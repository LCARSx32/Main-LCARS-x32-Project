Option Strict Off 'Some speech types are badly defined. If this changes, fix this to On

Imports SpeechLib
Imports LCARS.UI

Module modSpeech
    Private SpeechEngine As SpInprocRecognizer
    Private Listener As SpInProcRecoContext    'The Main Recognition Object Used throughout the whole program. -- Shared Object: More Info on this later.
    Private grammar As ISpeechRecoGrammar                       'The Grammar Object so the program knows what is going on. -- Instanced Object: More Info on this later.
    Private vox As SpVoice
    Private continuousCommands As Boolean = False
    Private Confirm As VoiceCmd = Nothing
    Private Authorization As VoiceCmd = Nothing
    Friend RulesHandlers As New Dictionary(Of String, VoiceCmd)
    Friend console As New frmSpeechConsole
    Private WithEvents timeoutTimer As New System.Timers.Timer With {.AutoReset = False}

    Private Sub beginVoiceRecognition()
        'Clear data structures
        RulesHandlers.Clear()
        'Initialize internal commands
        For Each intCmd As InternalVoiceCmd In InternalVoiceCommands
            RulesHandlers.Add(intCmd.Name, intCmd)
        Next
        'Load external commands
        Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
        myReg = myReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\CustomVoiceCommands", False)
        If Not myReg Is Nothing Then
            For Each extCmd As String In myReg.GetValueNames()
                Dim command As String = CStr(myReg.GetValue(extCmd))
                'TODO: Change settings so that a description can be stored
                Dim myCommand As New ExternalVoiceCmd(extCmd, "External", extCmd, False)
                RulesHandlers.Add(myCommand.Name, myCommand)
            Next
        End If

        'Add commands to console
        console.ClearCommands()
        'TODO: Add "computer" + description
        For Each myItem As VoiceCmd In RulesHandlers.Values
            console.AddCommand(myItem)
        Next

        'Load up the speech recognition
        Try
            If Not Listener Is Nothing Then
                RemoveHandler Listener.Recognition, AddressOf OnReco
            End If
            Listener = Nothing
            grammar = Nothing
            SpeechEngine = Nothing
            SpeechEngine = New SpInprocRecognizer()

            Listener = SpeechEngine.CreateRecoContext()     'Create a new Reco Context Class
            Dim myInputs As ISpeechObjectTokens = Listener.Recognizer.GetAudioInputs()
            Listener.Recognizer.AudioInput = myInputs.Item(0) 'use the default audio input device
            grammar = Listener.CreateGrammar(1)              'Setup the Grammar
            grammar.DictationLoad()                       'Load dictation
            grammar.DictationSetState(SpeechRuleState.SGDSInactive) 'Set dictation inactive
            grammar.State = SpeechGrammarState.SGSEnabled
            Dim builder As ISpGrammarBuilder = grammar 'Somehow this works
            'Set up main rules
            Dim hStateMain As IntPtr
            builder.GetRule("Main", 0, SpeechLib.SpeechRuleAttributes.SRATopLevel, True, hStateMain)
            'Interim state
            Dim hStateMain2 As IntPtr
            builder.CreateNewState(hStateMain, hStateMain2)
            'Add word transition for init command ("Computer")
            Dim initText As String = GetSetting("LCARS x32", "VoiceCommandAlias", "computer", "computer")
            builder.AddWordTransition(hStateMain, hStateMain2, initText, " ", SPGRAMMARWORDTYPE.SPWT_LEXICAL, 1, Nothing)
            'Command rule
            Dim commandListPtr As IntPtr
            builder.GetRule("Command", 0, SpeechRuleAttributes.SRATopLevel, True, commandListPtr)
            builder.AddRuleTransition(hStateMain2, Nothing, commandListPtr, 1, Nothing)
            'Epsilon transition
            'Required to have a full path to Nothing
            builder.AddWordTransition(commandListPtr, Nothing, Nothing, Nothing, SPGRAMMARWORDTYPE.SPWT_LEXICAL, 1, Nothing)

            For Each myRule As VoiceCmd In RulesHandlers.Values
                Dim hStateRule As IntPtr
                builder.GetRule(myRule.Name, 0, SpeechRuleAttributes.SRATopLevel, True, hStateRule)
                myRule.BuildRule(builder, hStateRule)
                builder.AddRuleTransition(commandListPtr, Nothing, hStateRule, 1, Nothing)
            Next

            builder.Commit(0) ' Commit changes
            'Set rules to their initial states
            grammar.CmdSetRuleState("Main", SpeechRuleState.SGDSActive)
            grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSInactive)
            grammar.CmdSetRuleState("Confirm", SpeechRuleState.SGDSInactive)
            AddHandler Listener.Recognition, AddressOf OnReco
            vox = New SpVoice
        Catch ex As Runtime.InteropServices.COMException
            Select Case ex.ErrorCode
                Case -2147201021
                    MsgBox("Invalid language code. If your computer's speech recognition is not set to English (US), please change the language code.", MsgBoxStyle.OkOnly, "Error:")
                Case Else
                    LCARS.UI.MsgBox("Voice commands failed to initialize.  MS Speech may not be installed or working properly.", MsgBoxStyle.OkCancel, "ERROR:")
                    Dim myerrorfile As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Voice error.txt", True)
                    myerrorfile.WriteLine(ex.ToString)
                    myerrorfile.Close()
            End Select
        Catch ex As Exception
            LCARS.UI.MsgBox("Voice commands failed to initialize.  MS Speech may not be installed or working properly.", MsgBoxStyle.OkCancel, "ERROR:")
            Dim myerrorfile As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Voice error.txt", True)
            myerrorfile.WriteLine(ex.ToString)
            myerrorfile.Close()
        End Try
        needsReload = False
    End Sub
    Public Sub SimulateRecognition(ByVal input As String)
        If Not SpeechEnabled Then
            console.WriteLine("Speech recognition not enabled. Unable to parse input.")
            Return
        End If
        grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSActive)
        Listener.Recognizer.EmulateRecognition(input)
        grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSInactive)
    End Sub
    Private Sub OnReco(ByVal StreamNumber As Integer, ByVal StreamPosition As Object, ByVal RecognitionType As SpeechRecognitionType, ByVal Result As ISpeechRecoResult)
        console.WriteLine(Result.PhraseInfo.GetText().ToUpper())
        Dim rule As String = Result.PhraseInfo.Rule.Name
        If rule = "Main" Then
            If Result.PhraseInfo.Rule.Children.Item(0).Children Is Nothing Then
                AlertMuted = True
                grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSActive)
                LCARSSound.ListeningSound.Play()
                If LCARS.x32.modSettings.CommandTimeoutEnabled And Not continuousCommands Then
                    timeoutTimer.Interval = LCARS.x32.modSettings.CommandTimeout * 1000 'Convert sec to ms
                    timeoutTimer.Start()
                End If
            Else
                Dim commandName As String = Result.PhraseInfo.Rule.Children.Item(0).Children.Item(0).Name
                executeCommand(commandName, Result)
            End If
        Else
            timeoutTimer.Stop()
            Dim commandName As String = Result.PhraseInfo.Rule.Children.Item(0).Name
            executeCommand(commandName, Result)
        End If
    End Sub

    Private Sub executeCommand(ByVal name As String, ByRef result As ISpeechRecoResult)
        Dim command As VoiceCmd = Nothing
        Try
            command = RulesHandlers.Item(name)
        Catch ex As KeyNotFoundException
            console.WriteLine("Unable to determine rule: " & name)
        End Try
        If command.RequiresAuthorize Then
            Authorization = command
            'TODO: Create authorization sound
        ElseIf command.RequiresConfirm Then
            LCARSSound.ConfirmSound.Play()
            Confirm = command
        Else
            command.Execute(result)
            Confirm = Nothing
            Authorization = Nothing
        End If
        If Not continuousCommands Then
            grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSInactive)
            If AlertMuted Then AlertMuted = False
        End If
    End Sub

    Private Sub onCommandTimeout(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timeoutTimer.Elapsed
        If myDesktop.InvokeRequired Then
            myDesktop.Invoke(New System.Timers.ElapsedEventHandler(AddressOf onCommandTimeout), source, e)
        Else
            If Not continuousCommands And LCARS.x32.modSettings.CommandTimeoutEnabled Then
                grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSInactive)
                console.WriteLine("Command timed out (No command given)".ToUpper())
                LCARSSound.TimeoutSound.Play()
                If AlertMuted Then AlertMuted = False
            End If
        End If
    End Sub

    Friend Sub ShowConsole()
        console.Show()
        console.BringToFront()
        console.Activate()
    End Sub

    Public Event SpeechEnableChanged As EventHandler
    Private needsReload As Boolean = False

    Public Property SpeechEnabled() As Boolean
        Get
            If SpeechEngine Is Nothing Then
                Return False
            End If
            Return Listener.State = SpeechRecoContextState.SRCS_Enabled
        End Get
        Set(ByVal value As Boolean)
            If value Then
                If SpeechEngine Is Nothing Or needsReload Then
                    beginVoiceRecognition()
                Else
                    Listener.State = SpeechRecoContextState.SRCS_Enabled
                End If
            Else
                If SpeechEngine IsNot Nothing Then
                    Listener.State = SpeechRecoContextState.SRCS_Disabled
                End If
            End If
            RaiseEvent SpeechEnableChanged(Nothing, Nothing)
        End Set
    End Property

    Public Sub RefreshSpeech()
        If Not SpeechEnabled Then
            needsReload = True
        Else
            beginVoiceRecognition()
        End If
    End Sub

