Imports System.IO
Imports System.Runtime.InteropServices
Imports LCARS.x32

public Class modBusiness

#Region " Structures "
    Public Structure UserButtonInfo
        Dim color As String
        Dim Name As String
        Dim Location As String
    End Structure
#End Region

#Region " Global Variables "

#Region " Public Global Variables "

    'Common form components
    Public myForm As Form
    Public myMainPanel As Panel
    Public ProgramsPanel As LCARS.Controls.WindowlessContainer
    Public UserButtonsPanel As LCARS.Controls.ButtonGrid
    Public myAppsPanel As Panel

    'Common Buttons
    Public myStartMenu As LCARS.LCARSbuttonClass
    Public myComputer As LCARS.LCARSbuttonClass
    Public mySettings As LCARS.LCARSbuttonClass
    Public myEngineering As LCARS.LCARSbuttonClass
    Public myModeSelect As LCARS.LCARSbuttonClass
    Public myDeactivate As LCARS.LCARSbuttonClass
    Public myAlert As LCARS.LCARSbuttonClass
    Public myDestruct As LCARS.LCARSbuttonClass
    Public myClock As Control
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
    Public bars() As LCARS.LCARSbuttonClass
    Public myBattPercent As Control
    Public myPowerSource As Control
    Public myProgsUp As LCARS.LCARSbuttonClass
    Public myProgsBack As LCARS.LCARSbuttonClass
    Public myProgsNext As LCARS.LCARSbuttonClass

    Public MyPrograms As DirectoryStartItem
    Public myUserButtonCollection As New List(Of UserButtonInfo)
    Public WithEvents tmrAutohide As New Timer()
    Public ScreenIndex As Integer

    Public leftArrow As LCARS.Controls.ArrowButton
    Public rightArrow As LCARS.Controls.ArrowButton

    Public isInit As Boolean = False

#End Region

#Region " Private Global Variables "

    'Program Pages
    Dim ProgDir As New List(Of Integer)
    Dim ProgPageSize As Integer
    Dim curProgPage As Integer = 1
    Dim pageCount As Integer
    Dim curProgIndex As Integer

    'External application management
    Dim windowMap As New Dictionary(Of ExternalApp, TaskbarItem)()
    Dim taskbarList As New List(Of TaskbarItem)()
    Dim taskbarOffset As Integer = 0

    'On Screen Keyboard (OSK)
    Dim OSKproc As New Process
    Dim isVisible As Boolean = False

    'Autohide
    Dim autohide As IAutohide.AutoHideModes
    Dim hideCount As Integer = 0
#End Region

