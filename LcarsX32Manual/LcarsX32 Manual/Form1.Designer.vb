<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hlpfrm
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
        Dim LcarScolor1 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.FlatButton2 = New LCARS.Controls.FlatButton
        Me.btnwidth = New LCARS.Controls.FlatButton
        Me.exitbtn = New LCARS.Controls.FlatButton
        Me.Elbow1 = New LCARS.Controls.Elbow
        Me.FlatButton5 = New LCARS.Controls.FlatButton
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.FlatButton9 = New LCARS.Controls.FlatButton
        Me.FlatButton12 = New LCARS.Controls.FlatButton
        Me.FlatButton7 = New LCARS.Controls.FlatButton
        Me.FlatButton8 = New LCARS.Controls.FlatButton
        Me.FlatButton3 = New LCARS.Controls.FlatButton
        Me.cpxManualName = New LCARS.Controls.ComplexButton
        Me.FlatButton4 = New LCARS.Controls.FlatButton
        Me.Elbow4 = New LCARS.Controls.Elbow
        Me.webChapterContainer = New System.Windows.Forms.WebBrowser
        Me.btgChapters = New LCARS.Controls.ButtonGrid
        Me.SuspendLayout()
        '
        'FlatButton1
        '
        Me.FlatButton1.AutoEllipsis = False
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = "PAGE UP"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = True
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(12, 83)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(85, 28)
        Me.FlatButton1.TabIndex = 103
        Me.FlatButton1.Tag = "4"
        Me.FlatButton1.Text = "PAGE UP"
        '
        'FlatButton2
        '
        Me.FlatButton2.AutoEllipsis = False
        Me.FlatButton2.Beeping = False
        Me.FlatButton2.ButtonText = "PAGE DOWN"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton2.ButtonTextHeight = 14
        Me.FlatButton2.Clickable = True
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton2.Data = Nothing
        Me.FlatButton2.Data2 = Nothing
        Me.FlatButton2.FlashInterval = 500
        Me.FlatButton2.holdDraw = False
        Me.FlatButton2.Lit = True
        Me.FlatButton2.Location = New System.Drawing.Point(12, 114)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton2.Size = New System.Drawing.Size(85, 28)
        Me.FlatButton2.TabIndex = 104
        Me.FlatButton2.Tag = "5"
        Me.FlatButton2.Text = "PAGE DOWN"
        '
        'btnwidth
        '
        Me.btnwidth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnwidth.AutoEllipsis = False
        Me.btnwidth.Beeping = False
        Me.btnwidth.ButtonText = ""
        Me.btnwidth.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnwidth.ButtonTextHeight = 14
        Me.btnwidth.Clickable = True
        Me.btnwidth.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.btnwidth.CustomAlertColor = System.Drawing.Color.Empty
        Me.btnwidth.Data = Nothing
        Me.btnwidth.Data2 = Nothing
        Me.btnwidth.FlashInterval = 500
        Me.btnwidth.holdDraw = False
        Me.btnwidth.Lit = True
        Me.btnwidth.Location = New System.Drawing.Point(12, 177)
        Me.btnwidth.Name = "btnwidth"
        Me.btnwidth.RedAlert = LCARS.LCARSalert.Normal
        Me.btnwidth.Size = New System.Drawing.Size(85, 179)
        Me.btnwidth.TabIndex = 106
        Me.btnwidth.Tag = "7"
        '
        'exitbtn
        '
        Me.exitbtn.AutoEllipsis = False
        Me.exitbtn.Beeping = False
        Me.exitbtn.ButtonText = "CLOSE"
        Me.exitbtn.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.exitbtn.ButtonTextHeight = 14
        Me.exitbtn.Clickable = True
        Me.exitbtn.Color = LCARS.LCARScolorStyles.Orange
        Me.exitbtn.CustomAlertColor = System.Drawing.Color.Empty
        Me.exitbtn.Data = Nothing
        Me.exitbtn.Data2 = Nothing
        Me.exitbtn.FlashInterval = 500
        Me.exitbtn.holdDraw = False
        Me.exitbtn.Lit = True
        Me.exitbtn.Location = New System.Drawing.Point(12, 145)
        Me.exitbtn.Name = "exitbtn"
        Me.exitbtn.RedAlert = LCARS.LCARSalert.Normal
        Me.exitbtn.Size = New System.Drawing.Size(85, 29)
        Me.exitbtn.TabIndex = 109
        Me.exitbtn.Tag = "12"
        Me.exitbtn.Text = "CLOSE"
        '
        'Elbow1
        '
        Me.Elbow1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow1.AutoEllipsis = False
        Me.Elbow1.Beeping = False
        Me.Elbow1.ButtonHeight = 25
        Me.Elbow1.ButtonText = ""
        Me.Elbow1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Elbow1.ButtonTextHeight = 14
        Me.Elbow1.ButtonWidth = 85
        Me.Elbow1.Clickable = True
        Me.Elbow1.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Elbow1.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow1.Data = Nothing
        Me.Elbow1.Data2 = Nothing
        Me.Elbow1.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow1.FlashInterval = 500
        Me.Elbow1.holdDraw = False
        Me.Elbow1.Lit = True
        Me.Elbow1.Location = New System.Drawing.Point(12, 541)
        Me.Elbow1.Name = "Elbow1"
        Me.Elbow1.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow1.Size = New System.Drawing.Size(339, 53)
        Me.Elbow1.TabIndex = 132
        '
        'FlatButton5
        '
        Me.FlatButton5.AutoEllipsis = False
        Me.FlatButton5.Beeping = False
        Me.FlatButton5.ButtonText = ""
        Me.FlatButton5.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton5.ButtonTextHeight = 14
        Me.FlatButton5.Clickable = False
        Me.FlatButton5.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton5.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton5.Data = Nothing
        Me.FlatButton5.Data2 = Nothing
        Me.FlatButton5.FlashInterval = 500
        Me.FlatButton5.holdDraw = False
        Me.FlatButton5.Lit = True
        Me.FlatButton5.Location = New System.Drawing.Point(172, 12)
        Me.FlatButton5.Name = "FlatButton5"
        Me.FlatButton5.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton5.Size = New System.Drawing.Size(30, 30)
        Me.FlatButton5.TabIndex = 136
        Me.FlatButton5.Tag = "7"
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.Black
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.ForeColor = System.Drawing.Color.Cyan
        Me.txtTitle.Location = New System.Drawing.Point(114, 46)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(524, 40)
        Me.txtTitle.TabIndex = 165
        Me.txtTitle.Text = "LCARSX32 INSTRUCTION MANUAL"
        '
        'FlatButton9
        '
        Me.FlatButton9.AutoEllipsis = False
        Me.FlatButton9.Beeping = False
        Me.FlatButton9.ButtonText = ""
        Me.FlatButton9.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton9.ButtonTextHeight = 14
        Me.FlatButton9.Clickable = False
        Me.FlatButton9.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton9.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton9.Data = Nothing
        Me.FlatButton9.Data2 = Nothing
        Me.FlatButton9.FlashInterval = 500
        Me.FlatButton9.holdDraw = False
        Me.FlatButton9.Lit = True
        Me.FlatButton9.Location = New System.Drawing.Point(205, 12)
        Me.FlatButton9.Name = "FlatButton9"
        Me.FlatButton9.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton9.Size = New System.Drawing.Size(73, 5)
        Me.FlatButton9.TabIndex = 176
        Me.FlatButton9.Tag = "7"
        '
        'FlatButton12
        '
        Me.FlatButton12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton12.AutoEllipsis = False
        Me.FlatButton12.Beeping = False
        Me.FlatButton12.ButtonText = ""
        Me.FlatButton12.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton12.ButtonTextHeight = 14
        Me.FlatButton12.Clickable = True
        Me.FlatButton12.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.FlatButton12.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton12.Data = Nothing
        Me.FlatButton12.Data2 = Nothing
        Me.FlatButton12.FlashInterval = 500
        Me.FlatButton12.holdDraw = False
        Me.FlatButton12.Lit = True
        Me.FlatButton12.Location = New System.Drawing.Point(357, 570)
        Me.FlatButton12.Name = "FlatButton12"
        Me.FlatButton12.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton12.Size = New System.Drawing.Size(284, 25)
        Me.FlatButton12.TabIndex = 188
        Me.FlatButton12.Tag = "7"
        '
        'FlatButton7
        '
        Me.FlatButton7.AutoEllipsis = False
        Me.FlatButton7.Beeping = False
        Me.FlatButton7.ButtonText = ""
        Me.FlatButton7.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton7.ButtonTextHeight = 14
        Me.FlatButton7.Clickable = False
        Me.FlatButton7.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton7.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton7.Data = Nothing
        Me.FlatButton7.Data2 = Nothing
        Me.FlatButton7.FlashInterval = 500
        Me.FlatButton7.holdDraw = False
        Me.FlatButton7.Lit = True
        Me.FlatButton7.Location = New System.Drawing.Point(205, 37)
        Me.FlatButton7.Name = "FlatButton7"
        Me.FlatButton7.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton7.Size = New System.Drawing.Size(73, 5)
        Me.FlatButton7.TabIndex = 190
        Me.FlatButton7.Tag = "7"
        '
        'FlatButton8
        '
        Me.FlatButton8.AutoEllipsis = False
        Me.FlatButton8.Beeping = False
        Me.FlatButton8.ButtonText = ""
        Me.FlatButton8.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton8.ButtonTextHeight = 14
        Me.FlatButton8.Clickable = True
        Me.FlatButton8.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton8.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton8.Data = Nothing
        Me.FlatButton8.Data2 = Nothing
        Me.FlatButton8.FlashInterval = 500
        Me.FlatButton8.holdDraw = False
        Me.FlatButton8.Lit = True
        Me.FlatButton8.Location = New System.Drawing.Point(205, 20)
        Me.FlatButton8.Name = "FlatButton8"
        Me.FlatButton8.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton8.Size = New System.Drawing.Size(73, 14)
        Me.FlatButton8.TabIndex = 191
        Me.FlatButton8.Tag = "7"
        '
        'FlatButton3
        '
        Me.FlatButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton3.AutoEllipsis = False
        Me.FlatButton3.Beeping = False
        Me.FlatButton3.ButtonText = ""
        Me.FlatButton3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton3.ButtonTextHeight = 14
        Me.FlatButton3.Clickable = True
        Me.FlatButton3.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton3.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton3.Data = Nothing
        Me.FlatButton3.Data2 = Nothing
        Me.FlatButton3.FlashInterval = 500
        Me.FlatButton3.holdDraw = False
        Me.FlatButton3.Lit = True
        Me.FlatButton3.Location = New System.Drawing.Point(12, 359)
        Me.FlatButton3.Name = "FlatButton3"
        Me.FlatButton3.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton3.Size = New System.Drawing.Size(85, 176)
        Me.FlatButton3.TabIndex = 194
        Me.FlatButton3.Tag = "7"
        '
        'cpxManualName
        '
        Me.cpxManualName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cpxManualName.AutoEllipsis = False
        Me.cpxManualName.Beeping = True
        Me.cpxManualName.ButtonText = ""
        Me.cpxManualName.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cpxManualName.ButtonTextHeight = 14
        Me.cpxManualName.Clickable = True
        Me.cpxManualName.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.cpxManualName.CustomAlertColor = System.Drawing.Color.Empty
        Me.cpxManualName.Data = Nothing
        Me.cpxManualName.Data2 = Nothing
        Me.cpxManualName.FlashInterval = 500
        Me.cpxManualName.holdDraw = False
        Me.cpxManualName.Lit = True
        Me.cpxManualName.Location = New System.Drawing.Point(418, 12)
        Me.cpxManualName.Name = "cpxManualName"
        Me.cpxManualName.RedAlert = LCARS.LCARSalert.Normal
        Me.cpxManualName.SideBlockColor = LCARS.LCARScolorStyles.StaticBlue
        Me.cpxManualName.SideText = " LCARS X32 HELP "
        Me.cpxManualName.SideTextColor = LCARS.LCARScolorStyles.NavigationFunction
        Me.cpxManualName.SideTextWidth = -1
        Me.cpxManualName.Size = New System.Drawing.Size(220, 30)
        Me.cpxManualName.TabIndex = 195
        '
        'FlatButton4
        '
        Me.FlatButton4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton4.AutoEllipsis = False
        Me.FlatButton4.Beeping = False
        Me.FlatButton4.ButtonText = ""
        Me.FlatButton4.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton4.ButtonTextHeight = 14
        Me.FlatButton4.Clickable = False
        Me.FlatButton4.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton4.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton4.Data = Nothing
        Me.FlatButton4.Data2 = Nothing
        Me.FlatButton4.FlashInterval = 500
        Me.FlatButton4.holdDraw = False
        Me.FlatButton4.Lit = True
        Me.FlatButton4.Location = New System.Drawing.Point(280, 12)
        Me.FlatButton4.Name = "FlatButton4"
        Me.FlatButton4.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton4.Size = New System.Drawing.Size(132, 30)
        Me.FlatButton4.TabIndex = 196
        Me.FlatButton4.Tag = "7"
        '
        'Elbow4
        '
        Me.Elbow4.AutoEllipsis = False
        Me.Elbow4.Beeping = False
        Me.Elbow4.ButtonHeight = 30
        Me.Elbow4.ButtonText = ""
        Me.Elbow4.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Elbow4.ButtonTextHeight = 14
        Me.Elbow4.ButtonWidth = 85
        Me.Elbow4.Clickable = True
        Me.Elbow4.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Elbow4.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow4.Data = Nothing
        Me.Elbow4.Data2 = Nothing
        Me.Elbow4.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow4.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow4.FlashInterval = 500
        Me.Elbow4.holdDraw = False
        Me.Elbow4.Lit = True
        Me.Elbow4.Location = New System.Drawing.Point(12, 12)
        Me.Elbow4.Name = "Elbow4"
        Me.Elbow4.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow4.Size = New System.Drawing.Size(157, 68)
        Me.Elbow4.TabIndex = 135
        '
        'webChapterContainer
        '
        Me.webChapterContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webChapterContainer.Location = New System.Drawing.Point(104, 86)
        Me.webChapterContainer.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webChapterContainer.Name = "webChapterContainer"
        Me.webChapterContainer.Size = New System.Drawing.Size(534, 366)
        Me.webChapterContainer.TabIndex = 198
        '
        'btgChapters
        '
        Me.btgChapters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btgChapters.Beeping = False
        Me.btgChapters.ColorsAvailable = LcarScolor1
        Me.btgChapters.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Horizontal
        Me.btgChapters.ControlPadding = 5
        Me.btgChapters.ControlSize = New System.Drawing.Size(150, 30)
        Me.btgChapters.CurrentPage = 1
        Me.btgChapters.Location = New System.Drawing.Point(103, 458)
        Me.btgChapters.MinimumSize = New System.Drawing.Size(50, 50)
        Me.btgChapters.Name = "btgChapters"
        Me.btgChapters.Size = New System.Drawing.Size(535, 106)
        Me.btgChapters.TabIndex = 199
        Me.btgChapters.Text = "ButtonGrid1"
        '
        'Hlpfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(650, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.btgChapters)
        Me.Controls.Add(Me.webChapterContainer)
        Me.Controls.Add(Me.FlatButton4)
        Me.Controls.Add(Me.cpxManualName)
        Me.Controls.Add(Me.FlatButton3)
        Me.Controls.Add(Me.FlatButton8)
        Me.Controls.Add(Me.FlatButton7)
        Me.Controls.Add(Me.FlatButton12)
        Me.Controls.Add(Me.FlatButton9)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.FlatButton5)
        Me.Controls.Add(Me.Elbow4)
        Me.Controls.Add(Me.Elbow1)
        Me.Controls.Add(Me.exitbtn)
        Me.Controls.Add(Me.btnwidth)
        Me.Controls.Add(Me.FlatButton2)
        Me.Controls.Add(Me.FlatButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(650, 500)
        Me.Name = "Hlpfrm"
        Me.Text = "LcarsX32 Help"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton2 As LCARS.Controls.FlatButton
    Friend WithEvents btnwidth As LCARS.Controls.FlatButton
    Friend WithEvents exitbtn As LCARS.Controls.FlatButton
    Friend WithEvents Elbow1 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton5 As LCARS.Controls.FlatButton
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents FlatButton9 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton12 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton7 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton8 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton3 As LCARS.Controls.FlatButton
    Friend WithEvents cpxManualName As LCARS.Controls.ComplexButton
    Friend WithEvents FlatButton4 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow4 As LCARS.Controls.Elbow
    Friend WithEvents webChapterContainer As System.Windows.Forms.WebBrowser
    Friend WithEvents btgChapters As LCARS.Controls.ButtonGrid

End Class
