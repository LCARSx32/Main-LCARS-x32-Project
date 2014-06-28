Imports System.IO
Imports System.Runtime.InteropServices
Imports LCARS.x32

public Class modBusiness

#Region " Structures "

    Private Structure ExternalApp
        Dim hWnd As Integer
        Dim MainWindowText As String
    End Structure

    Public Structure UserButtonInfo
        Dim color As String
        Dim Name As String
        Dim Location As String
    End Structure

    Public Structure FormButtonMethods
        Dim StartMenu As String
        Dim MyComputer As String
        Dim Settings As String
        Dim Engineering As String
        Dim ModeSelect As String
    End Structure

#End Region

#Region " Global Variables "

#Region " Public Global Variables "

    'Common form components
    Public myForm As Form
    Public myMainBar As Panel
    Public myMainPanel As Panel
    Public ProgramsPanel As LCARS.Controls.WindowlessContainer
    'Public ProgramsButton As LCARS.LCARSbuttonClass
    'Public MyCompPanel As Panel
    Public UserButtonsPanel As LCARS.Controls.ButtonGrid
    Public myAppsPanel As Panel
    'Public UserButtonsListBox As ListBox
    'Public InstanceManager As IntPtr

    'Common Buttons
    Public myStartMenu As LCARS.LCARSbuttonClass
    Public myComputer As LCARS.LCARSbuttonClass
    Public mySettings As LCARS.LCARSbuttonClass
    Public myEngineering As LCARS.LCARSbuttonClass
    Public myModeSelect As LCARS.LCARSbuttonClass
    Public myDeactivate As LCARS.LCARSbuttonClass
    Public myAlert As LCARS.LCARSbuttonClass
    Public myDestruct As LCARS.LCARSbuttonClass
    Public myClock As Object
    Public myPhoto As LCARS.LCARSbuttonClass
    Public myWebBrowser As LCARS.LCARSbuttonClass
    Public myButtonManager As LCARS.LCARSbuttonClass
    Public myUserButtons As LCARS.LCARSbuttonClass
    Public myDocuments As LCARS.LCARSbuttonClass
    Public myPictures As LCARS.LCARSbuttonClass
    Public myVideos As LCARS.LCARSbuttonClass
    Public myMusic As LCARS.LCARSbuttonClass
    Public myBattery As Panel
    Public myTrayPanel As Panel
    Public myShowTrayButton As LCARS.LCARSbuttonClass
    Public myHideTrayButton As LCARS.Controls.ArrowButton
    Public myOSK As LCARS.Controls.FlatButton
    Public mySpeech As LCARS.Controls.FlatButton
    Public myHelp As LCARS.LCARSbuttonClass
    Public myRun As LCARS.LCARSbuttonClass
    Public myAlertListButton As LCARS.LCARSbuttonClass
    Public myProgramPagesDisplay As LCARS.LCARSbuttonClass

    Public adjustedBounds As Rectangle
    Public MyPrograms As Collection = New Collection
    Public myUserButtonCollection As New List(Of UserButtonInfo)
    Public mainTimer As New Timer
    Public ScreenIndex As Integer


    Public shellMode As Boolean = False
    Public progShowing As Boolean
    Public userButtonsShowing As Boolean

#End Region

#Region " Private Global Variables "

    'Program Pages
    Dim ProgDir(-1) As Integer
    Dim ProgPageSize As Integer
    Dim curProgPage As Integer = 1
    Dim pageCount As Integer
    Dim curProgIndex As Integer

    'External application management
    Dim myWindows(-1) As ExternalApp
    Dim WindowList(-1) As ExternalApp
    Dim excluded(-1) As IntPtr

    'Form Methods
    Dim myMethods As FormButtonMethods

    'Time Format
    Dim timeFormat As String = "h:mm:sstt"
    Dim dateFormat As String = "M/d/yyyy"

    'On Screen Keyboard (OSK)
    Dim OSKproc As New Process
    Dim isVisible As Boolean = False

#End Region

