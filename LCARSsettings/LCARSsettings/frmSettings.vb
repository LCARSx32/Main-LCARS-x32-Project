'Imports LCARS.UI
Imports System.Runtime.InteropServices

Public Class frmSettings

#Region " Window Resizing "
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer
    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public InterMsgID As Integer
    Const WM_COPYDATA As Integer = &H4A
    Dim x32Handle As IntPtr = IntPtr.Zero
    Public Const HWND_BROADCAST As Integer = &HFFFF

    Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure
    Dim WithEvents interop As New LCARS.x32Interop

    Private Sub interop_BeepingChanged(ByVal Beeping As Boolean) Handles interop.BeepingChanged
        LCARS.SetBeeping(Me, Beeping)
    End Sub

    Private Sub interop_ColorsChanged() Handles interop.ColorsChanged
        LCARS.UpdateColors(Me)
    End Sub

    Private Sub interop_LCARSx32Closing() Handles interop.LCARSx32Closing
        Application.Exit()
    End Sub

    Private Sub WorkingAreaUpdated(ByVal NewArea As System.Drawing.Rectangle) Handles interop.WorkingAreaChanged
        Me.Bounds = NewArea
    End Sub

#End Region


    Dim myColors(-1) As String
    Dim myFiles() As String
    Dim myLanguageFiles() As String
    Dim selectedMainScreen As String
    Dim aliasList() As AliasEntry
    Dim customList As New List(Of CustomEntry)
    Dim alertList As New List(Of AlertEntry)
    Public Structure AliasEntry
        Dim Command As String
        Dim CommandAlias As String
    End Structure

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
        Function CompareTo(ByVal other As AlertEntry) As Integer Implements IComparable(Of LCARSsettings.frmSettings.AlertEntry).CompareTo
            Return Me.id.CompareTo(other.id)
        End Function
    End Structure

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        interop.Init()
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        Dim myCommands() As String = System.Environment.CommandLine.Split("/")
        If myCommands.GetUpperBound(0) > 0 Then
            x32Handle = myCommands(1) 'GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        End If

        SendMessage(x32Handle, InterMsgID, Me.Handle, 1)


        Dim beeping As Boolean = Boolean.Parse(GetSetting("LCARS x32", "Application", "ButtonBeep", "False"))
        Dim shellPath As String = ""

        Me.Bounds = Screen.PrimaryScreen.WorkingArea



        cbBeeping.Lit = beeping
        If cbBeeping.Lit Then
            cbBeeping.SideText = "ON"
        Else
            cbBeeping.SideText = "OFF"
        End If

        If System.Environment.OSVersion.Platform = PlatformID.Win32NT Then
            '2000 - Current
            Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            myReg = myReg.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Winlogon", False)
            shellPath = myReg.GetValue("Shell")
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
        ElseIf shellPath.ToLower = "lcarsmain.exe -s" Or shellPath.ToLower = "lcarsm~1.exe" Then
            fbShellSelect.Top = hpbLCARS.Top
            hpbLCARS.Color = LCARS.LCARScolorStyles.PrimaryFunction
            hpbExplorer.Color = LCARS.LCARScolorStyles.SystemFunction
        Else
            MsgBox(shellPath)
        End If

        cbVoice.Lit = GetSetting("LCARS x32", "Application", "SpeechOn", "TRUE")

        If cbVoice.Lit Then
            cbVoice.SideText = "ON"
        Else
            cbVoice.SideText = "OFF"
        End If

        cbDates.Lit = GetSetting("LCARS x32", "Application", "Stardate", "FALSE")
        If cbDates.Lit Then
            cbDates.SideText = "ON"
        Else
            cbDates.SideText = "OFF"
        End If

        selectedMainScreen = GetSetting("LCARS X32", "Load", "GUI Form", 1)

        Select Case selectedMainScreen
            Case "1"
                picMain1_Click(sender, e)
            Case "2"
                picMain2_Click(sender, e)
            Case "3"
                picMain3_Click(sender, e)
            Case "4"
                picMain4_Click(sender, e)

        End Select

        cbAutoHide.Lit = CBool(GetSetting("LCARS X32", "LOAD", "AutoHide", "0"))

        If cbAutoHide.Lit Then
            cbAutoHide.SideText = "ON"
        Else
            cbAutoHide.SideText = "OFF"
        End If

        'Speech Command Config
        txtLanguageCode.Text = GetSetting("LCARS X32", "Application", "SpeechCode", "409")
        'Command Aliases
        Dim myAlias As New AliasEntry
        Dim myCommandList() As String = {"computer", "menu", "my computer", "settings", _
                                         "engineering", "mode select", "my documents", _
                                         "my pictures", "my music", "my videos", "deactivate", _
                                         "self destruct", "log off", "red alert", _
                                         "cancel alert", "shut down", "end program", "cancel", _
                                         "stardate", "run program", "date", "time", "keyboard", _
                                         "task manager", "continuous commands", "yellow alert", _
                                         "confirmed", "help", "authorization", "show console", _
                                         "hide console", "web browser"}
        ReDim aliasList(myCommandList.Length - 1)
        For i As Integer = 0 To myCommandList.Length - 1
            aliasList(i).Command = myCommandList(i)
            aliasList(i).CommandAlias = GetSetting("LCARS X32", "VoiceCommandAlias", aliasList(i).Command, "")
            lstInternalCommands.Items.Add(aliasList(i).Command & ": " & aliasList(i).CommandAlias)
        Next
        'Custom Commands
        Dim myVoiceReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
        myVoiceReg = Microsoft.Win32.Registry.CurrentUser
        myVoiceReg = myVoiceReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\CustomVoiceCommands", False)
        If Not myVoiceReg Is Nothing Then
            For intloop As Integer = 0 To myVoiceReg.ValueCount - 1
                Dim myCommand As New CustomEntry
                myCommand.CommandName = myVoiceReg.GetValueNames(intloop)
                myCommand.Command = myVoiceReg.GetValue(myCommand.CommandName)
                customList.Add(myCommand)
                lstExternalCommands.Items.Add(myCommand.CommandName & ": " & myCommand.Command)
            Next
        End If
        'Sounds
        txtSoundPath.Text = "Button Sound Path: " & GetSetting("LCARS X32", "Application", "ButtonSound", Application.StartupPath & "\207.wav")
        'lblRedAlert.Text = "Red Alert Sound Path: " & GetSetting("LCARS X32", "Application", "RedAlertSound", Application.StartupPath & "\red_alert.wav")

        'Updates
        lblVersion.Text = "Program Version: " & New ProgramVersions(Application.StartupPath & "\versions.txt").getGlobalVersion()
        cpxAutoUpdates.Lit = GetSetting("LCARS X32", "Application", "Updates", "FALSE")
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
            txtCustom.Text = GetSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL")
            txtCustom.Visible = True
        End If
        AddHandler txtCustom.TextChanged, AddressOf txtCustom_TextChanged


        'Hide Explorer
        cpxHideExplorer.Lit = GetSetting("LCARS X32", "Application", "HideExplorer", "FALSE")
        If cpxHideExplorer.Lit Then
            cpxHideExplorer.SideText = "ON"
        Else
            cpxHideExplorer.SideText = "OFF"
        End If

        'Add tabs to listbox
        Dim tabs() As Integer = {30, 100, 30}
        Dim pinned As GCHandle = GCHandle.Alloc(tabs, GCHandleType.Pinned)
        SendMessage(lstAlerts.Handle, &H192, New IntPtr(tabs.Length), pinned.AddrOfPinnedObject)
        pinned.Free()
        lstAlerts.Refresh()
        lblAlertName.Text = ""
        lblID.Text = ""
        loadAlerts()

        'Debug switch
        cbDebug.Lit = GetSetting("LCARS x32", "Application", "DebugSwitch", "FALSE")
        If cbDebug.Lit Then
            cbDebug.SideText = "ON"
        End If
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
            MsgBox("Error loading color profile.  Please check the file '" & lstColors.SelectedItem & ".lxcp' in the program folder.", MsgBoxStyle.Critical, "ERROR")
        End Try

        FileClose(1)

    End Sub

    Private Sub UpdateColors(ByVal container As Control)

        For Each myControl As Control In container.Controls
            If myControl.GetType.ToString.Substring(0, 5).ToLower = "lcars" Then
                Try
                    CType(myControl, Object).ColorsAvailable.setColors(myColors)
                    CType(myControl, Object).DrawAllButtons()
                Catch
                End Try


            Else
                If myControl.Controls.Count > 0 Then
                    UpdateColors(myControl)
                End If
            End If
        Next
    End Sub

    Private Sub UpdateMainscreenColors(ByVal Colors() As String)
        setMainscreenData(2, Nothing)
    End Sub

    Private Sub sbUseScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUseScheme.Click
        If myColors.GetUpperBound(0) > -1 Then
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(myColors, ","))
            UpdateMainscreenColors(myColors)
        End If
    End Sub

 

    Private Sub picMain1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain1.Click
        picSelect.Location = New Point(picMain1.Left - 19, picMain1.Top - 15)
        SaveSetting("LCARS X32", "Load", "GUI Form", 1)
    End Sub

    Private Sub picMain2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain2.Click
        picSelect.Location = New Point(picMain2.Left - 19, picMain2.Top - 15)
        SaveSetting("LCARS X32", "Load", "GUI Form", 2)
    End Sub

    Private Sub picMain3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain3.Click
        picSelect.Location = New Point(picMain3.Left - 19, picMain3.Top - 15)
        SaveSetting("LCARS X32", "Load", "GUI Form", 3)
    End Sub


    Private Sub cbBeeping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBeeping.Click

        cbBeeping.Lit = Not cbBeeping.Lit

        If cbBeeping.Lit Then
            cbBeeping.SideText = "ON"
        Else
            cbBeeping.SideText = "OFF"
        End If

        SaveSetting("LCARS x32", "Application", "ButtonBeep", cbBeeping.Lit)


        SetMainscreenBeeping(cbBeeping.Lit)
    End Sub

    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
    End Sub

    Private Sub hpbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim wallpaper As String

        lstSizeMode.SelectedIndex = GetSetting("LCARS x32", "Application", "WallpaperSizeMode", 0)
        wallpaper = GetSetting("LCARS x32", "Application", "Wallpaper", "FederationLogo")
        If wallpaper = "FederationLogo" Then
            picWallpaper.Image = My.Resources.federation_logo
        Else
            Try
                picWallpaper.Image = Image.FromFile(wallpaper)
            Catch ex As Exception
                LCARS.UI.MsgBox("Unable to find user-defined wallpaper. Reverting to default.", MsgBoxStyle.OkOnly, "Error:")
                picWallpaper.Image = My.Resources.federation_logo
            End Try
        End If

        SetWallpaper(picWallpaper.Image)

    End Sub

    Private Sub SetWallpaper(ByVal bg As Image)
        Dim myImageData As Byte()

       
        Using ms As New System.IO.MemoryStream()
            bg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            myImageData = ms.ToArray()
        End Using

        Dim myData As New COPYDATASTRUCT
        myData.dwData = 1
        myData.cdData = myImageData.Length

        Dim myPtr As IntPtr = Marshal.AllocCoTaskMem(myImageData.Length)
        Marshal.Copy(myImageData, 0, myPtr, myImageData.Length)

        myData.lpData = myPtr

        Dim MyCopyData As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        Marshal.StructureToPtr(myData, MyCopyData, False)

        Dim res As Integer = SendMessage(x32Handle, WM_COPYDATA, Me.Handle, MyCopyData)
    End Sub

    Private Sub sbDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDefault.Click
        picWallpaper.Image = My.Resources.federation_logo
        SetWallpaper(picWallpaper.Image)
        SaveSetting("LCARS x32", "Application", "Wallpaper", "FederationLogo")
    End Sub

    Private Sub sbChangeWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbChangeWallpaper.Click
        Dim myFile As New OpenFileDialog
        Dim result As DialogResult

        myFile.Filter = "Image Files|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png;*.tif;*.tiff;*.ico"
        result = myFile.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            picWallpaper.Image = Image.FromFile(myFile.FileName)
            SetWallpaper(picWallpaper.Image)
            SaveSetting("LCARS x32", "Application", "Wallpaper", myFile.FileName)
        End If
    End Sub

  

    Private Sub lstSizeMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSizeMode.SelectedIndexChanged
        Select Case lstSizeMode.SelectedIndex
            Case 0
                SetWallpaperSizeMode(ImageLayout.Zoom)
            Case 1
                SetWallpaperSizeMode(ImageLayout.Stretch)
            Case 2
                SetWallpaperSizeMode(ImageLayout.Center)
            Case 3
                SetWallpaperSizeMode(ImageLayout.Tile)
            Case Else
                Exit Sub
        End Select

        SaveSetting("LCARS x32", "Application", "WallpaperSizeMode", lstSizeMode.SelectedIndex)
    End Sub

    Private Sub SetWallpaperSizeMode(ByVal sizemode As ImageLayout)
        setMainscreenData(4, Int(sizemode))

    End Sub

    Private Sub hpbLCARS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpbLCARS.Click
        fbShellSelect.Top = hpbLCARS.Top
        hpbLCARS.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpbExplorer.Color = LCARS.LCARScolorStyles.SystemFunction
        Try
            Process.Start(Application.StartupPath & "\SetShell.exe", "/q /set:lcars")
        Catch ex As Exception
            LCARS.UI.MsgBox("Could not launch SetShell.exe.  Please make sure it is in the same directory as LCARSsettings.exe." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.OkCancel, "ERROR")
        End Try
    End Sub

    Private Sub hpbExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpbExplorer.Click
        fbShellSelect.Top = hpbExplorer.Top
        hpbExplorer.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpbLCARS.Color = LCARS.LCARScolorStyles.SystemFunction
        Try
            Process.Start(Application.StartupPath & "\SetShell.exe", "/q /set:explorer")
        Catch ex As Exception
            LCARS.UI.MsgBox("Could not launch SetShell.exe.  Please make sure it is in the same directory as LCARSsettings.exe." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.OkCancel, "ERROR")
        End Try

    End Sub

    Private Sub SetMainscreenBeeping(ByVal enabled As Boolean)
        setMainscreenData(3, enabled)
    End Sub

    Private Sub setMainscreenData(ByVal code As Integer, ByVal data As Object)
        Dim myData As New COPYDATASTRUCT
        myData.dwData = code

        If Not data Is Nothing Then
            myData.cdData = Marshal.SizeOf(data.GetType)
            Dim myPtr As IntPtr = Marshal.AllocCoTaskMem(myData.cdData)
            Marshal.StructureToPtr(data, myPtr, False)
            myData.lpData = myPtr
        End If

        Dim MyCopyData As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        Marshal.StructureToPtr(myData, MyCopyData, False)

        Dim res As Integer = SendMessage(x32Handle, WM_COPYDATA, Me.Handle, MyCopyData)
    End Sub

   

    Private Sub cbVoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVoice.Click
        cbVoice.Lit = Not cbVoice.Lit

        SaveSetting("LCARS x32", "Application", "SpeechOn", cbVoice.Lit)

        If cbVoice.Lit Then
            cbVoice.SideText = "ON"
            setMainscreenData(8, 1)
        Else
            cbVoice.SideText = "OFF"
            setMainscreenData(8, 0)
        End If
    End Sub

    Private Sub picMain4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain4.Click
        picSelect.Location = New Point(picMain4.Left - 19, picMain4.Top - 15)
        SaveSetting("LCARS X32", "Load", "GUI Form", 4)

    End Sub

    Private Sub cbAutoHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutoHide.Click
        cbAutoHide.Lit = Not cbAutoHide.Lit

        If cbAutoHide.Lit Then
            cbAutoHide.SideText = "ON"
            setMainscreenData(9, 1)

        Else
            cbAutoHide.SideText = "OFF"
            setMainscreenData(9, 0)
        End If

        SaveSetting("LCARS X32", "Load", "AutoHide", Convert.ToInt32(cbAutoHide.Lit))


    End Sub

    Private Sub ltcSettings_SelectedTabChanged(ByVal Tab As LCARS.Controls.x32TabPage, ByVal TabIndex As System.Int32) Handles ltcSettings.SelectedTabChanged
        If ltcSettings.SelectedTab.Text = "APPEARENCE" Then
            myFiles = System.IO.Directory.GetFiles(Application.StartupPath & "\colors", "*.lxcp")

            lstColors.Items.Clear()

            For Each myFile As String In myFiles
                lstColors.Items.Add(System.IO.Path.GetFileNameWithoutExtension(myFile))
            Next
            myLanguageFiles = System.IO.Directory.GetFiles(Application.StartupPath & "\lang", "*.lng")
            lstLanguages.Items.Clear()
            For Each myFile As String In myLanguageFiles
                lstLanguages.Items.Add(System.IO.Path.GetFileNameWithoutExtension(myFile))
            Next
        ElseIf ltcSettings.SelectedTab.Text = "ABOUT" Then
            Dim myreader As New System.IO.StreamReader(Application.StartupPath & "\About.txt")
            lblAbout.Text = myreader.ReadToEnd()
            myreader.Close()
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
        'Dim myfile As System.IO.StreamReader ' = system.IO.File.OpenText(application.StartupPath & lstlanguages.GetItemText(
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
            MsgBox("Error loading language file.  Please check the file '" & lstLanguages.SelectedItem & ".lng' in the lang folder.", MsgBoxStyle.Critical, "ERROR")
        End Try

        FileClose(1)

    End Sub

    Private Sub sbUseLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUseLanguage.Click
        If lstLanguages.SelectedIndex > -1 Then
            SaveSetting("LCARS X32", "Application", "LangFile", lstLanguages.SelectedItem & ".lng")
            setMainscreenData(10, Nothing)
        End If
    End Sub

    Private Sub fbChangeSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbChangeSound.Click
        Dim myFileSelect As New frmFileSelect(Application.StartupPath, ".wav,", "Select a sound file")
        myFileSelect.ShowDialog()
        If myFileSelect.Result = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(myFileSelect.lblCurrentSelected.Text) Then
                SaveSetting("LCARS X32", "Application", "ButtonSound", myFileSelect.lblCurrentSelected.Text)
                txtSoundPath.Text = "Button sound path: " & myFileSelect.lblCurrentSelected.Text
            End If
        End If
    End Sub

    Private Sub fbSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbSaveChanges.Click
        SaveSetting("LCARS X32", "Application", "SpeechCode", txtLanguageCode.Text)
        'Remove all old values
        Try
            DeleteSetting("LCARS x32", "CustomVoiceCommands")
        Catch ex As Exception
            'Nothing of importance, there just weren't any custom commands
        End Try
        Try
            DeleteSetting("LCARS x32", "VoiceCommandAlias")
        Catch ex As Exception
            'Nothing of importance, there just weren't any aliases
        End Try
        'Write new values
        For Each mycommand As AliasEntry In aliasList
            If mycommand.CommandAlias <> "" Then
                SaveSetting("LCARS X32", "VoiceCommandAlias", mycommand.Command, mycommand.CommandAlias)
            End If
        Next
        For Each mycommand As CustomEntry In customList
            SaveSetting("LCARS X32", "CustomVoiceCommands", mycommand.CommandName, mycommand.Command)
        Next
        If cbVoice.Lit Then
            setMainscreenData(8, 1)
        Else
            setMainscreenData(8, 0)
        End If
    End Sub

    Private Sub sbInternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbInternal.Click
        pnlInternal.Visible = True
        pnlInternal.BringToFront()
        lstInternalCommands.Visible = True
        lstInternalCommands.BringToFront()
        pnlExternal.Visible = False
        lstExternalCommands.Visible = False
    End Sub

    Private Sub sbExternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExternal.Click
        pnlExternal.Visible = True
        pnlExternal.BringToFront()
        lstExternalCommands.Visible = True
        lstExternalCommands.BringToFront()
        pnlInternal.Visible = False
        lstInternalCommands.Visible = False
    End Sub

    Private Sub lstInternalCommands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInternalCommands.SelectedIndexChanged
        lblIntCommandName.Text = "Command Name: " & aliasList(lstInternalCommands.SelectedIndex).Command
        txtAlias.Text = aliasList(lstInternalCommands.SelectedIndex).CommandAlias
        Select Case aliasList(lstInternalCommands.SelectedIndex).Command
            Case "computer"
                lblDescription.Text = "Description: Command initializer. Must be spoken to use any other command."
            Case "menu"
                lblDescription.Text = "Description: Shows the Start Menu."
            Case "my computer"
                lblDescription.Text = "Description: Opens LCARS file browser."
            Case "settings"
                lblDescription.Text = "Description: Opens settings."
            Case "engineering"
                lblDescription.Text = "Description: Opens system information program."
            Case "mode select"
                lblDescription.Text = "Description: Shows screen chooser dialog."
            Case "my documents"
                lblDescription.Text = "Description: Opens LCARS file browser to show the ""My Documents"" folder."
            Case "my pictures"
                lblDescription.Text = "Description: Opens LCARS file browser to show the ""My Pictures"" folder."
            Case "my music"
                lblDescription.Text = "Description: Opens LCARS file browser to show the ""My Music"" folder."
            Case "my videos"
                lblDescription.Text = "Description: Opens LCARS file browser to show the ""My Videos"" folder."
            Case "deactivate"
                lblDescription.Text = "Description: Closes LCARS."
            Case "self destruct"
                lblDescription.Text = "Description: Opens self destruct program."
            Case "log off"
                lblDescription.Text = "Description: Logs off computer. Requires confirmation"
            Case "red alert"
                lblDescription.Text = "Description: Initiates a red alert."
            Case "cancel alert"
                lblDescription.Text = "Description: Cancels a red or yellow alert."
            Case "shut down"
                lblDescription.Text = "Description: Shuts down computer. Requires confirmation."
            Case "end program"
                lblDescription.Text = "Description: Closes current program."
            Case "cancel"
                lblDescription.Text = "Description: Ends continuous commands."
            Case "stardate"
                lblDescription.Text = "Description: Gives the current stardate."
            Case "run program"
                lblDescription.Text = "Description: Brings up ""run program"" dialog."
            Case "date"
                lblDescription.Text = "Description: Gives the current date."
            Case "time"
                lblDescription.Text = "Description: Gives the current time."
            Case "keyboard"
                lblDescription.Text = "Description: Shows the On Screen Keyboard."
            Case "task manager"
                lblDescription.Text = "Description: Opens incomplete LCARS task manager."
            Case "continuous commands"
                lblDescription.Text = "Description: Removes need to say ""computer"" before every command."
            Case "yellow alert"
                lblDescription.Text = "Description: Initiates a yellow alert."
            Case "confirmed"
                lblDescription.Text = "Description: Used to confirm a voice command."
            Case "help"
                lblDescription.Text = "Description: Opens ""Help"" program."
            Case "authorization"
                lblDescription.Text = "Description: Confirms commands that have been set to require command authorization."
            Case "show console"
                lblDescription.Text = "Description: Shows the speech console."
            Case "hide console"
                lblDescription.Text = "Description: Hides the speech console."
            Case "web browser"
                lblDescription.Text = "Description: Starts the LCARS web browser."
        End Select
    End Sub

    Private Sub txtAlias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.TextChanged
        Dim myposition As Integer = lstInternalCommands.SelectedIndex
        Dim newAlias As New AliasEntry
        newAlias.CommandAlias = txtAlias.Text
        newAlias.Command = aliasList(myposition).Command
        aliasList(myposition) = newAlias
        lstInternalCommands.Items.Clear()
        For Each myAlias As AliasEntry In aliasList
            lstInternalCommands.Items.Add(myAlias.Command & ": " & myAlias.CommandAlias)
        Next
        lstInternalCommands.SelectedIndex = myposition
    End Sub

    Private Sub sbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbAdd.Click
        lblError.Text = ""
        pnlAdd.Visible = True
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        pnlAdd.Visible = False
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        Dim myCheck As Boolean = True
        For Each myelement As CustomEntry In customList
            If myelement.CommandName = txtCommandName.Text Then
                myCheck = False
                lblError.Text = "Command already in use. Choose another name."
            End If
        Next
        If myCheck Then
            lblError.Text = ""
            Dim myCommand As New CustomEntry
            myCommand.CommandName = txtCommandName.Text.ToLower()
            myCommand.Command = txtCommandPath.Text
            customList.Add(myCommand)
            lstExternalCommands.Items.Add(myCommand.CommandName.ToLower() & ": " & myCommand.Command)
            pnlAdd.Visible = False
        End If
    End Sub

    Private Sub sbRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRemove.Click
        If lstExternalCommands.SelectedIndex <> -1 Then
            customList.RemoveAt(lstExternalCommands.SelectedIndex)
            lstExternalCommands.Items.RemoveAt(lstExternalCommands.SelectedIndex)
        End If
    End Sub

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

    Private Sub cpxHideExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpxHideExplorer.Click
        cpxHideExplorer.Lit = Not cpxHideExplorer.Lit
        If cpxHideExplorer.Lit Then
            cpxHideExplorer.SideText = "ON"
            SaveSetting("LCARS X32", "Application", "HideExplorer", "TRUE")
        Else
            cpxHideExplorer.SideText = "OFF"
            SaveSetting("LCARS X32", "Application", "HideExplorer", "FALSE")
        End If
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
            Dim alertstring As String = GetSetting("LCARS x32", "Alerts", myAlert.id, "")
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
        Try
            DeleteSetting("LCARS x32", "Alerts")
        Catch ex As Exception
        End Try
        For i As Integer = 0 To alertList.Count - 1
            Dim myAlert As AlertEntry = alertList(i)
            SaveSetting("LCARS x32", "Alerts", alertList(i).id, myAlert.Name & "|" & myAlert.Color & "|" & myAlert.Sound)
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
        If GetSetting("LCARS x32", "Application", "DebugSwitch", "TRUE") Then
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
        Dim myFileSelect As New frmFileSelect(Application.StartupPath, ".wav,", "Select a sound file")
        myFileSelect.ShowDialog()
        If myFileSelect.Result = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(myFileSelect.ReturnPath) Then
                Dim temp As AlertEntry = alertList(lstAlerts.SelectedIndex)
                temp.Sound = myFileSelect.ReturnPath
                alertList(lstAlerts.SelectedIndex) = temp
                SaveAlerts()
            End If
        End If

    End Sub
End Class