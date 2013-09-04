<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaskManager
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
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.lstProcesses = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'StandardButton1
        '
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.StandardButton1.ButtonText = "X"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.StandardButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(351, 0)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(30, 32)
        Me.StandardButton1.TabIndex = 1
        Me.StandardButton1.Text = "X"
        '
        'lstProcesses
        '
        Me.lstProcesses.BackColor = System.Drawing.Color.Black
        Me.lstProcesses.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProcesses.ForeColor = System.Drawing.Color.OrangeRed
        Me.lstProcesses.FormattingEnabled = True
        Me.lstProcesses.ItemHeight = 21
        Me.lstProcesses.Location = New System.Drawing.Point(12, 38)
        Me.lstProcesses.Name = "lstProcesses"
        Me.lstProcesses.Size = New System.Drawing.Size(357, 256)
        Me.lstProcesses.TabIndex = 0
        '
        'frmTaskManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(381, 347)
        Me.Controls.Add(Me.StandardButton1)
        Me.Controls.Add(Me.lstProcesses)
        Me.ForeColor = System.Drawing.Color.OrangeRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTaskManager"
        Me.Text = "Task Manager"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents lstProcesses As System.Windows.Forms.ListBox
End Class
