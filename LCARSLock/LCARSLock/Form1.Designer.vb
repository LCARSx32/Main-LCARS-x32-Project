<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLock))
        Me.lblOmega = New System.Windows.Forms.Label
        Me.lblEnter = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Settings = New LCARS.Controls.FlatButton
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.HalfPillButton2 = New LCARS.Controls.HalfPillButton
        Me.HalfPillButton1 = New LCARS.Controls.HalfPillButton
        Me.sbSubmit = New LCARS.Controls.StandardButton
        Me.tbTop = New LCARS.Controls.TextButton
        Me.pnlSettings = New System.Windows.Forms.Panel
        Me.sbReset = New LCARS.Controls.StandardButton
        Me.txtOld = New System.Windows.Forms.TextBox
        Me.txtNew = New System.Windows.Forms.TextBox
        Me.lblReset = New System.Windows.Forms.Label
        Me.pnlSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblOmega
        '
        Me.lblOmega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOmega.Font = New System.Drawing.Font("LCARS", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOmega.Location = New System.Drawing.Point(70, 60)
        Me.lblOmega.Name = "lblOmega"
        Me.lblOmega.Size = New System.Drawing.Size(496, 453)
        Me.lblOmega.TabIndex = 1
        Me.lblOmega.Text = "Ω"
        Me.lblOmega.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEnter
        '
        Me.lblEnter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEnter.AutoSize = True
        Me.lblEnter.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnter.Location = New System.Drawing.Point(12, 474)
        Me.lblEnter.Name = "lblEnter"
        Me.lblEnter.Size = New System.Drawing.Size(230, 39)
        Me.lblEnter.TabIndex = 3
        Me.lblEnter.Text = "Enter Authorization Code:"
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.BackColor = System.Drawing.Color.Black
        Me.txtCode.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.ForeColor = System.Drawing.Color.Orange
        Me.txtCode.Location = New System.Drawing.Point(240, 471)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtCode.Size = New System.Drawing.Size(206, 47)
        Me.txtCode.TabIndex = 0
        '
        'Settings
        '
        Me.Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Settings.BackgroundImage = CType(resources.GetObject("Settings.BackgroundImage"), System.Drawing.Image)
        Me.Settings.Beeping = False
        Me.Settings.ButtonText = "SETTINGS"
        Me.Settings.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Settings.ButtonTextHeight = 14
        Me.Settings.Clickable = True
        Me.Settings.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.Settings.CustomAlertColor = System.Drawing.Color.Empty
        Me.Settings.Data = Nothing
        Me.Settings.Data2 = Nothing
        Me.Settings.FlashInterval = 500
        Me.Settings.holdDraw = False
        Me.Settings.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.Settings.lblTextSize = New System.Drawing.Point(74, 27)
        Me.Settings.lblTextVisible = True
        Me.Settings.Lit = True
        Me.Settings.Location = New System.Drawing.Point(46, 534)
        Me.Settings.Name = "Settings"
        Me.Settings.RedAlert = LCARS.LCARSalert.Normal
        Me.Settings.Size = New System.Drawing.Size(74, 27)
        Me.Settings.TabIndex = 6
        Me.Settings.Text = "SETTINGS"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.BackgroundImage = CType(resources.GetObject("FlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = ""
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = False
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton1.lblTextSize = New System.Drawing.Point(465, 27)
        Me.FlatButton1.lblTextVisible = True
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(126, 534)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(465, 27)
        Me.FlatButton1.TabIndex = 6
        '
        'HalfPillButton2
        '
        Me.HalfPillButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton2.BackgroundImage = CType(resources.GetObject("HalfPillButton2.BackgroundImage"), System.Drawing.Image)
        Me.HalfPillButton2.Beeping = False
        Me.HalfPillButton2.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillLeft
        Me.HalfPillButton2.ButtonText = ""
        Me.HalfPillButton2.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.HalfPillButton2.ButtonTextHeight = 14
        Me.HalfPillButton2.Clickable = False
        Me.HalfPillButton2.Color = LCARS.LCARScolorStyles.StaticTan
        Me.HalfPillButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.HalfPillButton2.Data = Nothing
        Me.HalfPillButton2.Data2 = Nothing
        Me.HalfPillButton2.FlashInterval = 500
        Me.HalfPillButton2.holdDraw = False
        Me.HalfPillButton2.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton2.lblTextLoc = New System.Drawing.Point(13, 0)
        Me.HalfPillButton2.lblTextSize = New System.Drawing.Point(15, 27)
        Me.HalfPillButton2.lblTextVisible = True
        Me.HalfPillButton2.Lit = True
        Me.HalfPillButton2.Location = New System.Drawing.Point(12, 534)
        Me.HalfPillButton2.Name = "HalfPillButton2"
        Me.HalfPillButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.HalfPillButton2.Size = New System.Drawing.Size(28, 27)
        Me.HalfPillButton2.TabIndex = 5
        '
        'HalfPillButton1
        '
        Me.HalfPillButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton1.BackgroundImage = CType(resources.GetObject("HalfPillButton1.BackgroundImage"), System.Drawing.Image)
        Me.HalfPillButton1.Beeping = False
        Me.HalfPillButton1.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.HalfPillButton1.ButtonText = ""
        Me.HalfPillButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.HalfPillButton1.ButtonTextHeight = 14
        Me.HalfPillButton1.Clickable = False
        Me.HalfPillButton1.Color = LCARS.LCARScolorStyles.StaticTan
        Me.HalfPillButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.HalfPillButton1.Data = Nothing
        Me.HalfPillButton1.Data2 = Nothing
        Me.HalfPillButton1.FlashInterval = 500
        Me.HalfPillButton1.holdDraw = False
        Me.HalfPillButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HalfPillButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.HalfPillButton1.lblTextSize = New System.Drawing.Point(15, 27)
        Me.HalfPillButton1.lblTextVisible = True
        Me.HalfPillButton1.Lit = True
        Me.HalfPillButton1.Location = New System.Drawing.Point(597, 534)
        Me.HalfPillButton1.Name = "HalfPillButton1"
        Me.HalfPillButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.HalfPillButton1.Size = New System.Drawing.Size(28, 27)
        Me.HalfPillButton1.TabIndex = 5
        '
        'sbSubmit
        '
        Me.sbSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSubmit.BackgroundImage = CType(resources.GetObject("sbSubmit.BackgroundImage"), System.Drawing.Image)
        Me.sbSubmit.Beeping = False
        Me.sbSubmit.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSubmit.ButtonText = "SUBMIT"
        Me.sbSubmit.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbSubmit.ButtonTextHeight = 14
        Me.sbSubmit.Clickable = True
        Me.sbSubmit.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbSubmit.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbSubmit.Data = Nothing
        Me.sbSubmit.Data2 = Nothing
        Me.sbSubmit.FlashInterval = 500
        Me.sbSubmit.holdDraw = False
        Me.sbSubmit.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSubmit.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbSubmit.lblTextSize = New System.Drawing.Point(111, 36)
        Me.sbSubmit.lblTextVisible = True
        Me.sbSubmit.Lit = True
        Me.sbSubmit.Location = New System.Drawing.Point(478, 477)
        Me.sbSubmit.Name = "sbSubmit"
        Me.sbSubmit.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSubmit.Size = New System.Drawing.Size(147, 36)
        Me.sbSubmit.TabIndex = 2
        Me.sbSubmit.Text = "SUBMIT"
        '
        'tbTop
        '
        Me.tbTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTop.BackgroundImage = CType(resources.GetObject("tbTop.BackgroundImage"), System.Drawing.Image)
        Me.tbTop.Beeping = False
        Me.tbTop.ButtonText = "SYSTEM LOCKED"
        Me.tbTop.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTop.ButtonTextHeight = 30
        Me.tbTop.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTop.Clickable = False
        Me.tbTop.Color = LCARS.LCARScolorStyles.StaticTan
        Me.tbTop.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTop.Data = Nothing
        Me.tbTop.Data2 = Nothing
        Me.tbTop.FlashInterval = 500
        Me.tbTop.holdDraw = False
        Me.tbTop.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTop.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbTop.lblTextSize = New System.Drawing.Point(613, 27)
        Me.tbTop.lblTextVisible = True
        Me.tbTop.Lit = True
        Me.tbTop.Location = New System.Drawing.Point(12, 12)
        Me.tbTop.Name = "tbTop"
        Me.tbTop.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTop.Size = New System.Drawing.Size(613, 27)
        Me.tbTop.TabIndex = 0
        Me.tbTop.Text = "SYSTEM LOCKED"
        '
        'pnlSettings
        '
        Me.pnlSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSettings.Controls.Add(Me.sbReset)
        Me.pnlSettings.Controls.Add(Me.txtOld)
        Me.pnlSettings.Controls.Add(Me.txtNew)
        Me.pnlSettings.Controls.Add(Me.lblReset)
        Me.pnlSettings.Location = New System.Drawing.Point(12, 45)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(613, 482)
        Me.pnlSettings.TabIndex = 7
        Me.pnlSettings.Visible = False
        '
        'sbReset
        '
        Me.sbReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbReset.BackgroundImage = CType(resources.GetObject("sbReset.BackgroundImage"), System.Drawing.Image)
        Me.sbReset.Beeping = False
        Me.sbReset.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbReset.ButtonText = "SUBMIT"
        Me.sbReset.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbReset.ButtonTextHeight = 14
        Me.sbReset.Clickable = True
        Me.sbReset.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbReset.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbReset.Data = Nothing
        Me.sbReset.Data2 = Nothing
        Me.sbReset.FlashInterval = 500
        Me.sbReset.holdDraw = False
        Me.sbReset.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbReset.lblTextLoc = New System.Drawing.Point(23, 0)
        Me.sbReset.lblTextSize = New System.Drawing.Point(86, 47)
        Me.sbReset.lblTextVisible = True
        Me.sbReset.Lit = True
        Me.sbReset.Location = New System.Drawing.Point(466, 429)
        Me.sbReset.Name = "sbReset"
        Me.sbReset.RedAlert = LCARS.LCARSalert.Normal
        Me.sbReset.Size = New System.Drawing.Size(133, 47)
        Me.sbReset.TabIndex = 4
        Me.sbReset.Text = "SUBMIT"
        '
        'txtOld
        '
        Me.txtOld.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOld.BackColor = System.Drawing.Color.Black
        Me.txtOld.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOld.ForeColor = System.Drawing.Color.Orange
        Me.txtOld.Location = New System.Drawing.Point(182, 75)
        Me.txtOld.Name = "txtOld"
        Me.txtOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtOld.Size = New System.Drawing.Size(417, 47)
        Me.txtOld.TabIndex = 0
        '
        'txtNew
        '
        Me.txtNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNew.BackColor = System.Drawing.Color.Black
        Me.txtNew.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNew.ForeColor = System.Drawing.Color.Orange
        Me.txtNew.Location = New System.Drawing.Point(182, 150)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtNew.Size = New System.Drawing.Size(417, 47)
        Me.txtNew.TabIndex = 0
        '
        'lblReset
        '
        Me.lblReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReset.AutoSize = True
        Me.lblReset.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReset.Location = New System.Drawing.Point(0, 0)
        Me.lblReset.Name = "lblReset"
        Me.lblReset.Size = New System.Drawing.Size(176, 195)
        Me.lblReset.TabIndex = 3
        Me.lblReset.Text = "Reset password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Old password:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    New password:"
        '
        'frmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(637, 573)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Settings)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.HalfPillButton2)
        Me.Controls.Add(Me.HalfPillButton1)
        Me.Controls.Add(Me.lblEnter)
        Me.Controls.Add(Me.sbSubmit)
        Me.Controls.Add(Me.tbTop)
        Me.Controls.Add(Me.lblOmega)
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLock"
        Me.ShowInTaskbar = False
        Me.Text = "System Locked"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbTop As LCARS.Controls.TextButton
    Friend WithEvents lblOmega As System.Windows.Forms.Label
    Friend WithEvents sbSubmit As LCARS.Controls.StandardButton
    Friend WithEvents lblEnter As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents HalfPillButton1 As LCARS.Controls.HalfPillButton
    Friend WithEvents HalfPillButton2 As LCARS.Controls.HalfPillButton
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents Settings As LCARS.Controls.FlatButton
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents sbReset As LCARS.Controls.StandardButton
    Friend WithEvents txtOld As System.Windows.Forms.TextBox
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblReset As System.Windows.Forms.Label

End Class