#End Region

    Private Function fEnumWindowsCallBack(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer
        Dim lReturn As Integer
        Dim lExStyle As Integer
        Dim bNoOwner As Boolean
        Dim sWindowText As String

        If IsWindowVisible(hwnd) Then
            If GetParent(hwnd) = 0 Then

                bNoOwner = (GetWindow(hwnd, GW_OWNER) = 0)
                lExStyle = GetWindowLong(hwnd, GWL_EXSTYLE)

                'If (((lExStyle And WS_EX_TOOLWINDOW) = 0) Or (lExStyle And WS_EX_APPWINDOW)) Or _
                '(((lExStyle And WS_EX_TOOLWINDOW) = 0) And ((lExStyle And WS_EX_APPWINDOW) = 0) And bNoOwner = True) Then
                'This if statement is from code found at http://msdntracker.blogspot.com/2008/03/list-currently-opened-windows-with.html
                If (((lExStyle And WS_EX_TOOLWINDOW) = 0) And bNoOwner) Or ((lExStyle And WS_EX_APPWINDOW) And Not bNoOwner) Then
                    Dim screen1, screen2 As String
                    screen1 = Screen.FromHandle(hwnd).DeviceName
                    screen1 = screen1.Substring(0, InStr(screen1, ControlChars.NullChar))

                    screen2 = Screen.FromHandle(myForm.Handle).DeviceName
                    screen2 = screen2.Substring(0, InStr(screen2, ControlChars.NullChar))

                    If screen1 = screen2 Then
                        '
                        ' Get the window's caption.
                        '
                        sWindowText = Space(256)
                        lReturn = GetWindowText(hwnd, sWindowText, Len(sWindowText))
                        If lReturn Then
                            '
                            ' Add it to our list.
                            '
                            sWindowText = Left(sWindowText, lReturn)

                            ReDim Preserve WindowList(WindowList.Length)
                            WindowList(WindowList.GetUpperBound(0)).MainWindowText = Trim(sWindowText)
                            WindowList(WindowList.GetUpperBound(0)).hWnd = hwnd

                        End If
                    End If
                End If

                sWindowText = Space(256)
                lReturn = GetWindowText(hwnd, sWindowText, Len(sWindowText))

            End If
            End If




            fEnumWindowsCallBack = True
    End Function

    Public Sub SetWallpaper(ByVal wall As Image)
        myDesktop.curDesktop(ScreenIndex).BackgroundImage = wall
    End Sub

    Public Sub setWallpaperSizeMode(ByVal sizemode As ImageLayout)
        myDesktop.curDesktop(ScreenIndex).BackgroundImageLayout = sizemode
    End Sub



    Public Sub myStartMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub myCompButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub mySettingsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mySettings As New frmSettings()
        MoveToScreen(Screen.FromHandle(myForm.Handle), mySettings.Handle)
        mySettings.Show()
        'Dim myProcess As New Process()
        'myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSsettings.exe"
        'myProcess.StartInfo.Arguments = "/" & myDesktop.Handle.ToString()
        'launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myEngineeringButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSengineering.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myModeSelectButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        cancelAlert = True
        Application.DoEvents()
        'Check that the images directory exists. If not, create it.
        If Not Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images") Then
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images")
        End If
        'TODO: Save screenshots by screen index
        'Save screenshot and show the selection form
        Dim screenImage As New Bitmap(myForm.Width, myForm.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenImage)
        g.CopyFromScreen(myForm.PointToScreen(New Point(0, 0)), New Point(0, 0), myForm.Size)
        Try
            screenImage.Save(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\" & myForm.Name.ToLower() & "_" & ScreenIndex & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            ' Save will throw an exception if the given path is not yet available for writing.
            ' Unfortunately, .Save takes its sweet time releasing the file, so if you try to
            ' call .Save on the same file within a few seconds, it throws an exception. There
            ' isn't a straightforward way to test if the file is in use, so just catch and
            ' ignore the exception for now.
            'MsgBox(ex.ToString())
        End Try
        SetParent(hTrayIcons, hTrayParent)
        Dim myChoice As New ScreenChooserDialog(ScreenIndex)
        MoveToScreen(Screen.FromHandle(myForm.Handle), myChoice.Handle)
        myChoice.Show()
    End Sub

    Public Sub myDeactivateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSshutdown.exe"
        myProcess.StartInfo.Arguments = "/" & myDesktop.Handle.ToString()
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSshutdown.exe", "/" & myDesktop.Handle.ToString)
    End Sub

    Public Sub myAlertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.WindowState = FormWindowState.Minimized
        If cancelAlert Then
            GeneralAlert(0)
        Else
            cancelAlert = True
        End If
    End Sub

    Public Sub myYellowAlertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.WindowState = FormWindowState.Minimized
        If cancelAlert Then
            GeneralAlert(1)
        Else
            cancelAlert = True
        End If
    End Sub

    Public Sub myDestructButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSdestruct.exe"
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSdestruct.exe")
    End Sub

    Public Sub myPhoto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSpic.exe"
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSpic.exe")
    End Sub

    Public Sub myWebBrowser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSWebBrowser.exe"
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSWebBrowser.exe")
    End Sub

    Public Sub myButtonManager_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myUserButtons As New frmManageButtons(Me)

        myUserButtons.Show()
    End Sub

    Public Sub myUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If UserButtonsPanel.Visible = True Then
            UserButtonsPanel.Visible = False
            myButtonManager.Visible = False
        Else
            UserButtonsPanel.Visible = True
            myButtonManager.Visible = True
        End If
        progShowing = ProgramsPanel.Visible
        userButtonsShowing = UserButtonsPanel.Visible
        myMainBar.Width -= 1
        myMainBar.Width += 1


    End Sub

    Public Sub myDocuments_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        ' myStartMenu.doClick(sender, e)
    End Sub

    Public Sub myPictures_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
    End Sub
    Public Sub myVideos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = GetMyVideosPath()
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSexplorer.exe", GetMyVideosPath())
    End Sub

    Public Sub myMusic_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
    End Sub

    Public Sub myShowTrayButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        modSettings.ShowTrayIcons(ScreenIndex) = True
        Dim myPlacement As New WINDOWPLACEMENT
        GetWindowPlacement(hTrayIcons, myPlacement)
        Dim myWidth As Integer = myPlacement.rcNormalPosition.Right_Renamed - myPlacement.rcNormalPosition.Left_Renamed

        myAppsPanel.Width -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width
        myTrayPanel.Left -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width

        myTrayPanel.Width = myWidth + myHideTrayButton.Width

        myShowTrayButton.Visible = False
        myHideTrayButton.Visible = True
        SetParent(hTrayIcons, myTrayPanel.Handle)

    End Sub

    Public Sub myHideTrayButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        modSettings.ShowTrayIcons(ScreenIndex) = False
        Dim mywidth As Integer = myShowTrayButton.Width - myTrayPanel.Width
        myTrayPanel.Width = myShowTrayButton.Width
        myTrayPanel.Left -= mywidth
        myAppsPanel.Width -= mywidth
        myHideTrayButton.Visible = False
        myShowTrayButton.Visible = True
        myShowTrayButton.BringToFront()
        SetParent(hTrayIcons, myIconSaver.Handle)
    End Sub

    Public Sub myOSK_Click(ByVal Sender As Object, ByVal e As System.EventArgs)
        If OSKproc.StartInfo.FileName = "" Then
            OSKproc = Process.Start(Application.StartupPath & "\OnScreenKeyboard.exe")
            isVisible = True
        ElseIf OSKproc.StartInfo.FileName <> "" And OSKproc.HasExited = True Then
            OSKproc = Process.Start(Application.StartupPath & "\OnScreenKeyboard.exe")
            isVisible = True
        Else
            If isVisible Then
                ShowWindow(OSKproc.MainWindowHandle, SW_HIDE)
                isVisible = False
            Else
                ShowWindow(OSKproc.MainWindowHandle, SW_SHOW)
                isVisible = True
            End If
        End If
    End Sub

    Public Sub mySpeech_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If console.Visible Then
            console.Hide()
        Else
            modSpeech.ShowConsole()
        End If
    End Sub

    Public Sub myHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\Lcarsx32 Manual.exe"
        myProcess.StartInfo.Arguments = Application.StartupPath & "\LCARS x32 Manual"
        launchProcessOnScreen(myProcess)
        'Process.Start(Application.StartupPath & "\Lcarsx32 Manual.exe", Application.StartupPath & "\LCARS x32 Manual")
    End Sub

    Public Sub myRun_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myRunDialog As New frmRunProgram
        MoveToScreen(Screen.FromHandle(myForm.Handle), myRunDialog.Handle)
        myRunDialog.Show()
    End Sub

    Public Sub myAlertListButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If frmAlerts.Visible Then
            frmAlerts.Hide()
        Else
            frmAlerts.Show()
        End If
    End Sub

    Public Sub init(ByRef curForm As Form)
        'When a mainscreen loads, it calls this sub to let LCARS x32 know
        'that it is now the mainscreen.  Since most of the functions of the
        'mainscreen are done through this module, it is imperitive that they
        'call this sub as soon as they load.
        setBusiness(Me, ScreenIndex)


        ReDim myWindows(-1)
        myForm = curForm

        AddHandler Microsoft.Win32.SystemEvents.DisplaySettingsChanged, AddressOf System_DisplayChanged

        'Set the form's extended style to "WS_EX_TOOLWINDOW" which allows it
        'to stay fullscreen instead of being resized by the working area.
        Dim currentStyle As Integer = GetWindowLong(myForm.Handle, -20)
        currentStyle = currentStyle Or (&H80)
        SetWindowLong(myForm.Handle, -20, currentStyle)

        'Set the various panels and buttons that are controlled by this module.
        'These panels and buttons behave exactly the same on each mainscreen.
        ProgramsPanel = myForm.Controls.Find("pnlPrograms", True)(0)
        'ProgramsButton = myForm.Controls.Find("fbPrograms", True)(0)
        myMainPanel = myForm.Controls.Find("pnlMain", True)(0)
        myMainBar = myForm.Controls.Find("pnlMainBar", True)(0)
        UserButtonsPanel = myForm.Controls.Find("gridUserButtons", True)(0)
        myAppsPanel = myForm.Controls.Find("pnlApps", True)(0)

        'Mainscreen Buttons:
        myStartMenu = myForm.Controls.Find("myStartMenu", True)(0)
        myComputer = myForm.Controls.Find("MyComp", True)(0)
        mySettings = myForm.Controls.Find("mySettings", True)(0)
        myEngineering = myForm.Controls.Find("myEngineering", True)(0)
        myModeSelect = myForm.Controls.Find("myModeSelect", True)(0)
        myDeactivate = myForm.Controls.Find("myDeactivate", True)(0)
        myAlert = myForm.Controls.Find("myAlert", True)(0)
        'myYellowAlert = myForm.Controls.Find("myYellowAlert", True)(0)
        myDestruct = myForm.Controls.Find("myDestruct", True)(0)
        myClock = myForm.Controls.Find("myClock", True)(0)
        myPhoto = myForm.Controls.Find("myPhoto", True)(0)
        myWebBrowser = myForm.Controls.Find("fbWebBrowser", True)(0)
        myButtonManager = myForm.Controls.Find("myButtonManager", True)(0)
        myUserButtons = myForm.Controls.Find("myUserButtons", True)(0)
        myDocuments = myForm.Controls.Find("myDocuments", True)(0)
        myPictures = myForm.Controls.Find("myPictures", True)(0)
        myVideos = myForm.Controls.Find("myVideos", True)(0)
        myMusic = myForm.Controls.Find("myMusic", True)(0)
        myBattery = myForm.Controls.Find("pnlBatt", True)(0)
        myTrayPanel = myForm.Controls.Find("pnlTray", True)(0)
        myShowTrayButton = myForm.Controls.Find("ShowTrayButton", True)(0)
        myHideTrayButton = myForm.Controls.Find("HideTrayButton", True)(0)
        myOSK = myForm.Controls.Find("myOSK", True)(0)
        mySpeech = myForm.Controls.Find("mySpeech", True)(0)
        myHelp = myForm.Controls.Find("myHelp", True)(0)
        myRun = myForm.Controls.Find("myRun", True)(0)
        myAlertListButton = myForm.Controls.Find("myAlertListButton", True)(0)
        myProgramPagesDisplay = myForm.Controls.Find("fbProgramPages", True)(0)

        If Listener Is Nothing OrElse Listener.State <> SpeechLib.SpeechRecoContextState.SRCS_Enabled Then
            mySpeech.Lit = False
        Else
            mySpeech.Lit = True
        End If
        'event handlers:
        AddHandler ProgramsPanel.Resize, AddressOf ProgramsPanel_Resize
        AddHandler myStartMenu.Click, AddressOf myStartMenu_Click
        AddHandler myComputer.Click, AddressOf myCompButton_Click
        AddHandler mySettings.Click, AddressOf mySettingsButton_Click
        AddHandler myEngineering.Click, AddressOf myEngineeringButton_Click
        AddHandler myModeSelect.Click, AddressOf myModeSelectButton_Click
        AddHandler myDeactivate.Click, AddressOf myDeactivateButton_Click
        AddHandler myAlert.Click, AddressOf myAlertButton_Click
        'AddHandler myYellowAlert.Click, AddressOf myYellowAlertButton_Click
        AddHandler myDestruct.Click, AddressOf myDestructButton_Click
        AddHandler myPhoto.Click, AddressOf myPhoto_Click
        AddHandler myWebBrowser.Click, AddressOf myWebBrowser_Click
        AddHandler myButtonManager.Click, AddressOf myButtonManager_Click
        AddHandler myUserButtons.Click, AddressOf myUserButtons_Click
        AddHandler myDocuments.Click, AddressOf myDocuments_Click
        AddHandler myPictures.Click, AddressOf myPictures_Click
        AddHandler myVideos.Click, AddressOf myVideos_Click
        AddHandler myMusic.Click, AddressOf myMusic_Click
        AddHandler myShowTrayButton.Click, AddressOf myShowTrayButton_Click
        AddHandler myHideTrayButton.Click, AddressOf myHideTrayButton_Click
        AddHandler myOSK.Click, AddressOf myOSK_Click
        AddHandler mySpeech.Click, AddressOf mySpeech_Click
        AddHandler myHelp.Click, AddressOf myHelp_Click
        AddHandler myForm.FormClosing, AddressOf myForm_Closing
        AddHandler myRun.Click, AddressOf myRun_Click
        AddHandler myAlertListButton.Click, AddressOf myAlertListButton_Click
        ReDim ProgDir(-1)

        MyPrograms.Clear()
        MyPrograms = GetAllPrograms
        'myProgGrid.ControlSize = New Size(myProgGrid.Width, 25)
        loadProgList()


        myUserButtonCollection.Clear()
        loadUserButtons()
        loadLanguage()


        Dim DoBeeping As Boolean = Boolean.Parse(GetSetting("LCARS x32", "Application", "ButtonBeep", "False"))

        LCARS.SetBeeping(myForm, DoBeeping)

        AddHandler mainTimer.Tick, AddressOf mainTimer_Tick


        'load Mainscreen Settings:
        Dim AutoHideMode As Integer = modSettings.AutoHide(ScreenIndex)
        SetAutoHide(AutoHideMode, ScreenIndex)
        If modSettings.ShowTrayIcons(ScreenIndex) = True Then
            myShowTrayButton_Click(New Object, New EventArgs)
        End If


    End Sub

    Public Sub loadLanguage()
        Try
            Dim strinput As String = ""
            Dim split() As String
            Dim filename As String = GetSetting("LCARS X32", "Application", "LangFile", "Standard.lng")

            FileOpen(1, Application.StartupPath() & "\lang\" & filename, OpenMode.Input)
            Input(1, strinput)
            If strinput.ToLower = "lcars x32 language file" Then
                Do Until EOF(1)
                    Input(1, strinput)
                    If strinput.Contains("=") Then
                        split = strinput.Split("=")
                        'Makes sure that one bad line doesn't stop loading the whole language file.
                        If myForm.Controls.Find(split(0).Trim, True).Length > 0 Then
                            CType(myForm.Controls.Find(split(0).Trim, True)(0), LCARS.LCARSbuttonClass).ButtonText = split(1).Trim.Replace(Chr(34), "")
                        End If
                    End If
                Loop
            Else
                MsgBox("The file '" & filename & "' is not a valid LCARS x32 language file." _
                       & vbNewLine & vbNewLine & "LCARS x32 will use the default button text instead.")
            End If
            FileClose(1)

        Catch ex As Exception
            MsgBox("error" & vbNewLine & ex.ToString())
            FileClose(1)
        End Try

    End Sub

    Private Sub System_DisplayChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        myForm.Bounds = Screen.AllScreens(ScreenIndex).Bounds
        'TODO: Move to frmStartup
        'TODO: Handle changes to number of displays
        myDesktop.pnlBack.Bounds = Screen.AllScreens(ScreenIndex).Bounds

    End Sub

    Private Sub mainTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim found As Boolean = False
        Dim intloop As Integer
        Dim battInfo As PowerStatus = SystemInformation.PowerStatus
        Static battLevel As Single = 1

        'Check for and hide startbar, ect. Code from Alan - Causing problems with message boxes
        If GetSetting("LCARS X32", "Application", "HideExplorer", "FALSE") = "TRUE" Then
            Try

                Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
                SetWindowPos(intReturn, 0, 0, 0, 0, 0, SetWindowPosFlags.HideWindow)

            Catch ex As Exception
            End Try
        End If


        'Set the clock
        '-------------------------
        'Get the time and date format
        Dim newText As String = ""
        If (GetSetting("LCARS x32", "Application", "Stardate", "TRUE") <> "TRUE") Then
            Try
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Control Panel\International")
                timeFormat = myReg.GetValue("sTimeFormat", "h:mm:sstt")
                dateFormat = myReg.GetValue("sShortDate", "M/d/yyyy")
            Catch ex As Exception
                timeFormat = "h:mm:sstt"
                dateFormat = "M/d/yyyy"
            End Try

            newText = Format(Now, timeFormat) & " " & Format(Now.Date, dateFormat)

        Else
            newText = LCARS.Stardate.getStardate(Now)
        End If
        If myClock.GetType Is GetType(Label) Then
            If Not newText = myClock.text Then
                myClock.text = newText
            End If

        Else

            If Not newText = myClock.ButtonText Then
                myClock.ButtonText = newText
            End If
        End If

        '-------------------------


        'if we are on battery power, update the battery's status
        '-------------------------
        myBattery.Controls("lblBatt").Text = battInfo.BatteryLifePercent * 100 & "%"

        If battInfo.PowerLineStatus = PowerLineStatus.Offline Then
            myBattery.Controls("lblPowerSource").Text = "AUXILIARY"
        Else
            myBattery.Controls("lblPowerSource").Text = "PRIMARY"
        End If

        Dim newBattLevel As Single

        Select Case battInfo.BatteryLifePercent
            Case 0 To 0.1
                newBattLevel = 0
            Case 0.1 To 0.1
                newBattLevel = 0.1
            Case 0.11 To 0.2
                newBattLevel = 0.2
            Case 0.21 To 0.3
                newBattLevel = 0.3
            Case 0.31 To 0.4
                newBattLevel = 0.4
            Case 0.41 To 0.5
                newBattLevel = 0.5
            Case 0.51 To 0.6
                newBattLevel = 0.6
            Case 0.61 To 0.7
                newBattLevel = 0.7
            Case 0.71 To 0.8
                newBattLevel = 0.8
            Case 0.81 To 0.9
                newBattLevel = 0.9
            Case 0.91 To 1
                newBattLevel = 1
        End Select
        If newBattLevel <> battLevel Then
            battLevel = newBattLevel

            Dim b1 As Control = myBattery.Controls("fbBatt1")
            Dim b2 As Control = myBattery.Controls("fbBatt2")
            Dim b3 As Control = myBattery.Controls("fbBatt3")
            Dim b4 As Control = myBattery.Controls("fbBatt4")
            Dim b5 As Control = myBattery.Controls("fbBatt5")
            Dim b6 As Control = myBattery.Controls("fbBatt6")
            Dim b7 As Control = myBattery.Controls("fbBatt7")
            Dim b8 As Control = myBattery.Controls("fbBatt8")
            Dim b9 As Control = myBattery.Controls("fbBatt9")
            Dim b10 As Control = myBattery.Controls("fbBatt10")

            Select Case battLevel
                Case 1
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = True
                    b7.Visible = True
                    b8.Visible = True
                    b9.Visible = True
                    b10.Visible = True
                Case 0.9
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = True
                    b7.Visible = True
                    b8.Visible = True
                    b9.Visible = True
                    b10.Visible = False
                Case 0.8
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = True
                    b7.Visible = True
                    b8.Visible = True
                    b9.Visible = False
                    b10.Visible = False
                Case 0.7
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = True
                    b7.Visible = True
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.6
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = True
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.5
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = True
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.4
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = True
                    b5.Visible = False
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.3
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = True
                    b4.Visible = False
                    b5.Visible = False
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.2
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = False
                    b4.Visible = False
                    b5.Visible = False
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0.1
                    b1.Visible = True
                    b2.Visible = True
                    b3.Visible = False
                    b4.Visible = False
                    b5.Visible = False
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                Case 0
                    b1.Visible = False
                    b2.Visible = False
                    b3.Visible = False
                    b4.Visible = False
                    b5.Visible = False
                    b6.Visible = False
                    b7.Visible = False
                    b8.Visible = False
                    b9.Visible = False
                    b10.Visible = False
                    GeneralAlert(1)
            End Select
        End If


        ReDim myWindows(-1)

        ReDim WindowList(-1)

        adjustedBounds = New Rectangle(myMainBar.PointToScreen(myMainPanel.Location).X, myMainBar.PointToScreen(myMainPanel.Location).Y, myMainPanel.Width, myMainPanel.Height)

        If Not adjustedBounds = Screen.AllScreens(ScreenIndex).WorkingArea Then
            'The working area has changed, alert the linked windows (if there are any).
            If LinkedWindows.Count > 0 Then
                Dim myRectData As New COPYDATASTRUCT
                myRectData.dwData = 100
                myRectData.cdData = Marshal.SizeOf(GetType(Rectangle))

                Dim myPtr As IntPtr = Marshal.AllocCoTaskMem(myRectData.cdData)
                Marshal.StructureToPtr(adjustedBounds, myPtr, False)

                myRectData.lpData = myPtr

                Dim MyCopyData As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(COPYDATASTRUCT)))
                Marshal.StructureToPtr(myRectData, MyCopyData, False)
                'Do not use SendDataToLinkedWindows; it uses PostMessage, not SendMessage
                For Each targetHandle As IntPtr In LinkedWindows
                    'Compare working areas because no equality operator for screens
                    If Screen.FromHandle(targetHandle).WorkingArea = Screen.FromHandle(myForm.Handle).WorkingArea Then
                        Dim res As Integer = SendMessage(targetHandle, WM_COPYDATA, myDesktop.Handle, MyCopyData)
                    End If
                Next
            End If
            resizeWorkingArea(adjustedBounds.X, adjustedBounds.Y, adjustedBounds.Width, adjustedBounds.Height)
            'myDesktop.curDesktop(ScreenIndex).Bounds = Screen.AllScreens(ScreenIndex).WorkingArea
        End If

        If Not myDesktop.curDesktop(ScreenIndex).Size = adjustedBounds.Size Then
            updateDesktopBounds(ScreenIndex)
        End If

        'Deal with resizing the tray icon panel if necessary
        If myHideTrayButton.Visible = True Then
            Dim myPlacement As New WINDOWPLACEMENT
            GetWindowPlacement(hTrayIcons, myPlacement)
            Dim myWidth As Integer = myPlacement.rcNormalPosition.Right_Renamed - myPlacement.rcNormalPosition.Left_Renamed
            If myWidth <> myWidth + myHideTrayButton.Width Then
                myAppsPanel.Width -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width
                myTrayPanel.Left -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width

                myTrayPanel.Width = myWidth + myHideTrayButton.Width
            End If
        End If



        'Refresh the taskbar if necessary
        'find all the windows
        EnumWindows(New EnumCallBack(AddressOf fEnumWindowsCallBack), IntPtr.Zero)

        For Each curWindow As ExternalApp In WindowList

            For Each myWindow As ExternalApp In myWindows
                If myWindow.hWnd = curWindow.hWnd Then
                    myWindow.MainWindowText = curWindow.MainWindowText
                    found = True
                    Exit For
                End If
            Next

            If found = False Then
                ReDim Preserve myWindows(myWindows.Length)
                myWindows(myWindows.GetUpperBound(0)) = curWindow
            End If

            found = False

        Next



        'refresh the taskbar
        If myAppsPanel.Controls.Count <> myWindows.Length * 2 + 2 Then

            Dim beeping As Boolean = Boolean.Parse(GetSetting("LCARS x32", "Application", "ButtonBeep", "False"))

            myAppsPanel.Controls.Clear()

            Dim leftArrow As New LCARS.Controls.ArrowButton
            Dim rightArrow As New LCARS.Controls.ArrowButton

            leftArrow.ArrowDirection = LCARS.LCARSarrowDirection.Left
            rightArrow.ArrowDirection = LCARS.LCARSarrowDirection.Right

            leftArrow.Size = New Point(25, 25)
            rightArrow.Size = leftArrow.Size

            leftArrow.Location = New Point(0, 0)
            rightArrow.Anchor = AnchorStyles.Right



            leftArrow.Lit = False
            rightArrow.Lit = False

            leftArrow.Name = "leftArrow"
            rightArrow.Name = "rightArrow"

            myAppsPanel.Controls.Add(leftArrow)

            AddHandler leftArrow.Click, AddressOf leftArrow_Click
            AddHandler rightArrow.Click, AddressOf rightArrow_Click

            For intloop = 0 To myWindows.GetUpperBound(0)
                Dim myButton As New LCARS.Controls.HalfPillButton
                Dim myCloseButton As New LCARS.Controls.FlatButton
                myCloseButton.Size = New Point(20, 25)
                myCloseButton.ButtonText = "X"
                myCloseButton.ButtonTextAlign = ContentAlignment.MiddleCenter
                myCloseButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                myCloseButton.Left = (((myAppsPanel.Controls.Count - 1) \ 2) * 134) + 31
                myCloseButton.Top = 0
                myCloseButton.Data = myWindows(intloop).hWnd
                myCloseButton.Beeping = beeping
                myCloseButton.Tag = (intloop + 6).ToString
                myAppsPanel.Controls.Add(myCloseButton)

                AddHandler myCloseButton.Click, AddressOf CloseButton_Click


                myButton.ButtonText = myWindows(intloop).MainWindowText
                myButton.Size = New Point(100, 25)
                myButton.Left = (((myAppsPanel.Controls.Count - 1) \ 2) * 134) + 56
                myButton.Top = 0
                myButton.Beeping = False
                myButton.Data = myWindows(intloop).hWnd
                myButton.Beeping = beeping
                myButton.ButtonTextAlign = ContentAlignment.TopLeft
                If getWindowState(myWindows(intloop).hWnd) = WindowStates.MINIMIZED Then
                    myButton.Lit = False
                Else
                    myButton.Lit = True
                End If

                myButton.Tag = (intloop + 6).ToString

                myAppsPanel.Controls.Add(myButton)

                AddHandler myButton.Click, AddressOf AppsButton_Click
            Next
            rightArrow.Location = New Point(myAppsPanel.Width - 31, 0)
            myAppsPanel.Controls.Add(rightArrow)
            rightArrow.BringToFront()
            myAppsPanel.Tag = (intloop + 6).ToString
        Else
            For Each curWindow As ExternalApp In myWindows
                For Each myButton As LCARS.LCARSbuttonClass In myAppsPanel.Controls
                    If myButton.Data = curWindow.hWnd Then

                        If getWindowState(curWindow.hWnd) = WindowStates.MINIMIZED Then
                            If myButton.Lit Then
                                myButton.Lit = False
                            End If
                            'If myButton.RedAlert <> LCARS.LCARSalert.Normal Then
                            'myButton.RedAlert = LCARS.LCARSalert.Normal
                            'End If
                        Else
                            If myButton.Lit = False Then
                                myButton.Lit = True
                            End If
                        End If
                        'If myButton.Data = GetTopWindow() Then
                        'If myButton.Color <> LCARS.LCARScolorStyles.FunctionOffline Then
                        'If myButton.RedAlert <> LCARS.LCARSalert.White Then
                        'myButton.RedAlert = LCARS.LCARSalert.White
                        'End If
                        'End If
                        'Else
                        'If myButton.RedAlert <> LCARS.LCARSalert.Normal Then
                        'myButton.RedAlert = LCARS.LCARSalert.Normal
                        'End If
                        'End If

                        If Not (myButton.ButtonText = curWindow.MainWindowText.ToUpper Or myButton.ButtonText = "X") Then
                            myButton.ButtonText = curWindow.MainWindowText
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    'Moves the taskbar buttons to the right
    Private Sub rightArrow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each myControl As LCARS.LCARSbuttonClass In myAppsPanel.Controls
            If Not (myControl.Name.ToLower = "leftarrow" Or myControl.Name.ToLower = "rightarrow") Then
                myControl.Left -= 134
            End If
        Next
    End Sub
    'Moves the taskbar buttons to the left
    Private Sub leftArrow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each myControl As LCARS.LCARSbuttonClass In myAppsPanel.Controls
            If Not (myControl.Name.ToLower = "leftarrow" Or myControl.Name.ToLower = "rightarrow") Then
                myControl.Left += 134
            End If
        Next
    End Sub
    'Red "X" next to the taskbar button
    Private Sub CloseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CloseWindow(CInt(CType(sender, LCARS.LCARSbuttonClass).Data))
    End Sub
    'Taskbar button
    Private Sub AppsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myButton As LCARS.LCARSbuttonClass = CType(sender, LCARS.LCARSbuttonClass)
        Dim myHandle As Integer = myButton.Data
        Dim curFrontWindow As Integer = GetTopWindow()

        If curFrontWindow = myHandle Then
            If getWindowState(myHandle) <> WindowStates.MINIMIZED Then
                myButton.Data2 = getWindowState(myHandle)
                SetWindowState(myHandle, WindowStates.MINIMIZED)
            Else
                If Not myButton.Data2 Is Nothing Then
                    SetWindowState(myHandle, myButton.Data2)
                Else
                    SetWindowState(myHandle, WindowStates.NORMAL)
                End If
            End If
        Else
            If getWindowState(myHandle) = WindowStates.MINIMIZED Then
                If Not myButton.Data2 Is Nothing Then
                    SetWindowState(myHandle, myButton.Data2)
                Else
                    SetWindowState(myHandle, WindowStates.NORMAL)
                End If
            End If
            SetTopWindow(myHandle)
        End If
    End Sub

    Public Sub loadUserButtons()

        If Not UserButtonsPanel Is Nothing Then
            If File.Exists(Application.StartupPath & "\UserButtons.ini") Then
                Dim strinput As String = ""
                Dim intCount As Integer = 0
                FileOpen(1, Application.StartupPath & "\UserButtons.ini", OpenMode.Input, OpenAccess.Read)
                Do Until EOF(1)
                    Input(1, strinput)

                    If strinput <> "" Then
                        Dim buttonName As String = strinput
                        Input(1, strinput)
                        SaveSetting("LCARS x32", "UserButtons", intCount.ToString("D2") & buttonName, strinput)
                        intCount += 1
                    End If
                Loop
                FileClose(1)
                Kill(Application.StartupPath & "\UserButtons.ini")
            End If
            Dim buttonTop As Integer = 0
            Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            UserButtonsPanel.Clear()
            myUserButtonCollection.Clear()

            myReg = myReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\UserButtons", False)

            If Not myReg Is Nothing Then
                For intloop As Integer = 0 To myReg.ValueCount - 1

                    Dim mybutton As New LCARS.LightweightControls.LCFlatButton
                    Dim myUserButtonInfo As New UserButtonInfo


                    mybutton.Beeping = False
                    mybutton.Color = LCARS.LCARScolorStyles.MiscFunction

                    AddHandler mybutton.Click, AddressOf myfile_click

                    If IsNumeric(myReg.GetValueNames(intloop).Substring(0, 2)) Then
                        mybutton.Text = myReg.GetValueNames(intloop).Substring(2)
                    Else
                        mybutton.Text = myReg.GetValueNames(intloop)
                    End If

                    myUserButtonInfo.Name = mybutton.Text
                    'myUserButtonInfo.color = Convert.ToInt32(myReg.GetValueNames(intloop).Substring(0, 2))
                    mybutton.Data = myReg.GetValue(myReg.GetValueNames(intloop))
                    myUserButtonInfo.Location = mybutton.Data

                    UserButtonsPanel.Add(mybutton)
                    'UserButtonsListBox.Items.Add(mybutton.ButtonText)

                    AddUserButton(myUserButtonInfo, True)
                Next
            End If
        End If

    End Sub

    Public Sub AddUserButton(ByVal button As UserButtonInfo, Optional ByVal DontSave As Boolean = False)
        myUserButtonCollection.Add(button)
        If DontSave = False Then
            SaveUserButtons()
            loadUserButtons()
        End If

    End Sub

    Public Sub RemoveUserButton(ByVal index As Integer)
        myUserButtonCollection.RemoveAt(index)
        SaveUserButtons()
        loadUserButtons()
    End Sub

    Public Sub EditUserButton(ByVal button As UserButtonInfo, ByVal index As Integer)
        'myUserButtonCollection.remove(index)
        'myUserButtonCollection.add(button, index)
        myUserButtonCollection(index) = button
        SaveUserButtons()
        loadUserButtons()
    End Sub

    Public Sub SaveUserButtons()
        Try
            'remove current userbuttons
            Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
            myReg = myReg.OpenSubKey("Software\VB and VBA Program Settings\LCARS x32\UserButtons", True)
            Dim myValues() As String = myReg.GetValueNames()

            For Each myValue As String In myValues
                myReg.DeleteValue(myValue)
            Next
        Catch ex As Exception

        End Try

        Dim intCount As Integer = 0
        Dim index As Integer
        For index = 0 To myUserButtonCollection.Count - 1
            Dim myobject As Object = myUserButtonCollection(index)
            Dim myButton As UserButtonInfo
            myButton = CType(myobject, UserButtonInfo)
            Try
                SaveSetting("LCARS x32", "UserButtons", intCount.ToString("D2") & myButton.Name, myButton.Location)
            Catch ex As Exception
                'MsgBox(ex.ToString())
            End Try
            intCount += 1
        Next
    End Sub

    Private Sub UserButtonsPanel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ProgramsPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        If myForm.WindowState <> FormWindowState.Minimized Then
            Dim myPage As Integer

            ProgPageSize = ProgramsPanel.Height \ 25
            myPage = (curProgIndex \ ProgPageSize) + 1
            loadProgList() '(myPage * ProgPageSize) - (ProgPageSize - 1))
        End If
    End Sub

    'Private Sub loadProgList() '(Optional ByVal index As Integer = 1)
    '    Dim intloop As Integer
    '    'Dim itemCount As Integer = 0
    '    '  Dim visibility As Boolean = True
    '    Dim myDir As Collection

    '    'Dim pageMax As Integer
    '    'curProgIndex = index

    '    myDir = MyPrograms
    '    'ProgPageSize = ProgramsPanel.Height \ 30

    '    For intloop = 0 To ProgDir.GetUpperBound(0)
    '        myDir = myDir(ProgDir(intloop)).subItems
    '    Next

    '    ' visibility = ProgramsPanel.Visible

    '    'If ProgramsPanel.Visible = True Then
    '    '    ProgramsPanel.Visible = False
    '    'End If

    '    'ProgramsPanel.Controls.Clear()
    '    '  ProgramsPanel.Visible = visibility

    '    'pageCount = Int(myDir.Count / ProgPageSize)

    '    'If myDir.Count Mod ProgPageSize > 0 Then
    '    '    pageCount += 1
    '    'End If

    '    'curProgPage = (index \ ProgPageSize) + 1

    '    'RaiseEvent programsPageDataChanged("PAGES " & curProgPage & " of " & pageCount)


    '    'pageMax = ProgPageSize + (index - 1)

    '    'If pageMax > myDir.Count Then
    '    '    pageMax = myDir.Count
    '    'End If

    '    For intloop = 1 To myDir.Count
    '        If myDir(intloop).GetType Is GetType(DirectoryStartItem) Then
    '            With CType(myDir(intloop), DirectoryStartItem)
    '                Dim myButton As New LCARS.LightweightControls.LCComplexButton 'LCARS.Controls.ComplexButton
    '                'myButton.Width = ProgramsPanel.Width
    '                'myButton.Height = 25
    '                'myButton.Left = 0
    '                myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
    '                myButton.Text = .Name
    '                myButton.SideText = .subItems.Count
    '                myButton.TextHeight = 14
    '                myButton.TextAlign = ContentAlignment.BottomRight
    '                myButton.Data = intloop
    '                'myButton.Top = itemCount * 30
    '                'myButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
    '                '                 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '                'myButton.Data = intloop
    '                myButton.Beeping = False
    '                'myButton.Tag = ((pageMax - index) - (intloop - index)).ToString
    '                myProgGrid.Add(myButton)
    '                AddHandler myButton.Click, AddressOf myDir_click
    '                'itemCount += 1
    '            End With
    '        Else
    '            With CType(myDir(intloop), FileStartItem)
    '                Dim myButton As New LCARS.LightweightControls.LCComplexButton 'LCARS.Controls.StandardButton
    '                'myButton.Width = ProgramsPanel.Width
    '                'myButton.Height = 25
    '                'myButton.Left = 0
    '                myButton.Color = LCARS.LCARScolorStyles.MiscFunction
    '                myButton.Text = Path.GetFileNameWithoutExtension(.Name)
    '                myButton.Data = .Link.Executable
    '                'myButton.Top = itemCount * 30
    '                myButton.Beeping = False
    '                'myButton.Tag = ((pageMax - index) - (intloop - index)).ToString
    '                myProgGrid.Add(myButton)
    '                AddHandler myButton.Click, AddressOf myfile_click
    '                'itemCount += 1
    '            End With
    '        End If
    '    Next
    '    'ProgramsPanel.Tag = (pageMax - index).ToString

    'End Sub
    Private Sub loadProgList(Optional ByVal index As Integer = 1)
        Dim intloop As Integer
        Dim itemCount As Integer = 0
        '  Dim visibility As Boolean = True
        Dim myDir As Collection

        Dim pageMax As Integer
        curProgIndex = index

        myDir = MyPrograms
        ProgPageSize = ProgramsPanel.Height \ 30
        For intloop = 0 To ProgDir.GetUpperBound(0)
            myDir = myDir(ProgDir(intloop)).subItems
        Next
        ProgramsPanel.Clear()
        '  ProgramsPanel.Visible = visibility

        pageCount = Int(myDir.Count / ProgPageSize)

        If myDir.Count Mod ProgPageSize > 0 Then
            pageCount += 1
        End If

        curProgPage = (index \ ProgPageSize) + 1

        myProgramPagesDisplay.Text = "PAGES " & curProgPage & " of " & pageCount


        pageMax = ProgPageSize + (index - 1)

        If pageMax > myDir.Count Then
            pageMax = myDir.Count
        End If

        For intloop = index To pageMax
            If myDir(intloop).GetType Is GetType(DirectoryStartItem) Then
                With CType(myDir(intloop), DirectoryStartItem)
                    Dim myButton As New LCARS.LightweightControls.LCComplexButton
                    myButton.Width = ProgramsPanel.Width
                    myButton.Height = 25
                    myButton.Left = 0
                    myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                    myButton.Text = .Name
                    myButton.SideText = .subItems.Count
                    myButton.TextHeight = 14
                    myButton.TextAlign = ContentAlignment.BottomRight
                    myButton.Data = intloop
                    myButton.Top = itemCount * 30
                    'myButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    '                 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                    myButton.Beeping = False
                    myButton.Data2 = ((pageMax - index) - (intloop - index)).ToString
                    ProgramsPanel.Add(myButton)
                    AddHandler myButton.Click, AddressOf myDir_click
                    itemCount += 1
                End With
            Else
                With CType(myDir(intloop), FileStartItem)
                    Dim myButton As New LCARS.LightweightControls.LCStandardButton
                    myButton.Width = ProgramsPanel.Width
                    myButton.Height = 25
                    myButton.Left = 0
                    myButton.Color = LCARS.LCARScolorStyles.MiscFunction
                    myButton.Text = Path.GetFileNameWithoutExtension(.Name)
                    myButton.Data = .Link.Executable
                    myButton.Top = itemCount * 30
                    myButton.Beeping = False
                    myButton.Data2 = ((pageMax - index) - (intloop - index)).ToString
                    ProgramsPanel.Add(myButton)
                    AddHandler myButton.Click, AddressOf myfile_click
                    itemCount += 1
                End With
            End If
        Next
        ProgramsPanel.Tag = (pageMax - index).ToString

    End Sub

    Public Sub nextProgPage()
        If curProgPage < pageCount Then
            curProgPage += 1
            loadProgList((curProgPage * ProgPageSize) - (ProgPageSize - 1))
        Else
            Beep()
        End If
    End Sub

    Public Sub previousProgPage()
        If curProgPage > 1 Then
            curProgPage -= 1
            loadProgList((curProgPage * ProgPageSize) - (ProgPageSize - 1))
        Else
            Beep()
        End If
    End Sub


    'Used for programs in start menu and in Personal Programs (userbuttons)
    Private Sub myfile_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ProgramsPanel.Visible Then
            myStartMenu.doClick(sender, e)
        End If
        If UserButtonsPanel.Visible Then
            myUserButtons.doClick(sender, e)
        End If
        Application.DoEvents()
        Try
            If Path.GetExtension(sender.data.ToString.ToLower) = ".lnk" Then

                Dim myProcess As New System.Diagnostics.Process
                myProcess.StartInfo.FileName = sender.data
                launchProcessOnScreen(myProcess)

            Else
                If File.Exists(sender.data) Then
                    'The command string is an absolute path.
                    Try
                        Dim myprocess As New Process
                        myprocess.StartInfo.FileName = sender.data
                        myprocess.StartInfo.WorkingDirectory = Path.GetDirectoryName(sender.data)
                        launchProcessOnScreen(myprocess)
                    Catch ex As Exception
                        GoTo Retry 'Yes, I know. If you have a better way, go for it.
                    End Try
                Else
Retry:
                    'The command will be interpreted as an absolute path, followed by arguments
                    Try
                        Dim myProcess As New Process()
                        If (sender.data.Substring(0, 1) = """") Then
                            Dim splitIndex As Integer = sender.data.Substring(1).IndexOf("""") + 2
                            myProcess.StartInfo.FileName = sender.data.Substring(0, splitIndex)
                            myProcess.StartInfo.Arguments = sender.data.Substring(splitIndex + 1)
                            myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                        Else
                            myProcess.StartInfo.FileName = sender.data.Split(" ")(0)
                            myProcess.StartInfo.Arguments = sender.data.Substring(myProcess.StartInfo.FileName.Length + 1)
                            myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                        End If
                        launchProcessOnScreen(myProcess)
                    Catch ex As Exception
                        'Throw it to shell and see what happens.
                        Try
                            Dim myID As Integer
                            myID = Shell(sender.data, AppWinStyle.NormalFocus)
                            Dim myprocess As Process = Process.GetProcessById(myID)
                            Do Until myprocess.MainWindowHandle <> 0
                                If Now.Subtract(myprocess.StartTime) > New TimeSpan(0, 0, 15) Then
                                    Exit Do
                                Else
                                    myprocess = Process.GetProcessById(myID)
                                    Application.DoEvents()
                                End If
                            Loop
                            MoveToScreen(Screen.FromHandle(myForm.Handle), myprocess.MainWindowHandle)
                        Catch ex2 As Exception
                            'Throw it to Process.Start and hope for the best
                            Try
                                Dim myProcess As Process = Process.Start(sender.data)
                                Dim myID As Integer = myProcess.Id
                                Do Until myProcess.MainWindowHandle <> 0
                                    If Now.Subtract(myProcess.StartTime) > New TimeSpan(0, 0, 15) Then
                                        Exit Do
                                    Else
                                        myProcess = Process.GetProcessById(myID)
                                        Application.DoEvents()
                                    End If
                                Loop
                                MoveToScreen(Screen.FromHandle(myForm.Handle), myProcess.MainWindowHandle)
                            Catch ex3 As Exception
                                MsgBox("Error: " & vbNewLine & vbNewLine & ex3.Message)
                            End Try
                        End Try
                    End Try
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

            Try
                Dim myID As Integer
                myID = Shell(sender.data, AppWinStyle.NormalFocus)
                Dim myprocess As Process = Process.GetProcessById(myID)
                MoveToScreen(Screen.FromHandle(myForm.Handle), myprocess.MainWindowHandle)
            Catch ex2 As Exception
                MsgBox("Error: " & vbNewLine & vbNewLine & ex2.Message)
            End Try
        End Try
    End Sub

    Public Sub launchProcessOnScreen(ByVal myProcess As Process)
        myProcess.Start()
        Dim myID As Integer = myProcess.Id

        Do Until myProcess.MainWindowHandle <> 0
            If Now.Subtract(myProcess.StartTime) > New TimeSpan(0, 0, 15) Then
                Exit Do
            Else
                myProcess = Process.GetProcessById(myID)
                Application.DoEvents()
            End If
        Loop

        MoveToScreen(Screen.FromHandle(myForm.Handle), myProcess.MainWindowHandle)

    End Sub


    Private Sub MoveToScreen(ByVal myScreen As Screen, ByVal hWnd As IntPtr)
        Dim myPlacement As New WINDOWPLACEMENT
        Dim isMax As Boolean = False

        myPlacement.Length = Marshal.SizeOf(myPlacement)

        GetWindowPlacement(hWnd, myPlacement)

        myPlacement.ptMaxPosition.X = myForm.Left
        myPlacement.ptMaxPosition.Y = myForm.Top


        myPlacement.ptMinPosition.X = myForm.Location.X


        myPlacement.rcNormalPosition.Right_Renamed -= myPlacement.rcNormalPosition.Left_Renamed - myForm.Left
        myPlacement.rcNormalPosition.Bottom_Renamed -= myPlacement.rcNormalPosition.Top_Renamed - myForm.Top
        myPlacement.rcNormalPosition.Left_Renamed = myForm.Location.X
        myPlacement.rcNormalPosition.Top_Renamed = myForm.Location.Y

        If myPlacement.ShowCmd = 3 Then
            isMax = True
            myPlacement.ShowCmd = 1
        End If

        SetWindowPlacement(hWnd, myPlacement)

        If isMax Then
            myPlacement.ShowCmd = 3
            SetWindowPlacement(hWnd, myPlacement)

        End If
    End Sub

    Private Sub myDir_click(ByVal sender As Object, ByVal e As System.EventArgs)
        ReDim Preserve ProgDir(ProgDir.Length)
        ProgDir(ProgDir.GetUpperBound(0)) = sender.data
        loadProgList()
    End Sub

    Public Sub ProgBack()
        If ProgDir.GetUpperBound(0) > -1 Then
            ReDim Preserve ProgDir(ProgDir.GetUpperBound(0) - 1)
            loadProgList()
        Else
            Beep()
        End If
    End Sub

    Public Sub myForm_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If Not modCommon.closing Then
            e.Cancel = True
            myDeactivate.doClick(sender, e)
        End If
    End Sub

    '    Private Sub myFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim index As Integer = CType(sender, LCARS.LCARSbuttonClass).Data
    '        Dim myItem As programList.FileStartItem
    '        Dim myAppPanel As New lcarsAppPanel.lcarsAppPanel
    '        Dim setParentResult As Integer
    '        Dim myProcess() As Process
    '        Dim myParser As New MSIparser
    '        Dim result As String


    '        ' 'Dim myShortcut As IWshRuntimeLibrary.IWshShortcut
    '        ' 'Dim myShell As New IWshRuntimeLibrary.WshShell
    '        myAppPanel.Anchor = 15
    '        myAppPanel.Location = New Point(0, 0)

    '        ' fbStart_Click(sender, e)

    '        myItem = CType(curItem(index), programList.FileStartItem)

    '        Dim shell As New IWshRuntimeLibrary.IWshShell_Class
    '        Dim myShortcut As IWshRuntimeLibrary.IWshShortcut


    '        result = myParser.ParseShortcut(myItem.Link.Executable)

    '        If result Is Nothing Then
    '            myShortcut = shell.CreateShortcut(myItem.Link.Executable)
    '            result = myShortcut.TargetPath
    '        End If

    '        Dim myStartInfo As ProcessStartInfo = New ProcessStartInfo(result)
    '        myStartInfo.WindowStyle = ProcessWindowStyle.Normal
    '        Process.Start(myStartInfo)

    '        ''Do Until myProcess.MainWindowTitle <> ""
    '        ''    Application.DoEvents()
    '        ''Loop
    '        myProcess = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(result))

    'tryAgain:
    '        Do Until myProcess.GetUpperBound(0) > -1
    '            myProcess = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(result))
    '            Application.DoEvents()
    '        Loop

    '        If myProcess(0).MainWindowHandle.ToInt32 = 0 Then
    '            ReDim myProcess(-1)
    '            GoTo tryAgain
    '        End If

    '        Dim myHandle As Integer = myProcess(0).MainWindowHandle.ToInt32

    '        Do Until setParentResult > 0
    '            ''  ShowWindow(myProcess(0).MainWindowHandle, SW_MINIMIZE)
    '            Dim currentStyle As Integer = GetWindowLong(myProcess(0).MainWindowHandle, GWL_STYLE)
    '            currentStyle = currentStyle And Not (WS_DLGFRAME)
    '            Application.DoEvents()
    '            SetWindowLong(myProcess(0).MainWindowHandle, GWL_STYLE, currentStyle)
    '            Application.DoEvents()
    '            setParentResult = SetParent(myProcess(0).MainWindowHandle, myAppPanel.AppWindowHandle).ToInt32
    '            Application.DoEvents()
    '            If setParentResult = 0 Then
    '                Dim err As Integer
    '                err = Marshal.GetLastWin32Error
    '            End If
    '            Application.DoEvents()
    '        Loop
    '        Application.DoEvents()
    '        ShowWindow(myProcess(0).MainWindowHandle, SW_MAXIMIZE)

    '        With myAppPanel
    '            .ApplicationTitle = myProcess(0).MainWindowTitle.ToUpper
    '            .WindowHandle = myProcess(0).MainWindowHandle.ToInt32
    '            .ApplicationID = myProcess(0).Id
    '            pnlMainBox.Controls.Add(myAppPanel)
    '            .Size = pnlMainBox.Size
    '            pnlMainBox.Visible = True
    '            .BringToFront()
    '        End With

    '        pnlAppOptions.Visible = True
    '        pnlAppOptions.BringToFront()




    '        subList.Clear()
    '        ''elbProgsTop.Clickable = False
    '        ''elbProgsTop.Lit = False
    '        ''elbProgsBottom.Clickable = False
    '        ''elbProgsBottom.Lit = False


    '        ''curItem = myItems

    '        ''FlatButton30.ButtonText = curItem.Count
    '        ''scrollIndex = 1
    '        ''AnimatePanel(pnlPrograms, True)

    '    End Sub
End Class
