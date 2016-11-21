<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
    Inherits LCARS.LCARSForm

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
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.lblMessage = New System.Windows.Forms.Label
        Me.lstUpdates = New System.Windows.Forms.ListBox
        Me.sbNext = New LCARS.Controls.StandardButton
        Me.pnlDownloadList = New System.Windows.Forms.Panel
        Me.rtbServer = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(518, 387)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(126, 35)
        Me.sbCancel.TabIndex = 0
        Me.sbCancel.Text = "CANCEL"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "LCARS UPDATE"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(13, 13)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(631, 24)
        Me.tbTitle.TabIndex = 1
        Me.tbTitle.Text = "LCARS UPDATE"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(13, 42)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(119, 24)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Checking for updates."
        '
        'lstUpdates
        '
        Me.lstUpdates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstUpdates.BackColor = System.Drawing.Color.Black
        Me.lstUpdates.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstUpdates.ForeColor = System.Drawing.Color.Orange
        Me.lstUpdates.FormattingEnabled = True
        Me.lstUpdates.ItemHeight = 24
        Me.lstUpdates.Location = New System.Drawing.Point(13, 70)
        Me.lstUpdates.Name = "lstUpdates"
        Me.lstUpdates.Size = New System.Drawing.Size(631, 292)
        Me.lstUpdates.TabIndex = 3
        '
        'sbNext
        '
        Me.sbNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbNext.Beeping = False
        Me.sbNext.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbNext.ButtonText = "NEXT"
        Me.sbNext.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbNext.ButtonTextHeight = 14
        Me.sbNext.Clickable = False
        Me.sbNext.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbNext.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbNext.Data = Nothing
        Me.sbNext.Data2 = Nothing
        Me.sbNext.FlashInterval = 500
        Me.sbNext.holdDraw = False
        Me.sbNext.Lit = False
        Me.sbNext.Location = New System.Drawing.Point(386, 387)
        Me.sbNext.Name = "sbNext"
        Me.sbNext.RedAlert = LCARS.LCARSalert.Normal
        Me.sbNext.Size = New System.Drawing.Size(126, 35)
        Me.sbNext.TabIndex = 0
        Me.sbNext.Text = "NEXT"
        '
        'pnlDownloadList
        '
        Me.pnlDownloadList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDownloadList.AutoScroll = True
        Me.pnlDownloadList.AutoScrollMinSize = New System.Drawing.Size(20, 20)
        Me.pnlDownloadList.Location = New System.Drawing.Point(13, 69)
        Me.pnlDownloadList.Name = "pnlDownloadList"
        Me.pnlDownloadList.Size = New System.Drawing.Size(631, 312)
        Me.pnlDownloadList.TabIndex = 4
        Me.pnlDownloadList.Visible = False
        '
        'rtbServer
        '
        Me.rtbServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbServer.BackColor = System.Drawing.Color.Black
        Me.rtbServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbServer.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbServer.ForeColor = System.Drawing.Color.Orange
        Me.rtbServer.Location = New System.Drawing.Point(13, 388)
        Me.rtbServer.Multiline = False
        Me.rtbServer.Name = "rtbServer"
        Me.rtbServer.ReadOnly = True
        Me.rtbServer.Size = New System.Drawing.Size(367, 34)
        Me.rtbServer.TabIndex = 5
        Me.rtbServer.Text = ""
        Me.rtbServer.Visible = False
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(656, 434)
        Me.Controls.Add(Me.rtbServer)
        Me.Controls.Add(Me.pnlDownloadList)
        Me.Controls.Add(Me.lstUpdates)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.sbNext)
        Me.Controls.Add(Me.sbCancel)
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUpdate"
        Me.Text = "LCARS Update"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lstUpdates As System.Windows.Forms.ListBox
    Friend WithEvents sbNext As LCARS.Controls.StandardButton
    Friend WithEvents pnlDownloadList As System.Windows.Forms.Panel
    Friend WithEvents rtbServer As System.Windows.Forms.RichTextBox

End Class
