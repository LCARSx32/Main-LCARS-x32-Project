<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRedAlert
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRedAlert))
        Me.sbProperties = New LCARS.Controls.StandardButton
        Me.FlatButton14 = New LCARS.Controls.FlatButton
        Me.Elbow5 = New LCARS.Controls.Elbow
        Me.tmrMouseSelect = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWA = New System.Windows.Forms.Timer(Me.components)
        Me.Elbow6 = New LCARS.Controls.Elbow
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.StandardButton2 = New LCARS.Controls.StandardButton
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.SuspendLayout()
        '
        'sbProperties
        '
        Me.sbProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbProperties.BackgroundImage = CType(resources.GetObject("sbProperties.BackgroundImage"), System.Drawing.Image)
        Me.sbProperties.Beeping = False
        Me.sbProperties.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbProperties.ButtonText = "MUTE"
        Me.sbProperties.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbProperties.ButtonTextHeight = 14
        Me.sbProperties.Clickable = True
        Me.sbProperties.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbProperties.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbProperties.Data = Nothing
        Me.sbProperties.Data2 = Nothing
        Me.sbProperties.FlashInterval = 500
        Me.sbProperties.holdDraw = False
        Me.sbProperties.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbProperties.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.sbProperties.lblTextSize = New System.Drawing.Point(87, 26)
        Me.sbProperties.lblTextVisible = True
        Me.sbProperties.Lit = True
        Me.sbProperties.Location = New System.Drawing.Point(520, 89)
        Me.sbProperties.Name = "sbProperties"
        Me.sbProperties.RedAlert = LCARS.LCARSalert.Normal
        Me.sbProperties.Size = New System.Drawing.Size(87, 26)
        Me.sbProperties.TabIndex = 72
        Me.sbProperties.Text = "MUTE"
        '
        'FlatButton14
        '
        Me.FlatButton14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton14.BackgroundImage = CType(resources.GetObject("FlatButton14.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton14.Beeping = False
        Me.FlatButton14.ButtonText = ""
        Me.FlatButton14.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton14.ButtonTextHeight = 14
        Me.FlatButton14.Clickable = False
        Me.FlatButton14.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton14.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton14.Data = Nothing
        Me.FlatButton14.Data2 = Nothing
        Me.FlatButton14.FlashInterval = 500
        Me.FlatButton14.holdDraw = False
        Me.FlatButton14.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton14.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton14.lblTextSize = New System.Drawing.Point(5, 316)
        Me.FlatButton14.lblTextVisible = True
        Me.FlatButton14.Lit = True
        Me.FlatButton14.Location = New System.Drawing.Point(509, 89)
        Me.FlatButton14.Name = "FlatButton14"
        Me.FlatButton14.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton14.Size = New System.Drawing.Size(5, 316)
        Me.FlatButton14.TabIndex = 76
        '
        'Elbow5
        '
        Me.Elbow5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow5.BackgroundImage = CType(resources.GetObject("Elbow5.BackgroundImage"), System.Drawing.Image)
        Me.Elbow5.Beeping = False
        Me.Elbow5.ButtonHeight = 25
        Me.Elbow5.ButtonText = "OPTIONS"
        Me.Elbow5.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Elbow5.ButtonTextHeight = 14
        Me.Elbow5.ButtonWidth = 5
        Me.Elbow5.Clickable = False
        Me.Elbow5.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.Elbow5.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow5.Data = Nothing
        Me.Elbow5.Data2 = Nothing
        Me.Elbow5.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow5.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow5.FlashInterval = 500
        Me.Elbow5.holdDraw = False
        Me.Elbow5.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow5.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.Elbow5.lblTextSize = New System.Drawing.Point(113, 38)
        Me.Elbow5.lblTextVisible = True
        Me.Elbow5.Lit = True
        Me.Elbow5.Location = New System.Drawing.Point(509, 45)
        Me.Elbow5.Name = "Elbow5"
        Me.Elbow5.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow5.Size = New System.Drawing.Size(113, 38)
        Me.Elbow5.TabIndex = 74
        Me.Elbow5.Text = "OPTIONS"
        '
        'tmrMouseSelect
        '
        Me.tmrMouseSelect.Interval = 500
        '
        'tmrWA
        '
        Me.tmrWA.Enabled = True
        '
        'Elbow6
        '
        Me.Elbow6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow6.BackgroundImage = CType(resources.GetObject("Elbow6.BackgroundImage"), System.Drawing.Image)
        Me.Elbow6.Beeping = False
        Me.Elbow6.ButtonHeight = 25
        Me.Elbow6.ButtonText = ""
        Me.Elbow6.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Elbow6.ButtonTextHeight = 14
        Me.Elbow6.ButtonWidth = 5
        Me.Elbow6.Clickable = False
        Me.Elbow6.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.Elbow6.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow6.Data = Nothing
        Me.Elbow6.Data2 = Nothing
        Me.Elbow6.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow6.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow6.FlashInterval = 500
        Me.Elbow6.holdDraw = False
        Me.Elbow6.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow6.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.Elbow6.lblTextSize = New System.Drawing.Point(113, 39)
        Me.Elbow6.lblTextVisible = True
        Me.Elbow6.Lit = True
        Me.Elbow6.Location = New System.Drawing.Point(509, 411)
        Me.Elbow6.Name = "Elbow6"
        Me.Elbow6.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow6.Size = New System.Drawing.Size(113, 39)
        Me.Elbow6.TabIndex = 75
        '
        'StandardButton1
        '
        Me.StandardButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton1.BackgroundImage = CType(resources.GetObject("StandardButton1.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.StandardButton1.ButtonText = "CANCEL ALERT"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.StandardButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.StandardButton1.lblTextSize = New System.Drawing.Point(87, 26)
        Me.StandardButton1.lblTextVisible = True
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(520, 121)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(87, 26)
        Me.StandardButton1.TabIndex = 77
        Me.StandardButton1.Text = "CANCEL ALERT"
        '
        'StandardButton2
        '
        Me.StandardButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton2.BackgroundImage = CType(resources.GetObject("StandardButton2.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton2.Beeping = False
        Me.StandardButton2.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.StandardButton2.ButtonText = "TECHNICAL DATA"
        Me.StandardButton2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.StandardButton2.ButtonTextHeight = 14
        Me.StandardButton2.Clickable = True
        Me.StandardButton2.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.StandardButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton2.Data = Nothing
        Me.StandardButton2.Data2 = Nothing
        Me.StandardButton2.FlashInterval = 500
        Me.StandardButton2.holdDraw = False
        Me.StandardButton2.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton2.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.StandardButton2.lblTextSize = New System.Drawing.Point(87, 26)
        Me.StandardButton2.lblTextVisible = True
        Me.StandardButton2.Lit = True
        Me.StandardButton2.Location = New System.Drawing.Point(520, 171)
        Me.StandardButton2.Name = "StandardButton2"
        Me.StandardButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton2.Size = New System.Drawing.Size(87, 26)
        Me.StandardButton2.TabIndex = 78
        Me.StandardButton2.Text = "TECHNICAL DATA"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.Font = New System.Drawing.Font("LCARS", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(33, 74)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(470, 396)
        Me.lblMessage.TabIndex = 80
        Me.lblMessage.Text = "RED ALERT"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(175, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 72)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "RED ALERT"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.BackgroundImage = CType(resources.GetObject("FlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = ""
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = False
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton1.lblTextSize = New System.Drawing.Point(5, 363)
        Me.FlatButton1.lblTextVisible = True
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(617, 64)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(5, 363)
        Me.FlatButton1.TabIndex = 59
        '
        'frmRedAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StandardButton2)
        Me.Controls.Add(Me.StandardButton1)
        Me.Controls.Add(Me.sbProperties)
        Me.Controls.Add(Me.FlatButton14)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.Elbow6)
        Me.Controls.Add(Me.Elbow5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRedAlert"
        Me.Text = "frmRedAlert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbProperties As LCARS.Controls.StandardButton
    Friend WithEvents FlatButton14 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow5 As LCARS.Controls.Elbow
    Friend WithEvents tmrMouseSelect As System.Windows.Forms.Timer
    Friend WithEvents tmrWA As System.Windows.Forms.Timer
    Friend WithEvents Elbow6 As LCARS.Controls.Elbow
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents StandardButton2 As LCARS.Controls.StandardButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
End Class
