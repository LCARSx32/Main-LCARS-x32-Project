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
        Dim LcarScolor6 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor7 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor5 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim LcarScolor4 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Windowless = New LCARS.Controls.WindowlessContainer
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.FlatButton2 = New LCARS.Controls.FlatButton
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.StandardButton1)
        Me.Panel1.Controls.Add(Me.FlatButton2)
        Me.Panel1.Location = New System.Drawing.Point(13, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 204)
        Me.Panel1.TabIndex = 4
        '
        'Windowless
        '
        Me.Windowless.Beeping = False
        Me.Windowless.ColorsAvailable = LcarScolor6
        Me.Windowless.Location = New System.Drawing.Point(12, 288)
        Me.Windowless.Name = "Windowless"
        Me.Windowless.Size = New System.Drawing.Size(757, 245)
        Me.Windowless.TabIndex = 3
        Me.Windowless.Text = "WindowlessContainer1"
        '
        'FlatButton1
        '
        Me.FlatButton1.BackgroundImage = CType(resources.GetObject("FlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = "STANDARD"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = True
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.FlatButton1.ColorsAvailable = LcarScolor7
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton1.lblTextSize = New System.Drawing.Size(81, 25)
        Me.FlatButton1.lblTextVisible = True
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(13, 12)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(81, 25)
        Me.FlatButton1.TabIndex = 1
        Me.FlatButton1.Text = "STANDARD"
        '
        'FlatButton2
        '
        Me.FlatButton2.BackgroundImage = CType(resources.GetObject("FlatButton2.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton2.Beeping = False
        Me.FlatButton2.ButtonText = "FLATBUTTON2"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton2.ButtonTextHeight = 14
        Me.FlatButton2.Clickable = True
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.FlatButton2.ColorsAvailable = LcarScolor5
        Me.FlatButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton2.Data = Nothing
        Me.FlatButton2.Data2 = Nothing
        Me.FlatButton2.FlashInterval = 500
        Me.FlatButton2.holdDraw = False
        Me.FlatButton2.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton2.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton2.lblTextSize = New System.Drawing.Size(200, 100)
        Me.FlatButton2.lblTextVisible = True
        Me.FlatButton2.Lit = True
        Me.FlatButton2.Location = New System.Drawing.Point(3, 3)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton2.Size = New System.Drawing.Size(200, 100)
        Me.FlatButton2.TabIndex = 0
        Me.FlatButton2.Text = "FLATBUTTON2"
        '
        'StandardButton1
        '
        Me.StandardButton1.BackgroundImage = CType(resources.GetObject("StandardButton1.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.StandardButton1.ButtonText = "STANDARDBUTTON1"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.StandardButton1.ColorsAvailable = LcarScolor4
        Me.StandardButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.StandardButton1.lblTextLoc = New System.Drawing.Point(27, 0)
        Me.StandardButton1.lblTextSize = New System.Drawing.Size(91, 55)
        Me.StandardButton1.lblTextVisible = True
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(266, 120)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(146, 55)
        Me.StandardButton1.TabIndex = 5
        Me.StandardButton1.Text = "STANDARDBUTTON1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(782, 545)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Windowless)
        Me.Controls.Add(Me.FlatButton1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LcarsCalender1 As LCARS.Controls.LCARSCalender
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents Windowless As LCARS.Controls.WindowlessContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlatButton2 As LCARS.Controls.FlatButton
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton

End Class
