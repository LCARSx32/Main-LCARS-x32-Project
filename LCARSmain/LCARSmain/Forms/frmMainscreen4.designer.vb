<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainscreen4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim LcarScolor1 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor2 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.pnlMainBar = New System.Windows.Forms.Panel
        Me.myAlertListButton = New LCARS.Controls.ArrowButton
        Me.pnlBatt = New System.Windows.Forms.Panel
        Me.fbBatt8 = New LCARS.Controls.FlatButton
        Me.fbBatt10 = New LCARS.Controls.FlatButton
        Me.fbBatt9 = New LCARS.Controls.FlatButton
        Me.fbBatt7 = New LCARS.Controls.FlatButton
        Me.fbBatt6 = New LCARS.Controls.FlatButton
        Me.fbBattTop = New LCARS.Controls.FlatButton
        Me.lblBatt = New System.Windows.Forms.Label
        Me.fbBatt3 = New LCARS.Controls.FlatButton
        Me.fbBatt5 = New LCARS.Controls.FlatButton
        Me.fbBatt4 = New LCARS.Controls.FlatButton
        Me.fbBatt2 = New LCARS.Controls.FlatButton
        Me.fbBatt1 = New LCARS.Controls.FlatButton
        Me.FlatButton19 = New LCARS.Controls.FlatButton
        Me.Elbow6 = New LCARS.Controls.Elbow
        Me.FlatButton15 = New LCARS.Controls.FlatButton
        Me.Elbow8 = New LCARS.Controls.Elbow
        Me.lblPowerSource = New System.Windows.Forms.Label
        Me.Elbow9 = New LCARS.Controls.Elbow
        Me.Elbow7 = New LCARS.Controls.Elbow
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.myClock = New LCARS.Controls.FlatButton
        Me.myStartMenu = New LCARS.Controls.FlatButton
        Me.myUserButtons = New LCARS.Controls.FlatButton
        Me.myPictures = New LCARS.Controls.FlatButton
        Me.myAlert = New LCARS.Controls.FlatButton
        Me.myPhoto = New LCARS.Controls.FlatButton
        Me.pnlApps = New System.Windows.Forms.Panel
        Me.myDeactivate = New LCARS.Controls.FlatButton
        Me.myVideos = New LCARS.Controls.FlatButton
        Me.myDocuments = New LCARS.Controls.FlatButton
        Me.myDestruct = New LCARS.Controls.FlatButton
        Me.pnlTray = New System.Windows.Forms.Panel
        Me.HideTrayButton = New LCARS.Controls.ArrowButton
        Me.showTrayButton = New LCARS.Controls.FlatButton
        Me.myModeSelect = New LCARS.Controls.FlatButton
        Me.fbWebBrowser = New LCARS.Controls.FlatButton
        Me.myRun = New LCARS.Controls.FlatButton
        Me.myEngineering = New LCARS.Controls.FlatButton
        Me.mySpeech = New LCARS.Controls.FlatButton
        Me.mySettings = New LCARS.Controls.FlatButton
        Me.myHelp = New LCARS.Controls.FlatButton
        Me.myOSK = New LCARS.Controls.FlatButton
        Me.myButtonManager = New LCARS.Controls.FlatButton
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.pnlProgs = New System.Windows.Forms.Panel
        Me.myProgsNext = New LCARS.Controls.ArrowButton
        Me.fbProgramPages = New LCARS.Controls.FlatButton
        Me.pnlPrograms = New LCARS.Controls.WindowlessContainer
        Me.myProgBack = New LCARS.Controls.FlatButton
        Me.myProgsBack = New LCARS.Controls.ArrowButton
        Me.myMusic = New LCARS.Controls.FlatButton
        Me.MyComp = New LCARS.Controls.FlatButton
        Me.gridUserButtons = New LCARS.Controls.ButtonGrid
        Me.tmrAutoHide = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMainBar.SuspendLayout()
        Me.pnlBatt.SuspendLayout()
        Me.pnlTray.SuspendLayout()
        Me.pnlProgs.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMainBar
        '
        Me.pnlMainBar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMainBar.Controls.Add(Me.myAlertListButton)
        Me.pnlMainBar.Controls.Add(Me.pnlBatt)
        Me.pnlMainBar.Controls.Add(Me.FlatButton1)
        Me.pnlMainBar.Controls.Add(Me.myClock)
        Me.pnlMainBar.Controls.Add(Me.myStartMenu)
        Me.pnlMainBar.Controls.Add(Me.myUserButtons)
        Me.pnlMainBar.Controls.Add(Me.myPictures)
        Me.pnlMainBar.Controls.Add(Me.myAlert)
        Me.pnlMainBar.Controls.Add(Me.myPhoto)
        Me.pnlMainBar.Controls.Add(Me.pnlApps)
        Me.pnlMainBar.Controls.Add(Me.myDeactivate)
        Me.pnlMainBar.Controls.Add(Me.myVideos)
        Me.pnlMainBar.Controls.Add(Me.myDocuments)
        Me.pnlMainBar.Controls.Add(Me.myDestruct)
        Me.pnlMainBar.Controls.Add(Me.pnlTray)
        Me.pnlMainBar.Controls.Add(Me.myModeSelect)
        Me.pnlMainBar.Controls.Add(Me.fbWebBrowser)
        Me.pnlMainBar.Controls.Add(Me.myRun)
        Me.pnlMainBar.Controls.Add(Me.myEngineering)
        Me.pnlMainBar.Controls.Add(Me.mySpeech)
        Me.pnlMainBar.Controls.Add(Me.mySettings)
        Me.pnlMainBar.Controls.Add(Me.myHelp)
        Me.pnlMainBar.Controls.Add(Me.myOSK)
        Me.pnlMainBar.Controls.Add(Me.myButtonManager)
        Me.pnlMainBar.Controls.Add(Me.pnlMain)
        Me.pnlMainBar.Controls.Add(Me.pnlProgs)
        Me.pnlMainBar.Controls.Add(Me.myMusic)
        Me.pnlMainBar.Controls.Add(Me.MyComp)
        Me.pnlMainBar.Controls.Add(Me.gridUserButtons)
        Me.pnlMainBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainBar.Name = "pnlMainBar"
        Me.pnlMainBar.Size = New System.Drawing.Size(800, 600)
        Me.pnlMainBar.TabIndex = 0
        Me.pnlMainBar.Tag = "2"
        '
        'myAlertListButton
        '
        Me.myAlertListButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myAlertListButton.ArrowDirection = LCARS.LCARSarrowDirection.Down
        Me.myAlertListButton.AutoEllipsis = Nothing
        Me.myAlertListButton.Beeping = False
        Me.myAlertListButton.ButtonText = ""
        Me.myAlertListButton.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.myAlertListButton.ButtonTextHeight = 14
        Me.myAlertListButton.Clickable = True
        Me.myAlertListButton.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myAlertListButton.CustomAlertColor = System.Drawing.Color.Empty
        Me.myAlertListButton.Data = Nothing
        Me.myAlertListButton.Data2 = Nothing
        Me.myAlertListButton.FlashInterval = 500
        Me.myAlertListButton.holdDraw = False
        Me.myAlertListButton.Lit = True
        Me.myAlertListButton.Location = New System.Drawing.Point(675, 62)
        Me.myAlertListButton.Name = "myAlertListButton"
        Me.myAlertListButton.RedAlert = LCARS.LCARSalert.Normal
        Me.myAlertListButton.Size = New System.Drawing.Size(24, 48)
        Me.myAlertListButton.TabIndex = 86
        '
        'pnlBatt
        '
        Me.pnlBatt.Controls.Add(Me.fbBatt8)
        Me.pnlBatt.Controls.Add(Me.fbBatt10)
        Me.pnlBatt.Controls.Add(Me.fbBatt9)
        Me.pnlBatt.Controls.Add(Me.fbBatt7)
        Me.pnlBatt.Controls.Add(Me.fbBatt6)
        Me.pnlBatt.Controls.Add(Me.fbBattTop)
        Me.pnlBatt.Controls.Add(Me.lblBatt)
        Me.pnlBatt.Controls.Add(Me.fbBatt3)
        Me.pnlBatt.Controls.Add(Me.fbBatt5)
        Me.pnlBatt.Controls.Add(Me.fbBatt4)
        Me.pnlBatt.Controls.Add(Me.fbBatt2)
        Me.pnlBatt.Controls.Add(Me.fbBatt1)
        Me.pnlBatt.Controls.Add(Me.FlatButton19)
        Me.pnlBatt.Controls.Add(Me.Elbow6)
        Me.pnlBatt.Controls.Add(Me.FlatButton15)
        Me.pnlBatt.Controls.Add(Me.Elbow8)
        Me.pnlBatt.Controls.Add(Me.lblPowerSource)
        Me.pnlBatt.Controls.Add(Me.Elbow9)
        Me.pnlBatt.Controls.Add(Me.Elbow7)
        Me.pnlBatt.Location = New System.Drawing.Point(6, 62)
        Me.pnlBatt.Name = "pnlBatt"
        Me.pnlBatt.Size = New System.Drawing.Size(109, 48)
        Me.pnlBatt.TabIndex = 61
        Me.pnlBatt.Tag = ""
        '
        'fbBatt8
        '
        Me.fbBatt8.AutoEllipsis = False
        Me.fbBatt8.Beeping = False
        Me.fbBatt8.ButtonText = ""
        Me.fbBatt8.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt8.ButtonTextHeight = 18
        Me.fbBatt8.Clickable = False
        Me.fbBatt8.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt8.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt8.Data = Nothing
        Me.fbBatt8.Data2 = Nothing
        Me.fbBatt8.FlashInterval = 0
        Me.fbBatt8.holdDraw = False
        Me.fbBatt8.Lit = True
        Me.fbBatt8.Location = New System.Drawing.Point(13, 15)
        Me.fbBatt8.Name = "fbBatt8"
        Me.fbBatt8.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt8.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt8.TabIndex = 53
        Me.fbBatt8.Tag = "2"
        '
        'fbBatt10
        '
        Me.fbBatt10.AutoEllipsis = False
        Me.fbBatt10.Beeping = False
        Me.fbBatt10.ButtonText = ""
        Me.fbBatt10.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt10.ButtonTextHeight = 18
        Me.fbBatt10.Clickable = False
        Me.fbBatt10.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt10.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt10.Data = Nothing
        Me.fbBatt10.Data2 = Nothing
        Me.fbBatt10.FlashInterval = 0
        Me.fbBatt10.holdDraw = False
        Me.fbBatt10.Lit = True
        Me.fbBatt10.Location = New System.Drawing.Point(13, 9)
        Me.fbBatt10.Name = "fbBatt10"
        Me.fbBatt10.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt10.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt10.TabIndex = 55
        Me.fbBatt10.Tag = "4"
        '
        'fbBatt9
        '
        Me.fbBatt9.AutoEllipsis = False
        Me.fbBatt9.Beeping = False
        Me.fbBatt9.ButtonText = ""
        Me.fbBatt9.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt9.ButtonTextHeight = 18
        Me.fbBatt9.Clickable = False
        Me.fbBatt9.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt9.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt9.Data = Nothing
        Me.fbBatt9.Data2 = Nothing
        Me.fbBatt9.FlashInterval = 0
        Me.fbBatt9.holdDraw = False
        Me.fbBatt9.Lit = True
        Me.fbBatt9.Location = New System.Drawing.Point(13, 12)
        Me.fbBatt9.Name = "fbBatt9"
        Me.fbBatt9.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt9.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt9.TabIndex = 54
        Me.fbBatt9.Tag = "3"
        '
        'fbBatt7
        '
        Me.fbBatt7.AutoEllipsis = False
        Me.fbBatt7.Beeping = False
        Me.fbBatt7.ButtonText = ""
        Me.fbBatt7.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt7.ButtonTextHeight = 18
        Me.fbBatt7.Clickable = False
        Me.fbBatt7.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt7.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt7.Data = Nothing
        Me.fbBatt7.Data2 = Nothing
        Me.fbBatt7.FlashInterval = 0
        Me.fbBatt7.holdDraw = False
        Me.fbBatt7.Lit = True
        Me.fbBatt7.Location = New System.Drawing.Point(13, 18)
        Me.fbBatt7.Name = "fbBatt7"
        Me.fbBatt7.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt7.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt7.TabIndex = 52
        Me.fbBatt7.Tag = "1"
        '
        'fbBatt6
        '
        Me.fbBatt6.AutoEllipsis = False
        Me.fbBatt6.Beeping = False
        Me.fbBatt6.ButtonText = ""
        Me.fbBatt6.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt6.ButtonTextHeight = 18
        Me.fbBatt6.Clickable = False
        Me.fbBatt6.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt6.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt6.Data = Nothing
        Me.fbBatt6.Data2 = Nothing
        Me.fbBatt6.FlashInterval = 500
        Me.fbBatt6.holdDraw = False
        Me.fbBatt6.Lit = True
        Me.fbBatt6.Location = New System.Drawing.Point(13, 21)
        Me.fbBatt6.Name = "fbBatt6"
        Me.fbBatt6.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt6.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt6.TabIndex = 51
        Me.fbBatt6.Tag = "0"
        '
        'fbBattTop
        '
        Me.fbBattTop.AutoEllipsis = False
        Me.fbBattTop.Beeping = False
        Me.fbBattTop.ButtonText = ""
        Me.fbBattTop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBattTop.ButtonTextHeight = 18
        Me.fbBattTop.Clickable = False
        Me.fbBattTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBattTop.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBattTop.Data = Nothing
        Me.fbBattTop.Data2 = Nothing
        Me.fbBattTop.FlashInterval = 0
        Me.fbBattTop.holdDraw = False
        Me.fbBattTop.Lit = True
        Me.fbBattTop.Location = New System.Drawing.Point(21, 1)
        Me.fbBattTop.Name = "fbBattTop"
        Me.fbBattTop.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBattTop.Size = New System.Drawing.Size(8, 5)
        Me.fbBattTop.TabIndex = 47
        Me.fbBattTop.Tag = "5"
        '
        'lblBatt
        '
        Me.lblBatt.AutoSize = True
        Me.lblBatt.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatt.ForeColor = System.Drawing.Color.Orange
        Me.lblBatt.Location = New System.Drawing.Point(58, 24)
        Me.lblBatt.Name = "lblBatt"
        Me.lblBatt.Size = New System.Drawing.Size(38, 21)
        Me.lblBatt.TabIndex = 35
        Me.lblBatt.Tag = "3"
        Me.lblBatt.Text = "100%"
        '
        'fbBatt3
        '
        Me.fbBatt3.AutoEllipsis = False
        Me.fbBatt3.Beeping = False
        Me.fbBatt3.ButtonText = ""
        Me.fbBatt3.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt3.ButtonTextHeight = 18
        Me.fbBatt3.Clickable = False
        Me.fbBatt3.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt3.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt3.Data = Nothing
        Me.fbBatt3.Data2 = Nothing
        Me.fbBatt3.FlashInterval = 0
        Me.fbBatt3.holdDraw = False
        Me.fbBatt3.Lit = True
        Me.fbBatt3.Location = New System.Drawing.Point(13, 30)
        Me.fbBatt3.Name = "fbBatt3"
        Me.fbBatt3.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt3.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt3.TabIndex = 32
        Me.fbBatt3.Tag = "2"
        '
        'fbBatt5
        '
        Me.fbBatt5.AutoEllipsis = False
        Me.fbBatt5.Beeping = False
        Me.fbBatt5.ButtonText = ""
        Me.fbBatt5.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt5.ButtonTextHeight = 18
        Me.fbBatt5.Clickable = False
        Me.fbBatt5.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt5.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt5.Data = Nothing
        Me.fbBatt5.Data2 = Nothing
        Me.fbBatt5.FlashInterval = 0
        Me.fbBatt5.holdDraw = False
        Me.fbBatt5.Lit = True
        Me.fbBatt5.Location = New System.Drawing.Point(13, 24)
        Me.fbBatt5.Name = "fbBatt5"
        Me.fbBatt5.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt5.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt5.TabIndex = 34
        Me.fbBatt5.Tag = "4"
        '
        'fbBatt4
        '
        Me.fbBatt4.AutoEllipsis = False
        Me.fbBatt4.Beeping = False
        Me.fbBatt4.ButtonText = ""
        Me.fbBatt4.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt4.ButtonTextHeight = 18
        Me.fbBatt4.Clickable = False
        Me.fbBatt4.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt4.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt4.Data = Nothing
        Me.fbBatt4.Data2 = Nothing
        Me.fbBatt4.FlashInterval = 0
        Me.fbBatt4.holdDraw = False
        Me.fbBatt4.Lit = True
        Me.fbBatt4.Location = New System.Drawing.Point(13, 27)
        Me.fbBatt4.Name = "fbBatt4"
        Me.fbBatt4.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt4.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt4.TabIndex = 33
        Me.fbBatt4.Tag = "3"
        '
        'fbBatt2
        '
        Me.fbBatt2.AutoEllipsis = False
        Me.fbBatt2.Beeping = False
        Me.fbBatt2.ButtonText = ""
        Me.fbBatt2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt2.ButtonTextHeight = 18
        Me.fbBatt2.Clickable = False
        Me.fbBatt2.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt2.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt2.Data = Nothing
        Me.fbBatt2.Data2 = Nothing
        Me.fbBatt2.FlashInterval = 0
        Me.fbBatt2.holdDraw = False
        Me.fbBatt2.Lit = True
        Me.fbBatt2.Location = New System.Drawing.Point(13, 33)
        Me.fbBatt2.Name = "fbBatt2"
        Me.fbBatt2.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt2.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt2.TabIndex = 31
        Me.fbBatt2.Tag = "1"
        '
        'fbBatt1
        '
        Me.fbBatt1.AutoEllipsis = False
        Me.fbBatt1.Beeping = False
        Me.fbBatt1.ButtonText = ""
        Me.fbBatt1.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBatt1.ButtonTextHeight = 18
        Me.fbBatt1.Clickable = False
        Me.fbBatt1.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbBatt1.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBatt1.Data = Nothing
        Me.fbBatt1.Data2 = Nothing
        Me.fbBatt1.FlashInterval = 500
        Me.fbBatt1.holdDraw = False
        Me.fbBatt1.Lit = True
        Me.fbBatt1.Location = New System.Drawing.Point(13, 36)
        Me.fbBatt1.Name = "fbBatt1"
        Me.fbBatt1.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBatt1.Size = New System.Drawing.Size(25, 2)
        Me.fbBatt1.TabIndex = 30
        Me.fbBatt1.Tag = "0"
        '
        'FlatButton19
        '
        Me.FlatButton19.AutoEllipsis = False
        Me.FlatButton19.Beeping = False
        Me.FlatButton19.ButtonText = ""
        Me.FlatButton19.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton19.ButtonTextHeight = 18
        Me.FlatButton19.Clickable = False
        Me.FlatButton19.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton19.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton19.Data = Nothing
        Me.FlatButton19.Data2 = Nothing
        Me.FlatButton19.FlashInterval = 0
        Me.FlatButton19.holdDraw = False
        Me.FlatButton19.Lit = True
        Me.FlatButton19.Location = New System.Drawing.Point(6, 12)
        Me.FlatButton19.Name = "FlatButton19"
        Me.FlatButton19.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton19.Size = New System.Drawing.Size(5, 18)
        Me.FlatButton19.TabIndex = 25
        Me.FlatButton19.Tag = "0"
        '
        'Elbow6
        '
        Me.Elbow6.AutoEllipsis = False
        Me.Elbow6.Beeping = False
        Me.Elbow6.ButtonHeight = 2
        Me.Elbow6.ButtonText = ""
        Me.Elbow6.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Elbow6.ButtonTextHeight = 14
        Me.Elbow6.ButtonWidth = 5
        Me.Elbow6.Clickable = False
        Me.Elbow6.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow6.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow6.Data = Nothing
        Me.Elbow6.Data2 = Nothing
        Me.Elbow6.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow6.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow6.FlashInterval = 0
        Me.Elbow6.holdDraw = False
        Me.Elbow6.Lit = True
        Me.Elbow6.Location = New System.Drawing.Point(6, 27)
        Me.Elbow6.Name = "Elbow6"
        Me.Elbow6.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow6.Size = New System.Drawing.Size(13, 16)
        Me.Elbow6.TabIndex = 26
        Me.Elbow6.Tag = "0"
        '
        'FlatButton15
        '
        Me.FlatButton15.AutoEllipsis = False
        Me.FlatButton15.Beeping = False
        Me.FlatButton15.ButtonText = ""
        Me.FlatButton15.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton15.ButtonTextHeight = 18
        Me.FlatButton15.Clickable = False
        Me.FlatButton15.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton15.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton15.Data = Nothing
        Me.FlatButton15.Data2 = Nothing
        Me.FlatButton15.FlashInterval = 0
        Me.FlatButton15.holdDraw = False
        Me.FlatButton15.Lit = True
        Me.FlatButton15.Location = New System.Drawing.Point(40, 15)
        Me.FlatButton15.Name = "FlatButton15"
        Me.FlatButton15.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton15.Size = New System.Drawing.Size(5, 18)
        Me.FlatButton15.TabIndex = 44
        Me.FlatButton15.Tag = "0"
        '
        'Elbow8
        '
        Me.Elbow8.AutoEllipsis = False
        Me.Elbow8.Beeping = False
        Me.Elbow8.ButtonHeight = 2
        Me.Elbow8.ButtonText = ""
        Me.Elbow8.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Elbow8.ButtonTextHeight = 14
        Me.Elbow8.ButtonWidth = 5
        Me.Elbow8.Clickable = False
        Me.Elbow8.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow8.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow8.Data = Nothing
        Me.Elbow8.Data2 = Nothing
        Me.Elbow8.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow8.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerRight
        Me.Elbow8.FlashInterval = 0
        Me.Elbow8.holdDraw = False
        Me.Elbow8.Lit = True
        Me.Elbow8.Location = New System.Drawing.Point(16, 27)
        Me.Elbow8.Name = "Elbow8"
        Me.Elbow8.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow8.Size = New System.Drawing.Size(29, 16)
        Me.Elbow8.TabIndex = 45
        Me.Elbow8.Tag = "0"
        '
        'lblPowerSource
        '
        Me.lblPowerSource.AutoSize = True
        Me.lblPowerSource.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPowerSource.ForeColor = System.Drawing.Color.Orange
        Me.lblPowerSource.Location = New System.Drawing.Point(51, 1)
        Me.lblPowerSource.Name = "lblPowerSource"
        Me.lblPowerSource.Size = New System.Drawing.Size(57, 21)
        Me.lblPowerSource.TabIndex = 36
        Me.lblPowerSource.Tag = "3"
        Me.lblPowerSource.Text = "AUXILIARY"
        '
        'Elbow9
        '
        Me.Elbow9.AutoEllipsis = False
        Me.Elbow9.Beeping = False
        Me.Elbow9.ButtonHeight = 2
        Me.Elbow9.ButtonText = ""
        Me.Elbow9.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Elbow9.ButtonTextHeight = 14
        Me.Elbow9.ButtonWidth = 5
        Me.Elbow9.Clickable = False
        Me.Elbow9.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow9.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow9.Data = Nothing
        Me.Elbow9.Data2 = Nothing
        Me.Elbow9.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow9.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperRight
        Me.Elbow9.FlashInterval = 0
        Me.Elbow9.holdDraw = False
        Me.Elbow9.Lit = True
        Me.Elbow9.Location = New System.Drawing.Point(32, 4)
        Me.Elbow9.Name = "Elbow9"
        Me.Elbow9.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow9.Size = New System.Drawing.Size(13, 16)
        Me.Elbow9.TabIndex = 46
        Me.Elbow9.Tag = "0"
        '
        'Elbow7
        '
        Me.Elbow7.AutoEllipsis = False
        Me.Elbow7.Beeping = False
        Me.Elbow7.ButtonHeight = 2
        Me.Elbow7.ButtonText = ""
        Me.Elbow7.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Elbow7.ButtonTextHeight = 14
        Me.Elbow7.ButtonWidth = 5
        Me.Elbow7.Clickable = False
        Me.Elbow7.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow7.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow7.Data = Nothing
        Me.Elbow7.Data2 = Nothing
        Me.Elbow7.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow7.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow7.FlashInterval = 0
        Me.Elbow7.holdDraw = False
        Me.Elbow7.Lit = True
        Me.Elbow7.Location = New System.Drawing.Point(6, 4)
        Me.Elbow7.Name = "Elbow7"
        Me.Elbow7.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow7.Size = New System.Drawing.Size(13, 16)
        Me.Elbow7.TabIndex = 43
        Me.Elbow7.Tag = "0"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.AutoEllipsis = False
        Me.FlatButton1.Beeping = True
        Me.FlatButton1.ButtonText = ""
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = False
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(294, 5)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(21, 51)
        Me.FlatButton1.TabIndex = 85
        '
        'myClock
        '
        Me.myClock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myClock.AutoEllipsis = False
        Me.myClock.Beeping = False
        Me.myClock.ButtonText = "LOADING CLOCK"
        Me.myClock.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myClock.ButtonTextHeight = -1
        Me.myClock.Clickable = True
        Me.myClock.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.myClock.CustomAlertColor = System.Drawing.Color.Empty
        Me.myClock.Data = Nothing
        Me.myClock.Data2 = Nothing
        Me.myClock.FlashInterval = 500
        Me.myClock.holdDraw = False
        Me.myClock.Lit = True
        Me.myClock.Location = New System.Drawing.Point(479, 116)
        Me.myClock.Name = "myClock"
        Me.myClock.RedAlert = LCARS.LCARSalert.Normal
        Me.myClock.Size = New System.Drawing.Size(72, 40)
        Me.myClock.TabIndex = 69
        Me.myClock.Tag = "1"
        Me.myClock.Text = "LOADING CLOCK"
        '
        'myStartMenu
        '
        Me.myStartMenu.AutoEllipsis = False
        Me.myStartMenu.Beeping = False
        Me.myStartMenu.ButtonText = "PROGRAMS"
        Me.myStartMenu.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myStartMenu.ButtonTextHeight = 14
        Me.myStartMenu.Clickable = True
        Me.myStartMenu.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myStartMenu.CustomAlertColor = System.Drawing.Color.Empty
        Me.myStartMenu.Data = Nothing
        Me.myStartMenu.Data2 = Nothing
        Me.myStartMenu.FlashInterval = 500
        Me.myStartMenu.holdDraw = False
        Me.myStartMenu.Lit = True
        Me.myStartMenu.Location = New System.Drawing.Point(6, 116)
        Me.myStartMenu.Name = "myStartMenu"
        Me.myStartMenu.RedAlert = LCARS.LCARSalert.Normal
        Me.myStartMenu.Size = New System.Drawing.Size(238, 40)
        Me.myStartMenu.TabIndex = 69
        Me.myStartMenu.Tag = "0"
        Me.myStartMenu.Text = "PROGRAMS"
        '
        'myUserButtons
        '
        Me.myUserButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myUserButtons.AutoEllipsis = False
        Me.myUserButtons.Beeping = False
        Me.myUserButtons.ButtonText = "PERSONAL BUTTONS"
        Me.myUserButtons.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myUserButtons.ButtonTextHeight = 14
        Me.myUserButtons.Clickable = True
        Me.myUserButtons.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myUserButtons.CustomAlertColor = System.Drawing.Color.Empty
        Me.myUserButtons.Data = Nothing
        Me.myUserButtons.Data2 = Nothing
        Me.myUserButtons.FlashInterval = 500
        Me.myUserButtons.holdDraw = False
        Me.myUserButtons.Lit = True
        Me.myUserButtons.Location = New System.Drawing.Point(557, 116)
        Me.myUserButtons.Name = "myUserButtons"
        Me.myUserButtons.RedAlert = LCARS.LCARSalert.Normal
        Me.myUserButtons.Size = New System.Drawing.Size(238, 40)
        Me.myUserButtons.TabIndex = 68
        Me.myUserButtons.Tag = "1"
        Me.myUserButtons.Text = "PERSONAL BUTTONS"
        '
        'myPictures
        '
        Me.myPictures.AutoEllipsis = False
        Me.myPictures.Beeping = False
        Me.myPictures.ButtonText = "MY PICTURES"
        Me.myPictures.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myPictures.ButtonTextHeight = 14
        Me.myPictures.Clickable = True
        Me.myPictures.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myPictures.CustomAlertColor = System.Drawing.Color.Empty
        Me.myPictures.Data = Nothing
        Me.myPictures.Data2 = Nothing
        Me.myPictures.FlashInterval = 500
        Me.myPictures.holdDraw = False
        Me.myPictures.Lit = True
        Me.myPictures.Location = New System.Drawing.Point(198, 5)
        Me.myPictures.Name = "myPictures"
        Me.myPictures.RedAlert = LCARS.LCARSalert.Normal
        Me.myPictures.Size = New System.Drawing.Size(90, 24)
        Me.myPictures.TabIndex = 76
        Me.myPictures.Tag = "6"
        Me.myPictures.Text = "MY PICTURES"
        '
        'myAlert
        '
        Me.myAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myAlert.AutoEllipsis = False
        Me.myAlert.Beeping = False
        Me.myAlert.ButtonText = "RED ALERT"
        Me.myAlert.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myAlert.ButtonTextHeight = 14
        Me.myAlert.Clickable = True
        Me.myAlert.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.myAlert.CustomAlertColor = System.Drawing.Color.Empty
        Me.myAlert.Data = Nothing
        Me.myAlert.Data2 = Nothing
        Me.myAlert.FlashInterval = 500
        Me.myAlert.holdDraw = False
        Me.myAlert.Lit = True
        Me.myAlert.Location = New System.Drawing.Point(609, 62)
        Me.myAlert.Name = "myAlert"
        Me.myAlert.RedAlert = LCARS.LCARSalert.Normal
        Me.myAlert.Size = New System.Drawing.Size(59, 48)
        Me.myAlert.TabIndex = 34
        Me.myAlert.Tag = "3"
        Me.myAlert.Text = "RED ALERT"
        '
        'myPhoto
        '
        Me.myPhoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myPhoto.AutoEllipsis = False
        Me.myPhoto.Beeping = False
        Me.myPhoto.ButtonText = "PHOTO VIEWER"
        Me.myPhoto.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myPhoto.ButtonTextHeight = 14
        Me.myPhoto.Clickable = True
        Me.myPhoto.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myPhoto.CustomAlertColor = System.Drawing.Color.Empty
        Me.myPhoto.Data = Nothing
        Me.myPhoto.Data2 = Nothing
        Me.myPhoto.FlashInterval = 500
        Me.myPhoto.holdDraw = False
        Me.myPhoto.Lit = True
        Me.myPhoto.Location = New System.Drawing.Point(513, 5)
        Me.myPhoto.Name = "myPhoto"
        Me.myPhoto.RedAlert = LCARS.LCARSalert.Normal
        Me.myPhoto.Size = New System.Drawing.Size(90, 23)
        Me.myPhoto.TabIndex = 74
        Me.myPhoto.Tag = "6"
        Me.myPhoto.Text = "PHOTO VIEWER"
        '
        'pnlApps
        '
        Me.pnlApps.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlApps.BackColor = System.Drawing.Color.Black
        Me.pnlApps.Location = New System.Drawing.Point(121, 62)
        Me.pnlApps.Name = "pnlApps"
        Me.pnlApps.Size = New System.Drawing.Size(352, 48)
        Me.pnlApps.TabIndex = 77
        '
        'myDeactivate
        '
        Me.myDeactivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myDeactivate.AutoEllipsis = False
        Me.myDeactivate.Beeping = False
        Me.myDeactivate.ButtonText = "DEACTIVATE"
        Me.myDeactivate.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myDeactivate.ButtonTextHeight = 14
        Me.myDeactivate.Clickable = True
        Me.myDeactivate.Color = LCARS.LCARScolorStyles.Orange
        Me.myDeactivate.CustomAlertColor = System.Drawing.Color.Empty
        Me.myDeactivate.Data = Nothing
        Me.myDeactivate.Data2 = Nothing
        Me.myDeactivate.FlashInterval = 500
        Me.myDeactivate.holdDraw = False
        Me.myDeactivate.Lit = True
        Me.myDeactivate.Location = New System.Drawing.Point(705, 5)
        Me.myDeactivate.Name = "myDeactivate"
        Me.myDeactivate.RedAlert = LCARS.LCARSalert.Normal
        Me.myDeactivate.Size = New System.Drawing.Size(90, 51)
        Me.myDeactivate.TabIndex = 52
        Me.myDeactivate.Tag = "1"
        Me.myDeactivate.Text = "DEACTIVATE"
        '
        'myVideos
        '
        Me.myVideos.AutoEllipsis = False
        Me.myVideos.Beeping = False
        Me.myVideos.ButtonText = "MY VIDEOS"
        Me.myVideos.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myVideos.ButtonTextHeight = 14
        Me.myVideos.Clickable = True
        Me.myVideos.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myVideos.CustomAlertColor = System.Drawing.Color.Empty
        Me.myVideos.Data = Nothing
        Me.myVideos.Data2 = Nothing
        Me.myVideos.FlashInterval = 500
        Me.myVideos.holdDraw = False
        Me.myVideos.Lit = True
        Me.myVideos.Location = New System.Drawing.Point(198, 35)
        Me.myVideos.Name = "myVideos"
        Me.myVideos.RedAlert = LCARS.LCARSalert.Normal
        Me.myVideos.Size = New System.Drawing.Size(90, 21)
        Me.myVideos.TabIndex = 75
        Me.myVideos.Tag = "6"
        Me.myVideos.Text = "MY VIDEOS"
        '
        'myDocuments
        '
        Me.myDocuments.AutoEllipsis = False
        Me.myDocuments.Beeping = False
        Me.myDocuments.ButtonText = "MY DOCUMENTS"
        Me.myDocuments.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myDocuments.ButtonTextHeight = 14
        Me.myDocuments.Clickable = True
        Me.myDocuments.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myDocuments.CustomAlertColor = System.Drawing.Color.Empty
        Me.myDocuments.Data = Nothing
        Me.myDocuments.Data2 = Nothing
        Me.myDocuments.FlashInterval = 500
        Me.myDocuments.holdDraw = False
        Me.myDocuments.Lit = True
        Me.myDocuments.Location = New System.Drawing.Point(102, 35)
        Me.myDocuments.Name = "myDocuments"
        Me.myDocuments.RedAlert = LCARS.LCARSalert.Normal
        Me.myDocuments.Size = New System.Drawing.Size(90, 21)
        Me.myDocuments.TabIndex = 75
        Me.myDocuments.Tag = "6"
        Me.myDocuments.Text = "MY DOCUMENTS"
        '
        'myDestruct
        '
        Me.myDestruct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myDestruct.AutoEllipsis = False
        Me.myDestruct.Beeping = False
        Me.myDestruct.ButtonText = "AUTO DESTRUCT"
        Me.myDestruct.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myDestruct.ButtonTextHeight = 14
        Me.myDestruct.Clickable = True
        Me.myDestruct.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.myDestruct.CustomAlertColor = System.Drawing.Color.Empty
        Me.myDestruct.Data = Nothing
        Me.myDestruct.Data2 = Nothing
        Me.myDestruct.FlashInterval = 500
        Me.myDestruct.holdDraw = False
        Me.myDestruct.Lit = True
        Me.myDestruct.Location = New System.Drawing.Point(705, 62)
        Me.myDestruct.Name = "myDestruct"
        Me.myDestruct.RedAlert = LCARS.LCARSalert.Normal
        Me.myDestruct.Size = New System.Drawing.Size(90, 48)
        Me.myDestruct.TabIndex = 51
        Me.myDestruct.Tag = "2"
        Me.myDestruct.Text = "AUTO DESTRUCT"
        '
        'pnlTray
        '
        Me.pnlTray.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTray.BackColor = System.Drawing.Color.Black
        Me.pnlTray.Controls.Add(Me.HideTrayButton)
        Me.pnlTray.Controls.Add(Me.showTrayButton)
        Me.pnlTray.Location = New System.Drawing.Point(479, 62)
        Me.pnlTray.Name = "pnlTray"
        Me.pnlTray.Size = New System.Drawing.Size(124, 48)
        Me.pnlTray.TabIndex = 79
        '
        'HideTrayButton
        '
        Me.HideTrayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HideTrayButton.ArrowDirection = LCARS.LCARSarrowDirection.Right
        Me.HideTrayButton.AutoEllipsis = Nothing
        Me.HideTrayButton.Beeping = True
        Me.HideTrayButton.ButtonText = ""
        Me.HideTrayButton.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.HideTrayButton.ButtonTextHeight = 14
        Me.HideTrayButton.Clickable = True
        Me.HideTrayButton.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.HideTrayButton.CustomAlertColor = System.Drawing.Color.Empty
        Me.HideTrayButton.Data = Nothing
        Me.HideTrayButton.Data2 = Nothing
        Me.HideTrayButton.FlashInterval = 500
        Me.HideTrayButton.holdDraw = False
        Me.HideTrayButton.Lit = True
        Me.HideTrayButton.Location = New System.Drawing.Point(69, 0)
        Me.HideTrayButton.Name = "HideTrayButton"
        Me.HideTrayButton.RedAlert = LCARS.LCARSalert.Normal
        Me.HideTrayButton.Size = New System.Drawing.Size(55, 48)
        Me.HideTrayButton.TabIndex = 1
        Me.HideTrayButton.Visible = False
        '
        'showTrayButton
        '
        Me.showTrayButton.AutoEllipsis = False
        Me.showTrayButton.Beeping = True
        Me.showTrayButton.ButtonText = "SHOW TRAY ICONS"
        Me.showTrayButton.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.showTrayButton.ButtonTextHeight = 14
        Me.showTrayButton.Clickable = True
        Me.showTrayButton.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.showTrayButton.CustomAlertColor = System.Drawing.Color.Empty
        Me.showTrayButton.Data = Nothing
        Me.showTrayButton.Data2 = Nothing
        Me.showTrayButton.FlashInterval = 500
        Me.showTrayButton.holdDraw = False
        Me.showTrayButton.Lit = True
        Me.showTrayButton.Location = New System.Drawing.Point(0, 0)
        Me.showTrayButton.Name = "showTrayButton"
        Me.showTrayButton.RedAlert = LCARS.LCARSalert.Normal
        Me.showTrayButton.Size = New System.Drawing.Size(124, 48)
        Me.showTrayButton.TabIndex = 2
        Me.showTrayButton.Text = "SHOW TRAY ICONS"
        '
        'myModeSelect
        '
        Me.myModeSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myModeSelect.AutoEllipsis = False
        Me.myModeSelect.Beeping = True
        Me.myModeSelect.ButtonText = "MODE SELECT"
        Me.myModeSelect.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myModeSelect.ButtonTextHeight = 14
        Me.myModeSelect.Clickable = True
        Me.myModeSelect.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.myModeSelect.CustomAlertColor = System.Drawing.Color.Empty
        Me.myModeSelect.Data = Nothing
        Me.myModeSelect.Data2 = Nothing
        Me.myModeSelect.FlashInterval = 500
        Me.myModeSelect.holdDraw = False
        Me.myModeSelect.Lit = True
        Me.myModeSelect.Location = New System.Drawing.Point(609, 5)
        Me.myModeSelect.Name = "myModeSelect"
        Me.myModeSelect.RedAlert = LCARS.LCARSalert.Normal
        Me.myModeSelect.Size = New System.Drawing.Size(90, 51)
        Me.myModeSelect.TabIndex = 51
        Me.myModeSelect.Tag = "4"
        Me.myModeSelect.Text = "MODE SELECT"
        '
        'fbWebBrowser
        '
        Me.fbWebBrowser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbWebBrowser.AutoEllipsis = False
        Me.fbWebBrowser.Beeping = False
        Me.fbWebBrowser.ButtonText = "WEB BROWSER"
        Me.fbWebBrowser.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbWebBrowser.ButtonTextHeight = 14
        Me.fbWebBrowser.Clickable = True
        Me.fbWebBrowser.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.fbWebBrowser.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbWebBrowser.Data = Nothing
        Me.fbWebBrowser.Data2 = Nothing
        Me.fbWebBrowser.FlashInterval = 500
        Me.fbWebBrowser.holdDraw = False
        Me.fbWebBrowser.Lit = True
        Me.fbWebBrowser.Location = New System.Drawing.Point(513, 33)
        Me.fbWebBrowser.Name = "fbWebBrowser"
        Me.fbWebBrowser.RedAlert = LCARS.LCARSalert.Normal
        Me.fbWebBrowser.Size = New System.Drawing.Size(90, 23)
        Me.fbWebBrowser.TabIndex = 50
        Me.fbWebBrowser.Tag = "6"
        Me.fbWebBrowser.Text = "WEB BROWSER"
        '
        'myRun
        '
        Me.myRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myRun.AutoEllipsis = False
        Me.myRun.Beeping = False
        Me.myRun.ButtonText = "RUN PROGRAM"
        Me.myRun.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myRun.ButtonTextHeight = 14
        Me.myRun.Clickable = True
        Me.myRun.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myRun.CustomAlertColor = System.Drawing.Color.Empty
        Me.myRun.Data = Nothing
        Me.myRun.Data2 = Nothing
        Me.myRun.FlashInterval = 500
        Me.myRun.holdDraw = False
        Me.myRun.Lit = True
        Me.myRun.Location = New System.Drawing.Point(321, 5)
        Me.myRun.Name = "myRun"
        Me.myRun.RedAlert = LCARS.LCARSalert.Normal
        Me.myRun.Size = New System.Drawing.Size(90, 51)
        Me.myRun.TabIndex = 50
        Me.myRun.Tag = "6"
        Me.myRun.Text = "RUN PROGRAM"
        '
        'myEngineering
        '
        Me.myEngineering.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myEngineering.AutoEllipsis = False
        Me.myEngineering.Beeping = False
        Me.myEngineering.ButtonText = "ENGINEERING"
        Me.myEngineering.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myEngineering.ButtonTextHeight = 14
        Me.myEngineering.Clickable = True
        Me.myEngineering.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myEngineering.CustomAlertColor = System.Drawing.Color.Empty
        Me.myEngineering.Data = Nothing
        Me.myEngineering.Data2 = Nothing
        Me.myEngineering.FlashInterval = 500
        Me.myEngineering.holdDraw = False
        Me.myEngineering.Lit = True
        Me.myEngineering.Location = New System.Drawing.Point(417, 33)
        Me.myEngineering.Name = "myEngineering"
        Me.myEngineering.RedAlert = LCARS.LCARSalert.Normal
        Me.myEngineering.Size = New System.Drawing.Size(90, 23)
        Me.myEngineering.TabIndex = 50
        Me.myEngineering.Tag = "6"
        Me.myEngineering.Text = "ENGINEERING"
        '
        'mySpeech
        '
        Me.mySpeech.AutoEllipsis = False
        Me.mySpeech.Beeping = False
        Me.mySpeech.ButtonText = "SPEECH"
        Me.mySpeech.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.mySpeech.ButtonTextHeight = 14
        Me.mySpeech.Clickable = True
        Me.mySpeech.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.mySpeech.CustomAlertColor = System.Drawing.Color.Empty
        Me.mySpeech.Data = Nothing
        Me.mySpeech.Data2 = Nothing
        Me.mySpeech.FlashInterval = 500
        Me.mySpeech.holdDraw = False
        Me.mySpeech.Lit = False
        Me.mySpeech.Location = New System.Drawing.Point(329, 116)
        Me.mySpeech.Name = "mySpeech"
        Me.mySpeech.RedAlert = LCARS.LCARSalert.Normal
        Me.mySpeech.Size = New System.Drawing.Size(67, 40)
        Me.mySpeech.TabIndex = 84
        Me.mySpeech.Tag = "1"
        Me.mySpeech.Text = "SPEECH"
        '
        'mySettings
        '
        Me.mySettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mySettings.AutoEllipsis = False
        Me.mySettings.Beeping = False
        Me.mySettings.ButtonText = "SETTINGS"
        Me.mySettings.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.mySettings.ButtonTextHeight = 14
        Me.mySettings.Clickable = True
        Me.mySettings.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.mySettings.CustomAlertColor = System.Drawing.Color.Empty
        Me.mySettings.Data = Nothing
        Me.mySettings.Data2 = Nothing
        Me.mySettings.FlashInterval = 500
        Me.mySettings.holdDraw = False
        Me.mySettings.Lit = True
        Me.mySettings.Location = New System.Drawing.Point(417, 5)
        Me.mySettings.Name = "mySettings"
        Me.mySettings.RedAlert = LCARS.LCARSalert.Normal
        Me.mySettings.Size = New System.Drawing.Size(90, 23)
        Me.mySettings.TabIndex = 32
        Me.mySettings.Tag = "7"
        Me.mySettings.Text = "SETTINGS"
        '
        'myHelp
        '
        Me.myHelp.AutoEllipsis = False
        Me.myHelp.Beeping = False
        Me.myHelp.ButtonText = "HELP"
        Me.myHelp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myHelp.ButtonTextHeight = 14
        Me.myHelp.Clickable = True
        Me.myHelp.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myHelp.CustomAlertColor = System.Drawing.Color.Empty
        Me.myHelp.Data = Nothing
        Me.myHelp.Data2 = Nothing
        Me.myHelp.FlashInterval = 500
        Me.myHelp.holdDraw = False
        Me.myHelp.Lit = True
        Me.myHelp.Location = New System.Drawing.Point(252, 116)
        Me.myHelp.Name = "myHelp"
        Me.myHelp.RedAlert = LCARS.LCARSalert.Normal
        Me.myHelp.Size = New System.Drawing.Size(71, 40)
        Me.myHelp.TabIndex = 83
        Me.myHelp.Tag = "1"
        Me.myHelp.Text = "HELP"
        '
        'myOSK
        '
        Me.myOSK.AutoEllipsis = False
        Me.myOSK.Beeping = False
        Me.myOSK.ButtonText = "OSK"
        Me.myOSK.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myOSK.ButtonTextHeight = 14
        Me.myOSK.Clickable = True
        Me.myOSK.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myOSK.CustomAlertColor = System.Drawing.Color.Empty
        Me.myOSK.Data = Nothing
        Me.myOSK.Data2 = Nothing
        Me.myOSK.FlashInterval = 500
        Me.myOSK.holdDraw = False
        Me.myOSK.Lit = True
        Me.myOSK.Location = New System.Drawing.Point(402, 116)
        Me.myOSK.Name = "myOSK"
        Me.myOSK.RedAlert = LCARS.LCARSalert.Normal
        Me.myOSK.Size = New System.Drawing.Size(73, 40)
        Me.myOSK.TabIndex = 83
        Me.myOSK.Tag = "1"
        Me.myOSK.Text = "OSK"
        '
        'myButtonManager
        '
        Me.myButtonManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myButtonManager.AutoEllipsis = False
        Me.myButtonManager.Beeping = False
        Me.myButtonManager.ButtonText = "MANAGE YOUR PROGRAMS"
        Me.myButtonManager.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.myButtonManager.ButtonTextHeight = 14
        Me.myButtonManager.Clickable = True
        Me.myButtonManager.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.myButtonManager.CustomAlertColor = System.Drawing.Color.Empty
        Me.myButtonManager.Data = Nothing
        Me.myButtonManager.Data2 = Nothing
        Me.myButtonManager.FlashInterval = 500
        Me.myButtonManager.holdDraw = False
        Me.myButtonManager.Lit = True
        Me.myButtonManager.Location = New System.Drawing.Point(557, 574)
        Me.myButtonManager.Name = "myButtonManager"
        Me.myButtonManager.RedAlert = LCARS.LCARSalert.Normal
        Me.myButtonManager.Size = New System.Drawing.Size(238, 20)
        Me.myButtonManager.TabIndex = 70
        Me.myButtonManager.Tag = "5"
        Me.myButtonManager.Text = "MANAGE YOUR PROGRAMS"
        Me.myButtonManager.Visible = False
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.BackColor = System.Drawing.Color.Black
        Me.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlMain.Location = New System.Drawing.Point(250, 162)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(301, 432)
        Me.pnlMain.TabIndex = 75
        '
        'pnlProgs
        '
        Me.pnlProgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlProgs.Controls.Add(Me.myProgsNext)
        Me.pnlProgs.Controls.Add(Me.fbProgramPages)
        Me.pnlProgs.Controls.Add(Me.pnlPrograms)
        Me.pnlProgs.Controls.Add(Me.myProgBack)
        Me.pnlProgs.Controls.Add(Me.myProgsBack)
        Me.pnlProgs.Location = New System.Drawing.Point(6, 162)
        Me.pnlProgs.Name = "pnlProgs"
        Me.pnlProgs.Size = New System.Drawing.Size(238, 432)
        Me.pnlProgs.TabIndex = 73
        Me.pnlProgs.Tag = "9"
        Me.pnlProgs.Visible = False
        '
        'myProgsNext
        '
        Me.myProgsNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myProgsNext.ArrowDirection = LCARS.LCARSarrowDirection.Right
        Me.myProgsNext.AutoEllipsis = Nothing
        Me.myProgsNext.Beeping = False
        Me.myProgsNext.ButtonText = ""
        Me.myProgsNext.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.myProgsNext.ButtonTextHeight = 14
        Me.myProgsNext.Clickable = True
        Me.myProgsNext.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myProgsNext.CustomAlertColor = System.Drawing.Color.Empty
        Me.myProgsNext.Data = Nothing
        Me.myProgsNext.Data2 = Nothing
        Me.myProgsNext.FlashInterval = 500
        Me.myProgsNext.holdDraw = False
        Me.myProgsNext.Lit = True
        Me.myProgsNext.Location = New System.Drawing.Point(198, 389)
        Me.myProgsNext.Name = "myProgsNext"
        Me.myProgsNext.RedAlert = LCARS.LCARSalert.Normal
        Me.myProgsNext.Size = New System.Drawing.Size(40, 40)
        Me.myProgsNext.TabIndex = 25
        Me.myProgsNext.Tag = "0"
        '
        'fbProgramPages
        '
        Me.fbProgramPages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbProgramPages.AutoEllipsis = False
        Me.fbProgramPages.Beeping = False
        Me.fbProgramPages.ButtonText = "1/15"
        Me.fbProgramPages.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fbProgramPages.ButtonTextHeight = -1
        Me.fbProgramPages.Clickable = False
        Me.fbProgramPages.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbProgramPages.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbProgramPages.Data = Nothing
        Me.fbProgramPages.Data2 = Nothing
        Me.fbProgramPages.FlashInterval = 500
        Me.fbProgramPages.holdDraw = False
        Me.fbProgramPages.Lit = True
        Me.fbProgramPages.Location = New System.Drawing.Point(46, 389)
        Me.fbProgramPages.Name = "fbProgramPages"
        Me.fbProgramPages.RedAlert = LCARS.LCARSalert.Normal
        Me.fbProgramPages.Size = New System.Drawing.Size(146, 40)
        Me.fbProgramPages.TabIndex = 24
        Me.fbProgramPages.Tag = "0"
        Me.fbProgramPages.Text = "1/15"
        '
        'pnlPrograms
        '
        Me.pnlPrograms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrograms.Beeping = False
        Me.pnlPrograms.ColorsAvailable = LcarScolor1
        Me.pnlPrograms.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrograms.Name = "pnlPrograms"
        Me.pnlPrograms.Size = New System.Drawing.Size(238, 337)
        Me.pnlPrograms.TabIndex = 23
        '
        'myProgBack
        '
        Me.myProgBack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myProgBack.AutoEllipsis = False
        Me.myProgBack.Beeping = False
        Me.myProgBack.ButtonText = "BACK"
        Me.myProgBack.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.myProgBack.ButtonTextHeight = 14
        Me.myProgBack.Clickable = True
        Me.myProgBack.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.myProgBack.CustomAlertColor = System.Drawing.Color.Empty
        Me.myProgBack.Data = Nothing
        Me.myProgBack.Data2 = Nothing
        Me.myProgBack.FlashInterval = 500
        Me.myProgBack.holdDraw = False
        Me.myProgBack.Lit = True
        Me.myProgBack.Location = New System.Drawing.Point(0, 343)
        Me.myProgBack.Name = "myProgBack"
        Me.myProgBack.RedAlert = LCARS.LCARSalert.Normal
        Me.myProgBack.Size = New System.Drawing.Size(238, 40)
        Me.myProgBack.TabIndex = 46
        Me.myProgBack.Tag = "0"
        Me.myProgBack.Text = "BACK"
        '
        'myProgsBack
        '
        Me.myProgsBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.myProgsBack.ArrowDirection = LCARS.LCARSarrowDirection.Left
        Me.myProgsBack.AutoEllipsis = Nothing
        Me.myProgsBack.Beeping = False
        Me.myProgsBack.ButtonText = ""
        Me.myProgsBack.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.myProgsBack.ButtonTextHeight = 14
        Me.myProgsBack.Clickable = True
        Me.myProgsBack.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myProgsBack.CustomAlertColor = System.Drawing.Color.Empty
        Me.myProgsBack.Data = Nothing
        Me.myProgsBack.Data2 = Nothing
        Me.myProgsBack.FlashInterval = 500
        Me.myProgsBack.holdDraw = False
        Me.myProgsBack.Lit = True
        Me.myProgsBack.Location = New System.Drawing.Point(0, 389)
        Me.myProgsBack.Name = "myProgsBack"
        Me.myProgsBack.RedAlert = LCARS.LCARSalert.Normal
        Me.myProgsBack.Size = New System.Drawing.Size(40, 40)
        Me.myProgsBack.TabIndex = 26
        Me.myProgsBack.Tag = "0"
        '
        'myMusic
        '
        Me.myMusic.AutoEllipsis = False
        Me.myMusic.Beeping = False
        Me.myMusic.ButtonText = "MY MUSIC"
        Me.myMusic.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.myMusic.ButtonTextHeight = 14
        Me.myMusic.Clickable = True
        Me.myMusic.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.myMusic.CustomAlertColor = System.Drawing.Color.Empty
        Me.myMusic.Data = Nothing
        Me.myMusic.Data2 = Nothing
        Me.myMusic.FlashInterval = 500
        Me.myMusic.holdDraw = False
        Me.myMusic.Lit = True
        Me.myMusic.Location = New System.Drawing.Point(102, 5)
        Me.myMusic.Name = "myMusic"
        Me.myMusic.RedAlert = LCARS.LCARSalert.Normal
        Me.myMusic.Size = New System.Drawing.Size(90, 24)
        Me.myMusic.TabIndex = 33
        Me.myMusic.Tag = "8"
        Me.myMusic.Text = "MY MUSIC"
        '
        'MyComp
        '
        Me.MyComp.AutoEllipsis = False
        Me.MyComp.Beeping = False
        Me.MyComp.ButtonText = "MY COMPUTER"
        Me.MyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.MyComp.ButtonTextHeight = 14
        Me.MyComp.Clickable = True
        Me.MyComp.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.MyComp.CustomAlertColor = System.Drawing.Color.Empty
        Me.MyComp.Data = Nothing
        Me.MyComp.Data2 = Nothing
        Me.MyComp.FlashInterval = 500
        Me.MyComp.holdDraw = False
        Me.MyComp.Lit = True
        Me.MyComp.Location = New System.Drawing.Point(6, 5)
        Me.MyComp.Name = "MyComp"
        Me.MyComp.RedAlert = LCARS.LCARSalert.Normal
        Me.MyComp.Size = New System.Drawing.Size(90, 51)
        Me.MyComp.TabIndex = 33
        Me.MyComp.Tag = "8"
        Me.MyComp.Text = "MY COMPUTER"
        '
        'gridUserButtons
        '
        Me.gridUserButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridUserButtons.Beeping = False
        Me.gridUserButtons.ColorsAvailable = LcarScolor2
        Me.gridUserButtons.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Horizontal
        Me.gridUserButtons.ControlPadding = 5
        Me.gridUserButtons.ControlSize = New System.Drawing.Size(100, 25)
        Me.gridUserButtons.CurrentPage = 1
        Me.gridUserButtons.Location = New System.Drawing.Point(557, 162)
        Me.gridUserButtons.MinimumSize = New System.Drawing.Size(105, 30)
        Me.gridUserButtons.Name = "gridUserButtons"
        Me.gridUserButtons.Size = New System.Drawing.Size(238, 406)
        Me.gridUserButtons.TabIndex = 71
        Me.gridUserButtons.Visible = False
        '
        'tmrAutoHide
        '
        Me.tmrAutoHide.Enabled = True
        '
        'frmMainscreen4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.pnlMainBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMainscreen4"
        Me.ShowInTaskbar = False
        Me.Text = "Mainscreen 3"
        Me.pnlMainBar.ResumeLayout(False)
        Me.pnlBatt.ResumeLayout(False)
        Me.pnlBatt.PerformLayout()
        Me.pnlTray.ResumeLayout(False)
        Me.pnlProgs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMainBar As System.Windows.Forms.Panel
    Friend WithEvents gridUserButtons As LCARS.Controls.ButtonGrid
    Friend WithEvents myUserButtons As LCARS.Controls.FlatButton
    Friend WithEvents myButtonManager As LCARS.Controls.FlatButton
    Friend WithEvents myStartMenu As LCARS.Controls.FlatButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlApps As System.Windows.Forms.Panel
    Friend WithEvents pnlProgs As System.Windows.Forms.Panel
    Friend WithEvents myAlert As LCARS.Controls.FlatButton
    Friend WithEvents myEngineering As LCARS.Controls.FlatButton
    Friend WithEvents myModeSelect As LCARS.Controls.FlatButton
    Friend WithEvents myDeactivate As LCARS.Controls.FlatButton
    Friend WithEvents pnlPrograms As LCARS.Controls.WindowlessContainer
    Friend WithEvents myDestruct As LCARS.Controls.FlatButton
    Friend WithEvents myProgBack As LCARS.Controls.FlatButton
    Friend WithEvents fbProgramPages As LCARS.Controls.FlatButton
    Friend WithEvents myProgsNext As LCARS.Controls.ArrowButton
    Friend WithEvents myProgsBack As LCARS.Controls.ArrowButton
    Friend WithEvents MyComp As LCARS.Controls.FlatButton
    Friend WithEvents mySettings As LCARS.Controls.FlatButton
    Friend WithEvents myPhoto As LCARS.Controls.FlatButton
    Friend WithEvents tmrAutoHide As System.Windows.Forms.Timer
    Friend WithEvents myDocuments As LCARS.Controls.FlatButton
    Friend WithEvents myPictures As LCARS.Controls.FlatButton
    Friend WithEvents pnlTray As System.Windows.Forms.Panel
    Friend WithEvents HideTrayButton As LCARS.Controls.ArrowButton
    Friend WithEvents myOSK As LCARS.Controls.FlatButton
    Friend WithEvents mySpeech As LCARS.Controls.FlatButton
    Friend WithEvents myClock As LCARS.Controls.FlatButton
    Friend WithEvents showTrayButton As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents pnlBatt As System.Windows.Forms.Panel
    Friend WithEvents fbBatt8 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt10 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt9 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt7 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt6 As LCARS.Controls.FlatButton
    Friend WithEvents fbBattTop As LCARS.Controls.FlatButton
    Friend WithEvents lblBatt As System.Windows.Forms.Label
    Friend WithEvents fbBatt3 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt5 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt4 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt2 As LCARS.Controls.FlatButton
    Friend WithEvents fbBatt1 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton19 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow6 As LCARS.Controls.Elbow
    Friend WithEvents Elbow8 As LCARS.Controls.Elbow
    Friend WithEvents lblPowerSource As System.Windows.Forms.Label
    Friend WithEvents Elbow9 As LCARS.Controls.Elbow
    Friend WithEvents Elbow7 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton15 As LCARS.Controls.FlatButton
    Friend WithEvents myVideos As LCARS.Controls.FlatButton
    Friend WithEvents fbWebBrowser As LCARS.Controls.FlatButton
    Friend WithEvents myHelp As LCARS.Controls.FlatButton
    Friend WithEvents myMusic As LCARS.Controls.FlatButton
    Friend WithEvents myRun As LCARS.Controls.FlatButton
    Friend WithEvents myAlertListButton As LCARS.Controls.ArrowButton
End Class
