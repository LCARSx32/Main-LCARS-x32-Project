Imports System.Runtime.InteropServices


Module modCommon

    Public LinkedWindows As New List(Of IntPtr)
    Public StartingWorkingArea As New List(Of Rectangle)
    Public TaskBarState As Integer
    Public shutDownOptions As New cWrapExitWindows
    Public myDesktop As frmStartup
    Public curBusiness As New List(Of modBusiness)
    Public SysListView As IntPtr
    Public SysListViewParent As IntPtr
    Public hTrayIcons As IntPtr
    Public hTrayParent As IntPtr
    Public myIconSaver As New frmIconSaver
    Public closing As Boolean = False
    Public shellMode As Boolean = False
    Public displayOffset As Point

#Region " API Calls "

#Region " External Application Window Handling "

    'Bring a window to the front
    <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SetForegroundWindow")> _
   Public Function SetForegroundWindow(ByVal hWnd As IntPtr) As Integer
    End Function
    <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="GetForegroundWindow")> _
       Public Function GetForegroundWindow() As Integer
    End Function 'Import for "End Program" function

    Public Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure RECT
        Dim Left_Renamed As Integer
        Dim Top_Renamed As Integer
        Dim Right_Renamed As Integer
        Dim Bottom_Renamed As Integer
    End Structure

    Public Structure WINDOWPLACEMENT
        Dim Length As Integer
        Dim flags As Integer
        Dim ShowCmd As Integer
        Dim ptMinPosition As POINTAPI
        Dim ptMaxPosition As POINTAPI
        Dim rcNormalPosition As RECT
    End Structure

    Public Enum WindowStates
        NORMAL = 1
        MINIMIZED = 2
        MAXIMIZED = 3
        NOACTIVATE = 4
    End Enum


    Public Declare Function SetWindowPlacement Lib "user32" (ByVal hwnd As Integer, ByRef lpwndpl As WINDOWPLACEMENT) As Integer

    Public Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As Integer, ByRef lpwndpl As WINDOWPLACEMENT) As Integer

    Public Declare Function GetWindowRect Lib "user32" (ByVal hwnd As IntPtr, ByRef rectangle As RECT) As Integer

    Public Structure MINMAXINFO
        Dim ptReserved As POINTAPI
        Dim ptMaxSize As POINTAPI
        Dim ptMaxPosition As POINTAPI
        Dim ptMinTrackSize As POINTAPI
        Dim ptMaxTrackSize As POINTAPI
    End Structure

    Public Structure MONITORINFO
        Dim cbSize As Int32
        Dim rcMonitor As RECT
        Dim rcWork As RECT
        Dim dwFlags As Int32
    End Structure

    Public Const MONITOR_DEFAULTTONEAREST As Int32 = &H2

    Public Declare Function MonitorFromWindow Lib "user32" (ByVal hwnd As Int32, ByVal dwFlags As Int32) As Int32

    Public Declare Auto Function GetMonitorInfo Lib "user32" (ByVal hMonitor As Int32, ByRef lpmi As MONITORINFO) As Integer
#End Region

#Region " Working Area "
    'Constants for setting the "working area" (the area programs load)
    Public Const SPI_SETWORKAREA = 47
    Public Const SPIF_SENDWININICHANGE = &H2
    Public Const SPIF_UPDATEINIFILE = &H1
    Public Const SPIF_change = SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE
    'Constants for hiding minimized windows in shell mode
    Public Const SPI_GETMINIMIZEDMETRICS = &H2B
    Public Const SPI_SETMINIMIZEDMETRICS = &H2C

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MinimizedMetrics
        Public cbSize As UInteger
        Public iWidth As Integer
        Public iHorzGap As Integer
        Public iVertGap As Integer
        Public iArrange As MinimizedMetricsArrangement
    End Structure

    <Flags()> _
    Public Enum MinimizedMetricsArrangement
        BottomLeft = 0
        BottomRight = 1
        TopLeft = 2
        TopRight = 3
        Left = 0
        Right = 0
        Up = 4
        Down = 4
        Hide = 8
    End Enum

    'used to set the working area
    <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SystemParametersInfoA")> _
    Public Function SystemParametersInfo(ByVal uAction As UInteger, ByVal uParam As UInteger, ByVal lpvParam As IntPtr, ByVal fuWinIni As UInteger) As Int32
    End Function
