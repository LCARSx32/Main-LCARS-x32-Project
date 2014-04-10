'Imports system.io
'Imports System.Runtime.InteropServices
'Imports System.Reflection
'Imports SpeechLib
'Imports System.Xml

Public Class frmMainscreen1
    Implements IAutohide

#Region " Old Code "


    '#Region " Structures "

    '    Private Structure LCARSsettings
    '        Dim SpeechOn As Boolean
    '        Dim ButtonBeep As Boolean
    '        Dim BrowserHomePage As String
    '        Dim PanelOpenInterval As Integer
    '        Dim PanelCloseInterval As Integer
    '        Dim ScreenIndex As Integer
    '        Dim HasMultipleScreens As Boolean
    '        Dim UseGestures As Boolean
    '    End Structure

    '    Public Structure MyComputerItem
    '        Dim Name As String
    '        Dim DriveType As System.IO.DriveType
    '        Dim IsReady As Boolean
    '        Dim VolumeLabel As String
    '    End Structure

    '    Public Structure scrollObj
    '        Dim Name As String
    '        Dim ScrollMethod As scMethod
    '    End Structure

    '#End Region

    '#Region " API Calls "

    '    'Constants for controling the montitor state
    '    Const HWND_BROADCAST As Integer = &HFFFF
    '    Const SC_MONITORPOWER As Integer = &HF170
    '    Const WM_SYSCOMMAND As Short = &H112S

    '    'Constants for controling apps inside LCARS x32
    '    Private Const SW_MINIMIZE As Integer = 6
    '    Private Const SW_MAXIMIZE As Integer = 3
    '    Private Const SW_RESTORE As Integer = 9


    '    'used for loading apps inside of LCARS x32
    '    Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Boolean
    '    Declare Function SetParent Lib "user32" (ByVal hWndChild As System.IntPtr, ByVal hWndNewParent As System.IntPtr) As System.IntPtr
    '    Declare Function GetParent Lib "user32" (ByVal hWnd As System.IntPtr) As System.IntPtr
    '    'used for turning on and off screen
    '    Declare Function SendMessage Lib "user32" (ByVal Handle As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    '    Public Const GWL_STYLE = -16&
    '    Public Const WS_DLGFRAME = &H400000

    '    <DllImport("User32.dll", EntryPoint:="GetWindowLong")> _
    '    Friend Shared Function GetWindowLong(ByVal hwnd As IntPtr, ByVal index As Integer) As Integer
    '    End Function

    '    <DllImport("User32.dll", EntryPoint:="SetWindowLong")> _
    '    Friend Shared Function SetWindowLong(ByVal hwnd As IntPtr, ByVal index As Integer, ByVal style As Integer) As Integer
    '    End Function




    '#End Region

    '#Region " Global Variables "
    '    Delegate Sub scMethod(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs)
    '    Dim intTimeLeft As Integer = -1 'for self destruct
    '    'dim startItems(-1) As System.IO.FileSystemInfo

    '    Dim mybatt As PowerStatus = SystemInformation.PowerStatus
    '    Dim MyCompItems(-1) As MyComputerItem
    '    Dim BrowsedFolders As New Collection
    '    Dim curFiles(-1) As System.IO.FileSystemInfo
    '    Dim EndAlert As Boolean = False
    '    Dim curVisible As Panel

    '    Dim ScrollStartX As Integer = -1
    '    Dim ScrollStartY As Integer = -1
    '    Dim allowClick As Boolean = True

    '    Dim scrollIndex As Integer = 0
    '    Dim maxScrollItems As Integer = 0
    '    Dim browserScroll As Integer = 0
    '    Dim mainBoxSize As Rectangle

    '    Dim buttonScale As Double = 1
    '    Dim scaleWidth As Double
    '    Dim scaleHeight As Double

    'Dim cancelAlert As Boolean = False
    '    Dim inSubMenu As Boolean = False
    '    Dim cursorVisible As Boolean = True
    '    Shared curScrollObj As scrollObj

    '    'Voice Command Variables
    '    Dim mainMenuID As Integer
    '    'Dim dynamicMenuID As Integer
    '    Dim enableCommands As Boolean = False
    '    Dim continuousCommands As Boolean = False

    '    Dim doQ As Boolean = True


    '    'Dim startList As New programList
    '    Dim myItems As Collection
    '    Dim subList As New Collection
    '    Dim curItem As New Collection

    '    Dim myLoad As New frmLoad

    '    Dim tcpListener As New System.Net.Sockets.TcpListener(80)

    '    Dim Settings As New LCARSsettings

    '    Dim ComputerSound As New System.Media.SoundPlayer(My.Resources.computer)
    '    Dim redAlertSound As New System.Media.SoundPlayer(My.Resources.red_alert1)
    '    Dim Ack As New System.Media.SoundPlayer(My.Resources.ack)

    '#End Region

    '#Region " Control Events "

    '#Region " Form Events "
    '    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    '        Select Case e.KeyData
    '            Case 131149
    '                If cursorVisible Then
    '                    Me.Cursor.Hide()
    '                    cursorVisible = False
    '                Else
    '                    Me.Cursor.Show()
    '                    cursorVisible = True
    '                End If
    '            Case Keys.LWin
    '                fbStart.doClick(sender, New System.EventArgs)
    '            Case Keys.RWin
    '                fbStart.doClick(sender, New System.EventArgs)
    '        End Select

    '    End Sub
#End Region

    Dim lastTime As DateTime
    Dim isInit As Boolean
    Public modBusiness As New modBusiness
#Region " AutoHide "

    Public autohide As IAutohide.AutoHideModes = IAutohide.AutoHideModes.Disabled
    Dim hideCount As Integer = 0

    Private Function FindRoot(ByVal hWnd As Int32) As Int32
        Do
            Dim parent_hwnd As Int32 = GetParent(hWnd)
            If parent_hwnd = 0 Then Return hWnd
            hWnd = parent_hwnd
        Loop
    End Function

    Private Sub UpdateRegion()
        Dim myRegion As Region = New Region(New RectangleF(0, 0, Me.Width, Me.Height))
        Try
            Dim mainRect As New Rectangle
            Dim myLoc As Point = pnlMainBar.PointToScreen(pnlMain.Location)

            mainRect.X = myLoc.X
            mainRect.Y = myLoc.Y
            mainRect.Width = pnlMain.Width
            mainRect.Height = pnlMain.Height

            myRegion.Exclude(mainRect)
            Me.Region = myRegion
        Catch
        End Try
    End Sub

    Public Sub SetAutoHide(ByVal value As IAutohide.AutoHideModes) Implements IAutohide.SetAutoHide

        autohide = value
        If autohide = IAutohide.AutoHideModes.Disabled Then
            tmrAutoHide.Enabled = False
            hideCount = 0
            pnlMainBar.Top = 130
            pnlMainBar.Height = Screen.AllScreens(modBusiness.ScreenIndex).Bounds.Height - 130
            pnlMainBar_Resize(New Object, New System.EventArgs)
            Me.Visible = True
        Else
            autohide = IAutohide.AutoHideModes.Visible
            tmrAutoHide.Enabled = True
        End If
    End Sub

    Private Sub tmrAutoHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutoHide.Tick
        If Not autohide = IAutohide.AutoHideModes.Disabled Then
            Dim myPoint As POINTAPI
            myPoint.X = MousePosition.X
            myPoint.Y = MousePosition.Y

            Dim rootHwnd As IntPtr = FindRoot(WindowFromPoint(myPoint))

            If rootHwnd = Me.Handle Or _
             myPoint.Y < 1 Or myPoint.X < 1 Or _
             modBusiness.progShowing = True Or modBusiness.userButtonsShowing = True Then

                hideCount = 0
                ' pnlMainBar.Height = Me.Height

                If Not autohide = IAutohide.AutoHideModes.Visible Or Me.Visible = False Then
                    pnlMainBar.Top = 130
                    pnlMainBar.Height = Screen.AllScreens(modBusiness.ScreenIndex).Bounds.Height - 130
                    pnlMainBar_Resize(sender, e)


                    Me.Visible = True
                    autohide = IAutohide.AutoHideModes.Visible
                End If

            End If


            If hideCount <= 30 Then
                hideCount += 1
            Else
                autohide = IAutohide.AutoHideModes.Hidden
                pnlMainBar.Bounds = Screen.AllScreens(modBusiness.ScreenIndex).Bounds
                pnlMain.Bounds = pnlMainBar.Bounds
                UpdateRegion()
                Me.Visible = False
                ' pnlMainBar.Height = Screen.AllScreens(modBusiness.ScreenIndex).Bounds.Height + 70
            End If
        Else
            tmrAutoHide.Enabled = False
        End If

    End Sub

#End Region




    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        modBusiness.ScreenIndex = ScreenIndex
        modBusiness.init(Me)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '        If Screen.AllScreens.GetUpperBound(0) > 0 Then
        '            Dim Secondary As New frmSecondary
        '            Secondary.Text = "secondary"
        '            Secondary.Show()
        '            Secondary.Bounds = Screen.AllScreens(1).Bounds
        '            Secondary.WindowState = FormWindowState.Maximized
        '        End If

        '        loadSettings()
        '        'startList.DirectoryIcon = My.Resources.folder
        Me.Bounds = Screen.AllScreens(modBusiness.ScreenIndex).Bounds
        '  Me.WindowState = FormWindowState.Maximized
        Me.Show()

        Application.DoEvents()


        isInit = True
        pnlMainBar.Top = 130
        pnlMainBar.Height = Screen.AllScreens(modBusiness.ScreenIndex).Bounds.Height - 130
        pnlMainBar_Resize(New Object, New System.EventArgs)
        modBusiness.mainTimer.Enabled = True

        '        showLoginScreen()


        '        Me.Show()
        '        Application.DoEvents()
        '        Me.KeyPreview = True
        '        'Dim myWinSock As Threading.Thread
        '        'myWinSock = New Threading.Thread(AddressOf StartWinSockConnection)
        '        'myWinSock.Start()


        '        Application.DoEvents()
        '        LoadLCARS()
        '        redAlertSound.Load()
        '        ComputerSound.Load()
        '        ie.Navigate(Settings.BrowserHomePage)


        '        If Screen.AllScreens.GetUpperBound(0) > 0 Then
        '            If Settings.HasMultipleScreens = False Then
        '                myLoad.pnlMultMonitor.Visible = True
        '                myLoad.pnlMultMonitor.BringToFront()
        '                myLoad.Show()
        '                myLoad.TopMost = True
        '            End If
        '            '    Me.Bounds = Screen.AllScreens(1).Bounds
        '            '   Me.WindowState = FormWindowState.Maximized
        '        End If

        '        If Now.Day = 17 Then
        '            happyQday()
        '        End If

        ' AnimatePanel(Me, True, 150, True, True)
    End Sub

