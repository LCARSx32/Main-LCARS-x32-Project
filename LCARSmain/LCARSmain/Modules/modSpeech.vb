Imports SpeechLib
Imports LCARS.UI

Module modSpeech
    Dim SpeechEngine As SpInprocRecognizer
    Public Listener As SpInProcRecoContext    'The Main Recognition Object Used throughout the whole program. -- Shared Object: More Info on this later.
    Dim vGrammar As ISpeechRecoGrammar                       'The Grammar Object so the program knows what is going on. -- Instanced Object: More Info on this later.
    Dim HypoCount As Integer
    Dim vCommands As New Collection
    Dim listenCommands As Boolean = False
    Dim vox As SpVoice
    Dim continuousCommands As Boolean = False
    Dim Confirm As String
    Dim Authorization As String = ""
    Dim AliasList As New Collection
    Dim CustomList As New Collection
    Friend console As New frmSpeechConsole
    Dim WithEvents timeoutTimer As New System.Timers.Timer With {.AutoReset = False}

    Public Structure AliasEntry
        Dim Command As String
        Dim CommandAlias As String
    End Structure

    Public Structure CustomEntry
        Dim Command As String
        Dim CommandName As String
    End Structure

    Public Sub beginVoiceRecognition()
        'Get the list of aliases and custom commands

        'Aliases
        AliasList.Clear()

        Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
        myReg = myReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\VoiceCommandAlias", False)
        If Not myReg Is Nothing Then
            For intloop As Integer = 0 To myReg.ValueCount - 1
                Dim myAlias As New AliasEntry
                myAlias.Command = myReg.GetValueNames(intloop)
                myAlias.CommandAlias = myReg.GetValue(myAlias.Command)
                AliasList.Add(myAlias)
            Next
        End If
        'Custom Commands
        'No aliases for these, as they can just be renamed
        CustomList.Clear()
        myReg = Microsoft.Win32.Registry.CurrentUser
        myReg = myReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\CustomVoiceCommands", False)
        If Not myReg Is Nothing Then
            For intloop As Integer = 0 To myReg.ValueCount - 1
                Dim myCommand As New CustomEntry
                myCommand.CommandName = myReg.GetValueNames(intloop)
                myCommand.Command = myReg.GetValue(myCommand.CommandName)
                CustomList.Add(myCommand)
            Next
        End If


        'Rewrite commands.xml
        Try
            Dim myCode As String = GetSetting("LCARS x32", "Application", "SpeechCode", "409")
            Dim mywriter As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Temp & "/commands.xml")
            With mywriter
                'Stuff that's in the file regardless
                .WriteLine("<GRAMMAR LANGID=""" & myCode & """>")
                .WriteLine("  <!-- ""Constant"" definitions -->")
                .WriteLine("  <DEFINE>")
                .WriteLine("    <ID NAME=""Initiator"" VAL=""1""/>")
                .WriteLine("    <ID NAME=""MainCommands"" VAL=""2""/>")
                .WriteLine("  </DEFINE>")
                .WriteLine("  <!-- Rule definitions -->")
                .WriteLine("  <RULE NAME=""Init"" ID=""Initiator"" TOPLEVEL=""ACTIVE"">")
                .WriteLine("    <L>")
                .WriteLine("      <P>" & getCommandAlias("computer") & "</P>") 'Allows different modes of address ("Hey, Pea-Brain")
                .WriteLine("    </L>")
                .WriteLine("  </RULE>")
                .WriteLine("  <RULE NAME=""Commands"" ID=""MainCommands"" TOPLEVEL=""ACTIVE"">")
                .WriteLine("    <L>")
                'Code to arrange all names
                .WriteLine("      <P>" & getCommandAlias("menu") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("my computer") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("settings") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("engineering") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("mode select") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("my documents") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("my pictures") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("my music") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("my videos") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("deactivate") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("self destruct") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("log off") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("red alert") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("cancel alert") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("shut down") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("end program") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("cancel") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("stardate") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("run program") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("date") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("time") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("keyboard") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("task manager") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("continuous commands") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("yellow alert") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("confirmed") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("help") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("authorization") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("show console") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("hide console") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("web browser") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("display off") & "</P>")
                .WriteLine("      <P>" & getCommandAlias("display on") & "</P>")
                If GetSetting("LCARS x32", "Application", "DebugSwitch", "False") Then
                    .WriteLine("      <P>crash test</P>")
                End If
                .WriteLine("      <P>tea earl grey hot</P>")
                'Code to add Custom Commands
                For Each myCommand As CustomEntry In CustomList
                    .WriteLine("      <P>" & myCommand.CommandName & "</P>")
                Next
                'More stuff that's always the same
                .WriteLine("    </L>")
                .WriteLine("  </RULE>")
                .WriteLine("</GRAMMAR>")
            End With
            mywriter.Close()
        Catch ex As Exception
            MsgBox("Error rewriting commands.xml" & vbNewLine & ex.ToString())
        End Try

        'Load up the speech recognition
        Try
            If Not Listener Is Nothing Then
                RemoveHandler Listener.Recognition, AddressOf OnReco
            End If
            Listener = Nothing
            vGrammar = Nothing
            SpeechEngine = Nothing
            SpeechEngine = New SpInprocRecognizer

            Listener = SpeechEngine.CreateRecoContext     'Create a new Reco Context Class
            Dim myInputs As ISpeechObjectTokens = Listener.Recognizer.GetAudioInputs
            Listener.Recognizer.AudioInput = myInputs.Item(0) 'use the default audio input device
            vGrammar = Listener.CreateGrammar(1)              'Setup the Grammar
            vGrammar.DictationLoad()                       'Load the Grammar
            vGrammar.CmdLoadFromFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\commands.xml", SpeechLoadOption.SLOStatic)
            vGrammar.DictationSetState(SpeechRuleState.SGDSInactive)
            vGrammar.State = SpeechGrammarState.SGSEnabled
            vGrammar.CmdSetRuleIdState(1, SpeechRuleState.SGDSActive)
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
    End Sub
    Public Sub SimulateRecognition(ByVal input As String)
        console.lstHistory.Items.Add(input.ToUpper())
        ExecuteCommand(getCommandName(input).ToLower())
    End Sub
    Private Sub OnReco(ByVal StreamNumber As Integer, ByVal StreamPosition As Object, ByVal RecognitionType As SpeechRecognitionType, ByVal Result As ISpeechRecoResult)
        Dim recoResult As String = Result.PhraseInfo.GetText 'Create a new string, and assign the recognized text to it.
        With console.lstHistory
            .Items.Add(recoResult.ToUpper())
        End With
        Dim command As String = getCommandName(recoResult.ToLower()).ToLower() 'Find the internal name for the command, if existant
        If command = "computer" Then
            vGrammar.CmdSetRuleIdState(2, SpeechRuleState.SGDSActive)
            listenCommands = True
            muteAlert = True
            LCARSSound.ListeningSound.Play()
            If LCARS.x32.modSettings.CommandTimeoutEnabled And Not continuousCommands Then
                timeoutTimer.Interval = LCARS.x32.modSettings.CommandTimeout * 1000 'Convert sec to ms
                timeoutTimer.Start()
            End If
        Else
            If listenCommands = True Then
                timeoutTimer.Stop()
                'Get command's alias (if existant) and send it to the command interpreter
                ExecuteCommand(command)
                If Not continuousCommands Then listenCommands = False 'Handles Continuous Commands function, though regulated by command interpreter.
            End If
            muteAlert = False

        End If

    End Sub

    Private Sub onCommandTimeout(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timeoutTimer.Elapsed
        If myDesktop.InvokeRequired Then
            myDesktop.Invoke(New System.Timers.ElapsedEventHandler(AddressOf onCommandTimeout), source, e)
        Else
            If Not continuousCommands And listenCommands And LCARS.x32.modSettings.CommandTimeoutEnabled Then
                listenCommands = False
                LCARSSound.TimeoutSound.Play()
                console.lstHistory.Items.Add("Command timed out (No command given)".ToUpper())
            End If
        End If
    End Sub

    'TODO: Replace these three functions with a dictionary or two
    Public Function getCommandAlias(ByVal commandAlias As String) As String
        Dim returnCommand As String = commandAlias
        For Each myentry As AliasEntry In AliasList
            If myentry.Command.ToLower() = commandAlias.ToLower() Then
                returnCommand = myentry.CommandAlias.ToLower()
                Exit For
            End If
        Next
        Return returnCommand
    End Function

    Public Function getCommandName(ByVal commandAlias As String) As String
        Dim returnCommand As String = commandAlias
        For Each myentry As AliasEntry In AliasList
            If String.Compare(myentry.CommandAlias, commandAlias, True) = 0 Then
                returnCommand = myentry.Command.ToLower()
                Exit For
            End If
        Next
        Return returnCommand
    End Function

    Public Function getCustomCommand(ByVal commandName As String) As String
        Dim returnPath As String = ""
        For Each myEntry As CustomEntry In CustomList
            If myEntry.CommandName.ToLower() = commandName.ToLower() Then
                returnPath = myEntry.Command
            End If
        Next
        Return returnPath
    End Function

    Public Sub ExecuteCommand(ByVal command As String)
        'Executes all commands that do not affect the speech recognizer.
        'Here is where you add the code for the functionality of the command.
        'Be sure to add it to the "commands.xml" generator as well.
        'Also handles commands from text interface.

        If GetSetting("LCARS x32", "Authorization", command, "FALSE") And Authorization <> "" Then
            vox.Speak("Command authorization required")
            Authorization = command
        Else
            Dim sender As New Object
            Dim myE As New System.EventArgs
            Select Case command.ToLower
                Case "menu"
                    curBusiness(0).myStartMenu.doClick(sender, myE)
                Case "my computer"
                    curBusiness(0).myCompButton_Click(sender, myE)
                Case "settings"
                    curBusiness(0).mySettingsButton_Click(sender, myE)
                Case "engineering"
                    curBusiness(0).myEngineeringButton_Click(sender, myE)
                Case "mode select"
                    curBusiness(0).myModeSelectButton_Click(sender, myE)
                Case "my documents"
                    curBusiness(0).myDocuments.doClick(sender, myE)
                Case "my pictures"
                    curBusiness(0).myPictures.doClick(sender, myE)
                Case "my music"
                    Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                Case "my videos"
                    curBusiness(0).myVideos.doClick(sender, myE)
                Case "deactivate"
                    Process.Start(Application.StartupPath & "\LCARSshutdown.exe", "/" & myDesktop.Handle.ToString & "/c")
                Case "self destruct"
                    curBusiness(0).myDestruct.doClick(sender, myE)
                Case "log off"
                    LCARSSound.ConfirmSound.Play()
                    Confirm = "log off"
                Case "red alert"
                    GeneralAlert(0)
                Case "cancel alert"
                    cancelAlert = True
                Case "shut down"
                    LCARSSound.ConfirmSound.Play()
                    Confirm = "shut down"
                Case "end program"
                    Try
                        Dim hWndApp As IntPtr = GetForegroundWindow()
                        If Not hWndApp = Convert.ToInt64(GetSetting("LCARS x32", "Application", "MainWindowHandle")) Then
                            modCommon.CloseWindow(hWndApp)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString())
                    End Try
                Case "cancel"
                    continuousCommands = False
                Case "stardate"
                    Try
                        vox.Speak(LCARS.Stardate.getStardate(Now).ToString("F1"))
                    Catch ex As Exception
                    End Try
                Case "run program"
                    Dim myRun As New frmRunProgram
                    myRun.ShowDialog()
                Case "date"
                    Try
                        vox.Speak(Now.ToLongDateString())
                    Catch ex As Exception
                    End Try
                Case "time"
                    Try
                        vox.Speak(Now.ToLongTimeString())
                    Catch ex As Exception
                    End Try
                Case "keyboard"
                    curBusiness(0).myOSK.doClick(sender, myE)
                Case "task manager"
                    Try
                        Process.Start("taskmgr")
                    Catch ex As Exception
                    End Try
                    'Process.Start(Application.StartupPath & "\LCARSTaskManager.exe")
                Case "continuous commands"
                    continuousCommands = True
                    Try
                        vox.Speak("Continuous commands enabled.")
                    Catch ex As Exception
                    End Try
                Case "yellow alert"
                    GeneralAlert(1)
                Case "confirmed"
                    Select Case Confirm
                        Case "shut down"
                            shutDownOptions.ExitWindows(cWrapExitWindows.Action.Shutdown)
                        Case "log off"
                            shutDownOptions.ExitWindows(cWrapExitWindows.Action.LogOff)
                        Case Else
                            MsgBox("Invalid in current context")
                    End Select
                    Confirm = ""
                Case "help"
                    curBusiness(0).myHelp.doClick(sender, myE)
                Case "authorization"
                    ExecuteCommand(Authorization)
                Case "show console"
                    ShowConsole()
                Case "hide console"
                    console.Hide()
                Case "web browser"
                    curBusiness(0).myWebBrowser.doClick(sender, myE)
                Case "crash test"
                    'Causes an unhandled exception.
                    If GetSetting("LCARS x32", "Application", "DebugSwitch", "False") Then
                        Throw New Exception()
                    End If
                Case "tea earl grey hot"
                    My.Computer.Audio.Play(My.Resources._095, AudioPlayMode.Background)
                Case "display off"
                    PostMessage(frmStartup.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, MonitorPowerStates.PowerOff)
                Case "display on"
                    'Note: The line below is commented out because it will not work on Windows 10
                    'PostMessage(frmStartup.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, MonitorPowerStates.PowerOn)
                    mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero)
                Case Else 'Searches for .exe files for custom commands
                    Dim inputString As String = getCustomCommand(command.ToLower())
                    Try
                        If IO.File.Exists(inputString) Then
                            'The command string is an absolute path.
                            Dim myprocess As New Process
                            myprocess.StartInfo.FileName = inputString
                            myprocess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(inputString)
                            myprocess.Start()
                        Else
                            'It isn't, so jump to the catch
                            Throw New Exception
                        End If
                    Catch ex As Exception
                        'The command will be interpreted as an absolute path, followed by arguments
                        Try
                            Dim myProcess As New Process()
                            If (inputString.Substring(0, 1) = """") Then
                                Dim splitIndex As Integer = inputString.Substring(1).IndexOf("""") + 2
                                myProcess.StartInfo.FileName = inputString.Substring(0, splitIndex)
                                myProcess.StartInfo.Arguments = inputString.Substring(splitIndex + 1)
                                myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                            Else
                                myProcess.StartInfo.FileName = inputString.Split(" ")(0)
                                myProcess.StartInfo.Arguments = inputString.Substring(myProcess.StartInfo.FileName.Length + 1)
                                myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                            End If
                            myProcess.Start()
                        Catch ex1 As Exception
                            'Throw it to shell and see what happens.
                            Try
                                Dim myID As Integer
                                myID = Shell(inputString, AppWinStyle.NormalFocus)
                                Dim myprocess As Process = Process.GetProcessById(myID)
                            Catch ex2 As Exception
                                'Throw it to Process.Start and hope for the best
                                Try
                                    Dim myProcess As Process = Process.Start(inputString)
                                Catch ex3 As Exception
                                    MsgBox("Error: " & vbNewLine & vbNewLine & ex3.Message)
                                End Try
                            End Try
                        End Try

                    End Try
            End Select
        End If
    End Sub

    Friend Sub ShowConsole()
        'Dim commandList() As String = {"menu", "my computer", "settings", "engineering", _
        '                       "mode select", "my documents", "my pictures", _
        '                       "my music", "my videos", "deactivate", "self destruct", _
        '                       "log off", "red alert", "cancel alert", "shut down", _
        '                       "end program", "cancel", "stardate", "run program", _
        '                       "date", "time", "keyboard", "task manager", "continuous commands", _
        '                       "yellow alert", "confirmed", "help", "authorization", "show console", _
        '                       "hide console"}
        console.lstCommands.Items.Clear()
        With console.lstCommands.Items
            .Add(getCommandAlias("computer").ToUpper() & ": Command initializer. Must be spoken to use any other command.")
            .Add(getCommandAlias("menu").ToUpper() & ": Shows the Start Menu.")
            .Add(getCommandAlias("my computer").ToUpper() & ": Opens LCARS file browser.")
            .Add(getCommandAlias("settings".ToUpper()) & ": Opens settings.")
            .Add(getCommandAlias("engineering").ToUpper() & ": Opens system information program.")
            .Add(getCommandAlias("mode select").ToUpper() & ": Shows screen chooser dialog.")
            .Add(getCommandAlias("my documents").ToUpper() & ": Opens LCARS file browser to show the ""My Documents"" folder.")
            .Add(getCommandAlias("my pictures").ToUpper() & ": Opens LCARS file browser to show the ""My Pictures"" folder.")
            .Add(getCommandAlias("my music").ToUpper() & ": Opens LCARS file browser to show the ""My Music"" folder.")
            .Add(getCommandAlias("my videos").ToUpper() & ": Opens LCARS file browser to show the ""My Videos"" folder.")
            .Add(getCommandAlias("deactivate").ToUpper() & ": Closes LCARS.")
            .Add(getCommandAlias("self destruct").ToUpper() & ": Opens self destruct program.")
            .Add(getCommandAlias("log off").ToUpper() & ": Logs off computer. Requires confirmation")
            .Add(getCommandAlias("red alert".ToUpper()) & ": Initiates a red alert.")
            .Add(getCommandAlias("cancel alert").ToUpper() & ": Cancels a red or yellow alert.")
            .Add(getCommandAlias("shut down").ToUpper() & ": Shuts down computer. Requires confirmation.")
            .Add(getCommandAlias("end program").ToUpper() & ": Closes current program.")
            .Add(getCommandAlias("cancel").ToUpper() & ": Ends continuous commands.")
            .Add(getCommandAlias("stardate").ToUpper() & ": Gives the current stardate.")
            .Add(getCommandAlias("run program").ToUpper() & ": Brings up ""run program"" dialog.")
            .Add(getCommandAlias("date").ToUpper() & ": Gives the current date.")
            .Add(getCommandAlias("time").ToUpper() & ": Gives the current time.")
            .Add(getCommandAlias("keyboard").ToUpper() & ": Shows the On Screen Keyboard.")
            .Add(getCommandAlias("task manager").ToUpper() & ": Opens incomplete LCARS task manager.")
            .Add(getCommandAlias("continuous commands").ToUpper() & ": Removes need to say ""computer"" before every command.")
            .Add(getCommandAlias("yellow alert").ToUpper() & ": Initiates a yellow alert.")
            .Add(getCommandAlias("confirmed").ToUpper() & ": Used to confirm a voice command.")
            .Add(getCommandAlias("help").ToUpper() & ": Opens ""Help"" program.")
            .Add(getCommandAlias("authorization").ToUpper() & ": Confirms commands that have been set to require command authorization.")
            .Add(getCommandAlias("show console").ToUpper() & ": Shows the speech console")
            .Add(getCommandAlias("hide console").ToUpper() & ": Hides the speech console")
            .Add(getCommandAlias("web browser").ToUpper() & ": Starts the LCARS web browser")
            .Add(getCommandAlias("display off").ToUpper() & ": Turns off the display")
            .Add(getCommandAlias("display on").ToUpper() & ": Turns on the display")
            For Each myitem As CustomEntry In CustomList
                .Add(myitem.CommandName.ToUpper() & ": " & myitem.Command)
            Next
        End With
        If curBusiness(0).mySpeech.Lit Then
            console.fbOnOff.Lit = True
            console.fbOnOff.Text = "Recognition on"
        Else
            console.fbOnOff.Lit = False
            console.fbOnOff.Text = "Recognition off"
        End If
        console.Show()
        console.BringToFront()
        console.Activate()
    End Sub
End Module
