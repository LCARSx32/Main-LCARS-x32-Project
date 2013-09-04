<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirstRun
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirstRun))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Elbow1 = New LCARS.Controls.Elbow
        Me.fbBeep = New LCARS.Controls.FlatButton
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.Elbow2 = New LCARS.Controls.Elbow
        Me.FlatButton2 = New LCARS.Controls.FlatButton
        Me.fbExit = New LCARS.Controls.FlatButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.picMain2 = New System.Windows.Forms.PictureBox
        Me.picMain1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.picSelect = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.picMain2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMain1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(8, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(388, 114)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to the LCARS x32 initialization sequence.  The computer is going to ask y" & _
            "ou a few questions so it can set the interface up for you.  Please click the fla" & _
            "shing 'Continue' button to begin."
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.LCARSmain.My.Resources.Resources.federationLogo
        Me.PictureBox1.Location = New System.Drawing.Point(8, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(388, 243)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Elbow1
        '
        Me.Elbow1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow1.Beeping = True
        Me.Elbow1.ButtonHeight = 25
        Me.Elbow1.ButtonText = "LCARS X32 INITIATION SEQUENCE"
        Me.Elbow1.ButtonTextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Elbow1.ButtonTextHeight = 18
        Me.Elbow1.ButtonWidth = 200
        Me.Elbow1.Clickable = False
        Me.Elbow1.Color = LCARS.LCARScolorStyles.StaticTan
        Me.Elbow1.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow1.Data = Nothing
        Me.Elbow1.Data2 = Nothing
        Me.Elbow1.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.Elbow1.FlashInterval = 500
        Me.Elbow1.holdDraw = False
        Me.Elbow1.Lit = True
        Me.Elbow1.Location = New System.Drawing.Point(12, 12)
        Me.Elbow1.Name = "Elbow1"
        Me.Elbow1.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow1.Size = New System.Drawing.Size(616, 104)
        Me.Elbow1.TabIndex = 3
        Me.Elbow1.Text = "LCARS X32 INITIATION SEQUENCE"
        '
        'fbBeep
        '
        Me.fbBeep.Beeping = True
        Me.fbBeep.ButtonText = "TURN OFF BUTTON BEEPS"
        Me.fbBeep.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbBeep.ButtonTextHeight = 14
        Me.fbBeep.Clickable = True
        Me.fbBeep.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.fbBeep.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbBeep.Data = Nothing
        Me.fbBeep.Data2 = Nothing
        Me.fbBeep.FlashInterval = 500
        Me.fbBeep.holdDraw = False
        Me.fbBeep.Lit = True
        Me.fbBeep.Location = New System.Drawing.Point(12, 122)
        Me.fbBeep.Name = "fbBeep"
        Me.fbBeep.RedAlert = LCARS.LCARSalert.Normal
        Me.fbBeep.Size = New System.Drawing.Size(200, 36)
        Me.fbBeep.TabIndex = 4
        Me.fbBeep.Text = "TURN OFF BUTTON BEEPS"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.Beeping = True
        Me.FlatButton1.ButtonText = "X32"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = False
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(12, 164)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(200, 152)
        Me.FlatButton1.TabIndex = 5
        Me.FlatButton1.Text = "X32"
        '
        'Elbow2
        '
        Me.Elbow2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elbow2.Beeping = True
        Me.Elbow2.ButtonHeight = 25
        Me.Elbow2.ButtonText = "JUPITER STATION SOFTWORKS 2009"
        Me.Elbow2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Elbow2.ButtonTextHeight = 14
        Me.Elbow2.ButtonWidth = 200
        Me.Elbow2.Clickable = False
        Me.Elbow2.Color = LCARS.LCARScolorStyles.StaticTan
        Me.Elbow2.CustomAlertColor = System.Drawing.Color.Empty
        Me.Elbow2.Data = Nothing
        Me.Elbow2.Data2 = Nothing
        Me.Elbow2.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.Elbow2.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.Elbow2.FlashInterval = 500
        Me.Elbow2.holdDraw = False
        Me.Elbow2.Lit = True
        Me.Elbow2.Location = New System.Drawing.Point(12, 364)
        Me.Elbow2.Name = "Elbow2"
        Me.Elbow2.RedAlert = LCARS.LCARSalert.Normal
        Me.Elbow2.Size = New System.Drawing.Size(487, 104)
        Me.Elbow2.TabIndex = 6
        Me.Elbow2.Text = "JUPITER STATION SOFTWORKS 2009"
        '
        'FlatButton2
        '
        Me.FlatButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlatButton2.Beeping = True
        Me.FlatButton2.ButtonText = "CONTINUE"
        Me.FlatButton2.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.FlatButton2.ButtonTextHeight = 14
        Me.FlatButton2.Clickable = True
        Me.FlatButton2.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.FlatButton2.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton2.Data = Nothing
        Me.FlatButton2.Data2 = Nothing
        Me.FlatButton2.Flash = True
        Me.FlatButton2.FlashInterval = 1000
        Me.FlatButton2.holdDraw = False
        Me.FlatButton2.Lit = True
        Me.FlatButton2.Location = New System.Drawing.Point(12, 322)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton2.Size = New System.Drawing.Size(200, 36)
        Me.FlatButton2.TabIndex = 7
        Me.FlatButton2.Text = "CONTINUE"
        '
        'fbExit
        '
        Me.fbExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbExit.Beeping = True
        Me.fbExit.ButtonText = "EXIT"
        Me.fbExit.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbExit.ButtonTextHeight = 14
        Me.fbExit.Clickable = True
        Me.fbExit.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.fbExit.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbExit.Data = Nothing
        Me.fbExit.Data2 = Nothing
        Me.fbExit.FlashInterval = 500
        Me.fbExit.holdDraw = False
        Me.fbExit.Lit = True
        Me.fbExit.Location = New System.Drawing.Point(505, 443)
        Me.fbExit.Name = "fbExit"
        Me.fbExit.RedAlert = LCARS.LCARSalert.Normal
        Me.fbExit.Size = New System.Drawing.Size(123, 25)
        Me.fbExit.TabIndex = 8
        Me.fbExit.Text = "EXIT"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabControl1.Location = New System.Drawing.Point(203, 48)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(410, 392)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(402, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Welcome"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.picMain2)
        Me.TabPage2.Controls.Add(Me.picMain1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.picSelect)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(402, 366)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'picMain2
        '
        Me.picMain2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picMain2.Image = CType(resources.GetObject("picMain2.Image"), System.Drawing.Image)
        Me.picMain2.Location = New System.Drawing.Point(229, 176)
        Me.picMain2.Name = "picMain2"
        Me.picMain2.Size = New System.Drawing.Size(128, 96)
        Me.picMain2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMain2.TabIndex = 1
        Me.picMain2.TabStop = False
        '
        'picMain1
        '
        Me.picMain1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picMain1.Image = CType(resources.GetObject("picMain1.Image"), System.Drawing.Image)
        Me.picMain1.Location = New System.Drawing.Point(55, 176)
        Me.picMain1.Name = "picMain1"
        Me.picMain1.Size = New System.Drawing.Size(128, 96)
        Me.picMain1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMain1.TabIndex = 0
        Me.picMain1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(388, 139)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Please select the main screen you would like to use by clicking on its image.  Yo" & _
            "u can change main screens later in Settings.  Click  'Continue' once you have ma" & _
            "de your selection."
        '
        'picSelect
        '
        Me.picSelect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picSelect.Image = CType(resources.GetObject("picSelect.Image"), System.Drawing.Image)
        Me.picSelect.Location = New System.Drawing.Point(36, 161)
        Me.picSelect.Name = "picSelect"
        Me.picSelect.Size = New System.Drawing.Size(168, 127)
        Me.picSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSelect.TabIndex = 3
        Me.picSelect.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Location = New System.Drawing.Point(218, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 392)
        Me.Panel1.TabIndex = 10
        '
        'frmFirstRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.fbExit)
        Me.Controls.Add(Me.FlatButton2)
        Me.Controls.Add(Me.Elbow2)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.fbBeep)
        Me.Controls.Add(Me.Elbow1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFirstRun"
        Me.Text = "frmFirstRun"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.picMain2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMain1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Elbow1 As LCARS.Controls.Elbow
    Friend WithEvents fbBeep As LCARS.Controls.FlatButton
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents Elbow2 As LCARS.Controls.Elbow
    Friend WithEvents FlatButton2 As LCARS.Controls.FlatButton
    Friend WithEvents fbExit As LCARS.Controls.FlatButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picMain2 As System.Windows.Forms.PictureBox
    Friend WithEvents picMain1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picSelect As System.Windows.Forms.PictureBox
End Class