#Region " Old Code "
    '    Private Sub loadSettings()
    '        Dim AppName As String = "LCARS x32"
    '        Dim Section As String = "Application"
    '        Dim result As String = ""

    '        result = GetSetting(AppName, Section, "SpeechOn", "True")
    '        Settings.SpeechOn = Boolean.Parse(result)

    '        result = GetSetting(AppName, Section, "ButtonBeep", "True")
    '        Settings.ButtonBeep = Boolean.Parse(result)

    '        result = GetSetting(AppName, Section, "BrowserHomePage", "www.lcarsx32.com")
    '        Settings.BrowserHomePage = result

    '        result = GetSetting(AppName, Section, "PanelOpenInterval", "100")
    '        Settings.PanelOpenInterval = Integer.Parse(result)

    '        result = GetSetting(AppName, Section, "PanelCloseInterval", "50")
    '        Settings.PanelCloseInterval = Integer.Parse(result)

    '        result = GetSetting(AppName, Section, "UseGestures", "True")
    '        Settings.UseGestures = Boolean.Parse(result)

    '        updateButtonBeep(Me, Settings.ButtonBeep)
    '        updateButtonBeep(myLoad, Settings.ButtonBeep)
    '        tmrGestures.Enabled = Settings.UseGestures

    '    End Sub

    '    Private Sub saveSettings()
    '        Dim AppName As String = "LCARS x32"
    '        Dim Section As String = "Application"

    '        SaveSetting(AppName, Section, "SpeechOn", Settings.SpeechOn.ToString)
    '        SaveSetting(AppName, Section, "ButtonBeep", Settings.ButtonBeep.ToString)
    '        SaveSetting(AppName, Section, "BrowserHomePage", Settings.BrowserHomePage)
    '        SaveSetting(AppName, Section, "PanelOpenInterval", Settings.PanelOpenInterval)
    '        SaveSetting(AppName, Section, "PanelCloseInterval", Settings.PanelCloseInterval)
    '        SaveSetting(AppName, Section, "UseGestures", Settings.UseGestures)
    '    End Sub


    '    Private Sub showLoginScreen()

    '        myLoad.Show()
    '        With myLoad
    '            .sbAccess.Clickable = False

    '            If Settings.SpeechOn = False Then
    '                .lblVoice.Visible = False
    '                .fbVoice.Visible = False
    '            End If

    '            .lblWelcome.Text = "Welcome to the LCARS x32 Pre-Alpha release." & vbNewLine & vbNewLine & "Please keep in mind that this is a VERY early release.  It is not fully functional.  In fact, I would put it at around 15-25% functional." & vbNewLine & vbNewLine & "Please visit the forums at www.lcarsx32.com to comment on what is good, what is bad, and how LCARS x32 can be made better." & vbNewLine & vbNewLine & "Thanks," & vbNewLine & "-Ray"
    '            Application.DoEvents()


    '            .lblProgramData.ForeColor = Color.Orange
    '            Application.DoEvents()

    '            Try
    '                initStartMenu()
    '                Application.DoEvents()
    '            Catch ex As Exception
    '                LogErr(ex)
    '                .lblWelcome.Text = ex.Message
    '            End Try

    '            .fbProgramData.Lit = True
    '            Application.DoEvents()

    '            If Settings.SpeechOn = True Then
    '                Threading.Thread.Sleep(500)

    '                .lblVoice.ForeColor = Color.Orange
    '                Application.DoEvents()
    '            End If
    '            Try
    '                'loadVoiceCommands()
    '                Application.DoEvents()

    '                beginVoiceRecognition()
    '                Application.DoEvents()
    '                .fbVoice.Lit = True
    '                Application.DoEvents()

    '                .sbAccess.Clickable = True
    '                .sbAccess.Lit = True
    '            Catch ex As Exception

    '                LogErr(ex)

    '                'Show the error to the user
    '                .fbVoice.Lit = True
    '                .fbVoice.Color = LCARS.LCARScolorStyles.FunctionOffline
    '                .lblVoice.ForeColor = Color.Red
    '                Application.DoEvents()
    '                .sbAccess.Clickable = True
    '                .sbAccess.Lit = True
    '                .lblWelcome.Text = ex.Message.ToString
    '            End Try


    '        End With
    '        Do Until myLoad.Visible = False
    '            Application.DoEvents()
    '        Loop
    '    End Sub

    '#End Region

    '#Region " Click Events "



    '    Private Sub fbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbStart.Click

    '        If pnlMain.Left = 0 Then

    '            HideVisible()
    '            elbStart.Visible = True
    '            pnlMain.Left = 380
    '            pnlMain.Width -= 380
    '            AnimatePanel(pnlStart, True, 50)
    '        Else

    '            If pnlPrograms.Visible Then
    '                AnimatePanel(pnlPrograms, False)
    '                elbProgsTop.Visible = False
    '                elbProgsBottom.Visible = False
    '            End If

    '            AnimatePanel(pnlStart, False)
    '            elbStart.Visible = False
    '            pnlMain.Left = 0
    '            pnlMain.Width = Me.Width

    '            ShowVisible()


    '        End If

    ' End Sub

    '    Private Sub fbMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If pnlMyComp.Visible = False Then
    '            pnlMyComp.Location = New Point(0, 0)
    '            pnlMyComp.Size = pnlMainBox.Size
    '            ClearMainBox()
    '            initMyComp()
    '            pnlMyComp.BringToFront()
    '            AnimatePanel(pnlMyComp, True)
    '            AnimatePanel(pnlMyCompOptions, True)
    '            scrollIndex = 0
    '        Else
    '            ClearMainBox()
    '        End If
    '        curScrollObj.Name = "My Computer"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf myCompScroll)
    '    End Sub

    '    Private Sub myCompScroll(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs)
    '        If e.Button = Windows.Forms.MouseButtons.Left Then

    '            If e.Y - ScrollStartY > 50 Then

    '                If scrollIndex + maxScrollItems < curFiles.GetUpperBound(0) Then

    '                    scrollIndex += maxScrollItems
    '                    UpdateMyComp(scrollIndex)
    '                    AnimatePanel(pnlMyComp, True)
    '                    ScrollStartY = e.Y
    '                End If

    '            ElseIf ScrollStartY - e.Y > 50 Then

    '                If scrollIndex > 0 Then
    '                    'If curFiles.GetUpperBound(0) - scrollIndex < maxScrollItems Then
    '                    If scrollIndex >= maxScrollItems Then
    '                        scrollIndex -= maxScrollItems
    '                    Else

    '                        If scrollIndex - (maxScrollItems) < 0 Then
    '                            scrollIndex = 0
    '                        Else
    '                            scrollIndex -= maxScrollItems
    '                        End If

    '                    End If

    '                    UpdateMyComp(scrollIndex)
    '                    AnimatePanel(pnlMyComp, True)
    '                    ScrollStartY = e.Y
    '                End If
    '            End If

    '        End If
    '    End Sub

    '    Private Sub fbAllProgs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbAllProgs.Click
    '        pnlPrograms.BringToFront()

    '        If pnlPrograms.Visible Then


    '            AnimatePanel(pnlPrograms, False)

    '            Threading.Thread.Sleep(100)

    '            elbProgsTop.Visible = False
    '            elbProgsBottom.Visible = False



    '            AnimatePanel(pnlPrograms, False)


    '        Else
    '            curItem = myItems
    '            FlatButton30.ButtonText = curItem.Count

    '            scrollIndex = 1
    '            UpdateStartMenu(scrollIndex)

    '            elbProgsBottom.Visible = True
    '            elbProgsTop.Visible = True
    '            Application.DoEvents()

    '            Threading.Thread.Sleep(500)

    '            AnimatePanel(pnlPrograms, True)
    '        End If

    '        curScrollObj = Nothing
    '        scrollIndex = 1
    '        curScrollObj.Name = "All Programs"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf StartMenuScroll)

    '    End Sub

    '    'Private Sub myProgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    With startItems(startItems.GetUpperBound(0) - (Int(CType(sender, Control).Tag)))
    '    '        If Directory.Exists(.FullName) = False Then
    '    '            'LaunchLink(.FullName)
    '    '            ' Me.SendToBack()
    '    '            fbStart_Click(sender, e)
    '    '        Else
    '    '            inSubMenu = True
    '    '            startItems = getDir(startItems(startItems.GetUpperBound(0) - (Int(CType(sender, Control).Tag))).FullName)
    '    '            startItems = RemoveDuplicates(startItems)
    '    '            FlatButton30.ButtonText = (startItems.GetUpperBound(0) + 1)
    '    '            UpdateStartMenu(0)
    '    '            AnimatePanel(pnlPrograms, True)
    '    '        End If
    '    '    End With
    '    'End Sub


    '    Private Sub myCompButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        With MyCompItems(Int(CType(sender, Control).Tag))
    '            UpdateMyComp(0, .Name)
    '            AnimatePanel(pnlMyComp, True)
    '        End With
    '    End Sub

    '    Private Sub fbControlPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    '    Private Sub myDirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        With curFiles(Int(CType(sender, LCARS.LCARSbuttonClass).Data))
    '            If Directory.Exists(.FullName) Then
    '                scrollIndex = 0
    '                UpdateMyComp(0, .FullName)
    '                AnimatePanel(pnlMyComp, True)
    '            Else
    '                Process.Start(.FullName)
    '            End If
    '        End With
    '    End Sub

    '    Private Sub sbDestruct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDestruct.Click

    '        If tmrShutdown.Enabled = False Then
    '            If txtHrs.Text = "" Then txtHrs.Text = "0"
    '            If txtMins.Text = "" Then txtMins.Text = "0"
    '            If txtSecs.Text = "" Then txtSecs.Text = "0"

    '            intTimeLeft = Int(txtSecs.Text)
    '            intTimeLeft += Int(txtMins.Text) * 60
    '            intTimeLeft += (Int(txtHrs.Text) * 60) * 60

    '            If intTimeLeft > 1 Then
    '                tmrShutdown.Enabled = True
    '                sbDestruct.ButtonText = "ABORT SELF DESTRUCT"
    '                lblTime.Visible = True
    '                lblRemaining.Visible = True
    '            End If

    '        Else
    '            tmrShutdown.Enabled = False
    '            tmrAbort.Enabled = True
    '        End If

    '    End Sub

    '    Private Sub fbDestruct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDestruct.Click
    '        If pnlDestruct.Visible = False Then
    '            pnlDestruct.Location = New Point(0, 0)
    '            pnlDestruct.Size = pnlMainBox.Size
    '            ClearMainBox()
    '            txtHrs.Text = "0"
    '            txtMins.Text = "0"
    '            txtSecs.Text = "0"
    '            lblTime.Text = "00:00:00"
    '            intTimeLeft = -1
    '            pnlDestruct.BringToFront()
    '            AnimatePanel(pnlDestruct, True)
    '        Else
    '            ClearMainBox()
    '        End If
    '    End Sub

    '    Private Sub txtHrs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHrs.Click
    '        txtHrs.Text = ""
    '    End Sub

    '    Private Sub txtMins_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMins.Click
    '        txtMins.Text = ""
    '    End Sub

    '    Private Sub txtSecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSecs.Click
    '        txtSecs.Text = ""
    '    End Sub

    '    Private Sub fbHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        ClearMainBox()
    '    End Sub

    '#End Region

    '#Region " Timer Tick Events "

    '    Private Sub tmrShutdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrShutdown.Tick

    '        If intTimeLeft = -1 Then
    '            Dim result As MsgBoxResult
    '            tmrShutdown.Enabled = False
    '            result = MsgBox("Are you sure you want to shut down immediately?", MsgBoxStyle.YesNo, "IMMEDIATE SHUTDOWN?")

    '            If result = MsgBoxResult.Yes Then
    '                ShutDown()
    '            End If
    '        Else
    '            If intTimeLeft > 0 Then
    '                intTimeLeft -= 1
    '                Dim hr, min, sec, buffer As Integer
    '                buffer = intTimeLeft
    '                Try
    '                    hr = (buffer \ 60) \ 60
    '                    buffer = buffer - ((hr * 60) * 60)
    '                Catch ex As Exception
    '                    'Save a log of the error in case it is a major problem that needs addressing
    '                    LogErr(ex)

    '                    'Show the error to the user
    '                End Try

    '                Try
    '                    min = buffer \ 60
    '                    buffer = buffer - (min * 60)
    '                Catch ex As Exception
    '                    'Save a log of the error in case it is a major problem that needs addressing
    '                    LogErr(ex)

    '                    'Show the error to the user
    '                End Try

    '                sec = buffer

    '                lblTime.Text = Format(hr, "00") & ":" & Format(min, "00") & ":" & Format(sec, "00")
    '                Me.Text = lblTime.Text
    '            Else
    '                tmrShutdown.Enabled = False
    '                ShutDown()
    '            End If
    '        End If

    '    End Sub

    '    Private Sub tmrAbort_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAbort.Tick

    '        If intTimeLeft > 1 Then
    '            If intTimeLeft < 60 Then
    '                intTimeLeft -= 1
    '            Else
    '                intTimeLeft -= 10
    '            End If

    '            Dim hr, min, sec, buffer As Integer
    '            buffer = intTimeLeft
    '            Try
    '                hr = (buffer \ 60) \ 60
    '                buffer = buffer - ((hr * 60) * 60)
    '            Catch ex As Exception
    '                'Save a log of the error in case it is a major problem that needs addressing
    '                LogErr(ex)

    '                'Show the error to the user
    '            End Try

    '            Try
    '                min = buffer \ 60
    '                buffer = buffer - (min * 60)
    '            Catch ex As Exception
    '                'Save a log of the error in case it is a major problem that needs addressing
    '                LogErr(ex)

    '                'Show the error to the user
    '            End Try

    '            sec = buffer

    '            lblTime.Text = Format(hr, "00") & ":" & Format(min, "00") & ":" & Format(sec, "00")
    '            Me.Text = lblTime.Text
    '        Else
    '            tmrAbort.Enabled = False
    '            lblTime.Visible = False
    '            lblRemaining.Visible = False
    '            sbDestruct.ButtonText = "START SELF DESTRUCT"
    '            Application.DoEvents()
    '            AnimatePanel(pnlDestruct, False)
    '        End If
    '    End Sub

    '    Private Sub tmrBatt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBatt.Tick
    '        lblBatt.Text = (mybatt.BatteryLifePercent * 100) & "%"

    '        If mybatt.PowerLineStatus = PowerLineStatus.Online Then
    '            lblPowerSource.Text = "PRIMARY"
    '            If fbBatt1.Color <> LCARS.LCARScolorStyles.StaticTan Then
    '                fbBatt1.Color = LCARS.LCARScolorStyles.StaticTan
    '                fbBatt2.Color = LCARS.LCARScolorStyles.StaticTan
    '                fbBatt3.Color = LCARS.LCARScolorStyles.StaticTan
    '                fbBatt4.Color = LCARS.LCARScolorStyles.StaticTan
    '                fbBatt5.Color = LCARS.LCARScolorStyles.StaticTan
    '                fbBatt6.Color = LCARS.LCARScolorStyles.StaticTan
    '            End If
    '        Else
    '            If fbBatt1.Color <> LCARS.LCARScolorStyles.StaticBlue Then
    '                lblPowerSource.Text = "AUXILIARY"
    '                fbBatt1.Color = LCARS.LCARScolorStyles.StaticBlue
    '                fbBatt2.Color = LCARS.LCARScolorStyles.StaticBlue
    '                fbBatt3.Color = LCARS.LCARScolorStyles.StaticBlue
    '                fbBatt4.Color = LCARS.LCARScolorStyles.StaticBlue
    '                fbBatt5.Color = LCARS.LCARScolorStyles.StaticBlue
    '                fbBatt6.Color = LCARS.LCARScolorStyles.StaticBlue
    '            End If
    '        End If

    '        Application.DoEvents()

    '        If mybatt.BatteryLifePercent < 0.95 Then
    '            fbBatt6.Lit = False
    '        Else
    '            fbBatt6.Lit = True
    '        End If

    '        If mybatt.BatteryLifePercent < 0.8 Then
    '            fbBatt5.Lit = False
    '        Else
    '            fbBatt5.Lit = True
    '        End If

    '        If mybatt.BatteryLifePercent < 0.6 Then
    '            fbBatt4.Lit = False
    '        Else
    '            fbBatt4.Lit = True
    '        End If

    '        If mybatt.BatteryLifePercent < 0.4 Then
    '            fbBatt3.Lit = False
    '        Else
    '            fbBatt3.Lit = True
    '        End If

    '        If mybatt.BatteryLifePercent < 0.2 Then
    '            fbBatt2.Lit = False
    '        Else
    '            fbBatt2.Lit = True
    '        End If

    '        If mybatt.BatteryLifePercent > 0.11 Then
    '            fbBatt1.Flash = False
    '        Else
    '            If fbBatt1.Flash = False Then
    '                If mybatt.PowerLineStatus = PowerLineStatus.Offline Then
    '                    fbBatt1.Flash = True
    '                End If
    '            End If
    '        End If

    '    End Sub



    '#End Region

    '#Region " Paint Events "

    '    Private Sub pnlMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlMain.Paint
    '        '   Me.SendToBack()
    '    End Sub

    '#End Region

    '#End Region

    '#Region " Subs "

    '    Public Sub beginVoiceRecognition()

    '        If Settings.SpeechOn = True Then

    '            vCommand.Initialized = 1
    '            Dim strinput As String = ""
    '            Dim split() As String
    '            Dim myCommand As String
    '            Dim myAction As String


    '            'Get a menu ID from vCommand
    '            mainMenuID = vCommand.get_MenuCreate(My.Application.Info.AssemblyName, "state1", 4)

    '            'Turn on voice commands
    '            vCommand.CtlEnabled = 1

    '            'Read the vCommands.ini file which contains the system commands
    '            Dim myReader As System.IO.StreamReader = New System.IO.StreamReader(Application.StartupPath & "\vCommands.ini")
    '            Do Until myReader.Peek = -1
    '                strinput = myReader.ReadLine
    '                strinput = Trim(strinput)

    '                'Strip comments
    '                If InStr(strinput, "//") > 0 Then
    '                    strinput = Microsoft.VisualBasic.Left(strinput, InStr(strinput, "//") - 1)
    '                End If

    '                If Not strinput = "" Then
    '                    split = strinput.Split("=")

    '                    myCommand = Trim(split(0))

    '                    'Add the action to the list
    '                    myAction = Trim(split(1))

    '                    'Add the command to the vCommand listener
    '                    vCommand.AddCommand(mainMenuID, 1, myCommand, " ", "System Commands", 0, myAction)
    '                End If
    '            Loop

    '            'Add the command to the vCommand listener
    '            vCommand.AddCommand(mainMenuID, 1, "run program phillips one", " ", "System Commands", 0, "run program phillips one")

    '            'set the munu as the active menu
    '            vCommand.Activate(mainMenuID)

    '        Else
    '            'turn off voice commands
    '            vCommand.CtlEnabled = 0
    '        End If




    '    End Sub

    '    Private Sub Vcommand_CommandRecognize(ByVal sender As System.Object, ByVal e As AxHSRLib._VcommandEvents_CommandRecognizeEvent) Handles vCommand.CommandRecognize

    '        Dim recoResult As String = e.action 'Get the action associated with the command that was spoken
    '        Dim myE As New System.EventArgs

    '        If recoResult = "computer" Then
    '            enableCommands = True
    '            ComputerSound.Play()
    '        Else

    '            If enableCommands = True Then
    '                Ack.Play()
    '                Select Case recoResult.ToLower
    '                    Case "access"
    '                        myLoad.sbAccess_Click(sender, myE)
    '                    Case "menu"
    '                        fbStart_Click(sender, myE)
    '                    Case "my computer"
    '                        fbMyComp_Click(sender, myE)
    '                    Case "my documents"
    '                        fbMyDocs_Click(sender, myE)
    '                    Case "my pictures"
    '                        fbMyPictures_Click(sender, myE)
    '                    Case "my music"
    '                        fbMyMusic_Click(sender, myE)
    '                    Case "programs"
    '                        fbAllProgs_Click(sender, myE)
    '                    Case "deactivate"
    '                        fbDeactivate_Click(sender, myE)
    '                    Case "specify parameters"
    '                        fbSettings_Click(sender, myE)
    '                    Case "self destruct"
    '                        fbDestruct.doClick(sender, myE)
    '                    Case "log off"
    '                        fbLogOff.doClick(sender, myE)
    '                    Case "system browser"
    '                        fbMainBrowser_Click(sender, myE)
    '                    Case "home"
    '                        fbHome_Click(sender, myE)
    '                    Case "red alert"
    '                        redAlert()
    '                    Case "cancel red alert"
    '                        CancelRedAlert()
    '                    Case "list programs"
    '                        If pnlStart.Visible = False Then
    '                            fbStart.doClick(sender, myE)
    '                        End If
    '                        If pnlPrograms.Visible = False Then
    '                            fbAllProgs.doClick(sender, myE)
    '                        End If
    '                    Case "shut down"
    '                        ShutDown()
    '                    Case "back"
    '                        sbMyCompBack.doClick(sender, myE)
    '                    Case "continuous commands"
    '                        continuousCommands = True
    '                    Case "end commands"
    '                        continuousCommands = False
    '                    Case "scroll up"
    '                        Form1_MouseWheel(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.None, 0, 0, 0, 500))
    '                    Case "scroll down"
    '                        Form1_MouseWheel(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.None, 0, 0, 0, -500))
    '                    Case "run program phillips one"
    '                        happyQday()
    '                    Case "go away q"
    '                        goAwayQ()
    '                    Case Else
    '                        Dim myResult As Boolean = False

    '                        If recoResult.Length = 1 Then
    '                            myResult = checkDrives(recoResult)
    '                        End If

    '                        If myResult = False Then
    '                            Dim mybutton As New LCARS.LCARSbuttonClass

    '                            mybutton = findButton(recoResult, Me)

    '                            If Not mybutton Is Nothing Then
    '                                mybutton.doClick(Me, New EventArgs)
    '                            Else
    '                                FlatButton8.ButtonText = recoResult
    '                            End If
    '                            'fbMyComp.doClick(Me, New EventArgs)
    '                        End If

    '                End Select

    '                enableCommands = continuousCommands
    '            End If
    '        End If
    '    End Sub

    '    Private Sub ShutDown()
    '        'Dim pl As New programList
    '        'Dim os As String = pl.getOS

    '        'Select Case os
    '        '    Case "Win98", "WinNT3.51", "WinNT4.0"
    '        '        Shell("rundll32.exe shell32.dll,SHExitWindowsEx 1")
    '        '    Case "Modern"
    '        '        Shell("Shutdown.exe -s -f -t 00")
    '        'End Select
    '    End Sub

    '    Private Function checkDrives(ByVal letter As String) As Boolean
    '        If pnlMyComp.Visible = True Then
    '            Dim intloop As Integer
    '            For intloop = 0 To pnlMyComp.Controls.Count - 1
    '                If CType(pnlMyComp.Controls(intloop), LCARS.LCARSbuttonClass).Data.ToLower = letter.ToLower Then
    '                    CType(pnlMyComp.Controls(intloop), LCARS.LCARSbuttonClass).doClick(Me, New System.EventArgs)
    '                End If
    '            Next
    '        End If
    '    End Function

    '    Private Function findButton(ByVal buttonText As String, ByVal container As Object) As LCARS.LCARSbuttonClass
    '        Dim mybutton As LCARS.LCARSbuttonClass
    '        Dim intloop As Integer

    '        For intloop = 0 To container.controls.count - 1
    '            If container.controls(intloop).controls.count > 1 And container.visible = True Then
    '                mybutton = findButton(buttonText, container.controls(intloop))
    '                If Not mybutton Is Nothing Then
    '                    Exit For
    '                End If
    '            Else
    '                If InStr(container.controls(intloop).GetType.ToString.ToLower, "lcars") > 0 Then
    '                    If container.controls(intloop).buttontext.tolower = buttonText.ToLower Then
    '                        Return CType(container.controls(intloop), LCARS.LCARSbuttonClass)
    '                        Exit For
    '                    End If
    '                End If
    '            End If
    '        Next

    '        Return mybutton
    '    End Function


    '    Private Sub AnimatePanel(ByRef myPanel As Panel, ByVal makeVisible As Boolean, Optional ByVal interval As Integer = 10)

    '        Dim index As Integer
    '        Dim myCommand As String
    '        Dim myAction As String
    '        Dim myButton As LCARS.LCARSbuttonClass

    '        tmrBatt.Enabled = False
    '        tmrClock.Enabled = False

    '        'close all sub panels first.
    '        If makeVisible = False Then
    '            For Each myControl As Control In myPanel.Controls
    '                If myControl.GetType Is myPanel.GetType And myControl.Visible = True Then
    '                    AnimatePanel(myControl, False)
    '                End If
    '            Next
    '        End If



    '        If makeVisible = True Then
    '            myPanel.Visible = True
    '            Do Until index = Int(Replace(myPanel.Tag, ".", ""))

    '                For Each myControl As Control In myPanel.Controls
    '                    Try
    '                        If myControl.Tag = index Then
    '                            myControl.Visible = True
    '                            Application.DoEvents()

    '                            'If Microsoft.VisualBasic.Left(myControl.GetType.ToString, 5) = "LCARS" Then
    '                            '    myButton = CType(myControl, LCARS.LCARSbuttonClass)
    '                            '    If myButton.Clickable = True Then
    '                            '        If myButton.ButtonText <> "" And myButton.ButtonText <> "LCARS" Then
    '                            '            'Add the command to the list
    '                            '            myCommand = myButton.ButtonText

    '                            '            'Add the action to the list
    '                            '            myAction = myButton.ButtonText

    '                            '            vCommand.AddCommand(mainMenuID, 1, myCommand, myPanel.Name, "System Command", 0, myAction)
    '                            '        End If
    '                            '    End If
    '                            'End If

    '                        End If
    '                    Catch ex As Exception
    '                        'Save a log of the error in case it is a major problem that needs addressing
    '                        LogErr(ex, "Error on " & myPanel.Name & " at index " & index)

    '                        'Show the error to the user
    '                    End Try
    '                Next

    '                index += 1
    '                Application.DoEvents()
    '                Threading.Thread.Sleep(interval)
    '            Loop
    '        Else

    '            If Not myPanel.Tag Is Nothing Then
    '                If InStr(myPanel.Tag.ToString, ".") > 0 Then
    '                    index = Int(Replace(myPanel.Tag, ".", "")) - 1
    '                End If
    '            End If

    '            Do Until index = -1
    '                For Each myControl As Control In myPanel.Controls
    '                    Try
    '                        If myControl.Tag = index Then
    '                            myControl.Visible = False
    '                            'If myControl.GetType.ToString.Substring(0, 5) = "LCARS" Then
    '                            '    With CType(myControl, LCARS.LCARSbuttonClass)
    '                            '        If .Clickable Then
    '                            '            Dim intloop As Integer
    '                            '            Dim command As String
    '                            '            Dim action As String
    '                            '            Dim desc As String
    '                            '            Dim cat As String
    '                            '            Dim flags As Integer

    '                            '            For intloop = 1 To vCommand.get_CountCommands(mainMenuID)
    '                            '                vCommand.GetCommand(mainMenuID, intloop, command, desc, cat, flags, action)
    '                            '                If command.ToLower = .ButtonText.ToLower Then
    '                            '                    vCommand.EnableItem(mainMenuID, 0, intloop, 0)
    '                            '                    Exit For
    '                            '                End If
    '                            '            Next
    '                            '        End If
    '                            '    End With
    '                            'End If
    '                            Application.DoEvents()
    '                        End If
    '                    Catch ex As Exception
    '                        'Save a log of the error in case it is a major problem that needs addressing
    '                        LogErr(ex, "Error on " & myPanel.Name & " at index " & index)

    '                        'Show the error to the user
    '                    End Try
    '                Next

    '                index -= 1
    '                Application.DoEvents()
    '                Threading.Thread.Sleep(interval)
    '            Loop

    '            myPanel.Visible = False
    '            GC.Collect()

    '        End If




    '        Dim sender As New Object
    '        Dim e As New System.EventArgs
    '        tmrBatt_Tick(sender, e)
    '        tmrBatt.Enabled = True
    '        tmrClock_Tick(sender, e)
    '        tmrClock.Enabled = True

    '    End Sub

    '    Private Sub CancelRedAlert()
    '        cancelAlert = True
    '        tmrRedAlert.Enabled = False
    '        pnlRedAlert.Visible = False
    '    End Sub

    '    Private Sub ClearMainBox()

    '        If pnlStart.Visible Then
    '            fbStart.doClick(New Object, New System.EventArgs)
    '        End If

    '        If pnlSettings.Visible = True Then
    '            pnlMainBox.Bounds = mainBoxSize
    '        End If

    '        For Each myPanel As Control In pnlMainBox.Controls
    '            If myPanel.GetType Is pnlMainBox.GetType Then
    '                If myPanel.Visible = True Then
    '                    AnimatePanel(myPanel, False)
    '                End If
    '            End If
    '        Next

    '        For Each mypanel As Control In pnlOptionsBox.Controls
    '            If mypanel.GetType Is pnlOptionsBox.GetType Then
    '                If mypanel.Visible = True Then
    '                    AnimatePanel(mypanel, False)
    '                End If
    '            End If
    '        Next
    '    End Sub

    '    Private Sub HideVisible()
    '        curVisible = Nothing

    '        For Each myPanel As Control In pnlMainBox.Controls
    '            If myPanel.GetType.ToString.ToLower = "system.windows.forms.panel" And myPanel.Visible = True Then
    '                curVisible = CType(myPanel, Panel)
    '                AnimatePanel(curVisible, False, 10)
    '                Exit For
    '            End If
    '        Next


    '    End Sub

    '    Private Sub initMyComp()
    '        Dim tmpItems() As System.IO.DriveInfo
    '        Dim intloop As Integer
    '        Dim myDriveComparer As New DriveComparer
    '        tmpItems = System.IO.DriveInfo.GetDrives

    '        ReDim MyCompItems(-1)
    '        For intloop = 0 To tmpItems.GetUpperBound(0)
    '            ReDim Preserve MyCompItems(MyCompItems.GetUpperBound(0) + 1)
    '            With MyCompItems(MyCompItems.GetUpperBound(0))
    '                .DriveType = tmpItems(intloop).DriveType
    '                .IsReady = tmpItems(intloop).IsReady
    '                .Name = tmpItems(intloop).Name
    '                If .IsReady Then
    '                    .VolumeLabel = tmpItems(intloop).VolumeLabel
    '                End If
    '            End With
    '        Next
    '        Array.Sort(MyCompItems, myDriveComparer)
    '        UpdateMyComp(0, "mycomp")
    '    End Sub

    '    Public Sub initStartMenu()
    '        'myItems = startList.GetAllPrograms
    '        scrollIndex = 0
    '    End Sub



    '    Private Sub LoadLCARS()
    '        Dim sender As Object
    '        Dim e As System.EventArgs

    '        AnimatePanel(pnlMain, True, 50)

    '        ' If Not mybatt.BatteryChargeStatus = BatteryChargeStatus.NoSystemBattery Then
    '        AnimatePanel(pnlBatt, True)
    '        tmrBatt_Tick(sender, e)
    '        tmrBatt.Enabled = True
    '        ' End If

    '    End Sub

    '    Private Sub MainAlert()

    '        Dim intloop As Integer
    '        Dim LCARSbutton As New LCARS.LCARSbuttonClass
    '        Dim LCARStype As Type = LCARSbutton.GetType
    '        ' redAlertSound.PlayLooping()

    '        Do

    '            For intloop = 0 To Int(pnlMain.Tag.ToString.Replace(".", "")) - 1

    '                For Each myButton As Control In pnlMain.Controls
    '                    If myButton.GetType.IsSubclassOf(LCARStype) Then

    '                        With CType(myButton, LCARS.LCARSbuttonClass)
    '                            If cancelAlert = False Then
    '                                If myButton.Tag = intloop Then
    '                                    .RedAlert = LCARS.LCARSalert.White
    '                                    Application.DoEvents()
    '                                Else
    '                                    If .RedAlert <> LCARS.LCARSalert.Red Then
    '                                        .RedAlert = LCARS.LCARSalert.Red
    '                                        Application.DoEvents()
    '                                    End If
    '                                End If
    '                            Else
    '                                redAlertSound.Stop()
    '                                Exit Do
    '                            End If
    '                        End With
    '                    End If
    '                Next
    '                Threading.Thread.Sleep(50)
    '            Next
    '        Loop

    '        For Each mybutton As Control In pnlMain.Controls
    '            If mybutton.GetType.IsSubclassOf(LCARStype) Then
    '                With CType(mybutton, LCARS.LCARSbuttonClass)
    '                    .RedAlert = LCARS.LCARSalert.Normal
    '                End With
    '            End If
    '        Next

    '    End Sub

    '    Private Sub ShowVisible()
    '        If Not curVisible Is Nothing Then
    '            AnimatePanel(curVisible, True)
    '            Select Case curVisible.Name
    '                Case "pnlBrowser"
    '                    curScrollObj.Name = "Browser"
    '                    curScrollObj.ScrollMethod = New scMethod(AddressOf ScrollBrowser)
    '                Case "pnlMyComp"
    '                    curScrollObj.Name = "My Computer"
    '                    curScrollObj.ScrollMethod = New scMethod(AddressOf myCompScroll)
    '            End Select

    '        End If

    '    End Sub

    '    Private Sub UpdateMyComp(Optional ByVal index As Integer = 0, Optional ByVal path As String = "same")

    '        maxScrollItems = pnlMyComp.Height \ (sbButton.Height + 6)
    '        maxScrollItems = maxScrollItems * (pnlMyComp.Width \ (sbButton.Width + 6))


    '        Dim intloop As Integer
    '        Dim maxIndex As Integer
    '        Dim curPos As Point = New Point(6, 0)


    '        AnimatePanel(pnlMyComp, False, 5)
    '        pnlMyComp.Controls.Clear()
    '        GC.Collect()

    '        pnlMyComp.Tag = "." & 0


    '        If path = "mycomp" Then
    '            lblMyCompTitle.Text = "MY COMPUTER"
    '            BrowsedFolders.Clear()
    '            BrowsedFolders.Add(path)

    '            If index < MyCompItems.Length Then
    '                Try
    '                    For intloop = index To MyCompItems.GetUpperBound(0)
    '                        With MyCompItems(intloop)
    '                            Dim mybutton As New LCARS.Controls.ComplexButton
    '                            mybutton.ButtonTextAlign = ContentAlignment.BottomRight
    '                            mybutton.ButtonTextHeight = 26
    '                            mybutton.Beeping = Settings.ButtonBeep

    '                            If .IsReady Then
    '                                mybutton.ButtonText = .Name & " - " & .VolumeLabel
    '                            Else
    '                                mybutton.ButtonText = .Name & " - NOT READY"
    '                                mybutton.Lit = False
    '                            End If

    '                            mybutton.Color = LCARS.LCARScolorStyles.NavigationFunction
    '                            Select Case .DriveType
    '                                Case DriveType.Fixed
    '                                    mybutton.SideText = "HARD DRIVE"
    '                                Case DriveType.CDRom
    '                                    mybutton.SideText = "OPTICAL DRIVE"
    '                                Case DriveType.Network
    '                                    mybutton.SideText = "NETWORK DRIVE"
    '                                Case DriveType.Ram
    '                                    mybutton.SideText = "RAM DRIVE"
    '                                Case DriveType.Removable
    '                                    mybutton.SideText = "REMOVABLE DRIVE"
    '                                Case DriveType.Unknown
    '                                    mybutton.SideText = "UNKNOWN TYPE"
    '                            End Select

    '                            mybutton.Data = Microsoft.VisualBasic.Left(.Name, 1)

    '                            mybutton.Size = New Point(pnlMyComp.Width - 12, sbButton.Height)
    '                            mybutton.Location = curPos
    '                            mybutton.Visible = False

    '                            If curPos.Y + 42 < pnlMyComp.Height - mybutton.Height Then
    '                                curPos.Y += mybutton.Height + 6
    '                            Else
    '                                curPos.Y = 0
    '                                curPos.X += mybutton.Width + 6
    '                            End If

    '                            mybutton.Tag = intloop

    '                            AddHandler mybutton.Click, AddressOf myCompButton_Click

    '                            pnlMyComp.Controls.Add(mybutton)


    '                        End With

    '                        pnlMyComp.Tag = "." & intloop + 1


    '                    Next
    '                Catch ex As Exception
    '                    'Save a log of the error in case it is a major problem that needs addressing
    '                    LogErr(ex)

    '                    'Show the error to the user
    '                    redAlert(ex.Message)
    '                    UpdateMyComp(index, path)
    '                End Try
    '            End If
    '        Else
    '            Try
    '                If Not path = "same" Then 'a path was specified, so load the path.  Otherwise, use the files already in curFiles.

    '                    lblMyCompTitle.Text = System.IO.Path.GetFileNameWithoutExtension(path).ToUpper
    '                    If lblMyCompTitle.Text = "" Then
    '                        lblMyCompTitle.Text = path.ToUpper
    '                    End If

    '                    Dim myDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(path)
    '                    Dim buffer() As System.IO.FileSystemInfo

    '                    curFiles = myDir.GetDirectories

    '                    If BrowsedFolders.Count > 0 Then
    '                        If Not path.ToLower = BrowsedFolders.Item(BrowsedFolders.Count).ToString.ToLower Then
    '                            BrowsedFolders.Add(path)
    '                            If sbMyCompBack.Lit = False Or sbMyCompBack.Clickable = False Then
    '                                sbMyCompBack.Lit = True
    '                                sbMyCompBack.Clickable = True
    '                            End If
    '                        End If
    '                    Else
    '                        BrowsedFolders.Add(path)
    '                    End If

    '                    buffer = myDir.GetFiles

    '                    ReDim Preserve curFiles(curFiles.GetUpperBound(0) + buffer.GetUpperBound(0) + 1)

    '                    Array.Copy(buffer, 0, curFiles, curFiles.GetUpperBound(0) - buffer.GetUpperBound(0), buffer.GetUpperBound(0) + 1)

    '                    'Array.Sort(curFiles, New FileSystemInfoComparer)
    '                End If




    '                If index < curFiles.Length Then

    '                    If index + maxScrollItems < curFiles.GetUpperBound(0) Then
    '                        maxIndex = index + maxScrollItems
    '                    Else
    '                        maxIndex = curFiles.GetUpperBound(0)
    '                    End If


    '                    Dim tagNo As Integer
    '                    Dim upperTag As Integer
    '                    For intloop = index To maxIndex
    '                        With curFiles(intloop)
    '                            Dim mybutton As New LCARS.Controls.ComplexButton
    '                            mybutton.ButtonTextAlign = ContentAlignment.BottomRight
    '                            mybutton.ButtonTextHeight = 16
    '                            mybutton.holdDraw = True
    '                            mybutton.Beeping = Settings.ButtonBeep

    '                            If Directory.Exists(.FullName) = True Then
    '                                mybutton.Color = LCARS.LCARScolorStyles.NavigationFunction
    '                                mybutton.ButtonText = System.IO.Path.GetFileName(.FullName)
    '                                Dim sideCount As Integer
    '                                Try
    '                                    sideCount = Directory.GetDirectories(.FullName).GetUpperBound(0) + 1
    '                                    sideCount += Directory.GetFiles(.FullName).GetUpperBound(0) + 1
    '                                    mybutton.SideText = sideCount
    '                                Catch ex As Exception
    '                                    'Save a log of the error in case it is a major problem that needs addressing
    '                                    LogErr(ex)

    '                                    'Show the error to the user
    '                                    mybutton.SideText = "--"
    '                                    mybutton.Color = LCARS.LCARScolorStyles.FunctionUnavailable
    '                                End Try

    '                            Else
    '                                mybutton.Color = LCARS.LCARScolorStyles.MiscFunction
    '                                mybutton.ButtonText = System.IO.Path.GetFileName(.FullName)
    '                                Dim myfile As FileInfo = New FileInfo(.FullName)
    '                                mybutton.SideText = getSize(myfile.Length)
    '                            End If


    '                            mybutton.Size = sbButton.Size
    '                            mybutton.Location = curPos
    '                            mybutton.Visible = False

    '                            mybutton.Tag = tagNo
    '                            If tagNo > upperTag Then
    '                                upperTag = tagNo
    '                            End If
    '                            tagNo += 1



    '                            mybutton.Data = intloop

    '                            mybutton.Visible = False

    '                            AddHandler mybutton.Click, AddressOf myDirButton_Click

    '                            mybutton.holdDraw = False
    '                            pnlMyComp.Controls.Add(mybutton)

    '                            If curPos.Y + (mybutton.Height + 6) < pnlMyComp.Height - mybutton.Height Then
    '                                curPos.Y += mybutton.Height + 6
    '                            Else
    '                                If curPos.X + (mybutton.Width + 6) < pnlMyComp.Width - mybutton.Width Then
    '                                    tagNo = 0
    '                                    curPos.Y = 0
    '                                    curPos.X += mybutton.Width + 6
    '                                Else
    '                                    Exit For
    '                                End If
    '                            End If
    '                        End With


    '                    Next
    '                    pnlMyComp.Tag = "." & upperTag + 1
    '                End If
    '            Catch ex As Exception
    '                'Save a log of the error in case it is a major problem that needs addressing
    '                LogErr(ex)

    '                'Show the error to the user
    '                redAlert(ex.Message)
    '                If BrowsedFolders.Count > 1 Then
    '                    path = BrowsedFolders.Item(BrowsedFolders.Count)
    '                Else
    '                    BrowsedFolders.Clear()
    '                    path = "mycomp"
    '                End If
    '                UpdateMyComp(0, path)
    '            End Try

    '        End If
    '    End Sub

    '    Private Function getSize(ByVal byteSize As Double) As String
    '        Dim SizeType As String = "B"

    '        If byteSize > 1024 Then
    '            SizeType = "KB"
    '            byteSize = byteSize / 1024

    '            If byteSize > 1024 Then
    '                SizeType = "MB"
    '                byteSize = byteSize / 1024

    '                If byteSize > 1024 Then
    '                    SizeType = "GB"
    '                    byteSize = byteSize / 1024

    '                    'I doubt this program will ever use this size... but...
    '                    If byteSize > 1024 Then
    '                        SizeType = "TB"
    '                        byteSize = byteSize / 1024
    '                    End If
    '                End If
    '            End If
    '        End If

    '        Return Format(byteSize, "0.00") & SizeType
    '    End Function

    '    'Private Sub UpdateStartMenu(ByVal index As Integer)
    '    '    maxScrollItems = (pnlPrograms.Height \ 42)

    '    '    Dim intloop As Integer
    '    '    Dim maxIndex As Integer
    '    '    Dim curLoc As Point = New Point(55, pnlPrograms.Height - 42)
    '    '    Dim intCount As Integer = 0
    '    '    Dim curFile As New programList.FileStartItem
    '    '    Dim curDir As New programList.DirectoryStartItem



    '    '    'Clear any pre-existing buttons
    '    '    pnlPrograms.Controls.Clear()
    '    '    GC.Collect()

    '    '    pnlPrograms.Tag = ".0"

    '    '    If index < curItem.Count - maxScrollItems Then
    '    '        maxIndex = index + maxScrollItems - 1
    '    '    Else
    '    '        maxIndex = curItem.Count
    '    '    End If

    '    '    Try
    '    '        'Load the files:
    '    '        For intloop = index To maxIndex
    '    '            If curItem.Item(intloop).GetType Is curFile.GetType Then
    '    '                curFile = CType(curItem(intloop), programList.FileStartItem)
    '    '                Dim myButton As New LCARS.Controls.FlatButton
    '    '                myButton.Name = "StartButton" & intloop
    '    '                myButton.Beeping = Settings.ButtonBeep
    '    '                myButton.Tag = intCount
    '    '                intCount += 1
    '    '                myButton.ButtonText = System.IO.Path.GetFileNameWithoutExtension(curFile.Name.ToUpper)
    '    '                myButton.Size = New Size(New Point(147, 36))
    '    '                myButton.Anchor = 6
    '    '                myButton.ButtonTextHeight = 18
    '    '                myButton.Visible = False
    '    '                myButton.Location = curLoc
    '    '                myButton.Data = intloop
    '    '                myButton.Color = LCARS.LCARScolorStyles.MiscFunction


    '    '                AddHandler myButton.Click, AddressOf myFile_Click

    '    '                Dim iconButton As New LCARS.Controls.FlatButton
    '    '                iconButton.ButtonText = ""
    '    '                iconButton.Beeping = Settings.ButtonBeep
    '    '                iconButton.Size = New Size(New Point(40, 36))
    '    '                iconButton.Location = New Point(myButton.Left - 40, myButton.Top)
    '    '                iconButton.Tag = myButton.Tag
    '    '                iconButton.Visible = False

    '    '                Dim myIcon As New PictureBox
    '    '                myIcon.SizeMode = PictureBoxSizeMode.StretchImage
    '    '                myIcon.Size = New Size(New Point(32, 32))
    '    '                myIcon.Location = New Point(2, 2)
    '    '                myIcon.Image = curFile.Link.icon
    '    '                iconButton.Controls.Add(myIcon)
    '    '                pnlPrograms.Controls.Add(iconButton)

    '    '                pnlPrograms.Controls.Add(myButton)
    '    '                curLoc = New Point(curLoc.X, curLoc.Y - 42)
    '    '            ElseIf curItem(intloop).GetType Is curDir.GetType Then
    '    '                curDir = CType(curItem(intloop), programList.DirectoryStartItem)

    '    '                Dim myButton As New LCARS.Controls.FlatButton
    '    '                myButton.Name = "StartButton" & intloop
    '    '                myButton.Beeping = Settings.ButtonBeep
    '    '                myButton.Tag = intCount
    '    '                myButton.ButtonTextHeight = 18
    '    '                intCount += 1
    '    '                myButton.ButtonText = curDir.Name.ToUpper
    '    '                myButton.Size = New Size(New Point(147, 36))
    '    '                myButton.Anchor = 6
    '    '                myButton.Visible = False
    '    '                myButton.Location = curLoc
    '    '                myButton.Data = intloop
    '    '                myButton.Color = LCARS.LCARScolorStyles.NavigationFunction

    '    '                AddHandler myButton.Click, AddressOf myDir_Click

    '    '                Dim iconButton As New LCARS.Controls.FlatButton
    '    '                iconButton.ButtonText = ""
    '    '                iconButton.Beeping = Settings.ButtonBeep
    '    '                iconButton.Size = New Size(New Point(40, 36))
    '    '                iconButton.Location = New Point(myButton.Left - 40, myButton.Top)
    '    '                iconButton.Tag = myButton.Tag
    '    '                iconButton.Visible = False
    '    '                iconButton.Color = LCARS.LCARScolorStyles.NavigationFunction

    '    '                Dim myIcon As New PictureBox
    '    '                myIcon.SizeMode = PictureBoxSizeMode.StretchImage
    '    '                myIcon.Size = New Size(New Point(32, 32))
    '    '                myIcon.Location = New Point(2, 2)
    '    '                myIcon.Image = curDir.icon
    '    '                iconButton.Controls.Add(myIcon)
    '    '                pnlPrograms.Controls.Add(iconButton)

    '    '                pnlPrograms.Controls.Add(myButton)
    '    '                curLoc = New Point(curLoc.X, curLoc.Y - 42)
    '    '            End If
    '    '        Next

    '    '        pnlPrograms.Tag = "." & intCount
    '    '    Catch ex As Exception
    '    '        'Save a log of the error in case it is a major problem that needs addressing
    '    '        LogErr(ex)

    '    '        'Show the error to the user
    '    '        redAlert(ex.Message)
    '    '        fbStart_Click(New Object, New System.EventArgs)
    '    '    End Try
    '    'End Sub

    '#End Region

    '#Region " Functions "

    '    Private Function getDir(ByVal path As String) As FileSystemInfo()
    '        Dim everything(-1) As FileSystemInfo
    '        Dim myDir As DirectoryInfo = New DirectoryInfo(path)
    '        Dim files() As FileSystemInfo

    '        files = myDir.GetFiles
    '        everything = myDir.GetDirectories

    '        ReDim Preserve everything(everything.GetUpperBound(0) + files.GetUpperBound(0) + 1)

    '        Array.Copy(files, 0, everything, everything.GetUpperBound(0) - files.GetUpperBound(0), files.GetUpperBound(0) + 1)

    '        Return everything
    '    End Function



    '    Private Function GetStartMenuPrograms() As System.IO.FileSystemInfo()






    '        'Dim strProgs(-1) As System.IO.FileSystemInfo
    '        'Dim buffer(-1) As System.IO.FileSystemInfo
    '        'Dim GlobalStartPath As String
    '        'Dim UserStartPath As String
    '        'Dim mydir As System.IO.DirectoryInfo

    '        'Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
    '        'myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

    '        'UserStartPath = myReg.GetValue("Programs")

    '        'myReg = Microsoft.Win32.Registry.LocalMachine
    '        'myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

    '        'GlobalStartPath = myReg.GetValue("Common Programs")

    '        'mydir = New System.IO.DirectoryInfo(GlobalStartPath)
    '        'strProgs = mydir.GetFileSystemInfos("*.*")

    '        'mydir = New System.IO.DirectoryInfo(UserStartPath)
    '        'buffer = mydir.GetFileSystemInfos("*.*")


    '        'ReDim Preserve strProgs(strProgs.GetUpperBound(0) + (buffer.GetUpperBound(0) + 1))
    '        'Array.Copy(buffer, 0, strProgs, strProgs.GetUpperBound(0) - buffer.GetUpperBound(0), buffer.GetUpperBound(0) + 1)

    '        'strProgs = RemoveDuplicates(strProgs)
    '        ' ''TODO: GET RID OF DUPLICATE ENTRIES BETWEEN SYSTEM AND USER START MENUS!!

    '        'Return (strProgs)

    '    End Function

    '    Private Function RemoveDuplicates(ByVal myArray() As System.IO.FileSystemInfo) As System.IO.FileSystemInfo()
    '        Dim buffer(-1) As System.IO.FileSystemInfo
    '        Dim buffer2(-1) As System.IO.FileSystemInfo
    '        Dim intloop As Integer
    '        Dim intcount As Integer
    '        Dim found As Boolean

    '        For intloop = 0 To myArray.GetUpperBound(0)

    '            found = False

    '            For intcount = 0 To buffer.GetUpperBound(0)
    '                If buffer(intcount).FullName.ToLower = myArray(intloop).FullName.ToLower Or myArray(intloop).Name.ToLower = "desktop.ini" Or myArray(intloop).Name.ToLower = "thumbs.db" Then
    '                    found = True
    '                End If
    '            Next

    '            If found = False Then
    '                If Not myArray(intloop).Name.ToLower = "desktop.ini" Or myArray(intloop).Name.ToLower = "thumbs.db" Then
    '                    ReDim Preserve buffer(buffer.GetUpperBound(0) + 1)
    '                    buffer(buffer.GetUpperBound(0)) = myArray(intloop)
    '                End If

    '            End If
    '        Next

    '        buffer2 = buffer

    '        ReDim buffer(-1)

    '        Dim myComp As New FileSystemInfoComparer

    '        Array.Sort(buffer2, myComp)

    '        'put directories first
    '        For intloop = 0 To buffer2.GetUpperBound(0)
    '            If buffer2(intloop).Extension.Length = 0 Then
    '                ReDim Preserve buffer(buffer.GetUpperBound(0) + 1)
    '                buffer(buffer.GetUpperBound(0)) = buffer2(intloop)
    '            End If
    '        Next

    '        'then put everything else
    '        For intloop = 0 To buffer2.GetUpperBound(0)
    '            If buffer2(intloop).Extension.Length > 0 Then
    '                ReDim Preserve buffer(buffer.GetUpperBound(0) + 1)
    '                buffer(buffer.GetUpperBound(0)) = buffer2(intloop)
    '            End If
    '        Next

    '        Return buffer
    '    End Function

    '#End Region

    '    Private Sub StartMenuScroll(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '        If e.Button = Windows.Forms.MouseButtons.Left Then

    '            If e.Y - ScrolStartY > 50 Then

    '                If scrollIndex + maxScrollItems <= curItem.Count Then

    '                    scrollIndex += maxScrollItems
    '                    UpdateStartMenu(scrollIndex)
    '                    AnimatePanel(pnlPrograms, True)
    '                    ScrollStartY = e.Y

    '                End If

    '            ElseIf ScrollStartY - e.Y > 50 Then

    '                If scrollIndex > 1 Then
    '                    If scrollIndex > maxScrollItems Then
    '                        scrollIndex -= maxScrollItems
    '                    Else

    '                        'If scrollIndex - (maxScrollItems - 1) < 1 Then
    '                        If scrollIndex - (maxScrollItems + 1) < 1 Then
    '                            scrollIndex = 1
    '                        Else
    '                            scrollIndex -= maxScrollItems + 1
    '                        End If

    '                    End If

    '                    UpdateStartMenu(scrollIndex)
    '                    AnimatePanel(pnlPrograms, True)
    '                    ScrollStartY = e.Y
    '                End If
    '            End If

    '        End If
    '    End Sub



    'Private Sub tmrRedAlert_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRedAlert.Tick
    '    If lblRedAlert.ForeColor.ToArgb = Color.White.ToArgb Then
    '        lblRedAlert.ForeColor = Color.Red
    '    Else
    '        lblRedAlert.ForeColor = Color.White
    '    End If
    'End Sub

    'Private Sub sbDeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    fbDeactivate_Click(sender, e)
    'End Sub

    '    Private Sub ScrollBrowser(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '        Dim scrollDist As Integer
    '        Dim maxScroll As Integer = (ie.Document.Body.ScrollRectangle.Height + 32) - ie.Height
    '        scrollDist = ScrollStartY - e.Y

    '        If e.Button = Windows.Forms.MouseButtons.Left Then
    '            If scrollDist > 0 Then
    '                If Not scrollIndex + scrollDist > maxScroll Then
    '                    scrollIndex += scrollDist
    '                Else
    '                    scrollIndex = maxScroll
    '                End If

    '            Else
    '                If scrollDist < 0 Then
    '                    If Not scrollIndex + scrollDist < 0 Then
    '                        scrollIndex += scrollDist
    '                    Else
    '                        scrollIndex = 0
    '                    End If
    '                End If
    '            End If
    '        End If
    '        ScrollStartY = e.Y

    '        ie.Document.Window.ScrollTo(0, scrollIndex)
    '    End Sub

    '    Private Sub abNavigate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abNavigate.Click

    '        If ie.Url.AbsoluteUri = txtAddress.Text Then
    '            ie.Refresh()
    '        Else
    '            ie.Navigate(txtAddress.Text)
    '        End If
    '        scrollIndex = 0
    '    End Sub

    '    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    '        'myFrame = ie.Document.Window.WindowFrameElement.OffsetRectangle
    '        'MsgBox(myFrame.Height)
    '        'ie.Document.Window.WindowFrameElement.ScrollTop += 10

    '    End Sub

    '    Private Sub fbBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbBrowser.Click
    '        ClearMainBox()
    '        pnlBrowser.Location = New Point(0, 0)
    '        pnlBrowser.Size = pnlMainBox.Size
    '        pnlBrowser.Visible = True
    '        pnlBrowser.BringToFront()
    '        AnimatePanel(pnlBrowser, True)
    '        scrollIndex = 0

    '        ie.Navigate(Settings.BrowserHomePage)
    '        fbStart_Click(sender, e)
    '    End Sub

    '    Private Sub txtAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddress.KeyDown
    '        If e.KeyCode = Keys.Enter Then
    '            Dim myE As System.EventArgs
    '            abNavigate_Click(sender, myE)

    '        End If
    '    End Sub

    '    Private Sub fbMainBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        ClearMainBox()
    '        pnlBrowser.Location = New Point(0, 0)
    '        pnlBrowser.Size = pnlMainBox.Size
    '        pnlBrowser.Visible = True
    '        pnlBrowser.BringToFront()
    '        AnimatePanel(pnlBrowser, True)
    '        scrollIndex = 0
    '        curScrollObj.Name = "Browser"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf ScrollBrowser)


    '    End Sub

    '    Private Sub tmrGestures_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGestures.Tick

    '        Static oldLoc As Point = New Point(-1, -1)
    '        Dim newLoc As Point


    '        If MouseButtons = Windows.Forms.MouseButtons.Left And Not Me.ActiveForm Is Nothing Then
    '            If oldLoc.X = -1 And oldLoc.Y = -1 Then
    '                oldLoc = MousePosition
    '                Dim downArgs As Windows.Forms.MouseEventArgs = New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, oldLoc.X, oldLoc.Y, 0)
    '                ScrollStartX = oldLoc.X
    '                ScrollStartY = oldLoc.Y
    '            Else

    '                newLoc = MousePosition

    '                Dim xMovement As Integer
    '                Dim yMovement As Integer

    '                xMovement = newLoc.X - oldLoc.X
    '                xMovement = Replace(xMovement, "-", "")

    '                yMovement = newLoc.Y - oldLoc.Y
    '                yMovement = Replace(yMovement, "-", "")

    '                If xMovement > 10 Then
    '                    If xMovement > yMovement Then

    '                    Else
    '                        If Not curScrollObj.ScrollMethod Is Nothing Then
    '                            allowClick = False
    '                            Dim moveArgs As Windows.Forms.MouseEventArgs = New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, newLoc.X, newLoc.Y, 0)
    '                            curScrollObj.ScrollMethod.Invoke(Me, moveArgs)

    '                        End If

    '                    End If
    '                ElseIf yMovement > 10 Then
    '                    If Not curScrollObj.ScrollMethod Is Nothing Then
    '                        allowClick = False
    '                        Dim moveArgs As Windows.Forms.MouseEventArgs = New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, newLoc.X, newLoc.Y, 0)
    '                        curScrollObj.ScrollMethod.Invoke(Me, moveArgs)
    '                    End If
    '                Else
    '                    allowClick = True
    '                End If



    '                Application.DoEvents()
    '                ' Threading.Thread.Sleep(20)

    '            End If
    '        Else
    '            oldLoc = New Point(-1, -1)
    '            Application.DoEvents()
    '            'Threading.Thread.Sleep(1)
    '        End If

    '    End Sub

    '    Private Sub myDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim index As Integer
    '        Dim intloop As Integer

    '        If elbProgsTop.Lit = False Then
    '            elbProgsTop.Clickable = True
    '            elbProgsTop.Lit = True
    '            elbProgsBottom.Clickable = True
    '            elbProgsBottom.Lit = True
    '        End If

    '        index = CType(sender, LCARS.LCARSbuttonClass).Data
    '        subList.Add(index)

    '        curItem = myItems
    '        For intloop = 1 To subList.Count
    '            curItem = CType(curItem.Item(CType(subList(intloop), Integer)), programList.DirectoryStartItem).subItems
    '        Next
    '        FlatButton30.ButtonText = curItem.Count
    '        scrollIndex = 1
    '        UpdateStartMenu(scrollIndex)
    '        AnimatePanel(pnlPrograms, True)
    '    End Sub



    '    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles elbProgsBottom.Click, elbProgsTop.Click
    '        If subList.Count > 0 Then
    '            Dim intloop As Integer

    '            subList.Remove(subList.Count)

    '            If subList.Count = 0 Then
    '                elbProgsTop.Clickable = False
    '                elbProgsTop.Lit = False
    '                elbProgsBottom.Clickable = False
    '                elbProgsBottom.Lit = False
    '            End If

    '            curItem = myItems

    '            For intloop = 1 To subList.Count
    '                curItem = CType(curItem.Item(CType(subList(intloop), Integer)), programList.DirectoryStartItem).subItems
    '            Next
    '            FlatButton30.ButtonText = curItem.Count
    '            scrollIndex = 1
    '            UpdateStartMenu(scrollIndex)
    '            AnimatePanel(pnlPrograms, True)
    '        End If
    '    End Sub

    '    Private Sub ArrowButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Not scrollIndex - 1 < 0 Then
    '            scrollIndex -= 1
    '        Else
    '            scrollIndex = 0
    '        End If
    '        ie.Document.Window.ScrollTo(0, scrollIndex)

    '    End Sub

    '    Private Sub fbLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbLogOff.Click
    '        'tmrGestures.Enabled = False
    '        ' tmrBatt.Enabled = False

    '        'if the start menu is open, close it first.
    '        If pnlStart.Visible Then
    '            fbStart_Click(sender, e)
    '        End If

    '        AnimatePanel(pnlMain, False, 50)
    '        Application.DoEvents()

    '        myLoad.lblProgramData.Visible = False
    '        myLoad.lblVoice.Visible = False
    '        myLoad.lblWelcome.Visible = False
    '        myLoad.fbProgramData.Visible = False
    '        myLoad.fbVoice.Visible = False
    '        myLoad.TextButton1.ButtonText = ""
    '        myLoad.TextButton2.ButtonText = ""

    '        myLoad.lblOmega.Visible = True
    '        myLoad.lblStandby.Visible = True

    '        myLoad.ShowDialog()   'instead of doing showdialog() which would automatically wait until 
    '        'the standby screen was cleared, I use show() so that the speech recognition
    '        'code can continue to run.
    '        'Dim mythread As Threading.Thread
    '        'mythread = New Threading.Thread(AddressOf waitForLogon)
    '        'mythread.Start()
    '        waitForLogon()
    '    End Sub

    '    Private Sub waitForLogon()

    '        Do Until myLoad.Visible = False
    '            Application.DoEvents()
    '        Loop

    '        Application.DoEvents()

    '        Me.BringToFront()
    '        Me.Activate()
    '        LoadLCARS()
    '    End Sub

    '    Private Sub abBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abBack.Click
    '        ie.GoBack()
    '    End Sub

    '    Private Sub abForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abForward.Click
    '        ie.GoForward()
    '    End Sub

    '    Private Sub fbStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbStop.Click
    '        ie.Stop()
    '    End Sub

    '    Private Sub ie_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles ie.DocumentCompleted
    '        txtAddress.Text = ie.Url.AbsoluteUri
    '        scrollIndex = 0
    '        ie.Document.Window.ScrollTo(0, scrollIndex)
    '    End Sub

    '    Private Sub StartWinSockConnection()
    '        ' Must listen on correct port- must be same as port client wants to connect on.
    '        tcpListener.Start()
    '        Application.DoEvents()
    '        Do Until tcpListener.Pending = True
    '            Application.DoEvents()
    '        Loop

    '        Try
    '            'Accept the pending client connection and return             'a TcpClient initialized for communication. 
    '            Dim tcpClient As System.Net.Sockets.TcpClient = tcpListener.AcceptTcpClient()

    '            Do Until tcpClient.Connected = False
    '                Dim networkStream As System.Net.Sockets.NetworkStream = tcpClient.GetStream()
    '                ' Read the stream into a byte array
    '                If networkStream.DataAvailable Then
    '                    Dim bytes(tcpClient.ReceiveBufferSize) As Byte
    '                    networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
    '                    ' Return the data received from the client to the console.
    '                    Dim clientdata As String = System.Text.Encoding.ASCII.GetString(bytes)


    '                    clientdata = clientdata.Replace(Chr(0), "")


    '                    Select Case clientdata.ToLower
    '                        Case "close"
    '                            Exit Do
    '                        Case "openmycomp"
    '                            fbMyComp_Click(Me, New System.EventArgs)
    '                        Case "monitoroff"
    '                            TurnOff()
    '                        Case "monitoron"
    '                            TurnOn()
    '                        Case "disconnect"
    '                            Exit Do
    '                    End Select

    '                    'If clientdata <> "" Then
    '                    '    Dim responseString As String = "You sent: '" & clientdata & "'."
    '                    '    Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes(responseString)
    '                    '    networkStream.Write(sendBytes, 0, sendBytes.Length)
    '                    'End If

    '                    networkStream.Flush()
    '                    Application.DoEvents()

    '                End If
    '            Loop

    '            'The client disconnected, so...
    '            'Close TcpListener and TcpClient.
    '            tcpClient.Close()
    '            tcpListener.Stop()
    '        Catch ex As Exception
    '            'Save a log of the error in case it is a major problem that needs addressing
    '            LogErr(ex)

    '            'Show the error to the user
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub LogErr(ByRef ex As Exception, Optional ByVal specialInfo As String = "")

    '        Select Case ex.GetType.ToString
    '            Case "System.UnauthorizedAccessException"
    '                'Access denied - Don't log, not an application error.
    '            Case "System.IO.IOException"
    '                'An erro with a drive - Don't log, not an application error.
    '            Case Else
    '                'Save a log of the error in case it is a major problem that needs addressing
    '                Dim myTrace As New System.Diagnostics.StackTrace(ex, True)
    '                With myTrace.GetFrame(myTrace.FrameCount - 1)
    '                    Dim strLog As String = "Error occurred at " & .GetMethod.Name & " in " & System.IO.Path.GetFileName(.GetFileName) & vbNewLine
    '                    strLog += "Line " & .GetFileLineNumber & " Column " & .GetFileColumnNumber & vbNewLine
    '                    strLog += "Error Code: " & ex.GetType.ToString & vbNewLine & "Error message: " & ex.Message.ToString & vbNewLine & vbNewLine
    '                    strLog += specialInfo
    '                    If File.Exists(Application.StartupPath & "\ErrLog.txt") Then
    '                        FileOpen(1, Application.StartupPath & "\ErrLog.txt", OpenMode.Append)
    '                    Else
    '                        FileOpen(1, Application.StartupPath & "\ErrLog.txt", OpenMode.Output)
    '                    End If

    '                    PrintLine(1, strLog)
    '                    FileClose(1)
    '                End With
    '        End Select

    '    End Sub

    '    Sub TurnOff()
    '        SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2)
    '    End Sub

    '    Sub TurnOn()
    '        SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, -1)
    '    End Sub

    '    Private Sub fbSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If pnlSettings.Visible = False Then
    '            ClearMainBox()
    '            mainBoxSize = pnlMainBox.Bounds
    '            pnlMainBox.Size = Screen.PrimaryScreen.Bounds.Size
    '            pnlMainBox.Location = New Point(0, 0)

    '            cbSpeech.Lit = Settings.SpeechOn
    '            If cbSpeech.Lit Then
    '                cbSpeech.SideText = "ON"
    '            Else
    '                cbSpeech.SideText = "OFF"
    '            End If

    '            cbButtonBeep.Lit = Settings.ButtonBeep
    '            If cbButtonBeep.Lit Then
    '                cbButtonBeep.SideText = "ON"
    '            Else
    '                cbButtonBeep.SideText = "OFF"
    '            End If

    '            cbGestures.Lit = Settings.UseGestures
    '            If cbGestures.Lit Then
    '                cbGestures.SideText = "ON"
    '            Else
    '                cbGestures.SideText = "OFF"
    '            End If

    '            pnlSettings.Location = New Point(0, 0)
    '            pnlSettings.Size = pnlMainBox.Size
    '            pnlSettings.BringToFront()
    '            pnlMainBox.BringToFront()
    '            AnimatePanel(pnlSettings, True, 100)
    '        Else
    '            ClearMainBox()
    '        End If
    '    End Sub

    '    Private Sub sbApplySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbApplySettings.Click
    '        AnimatePanel(pnlSettings, False, 100)
    '        pnlMainBox.Bounds = mainBoxSize

    '        Settings.ButtonBeep = cbButtonBeep.Lit
    '        Settings.SpeechOn = cbSpeech.Lit
    '        Settings.UseGestures = cbGestures.Lit

    '        beginVoiceRecognition()


    '        If cbButtonBeep.Lit Then

    '            updateButtonBeep(Me, True)
    '            updateButtonBeep(myLoad, True)
    '        Else
    '            updateButtonBeep(Me, False)
    '            updateButtonBeep(myLoad, False)
    '        End If

    '        If cbGestures.Lit Then
    '            tmrGestures.Enabled = True
    '        Else
    '            tmrGestures.Enabled = False
    '        End If



    '        saveSettings()

    '    End Sub

    '    Private Sub updateButtonBeep(ByVal SearchControl As Control, ByVal enabled As Boolean)
    '        Dim myLcars As New LCARS.LCARSbuttonClass

    '        For Each myControl As Control In SearchControl.Controls
    '            If myControl.GetType.ToString.ToLower = "system.windows.forms.panel" Then
    '                updateButtonBeep(myControl, enabled)
    '            ElseIf Microsoft.VisualBasic.Left(myControl.GetType.ToString, 5) = "LCARS" Then
    '                With CType(myControl, LCARS.LCARSbuttonClass)
    '                    If .Clickable = True Then
    '                        .Beeping = enabled
    '                    End If
    '                End With
    '            End If
    '        Next
    '    End Sub


    '    Private Sub sbCancelRedAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancelRedAlert.Click
    '        CancelRedAlert()

    '    End Sub

    '    Private Sub cbSpeech_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSpeech.Click

    '        cbSpeech.Lit = Not cbSpeech.Lit
    '        If cbSpeech.Lit Then
    '            cbSpeech.SideText = "ON"
    '        Else
    '            cbSpeech.SideText = "OFF"
    '        End If
    '    End Sub

    '    Private Sub pnlMyComp_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMyComp.VisibleChanged
    '        'Try
    '        '    If pnlMyComp.Visible = False Then
    '        '        vGrammar.CmdSetRuleIdState(3, SpeechRuleState.SGDSInactive)
    '        '    End If
    '        'Catch
    '        'End Try

    '    End Sub

    '    Private Sub sbMyCompBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbMyCompBack.Click
    '        If BrowsedFolders.Count > 1 Then
    '            BrowsedFolders.Remove(BrowsedFolders.Count)
    '        End If
    '        If BrowsedFolders.Count <= 1 Then
    '            sbMyCompBack.Lit = False
    '            sbMyCompBack.Clickable = False
    '        End If

    '        UpdateMyComp(0, BrowsedFolders.Item(BrowsedFolders.Count))
    '        AnimatePanel(pnlMyComp, True)

    '        Dim myWindow As System.Windows.Forms.NativeWindow
    '        myWindow = New System.Windows.Forms.NativeWindow


    '    End Sub

    '    Private Sub fbMyDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyDocs.Click
    '        If pnlStart.Visible = True Then
    '            fbStart.doClick(sender, e)

    '            Do Until pnlStart.Visible = False
    '                Application.DoEvents()
    '            Loop
    '        End If


    '        pnlMyComp.Location = New Point(0, 0)
    '        pnlMyComp.Size = pnlMainBox.Size

    '        BrowsedFolders.Clear()

    '        scrollIndex = 0
    '        UpdateMyComp(scrollIndex, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))

    '        ClearMainBox()
    '        pnlMyComp.BringToFront()
    '        AnimatePanel(pnlMyComp, True)
    '        AnimatePanel(pnlMyCompOptions, True)
    '        curScrollObj.Name = "My Computer"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf myCompScroll)

    '    End Sub

    '    Private Sub fbMyPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyPictures.Click

    '        If pnlStart.Visible = True Then
    '            fbStart.doClick(sender, e)

    '            Do Until pnlStart.Visible = False
    '                Application.DoEvents()
    '            Loop
    '        End If

    '        pnlMyComp.Location = New Point(0, 0)
    '        pnlMyComp.Size = pnlMainBox.Size

    '        BrowsedFolders.Clear()

    '        scrollIndex = 0
    '        UpdateMyComp(scrollIndex, System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))

    '        ClearMainBox()
    '        pnlMyComp.BringToFront()
    '        AnimatePanel(pnlMyComp, True)
    '        AnimatePanel(pnlMyCompOptions, True)
    '        curScrollObj.Name = "My Computer"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf myCompScroll)

    '    End Sub

    '    Private Sub fbMyMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyMusic.Click

    '        If pnlStart.Visible = True Then
    '            fbStart.doClick(sender, e)

    '            Do Until pnlStart.Visible = False
    '                Application.DoEvents()
    '            Loop
    '        End If

    '        pnlMyComp.Location = New Point(0, 0)
    '        pnlMyComp.Size = pnlMainBox.Size

    '        BrowsedFolders.Clear()

    '        scrollIndex = 0
    '        UpdateMyComp(scrollIndex, System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))

    '        ClearMainBox()
    '        pnlMyComp.BringToFront()

    '        AnimatePanel(pnlMyComp, True)
    '        AnimatePanel(pnlMyCompOptions, True)
    '        curScrollObj.Name = "My Computer"
    '        curScrollObj.ScrollMethod = New scMethod(AddressOf myCompScroll)

    '    End Sub

    '    Private Sub fbMyNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyNetwork.Click
    '        'pnlMyComp.Location = New Point(0, 0)
    '        'pnlMyComp.Size = pnlMainBox.Size

    '        'BrowsedFolders.Clear()

    '        'UpdateMyComp(0, System.Environment.GetFolderPath(Environment.SpecialFolder.))

    '        'ClearMainBox()
    '        'pnlMyComp.BringToFront()
    '        'fbStart.doClick(sender, e)
    '        'AnimatePanel(pnlMyComp, True)
    '        'AnimatePanel(pnlMyCompOptions, True)

    '        '===========================================================
    '        'Need to use these:
    '        '===========================================================
    '        'Public Structure NETRESOURCE

    '        '    Dim dwScope As Integer

    '        '    Dim dwStructure As Integer

    '        '    Dim dwDisplayStructure As Integer

    '        '    Dim dwUsage As Integer

    '        '    Dim lpLocalName As String

    '        '    Dim lpRemoteName As String

    '        '    Dim lpComment As String

    '        '    Dim lpProvider As String

    '        'End Structure

    '        'Public Declare Function WNetOpenEnum Lib "mpr.dll" Alias "WNetOpenEnumA" (ByVal dwScope As Integer, ByVal dwStructure As Integer, ByVal dwUsage As Integer, ByVal lpNetResource As NETRESOURCE, ByVal lphEnum As Integer) As Integer
    '        'Public Declare Function WNetEnumResource Lib "mpr.dll" Alias "WNetEnumResourceA" (ByVal hEnum As Integer, ByVal lpcCount As Integer, ByVal lpBuffer As NETRESOURCE, ByVal lpBufferSize As Integer) As Integer

    '    End Sub

    '    Private Sub sbCancelSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancelSettings.Click
    '        AnimatePanel(pnlSettings, False, 100)
    '        pnlMainBox.Bounds = mainBoxSize
    '        pnlSettings.Visible = False

    '    End Sub

    '    Private Sub cbButtonBeep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbButtonBeep.Click

    '        cbButtonBeep.Lit = Not cbButtonBeep.Lit

    '        If cbButtonBeep.Lit Then
    '            cbButtonBeep.SideText = "ON"
    '        Else
    '            cbButtonBeep.SideText = "OFF"
    '        End If
    '    End Sub

    '    Private Sub fbAppClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        'Dim myButton As LCARS.Controls.FlatButton
    '        'myButton = CType(sender, LCARS.Controls.FlatButton)
    '        'PostMessage(Convert.ToInt32(myButton.Data), WM_CLOSE, 0, 0)
    '        'Threading.Thread.Sleep(500)
    '        'myButton.Parent.Parent.Dispose()
    '        'ClearMainBox()
    '    End Sub


    '    Private Sub cbGestures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGestures.Click

    '        cbGestures.Lit = Not cbGestures.Lit

    '        If cbGestures.Lit Then
    '            cbGestures.SideText = "ON"
    '        Else
    '            cbGestures.SideText = "OFF"
    '        End If
    '    End Sub

    '    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
    '        If Not curScrollObj.Name Is Nothing Then
    '            ScrollStartY = 0
    '            ScrollStartX = 0

    '            Dim scrollDist As Integer

    '            If e.Delta > 0 Then
    '                scrollDist -= 51
    '            Else
    '                scrollDist += 51
    '            End If

    '            If curScrollObj.Name.ToLower = "browser" Then
    '                scrollDist = scrollDist * -1
    '            End If

    '            curScrollObj.ScrollMethod.Invoke(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, 0, scrollDist, e.Delta))
    '        End If



    '    End Sub


    '    Private Sub happyQday()
    '        If doQ = True Then
    '            Dim myButton As LCARS.LCARSbuttonClass
    '            Dim intloop As Integer
    '            Dim tmpStr As String = ""


    '            For Each myControl As Control In pnlMain.Controls
    '                If Microsoft.VisualBasic.Left(myControl.GetType.ToString, 5) = "LCARS" Then
    '                    myButton = CType(myControl, LCARS.LCARSbuttonClass)
    '                    If myButton.ButtonText <> "" Then
    '                        tmpStr = ""
    '                        For intloop = 0 To myButton.ButtonText.Length - 1
    '                            tmpStr += "Q"
    '                        Next
    '                        myButton.q = myButton.ButtonText
    '                        myButton.ButtonText = tmpStr
    '                    End If
    '                End If
    '            Next
    '        End If
    '    End Sub

    '    Private Sub goAwayQ()
    '        doQ = False
    '        Dim myButton As LCARS.LCARSbuttonClass



    '        For Each myControl As Control In pnlMain.Controls
    '            If Microsoft.VisualBasic.Left(myControl.GetType.ToString, 5) = "LCARS" Then
    '                myButton = CType(myControl, LCARS.LCARSbuttonClass)
    '                If myButton.ButtonText <> "" Then
    '                    myButton.ButtonText = myButton.Q
    '                End If
    '            End If
    '        Next

    '    End Sub





    '    Private Sub StandardButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton8.Click



    '        scaleWidth = Me.Width / 640
    '        scaleHeight = Me.Height / 480

    '        'If scaleWidth > scaleHeight Then
    '        '    scaleControls(pnlMain, New SizeF(New PointF(scaleHeight, scaleHeight)))
    '        'Else
    '        '    scaleControls(pnlMain, New SizeF(New PointF(scaleWidth, scaleWidth)))
    '        'End If
    '        scaleControls(pnlMain, New SizeF(scaleHeight, scaleHeight))
    '        MsgBox(StandardButton8.Size.ToString)
    '    End Sub

    '    Private Sub scaleControls(ByVal container As Control, ByVal factor As SizeF, Optional ByVal SizeContainer As Boolean = False)
    '        Dim myFactor As SizeF = factor

    '        container.Visible = False

    '        For Each mycontrol As Control In container.Controls
    '            mycontrol.Scale(factor)
    '            If (mycontrol.Anchor And AnchorStyles.Top) > 0 And (mycontrol.Anchor And AnchorStyles.Bottom) > 0 Then
    '                factor.Height = 1
    '            End If
    '            If (mycontrol.Anchor And AnchorStyles.Left) > 0 And (mycontrol.Anchor And AnchorStyles.Right) > 0 Then
    '                factor.Width = 1
    '            End If
    '            If mycontrol.GetType Is GetType(LCARS.Controls.Elbow) Then
    '                With CType(mycontrol, LCARS.Controls.Elbow)
    '                    .ButtonWidth = .ButtonWidth * factor.Width
    '                    .ButtonHeight = .ButtonHeight * factor.Height
    '                End With
    '            End If

    '            If mycontrol.GetType.ToString.Substring(0, 5).ToLower = "lcars" Then
    '                With CType(mycontrol, LCARS.LCARSbuttonClass)
    '                    .ButtonTextHeight = .ButtonTextHeight * factor.Height
    '                End With

    '            End If
    '            factor = myFactor
    '        Next

    '        If SizeContainer = True Then
    '            If (container.Anchor And AnchorStyles.Top) > 0 And (container.Anchor And AnchorStyles.Bottom) > 0 Then
    '                factor.Height = 1
    '            End If
    '            If (container.Anchor And AnchorStyles.Left) > 0 And (container.Anchor And AnchorStyles.Right) > 0 Then
    '                factor.Width = 1
    '            End If
    '            container.Scale(factor)
    '        End If
    '        container.Visible = True
    '    End Sub

    '    Private Sub pnlBatt_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBatt.Paint

    '    End Sub

    '    Private Sub pnlBatt_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBatt.Resize

    '    End Sub

    '    Private Sub pnlBatt_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBatt.SizeChanged
    '        For Each myControl As Control In pnlBatt.Controls
    '            If myControl.GetType Is GetType(LCARS.Controls.Elbow) Then
    '                With CType(myControl, LCARS.Controls.Elbow)
    '                    .ButtonHeight = .ButtonHeight * scaleHeight
    '                    .ButtonWidth = .ButtonWidth * scaleWidth
    '                End With
    '            End If
    '        Next
    '    End Sub

    '    Private Sub tbClock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbClock.Click

    '        Dim intloop As Integer
    '        Dim command As String
    '        Dim action As String
    '        Dim desc As String
    '        Dim flags As Integer
    '        Dim cat As String

    '        FileOpen(1, "c:\commands.txt", OpenMode.Output)
    '        For intloop = 0 To vCommand.get_CountCommands(mainMenuID) - 1
    '            vCommand.GetCommand(mainMenuID, intloop, command, desc, cat, flags, action)
    '            PrintLine(1, command)
    '        Next
    '        FileClose(1)
    '    End Sub

    '    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.TextChanged

    '    End Sub
    'End Class

    '#Region " Comparer Classes "

    'Class DriveComparer

    '    Implements IComparer 'Implement the IComparer Interface 

    '    Overloads Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
    '        Dim a, b As LCARSmain.Form1.MyComputerItem

    '        a = CType(x, LCARSmain.Form1.MyComputerItem)
    '        b = CType(y, LCARSmain.Form1.MyComputerItem)

    '        If a.IsReady > b.IsReady Then
    '            Return 2
    '        ElseIf a.IsReady < b.IsReady Then
    '            Return -2
    '        Else
    '            If a.Name > b.Name Then
    '                Return 1
    '            ElseIf a.Name < b.Name Then
    '                Return -1
    '            Else
    '                Return 0
    '            End If
    '        End If

    '        'If x.id is bigger than y.id then x.id-y.id will be positive. 
    '        'And if y.id is bigger, then x.id-y.id will be negative
    '        'And finally if they are equal then x.id-y.id will equal zero.
    '    End Function
    'End Class

    'Class FileSystemInfoComparer

    '    Implements IComparer 'Implement the IComparer Interface 

    '    Overloads Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
    '        Dim a, b As FileSystemInfo

    '        a = CType(x, FileSystemInfo)
    '        b = CType(y, FileSystemInfo)

    '        If File.Exists(a.FullName) = False And File.Exists(b.FullName) Then
    '            Return -1

    '        ElseIf (File.Exists(a.FullName) And File.Exists(b.FullName)) Or (File.Exists(a.FullName) = False And File.Exists(b.FullName) = False) Then

    '            If Path.GetFileNameWithoutExtension(a.FullName) > Path.GetFileNameWithoutExtension(b.FullName) Then
    '                Return 1
    '            ElseIf a.FullName = b.FullName Then
    '                Return 0
    '            ElseIf a.FullName < b.FullName Then
    '                Return -1
    '            End If

    '        Else
    '            Return 1

    '        End If


    '        'If x.id is bigger than y.id then x.id-y.id will be positive. 
    '        'And if y.id is bigger, then x.id-y.id will be negative
    '        'And finally if they are equal then x.id-y.id will equal zero.
    '    End Function
    'End Class

    'Class TagComparer
    '    Implements IComparer 'Implement the IComparer Interface 

    '    Overloads Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
    '        Dim a, b As control

    '        a = CType(x, Control)
    '        b = CType(y, Control)

    '        If a.Tag > b.Tag Then
    '            Return 1
    '        ElseIf a.Tag = b.Tag Then
    '            Return 0
    '        ElseIf a.Tag < b.Tag Then
    '            Return -1
    '        End If
    '        'If x.id is bigger than y.id then x.id-y.id will be positive. 
    '        'And if y.id is bigger, then x.id-y.id will be negative
    '        'And finally if they are equal then x.id-y.id will equal zero.
    '    End Function
