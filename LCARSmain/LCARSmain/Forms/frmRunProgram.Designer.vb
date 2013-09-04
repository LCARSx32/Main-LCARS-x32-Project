<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRunProgram
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
        Me.TextButton1 = New LCARS.Controls.TextButton
        Me.txtCommand = New System.Windows.Forms.TextBox
        Me.fbBrowse = New LCARS.Controls.FlatButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.btnEnter = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextButton1
        '
        Me.TextButton1.Beeping = False
        Me.TextButton1.ButtonText = "RUN PROGRAM"
        Me.TextButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TextButton1.ButtonTextHeight = 24
        Me.TextButton1.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.TextButton1.Clickable = False
        Me.TextButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.TextButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.TextButton1.Data = Nothing
        Me.TextButton1.Data2 = Nothing
        Me.TextButton1.FlashInterval = 500
        Me.TextButton1.holdDraw = False
        Me.TextButton1.Lit = True
        Me.TextButton1.Location = New System.Drawing.Point(13, 13)
        Me.TextButton1.Name = "TextButton1"
        Me.TextButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.TextButton1.Size = New System.Drawing.Size(405, 22)
        Me.TextButton1.TabIndex = 0
        Me.TextButton1.Text = "RUN PROGRAM"
        '
        'txtCommand
        '
        Me.txtCommand.BackColor = System.Drawing.Color.Black
        Me.txtCommand.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommand.ForeColor = System.Drawing.Color.Orange
        Me.txtCommand.Location = New System.Drawing.Point(13, 67)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(369, 29)
        Me.txtCommand.TabIndex = 1
        '
        'fbBrowse
        '
        Me.fbBrowse.Beeping = False
        Me.fbBrowse.ButtonText = "..."
        Me.fbBrowse.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fbBrowse.ButtonTextHeight = 14
        Me.fbBrowse.Clickable = True
        Me.fbBrowse.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.fbBrowse.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBrowse.Data = Nothing
        Me.fbBrowse.Data2 = Nothing
        Me.fbBrowse.FlashInterval = 500
        Me.fbBrowse.holdDraw = False
        Me.fbBrowse.Lit = True
        Me.fbBrowse.Location = New System.Drawing.Point(389, 67)
        Me.fbBrowse.Name = "fbBrowse"
        Me.fbBrowse.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBrowse.Size = New System.Drawing.Size(29, 29)
        Me.fbBrowse.TabIndex = 2
        Me.fbBrowse.Text = "..."
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
        Me.sbOK.Location = New System.Drawing.Point(295, 129)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(123, 31)
        Me.sbOK.TabIndex = 3
        Me.sbOK.Text = "OK"
        '
        'sbCancel
        '
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
        Me.sbCancel.Location = New System.Drawing.Point(166, 129)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(123, 31)
        Me.sbCancel.TabIndex = 3
        Me.sbCancel.Text = "CANCEL"
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(319, 133)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(75, 23)
        Me.btnEnter.TabIndex = 4
        Me.btnEnter.Text = "Button1"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.Location = New System.Drawing.Point(186, 133)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 5
        Me.btncancel.Text = "Button1"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'frmRunProgram
        '
        Me.AcceptButton = Me.btnEnter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.btncancel
        Me.ClientSize = New System.Drawing.Size(430, 172)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.fbBrowse)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.TextButton1)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.btncancel)
        Me.ForeColor = System.Drawing.Color.OrangeRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRunProgram"
        Me.Text = "frmRunProgram"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextButton1 As LCARS.Controls.TextButton
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox
    Friend WithEvents fbBrowse As LCARS.Controls.FlatButton
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
End Class
