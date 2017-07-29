<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopying
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
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.elbTop = New LCARS.Controls.Elbow
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.Elbow1 = New LCARS.Controls.Elbow
        Me.TextButton1 = New LCARS.Controls.TextButton
        Me.prgCopying = New LCARS.Controls.ProgressBar
        Me.lblPaths = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.tmrUIUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.ButtonText = "COPYING FILES"
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.tbTitle.Location = New System.Drawing.Point(129, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(456, 24)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "COPYING FILES"
        '
        'elbTop
        '
        Me.elbTop.ButtonHeight = 24
        Me.elbTop.ButtonText = ""
        Me.elbTop.ButtonWidth = 100
        Me.elbTop.Clickable = False
        Me.elbTop.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.elbTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbTop.Location = New System.Drawing.Point(12, 12)
        Me.elbTop.Name = "elbTop"
        Me.elbTop.Size = New System.Drawing.Size(139, 47)
        Me.elbTop.TabIndex = 1
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.ButtonText = ""
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton1.Location = New System.Drawing.Point(12, 65)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Size = New System.Drawing.Size(100, 153)
        Me.FlatButton1.TabIndex = 2
        '
        'Elbow1
        '
        Me.Elbow1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Elbow1.ButtonHeight = 24
        Me.Elbow1.ButtonText = ""
        Me.Elbow1.ButtonWidth = 100
        Me.Elbow1.Clickable = False
        Me.Elbow1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.Elbow1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow1.Location = New System.Drawing.Point(12, 224)
        Me.Elbow1.Name = "Elbow1"
        Me.Elbow1.Size = New System.Drawing.Size(139, 49)
        Me.Elbow1.TabIndex = 4
        '
        'TextButton1
        '
        Me.TextButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton1.ButtonText = ""
        Me.TextButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TextButton1.ButtonTextHeight = 24
        Me.TextButton1.Clickable = False
        Me.TextButton1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.TextButton1.Location = New System.Drawing.Point(129, 249)
        Me.TextButton1.Name = "TextButton1"
        Me.TextButton1.Size = New System.Drawing.Size(456, 24)
        Me.TextButton1.TabIndex = 3
        '
        'prgCopying
        '
        Me.prgCopying.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgCopying.BackColor = System.Drawing.Color.Black
        Me.prgCopying.BottomText = "0%"
        Me.prgCopying.BottomTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.prgCopying.Color1 = LCARS.LCARScolorStyles.StaticTan
        Me.prgCopying.Color2 = LCARS.LCARScolorStyles.PrimaryFunction
        Me.prgCopying.HorizontalBarThickness = 10
        Me.prgCopying.Location = New System.Drawing.Point(124, 65)
        Me.prgCopying.Name = "prgCopying"
        Me.prgCopying.ProgressBarOrientation = LCARS.Controls.ProgressBar.ProgressBarStyle.Horizontal
        Me.prgCopying.Size = New System.Drawing.Size(461, 100)
        Me.prgCopying.Spacing = 5
        Me.prgCopying.TabIndex = 5
        Me.prgCopying.Text = "ProgressBar1"
        Me.prgCopying.TopText = "CURRENT FILE"
        Me.prgCopying.TopTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.prgCopying.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.prgCopying.VerticalBarThickness = 20
        '
        'lblPaths
        '
        Me.lblPaths.AutoEllipsis = True
        Me.lblPaths.Location = New System.Drawing.Point(119, 37)
        Me.lblPaths.Name = "lblPaths"
        Me.lblPaths.Size = New System.Drawing.Size(466, 25)
        Me.lblPaths.TabIndex = 6
        Me.lblPaths.Text = "Copying from: X to: Y"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(119, 172)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(160, 75)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Estimated time to completion:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Items Remaining:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Data Remaining:"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.Location = New System.Drawing.Point(493, 221)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(92, 22)
        Me.sbCancel.TabIndex = 8
        Me.sbCancel.Text = "CANCEL"
        '
        'tmrUIUpdate
        '
        Me.tmrUIUpdate.Enabled = True
        '
        'frmCopying
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(597, 285)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblPaths)
        Me.Controls.Add(Me.prgCopying)
        Me.Controls.Add(Me.Elbow1)
        Me.Controls.Add(Me.TextButton1)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.elbTop)
        Me.Controls.Add(Me.tbTitle)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Font = New System.Drawing.Font("LCARS", 16.0!)
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmCopying"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCopying"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents elbTop As LCARS.Controls.Elbow
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow1 As LCARS.Controls.Elbow
    Friend WithEvents TextButton1 As LCARS.Controls.TextButton
    Friend WithEvents prgCopying As LCARS.Controls.ProgressBar
    Friend WithEvents lblPaths As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Private WithEvents tmrUIUpdate As System.Windows.Forms.Timer
End Class
