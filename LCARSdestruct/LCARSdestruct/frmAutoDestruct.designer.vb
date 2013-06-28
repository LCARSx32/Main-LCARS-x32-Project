<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoDestruct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutoDestruct))
        Me.txtHours = New System.Windows.Forms.TextBox
        Me.txtMinutes = New System.Windows.Forms.TextBox
        Me.txtSeconds = New System.Windows.Forms.TextBox
        Me.tmrCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWA = New System.Windows.Forms.Timer(Me.components)
        Me.txtMilliseconds = New System.Windows.Forms.TextBox
        Me.pnl12hr = New System.Windows.Forms.Panel
        Me.FlatButton5 = New LCARS.Controls.FlatButton
        Me.HalfPillButton1 = New LCARS.Controls.HalfPillButton
        Me.HalfPillButton2 = New LCARS.Controls.HalfPillButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.pnl24hr = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.fbMode = New LCARS.Controls.FlatButton
        Me.fbSelected = New LCARS.Controls.FlatButton
        Me.hpAlarm = New LCARS.Controls.HalfPillButton
        Me.hpLogOff = New LCARS.Controls.HalfPillButton
        Me.hpShutDown = New LCARS.Controls.HalfPillButton
        Me.FlatButton4 = New LCARS.Controls.FlatButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.sbStart = New LCARS.Controls.StandardButton
        Me.FlatButton3 = New LCARS.Controls.FlatButton
        Me.FlatButton2 = New LCARS.Controls.FlatButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnl12hr.SuspendLayout()
        Me.pnl24hr.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtHours
        '
        Me.txtHours.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtHours.BackColor = System.Drawing.Color.Black
        Me.txtHours.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHours.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtHours.ForeColor = System.Drawing.Color.Orange
        Me.txtHours.Location = New System.Drawing.Point(229, 255)
        Me.txtHours.MaxLength = 2
        Me.txtHours.Multiline = True
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(75, 82)
        Me.txtHours.TabIndex = 94
        Me.txtHours.Text = "00"
        '
        'txtMinutes
        '
        Me.txtMinutes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMinutes.BackColor = System.Drawing.Color.Black
        Me.txtMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMinutes.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtMinutes.ForeColor = System.Drawing.Color.Orange
        Me.txtMinutes.Location = New System.Drawing.Point(367, 255)
        Me.txtMinutes.MaxLength = 2
        Me.txtMinutes.Multiline = True
        Me.txtMinutes.Name = "txtMinutes"
        Me.txtMinutes.Size = New System.Drawing.Size(75, 82)
        Me.txtMinutes.TabIndex = 96
        Me.txtMinutes.Text = "00"
        '
        'txtSeconds
        '
        Me.txtSeconds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtSeconds.BackColor = System.Drawing.Color.Black
        Me.txtSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeconds.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtSeconds.ForeColor = System.Drawing.Color.Orange
        Me.txtSeconds.Location = New System.Drawing.Point(508, 255)
        Me.txtSeconds.MaxLength = 2
        Me.txtSeconds.Multiline = True
        Me.txtSeconds.Name = "txtSeconds"
        Me.txtSeconds.Size = New System.Drawing.Size(75, 82)
        Me.txtSeconds.TabIndex = 98
        Me.txtSeconds.Text = "00"
        '
        'tmrCountdown
        '
        Me.tmrCountdown.Interval = 1
        '
        'tmrWA
        '
        Me.tmrWA.Enabled = True
        '
        'txtMilliseconds
        '
        Me.txtMilliseconds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMilliseconds.BackColor = System.Drawing.Color.Black
        Me.txtMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMilliseconds.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtMilliseconds.ForeColor = System.Drawing.Color.Orange
        Me.txtMilliseconds.Location = New System.Drawing.Point(649, 255)
        Me.txtMilliseconds.MaxLength = 2
        Me.txtMilliseconds.Multiline = True
        Me.txtMilliseconds.Name = "txtMilliseconds"
        Me.txtMilliseconds.Size = New System.Drawing.Size(75, 82)
        Me.txtMilliseconds.TabIndex = 102
        Me.txtMilliseconds.Text = "00"
        '
        'pnl12hr
        '
        Me.pnl12hr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnl12hr.Controls.Add(Me.FlatButton5)
        Me.pnl12hr.Controls.Add(Me.HalfPillButton1)
        Me.pnl12hr.Controls.Add(Me.HalfPillButton2)
        Me.pnl12hr.Controls.Add(Me.Label3)
        Me.pnl12hr.Controls.Add(Me.Label2)
        Me.pnl12hr.Controls.Add(Me.Label1)
        Me.pnl12hr.Controls.Add(Me.TextBox2)
        Me.pnl12hr.Controls.Add(Me.TextBox3)
        Me.pnl12hr.Controls.Add(Me.TextBox4)
        Me.pnl12hr.Location = New System.Drawing.Point(213, 184)
        Me.pnl12hr.Name = "pnl12hr"
        Me.pnl12hr.Size = New System.Drawing.Size(591, 158)
        Me.pnl12hr.TabIndex = 109
        Me.pnl12hr.Visible = False
        '
        'FlatButton5
        '
        Me.FlatButton5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton5.BackgroundImage = CType(resources.GetObject("FlatButton5.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton5.Beeping = True
        Me.FlatButton5.ButtonText = ""
        Me.FlatButton5.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton5.ButtonTextHeight = 14
        Me.FlatButton5.Clickable = True
        Me.FlatButton5.Color = LCARS.LCARScolorStyles.Orange
        Me.FlatButton5.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton5.Data = Nothing
        Me.FlatButton5.Data2 = Nothing
        Me.FlatButton5.FlashInterval = 500
        Me.FlatButton5.holdDraw = False
        Me.FlatButton5.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton5.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton5.lblTextSize = New System.Drawing.Point(35, 35)
        Me.FlatButton5.lblTextVisible = True
        Me.FlatButton5.Lit = True
        Me.FlatButton5.Location = New System.Drawing.Point(429, 73)
        Me.FlatButton5.Name = "FlatButton5"
        Me.FlatButton5.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton5.Size = New System.Drawing.Size(35, 35)
        Me.FlatButton5.TabIndex = 117
        '
        'HalfPillButton1
        '
        Me.HalfPillButton1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HalfPillButton1.BackgroundImage = CType(resources.GetObject("HalfPillButton1.BackgroundImage"), System.Drawing.Image)
        Me.HalfPillButton1.Beeping = True
        Me.HalfPillButton1.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.HalfPillButton1.ButtonText = "AM"
        Me.HalfPillButton1.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.HalfPillButton1.ButtonTextHeight = 18
        Me.HalfPillButton1.Clickable = True
        Me.HalfPillButton1.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.HalfPillButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.HalfPillButton1.Data = Nothing
        Me.HalfPillButton1.Data2 = Nothing
        Me.HalfPillButton1.FlashInterval = 500
        Me.HalfPillButton1.holdDraw = False
        Me.HalfPillButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.HalfPillButton1.lblTextSize = New System.Drawing.Point(69, 35)
        Me.HalfPillButton1.lblTextVisible = True
        Me.HalfPillButton1.Lit = True
        Me.HalfPillButton1.Location = New System.Drawing.Point(470, 73)
        Me.HalfPillButton1.Name = "HalfPillButton1"
        Me.HalfPillButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.HalfPillButton1.Size = New System.Drawing.Size(69, 35)
        Me.HalfPillButton1.TabIndex = 116
        Me.HalfPillButton1.Text = "AM"
        '
        'HalfPillButton2
        '
        Me.HalfPillButton2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HalfPillButton2.BackgroundImage = CType(resources.GetObject("HalfPillButton2.BackgroundImage"), System.Drawing.Image)
        Me.HalfPillButton2.Beeping = True
        Me.HalfPillButton2.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.HalfPillButton2.ButtonText = "PM"
        Me.HalfPillButton2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.HalfPillButton2.ButtonTextHeight = 18
        Me.HalfPillButton2.Clickable = True
        Me.HalfPillButton2.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.HalfPillButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.HalfPillButton2.Data = Nothing
        Me.HalfPillButton2.Data2 = Nothing
        Me.HalfPillButton2.FlashInterval = 500
        Me.HalfPillButton2.holdDraw = False
        Me.HalfPillButton2.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton2.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.HalfPillButton2.lblTextSize = New System.Drawing.Point(69, 35)
        Me.HalfPillButton2.lblTextVisible = True
        Me.HalfPillButton2.Lit = True
        Me.HalfPillButton2.Location = New System.Drawing.Point(470, 114)
        Me.HalfPillButton2.Name = "HalfPillButton2"
        Me.HalfPillButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.HalfPillButton2.Size = New System.Drawing.Size(69, 35)
        Me.HalfPillButton2.TabIndex = 115
        Me.HalfPillButton2.Text = "PM"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(269, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 91)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(136, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 91)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(46, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 54)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "12HR TIME:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.Black
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox2.ForeColor = System.Drawing.Color.Orange
        Me.TextBox2.Location = New System.Drawing.Point(327, 67)
        Me.TextBox2.MaxLength = 2
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(75, 82)
        Me.TextBox2.TabIndex = 108
        Me.TextBox2.Text = "00"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Black
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox3.ForeColor = System.Drawing.Color.Orange
        Me.TextBox3.Location = New System.Drawing.Point(188, 67)
        Me.TextBox3.MaxLength = 2
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(75, 82)
        Me.TextBox3.TabIndex = 106
        Me.TextBox3.Text = "00"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.Black
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox4.ForeColor = System.Drawing.Color.Orange
        Me.TextBox4.Location = New System.Drawing.Point(55, 67)
        Me.TextBox4.MaxLength = 2
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(75, 82)
        Me.TextBox4.TabIndex = 104
        Me.TextBox4.Text = "12"
        '
        'pnl24hr
        '
        Me.pnl24hr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnl24hr.Controls.Add(Me.Label4)
        Me.pnl24hr.Controls.Add(Me.Label5)
        Me.pnl24hr.Controls.Add(Me.Label6)
        Me.pnl24hr.Controls.Add(Me.TextBox1)
        Me.pnl24hr.Controls.Add(Me.TextBox5)
        Me.pnl24hr.Controls.Add(Me.TextBox6)
        Me.pnl24hr.Location = New System.Drawing.Point(213, 184)
        Me.pnl24hr.Name = "pnl24hr"
        Me.pnl24hr.Size = New System.Drawing.Size(591, 158)
        Me.pnl24hr.TabIndex = 118
        Me.pnl24hr.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(363, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 91)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Orange
        Me.Label5.Location = New System.Drawing.Point(230, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 91)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Orange
        Me.Label6.Location = New System.Drawing.Point(140, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 54)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "24HR TIME:"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox1.ForeColor = System.Drawing.Color.Orange
        Me.TextBox1.Location = New System.Drawing.Point(421, 62)
        Me.TextBox1.MaxLength = 2
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(75, 82)
        Me.TextBox1.TabIndex = 108
        Me.TextBox1.Text = "00"
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.Color.Black
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox5.ForeColor = System.Drawing.Color.Orange
        Me.TextBox5.Location = New System.Drawing.Point(282, 62)
        Me.TextBox5.MaxLength = 2
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(75, 82)
        Me.TextBox5.TabIndex = 106
        Me.TextBox5.Text = "00"
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.BackColor = System.Drawing.Color.Black
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.TextBox6.ForeColor = System.Drawing.Color.Orange
        Me.TextBox6.Location = New System.Drawing.Point(149, 62)
        Me.TextBox6.MaxLength = 2
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(75, 82)
        Me.TextBox6.TabIndex = 104
        Me.TextBox6.Text = "24"
        '
        'fbMode
        '
        Me.fbMode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbMode.BackgroundImage = CType(resources.GetObject("fbMode.BackgroundImage"), System.Drawing.Image)
        Me.fbMode.Beeping = True
        Me.fbMode.ButtonText = "MODE SELECT"
        Me.fbMode.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fbMode.ButtonTextHeight = 14
        Me.fbMode.Clickable = True
        Me.fbMode.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbMode.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbMode.Data = Nothing
        Me.fbMode.Data2 = Nothing
        Me.fbMode.FlashInterval = 500
        Me.fbMode.holdDraw = False
        Me.fbMode.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbMode.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbMode.lblTextSize = New System.Drawing.Point(91, 92)
        Me.fbMode.lblTextVisible = True
        Me.fbMode.Lit = True
        Me.fbMode.Location = New System.Drawing.Point(810, 250)
        Me.fbMode.Name = "fbMode"
        Me.fbMode.RedAlert = LCARS.LCARSalert.Normal
        Me.fbMode.Size = New System.Drawing.Size(91, 92)
        Me.fbMode.TabIndex = 108
        Me.fbMode.Text = "MODE SELECT"
        '
        'fbSelected
        '
        Me.fbSelected.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbSelected.BackgroundImage = CType(resources.GetObject("fbSelected.BackgroundImage"), System.Drawing.Image)
        Me.fbSelected.Beeping = True
        Me.fbSelected.ButtonText = ""
        Me.fbSelected.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbSelected.ButtonTextHeight = 14
        Me.fbSelected.Clickable = True
        Me.fbSelected.Color = LCARS.LCARScolorStyles.Orange
        Me.fbSelected.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbSelected.Data = Nothing
        Me.fbSelected.Data2 = Nothing
        Me.fbSelected.FlashInterval = 500
        Me.fbSelected.holdDraw = False
        Me.fbSelected.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbSelected.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbSelected.lblTextSize = New System.Drawing.Point(35, 35)
        Me.fbSelected.lblTextVisible = True
        Me.fbSelected.Lit = True
        Me.fbSelected.Location = New System.Drawing.Point(268, 360)
        Me.fbSelected.Name = "fbSelected"
        Me.fbSelected.RedAlert = LCARS.LCARSalert.Normal
        Me.fbSelected.Size = New System.Drawing.Size(35, 35)
        Me.fbSelected.TabIndex = 107
        '
        'hpAlarm
        '
        Me.hpAlarm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hpAlarm.BackgroundImage = CType(resources.GetObject("hpAlarm.BackgroundImage"), System.Drawing.Image)
        Me.hpAlarm.Beeping = True
        Me.hpAlarm.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpAlarm.ButtonText = "ALARM"
        Me.hpAlarm.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.hpAlarm.ButtonTextHeight = 18
        Me.hpAlarm.Clickable = True
        Me.hpAlarm.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.hpAlarm.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpAlarm.Data = Nothing
        Me.hpAlarm.Data2 = Nothing
        Me.hpAlarm.FlashInterval = 500
        Me.hpAlarm.holdDraw = False
        Me.hpAlarm.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpAlarm.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpAlarm.lblTextSize = New System.Drawing.Point(133, 35)
        Me.hpAlarm.lblTextVisible = True
        Me.hpAlarm.Lit = True
        Me.hpAlarm.Location = New System.Drawing.Point(309, 360)
        Me.hpAlarm.Name = "hpAlarm"
        Me.hpAlarm.RedAlert = LCARS.LCARSalert.Normal
        Me.hpAlarm.Size = New System.Drawing.Size(133, 35)
        Me.hpAlarm.TabIndex = 106
        Me.hpAlarm.Text = "ALARM"
        '
        'hpLogOff
        '
        Me.hpLogOff.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hpLogOff.BackgroundImage = CType(resources.GetObject("hpLogOff.BackgroundImage"), System.Drawing.Image)
        Me.hpLogOff.Beeping = True
        Me.hpLogOff.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpLogOff.ButtonText = "LOG OFF"
        Me.hpLogOff.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.hpLogOff.ButtonTextHeight = 18
        Me.hpLogOff.Clickable = True
        Me.hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpLogOff.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpLogOff.Data = Nothing
        Me.hpLogOff.Data2 = Nothing
        Me.hpLogOff.FlashInterval = 500
        Me.hpLogOff.holdDraw = False
        Me.hpLogOff.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpLogOff.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpLogOff.lblTextSize = New System.Drawing.Point(133, 35)
        Me.hpLogOff.lblTextVisible = True
        Me.hpLogOff.Lit = True
        Me.hpLogOff.Location = New System.Drawing.Point(309, 442)
        Me.hpLogOff.Name = "hpLogOff"
        Me.hpLogOff.RedAlert = LCARS.LCARSalert.Normal
        Me.hpLogOff.Size = New System.Drawing.Size(133, 35)
        Me.hpLogOff.TabIndex = 105
        Me.hpLogOff.Text = "LOG OFF"
        '
        'hpShutDown
        '
        Me.hpShutDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hpShutDown.BackgroundImage = CType(resources.GetObject("hpShutDown.BackgroundImage"), System.Drawing.Image)
        Me.hpShutDown.Beeping = True
        Me.hpShutDown.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpShutDown.ButtonText = "SHUT DOWN"
        Me.hpShutDown.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.hpShutDown.ButtonTextHeight = 18
        Me.hpShutDown.Clickable = True
        Me.hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpShutDown.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpShutDown.Data = Nothing
        Me.hpShutDown.Data2 = Nothing
        Me.hpShutDown.FlashInterval = 500
        Me.hpShutDown.holdDraw = False
        Me.hpShutDown.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpShutDown.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpShutDown.lblTextSize = New System.Drawing.Point(133, 35)
        Me.hpShutDown.lblTextVisible = True
        Me.hpShutDown.Lit = True
        Me.hpShutDown.Location = New System.Drawing.Point(309, 401)
        Me.hpShutDown.Name = "hpShutDown"
        Me.hpShutDown.RedAlert = LCARS.LCARSalert.Normal
        Me.hpShutDown.Size = New System.Drawing.Size(133, 35)
        Me.hpShutDown.TabIndex = 104
        Me.hpShutDown.Text = "SHUT DOWN"
        '
        'FlatButton4
        '
        Me.FlatButton4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton4.BackgroundImage = CType(resources.GetObject("FlatButton4.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton4.Beeping = False
        Me.FlatButton4.ButtonText = "MILLISECONDS"
        Me.FlatButton4.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton4.ButtonTextHeight = 14
        Me.FlatButton4.Clickable = False
        Me.FlatButton4.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.FlatButton4.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton4.Data = Nothing
        Me.FlatButton4.Data2 = Nothing
        Me.FlatButton4.FlashInterval = 500
        Me.FlatButton4.holdDraw = False
        Me.FlatButton4.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton4.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton4.lblTextSize = New System.Drawing.Point(160, 92)
        Me.FlatButton4.lblTextVisible = True
        Me.FlatButton4.Lit = True
        Me.FlatButton4.Location = New System.Drawing.Point(644, 250)
        Me.FlatButton4.Name = "FlatButton4"
        Me.FlatButton4.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton4.Size = New System.Drawing.Size(160, 92)
        Me.FlatButton4.TabIndex = 103
        Me.FlatButton4.Text = "MILLISECONDS"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbCancel.BackgroundImage = CType(resources.GetObject("sbCancel.BackgroundImage"), System.Drawing.Image)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCancel.ButtonTextHeight = 22
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.lblTextLoc = New System.Drawing.Point(24, 0)
        Me.sbCancel.lblTextSize = New System.Drawing.Point(86, 49)
        Me.sbCancel.lblTextVisible = True
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(644, 360)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(135, 49)
        Me.sbCancel.TabIndex = 101
        Me.sbCancel.Text = "CANCEL"
        '
        'sbStart
        '
        Me.sbStart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbStart.BackgroundImage = CType(resources.GetObject("sbStart.BackgroundImage"), System.Drawing.Image)
        Me.sbStart.Beeping = False
        Me.sbStart.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbStart.ButtonText = "START"
        Me.sbStart.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbStart.ButtonTextHeight = 22
        Me.sbStart.Clickable = True
        Me.sbStart.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbStart.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbStart.Data = Nothing
        Me.sbStart.Data2 = Nothing
        Me.sbStart.FlashInterval = 500
        Me.sbStart.holdDraw = False
        Me.sbStart.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbStart.lblTextLoc = New System.Drawing.Point(24, 0)
        Me.sbStart.lblTextSize = New System.Drawing.Point(86, 49)
        Me.sbStart.lblTextVisible = True
        Me.sbStart.Lit = True
        Me.sbStart.Location = New System.Drawing.Point(503, 360)
        Me.sbStart.Name = "sbStart"
        Me.sbStart.RedAlert = LCARS.LCARSalert.Normal
        Me.sbStart.Size = New System.Drawing.Size(135, 49)
        Me.sbStart.TabIndex = 100
        Me.sbStart.Text = "START"
        '
        'FlatButton3
        '
        Me.FlatButton3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton3.BackgroundImage = CType(resources.GetObject("FlatButton3.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton3.Beeping = False
        Me.FlatButton3.ButtonText = "SECONDS"
        Me.FlatButton3.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton3.ButtonTextHeight = 14
        Me.FlatButton3.Clickable = False
        Me.FlatButton3.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.FlatButton3.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton3.Data = Nothing
        Me.FlatButton3.Data2 = Nothing
        Me.FlatButton3.FlashInterval = 500
        Me.FlatButton3.holdDraw = False
        Me.FlatButton3.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton3.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton3.lblTextSize = New System.Drawing.Point(135, 92)
        Me.FlatButton3.lblTextVisible = True
        Me.FlatButton3.Lit = True
        Me.FlatButton3.Location = New System.Drawing.Point(503, 250)
        Me.FlatButton3.Name = "FlatButton3"
        Me.FlatButton3.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton3.Size = New System.Drawing.Size(135, 92)
        Me.FlatButton3.TabIndex = 99
        Me.FlatButton3.Text = "SECONDS"
        '
        'FlatButton2
        '
        Me.FlatButton2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton2.BackgroundImage = CType(resources.GetObject("FlatButton2.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton2.Beeping = False
        Me.FlatButton2.ButtonText = "MINUTES"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton2.ButtonTextHeight = 14
        Me.FlatButton2.Clickable = False
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.FlatButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton2.Data = Nothing
        Me.FlatButton2.Data2 = Nothing
        Me.FlatButton2.FlashInterval = 500
        Me.FlatButton2.holdDraw = False
        Me.FlatButton2.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton2.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton2.lblTextSize = New System.Drawing.Point(135, 92)
        Me.FlatButton2.lblTextVisible = True
        Me.FlatButton2.Lit = True
        Me.FlatButton2.Location = New System.Drawing.Point(362, 250)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton2.Size = New System.Drawing.Size(135, 92)
        Me.FlatButton2.TabIndex = 97
        Me.FlatButton2.Text = "MINUTES"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.BackgroundImage = CType(resources.GetObject("tbTitle.BackgroundImage"), System.Drawing.Image)
        Me.tbTitle.Beeping = True
        Me.tbTitle.ButtonText = "INITIATE AUTO DESTRUCT SEQUENCE"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tbTitle.ButtonTextHeight = 32
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbTitle.lblTextSize = New System.Drawing.Point(1014, 35)
        Me.tbTitle.lblTextVisible = True
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(5, 5)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(1014, 35)
        Me.tbTitle.TabIndex = 93
        Me.tbTitle.Text = "INITIATE AUTO DESTRUCT SEQUENCE"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton1.BackgroundImage = CType(resources.GetObject("FlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = "HOURS"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = False
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton1.lblTextSize = New System.Drawing.Point(135, 92)
        Me.FlatButton1.lblTextVisible = True
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(221, 250)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(135, 92)
        Me.FlatButton1.TabIndex = 95
        Me.FlatButton1.Text = "HOURS"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(220, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(231, 54)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "TIME REMAINING:"
        '
        'frmAutoDestruct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.pnl24hr)
        Me.Controls.Add(Me.pnl12hr)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.fbMode)
        Me.Controls.Add(Me.fbSelected)
        Me.Controls.Add(Me.hpAlarm)
        Me.Controls.Add(Me.hpLogOff)
        Me.Controls.Add(Me.hpShutDown)
        Me.Controls.Add(Me.txtMilliseconds)
        Me.Controls.Add(Me.FlatButton4)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbStart)
        Me.Controls.Add(Me.txtSeconds)
        Me.Controls.Add(Me.FlatButton3)
        Me.Controls.Add(Me.txtMinutes)
        Me.Controls.Add(Me.FlatButton2)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.FlatButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAutoDestruct"
        Me.Text = "Auto Destruct"
        Me.pnl12hr.ResumeLayout(False)
        Me.pnl12hr.PerformLayout()
        Me.pnl24hr.ResumeLayout(False)
        Me.pnl24hr.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents txtMinutes As System.Windows.Forms.TextBox
    Friend WithEvents FlatButton2 As LCARS.Controls.FlatButton
    Friend WithEvents txtSeconds As System.Windows.Forms.TextBox
    Friend WithEvents FlatButton3 As LCARS.Controls.FlatButton
    Friend WithEvents sbStart As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents tmrCountdown As System.Windows.Forms.Timer
    Friend WithEvents tmrWA As System.Windows.Forms.Timer
    Friend WithEvents txtMilliseconds As System.Windows.Forms.TextBox
    Friend WithEvents FlatButton4 As LCARS.Controls.FlatButton
    Friend WithEvents hpShutDown As LCARS.Controls.HalfPillButton
    Friend WithEvents hpLogOff As LCARS.Controls.HalfPillButton
    Friend WithEvents hpAlarm As LCARS.Controls.HalfPillButton
    Friend WithEvents fbSelected As LCARS.Controls.FlatButton
    Friend WithEvents fbMode As LCARS.Controls.FlatButton
    Friend WithEvents pnl12hr As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlatButton5 As LCARS.Controls.FlatButton
    Friend WithEvents HalfPillButton1 As LCARS.Controls.HalfPillButton
    Friend WithEvents HalfPillButton2 As LCARS.Controls.HalfPillButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnl24hr As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