#Region " Internal Command Subs "
    Private Sub doMenu(ByVal result As ISpeechRecoResult)
        If curBusiness(0).myStartMenu IsNot Nothing Then
            curBusiness(0).myStartMenu.doClick(Nothing, Nothing)
        End If
    End Sub
    Private Sub doComputer(ByVal result As ISpeechRecoResult)
        curBusiness(0).myCompButton_Click(Nothing, Nothing)
    End Sub
    Private Sub doSettings(ByVal result As ISpeechRecoResult)
        curBusiness(0).mySettingsButton_Click(Nothing, Nothing)
    End Sub
    Private Sub doEngineering(ByVal result As ISpeechRecoResult)
        curBusiness(0).myEngineeringButton_Click(Nothing, Nothing)
    End Sub
    Private Sub doModeSelect(ByVal result As ISpeechRecoResult)
        curBusiness(0).myModeSelectButton_Click(Nothing, Nothing)
    End Sub
    Private Sub doDocuments(ByVal result As ISpeechRecoResult)
        curBusiness(0).myDocuments_Click(Nothing, Nothing)
    End Sub
    Private Sub doPictures(ByVal result As ISpeechRecoResult)
        curBusiness(0).myPictures_Click(Nothing, Nothing)
    End Sub
    Private Sub doMusic(ByVal result As ISpeechRecoResult)
        curBusiness(0).myMusic_Click(Nothing, Nothing)
    End Sub
    Private Sub doVideos(ByVal result As ISpeechRecoResult)
        curBusiness(0).myVideos_Click(Nothing, Nothing)
    End Sub
    'This is public because it is used in ApplicationEvents
    Public Sub doDeactivate(ByVal result As ISpeechRecoResult)
        Process.Start(Application.StartupPath & "\LCARSshutdown.exe", "/" & myDesktop.Handle.ToString & "/c")
    End Sub
    Private Sub doSelfDestruct(ByVal result As ISpeechRecoResult)
        curBusiness(0).myDestructButton_Click(Nothing, Nothing)
    End Sub
    Private Sub doLogOff(ByVal result As ISpeechRecoResult)
        shutDownOptions.ExitWindows(cWrapExitWindows.Action.LogOff)
    End Sub
    Private Sub doRedAlert(ByVal result As ISpeechRecoResult)
        GeneralAlert(0)
    End Sub
    Private Sub doCancelAlert(ByVal result As ISpeechRecoResult)
        CancelAlert()
    End Sub
    Private Sub doShutdown(ByVal result As ISpeechRecoResult)
        shutDownOptions.ExitWindows(cWrapExitWindows.Action.Shutdown)
    End Sub
    Private Sub doEndProgram(ByVal result As ISpeechRecoResult)
        Try
            Dim hWndApp As Integer = GetForegroundWindow()
            If Not hWndApp = CInt(GetSetting("LCARS x32", "Application", "MainWindowHandle")) Then
                modCommon.CloseWindow(New IntPtr(hWndApp))
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Private Sub doCancel(ByVal result As ISpeechRecoResult)
        continuousCommands = False
        Authorization = Nothing
        Confirm = Nothing
    End Sub
    Private Sub doStardate(ByVal result As ISpeechRecoResult)
        Try
            vox.Speak(LCARS.Stardate.getStardate(Now).ToString("F1"))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub doRunProgram(ByVal result As ISpeechRecoResult)
        Dim myRun As New frmRunProgram
        myRun.ShowDialog()
    End Sub
    Private Sub doDate(ByVal result As ISpeechRecoResult)
        Try
            vox.Speak(Now.ToLongDateString())
        Catch ex As Exception
        End Try
    End Sub
    Private Sub doTime(ByVal result As ISpeechRecoResult)
        Try
            vox.Speak(Now.ToLongTimeString())
        Catch ex As Exception
        End Try
    End Sub
    Private Sub doKeyboard(ByVal result As ISpeechRecoResult)
        curBusiness(0).myOSK_Click(Nothing, Nothing)
    End Sub
    Private Sub doTaskManager(ByVal result As ISpeechRecoResult)
        Try
            Process.Start("taskmgr")
        Catch ex As Exception
        End Try
        'Process.Start(Application.StartupPath & "\LCARSTaskManager.exe")
    End Sub
    Private Sub doContinuousCommands(ByVal result As ISpeechRecoResult)
        continuousCommands = True
        grammar.CmdSetRuleState("Command", SpeechRuleState.SGDSActive)
        Try
            vox.Speak("Continuous commands enabled.")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub doYellowAlert(ByVal result As ISpeechRecoResult)
        GeneralAlert(1)
    End Sub
    Private Sub doConfirm(ByVal result As ISpeechRecoResult)
        If Confirm IsNot Nothing Then
            Confirm.Execute(result)
            Confirm = Nothing
        End If
    End Sub
    Private Sub doHelp(ByVal result As ISpeechRecoResult)
        curBusiness(0).myHelp_Click(Nothing, Nothing)
    End Sub
    Private Sub doAuthorization(ByVal result As ISpeechRecoResult)
        If Authorization IsNot Nothing Then
            Authorization.Execute(result)
            Authorization = Nothing
        End If
    End Sub
    Private Sub doShowConsole(ByVal result As ISpeechRecoResult)
        ShowConsole()
    End Sub
    Private Sub doHideConsole(ByVal result As ISpeechRecoResult)
        console.Hide()
    End Sub
    Private Sub doWebBrowser(ByVal result As ISpeechRecoResult)
        curBusiness(0).myWebBrowser_Click(Nothing, Nothing)
    End Sub
    Private Sub doCrash(ByVal result As ISpeechRecoResult)
        'Causes an unhandled exception.
        If CBool(GetSetting("LCARS x32", "Application", "DebugSwitch", "False")) Then
            Throw New Exception()
        End If
    End Sub
    Private Sub doDisplayOff(ByVal result As ISpeechRecoResult)
        PostMessage(frmStartup.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, MonitorPowerStates.PowerOff)
    End Sub
    Private Sub doDisplayOn(ByVal result As ISpeechRecoResult)
        'Note: The line below is commented out because it will not work on Windows 10
        'PostMessage(frmStartup.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, MonitorPowerStates.PowerOn)
        mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero)
    End Sub

