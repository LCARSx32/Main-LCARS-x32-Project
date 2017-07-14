Option Strict On

Imports System.Runtime.InteropServices

Public Module CommonScreen
    Public curBusiness As New List(Of modBusiness)

    Public WithEvents mainTimer As New Timer With {.Interval = 100}

    Public Sub initCommonComponents(ByVal b As modBusiness)
        initClock(b)
        initPowerStatus(b)
        initWindows(b)
    End Sub

    Private Sub mainTimer_tick(ByVal sender As Object, ByVal e As EventArgs) Handles mainTimer.Tick
        updateClock()
        updatePowerStatus()
        updateWindows()
        UpdateTray()
    End Sub

#Region " Clock "
    Private clockText As String = ""

    Private Sub initClock(ByVal b As modBusiness)
        b.myClock.Text = clockText
    End Sub

    Private Sub updateClock()
        Dim newText As String

        'Get the time and date format
        If CBool(GetSetting("LCARS x32", "Application", "Stardate", "TRUE")) Then
            newText = LCARS.Stardate.getStardate(Now).ToString()
        Else
            Dim timeFormat As String
            Dim DateFormat As String
            Try
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Control Panel\International")
                timeFormat = CStr(myReg.GetValue("sTimeFormat", "h:mm:sstt"))
                DateFormat = CStr(myReg.GetValue("sShortDate", "M/d/yyyy"))
            Catch ex As Exception
                timeFormat = "h:mm:sstt"
                DateFormat = "M/d/yyyy"
            End Try
            newText = Format(Now, timeFormat) & " " & Format(Now.Date, DateFormat)
        End If
        If clockText <> newText Then
            clockText = newText
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    myBusiness.myClock.Text = clockText
                End If
            Next
        End If
    End Sub
#End Region

#Region " Power Status "
    Private lineStatus As PowerLineStatus = PowerLineStatus.Unknown
    Private battPercent As Short = -1
    Private barNumber As Short = -1

    Private Sub initPowerStatus(ByVal b As modBusiness)
        b.myBattPercent.Text = battPercent & "%"
        If lineStatus = PowerLineStatus.Offline Then
            b.myPowerSource.Text = "AUXILIARY"
        Else
            b.myPowerSource.Text = "PRIMARY"
        End If
        For i As Integer = 0 To b.bars.Length - 1
            b.bars(i).Lit = i < barNumber
        Next
    End Sub

    Private Sub updatePowerStatus()
        ' SystemInformation.PowerStatus is effectively a static object. However,
        ' every time we read a property, it updates its internal values, so we
        ' should do that as little as possible
        Dim newBattPercent As Short = CShort(SystemInformation.PowerStatus.BatteryLifePercent * 100)
        Dim newLineStatus As PowerLineStatus = SystemInformation.PowerStatus.PowerLineStatus
        Dim newBarNumber As Short = CShort(Math.Ceiling(newBattPercent / 10.0F))

        If battPercent <> newBattPercent Then
            battPercent = newBattPercent
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    myBusiness.myBattPercent.Text = battPercent & "%"
                End If
            Next
        End If

        If lineStatus <> newLineStatus Then
            lineStatus = newLineStatus
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    If lineStatus = PowerLineStatus.Offline Then
                        myBusiness.myPowerSource.Text = "AUXILIARY"
                    Else
                        myBusiness.myPowerSource.Text = "PRIMARY"
                    End If
                End If
            Next
        End If

        If newBarNumber <> barNumber Then
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    For i As Integer = 0 To myBusiness.bars.Length - 1
                        myBusiness.bars(i).Lit = i < newBarNumber
                    Next
                End If
            Next
            barNumber = newBarNumber
        End If
    End Sub
#End Region

