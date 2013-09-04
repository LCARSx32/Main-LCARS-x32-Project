<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.LcarSbuttonClass1 = New LCARS.LCARSbuttonClass
        Me.SuspendLayout()
        '
        'StandardButton1
        '
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.StandardButton1.ButtonText = "STANDARDBUTTON1"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.StandardButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.Flash = True
        Me.StandardButton1.FlashInterval = 1000
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(13, 13)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(200, 118)
        Me.StandardButton1.TabIndex = 0
        Me.StandardButton1.Text = "STANDARDBUTTON1"
        '
        'LcarSbuttonClass1
        '
        Me.LcarSbuttonClass1.Beeping = False
        Me.LcarSbuttonClass1.ButtonText = "LCARSBUTTONCLASS1"
        Me.LcarSbuttonClass1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LcarSbuttonClass1.ButtonTextHeight = 14
        Me.LcarSbuttonClass1.Clickable = True
        Me.LcarSbuttonClass1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.LcarSbuttonClass1.CustomAlertColor = System.Drawing.Color.Empty
        Me.LcarSbuttonClass1.Data = Nothing
        Me.LcarSbuttonClass1.Data2 = Nothing
        Me.LcarSbuttonClass1.Flash = True
        Me.LcarSbuttonClass1.FlashInterval = 500
        Me.LcarSbuttonClass1.holdDraw = False
        Me.LcarSbuttonClass1.Lit = True
        Me.LcarSbuttonClass1.Location = New System.Drawing.Point(263, 43)
        Me.LcarSbuttonClass1.Name = "LcarSbuttonClass1"
        Me.LcarSbuttonClass1.RedAlert = LCARS.LCARSalert.Normal
        Me.LcarSbuttonClass1.Size = New System.Drawing.Size(147, 36)
        Me.LcarSbuttonClass1.TabIndex = 1
        Me.LcarSbuttonClass1.Text = "LCARSBUTTONCLASS1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(782, 532)
        Me.Controls.Add(Me.LcarSbuttonClass1)
        Me.Controls.Add(Me.StandardButton1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LcarsCalender1 As LCARS.Controls.LCARSCalender
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents LcarSbuttonClass1 As LCARS.LCARSbuttonClass

End Class
