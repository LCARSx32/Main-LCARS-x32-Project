<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenChooserDialog
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
        Dim LcarScolor2 As LCARS.LCARScolor = New LCARS.LCARScolor
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
        Me.gridScreens.Beeping = False
        Me.gridScreens.ColorsAvailable = LcarScolor2
        Me.gridScreens.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Horizontal
        Me.gridScreens.ControlPadding = 5
        Me.gridScreens.ControlSize = New System.Drawing.Size(210, 150)
        Me.gridScreens.CurrentPage = 1
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
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(215, 403)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(114, 31)
        Me.sbCancel.TabIndex = 2
        Me.sbCancel.Text = "CANCEL"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Beeping = False
        Me.btnOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.btnOK.ButtonText = "SELECT SCREEN"
        Me.btnOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOK.ButtonTextHeight = 14
        Me.btnOK.Clickable = True
        Me.btnOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.btnOK.CustomAlertColor = System.Drawing.Color.Empty
        Me.btnOK.Data = Nothing
        Me.btnOK.Data2 = Nothing
        Me.btnOK.FlashInterval = 500
        Me.btnOK.holdDraw = False
        Me.btnOK.Lit = True
        Me.btnOK.Location = New System.Drawing.Point(335, 403)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RedAlert = LCARS.LCARSalert.Normal
        Me.btnOK.Size = New System.Drawing.Size(114, 31)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "SELECT SCREEN"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "INTERFACE SELECTOR"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(12, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(437, 22)
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
