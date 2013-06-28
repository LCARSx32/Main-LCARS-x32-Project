<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.rbLCARS = New System.Windows.Forms.RadioButton
        Me.rbExplorer = New System.Windows.Forms.RadioButton
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'rbLCARS
        '
        Me.rbLCARS.AutoSize = True
        Me.rbLCARS.Checked = True
        Me.rbLCARS.Location = New System.Drawing.Point(85, 33)
        Me.rbLCARS.Name = "rbLCARS"
        Me.rbLCARS.Size = New System.Drawing.Size(80, 17)
        Me.rbLCARS.TabIndex = 0
        Me.rbLCARS.TabStop = True
        Me.rbLCARS.Text = "LCARS x32"
        Me.rbLCARS.UseVisualStyleBackColor = True
        '
        'rbExplorer
        '
        Me.rbExplorer.AutoSize = True
        Me.rbExplorer.Location = New System.Drawing.Point(85, 56)
        Me.rbExplorer.Name = "rbExplorer"
        Me.rbExplorer.Size = New System.Drawing.Size(110, 17)
        Me.rbExplorer.TabIndex = 1
        Me.rbExplorer.Text = "Windows Explorer"
        Me.rbExplorer.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(197, 99)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 134)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rbExplorer)
        Me.Controls.Add(Me.rbLCARS)
        Me.Name = "Form1"
        Me.Text = "Set Shell"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbLCARS As System.Windows.Forms.RadioButton
    Friend WithEvents rbExplorer As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button

End Class
