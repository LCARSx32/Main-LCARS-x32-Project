<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenChooserDialog
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
        Me.gridScreens = New LCARS.Controls.ButtonGrid
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.btnOK = New LCARS.Controls.StandardButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.SuspendLayout()
        '
        'gridScreens
        '
        Me.gridScreens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridScreens.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Horizontal
        Me.gridScreens.ControlSize = New System.Drawing.Size(210, 150)
        Me.gridScreens.Location = New System.Drawing.Point(13, 41)
        Me.gridScreens.MinimumSize = New System.Drawing.Size(215, 155)
        Me.gridScreens.Name = "gridScreens"
        Me.gridScreens.Size = New System.Drawing.Size(436, 356)
        Me.gridScreens.TabIndex = 3
        Me.gridScreens.Text = "ButtonGrid1"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.Location = New System.Drawing.Point(215, 403)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(114, 31)
        Me.sbCancel.TabIndex = 2
        Me.sbCancel.Text = "CANCEL"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.ButtonText = "SELECT SCREEN"
        Me.btnOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.btnOK.Location = New System.Drawing.Point(335, 403)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(114, 31)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "SELECT SCREEN"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.ButtonText = "INTERFACE SELECTOR"
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.Clickable = False
        Me.tbTitle.Location = New System.Drawing.Point(12, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(437, 24)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "INTERFACE SELECTOR"
        '
        'ScreenChooserDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(461, 446)
        Me.Controls.Add(Me.gridScreens)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tbTitle)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScreenChooserDialog"
        Me.Text = "Interface Selector"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents btnOK As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents gridScreens As LCARS.Controls.ButtonGrid
End Class
