Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Public Class frmStartup

    'Constants used to make this form act like the Windows desktop (stay in back, don't get activated)
    Const WS_EX_NOACTIVATE As Integer = &H8000000
    Const WS_VISIBLE As Integer = &H10000000

    'Used to register the "LCARS_X32_MSG" window message which allows x32 to talk to it's various windows
    'and applications.
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer

    'Holds the current Main Screen
    Dim myForm As New Form
    'The index of the current active screen (multi-monitor support)
    Dim screenindex As Integer = 0

    <System.Diagnostics.DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'This method intercepts incomming window messages and looks to see if any need to be read

        'Check if it's the "LCARS_X32_MSG"
        If m.Msg = InterMsgID Then

            'It is! So find out what was sent.

            'Send back a 1 so the program that sent the message knows we received it.
            m.Result = 1

            'LParam is used as a simple way of telling what the sender intended.  For example, x32 sends
            'a "LCARS_X32_MSG" to all registered windows with an LParam of 13 when it is closing, so they
            'can close too.
            If m.LParam = 1 Then
                'They are registering their program with x32 so they can receive resize and close notices.
                'Save their handle so we can send a message to them when 
                'the working area has changed or x32 is closing (if that handle isn't in the list already).
                Dim targetWnd As IntPtr = m.WParam
                LinkedWindows.Add(m.WParam)
                'Send them the window handle for x32 so they can communicate directly, otherwise they have
                'to broadcast the message to all windows.
                PostMessage(targetWnd, InterMsgID, Me.Handle, 2)
            End If

            'WM_COPYDATA is used when more than just a number needs to be sent to x32.
        ElseIf m.Msg = WM_COPYDATA Then

            'Copy the data from memory (RAM) into a COPYDATASTRUCT structure
            Dim myData As New COPYDATASTRUCT
            myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))

            'Find out what kind of data was sent:
            Select Case myData.dwData
                Case 1
                    'They want to set the wallpaper

                    'We received it!
                    m.Result = 1

                    'Set wallpaper
                    Dim myimage As Image
                    Dim myImageData(myData.cdData) As Byte

                    'Copy the image byte by byte 
                    For intloop As Integer = 0 To myData.cdData
                        myImageData(intloop) = Marshal.ReadByte(myData.lpData, intloop)
                    Next

                    'Use a MemoryStream to write the bytes to an image object
                    Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(myImageData, 0, myImageData.Length)
                    myimage = Image.FromStream(ms)

                    'Set the wallpaper to that image.  They (the other program) are responsible for saving the 
                    'path of the image in x32's settings (registry)
                    SetWallpaper(myimage)
                Case 2
                    'Reload x32's colors (presumably, after they have changed them in the registry)

                    'Yeah, yeah, we got the message
                    m.Result = 1

                    'Reload the colors of the current mainscreen
                    LCARS.UpdateColors(myForm)
                    For Each mywindow As IntPtr In LinkedWindows
                        SendMessage(mywindow, InterMsgID, 0, 2)
                    Next
                Case 3
                    'Set whether buttons should beep or not.

                    'Got it!
                    m.Result = 1

                    'Set the button beeping of the current mainscreen
                    Dim myValue As Boolean = Marshal.PtrToStructure(myData.lpData, GetType(Boolean))
                    LCARS.SetBeeping(myForm, myValue)
                    For Each mywindow As IntPtr In LinkedWindows
                        SendMessage(mywindow, InterMsgID, 0, 3)
                    Next
                Case 4
                    m.Result = 1
                    'Set the wallpaper sizemode of the desktop
                    Dim mySizeMode As ImageLayout = Marshal.PtrToStructure(myData.lpData, GetType(Integer))
                    setWallpaperSizeMode(mySizeMode)
                Case 5
                    'They want to close LCARS x32.

                    'We got the message
                    m.Result = 1

                    'Close LCARS (pretty self explainitory)
                    CloseLCARS()
                Case 6
                    'Start a Red Alert
                    'This is deprecated, but kept for backwards compatibility.
                    m.Result = 1

                    'Dim myAlert As New Threading.Thread(AddressOf redAlert)
                    'myAlert.Start()
                    GeneralAlert(0)
                Case 7
                    m.Result = 1

                    'Cancel current Alerts
                    cancelAlert = True
                Case 8
                    m.Result = 1

                    'Turn on/off Voice commands.
                    Dim result As Integer = Marshal.PtrToStructure(myData.lpData, GetType(Integer))
                    If result = 0 Then
                        'turn off voice commands
                        Try
                            Listener.Recognizer.State = SpeechLib.SpeechRecognizerState.SRSInactive
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            beginVoiceRecognition()
                        Catch ex As Exception
                        End Try
                    End If
                Case 9
                    m.Result = 1

                    'Turn on/off AutoHide
                    Dim result As Integer = Marshal.PtrToStructure(myData.lpData, GetType(Integer))
                    If result = 0 Then
                        SetAutoHide(0)
                    Else
                        SetAutoHide(1)
                    End If
                Case 10
                    m.Result = 1
                    'set language of mainscreens
                    curBusiness.loadLanguage()
                Case 11
                    m.Result = 1

                    'Set an alert
                    GeneralAlert(myData.cdData)
                Case 12
                    m.Result = 1
                    'Alerts updated
                    frmAlerts.loadAlerts()
            End Select
        End If

        'it wasn't a message we need to handle, so let VB take back over.
        MyBase.WndProc(m)

    End Sub

    Private Sub frmStartup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName("LCARSmain").Length > 1 Then
            End
        End If
        If Command().Contains("-u") Then
            Try
                My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\runInstallScript.exe")
                My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\Ionic.Zip.Reduced.dll")
            Catch ex As Exception
            End Try
        End If
        modSettings.InitializeSettings()
        If Command().Contains("-s") Then
            shellMode = True
            'Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.System) & "\systray.exe")
        End If
        If Not Command().Contains("-L") Then
            If System.IO.File.Exists(Application.StartupPath & "\LCARSLogin.exe") Then
                Process.Start(Application.StartupPath & "\LCARSLogin.exe")
                End
            End If
        End If


        If GetSetting("LCARS X32", "Application", "SpeechOn", "TRUE") Then
            beginVoiceRecognition()
        End If

        'If Screen.AllScreens.Length > 0 Then
        '    Dim myChooser As New screenChooserDialog
        '    myChooser.showdialog()
        '    screenindex = myChooser.ScreenIndex

        'Else
        '    For i As Integer = 0 To Screen.AllScreens.GetUpperBound(0)
        '        If Screen.AllScreens(i) Is Screen.PrimaryScreen Then
        '            screenindex = i 'use the primary screen
        '            Exit For
        '        End If
        '    Next
        'End If
        'If Not shellMode Then
        MoveTrayIcons()
        'End If

        'This has to be after the message is sent to allow for proper resizing
        If GetSetting("LCARS X32", "Application", "Updates", "FALSE") Then
            Process.Start(Application.StartupPath & "\LCARSUpdate.exe", "-s")
        End If

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If shellMode Then
            Me.Bounds = Screen.AllScreens(screenindex).Bounds
            'SetWindowPos(Me.Handle, 1, 0, 0, 100, 100, SetWindowPosFlags.IgnoreMove Or SetWindowPosFlags.IgnoreResize)
            Me.SendToBack()
        Else
            Me.Size = New Point(0, 0)
            Me.Visible = False
        End If

        Dim result As Boolean = SetShellReadyEvent("msgina: ShellReadyEvent")
        If result = False Then
            SetShellReadyEvent("ShellDesktopSwitchEvent")
        End If
        StartingWorkingArea = Screen.AllScreens(screenindex).WorkingArea

        GetTaskbarSettings()

        ShowTaskBar(False)


        SetDesktop(Me)
        SaveSetting("LCARS x32", "Application", "MainWindowHandle", Me.Handle.ToString)

        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")

        PostMessage(HWND_BROADCAST, InterMsgID, myDesktop.Handle, 0)

        Dim wallpaper As String
        Dim sizeMode As Integer

        sizeMode = GetSetting("LCARS x32", "Application", "WallpaperSizeMode", 2)
        Select Case sizeMode
            Case 0
                setWallpaperSizeMode(ImageLayout.Zoom)
            Case 1
                setWallpaperSizeMode(ImageLayout.Stretch)
            Case 2
                setWallpaperSizeMode(ImageLayout.Center)
            Case 3
                setWallpaperSizeMode(ImageLayout.Tile)
            Case Else
                Exit Sub
        End Select

        wallpaper = GetSetting("LCARS x32", "Application", "Wallpaper", "FederationLogo")
        If wallpaper = "FederationLogo" Then
            SetWallpaper(My.Resources.federationLogo)
        Else
            If System.IO.File.Exists(wallpaper) Then
                SetWallpaper(Image.FromFile(wallpaper))
            Else
                SetWallpaper(My.Resources.federationLogo)
                LCARS.UI.MsgBox("Unable to find user-defined wallpaper. Reverting to default.", MsgBoxStyle.OkOnly, "Error:")
            End If
        End If

        Dim chosenForm As String
        chosenForm = GetSetting("LCARS X32", "Load", "GUI Form", 1)

        Select Case chosenForm.ToLower
            Case "1"
                myForm = New frmMainscreen1(screenindex)
            Case "2"
                myForm = New frmMainscreen2(screenindex)
            Case "3"
                myForm = New frmMainscreen3(screenindex)
            Case "4"
                myForm = New frmMainscreen4(screenindex)
            Case Else
                myForm = New frmFirstRun
        End Select
        'If Not shellMode Then
        SaveDesktopIcons()
        'End If

        myForm.Show()
        myForm.BringToFront()
        'SetWindowPos(myForm.Handle, -1, 0, 0, 0, 0, SetWindowPosFlags.IgnoreMove Or SetWindowPosFlags.IgnoreResize)
        If shellMode Then
            Dim startupThread As New Threading.Thread(AddressOf StartupPrograms)
            startupThread.Start()
        End If
    End Sub

    Private Sub SaveDesktopIcons()
        Dim hwndProgMan As IntPtr = FindWindow("ProgMan", Nothing)
        Dim hwndSHELLDLL_DefView As IntPtr = FindWindowEx(hwndProgMan, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero)
        'Debug.Print("ProgMan handle: " & Hex(hwndSHELLDLL_DefView.ToInt32()))
        If hwndSHELLDLL_DefView = IntPtr.Zero And Not shellMode Then
            'MsgBox("Your desktop has been set to a rotating slideshow." & vbNewLine & "LCARS x32 will not display properly until you disable this.")
            Dim parent As IntPtr = GetParent(hwndProgMan)
            Dim count As Integer = 0
            Do
                hwndProgMan = FindWindowEx(parent, hwndProgMan, "WorkerW", IntPtr.Zero)
                'Debug.Print("WorkerW handle: " & Hex(hwndProgMan.ToInt32()))
                hwndSHELLDLL_DefView = FindWindowEx(hwndProgMan, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero)
                'Debug.Print("ShellDLL DefView handle: " & Hex(hwndSHELLDLL_DefView.ToInt32()))
                count += 1
            Loop While hwndSHELLDLL_DefView = IntPtr.Zero And count < 20
        End If
        If Not shellMode Then
            SysListView = FindWindowEx(hwndSHELLDLL_DefView, IntPtr.Zero, "SysListView32", IntPtr.Zero)
            SetParent(pnlBack.Handle, hwndProgMan)
            SetParent(pnlDesktop.Handle, hwndProgMan)
        End If

        Dim leftLoc As Integer = 0
        Dim topLoc As Integer = 0

        For Each myScreen As Screen In Screen.AllScreens
            If myScreen.Bounds.X < leftLoc Then
                leftLoc = myScreen.Bounds.X
            End If
            If myScreen.Bounds.Y < topLoc Then
                topLoc = myScreen.Bounds.Y
            End If
        Next

        Dim myBounds As Rectangle = Screen.AllScreens(screenindex).Bounds
        myBounds.X = myBounds.X - leftLoc
        myBounds.Y = myBounds.Y - topLoc
        If shellMode Then
            Dim currentStyle As Integer = GetWindowLong(Me.Handle, -20)
            currentStyle = currentStyle Or (&H80) Or (&H8000000)
            SetWindowLong(Me.Handle, -20, currentStyle)
            'SetWindowPos(Me.Handle, 1, 0, 0, 0, 0, SetWindowPosFlags.IgnoreMove Or SetWindowPosFlags.IgnoreResize Or SetWindowPosFlags.DoNotActivate)
            Me.Bounds = myBounds
        End If
        pnlBack.Bounds = myBounds
        pnlDesktop.Bounds = Screen.AllScreens(screenindex).WorkingArea
        pnlBack.BringToFront()
        pnlDesktop.BringToFront()


        myIconSaver.Bounds = Screen.AllScreens(screenindex).Bounds


        SetParent(SysListView, myIconSaver.Handle)
    End Sub

    Private Sub MoveTrayIcons()
        Dim hTray As IntPtr = FindWindow("Shell_TrayWnd", Nothing)
        Dim hTrayNotify As IntPtr = FindWindowEx(hTray, IntPtr.Zero, "TrayNotifyWnd", IntPtr.Zero)

        hTrayParent = FindWindowEx(hTrayNotify, IntPtr.Zero, "SysPager", IntPtr.Zero)
        hTrayIcons = FindWindowEx(hTrayParent, IntPtr.Zero, "ToolbarWindow32", IntPtr.Zero)

        Dim myStyle As Integer = GetWindowLong(hTrayIcons, GWL_STYLE)
        myStyle = myStyle And Not TBSTYLE_TRANSPARENT
        If (myStyle And TBSTYLE_TRANSPARENT) Then
            MsgBox("Transparent!")
        End If
        SetWindowLong(hTrayIcons, GWL_STYLE, myStyle)

        SetParent(hTrayIcons, myIconSaver.Handle)
    End Sub


    Private Function SetShellReadyEvent(ByVal eventName As String) As Boolean
        'Thanks to 'Raster' for his post on DreamInCode.net!
        'http://www.dreamincode.net/forums/showtopic98329.htm

        Dim hEvent As IntPtr

        ' open an event
        hEvent = OpenEvent(EventAccessRights.EVENT_MODIFY_STATE, False, eventName)

        ' return if event is null
        If (hEvent = IntPtr.Zero) Then
            Return False
        Else
            ' set the event using the handle
            SetEvent(hEvent)

            ' close the handle
            CloseHandle(hEvent)

            Return True
        End If
    End Function

    Private Sub StartupPrograms()
        Dim progList As New List(Of String)
        'Get everything stored in the registry
        Dim test() As RegistryKey = {Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", False), _
                             Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunOnce", False), _
                             Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunServices", False), _
                             Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunServicesOnce", False), _
                             Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", False), _
                             Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunOnce", False), _
                             Registry.LocalMachine.OpenSubKey("System\CurrentControlSet\Services", False)}
        For i As Integer = 0 To test.Length - 1
            Try
                If Not test(i) Is Nothing Then
                    Dim names() As String = test(i).GetValueNames()
                    For Each value As String In names
                        If value <> "" Then
                            progList.Add(test(i).GetValue(value))
                        End If
                    Next
                    test(i).Close()
                End If
            Catch ex As NullReferenceException
                Debug.Print("Failed")
            End Try
        Next

        'Get all start menu "Startup" folder programs
        Dim OSinfo As String = getOS()
        Dim GlobalStartPath As String = ""
        Dim UserStartPath As String = ""

        Select Case OSinfo
            Case "Win98"
                GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                UserStartPath = ""
            Case "WinNT3.51"
                GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                UserStartPath = ""
            Case "WinNT4.0"
                GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                UserStartPath = ""
            Case "Modern"
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)
                UserStartPath = myReg.GetValue("Startup")
                myReg = Microsoft.Win32.Registry.LocalMachine
                myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)
                GlobalStartPath = myReg.GetValue("Common Startup")
        End Select
        If Not GlobalStartPath = "" Then
            For Each myFile As String In System.IO.Directory.GetFiles(GlobalStartPath)
                progList.Add(myFile)
            Next
        End If
        If Not UserStartPath = "" Then
            For Each myFile As String In System.IO.Directory.GetFiles(UserStartPath)
                progList.Add(myFile)
            Next
        End If
        'If not enclosed in quotes, do so
        For Each myProgram As String In progList
            If Not myProgram.Substring(0, 1) = """" Then
                myProgram = """" & myProgram & """"
            End If
        Next

        'Start all programs retrieved
        For Each myProgram As String In progList
            Try
                'Process.Start(myProgram)
                Shell(myProgram)
            Catch ex As Exception
                MsgBox(myProgram & vbNewLine & vbNewLine & ex.ToString())
            End Try
        Next
    End Sub

End Class