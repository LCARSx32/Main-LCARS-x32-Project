<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRename
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
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.txtNew = New System.Windows.Forms.TextBox
        Me.lblFileName = New System.Windows.Forms.Label
        Me.lblRename = New System.Windows.Forms.Label
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'sbOK
        '
        Me.sbOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOK.Beeping = False
        Me.sbOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbOK.ButtonTextHeight = 14
        Me.sbOK.Clickable = True
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOK.Data = Nothing
        Me.sbOK.Data2 = Nothing
        Me.sbOK.DialogResult = System.Windows.Forms.DialogResult.None
        Me.sbOK.FlashInterval = 500
        Me.sbOK.holdDraw = False
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(305, 340)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(87, 26)
        Me.sbOK.TabIndex = 2
        Me.sbOK.Text = "OK"
        '
        'txtNew
        '
        Me.txtNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNew.BackColor = System.Drawing.Color.Black
        Me.txtNew.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNew.ForeColor = System.Drawing.Color.Orange
        Me.txtNew.Location = New System.Drawing.Point(41, 187)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(351, 38)
        Me.txtNew.TabIndex = 1
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(37, 155)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(104, 21)
        Me.lblFileName.TabIndex = 58
        Me.lblFileName.Text = "File/Directory Name:"
        '
        'lblRename
        '
        Me.lblRename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRename.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRename.ForeColor = System.Drawing.Color.Orange
        Me.lblRename.Location = New System.Drawing.Point(12, 5)
        Me.lblRename.Name = "lblRename"
        Me.lblRename.Size = New System.Drawing.Size(397, 52)
        Me.lblRename.TabIndex = 57
        Me.lblRename.Text = "RENAME"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(212, 340)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(87, 26)
        Me.sbCancel.TabIndex = 3
        Me.sbCancel.Text = "CANCEL"
        '
        'frmRename
        '
        Me.AcceptButton = Me.sbOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(422, 371)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblRename)
        Me.Controls.Add(Me.sbCancel)
        Me.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.Name = "frmRename"
        Me.Text = "frmRename"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblRename As System.Windows.Forms.Label
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
End Class
