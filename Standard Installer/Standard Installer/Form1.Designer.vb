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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtInstallPath = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkDesktop = New System.Windows.Forms.CheckBox
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnlInstalling = New System.Windows.Forms.Panel
        Me.lstInstalling = New System.Windows.Forms.ListBox
        Me.progress = New System.Windows.Forms.ProgressBar
        Me.pnlInstalling.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This program will install LCARS x32 on your system." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select your installation opt" & _
            "ions below and click next."
        '
        'txtInstallPath
        '
        Me.txtInstallPath.Location = New System.Drawing.Point(12, 76)
        Me.txtInstallPath.Name = "txtInstallPath"
        Me.txtInstallPath.Size = New System.Drawing.Size(292, 20)
        Me.txtInstallPath.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(311, 76)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(36, 20)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Install Path:"
        '
        'chkDesktop
        '
        Me.chkDesktop.AutoSize = True
        Me.chkDesktop.Checked = True
        Me.chkDesktop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesktop.Location = New System.Drawing.Point(13, 127)
        Me.chkDesktop.Name = "chkDesktop"
        Me.chkDesktop.Size = New System.Drawing.Size(139, 17)
        Me.chkDesktop.TabIndex = 4
        Me.chkDesktop.Text = "Create desktop shortcut"
        Me.chkDesktop.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(272, 175)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(191, 175)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlInstalling
        '
        Me.pnlInstalling.Controls.Add(Me.lstInstalling)
        Me.pnlInstalling.Controls.Add(Me.progress)
        Me.pnlInstalling.Location = New System.Drawing.Point(12, 12)
        Me.pnlInstalling.Name = "pnlInstalling"
        Me.pnlInstalling.Size = New System.Drawing.Size(335, 185)
        Me.pnlInstalling.TabIndex = 7
        Me.pnlInstalling.Visible = False
        '
        'lstInstalling
        '
        Me.lstInstalling.FormattingEnabled = True
        Me.lstInstalling.Location = New System.Drawing.Point(4, 33)
        Me.lstInstalling.Name = "lstInstalling"
        Me.lstInstalling.Size = New System.Drawing.Size(328, 147)
        Me.lstInstalling.TabIndex = 1
        '
        'progress
        '
        Me.progress.Location = New System.Drawing.Point(4, 3)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(328, 23)
        Me.progress.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 210)
        Me.Controls.Add(Me.pnlInstalling)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.chkDesktop)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtInstallPath)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "LCARS x32 Installer"
        Me.pnlInstalling.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInstallPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkDesktop As System.Windows.Forms.CheckBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlInstalling As System.Windows.Forms.Panel
    Friend WithEvents lstInstalling As System.Windows.Forms.ListBox
    Friend WithEvents progress As System.Windows.Forms.ProgressBar

End Class