#Region " Window tracking "
    Private windowList As New Dictionary(Of Integer, ExternalApp)
    Private newWindowList As New Dictionary(Of Integer, ExternalApp)
    Private topmostWindow As Integer = 0

    <Flags()> _
    Public Enum WindowUpdateFlags As Integer
        None = 0
        Text = 1
        State = 2
        Topmost = 4
    End Enum

    Private Sub initWindows(ByVal b As modBusiness)
        Dim bScreen As Integer = MonitorFromWindow(b.myForm.Handle.ToInt32(), MONITOR_DEFAULTTONEAREST)
        For Each app As ExternalApp In windowList.Values
            If app.hScreen = bScreen Then
                b.AddWindow(app)
            End If
        Next
    End Sub

    Private Sub updateWindows()
        'Get new window information
        newWindowList.Clear()
        EnumWindows(New EnumCallBack(AddressOf fEnumWindowsCallBack), 0)
        Dim newTopmost As Integer = GetForegroundWindow()

        'See which screens are available
        Dim screenDict As New Dictionary(Of Integer, modBusiness)
        For Each b As modBusiness In curBusiness
            If b.isInit Then
                screenDict.Add(MonitorFromWindow(b.myForm.Handle.ToInt32(), MONITOR_DEFAULTTONEAREST), b)
            End If
        Next

        'Get the list of windows to remove
        Dim removeList As New List(Of Integer)
        For Each myKey As Integer In windowList.Keys
            If Not newWindowList.ContainsKey(myKey) Then
                removeList.Add(myKey)
            End If
        Next
        For Each myKey As Integer In removeList
            Dim removedApp As ExternalApp = windowList(myKey)
            If screenDict.ContainsKey(removedApp.hScreen) Then
                screenDict(removedApp.hScreen).RemoveWindow(removedApp)
                'If not in the screen list, assume that it's already gone
            End If
            windowList.Remove(myKey)
        Next

        'Update or add remaining windows
        For Each mykey As Integer In newWindowList.Keys
            Dim newApp As ExternalApp = newWindowList(mykey)
            If windowList.ContainsKey(mykey) Then
                Dim oldApp As ExternalApp = windowList(mykey)
                If newApp.hScreen = oldApp.hScreen Then
                    'Update window properties
                    Dim flags As WindowUpdateFlags = WindowUpdateFlags.None
                    If newApp.Text <> oldApp.Text Then
                        oldApp.Text = newApp.Text
                        flags = WindowUpdateFlags.Text
                    End If
                    If newApp.Minimized <> oldApp.Minimized Then
                        oldApp.Minimized = newApp.Minimized
                        flags = flags Or WindowUpdateFlags.State
                    End If
                    If flags <> WindowUpdateFlags.None AndAlso _
                            screenDict.ContainsKey(oldApp.hScreen) Then
                        screenDict(oldApp.hScreen).UpdateWindow(oldApp, flags)
                    End If
                Else
                    'Remove from old screen, then add to new screen
                    If screenDict.ContainsKey(oldApp.hScreen) Then
                        screenDict(oldApp.hScreen).RemoveWindow(oldApp)
                    End If
                    windowList(mykey) = newApp
                    If screenDict.ContainsKey(newApp.hScreen) Then
                        screenDict(newApp.hScreen).AddWindow(newApp)
                    Else
                        'TODO: Add default handler
                    End If
                End If
            Else
                windowList.Add(mykey, newWindowList(mykey))
                If screenDict.ContainsKey(newApp.hScreen) Then
                    screenDict(newApp.hScreen).AddWindow(newApp)
                Else
                    'TODO: Add default handler
                End If
            End If
        Next
        If newTopmost <> topmostWindow Then
            If windowList.ContainsKey(topmostWindow) Then
                Dim oldTop As ExternalApp = windowList(topmostWindow)
                oldTop.topmost = False
                If screenDict.ContainsKey(oldTop.hScreen) Then
                    screenDict(oldTop.hScreen).UpdateWindow(oldTop, WindowUpdateFlags.Topmost)
                End If
            End If
            If windowList.ContainsKey(newTopmost) Then
                Dim newTop As ExternalApp = windowList(newTopmost)
                newTop.topmost = True
                If screenDict.ContainsKey(newTop.hScreen) Then
                    screenDict(newTop.hScreen).UpdateWindow(newTop, WindowUpdateFlags.Topmost)
                End If
            End If
            topmostWindow = newTopmost
        End If
    End Sub

    Private Function fEnumWindowsCallBack(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer
        Const continueEnumeration As Integer = 1 ' True
        Const stopEnumration As Integer = 0 ' False
        'Stop if main timer disabled
        If Not mainTimer.Enabled Then Return stopEnumration
        'Hidden windows should not be shown
        If Not IsWindowVisible(hwnd) Then Return continueEnumeration
        'Windows with a parent should not be shown
        If GetParent(hwnd) <> 0 Then Return continueEnumeration

        Dim bNoOwner As Boolean = (GetWindow(hwnd, GW_OWNER) = 0)
        Dim lExStyle As Integer = GetWindowLong_Safe(hwnd, GWL_EXSTYLE)
        Dim toolWindow As Boolean = (lExStyle And WS_EX_TOOLWINDOW) = 0
        Dim appWindow As Boolean = (lExStyle And WS_EX_APPWINDOW) = WS_EX_APPWINDOW
        Dim modernApp As Boolean = (lExStyle And WS_EX_NOREDIRECTIONBITMAP) = WS_EX_NOREDIRECTIONBITMAP

        If ((toolWindow And bNoOwner) Or (appWindow And Not bNoOwner)) Then
            If modernApp Then
                'Check to see if it's suspended
                Dim pid As Integer = 0
                GetWindowThreadProcessId(hwnd, pid) 'Return value ignored
                Dim proc As Process = Process.GetProcessById(pid)
                If proc IsNot Nothing Then
                    If proc.Threads(0).WaitReason = ThreadWaitReason.Suspended Then
                        Return continueEnumeration
                    End If
                    If proc.ProcessName = "ApplicationFrameHost" Then
                        Return continueEnumeration
                    End If
                Else
                    Return continueEnumeration
                End If
            End If

            'Check to see if it's on the current virtual desktop
            Try
                If Not (modernApp OrElse VirtualDesktops.IsWindowOnCurrentVirtualDesktop(New IntPtr(hwnd))) Then
                    Return continueEnumeration
                End If
            Catch ex As COMException
            End Try

            Dim myApp As New ExternalApp(hwnd)
            newWindowList.Add(hwnd, myApp)
        End If
        Return continueEnumeration
    End Function

#End Region
End Module
