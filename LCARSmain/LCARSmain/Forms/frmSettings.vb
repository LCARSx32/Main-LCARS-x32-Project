Option Strict On

'Imports LCARS.UI
Imports System.Runtime.InteropServices
Imports LCARS.x32.modSettings

Public Class frmSettings
    Inherits LCARS.LCARSForm

#Region " Mode changing "
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID And My.Application.IsSettingsMode Then
            m.Result = New IntPtr(1)
            If m.LParam.ToInt64() = 3 Then
                'They are telling this (settings) instance to run as a shell
                My.Application.SwitchToShellFromSettings()
                tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
                tbTitle.Text = "Settings"
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

#End Region

    Dim myColors(-1) As String
    Dim myFiles() As String
    Dim myLanguageFiles() As String
    Dim aliasList() As AliasEntry
    Dim customList As New List(Of CustomEntry)
    Dim alertList As New List(Of AlertEntry)
    Dim screenIndex As Integer = 0

    Private Class AliasEntry
        Public Command As String
        Public CommandAlias As String
        Public Description As String
        Public Overrides Function ToString() As String
            Return Command & ": " & CommandAlias
        End Function
    End Class

    Public Structure CustomEntry
        Dim Command As String
        Dim CommandName As String
    End Structure

    Private Structure AlertEntry
        Implements IComparable(Of AlertEntry)
        Dim id As Integer
        Dim Name As String
        Dim Color As String
        Dim Sound As String
        Function CompareTo(ByVal other As AlertEntry) As Integer Implements IComparable(Of AlertEntry).CompareTo
            Return Me.id.CompareTo(other.id)
        End Function
    End Structure

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Application.IsSettingsMode Then
            tbTitle.Color = LCARS.LCARScolorStyles.FunctionOffline
            tbTitle.Text = "Settings: System Offline"
        End If

        Dim beeping As Boolean = Boolean.Parse(GetSetting("LCARS x32", "Application", "ButtonBeep", "False"))
        Dim shellPath As String = ""

        lstSounds.DataSource = LCARSSound.sounds

        If System.Environment.OSVersion.Platform = PlatformID.Win32NT Then
            '2000 - Current
            Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            myReg = myReg.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Winlogon", False)
            shellPath = CType(myReg.GetValue("Shell"), String)
            shellPath = System.IO.Path.GetFileName(shellPath)

            myReg.Close()
        ElseIf System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            'Win98, 98SE, or ME (95 falls under this category, but doens't support .NET applications.
            Dim WinDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
            Dim strinput As String = ""

            If WinDir.Substring(Len(WinDir) - 1, 1) = "\" Then
                WinDir = WinDir.Substring(0, Len(WinDir) - 1)
            End If

            'a "cheat" to get the next folder up (which is the windows directory).
            WinDir = System.IO.Path.GetDirectoryName(WinDir)

            FileOpen(1, WinDir & "\system.ini", OpenMode.Input)
            Do Until EOF(1)
                Input(1, strinput)
                If strinput.Length >= 4 Then
                    If strinput.Substring(0, 5).ToLower = "shell" Then
                        strinput = strinput.ToLower.Replace("shell", "").Replace("=", "")
                        shellPath = System.IO.Path.GetFileName(strinput)
                    End If
                End If
            Loop
            FileClose(1)
        End If



        If shellPath Is Nothing OrElse shellPath.ToLower = "explorer.exe" Then
            fbShellSelect.Top = hpbExplorer.Top
            hpbExplorer.Color = LCARS.LCARScolorStyles.PrimaryFunction
            hpbLCARS.Color = LCARS.LCARScolorStyles.SystemFunction
        ElseIf shellPath.ToLower.StartsWith("lcarsmain.exe") Or shellPath.ToLower = "lcarsm~1.exe" Then
            fbShellSelect.Top = hpbLCARS.Top
            hpbLCARS.Color = LCARS.LCARScolorStyles.PrimaryFunction
            hpbExplorer.Color = LCARS.LCARScolorStyles.SystemFunction
        Else
            MsgBox(shellPath)
        End If

        cbVoice.Lit = CBool(GetSetting("LCARS x32", "Application", "SpeechOn", "TRUE"))

        If cbVoice.Lit Then
            cbVoice.SideText = "ON"
        Else
            cbVoice.SideText = "OFF"
        End If

        cpxVoiceTimeout.Lit = LCARS.x32.modSettings.CommandTimeoutEnabled
        If cpxVoiceTimeout.Lit Then
            cpxVoiceTimeout.SideText = "ON"
        Else
            cpxVoiceTimeout.SideText = "OFF"
        End If

        txtCommandTimeout.Text = LCARS.x32.modSettings.CommandTimeout.ToString()

        cbDates.Lit = CBool(GetSetting("LCARS x32", "Application", "Stardate", "FALSE"))
        If cbDates.Lit Then
            cbDates.SideText = "ON"
        Else
            cbDates.SideText = "OFF"
        End If

        Dim selectedMainScreen As Integer = MainScreen(screenIndex)

        Select Case selectedMainScreen
            Case 1
                picMain1_Click(sender, e)
            Case 2
                picMain2_Click(sender, e)
            Case 3
                picMain3_Click(sender, e)
            Case 4
                picMain4_Click(sender, e)

        End Select

        cbAutoHide.Lit = AutoHide(screenIndex)

        If cbAutoHide.Lit Then
            cbAutoHide.SideText = "ON"
        Else
            cbAutoHide.SideText = "OFF"
        End If

        'Speech Command Config
        txtLanguageCode.Text = GetSetting("LCARS X32", "Application", "SpeechCode", "409")
        'Command Aliases
        Dim myAlias As New AliasEntry

        ReDim aliasList(modSpeech.InternalVoiceCommands.Length)
        aliasList(0) = New AliasEntry()
        aliasList(0).Command = "computer"
        aliasList(0).CommandAlias = GetSetting("LCARS x32", "VoiceCommandAlias", "computer", "")
        aliasList(0).Description = "Command initializer. Must be spoken to use any other command."
        lstInternalCommands.Items.Add(aliasList(0))
        For i As Integer = 0 To modSpeech.InternalVoiceCommands.Length - 1
            aliasList(i + 1) = New AliasEntry()
            aliasList(i + 1).Command = modSpeech.InternalVoiceCommands(i).Name
            aliasList(i + 1).CommandAlias = GetSetting("LCARS X32", "VoiceCommandAlias", aliasList(i + 1).Command, "")
            aliasList(i + 1).Description = modSpeech.InternalVoiceCommands(i).Description
            lstInternalCommands.Items.Add(aliasList(i + 1))
        Next
        'Custom Commands
        Dim myVoiceReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
        myVoiceReg = Microsoft.Win32.Registry.CurrentUser
        myVoiceReg = myVoiceReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\CustomVoiceCommands", False)
        If Not myVoiceReg Is Nothing Then
            For intloop As Integer = 0 To myVoiceReg.ValueCount - 1
                Dim myCommand As New CustomEntry
                myCommand.CommandName = myVoiceReg.GetValueNames(intloop)
                myCommand.Command = CType(myVoiceReg.GetValue(myCommand.CommandName), String)
                customList.Add(myCommand)
                lstExternalCommands.Items.Add(myCommand.CommandName & ": " & myCommand.Command)
            Next
        End If
        'Sounds
        txtSoundPath.Text = "Button Sound Path: " & GetSetting("LCARS X32", "Application", "ButtonSound", Application.StartupPath & "\207.wav")

        'Updates
        lblVersion.Text = "Program Version: " & New LCARSUpdate.ProgramVersions(Application.StartupPath & "\versions.txt").getGlobalVersion()
        cpxAutoUpdates.Lit = CBool(GetSetting("LCARS X32", "Application", "Updates", "FALSE"))
        If cpxAutoUpdates.Lit Then
            cpxAutoUpdates.SideText = "ON"
        Else
            cpxAutoUpdates.SideText = "OFF"
        End If
        If GetSetting("LCARSUpdate", "Config", "UpdatePath", "release") = "experimental" Then
            fbChannelDot.Top = hpExperimental.Top
        ElseIf GetSetting("LCARSUpdate", "Config", "UpdatePath", "release") = "release" Then
            fbChannelDot.Top = hpRelease.Top
        Else
            fbChannelDot.Top = hpCustom.Top
            txtCustom.Visible = True
        End If
        txtCustom.Text = GetSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL")
        AddHandler txtCustom.TextChanged, AddressOf txtCustom_TextChanged


        'Alerts
        lblAlertName.Text = ""
        lblID.Text = ""
        loadAlerts()

        'Debug switch
        cbDebug.Lit = CBool(GetSetting("LCARS x32", "Application", "DebugSwitch", "FALSE"))
        If cbDebug.Lit Then
            cbDebug.SideText = "ON"
        End If

        cpxDDE.Lit = LCARS.x32.modSettings.DDEEnabled
        If cpxDDE.Lit Then
            cpxDDE.SideText = "OFF"
        End If

        'Load Colors
        myFiles = System.IO.Directory.GetFiles(Application.StartupPath & "\colors", "*.lxcp")
        lstColors.Items.Clear()
        For Each myFile As String In myFiles
            lstColors.Items.Add(System.IO.Path.GetFileNameWithoutExtension(myFile))
        Next

        'Load languages
        myLanguageFiles = System.IO.Directory.GetFiles(Application.StartupPath & "\lang", "*.lng")
        lstLanguages.Items.Clear()
        For Each myFile As String In myLanguageFiles
            lstLanguages.Items.Add(System.IO.Path.GetFileNameWithoutExtension(myFile))
        Next

    End Sub


    Private Sub lstColors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstColors.SelectedIndexChanged
        Try
            If lstColors.SelectedIndex > -1 Then
                Dim strinput As String = ""

                ReDim myColors(-1)

                FileOpen(1, myFiles(lstColors.SelectedIndex), OpenMode.Input)
                Do Until EOF(1)
                    Input(1, strinput)
                    ReDim Preserve myColors(myColors.GetUpperBound(0) + 1)
                    myColors(myColors.GetUpperBound(0)) = strinput
                Loop

                UpdateColors(pnlPreview)
            End If
        Catch
            MsgBox("Error loading color profile.  Please check the file '" & lstColors.SelectedItem.ToString() & ".lxcp' in the program folder.", MsgBoxStyle.Critical, "ERROR")
        End Try

        FileClose(1)

    End Sub

    Private Sub UpdateColors(ByVal container As Control)

        For Each myControl As Control In container.Controls
            If myControl.GetType.ToString.Substring(0, 5).ToLower = "lcars" Then
                Try
                    CType(myControl, LCARS.LCARSbuttonClass).ColorsAvailable.setColors(myColors)
                Catch
                End Try


            Else
                If myControl.Controls.Count > 0 Then
                    UpdateColors(myControl)
                End If
            End If
        Next
    End Sub

    Private Sub sbUseScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUseScheme.Click
        If myColors.GetUpperBound(0) > -1 Then
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(myColors, ","))
            RefreshColors()
        End If
    End Sub



    Private Sub picMain1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain1.Click
        picSelect.Location = New Point(picMain1.Left - 19, picMain1.Top - 15)
        MainScreen(screenIndex) = 1
    End Sub

    Private Sub picMain2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain2.Click
        picSelect.Location = New Point(picMain2.Left - 19, picMain2.Top - 15)
        MainScreen(screenIndex) = 2
    End Sub

    Private Sub picMain3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain3.Click
        picSelect.Location = New Point(picMain3.Left - 19, picMain3.Top - 15)
        MainScreen(screenIndex) = 3
    End Sub

    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
    End Sub

    Private Sub sbDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDefault.Click
        picWallpaper.Image = My.Resources.federationLogo
        SetWallpaper(picWallpaper.Image, screenIndex)
        Wallpaper(screenIndex) = "FederationLogo"
    End Sub

    Private Sub sbChangeWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbChangeWallpaper.Click
        Dim myFile As New OpenFileDialog
        Dim result As DialogResult

        myFile.Filter = "Image Files|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png;*.tif;*.tiff;*.ico"
        result = myFile.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            picWallpaper.Image = Image.FromFile(myFile.FileName)
            SetWallpaper(picWallpaper.Image, screenIndex)
            Wallpaper(screenIndex) = myFile.FileName
        End If
    End Sub



    Private Sub lstSizeMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSizeMode.SelectedIndexChanged
        Select Case lstSizeMode.SelectedIndex
            Case 0
                setWallpaperSizeMode(ImageLayout.Zoom, screenIndex)
            Case 1
                setWallpaperSizeMode(ImageLayout.Stretch, screenIndex)
            Case 2
                setWallpaperSizeMode(ImageLayout.Center, screenIndex)
            Case 3
                setWallpaperSizeMode(ImageLayout.Tile, screenIndex)
            Case Else
                Exit Sub
        End Select

        WallpaperSizeMode(screenIndex) = lstSizeMode.SelectedIndex
    End Sub

    Private Sub hpbLCARS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpbLCARS.Click
        fbShellSelect.Top = hpbLCARS.Top
        hpbLCARS.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpbExplorer.Color = LCARS.LCARScolorStyles.SystemFunction
        Try
            Process.Start(Application.StartupPath & "\SetShell.exe", "/q /set:lcars")
        Catch ex As Exception
            LCARS.UI.MsgBox("Could not launch SetShell.exe.  Please make sure it is in the same directory as LCARSmain.exe." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.OkCancel, "ERROR")
        End Try
    End Sub

    Private Sub hpbExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpbExplorer.Click
        fbShellSelect.Top = hpbExplorer.Top
        hpbExplorer.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpbLCARS.Color = LCARS.LCARScolorStyles.SystemFunction
        Try
            Process.Start(Application.StartupPath & "\SetShell.exe", "/q /set:explorer")
        Catch ex As Exception
            LCARS.UI.MsgBox("Could not launch SetShell.exe.  Please make sure it is in the same directory as LCARSmain.exe." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.OkCancel, "ERROR")
        End Try

    End Sub

    Private Sub picMain4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain4.Click
        picSelect.Location = New Point(picMain4.Left - 19, picMain4.Top - 15)
        MainScreen(screenIndex) = 4

    End Sub

    Private Sub cbAutoHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutoHide.Click
        cbAutoHide.Lit = Not cbAutoHide.Lit

        If cbAutoHide.Lit Then
            cbAutoHide.SideText = "ON"
            SetAutoHide(IAutohide.AutoHideModes.Hidden, screenIndex)

        Else
            cbAutoHide.SideText = "OFF"
            SetAutoHide(IAutohide.AutoHideModes.Disabled, screenIndex)
        End If

        AutoHide(screenIndex) = cbAutoHide.Lit

    End Sub

    Private Sub ltcSettings_SelectedTabChanged(ByVal Tab As LCARS.Controls.x32TabPage, ByVal TabIndex As System.Int32) Handles ltcSettings.SelectedTabChanged
        If ltcSettings.SelectedTab.Text = "ABOUT" Then
            Try
                Dim myreader As New System.IO.StreamReader(Application.StartupPath & "\About.txt")
                lblAbout.Text = myreader.ReadToEnd()
                myreader.Close()
            Catch ex As Exception
                lblAbout.Text = "Unable to load about message"
            End Try
        ElseIf ltcSettings.SelectedTab Is tabScreenSpecific Then
            'This code is here instead of in frmSettings_Load because it would need to be re-run
            'whenever the form changes size anyway.

            'Load screens
            pnlScreens.Controls.Clear()
            SyncLock Screen.AllScreens 'Prevents problems with a screen being removed while loading, hopefully
                Dim screenBounds(Screen.AllScreens.Length - 1) As RectangleF
                Dim screenLeft As Single = 0
                Dim screenTop As Single = 0
                Dim screenRight As Single = 0
                Dim screenBottom As Single = 0
                For i As Integer = 0 To screenBounds.Length - 1
                    screenBounds(i) = Screen.AllScreens(i).Bounds
                    If screenBounds(i).Left < screenLeft Then
                        screenLeft = screenBounds(i).Left
                    End If
                    If screenBounds(i).Top < screenTop Then
                        screenTop = screenBounds(i).Top
                    End If
                    If screenBounds(i).Right > screenRight Then
                        screenRight = screenBounds(i).Right
                    End If
                    If screenBounds(i).Bottom > screenBottom Then
                        screenBottom = screenBounds(i).Bottom
                    End If
                Next
                Dim hScale As Single = pnlScreens.Width / (screenRight - screenLeft)
                Dim vScale As Single = pnlScreens.Height / (screenBottom - screenTop)
                Dim scaleFactor As Single
                If hScale > vScale Then
                    scaleFactor = vScale
                Else
                    scaleFactor = hScale
                End If
                For i As Integer = 0 To screenBounds.Length - 1
                    screenBounds(i).Offset(-1 * screenLeft, -1 * screenTop)
                    screenBounds(i).X = screenBounds(i).X * scaleFactor
                    screenBounds(i).Y = screenBounds(i).Y * scaleFactor
                    screenBounds(i).Height = screenBounds(i).Height * scaleFactor
                    screenBounds(i).Width = screenBounds(i).Width * scaleFactor
                Next
                For i As Integer = 0 To screenBounds.Length - 1
                    'TODO: Use windowless controls, with a better representation of a screen
                    Dim myLabel As New Label()
                    With myLabel
                        .Text = i.ToString()
                        .BorderStyle = BorderStyle.FixedSingle
                        .Font = New Font("LCARS", 26, FontStyle.Regular, GraphicsUnit.Point)
                        .TextAlign = ContentAlignment.MiddleCenter
                        .BackColor = Color.Black
                        .ForeColor = Color.Orange
                        .Bounds = Rectangle.Round(screenBounds(i))
                    End With
                    AddHandler myLabel.Click, AddressOf myScreen_Click
                    pnlScreens.Controls.Add(myLabel)
                Next
            End SyncLock
        End If
    End Sub

    Private Sub cbDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDates.Click
        cbDates.Lit = Not cbDates.Lit
        If cbDates.Lit Then
            cbDates.SideText = "ON"
            SaveSetting("LCARS x32", "Application", "Stardate", "TRUE")
        Else
            cbDates.SideText = "OFF"
            SaveSetting("LCARS x32", "Application", "Stardate", "FALSE")
        End If
    End Sub

    Private Sub lstLanguages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLanguages.SelectedIndexChanged
        Try
            If lstLanguages.SelectedIndex > -1 Then
                Dim strinput As String = ""
                txtLanguagePreview.Text = ""

                FileOpen(1, myLanguageFiles(lstLanguages.SelectedIndex), OpenMode.Input)
                Do Until EOF(1)
                    Input(1, strinput)
                    txtLanguagePreview.Text = txtLanguagePreview.Text & vbNewLine & strinput
                Loop

            End If
        Catch
            MsgBox("Error loading language file.  Please check the file '" & lstLanguages.SelectedItem.ToString() & ".lng' in the lang folder.", MsgBoxStyle.Critical, "ERROR")
        End Try

        FileClose(1)

    End Sub

    Private Sub sbUseLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUseLanguage.Click
        If lstLanguages.SelectedIndex > -1 Then
            LanguageFileName(screenIndex) = lstLanguages.SelectedItem.ToString() & ".lng"
            curBusiness(screenIndex).loadLanguage()
        End If
    End Sub

