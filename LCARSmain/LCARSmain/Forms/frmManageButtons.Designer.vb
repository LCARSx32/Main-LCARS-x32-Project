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
        Me.lstUserButtons = New LCARS.Controls.LCARSList
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
        Me.sbUBaddCancel.ButtonText = "DONE"
        Me.sbUBaddCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sbUBaddCancel.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbUBaddCancel.Location = New System.Drawing.Point(538, 128)
        Me.sbUBaddCancel.Name = "sbUBaddCancel"
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
        Me.sbUBbrowse.ButtonText = "..."
        Me.sbUBbrowse.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbUBbrowse.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbUBbrowse.Location = New System.Drawing.Point(538, 80)
        Me.sbUBbrowse.Name = "sbUBbrowse"
        Me.sbUBbrowse.Size = New System.Drawing.Size(79, 29)
        Me.sbUBbrowse.TabIndex = 6
        Me.sbUBbrowse.Text = "..."
        '
        'sbUBok
        '
        Me.sbUBok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUBok.ButtonText = "OK"
        Me.sbUBok.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sbUBok.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbUBok.Location = New System.Drawing.Point(459, 128)
        Me.sbUBok.Name = "sbUBok"
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
        Me.sbRemoveUB.ButtonText = "REMOVE"
        Me.sbRemoveUB.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRemoveUB.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbRemoveUB.Location = New System.Drawing.Point(538, 201)
        Me.sbRemoveUB.Name = "sbRemoveUB"
        Me.sbRemoveUB.Size = New System.Drawing.Size(79, 32)
        Me.sbRemoveUB.TabIndex = 3
        Me.sbRemoveUB.Text = "REMOVE"
        '
        'sbToTop
        '
        Me.sbToTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbToTop.ButtonText = "MOVE TO TOP"
        Me.sbToTop.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbToTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbToTop.Location = New System.Drawing.Point(155, 201)
        Me.sbToTop.Name = "sbToTop"
        Me.sbToTop.Size = New System.Drawing.Size(104, 32)
        Me.sbToTop.TabIndex = 2
        Me.sbToTop.Text = "MOVE TO TOP"
        '
        'sbUp
        '
        Me.sbUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUp.ButtonText = "MOVE UP"
        Me.sbUp.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbUp.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbUp.Location = New System.Drawing.Point(265, 201)
        Me.sbUp.Name = "sbUp"
        Me.sbUp.Size = New System.Drawing.Size(84, 32)
        Me.sbUp.TabIndex = 2
        Me.sbUp.Text = "MOVE UP"
        '
        'sbDown
        '
        Me.sbDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDown.ButtonText = "MOVE DOWN"
        Me.sbDown.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDown.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbDown.Location = New System.Drawing.Point(355, 201)
        Me.sbDown.Name = "sbDown"
        Me.sbDown.Size = New System.Drawing.Size(98, 32)
        Me.sbDown.TabIndex = 2
        Me.sbDown.Text = "MOVE DOWN"
        '
        'sbEditUB
        '
        Me.sbEditUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbEditUB.ButtonText = "EDIT"
        Me.sbEditUB.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbEditUB.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.sbEditUB.Location = New System.Drawing.Point(459, 201)
        Me.sbEditUB.Name = "sbEditUB"
        Me.sbEditUB.Size = New System.Drawing.Size(73, 32)
        Me.sbEditUB.TabIndex = 2
        Me.sbEditUB.Text = "EDIT"
        '
        'lstUserButtons
        '
        Me.lstUserButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstUserButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstUserButtons.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstUserButtons.FormattingEnabled = True
        Me.lstUserButtons.ItemHeight = 28
        Me.lstUserButtons.Location = New System.Drawing.Point(0, 3)
        Me.lstUserButtons.Name = "lstUserButtons"
        Me.lstUserButtons.Size = New System.Drawing.Size(616, 168)
        Me.lstUserButtons.TabIndex = 0
        Me.lstUserButtons.TabStops = New Single(-1) {}
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
        Me.sbExitMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbExitMyComp.ButtonText = "X"
        Me.sbExitMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExitMyComp.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbExitMyComp.Location = New System.Drawing.Point(596, 3)
        Me.sbExitMyComp.Name = "sbExitMyComp"
        Me.sbExitMyComp.Size = New System.Drawing.Size(33, 32)
        Me.sbExitMyComp.TabIndex = 87
        Me.sbExitMyComp.Text = "X"
        '
        'sbTitle
        '
        Me.sbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitle.ButtonText = "PERSONAL BUTTONS MANAGER"
        Me.sbTitle.ButtonTextHeight = 20
        Me.sbTitle.Clickable = False
        Me.sbTitle.Location = New System.Drawing.Point(12, 3)
        Me.sbTitle.Name = "sbTitle"
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
    Friend WithEvents lstUserButtons As LCARS.Controls.LCARSList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sbExitMyComp As LCARS.Controls.StandardButton
    Friend WithEvents sbTitle As LCARS.Controls.StandardButton
    Friend WithEvents sbUp As LCARS.Controls.StandardButton
    Friend WithEvents sbDown As LCARS.Controls.StandardButton
    Friend WithEvents sbToTop As LCARS.Controls.StandardButton
End Class
