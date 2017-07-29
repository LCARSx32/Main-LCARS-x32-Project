<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMergeOptions
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
        Me.sbmerge = New LCARS.Controls.StandardButton
        Me.sbKeepBoth = New LCARS.Controls.StandardButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbGlobal = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.ButtonText = "MERGE DIRECTORY?"
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.tbTitle.Location = New System.Drawing.Point(12, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(390, 24)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "MERGE DIRECTORY?"
        '
        'tbBottom
        '
        Me.tbBottom.ButtonText = ""
        Me.tbBottom.ButtonTextHeight = 24
        Me.tbBottom.Clickable = False
        Me.tbBottom.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.tbBottom.Location = New System.Drawing.Point(12, 153)
        Me.tbBottom.Name = "tbBottom"
        Me.tbBottom.Size = New System.Drawing.Size(390, 24)
        Me.tbBottom.TabIndex = 1
        '
        'lblPrompt
        '
        Me.lblPrompt.Location = New System.Drawing.Point(9, 42)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(393, 24)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "The directory X already exists."
        '
        'sbDoNotCopy
        '
        Me.sbDoNotCopy.ButtonText = "DO NOT COPY"
        Me.sbDoNotCopy.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDoNotCopy.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbDoNotCopy.Lit = False
        Me.sbDoNotCopy.Location = New System.Drawing.Point(13, 69)
        Me.sbDoNotCopy.Name = "sbDoNotCopy"
        Me.sbDoNotCopy.Size = New System.Drawing.Size(144, 22)
        Me.sbDoNotCopy.TabIndex = 3
        Me.sbDoNotCopy.Text = "DO NOT COPY"
        '
        'sbmerge
        '
        Me.sbmerge.ButtonText = "MERGE DIRECTORIES"
        Me.sbmerge.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbmerge.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbmerge.Lit = False
        Me.sbmerge.Location = New System.Drawing.Point(13, 97)
        Me.sbmerge.Name = "sbmerge"
        Me.sbmerge.Size = New System.Drawing.Size(144, 22)
        Me.sbmerge.TabIndex = 3
        Me.sbmerge.Text = "MERGE DIRECTORIES"
        '
        'sbKeepBoth
        '
        Me.sbKeepBoth.ButtonText = "KEEP BOTH DIRECTORIES"
        Me.sbKeepBoth.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbKeepBoth.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbKeepBoth.Lit = False
        Me.sbKeepBoth.Location = New System.Drawing.Point(13, 125)
        Me.sbKeepBoth.Name = "sbKeepBoth"
        Me.sbKeepBoth.Size = New System.Drawing.Size(144, 22)
        Me.sbKeepBoth.TabIndex = 3
        Me.sbKeepBoth.Text = "KEEP BOTH DIRECTORIES"
        '
        'sbOK
        '
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.Location = New System.Drawing.Point(319, 125)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.Size = New System.Drawing.Size(83, 22)
        Me.sbOK.TabIndex = 3
        Me.sbOK.Text = "OK"
        '
        'sbGlobal
        '
        Me.sbGlobal.ButtonText = "USE FOR ALL OTHER CONFLICTS"
        Me.sbGlobal.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbGlobal.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbGlobal.Lit = False
        Me.sbGlobal.Location = New System.Drawing.Point(230, 69)
        Me.sbGlobal.Name = "sbGlobal"
        Me.sbGlobal.Size = New System.Drawing.Size(172, 22)
        Me.sbGlobal.TabIndex = 3
        Me.sbGlobal.Text = "USE FOR ALL OTHER CONFLICTS"
        '
        'frmMergeOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(414, 186)
        Me.Controls.Add(Me.sbKeepBoth)
        Me.Controls.Add(Me.sbmerge)
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
        Me.Name = "frmMergeOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Overwrite file?"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents tbBottom As LCARS.Controls.TextButton
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents sbDoNotCopy As LCARS.Controls.StandardButton
    Friend WithEvents sbmerge As LCARS.Controls.StandardButton
    Friend WithEvents sbKeepBoth As LCARS.Controls.StandardButton
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbGlobal As LCARS.Controls.StandardButton
End Class
