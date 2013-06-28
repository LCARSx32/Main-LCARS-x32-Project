<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeechConsole
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpeechConsole))
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.elbTop = New LCARS.Controls.Elbow
        Me.fbHide = New LCARS.Controls.FlatButton
        Me.fbOnOff = New LCARS.Controls.FlatButton
        Me.lstHistory = New System.Windows.Forms.ListBox
        Me.txtEntry = New System.Windows.Forms.TextBox
        Me.elbReferenceBottom = New LCARS.Controls.Elbow
        Me.tbBottom = New LCARS.Controls.TextButton
        Me.elbHistoryBottom = New LCARS.Controls.Elbow
        Me.elbReferenceTop = New LCARS.Controls.Elbow
        Me.fbReferenceBorder = New LCARS.Controls.FlatButton
        Me.fbHistoryBorder = New LCARS.Controls.FlatButton
        Me.lstCommands = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.BackgroundImage = CType(resources.GetObject("tbTitle.BackgroundImage"), System.Drawing.Image)
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "VOICE RECOGNITION CONSOLE"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTitle.ButtonTextHeight = 25
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbTitle.lblTextSize = New System.Drawing.Point(457, 23)
        Me.tbTitle.lblTextVisible = True
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(172, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(457, 23)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "VOICE RECOGNITION CONSOLE"
        '
        'elbTop
        '
        Me.elbTop.BackgroundImage = CType(resources.GetObject("elbTop.BackgroundImage"), System.Drawing.Image)
        Me.elbTop.Beeping = False
        Me.elbTop.ButtonHeight = 23
        Me.elbTop.ButtonText = "COMMAND HISTORY"
        Me.elbTop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.elbTop.ButtonTextHeight = 14
        Me.elbTop.ButtonWidth = 100
        Me.elbTop.Clickable = True
        Me.elbTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.elbTop.Data = Nothing
        Me.elbTop.Data2 = Nothing
        Me.elbTop.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbTop.FlashInterval = 500
        Me.elbTop.holdDraw = False
        Me.elbTop.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbTop.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbTop.lblTextSize = New System.Drawing.Point(182, 44)
        Me.elbTop.lblTextVisible = True
        Me.elbTop.Lit = True
        Me.elbTop.Location = New System.Drawing.Point(12, 12)
        Me.elbTop.Name = "elbTop"
        Me.elbTop.RedAlert = LCARS.LCARSalert.Normal
        Me.elbTop.Size = New System.Drawing.Size(182, 44)
        Me.elbTop.TabIndex = 1
        Me.elbTop.Text = "COMMAND HISTORY"
        '
        'fbHide
        '
        Me.fbHide.BackgroundImage = CType(resources.GetObject("fbHide.BackgroundImage"), System.Drawing.Image)
        Me.fbHide.Beeping = False
        Me.fbHide.ButtonText = "HIDE"
        Me.fbHide.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbHide.ButtonTextHeight = 14
        Me.fbHide.Clickable = True
        Me.fbHide.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbHide.Data = Nothing
        Me.fbHide.Data2 = Nothing
        Me.fbHide.FlashInterval = 500
        Me.fbHide.holdDraw = False
        Me.fbHide.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbHide.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbHide.lblTextSize = New System.Drawing.Point(100, 23)
        Me.fbHide.lblTextVisible = True
        Me.fbHide.Lit = True
        Me.fbHide.Location = New System.Drawing.Point(12, 62)
        Me.fbHide.Name = "fbHide"
        Me.fbHide.RedAlert = LCARS.LCARSalert.Normal
        Me.fbHide.Size = New System.Drawing.Size(100, 23)
        Me.fbHide.TabIndex = 2
        Me.fbHide.Text = "HIDE"
        '
        'fbOnOff
        '
        Me.fbOnOff.BackgroundImage = CType(resources.GetObject("fbOnOff.BackgroundImage"), System.Drawing.Image)
        Me.fbOnOff.Beeping = False
        Me.fbOnOff.ButtonText = "RECOGNITION ON"
        Me.fbOnOff.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbOnOff.ButtonTextHeight = 14
        Me.fbOnOff.Clickable = True
        Me.fbOnOff.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.fbOnOff.Data = Nothing
        Me.fbOnOff.Data2 = Nothing
        Me.fbOnOff.FlashInterval = 500
        Me.fbOnOff.holdDraw = False
        Me.fbOnOff.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbOnOff.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbOnOff.lblTextSize = New System.Drawing.Point(100, 23)
        Me.fbOnOff.lblTextVisible = True
        Me.fbOnOff.Lit = True
        Me.fbOnOff.Location = New System.Drawing.Point(12, 91)
        Me.fbOnOff.Name = "fbOnOff"
        Me.fbOnOff.RedAlert = LCARS.LCARSalert.Normal
        Me.fbOnOff.Size = New System.Drawing.Size(100, 23)
        Me.fbOnOff.TabIndex = 2
        Me.fbOnOff.Text = "RECOGNITION ON"
        '
        'lstHistory
        '
        Me.lstHistory.BackColor = System.Drawing.Color.Black
        Me.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstHistory.ForeColor = System.Drawing.Color.Cyan
        Me.lstHistory.FormattingEnabled = True
        Me.lstHistory.ItemHeight = 21
        Me.lstHistory.Location = New System.Drawing.Point(118, 42)
        Me.lstHistory.Name = "lstHistory"
        Me.lstHistory.Size = New System.Drawing.Size(511, 168)
        Me.lstHistory.TabIndex = 3
        '
        'txtEntry
        '
        Me.txtEntry.BackColor = System.Drawing.Color.Black
        Me.txtEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntry.ForeColor = System.Drawing.Color.Orange
        Me.txtEntry.Location = New System.Drawing.Point(118, 216)
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.Size = New System.Drawing.Size(511, 29)
        Me.txtEntry.TabIndex = 4
        '
        'elbReferenceBottom
        '
        Me.elbReferenceBottom.BackgroundImage = CType(resources.GetObject("elbReferenceBottom.BackgroundImage"), System.Drawing.Image)
        Me.elbReferenceBottom.Beeping = False
        Me.elbReferenceBottom.ButtonHeight = 23
        Me.elbReferenceBottom.ButtonText = ""
        Me.elbReferenceBottom.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.elbReferenceBottom.ButtonTextHeight = 14
        Me.elbReferenceBottom.ButtonWidth = 100
        Me.elbReferenceBottom.Clickable = False
        Me.elbReferenceBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbReferenceBottom.Data = Nothing
        Me.elbReferenceBottom.Data2 = Nothing
        Me.elbReferenceBottom.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbReferenceBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbReferenceBottom.FlashInterval = 500
        Me.elbReferenceBottom.holdDraw = False
        Me.elbReferenceBottom.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbReferenceBottom.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbReferenceBottom.lblTextSize = New System.Drawing.Point(182, 44)
        Me.elbReferenceBottom.lblTextVisible = True
        Me.elbReferenceBottom.Lit = True
        Me.elbReferenceBottom.Location = New System.Drawing.Point(12, 364)
        Me.elbReferenceBottom.Name = "elbReferenceBottom"
        Me.elbReferenceBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.elbReferenceBottom.Size = New System.Drawing.Size(182, 44)
        Me.elbReferenceBottom.TabIndex = 1
        '
        'tbBottom
        '
        Me.tbBottom.BackgroundImage = CType(resources.GetObject("tbBottom.BackgroundImage"), System.Drawing.Image)
        Me.tbBottom.Beeping = False
        Me.tbBottom.ButtonText = "COMMAND REFERENCE"
        Me.tbBottom.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbBottom.ButtonTextHeight = 25
        Me.tbBottom.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbBottom.Clickable = False
        Me.tbBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.tbBottom.Data = Nothing
        Me.tbBottom.Data2 = Nothing
        Me.tbBottom.FlashInterval = 500
        Me.tbBottom.holdDraw = False
        Me.tbBottom.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbBottom.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbBottom.lblTextSize = New System.Drawing.Point(457, 23)
        Me.tbBottom.lblTextVisible = True
        Me.tbBottom.Lit = True
        Me.tbBottom.Location = New System.Drawing.Point(172, 385)
        Me.tbBottom.Name = "tbBottom"
        Me.tbBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.tbBottom.Size = New System.Drawing.Size(457, 23)
        Me.tbBottom.TabIndex = 0
        Me.tbBottom.Text = "COMMAND REFERENCE"
        '
        'elbHistoryBottom
        '
        Me.elbHistoryBottom.BackgroundImage = CType(resources.GetObject("elbHistoryBottom.BackgroundImage"), System.Drawing.Image)
        Me.elbHistoryBottom.Beeping = False
        Me.elbHistoryBottom.ButtonHeight = 10
        Me.elbHistoryBottom.ButtonText = "ENTER COMMAND"
        Me.elbHistoryBottom.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.elbHistoryBottom.ButtonTextHeight = 14
        Me.elbHistoryBottom.ButtonWidth = 100
        Me.elbHistoryBottom.Clickable = False
        Me.elbHistoryBottom.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.elbHistoryBottom.Data = Nothing
        Me.elbHistoryBottom.Data2 = Nothing
        Me.elbHistoryBottom.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbHistoryBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbHistoryBottom.FlashInterval = 500
        Me.elbHistoryBottom.holdDraw = False
        Me.elbHistoryBottom.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbHistoryBottom.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbHistoryBottom.lblTextSize = New System.Drawing.Point(617, 30)
        Me.elbHistoryBottom.lblTextVisible = True
        Me.elbHistoryBottom.Lit = True
        Me.elbHistoryBottom.Location = New System.Drawing.Point(12, 230)
        Me.elbHistoryBottom.Name = "elbHistoryBottom"
        Me.elbHistoryBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.elbHistoryBottom.Size = New System.Drawing.Size(617, 30)
        Me.elbHistoryBottom.TabIndex = 1
        Me.elbHistoryBottom.Text = "ENTER COMMAND"
        '
        'elbReferenceTop
        '
        Me.elbReferenceTop.BackgroundImage = CType(resources.GetObject("elbReferenceTop.BackgroundImage"), System.Drawing.Image)
        Me.elbReferenceTop.Beeping = False
        Me.elbReferenceTop.ButtonHeight = 10
        Me.elbReferenceTop.ButtonText = ""
        Me.elbReferenceTop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.elbReferenceTop.ButtonTextHeight = 14
        Me.elbReferenceTop.ButtonWidth = 100
        Me.elbReferenceTop.Clickable = False
        Me.elbReferenceTop.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbReferenceTop.Data = Nothing
        Me.elbReferenceTop.Data2 = Nothing
        Me.elbReferenceTop.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbReferenceTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbReferenceTop.FlashInterval = 500
        Me.elbReferenceTop.holdDraw = False
        Me.elbReferenceTop.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbReferenceTop.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbReferenceTop.lblTextSize = New System.Drawing.Point(617, 30)
        Me.elbReferenceTop.lblTextVisible = True
        Me.elbReferenceTop.Lit = True
        Me.elbReferenceTop.Location = New System.Drawing.Point(12, 266)
        Me.elbReferenceTop.Name = "elbReferenceTop"
        Me.elbReferenceTop.RedAlert = LCARS.LCARSalert.Normal
        Me.elbReferenceTop.Size = New System.Drawing.Size(617, 30)
        Me.elbReferenceTop.TabIndex = 1
        '
        'fbReferenceBorder
        '
        Me.fbReferenceBorder.BackgroundImage = CType(resources.GetObject("fbReferenceBorder.BackgroundImage"), System.Drawing.Image)
        Me.fbReferenceBorder.Beeping = False
        Me.fbReferenceBorder.ButtonText = ""
        Me.fbReferenceBorder.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbReferenceBorder.ButtonTextHeight = 14
        Me.fbReferenceBorder.Clickable = False
        Me.fbReferenceBorder.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbReferenceBorder.Data = Nothing
        Me.fbReferenceBorder.Data2 = Nothing
        Me.fbReferenceBorder.FlashInterval = 500
        Me.fbReferenceBorder.holdDraw = False
        Me.fbReferenceBorder.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbReferenceBorder.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbReferenceBorder.lblTextSize = New System.Drawing.Point(100, 56)
        Me.fbReferenceBorder.lblTextVisible = True
        Me.fbReferenceBorder.Lit = True
        Me.fbReferenceBorder.Location = New System.Drawing.Point(12, 302)
        Me.fbReferenceBorder.Name = "fbReferenceBorder"
        Me.fbReferenceBorder.RedAlert = LCARS.LCARSalert.Normal
        Me.fbReferenceBorder.Size = New System.Drawing.Size(100, 56)
        Me.fbReferenceBorder.TabIndex = 5
        '
        'fbHistoryBorder
        '
        Me.fbHistoryBorder.BackgroundImage = CType(resources.GetObject("fbHistoryBorder.BackgroundImage"), System.Drawing.Image)
        Me.fbHistoryBorder.Beeping = False
        Me.fbHistoryBorder.ButtonText = ""
        Me.fbHistoryBorder.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbHistoryBorder.ButtonTextHeight = 14
        Me.fbHistoryBorder.Clickable = False
        Me.fbHistoryBorder.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbHistoryBorder.Data = Nothing
        Me.fbHistoryBorder.Data2 = Nothing
        Me.fbHistoryBorder.FlashInterval = 500
        Me.fbHistoryBorder.holdDraw = False
        Me.fbHistoryBorder.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbHistoryBorder.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbHistoryBorder.lblTextSize = New System.Drawing.Point(100, 104)
        Me.fbHistoryBorder.lblTextVisible = True
        Me.fbHistoryBorder.Lit = True
        Me.fbHistoryBorder.Location = New System.Drawing.Point(12, 120)
        Me.fbHistoryBorder.Name = "fbHistoryBorder"
        Me.fbHistoryBorder.RedAlert = LCARS.LCARSalert.Normal
        Me.fbHistoryBorder.Size = New System.Drawing.Size(100, 104)
        Me.fbHistoryBorder.TabIndex = 6
        '
        'lstCommands
        '
        Me.lstCommands.BackColor = System.Drawing.Color.Black
        Me.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCommands.ForeColor = System.Drawing.Color.Orange
        Me.lstCommands.FormattingEnabled = True
        Me.lstCommands.ItemHeight = 21
        Me.lstCommands.Location = New System.Drawing.Point(118, 289)
        Me.lstCommands.Name = "lstCommands"
        Me.lstCommands.Size = New System.Drawing.Size(511, 84)
        Me.lstCommands.TabIndex = 3
        '
        'frmSpeechConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(641, 420)
        Me.Controls.Add(Me.fbHistoryBorder)
        Me.Controls.Add(Me.fbReferenceBorder)
        Me.Controls.Add(Me.txtEntry)
        Me.Controls.Add(Me.lstCommands)
        Me.Controls.Add(Me.lstHistory)
        Me.Controls.Add(Me.fbOnOff)
        Me.Controls.Add(Me.fbHide)
        Me.Controls.Add(Me.elbReferenceTop)
        Me.Controls.Add(Me.elbHistoryBottom)
        Me.Controls.Add(Me.elbReferenceBottom)
        Me.Controls.Add(Me.elbTop)
        Me.Controls.Add(Me.tbBottom)
        Me.Controls.Add(Me.tbTitle)
        Me.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.Name = "frmSpeechConsole"
        Me.Text = "Speech Console"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents elbTop As LCARS.Controls.Elbow
    Friend WithEvents fbHide As LCARS.Controls.FlatButton
    Friend WithEvents fbOnOff As LCARS.Controls.FlatButton
    Friend WithEvents lstHistory As System.Windows.Forms.ListBox
    Friend WithEvents txtEntry As System.Windows.Forms.TextBox
    Friend WithEvents elbReferenceBottom As LCARS.Controls.Elbow
    Friend WithEvents tbBottom As LCARS.Controls.TextButton
    Friend WithEvents elbHistoryBottom As LCARS.Controls.Elbow
    Friend WithEvents elbReferenceTop As LCARS.Controls.Elbow
    Friend WithEvents fbReferenceBorder As LCARS.Controls.FlatButton
    Friend WithEvents fbHistoryBorder As LCARS.Controls.FlatButton
    Friend WithEvents lstCommands As System.Windows.Forms.ListBox
End Class
