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
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.elbTop = New LCARS.Controls.Elbow
        Me.fbHide = New LCARS.Controls.FlatButton
        Me.fbOnOff = New LCARS.Controls.FlatButton
        Me.txtEntry = New System.Windows.Forms.TextBox
        Me.elbReferenceBottom = New LCARS.Controls.Elbow
        Me.tbBottom = New LCARS.Controls.TextButton
        Me.elbHistoryBottom = New LCARS.Controls.Elbow
        Me.elbReferenceTop = New LCARS.Controls.Elbow
        Me.fbReferenceBorder = New LCARS.Controls.FlatButton
        Me.fbHistoryBorder = New LCARS.Controls.FlatButton
        Me.lstCommands = New System.Windows.Forms.ListBox
        Me.txtHistory = New System.Windows.Forms.TextBox
        Me.fbClearHistory = New LCARS.Controls.FlatButton
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.ButtonText = "VOICE RECOGNITION CONSOLE"
        Me.tbTitle.ButtonTextHeight = 25
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.tbTitle.Location = New System.Drawing.Point(172, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(457, 24)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "VOICE RECOGNITION CONSOLE"
        '
        'elbTop
        '
        Me.elbTop.ButtonHeight = 24
        Me.elbTop.ButtonText = "COMMAND HISTORY"
        Me.elbTop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.elbTop.ButtonWidth = 100
        Me.elbTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.elbTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbTop.Location = New System.Drawing.Point(12, 12)
        Me.elbTop.Name = "elbTop"
        Me.elbTop.Size = New System.Drawing.Size(182, 44)
        Me.elbTop.TabIndex = 1
        Me.elbTop.Text = "COMMAND HISTORY"
        '
        'fbHide
        '
        Me.fbHide.ButtonText = "HIDE"
        Me.fbHide.Location = New System.Drawing.Point(12, 62)
        Me.fbHide.Name = "fbHide"
        Me.fbHide.Size = New System.Drawing.Size(100, 23)
        Me.fbHide.TabIndex = 2
        Me.fbHide.Text = "HIDE"
        '
        'fbOnOff
        '
        Me.fbOnOff.ButtonText = "RECOGNITION ON"
        Me.fbOnOff.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.fbOnOff.Location = New System.Drawing.Point(12, 91)
        Me.fbOnOff.Name = "fbOnOff"
        Me.fbOnOff.Size = New System.Drawing.Size(100, 23)
        Me.fbOnOff.TabIndex = 2
        Me.fbOnOff.Text = "RECOGNITION ON"
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
        Me.elbReferenceBottom.ButtonHeight = 24
        Me.elbReferenceBottom.ButtonText = ""
        Me.elbReferenceBottom.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.elbReferenceBottom.ButtonWidth = 100
        Me.elbReferenceBottom.Clickable = False
        Me.elbReferenceBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbReferenceBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbReferenceBottom.Location = New System.Drawing.Point(12, 364)
        Me.elbReferenceBottom.Name = "elbReferenceBottom"
        Me.elbReferenceBottom.Size = New System.Drawing.Size(182, 45)
        Me.elbReferenceBottom.TabIndex = 1
        '
        'tbBottom
        '
        Me.tbBottom.ButtonText = "COMMAND REFERENCE"
        Me.tbBottom.ButtonTextHeight = 25
        Me.tbBottom.Clickable = False
        Me.tbBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.tbBottom.Location = New System.Drawing.Point(172, 385)
        Me.tbBottom.Name = "tbBottom"
        Me.tbBottom.Size = New System.Drawing.Size(457, 24)
        Me.tbBottom.TabIndex = 0
        Me.tbBottom.Text = "COMMAND REFERENCE"
        '
        'elbHistoryBottom
        '
        Me.elbHistoryBottom.ButtonHeight = 10
        Me.elbHistoryBottom.ButtonText = "ENTER COMMAND"
        Me.elbHistoryBottom.ButtonWidth = 100
        Me.elbHistoryBottom.Clickable = False
        Me.elbHistoryBottom.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.elbHistoryBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbHistoryBottom.Location = New System.Drawing.Point(12, 230)
        Me.elbHistoryBottom.Name = "elbHistoryBottom"
        Me.elbHistoryBottom.Size = New System.Drawing.Size(617, 30)
        Me.elbHistoryBottom.TabIndex = 1
        Me.elbHistoryBottom.Text = "ENTER COMMAND"
        '
        'elbReferenceTop
        '
        Me.elbReferenceTop.ButtonHeight = 10
        Me.elbReferenceTop.ButtonText = ""
        Me.elbReferenceTop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.elbReferenceTop.ButtonWidth = 100
        Me.elbReferenceTop.Clickable = False
        Me.elbReferenceTop.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbReferenceTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbReferenceTop.Location = New System.Drawing.Point(12, 266)
        Me.elbReferenceTop.Name = "elbReferenceTop"
        Me.elbReferenceTop.Size = New System.Drawing.Size(617, 30)
        Me.elbReferenceTop.TabIndex = 1
        '
        'fbReferenceBorder
        '
        Me.fbReferenceBorder.ButtonText = ""
        Me.fbReferenceBorder.Clickable = False
        Me.fbReferenceBorder.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbReferenceBorder.Location = New System.Drawing.Point(12, 302)
        Me.fbReferenceBorder.Name = "fbReferenceBorder"
        Me.fbReferenceBorder.Size = New System.Drawing.Size(100, 56)
        Me.fbReferenceBorder.TabIndex = 5
        '
        'fbHistoryBorder
        '
        Me.fbHistoryBorder.ButtonText = ""
        Me.fbHistoryBorder.Clickable = False
        Me.fbHistoryBorder.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.fbHistoryBorder.Location = New System.Drawing.Point(12, 149)
        Me.fbHistoryBorder.Name = "fbHistoryBorder"
        Me.fbHistoryBorder.Size = New System.Drawing.Size(100, 75)
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
        'txtHistory
        '
        Me.txtHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHistory.BackColor = System.Drawing.Color.Black
        Me.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistory.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistory.ForeColor = System.Drawing.Color.Orange
        Me.txtHistory.Location = New System.Drawing.Point(118, 42)
        Me.txtHistory.Multiline = True
        Me.txtHistory.Name = "txtHistory"
        Me.txtHistory.ReadOnly = True
        Me.txtHistory.Size = New System.Drawing.Size(511, 168)
        Me.txtHistory.TabIndex = 7
        '
        'fbClearHistory
        '
        Me.fbClearHistory.ButtonText = "CLEAR HISTORY"
        Me.fbClearHistory.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.fbClearHistory.Location = New System.Drawing.Point(12, 120)
        Me.fbClearHistory.Name = "fbClearHistory"
        Me.fbClearHistory.Size = New System.Drawing.Size(101, 23)
        Me.fbClearHistory.TabIndex = 8
        Me.fbClearHistory.Text = "CLEAR HISTORY"
        '
        'frmSpeechConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(641, 420)
        Me.Controls.Add(Me.fbClearHistory)
        Me.Controls.Add(Me.txtHistory)
        Me.Controls.Add(Me.fbHistoryBorder)
        Me.Controls.Add(Me.fbReferenceBorder)
        Me.Controls.Add(Me.txtEntry)
        Me.Controls.Add(Me.lstCommands)
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
    Friend WithEvents txtEntry As System.Windows.Forms.TextBox
    Friend WithEvents elbReferenceBottom As LCARS.Controls.Elbow
    Friend WithEvents tbBottom As LCARS.Controls.TextButton
    Friend WithEvents elbHistoryBottom As LCARS.Controls.Elbow
    Friend WithEvents elbReferenceTop As LCARS.Controls.Elbow
    Friend WithEvents fbReferenceBorder As LCARS.Controls.FlatButton
    Friend WithEvents fbHistoryBorder As LCARS.Controls.FlatButton
    Friend WithEvents lstCommands As System.Windows.Forms.ListBox
    Friend WithEvents txtHistory As System.Windows.Forms.TextBox
    Friend WithEvents fbClearHistory As LCARS.Controls.FlatButton
End Class
