<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hlpfrm
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
        Me.FlatButton1.ButtonText = "PAGE UP"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton1.Location = New System.Drawing.Point(12, 83)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Size = New System.Drawing.Size(85, 28)
        Me.FlatButton1.TabIndex = 103
        Me.FlatButton1.Tag = "4"
        Me.FlatButton1.Text = "PAGE UP"
        '
        'FlatButton2
        '
        Me.FlatButton2.ButtonText = "PAGE DOWN"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.FlatButton2.Location = New System.Drawing.Point(12, 114)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.Size = New System.Drawing.Size(85, 28)
        Me.FlatButton2.TabIndex = 104
        Me.FlatButton2.Tag = "5"
        Me.FlatButton2.Text = "PAGE DOWN"
        '
        'btnwidth
        '
        Me.btnwidth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnwidth.ButtonText = ""
        Me.btnwidth.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnwidth.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.btnwidth.Location = New System.Drawing.Point(12, 177)
        Me.btnwidth.Name = "btnwidth"
        Me.btnwidth.Size = New System.Drawing.Size(85, 179)
        Me.btnwidth.TabIndex = 106
        Me.btnwidth.Tag = "7"
        '
        'exitbtn
        '
        Me.exitbtn.ButtonText = "CLOSE"
        Me.exitbtn.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.exitbtn.Color = LCARS.LCARScolorStyles.Orange
        Me.exitbtn.Location = New System.Drawing.Point(12, 145)
        Me.exitbtn.Name = "exitbtn"
        Me.exitbtn.Size = New System.Drawing.Size(85, 29)
        Me.exitbtn.TabIndex = 109
        Me.exitbtn.Tag = "12"
        Me.exitbtn.Text = "CLOSE"
        '
        'Elbow1
        '
        Me.Elbow1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow1.ButtonText = ""
        Me.Elbow1.ButtonWidth = 85
        Me.Elbow1.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Elbow1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow1.Location = New System.Drawing.Point(12, 541)
        Me.Elbow1.Name = "Elbow1"
        Me.Elbow1.Size = New System.Drawing.Size(339, 53)
        Me.Elbow1.TabIndex = 132
        '
        'FlatButton5
        '
        Me.FlatButton5.ButtonText = ""
        Me.FlatButton5.Clickable = False
        Me.FlatButton5.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton5.Location = New System.Drawing.Point(172, 12)
        Me.FlatButton5.Name = "FlatButton5"
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
        Me.FlatButton9.ButtonText = ""
        Me.FlatButton9.Clickable = False
        Me.FlatButton9.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton9.Location = New System.Drawing.Point(205, 12)
        Me.FlatButton9.Name = "FlatButton9"
        Me.FlatButton9.Size = New System.Drawing.Size(73, 5)
        Me.FlatButton9.TabIndex = 176
        Me.FlatButton9.Tag = "7"
        '
        'FlatButton12
        '
        Me.FlatButton12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton12.ButtonText = ""
        Me.FlatButton12.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.FlatButton12.Location = New System.Drawing.Point(357, 570)
        Me.FlatButton12.Name = "FlatButton12"
        Me.FlatButton12.Size = New System.Drawing.Size(284, 25)
        Me.FlatButton12.TabIndex = 188
        Me.FlatButton12.Tag = "7"
        '
        'FlatButton7
        '
        Me.FlatButton7.ButtonText = ""
        Me.FlatButton7.Clickable = False
        Me.FlatButton7.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton7.Location = New System.Drawing.Point(205, 37)
        Me.FlatButton7.Name = "FlatButton7"
        Me.FlatButton7.Size = New System.Drawing.Size(73, 5)
        Me.FlatButton7.TabIndex = 190
        Me.FlatButton7.Tag = "7"
        '
        'FlatButton8
        '
        Me.FlatButton8.ButtonText = ""
        Me.FlatButton8.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton8.Location = New System.Drawing.Point(205, 20)
        Me.FlatButton8.Name = "FlatButton8"
        Me.FlatButton8.Size = New System.Drawing.Size(73, 14)
        Me.FlatButton8.TabIndex = 191
        Me.FlatButton8.Tag = "7"
        '
        'FlatButton3
        '
        Me.FlatButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton3.ButtonText = ""
        Me.FlatButton3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton3.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton3.Location = New System.Drawing.Point(12, 359)
        Me.FlatButton3.Name = "FlatButton3"
        Me.FlatButton3.Size = New System.Drawing.Size(85, 176)
        Me.FlatButton3.TabIndex = 194
        Me.FlatButton3.Tag = "7"
        '
        'cpxManualName
        '
        Me.cpxManualName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cpxManualName.Beeping = True
        Me.cpxManualName.ButtonText = ""
        Me.cpxManualName.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.cpxManualName.Location = New System.Drawing.Point(418, 12)
        Me.cpxManualName.Name = "cpxManualName"
        Me.cpxManualName.SideBlockColor = LCARS.LCARScolorStyles.StaticBlue
        Me.cpxManualName.SideText = " LCARS X32 HELP "
        Me.cpxManualName.SideTextColor = LCARS.LCARScolorStyles.NavigationFunction
        Me.cpxManualName.Size = New System.Drawing.Size(220, 30)
        Me.cpxManualName.TabIndex = 195
        '
        'FlatButton4
        '
        Me.FlatButton4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton4.ButtonText = ""
        Me.FlatButton4.Clickable = False
        Me.FlatButton4.Color = LCARS.LCARScolorStyles.StaticTan
        Me.FlatButton4.Location = New System.Drawing.Point(280, 12)
        Me.FlatButton4.Name = "FlatButton4"
        Me.FlatButton4.Size = New System.Drawing.Size(132, 30)
        Me.FlatButton4.TabIndex = 196
        Me.FlatButton4.Tag = "7"
        '
        'Elbow4
        '
        Me.Elbow4.ButtonHeight = 30
        Me.Elbow4.ButtonText = ""
        Me.Elbow4.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Elbow4.ButtonWidth = 85
        Me.Elbow4.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Elbow4.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow4.Location = New System.Drawing.Point(12, 12)
        Me.Elbow4.Name = "Elbow4"
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
        Me.btgChapters.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Horizontal
        Me.btgChapters.ControlSize = New System.Drawing.Size(150, 30)
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