#Region " Voice Command Settings "

    Private Sub cbVoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVoice.Click
        cbVoice.Lit = Not cbVoice.Lit

        SaveSetting("LCARS x32", "Application", "SpeechOn", cbVoice.Lit.ToString())

        If cbVoice.Lit Then
            cbVoice.SideText = "ON"
        Else
            cbVoice.SideText = "OFF"
        End If
        modSpeech.SpeechEnabled = cbVoice.Lit
    End Sub

    Dim editedCommand As Integer = -1

    Private Sub fbSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbSaveChanges.Click
        SaveSetting("LCARS X32", "Application", "SpeechCode", txtLanguageCode.Text)
        'Save timeout value
        Dim val As Double
        If Double.TryParse(txtCommandTimeout.Text, val) Then
            If val > 0 Then
                LCARS.x32.modSettings.CommandTimeout = val
                txtCommandTimeout.Text = val.ToString()
                'I don't think we need to change the current timeout, because it will be
                'canceled when it runs out or if another command is given.
            Else
                MsgBox("Timeout value must be greater than zero.")
                txtCommandTimeout.Text = LCARS.x32.modSettings.CommandTimeout.ToString()
            End If
        Else
            MsgBox("Non-numeric value entered for timeout.")
            txtCommandTimeout.Text = LCARS.x32.modSettings.CommandTimeout.ToString()
        End If
        'Remove all old values
        LCARS.TryDeleteSetting("LCARS x32", "CustomVoiceCommands")
        LCARS.TryDeleteSetting("LCARS x32", "VoiceCommandAlias")
        'Write new values
        For Each mycommand As AliasEntry In aliasList
            If mycommand.CommandAlias <> "" Then
                SaveSetting("LCARS X32", "VoiceCommandAlias", mycommand.Command, mycommand.CommandAlias)
            End If
        Next
        For Each mycommand As CustomEntry In customList
            SaveSetting("LCARS X32", "CustomVoiceCommands", mycommand.CommandName, mycommand.Command)
        Next
        If Not My.Application.IsSettingsMode Then
            modSpeech.RefreshSpeech()
        End If
    End Sub

    Private Sub sbInternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbInternal.Click
        pnlInternal.Visible = True
        lstInternalCommands.Visible = True
        pnlExternal.Visible = False
        lstExternalCommands.Visible = False
    End Sub

    Private Sub sbExternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExternal.Click
        pnlExternal.Visible = True
        lstExternalCommands.Visible = True
        pnlInternal.Visible = False
        lstInternalCommands.Visible = False
    End Sub

    Private Sub lstInternalCommands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInternalCommands.SelectedIndexChanged
        If lstInternalCommands.SelectedIndex = -1 Then Return
        lblIntCommandName.Text = "Command Name: " & aliasList(lstInternalCommands.SelectedIndex).Command
        txtAlias.Text = aliasList(lstInternalCommands.SelectedIndex).CommandAlias
        lblDescription.Text = "Description: " & aliasList(lstInternalCommands.SelectedIndex).Description
    End Sub

    Private Sub txtAlias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.TextChanged
        Dim newAlias As AliasEntry = CType(lstInternalCommands.SelectedItem, AliasEntry)
        newAlias.CommandAlias = txtAlias.Text
        lstInternalCommands.RefreshItem(lstInternalCommands.SelectedIndex)
    End Sub

    Private Sub sbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbAdd.Click
        lblError.Text = ""
        editedCommand = -1
        pnlAdd.Visible = True
        txtCommandName.Clear()
        txtCommandPath.Clear()
    End Sub

    Private Sub sbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbEdit.Click
        If lstExternalCommands.SelectedIndex <> -1 Then
            editedCommand = lstExternalCommands.SelectedIndex
            txtCommandName.Text = customList(lstExternalCommands.SelectedIndex).CommandName
            txtCommandPath.Text = customList(lstExternalCommands.SelectedIndex).Command
            lblError.Text = ""
            pnlAdd.Visible = True
        End If
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        pnlAdd.Visible = False
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        Dim valid As Boolean = True
        If txtCommandName.Text.Trim() = "" Then
            lblError.Text = "Unique, non-empty command name required."
            valid = False
        ElseIf txtCommandPath.Text.Trim = "" Then
            lblError.Text = "Non-empty command path required."
            valid = False
        ElseIf editedCommand = -1 Then
            For Each myelement As CustomEntry In customList
                If myelement.CommandName = txtCommandName.Text Then
                    valid = False
                    lblError.Text = "Command already in use. Choose another name."
                End If
            Next
        End If
        If valid Then
            lblError.Text = ""
            Dim myCommand As New CustomEntry
            myCommand.CommandName = txtCommandName.Text.ToLower()
            myCommand.Command = txtCommandPath.Text
            If editedCommand = -1 Then
                customList.Add(myCommand)
                lstExternalCommands.Items.Add(myCommand.CommandName.ToLower() & ": " & myCommand.Command)
            Else
                customList(editedCommand) = myCommand
                lstExternalCommands.Items(editedCommand) = myCommand.CommandName.ToLower() & ": " & myCommand.Command
            End If
            pnlAdd.Visible = False
        End If
    End Sub

    Private Sub sbRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRemove.Click
        If lstExternalCommands.SelectedIndex <> -1 Then
            customList.RemoveAt(lstExternalCommands.SelectedIndex)
            lstExternalCommands.Items.RemoveAt(lstExternalCommands.SelectedIndex)
        End If
    End Sub

    Private Sub cpxVoiceTimeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpxVoiceTimeout.Click
        cpxVoiceTimeout.Lit = Not cpxVoiceTimeout.Lit
        If cpxVoiceTimeout.Lit Then
            cpxVoiceTimeout.SideText = "ON"
        Else
            cpxVoiceTimeout.SideText = "OFF"
        End If
        LCARS.x32.modSettings.CommandTimeoutEnabled = cpxVoiceTimeout.Lit
        'No need to manually cancel the current timeout; it checks automatically.
    End Sub

