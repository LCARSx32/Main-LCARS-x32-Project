Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports LCARS.x32

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
    'Desktop panels
    Public curDesktop As New List(Of Panel)

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
            ElseIf m.LParam = 2 Then
                'They are telling this instance to load settings.
                curBusiness(0).mySettingsButton_Click(Nothing, Nothing)
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

                    'Deprecated message; can't handle multiple screens
                    m.Result = 0
                Case 2
                    'Reload x32's colors (presumably, after they have changed them in the registry)

                    'Yeah, yeah, we got the message
                    m.Result = 1

                    RefreshColors()
                Case 3
                    'Set whether buttons should beep or not.

                    'Got it!
                    m.Result = 1

                    'Set the button beeping of the current mainscreen
                    Dim myValue As Boolean = Marshal.PtrToStructure(myData.lpData, GetType(Boolean))
                    SetBeeping(myValue)
                Case 4
                    'Set the wallpaper sizemode of the desktop

                    'Deprecated message; can't handle multiple screens.
                    m.Result = 0
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
                    RefreshVoiceCommands(result)
                Case 9
                    'Turn on/off AutoHide

                    'Deprecated message; can't handle multiple screens
                    m.Result = 0
                Case 10
                    'set language of mainscreens

                    'Deprecated message; can't handle multiple screens
                    m.Result = 0
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
        CheckComponents()
        If Command().Contains("-u") Then
            Try
                My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\runInstallScript.exe")
                My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\Ionic.Zip.Reduced.dll")
            Catch ex As Exception
            End Try
        End If
        If modSettings.InstallPath = "" Then
            modSettings.InstallPath = Application.StartupPath
        End If
        modSettings.InitializeSettings()
        If Command().Contains("-s") Then
            shellMode = True
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

        MoveTrayIcons()
        HideMinimizedWindows()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = New Point(0, 0)
        Me.Visible = False

        Dim result As Boolean = SetShellReadyEvent("msgina: ShellReadyEvent")
        If result = False Then
            SetShellReadyEvent("ShellDesktopSwitchEvent")
        End If
        For Each myScreen As Screen In Screen.AllScreens
            StartingWorkingArea.Add(myScreen.WorkingArea)
        Next
        GetTaskbarSettings()

        ShowTaskBar(False)


        SetDesktop(Me)
        SaveSetting("LCARS x32", "Application", "MainWindowHandle", Me.Handle.ToString)

        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")

        PostMessage(HWND_BROADCAST, InterMsgID, myDesktop.Handle, 0)

        For i As Integer = 0 To Screen.AllScreens.Length - 1
            'Create desktop panel
            CreateDesktop(i)
            'Set forms
            loadForm(i)
        Next
        AddHandler Microsoft.Win32.SystemEvents.DisplaySettingsChanged, AddressOf System_DisplayChanged
        SaveDesktopIcons()

        For Each myBusiness As modBusiness In curBusiness
            myBusiness.myForm.BringToFront()
        Next

        If GetSetting("LCARS X32", "Application", "Updates", "FALSE") Then
            Try
                Process.Start(Application.StartupPath & "\LCARSUpdate.exe", "-s")
            Catch ex As Exception
                MsgBox("Unable to check for updates" & vbNewLine & vbNewLine & ex.ToString())
            End Try
        End If

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
        If shellMode Then
            hwndProgMan = IntPtr.Zero
            hwndSHELLDLL_DefView = IntPtr.Zero
        End If
        SysListView = FindWindowEx(hwndSHELLDLL_DefView, IntPtr.Zero, "SysListView32", IntPtr.Zero)
        SetParent(pnlBack.Handle, hwndProgMan)

        setBackBounds()

        For i As Integer = 0 To Screen.AllScreens.Length - 1
            updateDesktopBounds(i, Screen.AllScreens(i).WorkingArea)
        Next
        Dim currentStyle As Integer = GetWindowLong(pnlBack.Handle, -20)
        currentStyle = currentStyle Or WS_EX_NOACTIVATE Or WS_EX_TOOLWINDOW
        SetWindowLong(pnlBack.Handle, -20, currentStyle)
        pnlBack.BringToFront()
        For Each myBack As Panel In curDesktop
            myBack.BringToFront()
        Next

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
                If Not IO.Path.GetFileName(myFile).ToLower() = "desktop.ini" Then
                    progList.Add(myFile)
                End If
            Next
        End If
        If Not UserStartPath = "" Then
            For Each myFile As String In System.IO.Directory.GetFiles(UserStartPath)
                If Not IO.Path.GetFileName(myFile).ToLower() = "desktop.ini" Then
                    progList.Add(myFile)
                End If
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
                If GetSetting("LCARS x32", "Application", "DebugSwitch", "False") Then
                    MsgBox(myProgram & vbNewLine & vbNewLine & ex.ToString())
                End If
            End Try
        Next
    End Sub

    Private Sub CheckComponents()
        'Checks that critical files have not been deleted. Only files required for running and shutting down
        'LCARSmain.exe, or that might be run on startup are checked.
        If System.IO.File.Exists(Application.StartupPath & "\LCARS.dll") _
        And System.IO.File.Exists(Application.StartupPath & "\LCARSshutdown.exe") _
        And System.IO.File.Exists(Application.StartupPath & "\LCARSUpdate.exe") _
        Then
            'Do nothing. Nothing is needed.
        Else
            'Use standard message box because there's no telling if LCARS.dll was deleted.
            Microsoft.VisualBasic.MsgBox("Critical files have been deleted. LCARS x32 is either unable to start, or unable to shut down after being started. " _
                                         & "Reinstalling should fix this problem." & vbNewLine & vbNewLine & "Program will exit.", MsgBoxStyle.Critical, "Fatal error")
            End
        End If
    End Sub

    Private Sub HideMinimizedWindows()
        Dim myMetrics As MinimizedMetrics
        myMetrics.cbSize = Marshal.SizeOf(myMetrics)
        Dim myPtr As IntPtr = Marshal.AllocCoTaskMem(myMetrics.cbSize)
        Marshal.StructureToPtr(myMetrics, myPtr, True)
        'Get current information
        SystemParametersInfo(SPI_GETMINIMIZEDMETRICS, 0, myPtr, 0)
        myMetrics.iArrange = MinimizedMetricsArrangement.Hide
        myMetrics.cbSize = Marshal.SizeOf(myMetrics)
        Marshal.StructureToPtr(myMetrics, myPtr, True)
        'Set minimized windows to actually hide
        SystemParametersInfo(SPI_SETMINIMIZEDMETRICS, 0, myPtr, 0)
        Marshal.FreeCoTaskMem(myPtr)
    End Sub

    Public Sub System_DisplayChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        setBackBounds()
        If Screen.AllScreens.Length <> curBusiness.Count Then
            'Update the screens.
            Debug.Print("Number of displays changed!")
            If Screen.AllScreens.Length > curBusiness.Count Then
                'Assume new screen(s) are added at end
                'Add desktop, working area, empty modBusiness, and form
                For i As Integer = curBusiness.Count To Screen.AllScreens.Length - 1
                    CreateDesktop(i)
                    StartingWorkingArea.Add(Screen.AllScreens(i).Bounds)
                    loadForm(i)
                Next
            Else
                'Assume removed screen(s) are at end - Might not be accurate, 
                '    but will be correct in most common case
                'Remove desktop, working area, form, and modBusiness
                'Loop runs backwards to avoid indexing changes
                For i As Integer = curBusiness.Count - 1 To Screen.AllScreens.Length Step -1
                    curBusiness(i).mainTimer.Stop()
                    curBusiness(i).tmrAutohide.Stop()
                    curBusiness(i).myForm.Dispose()
                    curBusiness.RemoveAt(i)
                    Me.Controls.Remove(curDesktop(i))
                    curDesktop.RemoveAt(i)
                    StartingWorkingArea.RemoveAt(i)
                Next
            End If
        End If
        For Each b As modBusiness In curBusiness
            b.myForm.Bounds = Screen.AllScreens(b.ScreenIndex).Bounds
            b.resetWorkingArea()
        Next
    End Sub

    Private Sub CreateDesktop(ByVal i As Integer)
        Dim myDesktop As New Panel()
        myDesktop.BackColor = Color.Black
        pnlBack.Controls.Add(myDesktop)
        curDesktop.Add(myDesktop)
        'Set wallpaper
        Dim wallpaper As String
        Dim sizeMode As Integer

        sizeMode = modSettings.WallpaperSizeMode(i)
        Select Case sizeMode
            Case 0
                setWallpaperSizeMode(ImageLayout.Zoom, i)
            Case 1
                setWallpaperSizeMode(ImageLayout.Stretch, i)
            Case 2
                setWallpaperSizeMode(ImageLayout.Center, i)
            Case 3
                setWallpaperSizeMode(ImageLayout.Tile, i)
            Case Else
                Exit Sub
        End Select

        wallpaper = modSettings.Wallpaper(i)
        If wallpaper = "FederationLogo" Then
            SetWallpaper(My.Resources.federationLogo, i)
        Else
            If System.IO.File.Exists(wallpaper) Then
                SetWallpaper(Image.FromFile(wallpaper), i)
            Else
                SetWallpaper(My.Resources.federationLogo, i)
                LCARS.UI.MsgBox("Unable to find user-defined wallpaper. Reverting to default.", MsgBoxStyle.OkOnly, "Error:")
            End If
        End If
    End Sub

    Private Sub loadForm(ByVal i As Integer)
        Dim chosenForm As String
        chosenForm = modSettings.MainScreen(i)
        curBusiness.Add(Nothing)
        Select Case chosenForm.ToLower
            Case "1"
                myForm = New frmMainscreen1(i)
            Case "2"
                myForm = New frmMainscreen2(i)
            Case "3"
                myForm = New frmMainscreen3(i)
            Case "4"
                myForm = New frmMainscreen4(i)
            Case Else
                myForm = New frmFirstRun
        End Select
        myForm.Show()
        myForm.BringToFront()
    End Sub

    Private Sub setBackBounds()
        Dim leftLoc As Integer = Integer.MaxValue
        Dim topLoc As Integer = Integer.MaxValue
        Dim right As Integer = Integer.MinValue
        Dim bottom As Integer = Integer.MinValue

        For Each myScreen As Screen In Screen.AllScreens
            If myScreen.Bounds.Left < leftLoc Then
                leftLoc = myScreen.Bounds.Left
            End If
            If myScreen.Bounds.Top < topLoc Then
                topLoc = myScreen.Bounds.Top
            End If
            If myScreen.Bounds.Right > right Then
                right = myScreen.Bounds.Right
            End If
            If myScreen.Bounds.Bottom > bottom Then
                bottom = myScreen.Bounds.Bottom
            End If
        Next
        displayOffset = New Point(leftLoc, topLoc)
        Dim myBounds As Rectangle
        If shellMode Then
            myBounds = New Rectangle(leftLoc, topLoc, right - leftLoc, bottom - topLoc)
        Else
            myBounds = New Rectangle(0, 0, right - leftLoc, bottom - topLoc)
        End If
        pnlBack.Bounds = myBounds
    End Sub
End Class