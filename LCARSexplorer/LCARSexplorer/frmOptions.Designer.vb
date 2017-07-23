<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.tcOptions = New LCARS.Controls.x32TabControl
        Me.xtcView = CType(New LCARS.Controls.x32TabPage, LCARS.Controls.x32TabPage)
        Me.tglDimHidden = New LCARS.Controls.ToggleButton
        Me.tglColor = New LCARS.Controls.ToggleButton
        Me.tglCheck = New LCARS.Controls.ToggleButton
        Me.tglReparse = New LCARS.Controls.ToggleButton
        Me.tglSystem = New LCARS.Controls.ToggleButton
        Me.tglShowHidden = New LCARS.Controls.ToggleButton
        Me.tabMain = CType(New LCARS.Controls.x32TabPage, LCARS.Controls.x32TabPage)
        Me.fbClickMode = New LCARS.Controls.FlatButton
        Me.hpDouble = New LCARS.Controls.HalfPillButton
        Me.hpSingle = New LCARS.Controls.HalfPillButton
        Me.txtStartDir = New System.Windows.Forms.TextBox
        Me.lblClickMode = New System.Windows.Forms.Label
        Me.lblStartDir = New System.Windows.Forms.Label
        Me.tabShortcuts = CType(New LCARS.Controls.x32TabPage, LCARS.Controls.x32TabPage)
        Me.fbEdit = New LCARS.Controls.FlatButton
        Me.fbDown = New LCARS.Controls.FlatButton
        Me.fbAdd = New LCARS.Controls.FlatButton
        Me.fbRemove = New LCARS.Controls.FlatButton
        Me.fbUp = New LCARS.Controls.FlatButton
        Me.lstShortcutNames = New System.Windows.Forms.ListBox
        Me.lstShortcuts = New System.Windows.Forms.ListBox
        Me.tcOptions.SuspendLayout()
        Me.xtcView.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabShortcuts.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbOK
        '
        Me.sbOK.Beeping = False
        Me.sbOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.ButtonTextHeight = 14
        Me.sbOK.Clickable = True
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOK.Data = Nothing
        Me.sbOK.Data2 = Nothing
        Me.sbOK.FlashInterval = 500
        Me.sbOK.holdDraw = False
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(12, 288)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(101, 30)
        Me.sbOK.TabIndex = 2
        Me.sbOK.Text = "OK"
        '
        'tcOptions
        '
        Me.tcOptions.BackColor = System.Drawing.Color.Black
        Me.tcOptions.Controls.Add(Me.xtcView)
        Me.tcOptions.Controls.Add(Me.tabMain)
        Me.tcOptions.Controls.Add(Me.tabShortcuts)
        Me.tcOptions.Location = New System.Drawing.Point(12, 12)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedTab = Me.xtcView
        Me.tcOptions.Size = New System.Drawing.Size(511, 306)
        Me.tcOptions.TabIndex = 5
        Me.tcOptions.TabPages.Add(Me.tabMain)
        Me.tcOptions.TabPages.Add(Me.xtcView)
        Me.tcOptions.TabPages.Add(Me.tabShortcuts)
        Me.tcOptions.Text = "X32TabControl1"
        '
        'xtcView
        '
        Me.xtcView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xtcView.BackColor = System.Drawing.Color.Black
        Me.xtcView.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.xtcView.Controls.Add(Me.tglDimHidden)
        Me.xtcView.Controls.Add(Me.tglColor)
        Me.xtcView.Controls.Add(Me.tglCheck)
        Me.xtcView.Controls.Add(Me.tglReparse)
        Me.xtcView.Controls.Add(Me.tglSystem)
        Me.xtcView.Controls.Add(Me.tglShowHidden)
        Me.xtcView.Location = New System.Drawing.Point(0, 26)
        Me.xtcView.Name = "xtcView"
        Me.xtcView.Size = New System.Drawing.Size(401, 280)
        Me.xtcView.TabIndex = 7
        Me.xtcView.Text = "VIEW"
        '
        'tglDimHidden
        '
        Me.tglDimHidden.Beeping = False
        Me.tglDimHidden.ButtonText = "DIM HIDDEN FILES"
        Me.tglDimHidden.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglDimHidden.ButtonTextHeight = 14
        Me.tglDimHidden.Clickable = True
        Me.tglDimHidden.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.tglDimHidden.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglDimHidden.Data = Nothing
        Me.tglDimHidden.Data2 = Nothing
        Me.tglDimHidden.FlashInterval = 500
        Me.tglDimHidden.holdDraw = False
        Me.tglDimHidden.Lit = True
        Me.tglDimHidden.Location = New System.Drawing.Point(7, 195)
        Me.tglDimHidden.Name = "tglDimHidden"
        Me.tglDimHidden.RedAlert = LCARS.LCARSalert.Normal
        Me.tglDimHidden.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglDimHidden.SideText = "ON"
        Me.tglDimHidden.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglDimHidden.SideTextWidth = -1
        Me.tglDimHidden.Size = New System.Drawing.Size(239, 33)
        Me.tglDimHidden.TabIndex = 0
        Me.tglDimHidden.Text = "DIM HIDDEN FILES"
        '
        'tglColor
        '
        Me.tglColor.Beeping = False
        Me.tglColor.ButtonText = "COLOR FILES BY EXTENSION"
        Me.tglColor.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglColor.ButtonTextHeight = 14
        Me.tglColor.Clickable = True
        Me.tglColor.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.tglColor.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglColor.Data = Nothing
        Me.tglColor.Data2 = Nothing
        Me.tglColor.FlashInterval = 500
        Me.tglColor.holdDraw = False
        Me.tglColor.Lit = True
        Me.tglColor.Location = New System.Drawing.Point(7, 156)
        Me.tglColor.Name = "tglColor"
        Me.tglColor.RedAlert = LCARS.LCARSalert.Normal
        Me.tglColor.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglColor.SideText = "ON"
        Me.tglColor.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglColor.SideTextWidth = -1
        Me.tglColor.Size = New System.Drawing.Size(239, 33)
        Me.tglColor.TabIndex = 0
        Me.tglColor.Text = "COLOR FILES BY EXTENSION"
        '
        'tglCheck
        '
        Me.tglCheck.Beeping = False
        Me.tglCheck.ButtonText = "HIDE INACCESSIBLE DIRECTORIES"
        Me.tglCheck.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglCheck.ButtonTextHeight = 14
        Me.tglCheck.Clickable = True
        Me.tglCheck.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.tglCheck.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglCheck.Data = Nothing
        Me.tglCheck.Data2 = Nothing
        Me.tglCheck.FlashInterval = 500
        Me.tglCheck.holdDraw = False
        Me.tglCheck.Lit = True
        Me.tglCheck.Location = New System.Drawing.Point(7, 117)
        Me.tglCheck.Name = "tglCheck"
        Me.tglCheck.RedAlert = LCARS.LCARSalert.Normal
        Me.tglCheck.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglCheck.SideText = "ON"
        Me.tglCheck.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglCheck.SideTextWidth = -1
        Me.tglCheck.Size = New System.Drawing.Size(239, 33)
        Me.tglCheck.TabIndex = 0
        Me.tglCheck.Text = "HIDE INACCESSIBLE DIRECTORIES"
        '
        'tglReparse
        '
        Me.tglReparse.Beeping = False
        Me.tglReparse.ButtonText = "SHOW REPARSE POINTS"
        Me.tglReparse.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglReparse.ButtonTextHeight = 14
        Me.tglReparse.Clickable = True
        Me.tglReparse.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglReparse.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglReparse.Data = Nothing
        Me.tglReparse.Data2 = Nothing
        Me.tglReparse.FlashInterval = 500
        Me.tglReparse.holdDraw = False
        Me.tglReparse.Lit = True
        Me.tglReparse.Location = New System.Drawing.Point(7, 78)
        Me.tglReparse.Name = "tglReparse"
        Me.tglReparse.RedAlert = LCARS.LCARSalert.Normal
        Me.tglReparse.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglReparse.SideText = "ON"
        Me.tglReparse.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglReparse.SideTextWidth = -1
        Me.tglReparse.Size = New System.Drawing.Size(239, 33)
        Me.tglReparse.TabIndex = 0
        Me.tglReparse.Text = "SHOW REPARSE POINTS"
        '
        'tglSystem
        '
        Me.tglSystem.Beeping = False
        Me.tglSystem.ButtonText = "SHOW SYSTEM ITEMS"
        Me.tglSystem.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglSystem.ButtonTextHeight = 14
        Me.tglSystem.Clickable = True
        Me.tglSystem.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglSystem.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglSystem.Data = Nothing
        Me.tglSystem.Data2 = Nothing
        Me.tglSystem.FlashInterval = 500
        Me.tglSystem.holdDraw = False
        Me.tglSystem.Lit = True
        Me.tglSystem.Location = New System.Drawing.Point(7, 39)
        Me.tglSystem.Name = "tglSystem"
        Me.tglSystem.RedAlert = LCARS.LCARSalert.Normal
        Me.tglSystem.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglSystem.SideText = "ON"
        Me.tglSystem.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglSystem.SideTextWidth = -1
        Me.tglSystem.Size = New System.Drawing.Size(239, 33)
        Me.tglSystem.TabIndex = 0
        Me.tglSystem.Text = "SHOW SYSTEM ITEMS"
        '
        'tglShowHidden
        '
        Me.tglShowHidden.Beeping = False
        Me.tglShowHidden.ButtonText = "SHOW HIDDEN ITEMS"
        Me.tglShowHidden.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tglShowHidden.ButtonTextHeight = 14
        Me.tglShowHidden.Clickable = True
        Me.tglShowHidden.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglShowHidden.CustomAlertColor = System.Drawing.Color.Empty
        Me.tglShowHidden.Data = Nothing
        Me.tglShowHidden.Data2 = Nothing
        Me.tglShowHidden.FlashInterval = 500
        Me.tglShowHidden.holdDraw = False
        Me.tglShowHidden.Lit = True
        Me.tglShowHidden.Location = New System.Drawing.Point(7, 0)
        Me.tglShowHidden.Name = "tglShowHidden"
        Me.tglShowHidden.RedAlert = LCARS.LCARSalert.Normal
        Me.tglShowHidden.SideBlockColor = LCARS.LCARScolorStyles.Orange
        Me.tglShowHidden.SideText = "ON"
        Me.tglShowHidden.SideTextColor = LCARS.LCARScolorStyles.Orange
        Me.tglShowHidden.SideTextWidth = -1
        Me.tglShowHidden.Size = New System.Drawing.Size(239, 33)
        Me.tglShowHidden.TabIndex = 0
        Me.tglShowHidden.Text = "SHOW HIDDEN ITEMS"
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.BackColor = System.Drawing.Color.Black
        Me.tabMain.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tabMain.Controls.Add(Me.fbClickMode)
        Me.tabMain.Controls.Add(Me.hpDouble)
        Me.tabMain.Controls.Add(Me.hpSingle)
        Me.tabMain.Controls.Add(Me.txtStartDir)
        Me.tabMain.Controls.Add(Me.lblClickMode)
        Me.tabMain.Controls.Add(Me.lblStartDir)
        Me.tabMain.Location = New System.Drawing.Point(0, 26)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Size = New System.Drawing.Size(401, 280)
        Me.tabMain.TabIndex = 4
        Me.tabMain.Text = "MAIN OPTIONS"
        '
        'fbClickMode
        '
        Me.fbClickMode.Beeping = False
        Me.fbClickMode.ButtonText = ""
        Me.fbClickMode.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbClickMode.ButtonTextHeight = 14
        Me.fbClickMode.Clickable = False
        Me.fbClickMode.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.fbClickMode.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbClickMode.Data = Nothing
        Me.fbClickMode.Data2 = Nothing
        Me.fbClickMode.FlashInterval = 500
        Me.fbClickMode.holdDraw = False
        Me.fbClickMode.Lit = True
        Me.fbClickMode.Location = New System.Drawing.Point(7, 91)
        Me.fbClickMode.Name = "fbClickMode"
        Me.fbClickMode.RedAlert = LCARS.LCARSalert.Normal
        Me.fbClickMode.Size = New System.Drawing.Size(25, 25)
        Me.fbClickMode.TabIndex = 6
        '
        'hpDouble
        '
        Me.hpDouble.Beeping = False
        Me.hpDouble.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpDouble.ButtonText = "DOUBLE CLICK"
        Me.hpDouble.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.hpDouble.ButtonTextHeight = 14
        Me.hpDouble.Clickable = True
        Me.hpDouble.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpDouble.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpDouble.Data = Nothing
        Me.hpDouble.Data2 = Nothing
        Me.hpDouble.FlashInterval = 500
        Me.hpDouble.holdDraw = False
        Me.hpDouble.Lit = True
        Me.hpDouble.Location = New System.Drawing.Point(38, 122)
        Me.hpDouble.Name = "hpDouble"
        Me.hpDouble.RedAlert = LCARS.LCARSalert.Normal
        Me.hpDouble.Size = New System.Drawing.Size(130, 25)
        Me.hpDouble.TabIndex = 5
        Me.hpDouble.Text = "DOUBLE CLICK"
        '
        'hpSingle
        '
        Me.hpSingle.Beeping = False
        Me.hpSingle.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpSingle.ButtonText = "SINGLE CLICK"
        Me.hpSingle.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.hpSingle.ButtonTextHeight = 14
        Me.hpSingle.Clickable = True
        Me.hpSingle.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpSingle.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpSingle.Data = Nothing
        Me.hpSingle.Data2 = Nothing
        Me.hpSingle.FlashInterval = 500
        Me.hpSingle.holdDraw = False
        Me.hpSingle.Lit = True
        Me.hpSingle.Location = New System.Drawing.Point(38, 91)
        Me.hpSingle.Name = "hpSingle"
        Me.hpSingle.RedAlert = LCARS.LCARSalert.Normal
        Me.hpSingle.Size = New System.Drawing.Size(130, 25)
        Me.hpSingle.TabIndex = 5
        Me.hpSingle.Text = "SINGLE CLICK"
        '
        'txtStartDir
        '
        Me.txtStartDir.BackColor = System.Drawing.Color.Black
        Me.txtStartDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartDir.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDir.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtStartDir.Location = New System.Drawing.Point(4, 24)
        Me.txtStartDir.Name = "txtStartDir"
        Me.txtStartDir.Size = New System.Drawing.Size(284, 29)
        Me.txtStartDir.TabIndex = 4
        '
        'lblClickMode
        '
        Me.lblClickMode.AutoSize = True
        Me.lblClickMode.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClickMode.ForeColor = System.Drawing.Color.Orange
        Me.lblClickMode.Location = New System.Drawing.Point(3, 66)
        Me.lblClickMode.Name = "lblClickMode"
        Me.lblClickMode.Size = New System.Drawing.Size(59, 21)
        Me.lblClickMode.TabIndex = 3
        Me.lblClickMode.Text = "Click Mode"
        '
        'lblStartDir
        '
        Me.lblStartDir.AutoSize = True
        Me.lblStartDir.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDir.ForeColor = System.Drawing.Color.Orange
        Me.lblStartDir.Location = New System.Drawing.Point(3, 0)
        Me.lblStartDir.Name = "lblStartDir"
        Me.lblStartDir.Size = New System.Drawing.Size(80, 21)
        Me.lblStartDir.TabIndex = 3
        Me.lblStartDir.Text = "Start Directory:"
        '
        'tabShortcuts
        '
        Me.tabShortcuts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabShortcuts.BackColor = System.Drawing.Color.Black
        Me.tabShortcuts.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.tabShortcuts.Controls.Add(Me.fbEdit)
        Me.tabShortcuts.Controls.Add(Me.fbDown)
        Me.tabShortcuts.Controls.Add(Me.fbAdd)
        Me.tabShortcuts.Controls.Add(Me.fbRemove)
        Me.tabShortcuts.Controls.Add(Me.fbUp)
        Me.tabShortcuts.Controls.Add(Me.lstShortcutNames)
        Me.tabShortcuts.Controls.Add(Me.lstShortcuts)
        Me.tabShortcuts.Location = New System.Drawing.Point(0, 26)
        Me.tabShortcuts.Name = "tabShortcuts"
        Me.tabShortcuts.Size = New System.Drawing.Size(401, 280)
        Me.tabShortcuts.TabIndex = 5
        Me.tabShortcuts.Text = "MANAGE SHORTCUTS"
        '
        'fbEdit
        '
        Me.fbEdit.Beeping = False
        Me.fbEdit.ButtonText = "EDIT"
        Me.fbEdit.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbEdit.ButtonTextHeight = 14
        Me.fbEdit.Clickable = True
        Me.fbEdit.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbEdit.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbEdit.Data = Nothing
        Me.fbEdit.Data2 = Nothing
        Me.fbEdit.FlashInterval = 500
        Me.fbEdit.holdDraw = False
        Me.fbEdit.Lit = True
        Me.fbEdit.Location = New System.Drawing.Point(162, 214)
        Me.fbEdit.Name = "fbEdit"
        Me.fbEdit.RedAlert = LCARS.LCARSalert.Normal
        Me.fbEdit.Size = New System.Drawing.Size(75, 26)
        Me.fbEdit.TabIndex = 1
        Me.fbEdit.Text = "EDIT"
        '
        'fbDown
        '
        Me.fbDown.Beeping = False
        Me.fbDown.ButtonText = "MOVE DOWN"
        Me.fbDown.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbDown.ButtonTextHeight = 14
        Me.fbDown.Clickable = True
        Me.fbDown.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbDown.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbDown.Data = Nothing
        Me.fbDown.Data2 = Nothing
        Me.fbDown.FlashInterval = 500
        Me.fbDown.holdDraw = False
        Me.fbDown.Lit = True
        Me.fbDown.Location = New System.Drawing.Point(324, 214)
        Me.fbDown.Name = "fbDown"
        Me.fbDown.RedAlert = LCARS.LCARSalert.Normal
        Me.fbDown.Size = New System.Drawing.Size(75, 26)
        Me.fbDown.TabIndex = 1
        Me.fbDown.Text = "MOVE DOWN"
        '
        'fbAdd
        '
        Me.fbAdd.Beeping = False
        Me.fbAdd.ButtonText = "ADD"
        Me.fbAdd.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbAdd.ButtonTextHeight = 14
        Me.fbAdd.Clickable = True
        Me.fbAdd.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbAdd.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbAdd.Data = Nothing
        Me.fbAdd.Data2 = Nothing
        Me.fbAdd.FlashInterval = 500
        Me.fbAdd.holdDraw = False
        Me.fbAdd.Lit = True
        Me.fbAdd.Location = New System.Drawing.Point(0, 214)
        Me.fbAdd.Name = "fbAdd"
        Me.fbAdd.RedAlert = LCARS.LCARSalert.Normal
        Me.fbAdd.Size = New System.Drawing.Size(75, 26)
        Me.fbAdd.TabIndex = 1
        Me.fbAdd.Text = "ADD"
        '
        'fbRemove
        '
        Me.fbRemove.Beeping = False
        Me.fbRemove.ButtonText = "REMOVE"
        Me.fbRemove.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbRemove.ButtonTextHeight = 14
        Me.fbRemove.Clickable = True
        Me.fbRemove.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbRemove.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbRemove.Data = Nothing
        Me.fbRemove.Data2 = Nothing
        Me.fbRemove.FlashInterval = 500
        Me.fbRemove.holdDraw = False
        Me.fbRemove.Lit = True
        Me.fbRemove.Location = New System.Drawing.Point(81, 214)
        Me.fbRemove.Name = "fbRemove"
        Me.fbRemove.RedAlert = LCARS.LCARSalert.Normal
        Me.fbRemove.Size = New System.Drawing.Size(75, 26)
        Me.fbRemove.TabIndex = 1
        Me.fbRemove.Text = "REMOVE"
        '
        'fbUp
        '
        Me.fbUp.Beeping = False
        Me.fbUp.ButtonText = "MOVE UP"
        Me.fbUp.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbUp.ButtonTextHeight = 14
        Me.fbUp.Clickable = True
        Me.fbUp.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbUp.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbUp.Data = Nothing
        Me.fbUp.Data2 = Nothing
        Me.fbUp.FlashInterval = 500
        Me.fbUp.holdDraw = False
        Me.fbUp.Lit = True
        Me.fbUp.Location = New System.Drawing.Point(243, 214)
        Me.fbUp.Name = "fbUp"
        Me.fbUp.RedAlert = LCARS.LCARSalert.Normal
        Me.fbUp.Size = New System.Drawing.Size(75, 26)
        Me.fbUp.TabIndex = 1
        Me.fbUp.Text = "MOVE UP"
        '
        'lstShortcutNames
        '
        Me.lstShortcutNames.BackColor = System.Drawing.Color.Black
        Me.lstShortcutNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstShortcutNames.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShortcutNames.ForeColor = System.Drawing.Color.Orange
        Me.lstShortcutNames.FormattingEnabled = True
        Me.lstShortcutNames.ItemHeight = 21
        Me.lstShortcutNames.Location = New System.Drawing.Point(0, 4)
        Me.lstShortcutNames.Name = "lstShortcutNames"
        Me.lstShortcutNames.Size = New System.Drawing.Size(121, 170)
        Me.lstShortcutNames.TabIndex = 0
        '
        'lstShortcuts
        '
        Me.lstShortcuts.BackColor = System.Drawing.Color.Black
        Me.lstShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstShortcuts.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShortcuts.ForeColor = System.Drawing.Color.Orange
        Me.lstShortcuts.FormattingEnabled = True
        Me.lstShortcuts.ItemHeight = 21
        Me.lstShortcuts.Location = New System.Drawing.Point(120, 4)
        Me.lstShortcuts.Name = "lstShortcuts"
        Me.lstShortcuts.Size = New System.Drawing.Size(278, 170)
        Me.lstShortcuts.TabIndex = 0
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(535, 330)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.tcOptions)
        Me.ForeColor = System.Drawing.Color.OrangeRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOptions"
        Me.tcOptions.ResumeLayout(False)
        Me.tcOptions.PerformLayout()
        Me.xtcView.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabShortcuts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents lblStartDir As System.Windows.Forms.Label
    Friend WithEvents txtStartDir As System.Windows.Forms.TextBox
    Friend WithEvents tcOptions As LCARS.Controls.x32TabControl
    Friend WithEvents tabMain As LCARS.Controls.x32TabPage
    Friend WithEvents tabShortcuts As LCARS.Controls.x32TabPage
    Friend WithEvents lstShortcuts As System.Windows.Forms.ListBox
    Friend WithEvents lstShortcutNames As System.Windows.Forms.ListBox
    Friend WithEvents fbUp As LCARS.Controls.FlatButton
    Friend WithEvents fbAdd As LCARS.Controls.FlatButton
    Friend WithEvents fbRemove As LCARS.Controls.FlatButton
    Friend WithEvents fbDown As LCARS.Controls.FlatButton
    Friend WithEvents fbEdit As LCARS.Controls.FlatButton
    Friend WithEvents fbClickMode As LCARS.Controls.FlatButton
    Friend WithEvents hpDouble As LCARS.Controls.HalfPillButton
    Friend WithEvents hpSingle As LCARS.Controls.HalfPillButton
    Friend WithEvents lblClickMode As System.Windows.Forms.Label
    Friend WithEvents xtcView As LCARS.Controls.x32TabPage
    Friend WithEvents tglCheck As LCARS.Controls.ToggleButton
    Friend WithEvents tglReparse As LCARS.Controls.ToggleButton
    Friend WithEvents tglSystem As LCARS.Controls.ToggleButton
    Friend WithEvents tglShowHidden As LCARS.Controls.ToggleButton
    Friend WithEvents tglColor As LCARS.Controls.ToggleButton
    Friend WithEvents tglDimHidden As LCARS.Controls.ToggleButton
End Class