#End Region

    Public Sub New(ByVal screenIndex As Integer)
        Me.ScreenIndex = screenIndex
    End Sub

    Public Sub ShutdownScreen()
        tmrAutohide.Stop()
        isInit = False
        Application.DoEvents()
        If Not myForm Is Nothing Then
            DeregisterAlertForm(myForm)
            myForm.Dispose()
        End If
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
        MoveToScreen(mySettings.Handle)
        mySettings.Show()
    End Sub

    Public Sub myEngineeringButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSengineering.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myModeSelectButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Check that the images directory exists. If not, create it.
        If Not Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images") Then
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images")
        End If
        'Save screenshot and show the selection form
        Dim screenImage As New Bitmap(myForm.Width, myForm.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenImage)
        g.CopyFromScreen(myForm.PointToScreen(New Point(0, 0)), New Point(0, 0), myForm.Size)
        Try
            screenImage.Save(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\" & myForm.Name.ToLower() & "_" & ScreenIndex & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            MsgBox("Error saving image for interface " & myForm.Name & " on screen " & ScreenIndex & ".")
        End Try
        SetParent(hTrayIcons, hTrayParent)
        Dim myChoice As New ScreenChooserDialog(ScreenIndex)
        MoveToScreen(myChoice.Handle)
        myChoice.Show()
    End Sub

    Public Sub myDeactivateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSshutdown.exe"
        myProcess.StartInfo.Arguments = "/" & myDesktop.Handle.ToString()
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myAlertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If AlertActive Then
            CancelAlert()
        Else
            GeneralAlert(0)
        End If
    End Sub

    Public Sub myYellowAlertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If AlertActive Then
            CancelAlert()
        Else
            GeneralAlert(1)
        End If
    End Sub

    Public Sub myDestructButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSdestruct.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myPhoto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSpic.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myWebBrowser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSWebBrowser.exe"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myButtonManager_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Static myUserButtons As New frmManageButtons(Me)
        If myUserButtons.IsDisposed Then
            myUserButtons = New frmManageButtons(Me)
        End If
        myUserButtons.Show()
    End Sub

    Public Sub myUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UserButtonsPanel.Visible = Not UserButtonsPanel.Visible
        myButtonManager.Visible = UserButtonsPanel.Visible
    End Sub

    Public Sub myDocuments_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myPictures_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        launchProcessOnScreen(myProcess)
    End Sub
    Public Sub myVideos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = GetMyVideosPath()
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myMusic_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\LCARSexplorer.exe"
        myProcess.StartInfo.Arguments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
        launchProcessOnScreen(myProcess)
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
            If MonitorFromWindow(myForm.Handle, MONITOR_DEFAULTTONEAREST) = MonitorFromWindow(console.Handle, MONITOR_DEFAULTTONEAREST) Then
                console.Hide()
            Else
                MoveToScreen(console.Handle)
            End If
        Else
            modSpeech.ShowConsole()
            MoveToScreen(console.Handle)
        End If
    End Sub

    Public Sub myHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath & "\Lcarsx32 Manual.exe"
        myProcess.StartInfo.Arguments = Application.StartupPath & "\LCARS x32 Manual"
        launchProcessOnScreen(myProcess)
    End Sub

    Public Sub myRun_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myRunDialog As New frmRunProgram
        MoveToScreen(myRunDialog.Handle)
        myRunDialog.Show()
    End Sub

    Public Sub myAlertListButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If frmAlerts.Visible Then
            frmAlerts.Hide()
        Else
            frmAlerts.Show()
        End If
    End Sub

    Private Sub myForm_Load(ByVal sender As Object, ByVal e As EventArgs)
        myForm.Bounds = Screen.AllScreens(ScreenIndex).Bounds
        myForm.Show()
        isInit = True
        UpdateRegion()
        initCommonComponents(Me)
    End Sub

    Public Sub init(ByRef curForm As Form)
        'When a mainscreen loads, it calls this sub to let LCARS x32 know
        'that it is now the mainscreen.  Since most of the functions of the
        'mainscreen are done through this module, it is imperitive that they
        'call this sub as soon as they load.

        myForm = curForm

        'Set the form's extended style to "WS_EX_TOOLWINDOW" which allows it
        'to stay fullscreen instead of being resized by the working area.
        Dim currentStyle As Integer = GetWindowLong_Safe(myForm.Handle, GWL_EXSTYLE)
        currentStyle = currentStyle Or (WS_EX_TOOLWINDOW)
        SetWindowLong_Safe(myForm.Handle, GWL_EXSTYLE, currentStyle)

        'Set the various panels and buttons that are controlled by this module.
        'These panels and buttons behave exactly the same on each mainscreen.
        ProgramsPanel = myForm.Controls.Find("pnlPrograms", True)(0)
        myMainPanel = myForm.Controls.Find("pnlMain", True)(0)
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
        bars = New LCARS.LCARSbuttonClass(9) { _
            myBattery.Controls("fbBatt1"), _
            myBattery.Controls("fbBatt2"), _
            myBattery.Controls("fbBatt3"), _
            myBattery.Controls("fbBatt4"), _
            myBattery.Controls("fbBatt5"), _
            myBattery.Controls("fbBatt6"), _
            myBattery.Controls("fbBatt7"), _
            myBattery.Controls("fbBatt8"), _
            myBattery.Controls("fbBatt9"), _
            myBattery.Controls("fbBatt10")}
        myBattPercent = myBattery.Controls("lblBatt")
        myPowerSource = myBattery.Controls("lblPowerSource")
        myProgsUp = myForm.Controls.Find("myProgsUp", True)(0)
        myProgsBack = myForm.Controls.Find("myProgsBack", True)(0)
        myProgsNext = myForm.Controls.Find("myProgsNext", True)(0)

        'event handlers:
        AddHandler myForm.Load, AddressOf myForm_Load
        AddHandler ProgramsPanel.Resize, AddressOf ProgramsPanel_Resize
        AddHandler myMainPanel.Resize, AddressOf myMainPanel_Resize
        AddHandler myStartMenu.Click, AddressOf myStartMenu_Click
        AddHandler myComputer.Click, AddressOf myCompButton_Click
        AddHandler mySettings.Click, AddressOf mySettingsButton_Click
        AddHandler myEngineering.Click, AddressOf myEngineeringButton_Click
        AddHandler myModeSelect.Click, AddressOf myModeSelectButton_Click
        AddHandler myDeactivate.Click, AddressOf myDeactivateButton_Click
        AddHandler myAlert.Click, AddressOf myAlertButton_Click
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
        AddHandler myForm.MouseWheel, AddressOf myform_MouseScroll
        AddHandler myProgsUp.Click, AddressOf ProgBack
        AddHandler myProgsBack.Click, AddressOf previousProgPage
        AddHandler myProgsNext.Click, AddressOf nextProgPage

        mySpeech.Lit = modSpeech.SpeechEnabled

        setDoubleBuffered(myClock)

        MyPrograms = GetAllPrograms
        loadProgList()

        'Create arrows for window list
        leftArrow = New LCARS.Controls.ArrowButton()
        leftArrow.ArrowDirection = LCARS.LCARSarrowDirection.Left
        leftArrow.Size = New Point(25, 25)
        leftArrow.Location = New Point(0, 0)
        leftArrow.Lit = False
        leftArrow.Name = "leftArrow"
        rightArrow = New LCARS.Controls.ArrowButton()
        AddHandler leftArrow.Click, AddressOf leftArrow_Click
        myAppsPanel.Controls.Add(leftArrow)
        rightArrow.ArrowDirection = LCARS.LCARSarrowDirection.Right
        rightArrow.Size = leftArrow.Size
        rightArrow.Anchor = AnchorStyles.Right
        rightArrow.Lit = False
        rightArrow.Name = "rightArrow"
        rightArrow.Location = New Point(myAppsPanel.Width - rightArrow.Width, 0)
        AddHandler rightArrow.Click, AddressOf rightArrow_Click
        myAppsPanel.Controls.Add(rightArrow)

        windowMap.Clear()
        taskbarList.Clear()
        taskbarOffset = 0

        myUserButtonCollection.Clear()
        loadUserButtons()
        loadLanguage()

        LCARS.SetBeeping(myForm, modSettings.ButtonBeep)
        RegisterAlertForm(myForm)

        'load Mainscreen Settings:
        tmrAutohide.Interval = 100
        Dim AutoHideMode As Integer = modSettings.AutoHide(ScreenIndex)
        SetAutoHide(AutoHideMode)
        If modSettings.ShowTrayIcons(ScreenIndex) = True Then
            myShowTrayButton_Click(New Object, New EventArgs)
        End If
    End Sub

    Public Sub loadLanguage()
        Try
            Dim strinput As String = ""
            Dim split() As String
            Dim filename As String = modSettings.LanguageFileName(ScreenIndex)

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

#Region " Tray Icon Handling "
    Public Sub UpdateTray()
        'Deal with resizing the tray icon panel if necessary
        Dim myPlacement As New WINDOWPLACEMENT
        GetWindowPlacement(hTrayIcons, myPlacement)
        Dim myWidth As Integer = myPlacement.rcNormalPosition.Right - myPlacement.rcNormalPosition.Left
        If myWidth <> myWidth + myHideTrayButton.Width Then
            myAppsPanel.Width -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width
            myTrayPanel.Left -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width

            myTrayPanel.Width = myWidth + myHideTrayButton.Width
        End If
    End Sub

    Public Sub myShowTrayButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GetTray(Me)
        modSettings.ShowTrayIcons(ScreenIndex) = True
        Dim myPlacement As New WINDOWPLACEMENT
        GetWindowPlacement(hTrayIcons, myPlacement)
        Dim myWidth As Integer = myPlacement.rcNormalPosition.Right - myPlacement.rcNormalPosition.Left

        myAppsPanel.Width -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width
        myTrayPanel.Left -= (myWidth + myHideTrayButton.Width) - myTrayPanel.Width

        myTrayPanel.Width = myWidth + myHideTrayButton.Width

        myShowTrayButton.Visible = False
        myHideTrayButton.Visible = True
        SetParent(hTrayIcons, myTrayPanel.Handle)
    End Sub

    Public Sub myHideTrayButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        modSettings.ShowTrayIcons(ScreenIndex) = False
        ReturnTray(Me)
        Dim mywidth As Integer = myShowTrayButton.Width - myTrayPanel.Width
        myTrayPanel.Width = myShowTrayButton.Width
        myTrayPanel.Left -= mywidth
        myAppsPanel.Width -= mywidth
        myHideTrayButton.Visible = False
        myShowTrayButton.Visible = True
        myShowTrayButton.BringToFront()
        SetParent(hTrayIcons, myIconSaver.Handle)
    End Sub
#End Region

#Region " Taskbar buttons "
    Public Sub AddWindow(ByVal window As ExternalApp)
        Dim newItem As New TaskbarItem(window, Me, taskbarList.Count)
        newItem.Offset = taskbarOffset
        taskbarList.Add(newItem)
        windowMap.Add(window, newItem)
    End Sub

    Public Sub RemoveWindow(ByVal window As ExternalApp)
        Dim oldItem As TaskbarItem = windowMap(window)
        windowMap.Remove(window)
        For i As Integer = oldItem.Index + 1 To taskbarList.Count - 1
            taskbarList(i).Index = i - 1
        Next
        taskbarList.RemoveAt(oldItem.Index)
        oldItem.Remove()
    End Sub

    Public Sub UpdateWindow(ByVal window As ExternalApp, ByVal flags As WindowUpdateFlags)
        windowMap(window).Update(flags)
    End Sub

    'Moves the taskbar buttons to the right
    Private Sub rightArrow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        taskbarOffset += 1
        For Each myTaskbarItem As TaskbarItem In taskbarList
            myTaskbarItem.Offset = taskbarOffset
        Next
    End Sub

    'Moves the taskbar buttons to the left
    Private Sub leftArrow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        taskbarOffset -= 1
        For Each myTaskbarItem As TaskbarItem In taskbarList
            myTaskbarItem.Offset = taskbarOffset
        Next
    End Sub

#End Region

    Public Sub loadUserButtons()

        If Not UserButtonsPanel Is Nothing Then
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

#Region " Start Menu Handlers "
    Private Sub ProgramsPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        If myForm.WindowState <> FormWindowState.Minimized Then
            loadProgList(curProgIndex)
        End If
    End Sub

    Private Sub loadProgList(Optional ByVal index As Integer = 0)
        Dim itemCount As Integer = 0
        Dim myDir As DirectoryStartItem
        Dim pageMax As Integer

        ProgPageSize = ProgramsPanel.Height \ 30
        index = index - (index Mod ProgPageSize)
        curProgIndex = index

        myDir = MyPrograms
        For Each myindex As Integer In ProgDir
            myDir = myDir.subItems(myindex)
        Next
        ProgramsPanel.Clear()

        pageCount = Int(myDir.subItems.Count / ProgPageSize)

        If myDir.subItems.Count Mod ProgPageSize > 0 Then
            pageCount += 1
        End If

        curProgPage = (index \ ProgPageSize) + 1

        myProgramPagesDisplay.Text = "PAGES " & curProgPage & " of " & pageCount


        pageMax = ProgPageSize + (index - 1)

        If pageMax > myDir.subItems.Count - 1 Then
            pageMax = myDir.subItems.Count - 1
        End If

        For intloop As Integer = index To pageMax
            If myDir.subItems(intloop).GetType Is GetType(DirectoryStartItem) Then
                With CType(myDir.subItems(intloop), DirectoryStartItem)
                    Dim myButton As New LCARS.LightweightControls.LCComplexButton
                    myButton.HoldDraw = True
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
                    myButton.Beeping = False
                    myButton.Data2 = ((pageMax - index) - (intloop - index)).ToString
                    ProgramsPanel.Add(myButton)
                    myButton.HoldDraw = False
                    AddHandler myButton.Click, AddressOf myDir_click
                    itemCount += 1
                End With
            Else
                With CType(myDir.subItems(intloop), FileStartItem)
                    Dim myButton As New LCARS.LightweightControls.LCStandardButton
                    myButton.HoldDraw = True
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
                    myButton.HoldDraw = False
                    AddHandler myButton.Click, AddressOf startItem_click
                    itemCount += 1
                End With
            End If
        Next
        ProgramsPanel.Tag = (pageMax - index).ToString

        'Update buttons
        myProgsNext.Lit = curProgPage < pageCount
        myProgsBack.Lit = curProgPage > 1
        myProgsUp.Lit = ProgDir.Count > 0

    End Sub

    Public Sub nextProgPage()
        If curProgPage < pageCount Then
            curProgPage += 1
            loadProgList((curProgPage * ProgPageSize) - (ProgPageSize - 1))
        End If
    End Sub

    Public Sub previousProgPage()
        If curProgPage > 1 Then
            curProgPage -= 1
            loadProgList((curProgPage * ProgPageSize) - (ProgPageSize - 1))
        End If
    End Sub

    Public Sub ProgBack()
        If ProgDir.Count > 0 Then
            Dim index As Integer = ProgDir(ProgDir.Count - 1)
            ProgDir.RemoveAt(ProgDir.Count - 1)
            loadProgList(index)
        End If
    End Sub

    Private Sub myDir_click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProgDir.Add(sender.data)
        loadProgList()
    End Sub

    Private Sub startItem_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ProgramsPanel.Visible Then myStartMenu.doClick(sender, e)
        Application.DoEvents()
        Dim myprocess As New System.Diagnostics.Process()
        myprocess.StartInfo.FileName = CType(sender, LCARS.LightweightControls.LCFlatButton).Data
        launchProcessOnScreen(myprocess)
    End Sub
#End Region

    'Used for buttons in Personal Programs (userbuttons)
    Private Sub myfile_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If UserButtonsPanel.Visible Then
            myUserButtons.doClick(sender, e)
        End If
        Application.DoEvents()
        Dim cmdLine As String = CType(CType(sender, LCARS.LightweightControls.LCFlatButton).Data, String).Trim()
        Dim myprocess As New Process()
        If File.Exists(cmdLine) Then
            'The command string is an absolute path.
            myprocess.StartInfo.FileName = sender.data
            myprocess.StartInfo.WorkingDirectory = Path.GetDirectoryName(sender.data)
            launchProcessOnScreen(myprocess)
        Else
            'The command will be interpreted as a command followed by arguments
            Try
                If (sender.data.Substring(0, 1) = """") Then
                    Dim splitIndex As Integer = sender.data.Substring(1).IndexOf("""") + 2
                    myprocess.StartInfo.FileName = sender.data.Substring(0, splitIndex)
                    myprocess.StartInfo.Arguments = sender.data.Substring(splitIndex + 1)
                Else
                    myprocess.StartInfo.FileName = sender.data.Split(" ")(0)
                    myprocess.StartInfo.Arguments = sender.data.Substring(myprocess.StartInfo.FileName.Length + 1)
                End If
                'If full path specified, set working directory to containing folder
                If File.Exists(myprocess.StartInfo.FileName) Then
                    myprocess.StartInfo.WorkingDirectory = Path.GetDirectoryName(myprocess.StartInfo.FileName)
                End If
                launchProcessOnScreen(myprocess)
            Catch ex As Exception
                Debug.Print("Failed to interpret command line")
                'Throw it to shell and see what happens.
                Try
                    Dim myID As Integer
                    myID = Shell(sender.data, AppWinStyle.NormalFocus)
                    myprocess = Process.GetProcessById(myID)
                    launchProcessOnScreen(myprocess, False)
                Catch ex2 As ArgumentException
                    'Process already exited before we could get it.
                Catch ex2 As FileNotFoundException
                    MsgBox("Bad command string: " & cmdLine)
                End Try
            End Try
        End If
    End Sub

    Public Sub launchProcessOnScreen(ByVal myProcess As Process, Optional ByVal needsStart As Boolean = True)
        If needsStart Then
            Try
                If Not myProcess.Start() Then Return
            Catch ex As System.ComponentModel.Win32Exception
                MsgBox("Unable to start process")
                Return
            End Try
        End If
        Dim sw As New Stopwatch()
        sw.Start()
        Do Until myProcess.HasExited OrElse _
                 myProcess.MainWindowHandle <> IntPtr.Zero OrElse _
                 sw.ElapsedMilliseconds > 15000L
            myProcess.Refresh()
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        Loop
        sw.Stop()
        If Not myProcess.HasExited AndAlso _
               myProcess.MainWindowHandle <> IntPtr.Zero Then
            MoveToScreen(myProcess.MainWindowHandle)
        End If
    End Sub


    Private Sub MoveToScreen(ByVal hWnd As IntPtr)
        If MonitorFromWindow(hWnd, MONITOR_DEFAULTTONEAREST) _
                = MonitorFromWindow(myForm.Handle, MONITOR_DEFAULTTONEAREST) Then
            'Already on correct screen
            Return
        End If
        Dim myScreen As Screen = Screen.FromHandle(myForm.Handle)
        Dim myPlacement As New WINDOWPLACEMENT
        Dim isMax As Boolean = False

        myPlacement.Length = Marshal.SizeOf(myPlacement)

        GetWindowPlacement(hWnd, myPlacement)

        myPlacement.ptMaxPosition.X = myForm.Left
        myPlacement.ptMaxPosition.Y = myForm.Top

        myPlacement.rcNormalPosition.Right -= myPlacement.rcNormalPosition.Left - myForm.Left
        myPlacement.rcNormalPosition.Bottom -= myPlacement.rcNormalPosition.Top - myForm.Top
        myPlacement.rcNormalPosition.Left = myForm.Location.X
        myPlacement.rcNormalPosition.Top = myForm.Location.Y

        If myPlacement.ShowCmd = WindowStates.MAXIMIZED Then
            isMax = True
            myPlacement.ShowCmd = WindowStates.NORMAL
        End If

        SetWindowPlacement(hWnd, myPlacement)

        If isMax Then
            myPlacement.ShowCmd = WindowStates.MAXIMIZED
            SetWindowPlacement(hWnd, myPlacement)
        End If
    End Sub

    Public Sub myForm_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        e.Cancel = True
        myDeactivate.doClick(sender, e)
    End Sub

    Private Function FindRoot(ByVal hWnd As Int32) As Int32
        Do
            Dim parent_hwnd As Int32 = GetParent(hWnd)
            If parent_hwnd = 0 Then Return hWnd
            hWnd = parent_hwnd
        Loop
    End Function

    Public Sub SetAutoHide(ByVal value As IAutohide.AutoHideModes)

        autohide = value
        If autohide = IAutohide.AutoHideModes.Disabled Then
            tmrAutohide.Enabled = False
            hideCount = 0
            myForm.Visible = True
            UpdateWorkingArea()
        Else
            autohide = IAutohide.AutoHideModes.Visible
            tmrAutohide.Enabled = True
        End If
    End Sub

    Private Sub tmrAutoHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutohide.Tick
        If Not autohide = IAutohide.AutoHideModes.Disabled Then
            Dim myPoint As POINTAPI
            myPoint.X = Cursor.Position.X
            myPoint.Y = Cursor.Position.Y

            Dim rootHwnd As IntPtr = FindRoot(WindowFromPoint(myPoint))

            'The mouse must be within this many pixels of the edge to show the screen
            Const edgeWidth As Integer = 1

            Dim edges As IAutohide.AutohideEdges = CType(myForm, IAutohide).getAutohideEdges()
            Dim isAtEdge As Boolean = False

            If myForm.Bounds.Contains(myPoint.X, myPoint.Y) Then
                If (edges And IAutohide.AutohideEdges.Top) = IAutohide.AutohideEdges.Top Then
                    isAtEdge = isAtEdge Or (myPoint.Y < myForm.Top + edgeWidth And myPoint.Y >= myForm.Top)
                End If
                If (edges And IAutohide.AutohideEdges.Left) = IAutohide.AutohideEdges.Left Then
                    isAtEdge = isAtEdge Or (myPoint.X < myForm.Left + edgeWidth And myPoint.X >= myForm.Left)
                End If
                If (edges And IAutohide.AutohideEdges.Bottom) = IAutohide.AutohideEdges.Bottom Then
                    isAtEdge = isAtEdge Or (myPoint.Y >= myForm.Bottom - edgeWidth And myPoint.Y <= myForm.Bottom)
                End If
                If (edges And IAutohide.AutohideEdges.Right) = IAutohide.AutohideEdges.Right Then
                    isAtEdge = isAtEdge Or (myPoint.X >= myForm.Right - edgeWidth And myPoint.X <= myForm.Right)
                End If
            End If
            If rootHwnd = myForm.Handle Or isAtEdge Or _
                    ProgramsPanel.Visible Or UserButtonsPanel.Visible Then
                hideCount = 0

                If Not autohide = IAutohide.AutoHideModes.Visible Or myForm.Visible = False Then
                    myForm.Visible = True
                    autohide = IAutohide.AutoHideModes.Visible
                    UpdateWorkingArea()
                End If
            End If

            If hideCount <= 30 Then
                hideCount += 1
            Else
                autohide = IAutohide.AutoHideModes.Hidden
                myForm.Visible = False
                UpdateWorkingArea()
            End If
        Else
            tmrAutohide.Enabled = False
        End If
    End Sub

    Public Sub myform_MouseScroll(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not ProgramsPanel.Visible Then Return
        If e.Delta > 0 Then
            previousProgPage()
        Else
            nextProgPage()
        End If
    End Sub

    Public Sub myMainPanel_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If isInit Then
            UpdateRegion()
        End If
    End Sub

    Public Sub UpdateRegion()
        Dim myRegion As Region = New Region(New RectangleF(0, 0, myForm.Width, myForm.Height))
        Dim mainRect As New Rectangle(myForm.PointToClient(myMainPanel.PointToScreen(Drawing.Point.Empty)), myMainPanel.Size)
        myRegion.Exclude(mainRect)
        myForm.Region = myRegion
        UpdateWorkingArea()
    End Sub

    Public Sub UpdateWorkingArea()
        Dim adjustedBounds As Rectangle
        If autohide = IAutohide.AutoHideModes.Hidden Then
            adjustedBounds = Screen.FromHandle(myForm.Handle).Bounds
        Else
            adjustedBounds = New Rectangle(myMainPanel.PointToScreen(Drawing.Point.Empty), myMainPanel.Size)
        End If
        'Update working area and desktop panel
        resizeWorkingArea(adjustedBounds.X, adjustedBounds.Y, adjustedBounds.Width, adjustedBounds.Height)
        updateDesktopBounds(ScreenIndex, adjustedBounds)
        'Alert the linked windows (if there are any).
        If LinkedWindows.Count > 0 Then
            Dim myRectData As New COPYDATASTRUCT
            myRectData.dwData = 100
            myRectData.cdData = Marshal.SizeOf(GetType(Rectangle))

            Dim myPtr As IntPtr = Marshal.AllocCoTaskMem(myRectData.cdData)
            Marshal.StructureToPtr(adjustedBounds, myPtr, False)

            myRectData.lpData = myPtr

            Dim MyCopyData As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(COPYDATASTRUCT)))
            Marshal.StructureToPtr(myRectData, MyCopyData, False)
            Dim screen1 As Integer = MonitorFromWindow(myForm.Handle, MONITOR_DEFAULTTONEAREST)
            Dim i As Integer = LinkedWindows.Count - 1
            While i > 0
                Dim screen2 = MonitorFromWindow(LinkedWindows(i), MONITOR_DEFAULTTONEAREST)
                If screen1 <> screen2 Then Continue While
                Dim res As Integer = SendMessage(LinkedWindows(i), WM_COPYDATA, myDesktop.Handle, MyCopyData)
                If res = 0 Then 'Drop linked window if not responding
                    LinkedWindows.RemoveAt(i)
                End If
                i -= 1
            End While
            Marshal.FreeCoTaskMem(MyCopyData)
            Marshal.FreeCoTaskMem(myPtr)
        End If
    End Sub
End Class
