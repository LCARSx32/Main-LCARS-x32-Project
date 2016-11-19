<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageButtons
    Inherits LCARS.LCARSForm

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
        Me.pnlAddUB = New System.Windows.Forms.Panel
        Me.txtUBLoc = New System.Windows.Forms.TextBox
        Me.txtUBName = New System.Windows.Forms.TextBox
        Me.sbUBaddCancel = New LCARS.Controls.StandardButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.sbUBbrowse = New LCARS.Controls.StandardButton
        Me.sbUBok = New LCARS.Controls.StandardButton
        Me.pnlUBSettings = New System.Windows.Forms.Panel
        Me.sbRemoveUB = New LCARS.Controls.StandardButton
        Me.sbToTop = New LCARS.Controls.StandardButton
        Me.sbUp = New LCARS.Controls.StandardButton
        Me.sbDown = New LCARS.Controls.StandardButton
        Me.sbEditUB = New LCARS.Controls.StandardButton
        Me.lstUserButtons = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.sbExitMyComp = New LCARS.Controls.StandardButton
        Me.sbTitle = New LCARS.Controls.StandardButton
        Me.pnlAddUB.SuspendLayout()
        Me.pnlUBSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAddUB
        '
        Me.pnlAddUB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAddUB.Controls.Add(Me.txtUBLoc)
        Me.pnlAddUB.Controls.Add(Me.txtUBName)
        Me.pnlAddUB.Controls.Add(Me.sbUBaddCancel)
        Me.pnlAddUB.Controls.Add(Me.Label2)
        Me.pnlAddUB.Controls.Add(Me.Label1)
        Me.pnlAddUB.Controls.Add(Me.sbUBbrowse)
        Me.pnlAddUB.Controls.Add(Me.sbUBok)
        Me.pnlAddUB.Location = New System.Drawing.Point(12, 308)
        Me.pnlAddUB.Name = "pnlAddUB"
        Me.pnlAddUB.Size = New System.Drawing.Size(617, 158)
        Me.pnlAddUB.TabIndex = 13
        '
        'txtUBLoc
        '
        Me.txtUBLoc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUBLoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUBLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUBLoc.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUBLoc.ForeColor = System.Drawing.Color.Black
        Me.txtUBLoc.Location = New System.Drawing.Point(0, 80)
        Me.txtUBLoc.Name = "txtUBLoc"
        Me.txtUBLoc.Size = New System.Drawing.Size(532, 29)
        Me.txtUBLoc.TabIndex = 5
        '
        'txtUBName
        '
        Me.txtUBName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUBName.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUBName.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUBName.ForeColor = System.Drawing.Color.Black
        Me.txtUBName.Location = New System.Drawing.Point(0, 24)
        Me.txtUBName.Name = "txtUBName"
        Me.txtUBName.Size = New System.Drawing.Size(532, 29)
        Me.txtUBName.TabIndex = 4
        '
        'sbUBaddCancel
        '
        Me.sbUBaddCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUBaddCancel.AutoEllipsis = False
        Me.sbUBaddCancel.Beeping = False
        Me.sbUBaddCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbUBaddCancel.ButtonText = "DONE"
        Me.sbUBaddCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sbUBaddCancel.ButtonTextHeight = 14
        Me.sbUBaddCancel.Clickable = True
        Me.sbUBaddCancel.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbUBaddCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbUBaddCancel.Data = Nothing
        Me.sbUBaddCancel.Data2 = Nothing
        Me.sbUBaddCancel.FlashInterval = 500
        Me.sbUBaddCancel.holdDraw = False
        Me.sbUBaddCancel.Lit = True
        Me.sbUBaddCancel.Location = New System.Drawing.Point(538, 128)
        Me.sbUBaddCancel.Name = "sbUBaddCancel"
        Me.sbUBaddCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUBaddCancel.Size = New System.Drawing.Size(79, 27)
        Me.sbUBaddCancel.TabIndex = 9
        Me.sbUBaddCancel.Text = "DONE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "NAME:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(3, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "COMMAND:"
        '
        'sbUBbrowse
        '
        Me.sbUBbrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUBbrowse.AutoEllipsis = False
        Me.sbUBbrowse.Beeping = False
        Me.sbUBbrowse.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbUBbrowse.ButtonText = "..."
        Me.sbUBbrowse.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbUBbrowse.ButtonTextHeight = 14
        Me.sbUBbrowse.Clickable = True
        Me.sbUBbrowse.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbUBbrowse.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbUBbrowse.Data = Nothing
        Me.sbUBbrowse.Data2 = Nothing
        Me.sbUBbrowse.FlashInterval = 500
        Me.sbUBbrowse.holdDraw = False
        Me.sbUBbrowse.Lit = True
        Me.sbUBbrowse.Location = New System.Drawing.Point(538, 80)
        Me.sbUBbrowse.Name = "sbUBbrowse"
        Me.sbUBbrowse.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUBbrowse.Size = New System.Drawing.Size(79, 29)
        Me.sbUBbrowse.TabIndex = 6
        Me.sbUBbrowse.Text = "..."
        '
        'sbUBok
        '
        Me.sbUBok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUBok.AutoEllipsis = False
        Me.sbUBok.Beeping = False
        Me.sbUBok.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbUBok.ButtonText = "OK"
        Me.sbUBok.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sbUBok.ButtonTextHeight = 14
        Me.sbUBok.Clickable = True
        Me.sbUBok.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbUBok.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbUBok.Data = Nothing
        Me.sbUBok.Data2 = Nothing
        Me.sbUBok.FlashInterval = 500
        Me.sbUBok.holdDraw = False
        Me.sbUBok.Lit = True
        Me.sbUBok.Location = New System.Drawing.Point(459, 128)
        Me.sbUBok.Name = "sbUBok"
        Me.sbUBok.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUBok.Size = New System.Drawing.Size(73, 27)
        Me.sbUBok.TabIndex = 3
        Me.sbUBok.Text = "OK"
        '
        'pnlUBSettings
        '
        Me.pnlUBSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUBSettings.Controls.Add(Me.sbRemoveUB)
        Me.pnlUBSettings.Controls.Add(Me.sbToTop)
        Me.pnlUBSettings.Controls.Add(Me.sbUp)
        Me.pnlUBSettings.Controls.Add(Me.sbDown)
        Me.pnlUBSettings.Controls.Add(Me.sbEditUB)
        Me.pnlUBSettings.Controls.Add(Me.lstUserButtons)
        Me.pnlUBSettings.Location = New System.Drawing.Point(12, 66)
        Me.pnlUBSettings.Name = "pnlUBSettings"
        Me.pnlUBSettings.Size = New System.Drawing.Size(616, 236)
        Me.pnlUBSettings.TabIndex = 14
        '
        'sbRemoveUB
        '
        Me.sbRemoveUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbRemoveUB.AutoEllipsis = False
        Me.sbRemoveUB.Beeping = False
        Me.sbRemoveUB.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbRemoveUB.ButtonText = "REMOVE"
        Me.sbRemoveUB.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRemoveUB.ButtonTextHeight = 14
        Me.sbRemoveUB.Clickable = True
        Me.sbRemoveUB.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbRemoveUB.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbRemoveUB.Data = Nothing
        Me.sbRemoveUB.Data2 = Nothing
        Me.sbRemoveUB.FlashInterval = 500
        Me.sbRemoveUB.holdDraw = False
        Me.sbRemoveUB.Lit = True
        Me.sbRemoveUB.Location = New System.Drawing.Point(538, 201)
        Me.sbRemoveUB.Name = "sbRemoveUB"
        Me.sbRemoveUB.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRemoveUB.Size = New System.Drawing.Size(79, 32)
        Me.sbRemoveUB.TabIndex = 3
        Me.sbRemoveUB.Text = "REMOVE"
        '
        'sbToTop
        '
        Me.sbToTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbToTop.AutoEllipsis = False
        Me.sbToTop.Beeping = False
        Me.sbToTop.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbToTop.ButtonText = "MOVE TO TOP"
        Me.sbToTop.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbToTop.ButtonTextHeight = 14
        Me.sbToTop.Clickable = True
        Me.sbToTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbToTop.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbToTop.Data = Nothing
        Me.sbToTop.Data2 = Nothing
        Me.sbToTop.FlashInterval = 500
        Me.sbToTop.holdDraw = False
        Me.sbToTop.Lit = True
        Me.sbToTop.Location = New System.Drawing.Point(155, 201)
        Me.sbToTop.Name = "sbToTop"
        Me.sbToTop.RedAlert = LCARS.LCARSalert.Normal
        Me.sbToTop.Size = New System.Drawing.Size(104, 32)
        Me.sbToTop.TabIndex = 2
        Me.sbToTop.Text = "MOVE TO TOP"
        '
        'sbUp
        '
        Me.sbUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUp.AutoEllipsis = False
        Me.sbUp.Beeping = False
        Me.sbUp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbUp.ButtonText = "MOVE UP"
        Me.sbUp.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbUp.ButtonTextHeight = 14
        Me.sbUp.Clickable = True
        Me.sbUp.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbUp.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbUp.Data = Nothing
        Me.sbUp.Data2 = Nothing
        Me.sbUp.FlashInterval = 500
        Me.sbUp.holdDraw = False
        Me.sbUp.Lit = True
        Me.sbUp.Location = New System.Drawing.Point(265, 201)
        Me.sbUp.Name = "sbUp"
        Me.sbUp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUp.Size = New System.Drawing.Size(84, 32)
        Me.sbUp.TabIndex = 2
        Me.sbUp.Text = "MOVE UP"
        '
        'sbDown
        '
        Me.sbDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDown.AutoEllipsis = False
        Me.sbDown.Beeping = False
        Me.sbDown.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbDown.ButtonText = "MOVE DOWN"
        Me.sbDown.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDown.ButtonTextHeight = 14
        Me.sbDown.Clickable = True
        Me.sbDown.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbDown.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDown.Data = Nothing
        Me.sbDown.Data2 = Nothing
        Me.sbDown.FlashInterval = 500
        Me.sbDown.holdDraw = False
        Me.sbDown.Lit = True
        Me.sbDown.Location = New System.Drawing.Point(355, 201)
        Me.sbDown.Name = "sbDown"
        Me.sbDown.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDown.Size = New System.Drawing.Size(98, 32)
        Me.sbDown.TabIndex = 2
        Me.sbDown.Text = "MOVE DOWN"
        '
        'sbEditUB
        '
        Me.sbEditUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbEditUB.AutoEllipsis = False
        Me.sbEditUB.Beeping = False
        Me.sbEditUB.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbEditUB.ButtonText = "EDIT"
        Me.sbEditUB.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbEditUB.ButtonTextHeight = 14
        Me.sbEditUB.Clickable = True
        Me.sbEditUB.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbEditUB.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbEditUB.Data = Nothing
        Me.sbEditUB.Data2 = Nothing
        Me.sbEditUB.FlashInterval = 500
        Me.sbEditUB.holdDraw = False
        Me.sbEditUB.Lit = True
        Me.sbEditUB.Location = New System.Drawing.Point(459, 201)
        Me.sbEditUB.Name = "sbEditUB"
        Me.sbEditUB.RedAlert = LCARS.LCARSalert.Normal
        Me.sbEditUB.Size = New System.Drawing.Size(73, 32)
        Me.sbEditUB.TabIndex = 2
        Me.sbEditUB.Text = "EDIT"
        '
        'lstUserButtons
        '
        Me.lstUserButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstUserButtons.BackColor = System.Drawing.Color.White
        Me.lstUserButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstUserButtons.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstUserButtons.ForeColor = System.Drawing.Color.Black
        Me.lstUserButtons.FormattingEnabled = True
        Me.lstUserButtons.ItemHeight = 28
        Me.lstUserButtons.Location = New System.Drawing.Point(0, 3)
        Me.lstUserButtons.Name = "lstUserButtons"
        Me.lstUserButtons.Size = New System.Drawing.Size(616, 168)
        Me.lstUserButtons.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(249, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Current Personal Buttons:"
        '
        'sbExitMyComp
        '
        Me.sbExitMyComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExitMyComp.AutoEllipsis = False
        Me.sbExitMyComp.Beeping = False
        Me.sbExitMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbExitMyComp.ButtonText = "X"
        Me.sbExitMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExitMyComp.ButtonTextHeight = 14
        Me.sbExitMyComp.Clickable = True
        Me.sbExitMyComp.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbExitMyComp.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbExitMyComp.Data = Nothing
        Me.sbExitMyComp.Data2 = Nothing
        Me.sbExitMyComp.FlashInterval = 500
        Me.sbExitMyComp.holdDraw = False
        Me.sbExitMyComp.Lit = True
        Me.sbExitMyComp.Location = New System.Drawing.Point(596, 3)
        Me.sbExitMyComp.Name = "sbExitMyComp"
        Me.sbExitMyComp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbExitMyComp.Size = New System.Drawing.Size(33, 32)
        Me.sbExitMyComp.TabIndex = 87
        Me.sbExitMyComp.Text = "X"
        '
        'sbTitle
        '
        Me.sbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitle.Beeping = False
        Me.sbTitle.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbTitle.ButtonText = "PERSONAL BUTTONS MANAGER"
        Me.sbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.sbTitle.ButtonTextHeight = 20
        Me.sbTitle.Clickable = True
        Me.sbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbTitle.Data = Nothing
        Me.sbTitle.Data2 = Nothing
        Me.sbTitle.FlashInterval = 500
        Me.sbTitle.holdDraw = False
        Me.sbTitle.Lit = True
        Me.sbTitle.Location = New System.Drawing.Point(12, 3)
        Me.sbTitle.Name = "sbTitle"
        Me.sbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTitle.Size = New System.Drawing.Size(578, 32)
        Me.sbTitle.TabIndex = 88
        Me.sbTitle.Text = "PERSONAL BUTTONS MANAGER"
        '
        'frmManageButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.sbTitle)
        Me.Controls.Add(Me.pnlAddUB)
        Me.Controls.Add(Me.sbExitMyComp)
        Me.Controls.Add(Me.pnlUBSettings)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmManageButtons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PERSONAL BUTTON MANAGER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlAddUB.ResumeLayout(False)
        Me.pnlAddUB.PerformLayout()
        Me.pnlUBSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlAddUB As System.Windows.Forms.Panel
    Friend WithEvents sbUBaddCancel As LCARS.Controls.StandardButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sbUBbrowse As LCARS.Controls.StandardButton
    Friend WithEvents txtUBLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtUBName As System.Windows.Forms.TextBox
    Friend WithEvents sbUBok As LCARS.Controls.StandardButton
    Friend WithEvents pnlUBSettings As System.Windows.Forms.Panel
    Friend WithEvents sbRemoveUB As LCARS.Controls.StandardButton
    Friend WithEvents sbEditUB As LCARS.Controls.StandardButton
    Friend WithEvents lstUserButtons As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sbExitMyComp As LCARS.Controls.StandardButton
    Friend WithEvents sbTitle As LCARS.Controls.StandardButton
    Friend WithEvents sbUp As LCARS.Controls.StandardButton
    Friend WithEvents sbDown As LCARS.Controls.StandardButton
    Friend WithEvents sbToTop As LCARS.Controls.StandardButton
End Class
