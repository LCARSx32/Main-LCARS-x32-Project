<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartup
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
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlDesktop = New System.Windows.Forms.Panel
        Me.pnlBack = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'pnlDesktop
        '
        Me.pnlDesktop.BackColor = System.Drawing.Color.Black
        Me.pnlDesktop.BackgroundImage = Global.LCARSmain.My.Resources.Resources.federationLogo
        Me.pnlDesktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlDesktop.Location = New System.Drawing.Point(132, 13)
        Me.pnlDesktop.Name = "pnlDesktop"
        Me.pnlDesktop.Size = New System.Drawing.Size(151, 134)
        Me.pnlDesktop.TabIndex = 3
        '
        'pnlBack
        '
        Me.pnlBack.Location = New System.Drawing.Point(12, 12)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(114, 135)
        Me.pnlBack.TabIndex = 4
        '
        'frmStartup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(297, 159)
        Me.Controls.Add(Me.pnlBack)
        Me.Controls.Add(Me.pnlDesktop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStartup"
        Me.ShowInTaskbar = False
        Me.Text = "Startup"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pnlDesktop As System.Windows.Forms.Panel
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
End Class
