<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainscreen5
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
        Me.myModeSelect = New LCARS.Controls.FlatButton
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'myModeSelect
        '
        Me.myModeSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myModeSelect.ButtonText = "MODE SELECT"
        Me.myModeSelect.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.myModeSelect.Location = New System.Drawing.Point(0, 0)
        Me.myModeSelect.Name = "myModeSelect"
        Me.myModeSelect.Size = New System.Drawing.Size(200, 1)
        Me.myModeSelect.TabIndex = 0
        Me.myModeSelect.Text = "MODE SELECT"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Location = New System.Drawing.Point(0, 1)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(200, 199)
        Me.pnlMain.TabIndex = 1
        '
        'frmMainscreen5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(200, 200)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.myModeSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMainscreen5"
        Me.ShowInTaskbar = False
        Me.Text = "frmMainscreen5"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents myModeSelect As LCARS.Controls.FlatButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
End Class
