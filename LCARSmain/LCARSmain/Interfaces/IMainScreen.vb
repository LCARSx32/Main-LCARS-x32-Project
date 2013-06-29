Public Interface IMainScreen
    Inherits IAutohide
    Enum MainScreenControls
        Deactivate = 0
        StartMenu = 1
        MyComputer = 2
        Settings = 3
        Engineering = 4
        RedAlert = 5
        SelfDestruct = 6
        Clock = 7
        PhotoViewer = 8
        WebBrowser = 9
        ManageUserButtons = 10
        ViewUserButtons = 11
        MyDocuments = 12
        MyPictures = 13
        MyVideos = 14
        MyMusic = 15
        BatteryMonitor = 16
        TrayIcons = 17
        ShowTray = 18
        HideTray = 19
        OSK = 20
        SpeechConsole = 21
        Help = 22
        RunProgram = 23
        ListAlerts = 24
    End Enum
    ReadOnly Property MainForm() As System.Windows.Forms.Form

    ReadOnly Property MainBar() As System.Windows.Forms.Panel

    ReadOnly Property MainPanel() As System.Windows.Forms.Panel

    ReadOnly Property ProgramsPanel() As LCARS.Controls.ButtonGrid

    ReadOnly Property UserButtons() As LCARS.Controls.ButtonGrid

    ReadOnly Property TaskBar() As System.Windows.Forms.Panel

    ReadOnly Property ModeSelect() As LCARS.LCARSbuttonClass

    ReadOnly Property OptionalComponents(ByVal ComponentType As MainScreenControls) As LCARS.LCARSbuttonClass

    ReadOnly Property IsActive(ByVal ComponentType As MainScreenControls) As Boolean

    Property curBusiness() As modBusiness

    ReadOnly Property BuildVersion() As String

End Interface