#End Region



    Private Sub fbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click


        If pnlStart.Visible = False Then
            fbBlock.Visible = False
            elbStart.Visible = True
            Application.DoEvents()
            pnlMainContainer.Width = Me.Width - 309
            pnlMainContainer.Left = 309
            pnlStart.BringToFront()
        Else
            elbStart.Visible = False
            fbBlock.Visible = True
            Application.DoEvents()
            pnlMainContainer.Width = Me.Width
            pnlMainContainer.Left = 0
        End If
        pnlMainBar_Resize(sender, e)
        pnlStart.Visible = Not pnlStart.Visible

    End Sub


    Private Sub fbProgBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbProgBack.Click
        modBusiness.ProgBack()
    End Sub

    Private Sub abProgsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsNext.Click
        modBusiness.nextProgPage()
    End Sub

    Private Sub abProgsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsBack.Click
        modBusiness.previousProgPage()
    End Sub






    Private Sub pnlMainContainer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainContainer.Resize
        pnlMainBar_Resize(sender, e)
    End Sub

    Private Sub pnlUserButtons_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton1.Click
        If Not pnlMainBar.Top = 0 Then
            pnlMainBar.Top = 0
            myClock.Visible = False
            pnlMainBar.Height = Me.Height
            ArrowButton1.ArrowDirection = LCARS.LCARSarrowDirection.Down
            modBusiness.myClock = fbClock
        Else
            pnlMainBar.Top = 130
            pnlMainBar.Height = Me.Height - 130
            myClock.Visible = True
            ArrowButton1.ArrowDirection = LCARS.LCARSarrowDirection.Up
            modBusiness.myClock = myClock
            fbClock.ButtonText = "X32"
        End If
    End Sub

    Private Sub fbMyPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myPictures.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)

    End Sub

    Private Sub fbMyMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myMusic.Click
        myStartMenu.doClick(sender, e)

    End Sub

    Private Sub fbMyNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyNetwork.Click
        'Dim myComp As New frmMyComp
        'myComp.curPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        'MsgBox(myComp.curPath )

    End Sub

    Private Sub fbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDesktop.Click
        Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        myStartMenu.doClick(sender, e)

    End Sub


    Private Sub pnlMainBar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.Resize
        If isInit = True Then
            Dim myRect As New Rectangle

            myRect.Location = New Point(119, 40)
            myRect.Size = New Size(pnlMainBar.Width - 127, pnlMainBar.Height - 48)

            If modBusiness.userButtonsShowing Then
                myRect.Width = (gridUserButtons.Left - pnlMain.Left) - 10
            Else
                myRect.Width = (pnlMainContainer.Width - pnlMain.Left - 10)
            End If

            pnlMain.Bounds = myRect

            UpdateRegion()

        End If

    End Sub

    Private Sub myDocuments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myDocuments.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)
    End Sub

    Private Sub myRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myRun.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)
    End Sub


    Private Sub fbWebBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbWebBrowser.Click
        If pnlStart.Visible Then
            myStartMenu.doClick(sender, e)
        End If
    End Sub

    Private Sub myVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myVideos.Click
        If pnlStart.Visible Then myStartMenu.doClick(New Object, New EventArgs)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen1
        End Get
    End Property
    'Private Sub myAlertListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myAlertListButton.Click
    '    If frmAlerts.Visible Then
    '        frmAlerts.Hide()
    '    Else
    '        frmAlerts.Show()
    '    End If
    'End Sub
End Class

