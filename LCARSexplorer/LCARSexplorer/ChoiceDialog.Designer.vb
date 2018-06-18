<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoiceDialog(Of T)
    Inherits LCARS.LCARSForm

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
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.lstChoices = New LCARS.Controls.LCARSList
        Me.SuspendLayout()
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.ButtonText = "TITLE"
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.Location = New System.Drawing.Point(0, 0)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(385, 22)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "TITLE"
        '
        'sbOK
        '
        Me.sbOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.sbOK.Location = New System.Drawing.Point(288, 212)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.Size = New System.Drawing.Size(97, 25)
        Me.sbOK.TabIndex = 1
        Me.sbOK.Text = "OK"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(185, 212)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(97, 25)
        Me.sbCancel.TabIndex = 1
        Me.sbCancel.Text = "CANCEL"
        '
        'lstChoices
        '
        Me.lstChoices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstChoices.FormattingEnabled = True
        Me.lstChoices.ItemHeight = 25
        Me.lstChoices.Location = New System.Drawing.Point(13, 29)
        Me.lstChoices.Name = "lstChoices"
        Me.lstChoices.Size = New System.Drawing.Size(360, 177)
        Me.lstChoices.TabIndex = 2
        Me.lstChoices.TabStops = New Single(-1) {}
        '
        'ChoiceDialog
        '
        Me.AcceptButton = Me.sbOK
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(385, 237)
        Me.Controls.Add(Me.lstChoices)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.tbTitle)
        Me.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChoiceDialog"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents lstChoices As LCARS.Controls.LCARSList

End Class
