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
        Me.txtHours = New System.Windows.Forms.TextBox
        Me.txtMinutes = New System.Windows.Forms.TextBox
        Me.txtSeconds = New System.Windows.Forms.TextBox
        Me.tmrCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.txtMilliseconds = New System.Windows.Forms.TextBox
        Me.lblMode = New System.Windows.Forms.Label
        Me.cbAlertType = New System.Windows.Forms.ComboBox
        Me.txtExternal = New System.Windows.Forms.TextBox
        Me.hpExternal = New LCARS.Controls.HalfPillButton
        Me.fbMode = New LCARS.Controls.FlatButton
        Me.fbSelected = New LCARS.Controls.FlatButton
        Me.hpAlarm = New LCARS.Controls.HalfPillButton
        Me.hpLogOff = New LCARS.Controls.HalfPillButton
        Me.hpShutDown = New LCARS.Controls.HalfPillButton
        Me.fbMilliseconds = New LCARS.Controls.FlatButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.sbStart = New LCARS.Controls.StandardButton
        Me.fbSeconds = New LCARS.Controls.FlatButton
        Me.fbMinutes = New LCARS.Controls.FlatButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.fbHours = New LCARS.Controls.FlatButton
        Me.SuspendLayout()
        '
        'txtHours
        '
        Me.txtHours.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtHours.BackColor = System.Drawing.Color.Black
        Me.txtHours.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHours.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtHours.ForeColor = System.Drawing.Color.Orange
        Me.txtHours.Location = New System.Drawing.Point(228, 142)
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
        Me.txtMinutes.Location = New System.Drawing.Point(366, 142)
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
        Me.txtSeconds.Location = New System.Drawing.Point(507, 142)
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
        'txtMilliseconds
        '
        Me.txtMilliseconds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMilliseconds.BackColor = System.Drawing.Color.Black
        Me.txtMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMilliseconds.Font = New System.Drawing.Font("LCARS", 60.0!)
        Me.txtMilliseconds.ForeColor = System.Drawing.Color.Orange
        Me.txtMilliseconds.Location = New System.Drawing.Point(648, 142)
        Me.txtMilliseconds.MaxLength = 3
        Me.txtMilliseconds.Multiline = True
        Me.txtMilliseconds.Name = "txtMilliseconds"
        Me.txtMilliseconds.Size = New System.Drawing.Size(100, 82)
        Me.txtMilliseconds.TabIndex = 102
        Me.txtMilliseconds.Text = "000"
        Me.txtMilliseconds.WordWrap = False
        '
        'lblMode
        '
        Me.lblMode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.ForeColor = System.Drawing.Color.Orange
        Me.lblMode.Location = New System.Drawing.Point(219, 80)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(231, 54)
        Me.lblMode.TabIndex = 115
        Me.lblMode.Text = "TIME REMAINING:"
        '
        'cbAlertType
        '
        Me.cbAlertType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbAlertType.BackColor = System.Drawing.Color.Black
        Me.cbAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlertType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAlertType.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlertType.ForeColor = System.Drawing.Color.Orange
        Me.cbAlertType.FormattingEnabled = True
        Me.cbAlertType.Location = New System.Drawing.Point(100, 247)
        Me.cbAlertType.Name = "cbAlertType"
        Me.cbAlertType.Size = New System.Drawing.Size(161, 36)
        Me.cbAlertType.TabIndex = 119
        Me.cbAlertType.Visible = False
        '
        'txtExternal
        '
        Me.txtExternal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtExternal.BackColor = System.Drawing.Color.Black
        Me.txtExternal.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExternal.ForeColor = System.Drawing.Color.Orange
        Me.txtExternal.Location = New System.Drawing.Point(100, 370)
        Me.txtExternal.Name = "txtExternal"
        Me.txtExternal.Size = New System.Drawing.Size(160, 35)
        Me.txtExternal.TabIndex = 121
        Me.txtExternal.Visible = False
        '
        'hpExternal
        '
        Me.hpExternal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hpExternal.Beeping = False
        Me.hpExternal.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpExternal.ButtonText = "EXTERNAL"
        Me.hpExternal.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.hpExternal.ButtonTextHeight = 18
        Me.hpExternal.Clickable = True
        Me.hpExternal.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.hpExternal.CustomAlertColor = System.Drawing.Color.Empty
        Me.hpExternal.Data = Nothing
        Me.hpExternal.Data2 = Nothing
        Me.hpExternal.FlashInterval = 500
        Me.hpExternal.holdDraw = False
        Me.hpExternal.Lit = True
        Me.hpExternal.Location = New System.Drawing.Point(308, 370)
        Me.hpExternal.Name = "hpExternal"
        Me.hpExternal.RedAlert = LCARS.LCARSalert.Normal
        Me.hpExternal.Size = New System.Drawing.Size(133, 35)
        Me.hpExternal.TabIndex = 120
        Me.hpExternal.Text = "EXTERNAL"
        '
        'fbMode
        '
        Me.fbMode.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.fbMode.Lit = True
        Me.fbMode.Location = New System.Drawing.Point(833, 137)
        Me.fbMode.Name = "fbMode"
        Me.fbMode.RedAlert = LCARS.LCARSalert.Normal
        Me.fbMode.Size = New System.Drawing.Size(91, 92)
        Me.fbMode.TabIndex = 108
        Me.fbMode.Text = "MODE SELECT"
        '
        'fbSelected
        '
        Me.fbSelected.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.fbSelected.Lit = True
        Me.fbSelected.Location = New System.Drawing.Point(267, 247)
        Me.fbSelected.Name = "fbSelected"
        Me.fbSelected.RedAlert = LCARS.LCARSalert.Normal
        Me.fbSelected.Size = New System.Drawing.Size(35, 35)
        Me.fbSelected.TabIndex = 107
        '
        'hpAlarm
        '
        Me.hpAlarm.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.hpAlarm.Lit = True
        Me.hpAlarm.Location = New System.Drawing.Point(308, 247)
        Me.hpAlarm.Name = "hpAlarm"
        Me.hpAlarm.RedAlert = LCARS.LCARSalert.Normal
        Me.hpAlarm.Size = New System.Drawing.Size(133, 35)
        Me.hpAlarm.TabIndex = 106
        Me.hpAlarm.Text = "ALARM"
        '
        'hpLogOff
        '
        Me.hpLogOff.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.hpLogOff.Lit = True
        Me.hpLogOff.Location = New System.Drawing.Point(308, 329)
        Me.hpLogOff.Name = "hpLogOff"
        Me.hpLogOff.RedAlert = LCARS.LCARSalert.Normal
        Me.hpLogOff.Size = New System.Drawing.Size(133, 35)
        Me.hpLogOff.TabIndex = 105
        Me.hpLogOff.Text = "LOG OFF"
        '
        'hpShutDown
        '
        Me.hpShutDown.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.hpShutDown.Lit = True
        Me.hpShutDown.Location = New System.Drawing.Point(308, 288)
        Me.hpShutDown.Name = "hpShutDown"
        Me.hpShutDown.RedAlert = LCARS.LCARSalert.Normal
        Me.hpShutDown.Size = New System.Drawing.Size(133, 35)
        Me.hpShutDown.TabIndex = 104
        Me.hpShutDown.Text = "SHUT DOWN"
        '
        'fbMilliseconds
        '
        Me.fbMilliseconds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbMilliseconds.Beeping = False
        Me.fbMilliseconds.ButtonText = "MILLISECONDS"
        Me.fbMilliseconds.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbMilliseconds.ButtonTextHeight = 14
        Me.fbMilliseconds.Clickable = False
        Me.fbMilliseconds.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbMilliseconds.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbMilliseconds.Data = Nothing
        Me.fbMilliseconds.Data2 = Nothing
        Me.fbMilliseconds.FlashInterval = 500
        Me.fbMilliseconds.holdDraw = False
        Me.fbMilliseconds.Lit = True
        Me.fbMilliseconds.Location = New System.Drawing.Point(643, 137)
        Me.fbMilliseconds.Name = "fbMilliseconds"
        Me.fbMilliseconds.RedAlert = LCARS.LCARSalert.Normal
        Me.fbMilliseconds.Size = New System.Drawing.Size(184, 92)
        Me.fbMilliseconds.TabIndex = 103
        Me.fbMilliseconds.Text = "MILLISECONDS"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(643, 247)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(135, 49)
        Me.sbCancel.TabIndex = 101
        Me.sbCancel.Text = "CANCEL"
        '
        'sbStart
        '
        Me.sbStart.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.sbStart.Lit = True
        Me.sbStart.Location = New System.Drawing.Point(502, 247)
        Me.sbStart.Name = "sbStart"
        Me.sbStart.RedAlert = LCARS.LCARSalert.Normal
        Me.sbStart.Size = New System.Drawing.Size(135, 49)
        Me.sbStart.TabIndex = 100
        Me.sbStart.Text = "START"
        '
        'fbSeconds
        '
        Me.fbSeconds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbSeconds.Beeping = False
        Me.fbSeconds.ButtonText = "SECONDS"
        Me.fbSeconds.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbSeconds.ButtonTextHeight = 14
        Me.fbSeconds.Clickable = False
        Me.fbSeconds.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbSeconds.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbSeconds.Data = Nothing
        Me.fbSeconds.Data2 = Nothing
        Me.fbSeconds.FlashInterval = 500
        Me.fbSeconds.holdDraw = False
        Me.fbSeconds.Lit = True
        Me.fbSeconds.Location = New System.Drawing.Point(502, 137)
        Me.fbSeconds.Name = "fbSeconds"
        Me.fbSeconds.RedAlert = LCARS.LCARSalert.Normal
        Me.fbSeconds.Size = New System.Drawing.Size(135, 92)
        Me.fbSeconds.TabIndex = 99
        Me.fbSeconds.Text = "SECONDS"
        '
        'fbMinutes
        '
        Me.fbMinutes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbMinutes.Beeping = False
        Me.fbMinutes.ButtonText = "MINUTES"
        Me.fbMinutes.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbMinutes.ButtonTextHeight = 14
        Me.fbMinutes.Clickable = False
        Me.fbMinutes.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbMinutes.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbMinutes.Data = Nothing
        Me.fbMinutes.Data2 = Nothing
        Me.fbMinutes.FlashInterval = 500
        Me.fbMinutes.holdDraw = False
        Me.fbMinutes.Lit = True
        Me.fbMinutes.Location = New System.Drawing.Point(361, 137)
        Me.fbMinutes.Name = "fbMinutes"
        Me.fbMinutes.RedAlert = LCARS.LCARSalert.Normal
        Me.fbMinutes.Size = New System.Drawing.Size(135, 92)
        Me.fbMinutes.TabIndex = 97
        Me.fbMinutes.Text = "MINUTES"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(5, 5)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(1013, 35)
        Me.tbTitle.TabIndex = 93
        Me.tbTitle.Text = "INITIATE AUTO DESTRUCT SEQUENCE"
        '
        'fbHours
        '
        Me.fbHours.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbHours.Beeping = False
        Me.fbHours.ButtonText = "HOURS"
        Me.fbHours.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbHours.ButtonTextHeight = 14
        Me.fbHours.Clickable = False
        Me.fbHours.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbHours.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbHours.Data = Nothing
        Me.fbHours.Data2 = Nothing
        Me.fbHours.FlashInterval = 500
        Me.fbHours.holdDraw = False
        Me.fbHours.Lit = True
        Me.fbHours.Location = New System.Drawing.Point(220, 137)
        Me.fbHours.Name = "fbHours"
        Me.fbHours.RedAlert = LCARS.LCARSalert.Normal
        Me.fbHours.Size = New System.Drawing.Size(135, 92)
        Me.fbHours.TabIndex = 95
        Me.fbHours.Text = "HOURS"
        '
        'frmAutoDestruct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1023, 543)
        Me.Controls.Add(Me.txtExternal)
        Me.Controls.Add(Me.hpExternal)
        Me.Controls.Add(Me.cbAlertType)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.fbMode)
        Me.Controls.Add(Me.fbSelected)
        Me.Controls.Add(Me.hpAlarm)
        Me.Controls.Add(Me.hpLogOff)
        Me.Controls.Add(Me.hpShutDown)
        Me.Controls.Add(Me.txtMilliseconds)
        Me.Controls.Add(Me.fbMilliseconds)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbStart)
        Me.Controls.Add(Me.txtSeconds)
        Me.Controls.Add(Me.fbSeconds)
        Me.Controls.Add(Me.txtMinutes)
        Me.Controls.Add(Me.fbMinutes)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.fbHours)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAutoDestruct"
        Me.Text = "Auto Destruct"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents fbHours As LCARS.Controls.FlatButton
    Friend WithEvents txtMinutes As System.Windows.Forms.TextBox
    Friend WithEvents fbMinutes As LCARS.Controls.FlatButton
    Friend WithEvents txtSeconds As System.Windows.Forms.TextBox
    Friend WithEvents fbSeconds As LCARS.Controls.FlatButton
    Friend WithEvents sbStart As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents tmrCountdown As System.Windows.Forms.Timer
    Friend WithEvents txtMilliseconds As System.Windows.Forms.TextBox
    Friend WithEvents fbMilliseconds As LCARS.Controls.FlatButton
    Friend WithEvents hpShutDown As LCARS.Controls.HalfPillButton
    Friend WithEvents hpLogOff As LCARS.Controls.HalfPillButton
    Friend WithEvents hpAlarm As LCARS.Controls.HalfPillButton
    Friend WithEvents fbSelected As LCARS.Controls.FlatButton
    Friend WithEvents fbMode As LCARS.Controls.FlatButton
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents cbAlertType As System.Windows.Forms.ComboBox
    Friend WithEvents hpExternal As LCARS.Controls.HalfPillButton
    Friend WithEvents txtExternal As System.Windows.Forms.TextBox
End Class
