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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.sbHidden = New LCARS.Controls.StandardButton
        Me.sbCheck = New LCARS.Controls.StandardButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.lblStartDir = New System.Windows.Forms.Label
        Me.txtStartDir = New System.Windows.Forms.TextBox
        Me.tcOptions = New LCARS.Controls.x32TabControl
        Me.tabMain = New LCARS.Controls.x32TabPage
        Me.fbClickMode = New LCARS.Controls.FlatButton
        Me.hpDouble = New LCARS.Controls.HalfPillButton
        Me.hpSingle = New LCARS.Controls.HalfPillButton
        Me.lblClickMode = New System.Windows.Forms.Label
        Me.tabShortcuts = New LCARS.Controls.x32TabPage
        Me.fbEdit = New LCARS.Controls.FlatButton
        Me.fbDown = New LCARS.Controls.FlatButton
        Me.fbAdd = New LCARS.Controls.FlatButton
        Me.fbRemove = New LCARS.Controls.FlatButton
        Me.fbUp = New LCARS.Controls.FlatButton
        Me.lstShortcutNames = New System.Windows.Forms.ListBox
        Me.lstShortcuts = New System.Windows.Forms.ListBox
        Me.sbColors = New LCARS.Controls.StandardButton
        Me.tcOptions.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabShortcuts.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbHidden
        '
        Me.sbHidden.BackgroundImage = CType(resources.GetObject("sbHidden.BackgroundImage"), System.Drawing.Image)
        Me.sbHidden.Beeping = False
        Me.sbHidden.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbHidden.ButtonText = "SHOW HIDDEN FILES AND FOLDERS"
        Me.sbHidden.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbHidden.ButtonTextHeight = 14
        Me.sbHidden.Clickable = False
        Me.sbHidden.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.sbHidden.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbHidden.Data = Nothing
        Me.sbHidden.Data2 = Nothing
        Me.sbHidden.FlashInterval = 500
        Me.sbHidden.holdDraw = False
        Me.sbHidden.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbHidden.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbHidden.lblTextSize = New System.Drawing.Point(164, 30)
        Me.sbHidden.lblTextVisible = True
        Me.sbHidden.Lit = True
        Me.sbHidden.Location = New System.Drawing.Point(3, 3)
        Me.sbHidden.Name = "sbHidden"
        Me.sbHidden.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHidden.Size = New System.Drawing.Size(194, 30)
        Me.sbHidden.TabIndex = 2
        Me.sbHidden.Text = "SHOW HIDDEN FILES AND FOLDERS"
        Me.sbHidden.Visible = False
        '
        'sbCheck
        '
        Me.sbCheck.BackgroundImage = CType(resources.GetObject("sbCheck.BackgroundImage"), System.Drawing.Image)
        Me.sbCheck.Beeping = False
        Me.sbCheck.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCheck.ButtonText = "CHECK ACCESS "
        Me.sbCheck.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCheck.ButtonTextHeight = 14
        Me.sbCheck.Clickable = True
        Me.sbCheck.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbCheck.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCheck.Data = Nothing
        Me.sbCheck.Data2 = Nothing
        Me.sbCheck.FlashInterval = 500
        Me.sbCheck.holdDraw = False
        Me.sbCheck.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCheck.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbCheck.lblTextSize = New System.Drawing.Point(164, 30)
        Me.sbCheck.lblTextVisible = True
        Me.sbCheck.Lit = True
        Me.sbCheck.Location = New System.Drawing.Point(3, 39)
        Me.sbCheck.Name = "sbCheck"
        Me.sbCheck.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCheck.Size = New System.Drawing.Size(194, 30)
        Me.sbCheck.TabIndex = 2
        Me.sbCheck.Text = "CHECK ACCESS "
        '
        'sbOK
        '
        Me.sbOK.BackgroundImage = CType(resources.GetObject("sbOK.BackgroundImage"), System.Drawing.Image)
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
        Me.sbOK.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOK.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbOK.lblTextSize = New System.Drawing.Point(71, 30)
        Me.sbOK.lblTextVisible = True
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(12, 288)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(101, 30)
        Me.sbOK.TabIndex = 2
        Me.sbOK.Text = "OK"
        '
        'lblStartDir
        '
        Me.lblStartDir.AutoSize = True
        Me.lblStartDir.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDir.ForeColor = System.Drawing.Color.Orange
        Me.lblStartDir.Location = New System.Drawing.Point(3, 77)
        Me.lblStartDir.Name = "lblStartDir"
        Me.lblStartDir.Size = New System.Drawing.Size(80, 21)
        Me.lblStartDir.TabIndex = 3
        Me.lblStartDir.Text = "Start Directory:"
        '
        'txtStartDir
        '
        Me.txtStartDir.BackColor = System.Drawing.Color.Black
        Me.txtStartDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartDir.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDir.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtStartDir.Location = New System.Drawing.Point(4, 101)
        Me.txtStartDir.Name = "txtStartDir"
        Me.txtStartDir.Size = New System.Drawing.Size(284, 29)
        Me.txtStartDir.TabIndex = 4
        '
        'tcOptions
        '
        Me.tcOptions.BackColor = System.Drawing.Color.Black
        Me.tcOptions.Controls.Add(Me.tabMain)
        Me.tcOptions.Controls.Add(Me.tabShortcuts)
        Me.tcOptions.Location = New System.Drawing.Point(12, 12)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedTab = Me.tabMain
        Me.tcOptions.Size = New System.Drawing.Size(511, 306)
        Me.tcOptions.TabIndex = 5
        Me.tcOptions.TabPages.Add(Me.tabMain)
        Me.tcOptions.TabPages.Add(Me.tabShortcuts)
        Me.tcOptions.Text = "X32TabControl1"
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.BackColor = System.Drawing.Color.Black
        Me.tabMain.Controls.Add(Me.sbColors)
        Me.tabMain.Controls.Add(Me.fbClickMode)
        Me.tabMain.Controls.Add(Me.hpDouble)
        Me.tabMain.Controls.Add(Me.hpSingle)
        Me.tabMain.Controls.Add(Me.sbHidden)
        Me.tabMain.Controls.Add(Me.txtStartDir)
        Me.tabMain.Controls.Add(Me.sbCheck)
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
        Me.fbClickMode.BackgroundImage = CType(resources.GetObject("fbClickMode.BackgroundImage"), System.Drawing.Image)
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
        Me.fbClickMode.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbClickMode.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbClickMode.lblTextSize = New System.Drawing.Point(25, 25)
        Me.fbClickMode.lblTextVisible = True
        Me.fbClickMode.Lit = True
        Me.fbClickMode.Location = New System.Drawing.Point(7, 168)
        Me.fbClickMode.Name = "fbClickMode"
        Me.fbClickMode.RedAlert = LCARS.LCARSalert.Normal
        Me.fbClickMode.Size = New System.Drawing.Size(25, 25)
        Me.fbClickMode.TabIndex = 6
        '
        'hpDouble
        '
        Me.hpDouble.BackgroundImage = CType(resources.GetObject("hpDouble.BackgroundImage"), System.Drawing.Image)
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
        Me.hpDouble.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpDouble.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpDouble.lblTextSize = New System.Drawing.Point(130, 25)
        Me.hpDouble.lblTextVisible = True
        Me.hpDouble.Lit = True
        Me.hpDouble.Location = New System.Drawing.Point(38, 199)
        Me.hpDouble.Name = "hpDouble"
        Me.hpDouble.RedAlert = LCARS.LCARSalert.Normal
        Me.hpDouble.Size = New System.Drawing.Size(130, 25)
        Me.hpDouble.TabIndex = 5
        Me.hpDouble.Text = "DOUBLE CLICK"
        '
        'hpSingle
        '
        Me.hpSingle.BackgroundImage = CType(resources.GetObject("hpSingle.BackgroundImage"), System.Drawing.Image)
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
        Me.hpSingle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpSingle.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpSingle.lblTextSize = New System.Drawing.Point(130, 25)
        Me.hpSingle.lblTextVisible = True
        Me.hpSingle.Lit = True
        Me.hpSingle.Location = New System.Drawing.Point(38, 168)
        Me.hpSingle.Name = "hpSingle"
        Me.hpSingle.RedAlert = LCARS.LCARSalert.Normal
        Me.hpSingle.Size = New System.Drawing.Size(130, 25)
        Me.hpSingle.TabIndex = 5
        Me.hpSingle.Text = "SINGLE CLICK"
        '
        'lblClickMode
        '
        Me.lblClickMode.AutoSize = True
        Me.lblClickMode.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClickMode.ForeColor = System.Drawing.Color.Orange
        Me.lblClickMode.Location = New System.Drawing.Point(3, 143)
        Me.lblClickMode.Name = "lblClickMode"
        Me.lblClickMode.Size = New System.Drawing.Size(59, 21)
        Me.lblClickMode.TabIndex = 3
        Me.lblClickMode.Text = "Click Mode"
        '
        'tabShortcuts
        '
        Me.tabShortcuts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabShortcuts.BackColor = System.Drawing.Color.Black
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
        Me.fbEdit.BackgroundImage = CType(resources.GetObject("fbEdit.BackgroundImage"), System.Drawing.Image)
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
        Me.fbEdit.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbEdit.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbEdit.lblTextSize = New System.Drawing.Point(75, 26)
        Me.fbEdit.lblTextVisible = True
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
        Me.fbDown.BackgroundImage = CType(resources.GetObject("fbDown.BackgroundImage"), System.Drawing.Image)
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
        Me.fbDown.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbDown.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbDown.lblTextSize = New System.Drawing.Point(75, 26)
        Me.fbDown.lblTextVisible = True
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
        Me.fbAdd.BackgroundImage = CType(resources.GetObject("fbAdd.BackgroundImage"), System.Drawing.Image)
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
        Me.fbAdd.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbAdd.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbAdd.lblTextSize = New System.Drawing.Point(75, 26)
        Me.fbAdd.lblTextVisible = True
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
        Me.fbRemove.BackgroundImage = CType(resources.GetObject("fbRemove.BackgroundImage"), System.Drawing.Image)
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
        Me.fbRemove.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbRemove.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbRemove.lblTextSize = New System.Drawing.Point(75, 26)
        Me.fbRemove.lblTextVisible = True
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
        Me.fbUp.BackgroundImage = CType(resources.GetObject("fbUp.BackgroundImage"), System.Drawing.Image)
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
        Me.fbUp.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbUp.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbUp.lblTextSize = New System.Drawing.Point(75, 26)
        Me.fbUp.lblTextVisible = True
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
        'sbColors
        '
        Me.sbColors.BackgroundImage = CType(resources.GetObject("sbColors.BackgroundImage"), System.Drawing.Image)
        Me.sbColors.Beeping = False
        Me.sbColors.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbColors.ButtonText = "COLOR FILES BY EXTENSION"
        Me.sbColors.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbColors.ButtonTextHeight = 14
        Me.sbColors.Clickable = True
        Me.sbColors.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbColors.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbColors.Data = Nothing
        Me.sbColors.Data2 = Nothing
        Me.sbColors.FlashInterval = 500
        Me.sbColors.holdDraw = False
        Me.sbColors.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbColors.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbColors.lblTextSize = New System.Drawing.Point(164, 30)
        Me.sbColors.lblTextVisible = True
        Me.sbColors.Lit = True
        Me.sbColors.Location = New System.Drawing.Point(203, 39)
        Me.sbColors.Name = "sbColors"
        Me.sbColors.RedAlert = LCARS.LCARSalert.Normal
        Me.sbColors.Size = New System.Drawing.Size(194, 30)
        Me.sbColors.TabIndex = 7
        Me.sbColors.Text = "COLOR FILES BY EXTENSION"
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
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabShortcuts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbHidden As LCARS.Controls.StandardButton
    Friend WithEvents sbCheck As LCARS.Controls.StandardButton
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
    Friend WithEvents sbColors As LCARS.Controls.StandardButton
End Class