#End Region

    Private Sub cpxAutoUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpxAutoUpdates.Click
        cpxAutoUpdates.Lit = Not cpxAutoUpdates.Lit
        If cpxAutoUpdates.Lit Then
            cpxAutoUpdates.SideText = "ON"
            SaveSetting("LCARS X32", "Application", "Updates", "TRUE")
        Else
            cpxAutoUpdates.SideText = "OFF"
            SaveSetting("LCARS X32", "Application", "Updates", "FALSE")
        End If
    End Sub

    Private Sub sbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCheck.Click
        Process.Start(Application.StartupPath & "\LCARSUpdate.exe")
    End Sub

    Private Sub hpRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpRelease.Click
        fbChannelDot.Top = hpRelease.Top
        txtCustom.Visible = False
        SaveSetting("LCARSUpdate", "Config", "UpdatePath", "release")
    End Sub

    Private Sub hpExperimental_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpExperimental.Click
        fbChannelDot.Top = hpExperimental.Top
        txtCustom.Visible = False
        SaveSetting("LCARSUpdate", "Config", "UpdatePath", "experimental")
    End Sub

    Private Sub hpCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpCustom.Click
        fbChannelDot.Top = hpCustom.Top
        SaveSetting("LCARSUpdate", "Config", "UpdatePath", "custom")
        txtCustom.Visible = True
    End Sub

    Private Sub txtCustom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveSetting("LCARSUpdate", "Config", "CustomURL", txtCustom.Text)
    End Sub

    Private Sub loadAlerts()
        lstAlerts.Items.Clear()
        alertList.Clear()
        Dim myAlerts As List(Of String) = LCARS.Alerts.GetAllAlertNames()
        For Each alert As String In myAlerts
            Dim myAlert As New AlertEntry
            myAlert.id = LCARS.Alerts.GetAlertID(alert)
            Dim alertstring As String = GetSetting("LCARS x32", "Alerts", myAlert.id.ToString(), "")
            Dim startIndex As Integer = alertstring.IndexOf("|")
            myAlert.Name = alertstring.Substring(0, startIndex)
            myAlert.Color = alertstring.Substring(startIndex + 1, 7)
            myAlert.Sound = alertstring.Substring(startIndex + 9)
            alertList.Add(myAlert)
        Next
        alertList.Sort()
        For Each myAlert As AlertEntry In alertList
            lstAlerts.Items.Add(myAlert.id & vbTab & myAlert.Name & " Alert" & vbTab & myAlert.Color & vbTab & myAlert.Sound)
        Next
    End Sub

    Private Sub SaveAlerts()
        LCARS.TryDeleteSetting("LCARS x32", "Alerts")
        For i As Integer = 0 To alertList.Count - 1
            Dim myAlert As AlertEntry = alertList(i)
            SaveSetting("LCARS x32", "Alerts", alertList(i).id.ToString(), myAlert.Name & "|" & myAlert.Color & "|" & myAlert.Sound)
        Next
        LCARS.Alerts.RefreshAlerts(Me.Handle)
        loadAlerts()
    End Sub

    Private Sub lstAlerts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAlerts.SelectedIndexChanged
        If lstAlerts.SelectedIndex >= 0 Then
            lblAlertName.Text = alertList(lstAlerts.SelectedIndex).Name & " Alert"
            lblID.Text = "ID=" & alertList(lstAlerts.SelectedIndex).id
            If alertList(lstAlerts.SelectedIndex).id < 2 Then
                lblID.Text = lblID.Text & " (System-defined)"
            End If
            fbAlertColor.Text = alertList(lstAlerts.SelectedIndex).Color
            fbAlertColor.CustomAlertColor = ColorTranslator.FromHtml(fbAlertColor.Text)
            fbAlertColor.RedAlert = LCARS.LCARSalert.Custom
            lblAlertSound.Text = "Sound Path: " & alertList(lstAlerts.SelectedIndex).Sound
        End If
    End Sub

    Private Sub fbAlertColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbAlertColor.Click
        Dim myPicker As New ColorDialog
        myPicker.Color = fbAlertColor.CustomAlertColor
        myPicker.ShowDialog()
        Dim temp As AlertEntry = alertList(lstAlerts.SelectedIndex)
        temp.Color = LCARS.Util.GetHexColor(myPicker.Color)
        alertList(lstAlerts.SelectedIndex) = temp
        fbAlertColor.CustomAlertColor = myPicker.Color
        fbAlertColor.RedAlert = LCARS.LCARSalert.Custom
        Dim tempIndex As Integer = lstAlerts.SelectedIndex
        SaveAlerts()
        lstAlerts.SelectedIndex = tempIndex
    End Sub

    Private Sub hpAddAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpAddAlert.Click
        Dim name As String = InputBox("Enter a name for the new alert", "Enter alert name", "New")
        If Not name = "" Then
            Dim id As Integer = LCARS.Alerts.RegisterAlert(name, Color.Magenta, )
            loadAlerts()
            lstAlerts.SelectedIndex = lstAlerts.Items.Count - 1
        End If
    End Sub

    Private Sub fbDeleteAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDeleteAlert.Click
        If lstAlerts.SelectedIndex >= 0 Then
            Dim result As MsgBoxResult = MsgBox("Are you sure you wish to delete this alert? Deleting an alert could cause instability in other programs.", MsgBoxStyle.YesNoCancel, "Delete alert?")
            If result = MsgBoxResult.Yes Then
                Try
                    LCARS.Alerts.DeleteAlert(alertList(lstAlerts.SelectedIndex).id)
                Catch ex As Exception
                    MsgBox(ex.ToString())
                    MsgBox("Unable to delete system-defined alert.")
                End Try
                loadAlerts()
            End If
        End If
    End Sub

    Private Sub cbDebug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDebug.Click
        If CBool(GetSetting("LCARS x32", "Application", "DebugSwitch", "TRUE")) Then
            SaveSetting("LCARS x32", "Application", "DebugSwitch", "FALSE")
            cbDebug.SideText = "OFF"
            cbDebug.Lit = False
        Else
            SaveSetting("LCARS x32", "Application", "DebugSwitch", "TRUE")
            cbDebug.SideText = "ON"
            cbDebug.Lit = True
        End If
    End Sub

    Private Sub fbBrowseSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbBrowseSound.Click
        Dim myFileSelect As New LCARSexplorer.frmFileSelect(Application.StartupPath, ".wav,", "Select a sound file")
        myFileSelect.ShowDialog()
        If myFileSelect.DialogResult = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(myFileSelect.ReturnPath) Then
                Dim temp As AlertEntry = alertList(lstAlerts.SelectedIndex)
                temp.Sound = myFileSelect.ReturnPath
                alertList(lstAlerts.SelectedIndex) = temp
                SaveAlerts()
            End If
        End If

    End Sub

    Private Sub myScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pnlScreenSpecific.Visible = True
        screenIndex = Integer.Parse(CType(sender, Label).Text)
        'Main screen
        Select Case MainScreen(screenIndex)
            Case 1
                picMain1_Click(Nothing, Nothing)
            Case 2
                picMain2_Click(Nothing, Nothing)
            Case 3
                picMain3_Click(Nothing, Nothing)
            Case 4
                picMain4_Click(Nothing, Nothing)
        End Select
        'Autohide
        cbAutoHide.Lit = AutoHide(screenIndex)
        cbAutoHide.SideText = If(AutoHide(screenIndex), "ON", "OFF")
        'Wallpaper
        If Wallpaper(screenIndex) = "FederationLogo" Then
            picWallpaper.Image = My.Resources.federationLogo
        Else
            Try
                picWallpaper.Image = Image.FromFile(Wallpaper(screenIndex))
            Catch ex As Exception
                LCARS.UI.MsgBox("Unable to find user-defined wallpaper. Reverting to default.", MsgBoxStyle.OkOnly, "Error:")
                picWallpaper.Image = My.Resources.federationLogo
            End Try
        End If

        'Wallpaper size mode
        lstSizeMode.SelectedIndex = WallpaperSizeMode(screenIndex)
        'Language file
        Dim language As String = LanguageFileName(screenIndex).ToLower()
        For i As Integer = 0 To myLanguageFiles.Length - 1
            If language = System.IO.Path.GetFileName(myLanguageFiles(i)).ToLower() Then
                lstLanguages.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub fbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbBack.Click
        pnlScreenSpecific.Visible = False
    End Sub

    Private Sub fbWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbWallpaper.Click
        pnlWallpaper.Visible = True
        pnlMainScreen.Visible = False
        pnlLanguage.Visible = False
        fbWallpaper.RedAlert = LCARS.LCARSalert.White
        fbMainScreen.RedAlert = LCARS.LCARSalert.Normal
        fbLanguage.RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub fbMainScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMainScreen.Click
        pnlWallpaper.Visible = False
        pnlMainScreen.Visible = True
        pnlLanguage.Visible = False
        fbWallpaper.RedAlert = LCARS.LCARSalert.Normal
        fbMainScreen.RedAlert = LCARS.LCARSalert.White
        fbLanguage.RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub fbLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbLanguage.Click
        pnlWallpaper.Visible = False
        pnlMainScreen.Visible = False
        pnlLanguage.Visible = True
        fbWallpaper.RedAlert = LCARS.LCARSalert.Normal
        fbMainScreen.RedAlert = LCARS.LCARSalert.Normal
        fbLanguage.RedAlert = LCARS.LCARSalert.White
    End Sub