#End Region

#Region " Hide/Show Taskbar "
    Public Declare Function ShowWindow Lib "user32" _
    (ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Integer

    Public Declare Function FindWindow Lib "user32" _
        Alias "FindWindowA" (ByVal lpClassName As String, _
        ByVal lpWindowName As String) As IntPtr

    Public Const SW_HIDE As Integer = 0
    Public Const SW_SHOW As Integer = 5

#End Region

#Region " Send Data to Other Windows "
    <StructLayout(LayoutKind.Sequential)> _
  Public Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure
    Public Const WM_COPYDATA As Integer = &H4A
#End Region

#Region " Inter-Window Communications "

    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Public InterMsgID As Integer
    Public Const HWND_BROADCAST As Integer = &HFFFF
    Public Const WM_EXPLORER_CLOSE As Integer = &H5B4

#End Region

#Region " Get Window List "

    Delegate Function EnumCallBack(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer

    Declare Function EnumWindows Lib "user32" (ByVal lpEnumFunc As EnumCallBack, ByVal lParam As Integer) As Integer


    Declare Function GetParent Lib "user32" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindow Lib "user32" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
    Private Declare Function GetWindowLongPtr Lib "user32" Alias "GetWindowLongPtrA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer) As Integer
    Public Function GetWindowLong_Safe(ByVal hwnd As IntPtr, ByVal nIndex As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return GetWindowLong(hwnd, nIndex)
        Else
            Return GetWindowLongPtr(hwnd, nIndex)
        End If
    End Function
    Private Declare Auto Function SetWindowLongPtr Lib "User32.Dll" Alias "SetWindowLongPtrA" (ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As Integer
    Private Declare Auto Function SetWindowLong Lib "User32.Dll" Alias "SetWindowLongA" (ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As Integer
    Public Function SetWindowLong_Safe(ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return SetWindowLong(hwnd, nIndex, dwNewLong)
        Else
            Return SetWindowLongPtr(hwnd, nIndex, dwNewLong)
        End If
    End Function

    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Declare Function IsWindowVisible Lib "user32" (ByVal hwnd As IntPtr) As Boolean
    '
    ' Constants used with APIs
    '
    Public Const GW_OWNER As Short = 4
    Public Const GWL_EXSTYLE As Integer = (-20)
    Public Const GWL_STYLE As Integer = (-16)
    Public Const WS_EX_TOOLWINDOW As Short = &H80S
    Public Const WS_EX_APPWINDOW As Integer = &H40000
    Public Const WS_EX_TRANSPARENT As Integer = &H20
    Public Const WS_EX_NOREDIRECTIONBITMAP As Integer = &H200000
    Public Const TBSTYLE_TRANSPARENT As Integer = &H8000

    Dim myListBox As ListBox


#End Region

#Region " Log In Notification "
    'These functions are used to tell the computer that the shell is up and running.

    Public Enum EventAccessRights
        EVENT_ALL_ACCESS = &H1F0003
        EVENT_MODIFY_STATE = &H2
    End Enum

    <DllImport("kernel32.dll")> _
    Public Function OpenEvent(ByVal dwDesiredAcess As Integer, ByVal bInheritHandle As Boolean, ByVal lpName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll")> _
    Public Function SetEvent(ByVal hEevent As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Public Function CloseHandle(ByVal hObject As IntPtr) As Boolean
    End Function

#End Region

#Region " Close App "

    Private Const WM_CLOSE As Integer = &H10
    Private Const SC_CLOSE As Integer = &HF060
    Public Const WM_SYSCOMMAND As Integer = &H112

    Public Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

#End Region

#Region " Cover Desktop "
    Public Declare Function SetParent Lib "user32.dll" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
   Public Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal lclassName As String, ByVal windowTitle As IntPtr) As IntPtr
    End Function
#End Region

#Region " Get Window based on coordinates "

    Public Declare Auto Function WindowFromPoint Lib "user32" (ByVal point As POINTAPI) As IntPtr

#End Region

#Region " Get/Set Autohide and AlwaysOnTop Settings (Taskbar) "

    Public Structure APPBARDATA
        Public cbSize As Integer
        Public hwnd As Integer
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As Integer
    End Structure

    Private Const ABM_GETSTATE As Int32 = &H4
    Private Const ABM_SETSTATE As Int32 = &HA

    'Autohide
    Private Const ABS_AUTOHIDE As Int32 = &H1
    'Always on Top
    Private Const ABS_ALWAYSONTOP As Int32 = &H2

    Private Declare Function SHAppBarMessage Lib "shell32.dll" _
        (ByVal dwMessage As Integer, ByRef pData As APPBARDATA) As Integer

#End Region

#Region " Get My Videos folder "
    Public Function GetMyVideosPath() As String
        Dim result As String = GetSetting("LCARS x32", "Application", "Videos", "")
        If result = "" Then
            Try
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)
                result = myReg.GetValue("My Video")
                SaveSetting("LCARS x32", "Application", "Videos", result)
            Catch ex As Exception
            End Try
            If result = "" Then
                Dim res As DialogResult = MsgBox("Unable to find ""My Videos"". Would you like to manually set the path?", MsgBoxStyle.YesNo)
                If res = DialogResult.Yes Then
                    result = InputBox("Input the complete path to your ""My Videos"" directory:", "Input My Videos directory")
                    SaveSetting("LCARS x32", "Application", "Videos", result)
                End If
            End If
        End If

        Return result
    End Function
#End Region

#Region " Hide Windows components "

    'All code from PInvoke.net

    <Flags()> _
Public Enum SetWindowPosFlags As UInteger
        ''' <summary>If the calling thread and the thread that owns the window are attached to different input queues,
        ''' the system posts the request to the thread that owns the window. This prevents the calling thread from
        ''' blocking its execution while other threads process the request.</summary>
        ''' <remarks>SWP_ASYNCWINDOWPOS</remarks>
        SynchronousWindowPosition = &H4000
        ''' <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        ''' <remarks>SWP_DEFERERASE</remarks>
        DeferErase = &H2000
        ''' <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        ''' <remarks>SWP_DRAWFRAME</remarks>
        DrawFrame = &H20
        ''' <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
        ''' the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
        ''' is sent only when the window's size is being changed.</summary>
        ''' <remarks>SWP_FRAMECHANGED</remarks>
        FrameChanged = &H20
        ''' <summary>Hides the window.</summary>
        ''' <remarks>SWP_HIDEWINDOW</remarks>
        HideWindow = &H80
        ''' <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
        ''' top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
        ''' parameter).</summary>
        ''' <remarks>SWP_NOACTIVATE</remarks>
        DoNotActivate = &H10
        ''' <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
        ''' contents of the client area are saved and copied back into the client area after the window is sized or
        ''' repositioned.</summary>
        ''' <remarks>SWP_NOCOPYBITS</remarks>
        DoNotCopyBits = &H100
        ''' <summary>Retains the current position (ignores X and Y parameters).</summary>
        ''' <remarks>SWP_NOMOVE</remarks>
        IgnoreMove = &H2
        ''' <summary>Does not change the owner window's position in the Z order.</summary>
        ''' <remarks>SWP_NOOWNERZORDER</remarks>
        DoNotChangeOwnerZOrder = &H200
        ''' <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
        ''' the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
        ''' window uncovered as a result of the window being moved. When this flag is set, the application must
        ''' explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        ''' <remarks>SWP_NOREDRAW</remarks>
        DoNotRedraw = &H8
        ''' <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        ''' <remarks>SWP_NOREPOSITION</remarks>
        DoNotReposition = &H200
        ''' <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        ''' <remarks>SWP_NOSENDCHANGING</remarks>
        DoNotSendChangingEvent = &H400
        ''' <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        ''' <remarks>SWP_NOSIZE</remarks>
        IgnoreResize = &H1
        ''' <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        ''' <remarks>SWP_NOZORDER</remarks>
        IgnoreZOrder = &H4
        ''' <summary>Displays the window.</summary>
        ''' <remarks>SWP_SHOWWINDOW</remarks>
        ShowWindow = &H40
    End Enum
    Public Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As SetWindowPosFlags) As Boolean

#End Region

#Region " Monitor Power "
    Public Const SC_MONITORPOWER As Integer = &HF170
    Public Enum MonitorPowerStates As Integer
        PowerOn = -1
        Standby = 1
        PowerOff = 2
    End Enum

    Public Const MOUSEEVENTF_MOVE As Int32 = &H1
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Int32, ByVal dx As Int32, ByVal dy As Int32, ByVal dwData As Int32, ByVal dwExtraInfo As UIntPtr)
#End Region

#Region " Shell Window "
    ''' <summary>
    ''' Sets the shell window
    ''' </summary>
    ''' <param name="hwnd">Window handle of shell window</param>
    ''' <returns>True on success</returns>
    ''' <remarks>
    ''' - SetShellWindow will only succeed if there is not already a registered shell window
    ''' - On a successful call, the shell window will be moved to the bottom of the z-order and 
    ''' stay there. The window remains selectable.
    ''' - The shell window can only be reset by destroying the current window. Calling this function
    ''' with zero or Nothing will not help.
    ''' - Shell windows must not have WS_EX_TOPMOST set. If this bit is set, SetShellWindow will fail.
    ''' If you try to set this bit after a successful call to SetShellWindow, the bit will be ignored.
    ''' - If you try to move the window to the foreground with SetWindowPos and HWND_TOPMOST, the call
    ''' will succeed, but it will not change anything.
    ''' 
    ''' Above points are from the Wine developer's mailing list:
    ''' https://www.winehq.org/pipermail/wine-devel/2003-October/021368.html
    ''' </remarks>
    Public Declare Auto Function SetShellWindow Lib "User32" (ByVal hwnd As IntPtr) As Boolean

    ''' <summary>
    ''' Sets the shell and listview windows
    ''' </summary>
    ''' <param name="hwndShell">Handle of shell window</param>
    ''' <param name="hwndListView">Handle of listview window</param>
    ''' <returns>True on success</returns>
    ''' <remarks>
    ''' Not used; see http://www.spinics.net/lists/wine/msg11444.html for assumed workings.
    ''' </remarks>
    Public Declare Auto Function SetShellWindowEx Lib "User32" (ByVal hwndShell As IntPtr, ByVal hwndListView As IntPtr) As Boolean

    ''' <summary>
    ''' Gets the current shell window
    ''' </summary>
    ''' <returns>Window handle of current shell window</returns>
    ''' <remarks>
    ''' If there is no current registered shell window, then the function will return zero.
    ''' </remarks>
    Public Declare Auto Function GetShellWindow Lib "User32" () As IntPtr

#End Region

#Region " Shell DDE "
    Public Const WM_DDE_FIRST As Integer = &H3E0
    Public Const WM_DDE_LAST As Integer = WM_DDE_FIRST + 8

#End Region
#End Region

    Public Sub setBusiness(ByRef business As modBusiness, ByVal ScreenIndex As Integer)
        curBusiness(ScreenIndex) = business
    End Sub

    Public Sub SetWallpaper(ByVal wall As Image, ByVal ScreenIndex As Integer)
        If Not My.Application.IsSettingsMode Then
            myDesktop.curDesktop(ScreenIndex).BackgroundImage = wall
        End If
    End Sub

    Public Sub setWallpaperSizeMode(ByVal sizemode As ImageLayout, ByVal ScreenIndex As Integer)
        If Not My.Application.IsSettingsMode Then
            myDesktop.curDesktop(ScreenIndex).BackgroundImageLayout = sizemode
        End If
    End Sub

    Public Sub SetAutoHide(ByVal hide As IAutohide.AutoHideModes, ByVal ScreenIndex As Integer)
        If Not My.Application.IsSettingsMode Then
            curBusiness(ScreenIndex).SetAutoHide(hide)
        End If
    End Sub

    Public Sub SetDesktop(ByVal desktop As Form)
        myDesktop = desktop
    End Sub

    Public Sub RefreshColors()
        For Each myBusiness As modBusiness In curBusiness
            LCARS.UpdateColors(myBusiness.myForm)
        Next

        PostMessage(HWND_BROADCAST, InterMsgID, 0, 2)
    End Sub

    Public Sub SetBeeping(ByVal value As Boolean)
        For Each myBusiness As modBusiness In curBusiness
            LCARS.SetBeeping(myBusiness.myForm, value)
        Next

        PostMessage(HWND_BROADCAST, InterMsgID, 0, 3)
    End Sub

    Public Sub GetTaskbarSettings()
        'gets the AutoHide and AlwayOnTop settings of the taskbar, then sets the taskbar to "AlwaysOnTop"
        'If this wasn't done and the user has the taskbar set to "AutoHide" in Vista, LCARS x32 would 
        'constantly be fighting explorer for control of the WorkingArea.
        Dim TaskbarSettings As APPBARDATA

        TaskbarSettings.cbSize = Len(TaskbarSettings)
        TaskBarState = SHAppBarMessage(ABM_GETSTATE, TaskbarSettings)

        TaskbarSettings.lParam = ABS_ALWAYSONTOP
        SHAppBarMessage(ABM_SETSTATE, TaskbarSettings)
    End Sub

    Public Sub CloseWindow(ByVal hwnd As IntPtr)
        PostMessage(hwnd, WM_SYSCOMMAND, SC_CLOSE, 0)
        PostMessage(hwnd, WM_SYSCOMMAND, WM_CLOSE, 0)
    End Sub

    Public Sub ShowTaskBar(ByVal StartVisible As Boolean)
        Dim TaskbarHandle As IntPtr
        Dim StartButtonHandle As IntPtr

        TaskbarHandle = FindWindow("Shell_TrayWnd", "")
        StartButtonHandle = FindWindow("Button", "Start")

        If StartVisible Then
            ShowWindow(TaskbarHandle, SW_SHOW)
            ShowWindow(StartButtonHandle, SW_SHOW)
        Else
            ShowWindow(TaskbarHandle, SW_HIDE)
            ShowWindow(StartButtonHandle, SW_HIDE)
        End If
    End Sub

    Public Sub SetWindowState(ByVal hwnd As IntPtr, ByVal newState As WindowStates)
        Dim myPlacement As New WINDOWPLACEMENT()
        myPlacement.Length = Len(myPlacement)
        GetWindowPlacement(hwnd.ToInt32, myPlacement)

        If newState = WindowStates.NORMAL And myPlacement.flags = 2 Then
            newState = WindowStates.MAXIMIZED
        End If

        myPlacement.ShowCmd = newState
        SetWindowPlacement(hwnd.ToInt32, myPlacement)
    End Sub

    Public Sub SetTopWindow(ByVal hWnd As IntPtr)
        SetForegroundWindow(hWnd)
    End Sub

    Public Function getWindowState(ByVal hwnd As IntPtr) As WindowStates
        Dim myPlacement As New WINDOWPLACEMENT
        myPlacement.Length = Len(myPlacement)
        GetWindowPlacement(hwnd.ToInt32, myPlacement)
        Return myPlacement.ShowCmd
    End Function

    Public Sub resizeWorkingArea(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim myArea As New RECT
        myArea.Left_Renamed = x
        myArea.Top_Renamed = y
        myArea.Right_Renamed = x + width
        myArea.Bottom_Renamed = y + height

        Dim ptr As IntPtr = IntPtr.Zero

        ptr = Marshal.AllocHGlobal(Marshal.SizeOf(myArea))

        Marshal.StructureToPtr(myArea, ptr, False)

        If shellMode Then
            Dim i As Integer = SystemParametersInfo(SPI_SETWORKAREA, Marshal.SizeOf(myArea), ptr, SPIF_change)
        Else
            Dim i As Integer = SystemParametersInfo(SPI_SETWORKAREA, Marshal.SizeOf(myArea), ptr, SPIF_UPDATEINIFILE)
        End If
        Marshal.FreeHGlobal(ptr)
    End Sub

    Public Sub CloseLCARS()
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Unhook global event handlers and similar ''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        RemoveHandler Microsoft.Win32.SystemEvents.DisplaySettingsChanged, AddressOf frmStartup.System_DisplayChanged
        SetParent(hTrayIcons, myIconSaver.Handle)
        If shellMode And LCARS.x32.modSettings.DDEEnabled Then
            deinitDDE()
        End If

        '''''''''''''''''''''''''''''''
        '''' Close LCARS interface ''''
        '''''''''''''''''''''''''''''''
        PostMessage(HWND_BROADCAST, InterMsgID, myDesktop.Handle, 13)
        For Each myBusiness As modBusiness In curBusiness
            myBusiness.mainTimer.Enabled = False
            If Not myBusiness.myForm Is Nothing Then
                myBusiness.myForm.Dispose()
            End If
        Next

        ''''''''''''''''''''''''''''''''''''''''
        '''' Restore Windows Explorer State ''''
        ''''''''''''''''''''''''''''''''''''''''

        If Not shellMode Then
            'Restore taskbar state
            Dim TaskbarSettings As APPBARDATA
            TaskbarSettings.cbSize = Len(TaskbarSettings)
            SHAppBarMessage(ABM_GETSTATE, TaskbarSettings)
            TaskbarSettings.lParam = TaskBarState
            SHAppBarMessage(ABM_SETSTATE, TaskbarSettings) 'put the taskbar's "AutoHide" setting back to what it was
            ShowTaskBar(True)

            'Restore working areas
            For Each myArea As Rectangle In StartingWorkingArea
                If Not myArea = New Rectangle(0, 0, 0, 0) Then
                    With myArea
                        resizeWorkingArea(.X, .Y, .Width, .Height)
                    End With
                End If
            Next

            'Restore desktop icons
            SetParent(SysListView, SysListViewParent) 'hwndSHELLDLL_DefView)

            'Restore tray icon style
            Dim myStyle As Integer = GetWindowLong_Safe(hTrayIcons, GWL_STYLE)
            myStyle = myStyle Or TBSTYLE_TRANSPARENT
            SetWindowLong_Safe(hTrayIcons, GWL_STYLE, myStyle)
            'Restore tray icon location
            SetParent(hTrayIcons, hTrayParent)
        End If

        ''''''''''''''''''''''''
        '''' Final shutdown ''''
        ''''''''''''''''''''''''
        myDesktop.Close()
    End Sub

    Public Function getMainScreenTypes() As List(Of Type)
        Dim typeList As New List(Of Type)
        typeList.Add(GetType(frmMainscreen1))
        typeList.Add(GetType(frmMainscreen2))
        typeList.Add(GetType(frmMainscreen3))
        typeList.Add(GetType(frmMainscreen4))

        'Further code to find custom main screens
        Return typeList
    End Function

    Public Sub updateDesktopBounds(ByVal ScreenIndex As Integer, ByVal newBounds As Rectangle)
        myDesktop.curDesktop(ScreenIndex).Bounds = _
            New Rectangle(newBounds.Location - displayOffset, _
                          newBounds.Size)
    End Sub

    Public Sub setDoubleBuffered(ByVal c As Control)
        Dim prop As Reflection.PropertyInfo = _
        GetType(Control).GetProperty("DoubleBuffered", _
                                     Reflection.BindingFlags.NonPublic Or _
                                     Reflection.BindingFlags.Instance)
        prop.SetValue(c, True, Nothing)
    End Sub
End Module
