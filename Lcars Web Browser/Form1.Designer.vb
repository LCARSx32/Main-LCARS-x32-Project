<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.FlatButton2 = New LCARS.Controls.FlatButton
        Me.FlatButton3 = New LCARS.Controls.FlatButton
        Me.FlatButton4 = New LCARS.Controls.FlatButton
        Me.FlatButton6 = New LCARS.Controls.FlatButton
        Me.FlatButton7 = New LCARS.Controls.FlatButton
        Me.FlatButton8 = New LCARS.Controls.FlatButton
        Me.Elbow1 = New LCARS.Controls.Elbow
        Me.FlatButton4a = New LCARS.Controls.FlatButton
        Me.FlatButton5 = New LCARS.Controls.FlatButton
        Me.ComplexButton1 = New LCARS.Controls.ComplexButton
        Me.FlatButton9 = New LCARS.Controls.FlatButton
        Me.FlatButton10 = New LCARS.Controls.FlatButton
        Me.FlatButton11 = New LCARS.Controls.FlatButton
        Me.FlatButton13 = New LCARS.Controls.FlatButton
        Me.Arrowbutton1 = New LCARS.Controls.FlatButton
        Me.Arrowbutton2 = New LCARS.Controls.FlatButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.FlatButton14 = New LCARS.Controls.FlatButton
        Me.FlatButton15 = New LCARS.Controls.FlatButton
        Me.FlatButton16 = New LCARS.Controls.FlatButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.FlatButton12 = New LCARS.Controls.FlatButton
        Me.FlatButton17 = New LCARS.Controls.FlatButton
        Me.FlatButton18 = New LCARS.Controls.FlatButton
        Me.FlatButton19 = New LCARS.Controls.FlatButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FlatButton33 = New LCARS.Controls.FlatButton
        Me.FlatButton27 = New LCARS.Controls.FlatButton
        Me.FlatButton31 = New LCARS.Controls.FlatButton
        Me.FlatButton32 = New LCARS.Controls.FlatButton
        Me.FlatButton30 = New LCARS.Controls.FlatButton
        Me.FlatButton29 = New LCARS.Controls.FlatButton
        Me.FlatButton28 = New LCARS.Controls.FlatButton
        Me.Elbow5 = New LCARS.Controls.Elbow
        Me.Elbow4 = New LCARS.Controls.Elbow
        Me.FlatButton23 = New LCARS.Controls.FlatButton
        Me.FlatButton22 = New LCARS.Controls.FlatButton
        Me.Elbow3 = New LCARS.Controls.Elbow
        Me.FlatButton21 = New LCARS.Controls.FlatButton
        Me.FlatButton26 = New LCARS.Controls.FlatButton
        Me.FlatButton25 = New LCARS.Controls.FlatButton
        Me.FlatButton24 = New LCARS.Controls.FlatButton
        Me.Elbow2 = New LCARS.Controls.Elbow
        Me.FlatButton20 = New LCARS.Controls.FlatButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox1.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(461, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(163, 33)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Tag = "17"
        Me.TextBox1.Text = " "
        Me.TextBox1.Visible = False
        Me.TextBox1.WordWrap = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(163, 87)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(770, 680)
        Me.TabControl1.TabIndex = 21
        Me.TabControl1.Tag = "19"
        Me.TabControl1.Visible = False
        '
        'FlatButton1
        '
        Me.FlatButton1.Beeping = True
        Me.FlatButton1.ButtonText = "REFRESH PAGE"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton1.Location = New System.Drawing.Point(24, 293)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton1.TabIndex = 23
        Me.FlatButton1.Tag = "7"
        Me.FlatButton1.Text = "REFRESH PAGE"
        Me.FlatButton1.Visible = False
        '
        'FlatButton2
        '
        Me.FlatButton2.Beeping = True
        Me.FlatButton2.ButtonText = "STOP"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton2.Location = New System.Drawing.Point(24, 258)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton2.TabIndex = 25
        Me.FlatButton2.Tag = "8"
        Me.FlatButton2.Text = "STOP"
        Me.FlatButton2.Visible = False
        '
        'FlatButton3
        '
        Me.FlatButton3.Beeping = True
        Me.FlatButton3.ButtonText = "CLOSE"
        Me.FlatButton3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton3.Color = LCARS.LCARScolorStyles.Orange
        Me.FlatButton3.Location = New System.Drawing.Point(24, 468)
        Me.FlatButton3.Name = "FlatButton3"
        Me.FlatButton3.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton3.TabIndex = 26
        Me.FlatButton3.Tag = "3"
        Me.FlatButton3.Text = "CLOSE"
        Me.FlatButton3.Visible = False
        '
        'FlatButton4
        '
        Me.FlatButton4.Beeping = True
        Me.FlatButton4.ButtonText = "GOTO WEBSITE"
        Me.FlatButton4.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton4.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton4.Location = New System.Drawing.Point(24, 153)
        Me.FlatButton4.Name = "FlatButton4"
        Me.FlatButton4.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton4.TabIndex = 27
        Me.FlatButton4.Tag = "11"
        Me.FlatButton4.Text = "GOTO WEBSITE"
        Me.FlatButton4.Visible = False
        '
        'FlatButton6
        '
        Me.FlatButton6.Beeping = True
        Me.FlatButton6.ButtonText = "HOME PAGE"
        Me.FlatButton6.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton6.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton6.Location = New System.Drawing.Point(24, 118)
        Me.FlatButton6.Name = "FlatButton6"
        Me.FlatButton6.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton6.TabIndex = 29
        Me.FlatButton6.Tag = "12"
        Me.FlatButton6.Text = "HOME PAGE"
        Me.FlatButton6.Visible = False
        '
        'FlatButton7
        '
        Me.FlatButton7.Beeping = True
        Me.FlatButton7.ButtonText = "NEW TAB"
        Me.FlatButton7.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton7.Location = New System.Drawing.Point(24, 328)
        Me.FlatButton7.Name = "FlatButton7"
        Me.FlatButton7.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton7.TabIndex = 30
        Me.FlatButton7.Tag = "6"
        Me.FlatButton7.Text = "NEW TAB"
        Me.FlatButton7.Visible = False
        '
        'FlatButton8
        '
        Me.FlatButton8.Beeping = True
        Me.FlatButton8.ButtonText = "CLOSE TAB"
        Me.FlatButton8.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton8.Location = New System.Drawing.Point(24, 363)
        Me.FlatButton8.Name = "FlatButton8"
        Me.FlatButton8.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton8.TabIndex = 31
        Me.FlatButton8.Tag = "5"
        Me.FlatButton8.Text = "CLOSE TAB"
        Me.FlatButton8.Visible = False
        '
        'Elbow1
        '
        Me.Elbow1.ButtonHeight = 44
        Me.Elbow1.ButtonText = ""
        Me.Elbow1.ButtonTextHeight = 19
        Me.Elbow1.ButtonWidth = 100
        Me.Elbow1.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow1.Location = New System.Drawing.Point(24, 18)
        Me.Elbow1.Name = "Elbow1"
        Me.Elbow1.Size = New System.Drawing.Size(133, 94)
        Me.Elbow1.TabIndex = 33
        Me.Elbow1.Tag = "14"
        Me.Elbow1.Visible = False
        '
        'FlatButton4a
        '
        Me.FlatButton4a.Beeping = True
        Me.FlatButton4a.ButtonText = ""
        Me.FlatButton4a.Clickable = False
        Me.FlatButton4a.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton4a.Location = New System.Drawing.Point(163, 18)
        Me.FlatButton4a.Name = "FlatButton4a"
        Me.FlatButton4a.Size = New System.Drawing.Size(191, 44)
        Me.FlatButton4a.TabIndex = 34
        Me.FlatButton4a.Tag = "15"
        Me.FlatButton4a.Visible = False
        '
        'FlatButton5
        '
        Me.FlatButton5.Beeping = True
        Me.FlatButton5.ButtonText = ""
        Me.FlatButton5.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton5.Location = New System.Drawing.Point(360, 29)
        Me.FlatButton5.Name = "FlatButton5"
        Me.FlatButton5.Size = New System.Drawing.Size(95, 23)
        Me.FlatButton5.TabIndex = 35
        Me.FlatButton5.Tag = "16"
        Me.FlatButton5.Visible = False
        '
        'ComplexButton1
        '
        Me.ComplexButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComplexButton1.Beeping = True
        Me.ComplexButton1.ButtonText = ""
        Me.ComplexButton1.ButtonTextHeight = 4
        Me.ComplexButton1.Color = LCARS.LCARScolorStyles.StaticTan
        Me.ComplexButton1.Location = New System.Drawing.Point(630, 19)
        Me.ComplexButton1.Name = "ComplexButton1"
        Me.ComplexButton1.SideBlockColor = LCARS.LCARScolorStyles.StaticTan
        Me.ComplexButton1.SideText = " WEB BROWSER"
        Me.ComplexButton1.SideTextColor = LCARS.LCARScolorStyles.NavigationFunction
        Me.ComplexButton1.Size = New System.Drawing.Size(303, 44)
        Me.ComplexButton1.TabIndex = 54
        Me.ComplexButton1.Tag = "18"
        Me.ComplexButton1.Visible = False
        '
        'FlatButton9
        '
        Me.FlatButton9.Beeping = True
        Me.FlatButton9.ButtonText = ""
        Me.FlatButton9.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton9.Location = New System.Drawing.Point(360, 19)
        Me.FlatButton9.Name = "FlatButton9"
        Me.FlatButton9.Size = New System.Drawing.Size(95, 6)
        Me.FlatButton9.TabIndex = 55
        Me.FlatButton9.Tag = "16"
        Me.FlatButton9.Visible = False
        '
        'FlatButton10
        '
        Me.FlatButton10.Beeping = True
        Me.FlatButton10.ButtonText = ""
        Me.FlatButton10.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton10.Location = New System.Drawing.Point(360, 57)
        Me.FlatButton10.Name = "FlatButton10"
        Me.FlatButton10.Size = New System.Drawing.Size(95, 6)
        Me.FlatButton10.TabIndex = 56
        Me.FlatButton10.Tag = "16"
        Me.FlatButton10.Visible = False
        '
        'FlatButton11
        '
        Me.FlatButton11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton11.ButtonText = "LCARS"
        Me.FlatButton11.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.FlatButton11.Clickable = False
        Me.FlatButton11.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton11.Location = New System.Drawing.Point(24, 538)
        Me.FlatButton11.Name = "FlatButton11"
        Me.FlatButton11.Size = New System.Drawing.Size(99, 229)
        Me.FlatButton11.TabIndex = 57
        Me.FlatButton11.Tag = "1"
        Me.FlatButton11.Text = "LCARS"
        Me.FlatButton11.Visible = False
        '
        'FlatButton13
        '
        Me.FlatButton13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton13.Beeping = True
        Me.FlatButton13.ButtonText = ""
        Me.FlatButton13.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton13.Location = New System.Drawing.Point(461, 58)
        Me.FlatButton13.Name = "FlatButton13"
        Me.FlatButton13.Size = New System.Drawing.Size(163, 6)
        Me.FlatButton13.TabIndex = 59
        Me.FlatButton13.Tag = "17"
        Me.FlatButton13.Visible = False
        '
        'Arrowbutton1
        '
        Me.Arrowbutton1.Beeping = True
        Me.Arrowbutton1.ButtonText = "<"
        Me.Arrowbutton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Arrowbutton1.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Arrowbutton1.Location = New System.Drawing.Point(24, 188)
        Me.Arrowbutton1.Name = "Arrowbutton1"
        Me.Arrowbutton1.Size = New System.Drawing.Size(100, 29)
        Me.Arrowbutton1.TabIndex = 62
        Me.Arrowbutton1.Tag = "10"
        Me.Arrowbutton1.Text = "<"
        Me.Arrowbutton1.Visible = False
        '
        'Arrowbutton2
        '
        Me.Arrowbutton2.Beeping = True
        Me.Arrowbutton2.ButtonText = ">"
        Me.Arrowbutton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Arrowbutton2.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.Arrowbutton2.Location = New System.Drawing.Point(24, 223)
        Me.Arrowbutton2.Name = "Arrowbutton2"
        Me.Arrowbutton2.Size = New System.Drawing.Size(100, 29)
        Me.Arrowbutton2.TabIndex = 63
        Me.Arrowbutton2.Tag = "9"
        Me.Arrowbutton2.Text = ">"
        Me.Arrowbutton2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(163, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(24, 503)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 29)
        Me.ProgressBar1.TabIndex = 68
        Me.ProgressBar1.Tag = "2"
        Me.ProgressBar1.Visible = False
        '
        'FlatButton14
        '
        Me.FlatButton14.Beeping = True
        Me.FlatButton14.ButtonText = "ZOOM CONTROL"
        Me.FlatButton14.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton14.Location = New System.Drawing.Point(24, 433)
        Me.FlatButton14.Name = "FlatButton14"
        Me.FlatButton14.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton14.TabIndex = 69
        Me.FlatButton14.Tag = "4"
        Me.FlatButton14.Text = "ZOOM CONTROL"
        Me.FlatButton14.Visible = False
        '
        'FlatButton15
        '
        Me.FlatButton15.Beeping = True
        Me.FlatButton15.ButtonText = "ZOOM CONTROL"
        Me.FlatButton15.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton15.Location = New System.Drawing.Point(24, 433)
        Me.FlatButton15.Name = "FlatButton15"
        Me.FlatButton15.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton15.TabIndex = 70
        Me.FlatButton15.Tag = ""
        Me.FlatButton15.Text = "ZOOM CONTROL"
        Me.FlatButton15.Visible = False
        '
        'FlatButton16
        '
        Me.FlatButton16.Beeping = True
        Me.FlatButton16.ButtonText = "ZOOM CONTROL"
        Me.FlatButton16.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton16.Location = New System.Drawing.Point(24, 433)
        Me.FlatButton16.Name = "FlatButton16"
        Me.FlatButton16.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton16.TabIndex = 71
        Me.FlatButton16.Tag = ""
        Me.FlatButton16.Text = "ZOOM CONTROL"
        Me.FlatButton16.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(425, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = ""
        Me.PictureBox1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Orange
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Location = New System.Drawing.Point(64, 62)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(643, 434)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 74
        '
        'FlatButton12
        '
        Me.FlatButton12.Beeping = True
        Me.FlatButton12.ButtonText = "BOOKMARKS"
        Me.FlatButton12.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton12.Location = New System.Drawing.Point(24, 398)
        Me.FlatButton12.Name = "FlatButton12"
        Me.FlatButton12.Size = New System.Drawing.Size(100, 29)
        Me.FlatButton12.TabIndex = 75
        Me.FlatButton12.Tag = "4"
        Me.FlatButton12.Text = "BOOKMARKS"
        Me.FlatButton12.Visible = False
        '
        'FlatButton17
        '
        Me.FlatButton17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton17.Beeping = True
        Me.FlatButton17.ButtonText = "IMPORT IE FAVORITES"
        Me.FlatButton17.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton17.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton17.Location = New System.Drawing.Point(64, 588)
        Me.FlatButton17.Name = "FlatButton17"
        Me.FlatButton17.Size = New System.Drawing.Size(111, 29)
        Me.FlatButton17.TabIndex = 76
        Me.FlatButton17.Tag = "13"
        Me.FlatButton17.Text = "IMPORT IE FAVORITES"
        '
        'FlatButton18
        '
        Me.FlatButton18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton18.Beeping = True
        Me.FlatButton18.ButtonText = "DELETE ALL BOOKMARKS"
        Me.FlatButton18.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton18.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton18.Location = New System.Drawing.Point(181, 588)
        Me.FlatButton18.Name = "FlatButton18"
        Me.FlatButton18.Size = New System.Drawing.Size(120, 29)
        Me.FlatButton18.TabIndex = 77
        Me.FlatButton18.Tag = "13"
        Me.FlatButton18.Text = "DELETE ALL BOOKMARKS"
        '
        'FlatButton19
        '
        Me.FlatButton19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton19.Beeping = True
        Me.FlatButton19.ButtonText = "BOOKMARK URL"
        Me.FlatButton19.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton19.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton19.Location = New System.Drawing.Point(613, 588)
        Me.FlatButton19.Name = "FlatButton19"
        Me.FlatButton19.Size = New System.Drawing.Size(87, 29)
        Me.FlatButton19.TabIndex = 78
        Me.FlatButton19.Tag = "13"
        Me.FlatButton19.Text = "BOOKMARK URL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.FlatButton33)
        Me.GroupBox1.Controls.Add(Me.FlatButton27)
        Me.GroupBox1.Controls.Add(Me.FlatButton31)
        Me.GroupBox1.Controls.Add(Me.FlatButton32)
        Me.GroupBox1.Controls.Add(Me.FlatButton30)
        Me.GroupBox1.Controls.Add(Me.FlatButton29)
        Me.GroupBox1.Controls.Add(Me.FlatButton28)
        Me.GroupBox1.Controls.Add(Me.Elbow5)
        Me.GroupBox1.Controls.Add(Me.Elbow4)
        Me.GroupBox1.Controls.Add(Me.FlatButton23)
        Me.GroupBox1.Controls.Add(Me.FlatButton22)
        Me.GroupBox1.Controls.Add(Me.Elbow3)
        Me.GroupBox1.Controls.Add(Me.FlatButton21)
        Me.GroupBox1.Controls.Add(Me.FlatButton26)
        Me.GroupBox1.Controls.Add(Me.FlatButton25)
        Me.GroupBox1.Controls.Add(Me.FlatButton24)
        Me.GroupBox1.Controls.Add(Me.Elbow2)
        Me.GroupBox1.Controls.Add(Me.FlatButton20)
        Me.GroupBox1.Controls.Add(Me.FlatButton17)
        Me.GroupBox1.Controls.Add(Me.FlatButton19)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.FlatButton18)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(163, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(769, 649)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "20"
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'FlatButton33
        '
        Me.FlatButton33.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton33.Beeping = True
        Me.FlatButton33.ButtonText = "LOCK & UNLOCK CRITICAL FUNCTIONS"
        Me.FlatButton33.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton33.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.FlatButton33.Location = New System.Drawing.Point(307, 588)
        Me.FlatButton33.Name = "FlatButton33"
        Me.FlatButton33.Size = New System.Drawing.Size(189, 29)
        Me.FlatButton33.TabIndex = 96
        Me.FlatButton33.Tag = "13"
        Me.FlatButton33.Text = "LOCK & UNLOCK CRITICAL FUNCTIONS"
        '
        'FlatButton27
        '
        Me.FlatButton27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton27.ButtonText = ""
        Me.FlatButton27.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton27.Clickable = False
        Me.FlatButton27.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton27.Location = New System.Drawing.Point(64, 645)
        Me.FlatButton27.Name = "FlatButton27"
        Me.FlatButton27.Size = New System.Drawing.Size(644, 4)
        Me.FlatButton27.TabIndex = 95
        Me.FlatButton27.Tag = "14"
        '
        'FlatButton31
        '
        Me.FlatButton31.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton31.ButtonText = ""
        Me.FlatButton31.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton31.Clickable = False
        Me.FlatButton31.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton31.Location = New System.Drawing.Point(745, 509)
        Me.FlatButton31.Name = "FlatButton31"
        Me.FlatButton31.Size = New System.Drawing.Size(5, 90)
        Me.FlatButton31.TabIndex = 94
        Me.FlatButton31.Tag = "14"
        '
        'FlatButton32
        '
        Me.FlatButton32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton32.ButtonText = ""
        Me.FlatButton32.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton32.Clickable = False
        Me.FlatButton32.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton32.Location = New System.Drawing.Point(756, 509)
        Me.FlatButton32.Name = "FlatButton32"
        Me.FlatButton32.Size = New System.Drawing.Size(14, 90)
        Me.FlatButton32.TabIndex = 92
        Me.FlatButton32.Tag = "14"
        '
        'FlatButton30
        '
        Me.FlatButton30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton30.ButtonText = ""
        Me.FlatButton30.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton30.Clickable = False
        Me.FlatButton30.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton30.Location = New System.Drawing.Point(745, 146)
        Me.FlatButton30.Name = "FlatButton30"
        Me.FlatButton30.Size = New System.Drawing.Size(25, 364)
        Me.FlatButton30.TabIndex = 90
        Me.FlatButton30.Tag = "14"
        '
        'FlatButton29
        '
        Me.FlatButton29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton29.ButtonText = ""
        Me.FlatButton29.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton29.Clickable = False
        Me.FlatButton29.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton29.Location = New System.Drawing.Point(764, 56)
        Me.FlatButton29.Name = "FlatButton29"
        Me.FlatButton29.Size = New System.Drawing.Size(5, 90)
        Me.FlatButton29.TabIndex = 89
        Me.FlatButton29.Tag = "14"
        '
        'FlatButton28
        '
        Me.FlatButton28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton28.ButtonText = ""
        Me.FlatButton28.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton28.Clickable = False
        Me.FlatButton28.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton28.Location = New System.Drawing.Point(745, 56)
        Me.FlatButton28.Name = "FlatButton28"
        Me.FlatButton28.Size = New System.Drawing.Size(14, 90)
        Me.FlatButton28.TabIndex = 88
        Me.FlatButton28.Tag = "14"
        '
        'Elbow5
        '
        Me.Elbow5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow5.ButtonText = ""
        Me.Elbow5.ButtonTextHeight = 19
        Me.Elbow5.ButtonWidth = 25
        Me.Elbow5.Clickable = False
        Me.Elbow5.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow5.Location = New System.Drawing.Point(706, 5)
        Me.Elbow5.Name = "Elbow5"
        Me.Elbow5.Size = New System.Drawing.Size(64, 51)
        Me.Elbow5.TabIndex = 87
        Me.Elbow5.Tag = "14"
        '
        'Elbow4
        '
        Me.Elbow4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow4.ButtonHeight = 5
        Me.Elbow4.ButtonText = ""
        Me.Elbow4.ButtonTextHeight = 19
        Me.Elbow4.ButtonWidth = 25
        Me.Elbow4.Clickable = False
        Me.Elbow4.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow4.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerRight
        Me.Elbow4.Location = New System.Drawing.Point(706, 599)
        Me.Elbow4.Name = "Elbow4"
        Me.Elbow4.Size = New System.Drawing.Size(64, 51)
        Me.Elbow4.TabIndex = 86
        Me.Elbow4.Tag = "14"
        '
        'FlatButton23
        '
        Me.FlatButton23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton23.ButtonText = ""
        Me.FlatButton23.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton23.Clickable = False
        Me.FlatButton23.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton23.Location = New System.Drawing.Point(0, 509)
        Me.FlatButton23.Name = "FlatButton23"
        Me.FlatButton23.Size = New System.Drawing.Size(5, 90)
        Me.FlatButton23.TabIndex = 85
        Me.FlatButton23.Tag = "14"
        '
        'FlatButton22
        '
        Me.FlatButton22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton22.ButtonText = ""
        Me.FlatButton22.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton22.Clickable = False
        Me.FlatButton22.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton22.Location = New System.Drawing.Point(11, 509)
        Me.FlatButton22.Name = "FlatButton22"
        Me.FlatButton22.Size = New System.Drawing.Size(14, 90)
        Me.FlatButton22.TabIndex = 84
        Me.FlatButton22.Tag = "14"
        '
        'Elbow3
        '
        Me.Elbow3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Elbow3.ButtonHeight = 5
        Me.Elbow3.ButtonText = ""
        Me.Elbow3.ButtonTextHeight = 19
        Me.Elbow3.ButtonWidth = 25
        Me.Elbow3.Clickable = False
        Me.Elbow3.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow3.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow3.Location = New System.Drawing.Point(0, 599)
        Me.Elbow3.Name = "Elbow3"
        Me.Elbow3.Size = New System.Drawing.Size(64, 51)
        Me.Elbow3.TabIndex = 83
        Me.Elbow3.Tag = "14"
        '
        'FlatButton21
        '
        Me.FlatButton21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton21.ButtonText = ""
        Me.FlatButton21.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton21.Clickable = False
        Me.FlatButton21.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton21.Location = New System.Drawing.Point(0, 146)
        Me.FlatButton21.Name = "FlatButton21"
        Me.FlatButton21.Size = New System.Drawing.Size(25, 364)
        Me.FlatButton21.TabIndex = 82
        Me.FlatButton21.Tag = "14"
        '
        'FlatButton26
        '
        Me.FlatButton26.ButtonText = ""
        Me.FlatButton26.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton26.Clickable = False
        Me.FlatButton26.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.FlatButton26.Location = New System.Drawing.Point(11, 56)
        Me.FlatButton26.Name = "FlatButton26"
        Me.FlatButton26.Size = New System.Drawing.Size(14, 90)
        Me.FlatButton26.TabIndex = 81
        Me.FlatButton26.Tag = "13"
        '
        'FlatButton25
        '
        Me.FlatButton25.ButtonText = ""
        Me.FlatButton25.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton25.Clickable = False
        Me.FlatButton25.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton25.Location = New System.Drawing.Point(0, 56)
        Me.FlatButton25.Name = "FlatButton25"
        Me.FlatButton25.Size = New System.Drawing.Size(5, 90)
        Me.FlatButton25.TabIndex = 80
        Me.FlatButton25.Tag = "14"
        '
        'FlatButton24
        '
        Me.FlatButton24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton24.ButtonText = "BOOKMARKS"
        Me.FlatButton24.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FlatButton24.Clickable = False
        Me.FlatButton24.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton24.Location = New System.Drawing.Point(63, 5)
        Me.FlatButton24.Name = "FlatButton24"
        Me.FlatButton24.Size = New System.Drawing.Size(644, 25)
        Me.FlatButton24.TabIndex = 80
        Me.FlatButton24.Tag = "14"
        Me.FlatButton24.Text = "BOOKMARKS"
        '
        'Elbow2
        '
        Me.Elbow2.ButtonText = ""
        Me.Elbow2.ButtonTextHeight = 19
        Me.Elbow2.ButtonWidth = 25
        Me.Elbow2.Clickable = False
        Me.Elbow2.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.Elbow2.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow2.Location = New System.Drawing.Point(0, 5)
        Me.Elbow2.Name = "Elbow2"
        Me.Elbow2.Size = New System.Drawing.Size(64, 51)
        Me.Elbow2.TabIndex = 80
        Me.Elbow2.Tag = "14"
        '
        'FlatButton20
        '
        Me.FlatButton20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton20.Beeping = True
        Me.FlatButton20.ButtonText = "DELETE BOOKMARK"
        Me.FlatButton20.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FlatButton20.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton20.Location = New System.Drawing.Point(502, 588)
        Me.FlatButton20.Name = "FlatButton20"
        Me.FlatButton20.Size = New System.Drawing.Size(105, 29)
        Me.FlatButton20.TabIndex = 79
        Me.FlatButton20.Tag = "13"
        Me.FlatButton20.Text = "DELETE BOOKMARK"
        '
        'form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(965, 780)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FlatButton12)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FlatButton16)
        Me.Controls.Add(Me.FlatButton15)
        Me.Controls.Add(Me.FlatButton14)
        Me.Controls.Add(Me.Arrowbutton2)
        Me.Controls.Add(Me.Arrowbutton1)
        Me.Controls.Add(Me.FlatButton13)
        Me.Controls.Add(Me.FlatButton11)
        Me.Controls.Add(Me.FlatButton10)
        Me.Controls.Add(Me.FlatButton9)
        Me.Controls.Add(Me.ComplexButton1)
        Me.Controls.Add(Me.FlatButton5)
        Me.Controls.Add(Me.FlatButton4a)
        Me.Controls.Add(Me.Elbow1)
        Me.Controls.Add(Me.FlatButton6)
        Me.Controls.Add(Me.FlatButton4)
        Me.Controls.Add(Me.FlatButton8)
        Me.Controls.Add(Me.FlatButton7)
        Me.Controls.Add(Me.FlatButton3)
        Me.Controls.Add(Me.FlatButton2)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "20"
        Me.Text = " Lcars Web Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton2 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton3 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton4 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton6 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton7 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton8 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow1 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton4a As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton5 As LCARS.Controls.FlatButton
    Friend WithEvents ComplexButton1 As LCARS.Controls.ComplexButton
    Friend WithEvents FlatButton9 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton10 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton11 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton13 As LCARS.Controls.FlatButton
    Friend WithEvents Arrowbutton1 As LCARS.Controls.FlatButton
    Friend WithEvents Arrowbutton2 As LCARS.Controls.FlatButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents FlatButton14 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton15 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton16 As LCARS.Controls.FlatButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents FlatButton12 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton17 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton18 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton19 As LCARS.Controls.FlatButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FlatButton20 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton24 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow2 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton26 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton25 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton23 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton22 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow3 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton21 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow4 As LCARS.Controls.Elbow
    Friend WithEvents Elbow5 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton32 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton30 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton29 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton28 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton31 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton27 As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton33 As LCARS.Controls.FlatButton

End Class