#End Region

#Region " Internal Command Definitions "
    Public InternalVoiceCommands() As InternalVoiceCmd = { _
  New InternalVoiceCmd("menu", "Shows the Start Menu.", New VoiceCmdSub(AddressOf doMenu), False), _
  New InternalVoiceCmd("my computer", "Opens LCARS file browser.", New VoiceCmdSub(AddressOf doComputer), False), _
  New InternalVoiceCmd("settings", "Opens settings.", New VoiceCmdSub(AddressOf doSettings), False), _
  New InternalVoiceCmd("engineering", "Opens system information program.", New VoiceCmdSub(AddressOf doEngineering), False), _
  New InternalVoiceCmd("mode select", "Shows screen chooser dialog.", New VoiceCmdSub(AddressOf doModeSelect), False), _
  New InternalVoiceCmd("my documents", "Opens LCARS file browser to show the ""My Documents"" folder.", New VoiceCmdSub(AddressOf doDocuments), False), _
  New InternalVoiceCmd("my pictures", "Opens LCARS file browser to show the ""My Pictures"" folder.", New VoiceCmdSub(AddressOf doPictures), False), _
  New InternalVoiceCmd("my music", "Opens LCARS file browser to show the ""My Music"" folder.", New VoiceCmdSub(AddressOf doMusic), False), _
  New InternalVoiceCmd("my videos", "Opens LCARS file browser to show the ""My Videos"" folder.", New VoiceCmdSub(AddressOf doVideos), False), _
  New InternalVoiceCmd("deactivate", "Closes LCARS.", New VoiceCmdSub(AddressOf doDeactivate), False), _
  New InternalVoiceCmd("self destruct", "Opens self destruct program.", New VoiceCmdSub(AddressOf doSelfDestruct), False), _
  New InternalVoiceCmd("log off", "Logs off computer.", New VoiceCmdSub(AddressOf doLogOff), True), _
  New InternalVoiceCmd("red alert", "Initiates a red alert.", New VoiceCmdSub(AddressOf doRedAlert), False), _
  New InternalVoiceCmd("cancel alert", "Cancels a red or yellow alert.", New VoiceCmdSub(AddressOf doCancelAlert), False), _
  New InternalVoiceCmd("shut down", "Shuts down computer.", New VoiceCmdSub(AddressOf doShutdown), True), _
  New InternalVoiceCmd("end program", "Closes current program.", New VoiceCmdSub(AddressOf doEndProgram), False), _
  New InternalVoiceCmd("cancel", "Ends continuous commands or cancels a command that requires confirmation.", New VoiceCmdSub(AddressOf doCancel), False), _
  New InternalVoiceCmd("stardate", "Gives the current stardate.", New VoiceCmdSub(AddressOf doStardate), False), _
  New InternalVoiceCmd("run program", "Brings up ""run program"" dialog.", New VoiceCmdSub(AddressOf doRunProgram), False), _
  New InternalVoiceCmd("date", "Gives the current date.", New VoiceCmdSub(AddressOf doDate), False), _
  New InternalVoiceCmd("time", "Gives the current time.", New VoiceCmdSub(AddressOf doTime), False), _
  New InternalVoiceCmd("keyboard", "Shows the On Screen Keyboard.", New VoiceCmdSub(AddressOf doKeyboard), False), _
  New InternalVoiceCmd("task manager", "Opens incomplete LCARS task manager.", New VoiceCmdSub(AddressOf doTaskManager), False), _
  New InternalVoiceCmd("continuous commands", "Removes need to say ""computer"" before every command.", New VoiceCmdSub(AddressOf doContinuousCommands), False), _
  New InternalVoiceCmd("yellow alert", "Initiates a yellow alert.", New VoiceCmdSub(AddressOf doYellowAlert), False), _
  New InternalVoiceCmd("confirmed", "Used to confirm a voice command.", New VoiceCmdSub(AddressOf doConfirm), False), _
  New InternalVoiceCmd("help", "Opens ""Help"" program.", New VoiceCmdSub(AddressOf doHelp), False), _
  New InternalVoiceCmd("authorization", "Confirms commands that have been set to require command authorization.", New VoiceCmdSub(AddressOf doAuthorization), False), _
  New InternalVoiceCmd("show console", "Shows the speech console", New VoiceCmdSub(AddressOf doShowConsole), False), _
  New InternalVoiceCmd("hide console", "Hides the speech console", New VoiceCmdSub(AddressOf doHideConsole), False), _
  New InternalVoiceCmd("web browser", "Starts the LCARS web browser", New VoiceCmdSub(AddressOf doWebBrowser), False), _
  New InternalVoiceCmd("display off", "Turns off the display", New VoiceCmdSub(AddressOf doDisplayOff), False), _
  New InternalVoiceCmd("display on", "Turns on the display", New VoiceCmdSub(AddressOf doDisplayOn), False) _
    }

#End Region
End Module
