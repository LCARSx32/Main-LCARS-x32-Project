<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Installing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Installing))
        Me.lblMessage = New System.Windows.Forms.Label
        Me.pnlInstalling = New System.Windows.Forms.Panel
        Me.Progress = New runInstallScript.LCARSControls.ProgressBar
        Me.lstStatus = New System.Windows.Forms.ListBox
        Me.sbCancel = New runInstallScript.LCARSControls.StandardButton
        Me.sbContinue = New runInstallScript.LCARSControls.StandardButton
        Me.TextButton2 = New runInstallScript.LCARSControls.TextButton
        Me.TextButton1 = New runInstallScript.LCARSControls.TextButton
        Me.pnlInstalling.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(12, 77)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(326, 84)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Updates are ready to install." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please exit all LCARS programs and press ""Contin" & _
            "ue"""
        '
        'pnlInstalling
        '
        Me.pnlInstalling.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlInstalling.Controls.Add(Me.Progress)
        Me.pnlInstalling.Controls.Add(Me.lstStatus)
        Me.pnlInstalling.Location = New System.Drawing.Point(12, 41)
        Me.pnlInstalling.Name = "pnlInstalling"
        Me.pnlInstalling.Size = New System.Drawing.Size(524, 312)
        Me.pnlInstalling.TabIndex = 3
        Me.pnlInstalling.Visible = False
        '
        'Progress
        '
        Me.Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Progress.BackColor = System.Drawing.Color.Black
        Me.Progress.BottomText = "0% COMPLETE"
        Me.Progress.BottomTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Progress.Color1 = runInstallScript.LCARScolorStyles.StaticTan
        Me.Progress.Color2 = runInstallScript.LCARScolorStyles.PrimaryFunction
        Me.Progress.HorizontalBarThickness = 10
        Me.Progress.Location = New System.Drawing.Point(3, 21)
        Me.Progress.Name = "Progress"
        Me.Progress.ProgressBarOrientation = runInstallScript.LCARSControls.ProgressBar.ProgressBarStyle.Horizontal
        Me.Progress.Size = New System.Drawing.Size(518, 99)
        Me.Progress.Spacing = 5
        Me.Progress.TabIndex = 1
        Me.Progress.Text = "ProgressBar1"
        Me.Progress.TopText = "INSTALLING UPDATES"
        Me.Progress.TopTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Progress.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Progress.VerticalBarThickness = 20
        '
        'lstStatus
        '
        Me.lstStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstStatus.BackColor = System.Drawing.Color.Black
        Me.lstStatus.ForeColor = System.Drawing.Color.Orange
        Me.lstStatus.FormattingEnabled = True
        Me.lstStatus.ItemHeight = 28
        Me.lstStatus.Location = New System.Drawing.Point(3, 137)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.Size = New System.Drawing.Size(521, 172)
        Me.lstStatus.TabIndex = 0
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.BackgroundImage = CType(resources.GetObject("sbCancel.BackgroundImage"), System.Drawing.Image)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = runInstallScript.LCARSControls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = runInstallScript.LCARScolorStyles.FunctionOffline
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbCancel.lblTextSize = New System.Drawing.Point(102, 30)
        Me.sbCancel.lblTextVisible = True
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(266, 306)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = runInstallScript.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(132, 30)
        Me.sbCancel.TabIndex = 2
        Me.sbCancel.Text = "CANCEL"
        '
        'sbContinue
        '
        Me.sbContinue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbContinue.BackgroundImage = CType(resources.GetObject("sbContinue.BackgroundImage"), System.Drawing.Image)
        Me.sbContinue.Beeping = False
        Me.sbContinue.ButtonStyle = runInstallScript.LCARSControls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbContinue.ButtonText = "CONTINUE"
        Me.sbContinue.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbContinue.ButtonTextHeight = 14
        Me.sbContinue.Clickable = True
        Me.sbContinue.Color = runInstallScript.LCARScolorStyles.PrimaryFunction
        Me.sbContinue.Data = Nothing
        Me.sbContinue.Data2 = Nothing
        Me.sbContinue.FlashInterval = 500
        Me.sbContinue.holdDraw = False
        Me.sbContinue.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbContinue.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.sbContinue.lblTextSize = New System.Drawing.Point(102, 30)
        Me.sbContinue.lblTextVisible = True
        Me.sbContinue.Lit = True
        Me.sbContinue.Location = New System.Drawing.Point(404, 306)
        Me.sbContinue.Name = "sbContinue"
        Me.sbContinue.RedAlert = runInstallScript.LCARSalert.Normal
        Me.sbContinue.Size = New System.Drawing.Size(132, 30)
        Me.sbContinue.TabIndex = 2
        Me.sbContinue.Text = "CONTINUE"
        '
        'TextButton2
        '
        Me.TextButton2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton2.BackgroundImage = CType(resources.GetObject("TextButton2.BackgroundImage"), System.Drawing.Image)
        Me.TextButton2.Beeping = False
        Me.TextButton2.ButtonText = ""
        Me.TextButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TextButton2.ButtonTextHeight = 24
        Me.TextButton2.ButtonType = runInstallScript.LCARSControls.TextButton.TextButtonType.DoublePills
        Me.TextButton2.Clickable = False
        Me.TextButton2.Color = runInstallScript.LCARScolorStyles.SystemFunction
        Me.TextButton2.Data = Nothing
        Me.TextButton2.Data2 = Nothing
        Me.TextButton2.FlashInterval = 500
        Me.TextButton2.holdDraw = False
        Me.TextButton2.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton2.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.TextButton2.lblTextSize = New System.Drawing.Point(524, 22)
        Me.TextButton2.lblTextVisible = False
        Me.TextButton2.Lit = True
        Me.TextButton2.Location = New System.Drawing.Point(12, 359)
        Me.TextButton2.Name = "TextButton2"
        Me.TextButton2.RedAlert = runInstallScript.LCARSalert.Normal
        Me.TextButton2.Size = New System.Drawing.Size(524, 22)
        Me.TextButton2.TabIndex = 0
        '
        'TextButton1
        '
        Me.TextButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton1.BackgroundImage = CType(resources.GetObject("TextButton1.BackgroundImage"), System.Drawing.Image)
        Me.TextButton1.Beeping = False
        Me.TextButton1.ButtonText = "INSTALLING UPDATES"
        Me.TextButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TextButton1.ButtonTextHeight = 24
        Me.TextButton1.ButtonType = runInstallScript.LCARSControls.TextButton.TextButtonType.DoublePills
        Me.TextButton1.Clickable = False
        Me.TextButton1.Color = runInstallScript.LCARScolorStyles.SystemFunction
        Me.TextButton1.Data = Nothing
        Me.TextButton1.Data2 = Nothing
        Me.TextButton1.FlashInterval = 500
        Me.TextButton1.holdDraw = False
        Me.TextButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.TextButton1.lblTextSize = New System.Drawing.Point(523, 22)
        Me.TextButton1.lblTextVisible = False
        Me.TextButton1.Lit = True
        Me.TextButton1.Location = New System.Drawing.Point(13, 13)
        Me.TextButton1.Name = "TextButton1"
        Me.TextButton1.RedAlert = runInstallScript.LCARSalert.Normal
        Me.TextButton1.Size = New System.Drawing.Size(523, 22)
        Me.TextButton1.TabIndex = 0
        Me.TextButton1.Text = "INSTALLING UPDATES"
        '
        'Installing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(548, 393)
        Me.Controls.Add(Me.pnlInstalling)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbContinue)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.TextButton2)
        Me.Controls.Add(Me.TextButton1)
        Me.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "Installing"
        Me.Text = "Installing Updates"
        Me.pnlInstalling.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextButton1 As LCARSControls.TextButton
    Friend WithEvents TextButton2 As LCARSControls.TextButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents sbContinue As LCARSControls.StandardButton
    Friend WithEvents sbCancel As LCARSControls.StandardButton
    Friend WithEvents pnlInstalling As System.Windows.Forms.Panel
    Friend WithEvents Progress As runInstallScript.LCARSControls.ProgressBar
    Friend WithEvents lstStatus As System.Windows.Forms.ListBox

End Class
