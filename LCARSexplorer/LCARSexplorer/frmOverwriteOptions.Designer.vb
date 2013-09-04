<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOverwriteOptions
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
        Me.tbBottom = New LCARS.Controls.TextButton
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.sbDoNotCopy = New LCARS.Controls.StandardButton
        Me.sbOverwrite = New LCARS.Controls.StandardButton
        Me.sbKeepBoth = New LCARS.Controls.StandardButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbGlobal = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "OVERWRITE FILE?"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(12, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(390, 22)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "OVERWRITE FILE?"
        '
        'tbBottom
        '
        Me.tbBottom.Beeping = False
        Me.tbBottom.ButtonText = ""
        Me.tbBottom.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbBottom.ButtonTextHeight = 24
        Me.tbBottom.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbBottom.Clickable = False
        Me.tbBottom.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.tbBottom.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbBottom.Data = Nothing
        Me.tbBottom.Data2 = Nothing
        Me.tbBottom.FlashInterval = 500
        Me.tbBottom.holdDraw = False
        Me.tbBottom.Lit = True
        Me.tbBottom.Location = New System.Drawing.Point(12, 153)
        Me.tbBottom.Name = "tbBottom"
        Me.tbBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.tbBottom.Size = New System.Drawing.Size(390, 22)
        Me.tbBottom.TabIndex = 1
        '
        'lblPrompt
        '
        Me.lblPrompt.Location = New System.Drawing.Point(9, 42)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(393, 24)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "The file X already exists."
        '
        'sbDoNotCopy
        '
        Me.sbDoNotCopy.Beeping = False
        Me.sbDoNotCopy.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbDoNotCopy.ButtonText = "DO NOT COPY"
        Me.sbDoNotCopy.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDoNotCopy.ButtonTextHeight = 14
        Me.sbDoNotCopy.Clickable = True
        Me.sbDoNotCopy.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbDoNotCopy.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDoNotCopy.Data = Nothing
        Me.sbDoNotCopy.Data2 = Nothing
        Me.sbDoNotCopy.FlashInterval = 500
        Me.sbDoNotCopy.holdDraw = False
        Me.sbDoNotCopy.Lit = False
        Me.sbDoNotCopy.Location = New System.Drawing.Point(13, 69)
        Me.sbDoNotCopy.Name = "sbDoNotCopy"
        Me.sbDoNotCopy.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDoNotCopy.Size = New System.Drawing.Size(110, 22)
        Me.sbDoNotCopy.TabIndex = 3
        Me.sbDoNotCopy.Text = "DO NOT COPY"
        '
        'sbOverwrite
        '
        Me.sbOverwrite.Beeping = False
        Me.sbOverwrite.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOverwrite.ButtonText = "OVERWRITE"
        Me.sbOverwrite.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOverwrite.ButtonTextHeight = 14
        Me.sbOverwrite.Clickable = True
        Me.sbOverwrite.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbOverwrite.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOverwrite.Data = Nothing
        Me.sbOverwrite.Data2 = Nothing
        Me.sbOverwrite.FlashInterval = 500
        Me.sbOverwrite.holdDraw = False
        Me.sbOverwrite.Lit = False
        Me.sbOverwrite.Location = New System.Drawing.Point(13, 97)
        Me.sbOverwrite.Name = "sbOverwrite"
        Me.sbOverwrite.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOverwrite.Size = New System.Drawing.Size(110, 22)
        Me.sbOverwrite.TabIndex = 3
        Me.sbOverwrite.Text = "OVERWRITE"
        '
        'sbKeepBoth
        '
        Me.sbKeepBoth.Beeping = False
        Me.sbKeepBoth.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbKeepBoth.ButtonText = "KEEP BOTH FILES"
        Me.sbKeepBoth.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbKeepBoth.ButtonTextHeight = 14
        Me.sbKeepBoth.Clickable = True
        Me.sbKeepBoth.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbKeepBoth.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbKeepBoth.Data = Nothing
        Me.sbKeepBoth.Data2 = Nothing
        Me.sbKeepBoth.FlashInterval = 500
        Me.sbKeepBoth.holdDraw = False
        Me.sbKeepBoth.Lit = False
        Me.sbKeepBoth.Location = New System.Drawing.Point(13, 125)
        Me.sbKeepBoth.Name = "sbKeepBoth"
        Me.sbKeepBoth.RedAlert = LCARS.LCARSalert.Normal
        Me.sbKeepBoth.Size = New System.Drawing.Size(110, 22)
        Me.sbKeepBoth.TabIndex = 3
        Me.sbKeepBoth.Text = "KEEP BOTH FILES"
        '
        'sbOK
        '
        Me.sbOK.Beeping = False
        Me.sbOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.ButtonTextHeight = 14
        Me.sbOK.Clickable = True
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOK.Data = Nothing
        Me.sbOK.Data2 = Nothing
        Me.sbOK.FlashInterval = 500
        Me.sbOK.holdDraw = False
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(319, 125)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(83, 22)
        Me.sbOK.TabIndex = 3
        Me.sbOK.Text = "OK"
        '
        'sbGlobal
        '
        Me.sbGlobal.Beeping = False
        Me.sbGlobal.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbGlobal.ButtonText = "USE FOR ALL OTHER CONFLICTS"
        Me.sbGlobal.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbGlobal.ButtonTextHeight = 14
        Me.sbGlobal.Clickable = True
        Me.sbGlobal.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbGlobal.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbGlobal.Data = Nothing
        Me.sbGlobal.Data2 = Nothing
        Me.sbGlobal.FlashInterval = 500
        Me.sbGlobal.holdDraw = False
        Me.sbGlobal.Lit = False
        Me.sbGlobal.Location = New System.Drawing.Point(230, 69)
        Me.sbGlobal.Name = "sbGlobal"
        Me.sbGlobal.RedAlert = LCARS.LCARSalert.Normal
        Me.sbGlobal.Size = New System.Drawing.Size(172, 22)
        Me.sbGlobal.TabIndex = 3
        Me.sbGlobal.Text = "USE FOR ALL OTHER CONFLICTS"
        '
        'frmOverwriteOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(414, 186)
        Me.Controls.Add(Me.sbKeepBoth)
        Me.Controls.Add(Me.sbOverwrite)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.sbGlobal)
        Me.Controls.Add(Me.sbDoNotCopy)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.tbBottom)
        Me.Controls.Add(Me.tbTitle)
        Me.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmOverwriteOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Overwrite file?"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents tbBottom As LCARS.Controls.TextButton
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents sbDoNotCopy As LCARS.Controls.StandardButton
    Friend WithEvents sbOverwrite As LCARS.Controls.StandardButton
    Friend WithEvents sbKeepBoth As LCARS.Controls.StandardButton
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbGlobal As LCARS.Controls.StandardButton
End Class