#Region " Sounds "
    Dim soundEditing As Boolean = False
    Dim soundLoading As Boolean = False

    Private Sub lstSounds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSounds.SelectedIndexChanged
        If soundEditing Then Return
        soundLoading = True
        Dim s As LCARSSound = CType(lstSounds.SelectedItem, LCARSSound)
        sbSoundEnabled.Lit = s.Enabled
        lstSoundResources.BeginUpdate()
        lstSoundResources.Items.Clear()
        If s.CanUseResource Then
            For Each key As String In LCARSSound.ResourceDict.Keys
                lstSoundResources.Items.Add(key)
            Next
        Else
            lstSoundResources.Items.Add("DEFAULT")
        End If
        lstSoundResources.Items.Add("OTHER FILE")
        Dim path As String = s.Path
        If path.StartsWith("RESOURCE:") Then
            txtSoundPath.Visible = False
            fbChangeSound.Visible = False
            Dim f As String = path.Substring(9)
            lstSoundResources.SelectedItem = f
        Else
            If path = "DEFAULT" Then
                txtSoundPath.Visible = False
                fbChangeSound.Visible = False
                lstSoundResources.SelectedIndex = 0
            Else
                lstSoundResources.SelectedIndex = lstSoundResources.Items.Count - 1
                txtSoundPath.Visible = True
                fbChangeSound.Visible = True
                txtSoundPath.Text = path
            End If
        End If
        lstSoundResources.EndUpdate()
        soundLoading = False
    End Sub

    Private Sub sbSoundEnabled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSoundEnabled.Click
        soundEditing = True
        sbSoundEnabled.Lit = Not sbSoundEnabled.Lit
        CType(lstSounds.SelectedItem, LCARSSound).Enabled = sbSoundEnabled.Lit
        lstSounds.RefreshItem(lstSounds.SelectedIndex)
        soundEditing = False
    End Sub

    Private Sub fbChangeSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbChangeSound.Click
        Dim myFileSelect As New LCARSexplorer.frmFileSelect(Application.StartupPath, ".wav,", "Select a sound file")
        myFileSelect.ShowDialog()
        soundEditing = True
        If myFileSelect.DialogResult = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(myFileSelect.ReturnPath) Then
                Try
                    CType(lstSounds.SelectedItem, LCARSSound).Path = myFileSelect.ReturnPath
                Catch ex As IO.FileNotFoundException
                    MsgBox("Invalid item selected!")
                End Try
                lstSounds.RefreshItem(lstSounds.SelectedIndex)
            Else
                MsgBox("Invalid file selected")
            End If
        End If
        soundEditing = False
        lstSounds_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub lstSoundResources_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSoundResources.SelectedIndexChanged
        If soundLoading Then Return
        soundEditing = True
        Dim path As String
        If lstSoundResources.SelectedIndex = lstSoundResources.Items.Count - 1 Then
            txtSoundPath.Text = ""
            txtSoundPath.Visible = True
            fbChangeSound.Visible = True
            fbChangeSound_Click(sender, e)
            Return 'fbChangeSound_Click handles everything else
        ElseIf lstSoundResources.SelectedItem.ToString() = "DEFAULT" Then
            txtSoundPath.Visible = False
            fbChangeSound.Visible = False
            path = ""
        Else
            txtSoundPath.Visible = False
            fbChangeSound.Visible = False
            path = "RESOURCE:" & lstSoundResources.SelectedItem.ToString()
        End If
        Try
            CType(lstSounds.SelectedItem, LCARSSound).Path = path
        Catch ex As IO.FileNotFoundException
            MsgBox("Invalid item selected!")
        End Try
        lstSounds.RefreshItem(lstSounds.SelectedIndex)
        soundEditing = False
    End Sub

    Private Sub sbSoundTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSoundTest.Click
        If CType(lstSounds.SelectedItem, LCARSSound).CanUseResource Then
            CType(lstSounds.SelectedItem, LCARSSound).Test()
        Else
            ' button beep already playing
        End If
    End Sub

    Private Sub sbSoundTest_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbSoundTest.MouseDown
        'Use the actual button beep to play a button beep, otherwise disable it to prevent
        ' interference with the sound being tested.
        If CType(lstSounds.SelectedItem, LCARSSound).CanUseResource Then
            sbSoundTest.Beeping = False
        Else
            sbSoundTest.Beeping = True
        End If
    End Sub
#End Region

    Private Sub cpxDDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpxDDE.Click
        cpxDDE.Lit = Not cpxDDE.Lit
        LCARS.x32.modSettings.DDEEnabled = cpxDDE.Lit
        cpxDDE.SideText = If(cpxDDE.Lit, "ON", "OFF")
        If shellMode Then
            If cpxDDE.Lit Then
                initDDE()
            Else
                deinitDDE()
            End If
        End If
    End Sub
End Class