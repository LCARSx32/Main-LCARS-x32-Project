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
        Me.tabShortcuts = New LCARS.Controls.x32TabPage
        Me.lstShortcuts = New LCARS.Controls.LCARSList
        Me.fbEdit = New LCARS.Controls.FlatButton
        Me.fbDown = New LCARS.Controls.FlatButton
        Me.fbAddSystem = New LCARS.Controls.FlatButton
        Me.fbAdd = New LCARS.Controls.FlatButton
        Me.fbRemove = New LCARS.Controls.FlatButton
        Me.fbUp = New LCARS.Controls.FlatButton
        Me.xtcView = New LCARS.Controls.x32TabPage
        Me.tglDimHidden = New LCARS.Controls.ToggleButton
        Me.tglColor = New LCARS.Controls.ToggleButton
        Me.tglCheck = New LCARS.Controls.ToggleButton
        Me.tglReparse = New LCARS.Controls.ToggleButton
        Me.tglSystem = New LCARS.Controls.ToggleButton
        Me.tglShowHidden = New LCARS.Controls.ToggleButton
        Me.tabMain = New LCARS.Controls.x32TabPage
        Me.fbClickMode = New LCARS.Controls.FlatButton
        Me.hpDouble = New LCARS.Controls.HalfPillButton
        Me.hpSingle = New LCARS.Controls.HalfPillButton
        Me.txtStartDir = New System.Windows.Forms.TextBox
        Me.lblClickMode = New System.Windows.Forms.Label
        Me.lblStartDir = New System.Windows.Forms.Label
        Me.tcOptions.SuspendLayout()
        Me.tabShortcuts.SuspendLayout()
        Me.xtcView.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbOK
        '
        Me.sbOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.Location = New System.Drawing.Point(12, 346)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.Size = New System.Drawing.Size(101, 30)
        Me.sbOK.TabIndex = 2
        Me.sbOK.Text = "OK"
        '
        'tcOptions
        '
        Me.tcOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcOptions.BackColor = System.Drawing.Color.Black
        Me.tcOptions.Controls.Add(Me.tabShortcuts)
        Me.tcOptions.Controls.Add(Me.xtcView)
        Me.tcOptions.Controls.Add(Me.tabMain)
        Me.tcOptions.Location = New System.Drawing.Point(12, 12)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedTab = Me.tabShortcuts
        Me.tcOptions.Size = New System.Drawing.Size(615, 364)
        Me.tcOptions.TabIndex = 5
        Me.tcOptions.TabPages.Add(Me.tabMain)
        Me.tcOptions.TabPages.Add(Me.xtcView)
        Me.tcOptions.TabPages.Add(Me.tabShortcuts)
        Me.tcOptions.Text = "X32TabControl1"
        '
        'tabShortcuts
        '
        Me.tabShortcuts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabShortcuts.BackColor = System.Drawing.Color.Black
        Me.tabShortcuts.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.tabShortcuts.Controls.Add(Me.lstShortcuts)
        Me.tabShortcuts.Controls.Add(Me.fbEdit)
        Me.tabShortcuts.Controls.Add(Me.fbDown)
        Me.tabShortcuts.Controls.Add(Me.fbAddSystem)
        Me.tabShortcuts.Controls.Add(Me.fbAdd)
        Me.tabShortcuts.Controls.Add(Me.fbRemove)
        Me.tabShortcuts.Controls.Add(Me.fbUp)
        Me.tabShortcuts.Location = New System.Drawing.Point(0, 26)
        Me.tabShortcuts.Name = "tabShortcuts"
        Me.tabShortcuts.Size = New System.Drawing.Size(505, 338)
        Me.tabShortcuts.TabIndex = 5
        Me.tabShortcuts.Text = "MANAGE SHORTCUTS"
        '
        'lstShortcuts
        '
        Me.lstShortcuts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstShortcuts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstShortcuts.FormattingEnabled = True
        Me.lstShortcuts.ItemHeight = 25
        Me.lstShortcuts.Location = New System.Drawing.Point(0, 0)
        Me.lstShortcuts.Name = "lstShortcuts"
        Me.lstShortcuts.Size = New System.Drawing.Size(505, 252)
        Me.lstShortcuts.TabIndex = 2
        Me.lstShortcuts.TabStops = New Single() {150.0!}
        '
        'fbEdit
        '
        Me.fbEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbEdit.ButtonText = "EDIT"
        Me.fbEdit.Location = New System.Drawing.Point(243, 272)
        Me.fbEdit.Name = "fbEdit"
        Me.fbEdit.Size = New System.Drawing.Size(75, 26)
        Me.fbEdit.TabIndex = 1
        Me.fbEdit.Text = "EDIT"
        '
        'fbDown
        '
        Me.fbDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbDown.ButtonText = "MOVE DOWN"
        Me.fbDown.Location = New System.Drawing.Point(405, 272)
        Me.fbDown.Name = "fbDown"
        Me.fbDown.Size = New System.Drawing.Size(75, 26)
        Me.fbDown.TabIndex = 1
        Me.fbDown.Text = "MOVE DOWN"
        '
        'fbAddSystem
        '
        Me.fbAddSystem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbAddSystem.ButtonText = "ADD SYSTEM"
        Me.fbAddSystem.Location = New System.Drawing.Point(81, 272)
        Me.fbAddSystem.Name = "fbAddSystem"
        Me.fbAddSystem.Size = New System.Drawing.Size(75, 26)
        Me.fbAddSystem.TabIndex = 1
        Me.fbAddSystem.Text = "ADD SYSTEM"
        '
        'fbAdd
        '
        Me.fbAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbAdd.ButtonText = "ADD"
        Me.fbAdd.Location = New System.Drawing.Point(0, 272)
        Me.fbAdd.Name = "fbAdd"
        Me.fbAdd.Size = New System.Drawing.Size(75, 26)
        Me.fbAdd.TabIndex = 1
        Me.fbAdd.Text = "ADD"
        '
        'fbRemove
        '
        Me.fbRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbRemove.ButtonText = "REMOVE"
        Me.fbRemove.Location = New System.Drawing.Point(162, 272)
        Me.fbRemove.Name = "fbRemove"
        Me.fbRemove.Size = New System.Drawing.Size(75, 26)
        Me.fbRemove.TabIndex = 1
        Me.fbRemove.Text = "REMOVE"
        '
        'fbUp
        '
        Me.fbUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbUp.ButtonText = "MOVE UP"
        Me.fbUp.Location = New System.Drawing.Point(324, 272)
        Me.fbUp.Name = "fbUp"
        Me.fbUp.Size = New System.Drawing.Size(75, 26)
        Me.fbUp.TabIndex = 1
        Me.fbUp.Text = "MOVE UP"
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
        Me.xtcView.ForeColor = System.Drawing.Color.Orange
        Me.xtcView.Location = New System.Drawing.Point(0, 26)
        Me.xtcView.Name = "xtcView"
        Me.xtcView.Size = New System.Drawing.Size(505, 338)
        Me.xtcView.TabIndex = 7
        Me.xtcView.Text = "VIEW"
        '
        'tglDimHidden
        '
        Me.tglDimHidden.ButtonText = "DIM HIDDEN FILES"
        Me.tglDimHidden.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.tglDimHidden.Location = New System.Drawing.Point(7, 195)
        Me.tglDimHidden.Name = "tglDimHidden"
        Me.tglDimHidden.SideText = "ON"
        Me.tglDimHidden.Size = New System.Drawing.Size(239, 33)
        Me.tglDimHidden.TabIndex = 0
        Me.tglDimHidden.Text = "DIM HIDDEN FILES"
        '
        'tglColor
        '
        Me.tglColor.ButtonText = "COLOR FILES BY EXTENSION"
        Me.tglColor.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.tglColor.Location = New System.Drawing.Point(7, 156)
        Me.tglColor.Name = "tglColor"
        Me.tglColor.SideText = "ON"
        Me.tglColor.Size = New System.Drawing.Size(239, 33)
        Me.tglColor.TabIndex = 0
        Me.tglColor.Text = "COLOR FILES BY EXTENSION"
        '
        'tglCheck
        '
        Me.tglCheck.ButtonText = "HIDE INACCESSIBLE DIRECTORIES"
        Me.tglCheck.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.tglCheck.Location = New System.Drawing.Point(7, 117)
        Me.tglCheck.Name = "tglCheck"
        Me.tglCheck.SideText = "ON"
        Me.tglCheck.Size = New System.Drawing.Size(239, 33)
        Me.tglCheck.TabIndex = 0
        Me.tglCheck.Text = "HIDE INACCESSIBLE DIRECTORIES"
        '
        'tglReparse
        '
        Me.tglReparse.ButtonText = "SHOW REPARSE POINTS"
        Me.tglReparse.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglReparse.Location = New System.Drawing.Point(7, 78)
        Me.tglReparse.Name = "tglReparse"
        Me.tglReparse.SideText = "ON"
        Me.tglReparse.Size = New System.Drawing.Size(239, 33)
        Me.tglReparse.TabIndex = 0
        Me.tglReparse.Text = "SHOW REPARSE POINTS"
        '
        'tglSystem
        '
        Me.tglSystem.ButtonText = "SHOW SYSTEM ITEMS"
        Me.tglSystem.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglSystem.Location = New System.Drawing.Point(7, 39)
        Me.tglSystem.Name = "tglSystem"
        Me.tglSystem.SideText = "ON"
        Me.tglSystem.Size = New System.Drawing.Size(239, 33)
        Me.tglSystem.TabIndex = 0
        Me.tglSystem.Text = "SHOW SYSTEM ITEMS"
        '
        'tglShowHidden
        '
        Me.tglShowHidden.ButtonText = "SHOW HIDDEN ITEMS"
        Me.tglShowHidden.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tglShowHidden.Location = New System.Drawing.Point(7, 0)
        Me.tglShowHidden.Name = "tglShowHidden"
        Me.tglShowHidden.SideText = "ON"
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
        Me.tabMain.Size = New System.Drawing.Size(505, 338)
        Me.tabMain.TabIndex = 4
        Me.tabMain.Text = "MAIN OPTIONS"
        '
        'fbClickMode
        '
        Me.fbClickMode.ButtonText = ""
        Me.fbClickMode.Clickable = False
        Me.fbClickMode.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.fbClickMode.Location = New System.Drawing.Point(7, 91)
        Me.fbClickMode.Name = "fbClickMode"
        Me.fbClickMode.Size = New System.Drawing.Size(25, 25)
        Me.fbClickMode.TabIndex = 6
        '
        'hpDouble
        '
        Me.hpDouble.ButtonText = "DOUBLE CLICK"
        Me.hpDouble.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpDouble.Location = New System.Drawing.Point(38, 122)
        Me.hpDouble.Name = "hpDouble"
        Me.hpDouble.Size = New System.Drawing.Size(130, 25)
        Me.hpDouble.TabIndex = 5
        Me.hpDouble.Text = "DOUBLE CLICK"
        '
        'hpSingle
        '
        Me.hpSingle.ButtonText = "SINGLE CLICK"
        Me.hpSingle.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpSingle.Location = New System.Drawing.Point(38, 91)
        Me.hpSingle.Name = "hpSingle"
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
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(639, 388)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.tcOptions)
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOptions"
        Me.tcOptions.ResumeLayout(False)
        Me.tcOptions.PerformLayout()
        Me.tabShortcuts.ResumeLayout(False)
        Me.xtcView.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents lblStartDir As System.Windows.Forms.Label
    Friend WithEvents txtStartDir As System.Windows.Forms.TextBox
    Friend WithEvents tcOptions As LCARS.Controls.x32TabControl
    Friend WithEvents tabMain As LCARS.Controls.x32TabPage
    Friend WithEvents tabShortcuts As LCARS.Controls.x32TabPage
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
    Friend WithEvents lstShortcuts As LCARS.Controls.LCARSList
    Friend WithEvents fbAddSystem As LCARS.Controls.FlatButton
End Class
