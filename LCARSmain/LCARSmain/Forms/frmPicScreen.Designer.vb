<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenChooserDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScreenChooserDialog))
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.btnOK = New LCARS.Controls.StandardButton
        Me.picScreen4 = New System.Windows.Forms.PictureBox
        Me.picScreen2 = New System.Windows.Forms.PictureBox
        Me.picScreen3 = New System.Windows.Forms.PictureBox
        Me.picScreen1 = New System.Windows.Forms.PictureBox
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.picSelect = New System.Windows.Forms.PictureBox
        CType(Me.picScreen4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScreen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScreen3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScreen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StandardButton1
        '
        Me.StandardButton1.BackgroundImage = CType(resources.GetObject("StandardButton1.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.StandardButton1.ButtonText = "CANCEL"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton1.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.StandardButton1.lblTextSize = New System.Drawing.Point(83, 31)
        Me.StandardButton1.lblTextVisible = True
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(215, 403)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(114, 31)
        Me.StandardButton1.TabIndex = 2
        Me.StandardButton1.Text = "CANCEL"
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.Beeping = False
        Me.btnOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.btnOK.ButtonText = "SELECT SCREEN"
        Me.btnOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOK.ButtonTextHeight = 14
        Me.btnOK.Clickable = True
        Me.btnOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.btnOK.Data = Nothing
        Me.btnOK.Data2 = Nothing
        Me.btnOK.FlashInterval = 500
        Me.btnOK.holdDraw = False
        Me.btnOK.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.lblTextLoc = New System.Drawing.Point(15, 0)
        Me.btnOK.lblTextSize = New System.Drawing.Point(83, 31)
        Me.btnOK.lblTextVisible = True
        Me.btnOK.Lit = True
        Me.btnOK.Location = New System.Drawing.Point(335, 403)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RedAlert = LCARS.LCARSalert.Normal
        Me.btnOK.Size = New System.Drawing.Size(114, 31)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "SELECT SCREEN"
        '
        'picScreen4
        '
        Me.picScreen4.Location = New System.Drawing.Point(264, 232)
        Me.picScreen4.Name = "picScreen4"
        Me.picScreen4.Size = New System.Drawing.Size(158, 117)
        Me.picScreen4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picScreen4.TabIndex = 1
        Me.picScreen4.TabStop = False
        '
        'picScreen2
        '
        Me.picScreen2.Location = New System.Drawing.Point(264, 73)
        Me.picScreen2.Name = "picScreen2"
        Me.picScreen2.Size = New System.Drawing.Size(158, 117)
        Me.picScreen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picScreen2.TabIndex = 1
        Me.picScreen2.TabStop = False
        '
        'picScreen3
        '
        Me.picScreen3.Location = New System.Drawing.Point(34, 232)
        Me.picScreen3.Name = "picScreen3"
        Me.picScreen3.Size = New System.Drawing.Size(158, 117)
        Me.picScreen3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picScreen3.TabIndex = 1
        Me.picScreen3.TabStop = False
        '
        'picScreen1
        '
        Me.picScreen1.Location = New System.Drawing.Point(34, 73)
        Me.picScreen1.Name = "picScreen1"
        Me.picScreen1.Size = New System.Drawing.Size(158, 117)
        Me.picScreen1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picScreen1.TabIndex = 1
        Me.picScreen1.TabStop = False
        '
        'tbTitle
        '
        Me.tbTitle.BackgroundImage = CType(resources.GetObject("tbTitle.BackgroundImage"), System.Drawing.Image)
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "INTERFACE SELECTOR"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tbTitle.ButtonTextHeight = 24
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = True
        Me.tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbTitle.lblTextSize = New System.Drawing.Point(437, 22)
        Me.tbTitle.lblTextVisible = False
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(12, 12)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(437, 22)
        Me.tbTitle.TabIndex = 0
        Me.tbTitle.Text = "INTERFACE SELECTOR"
        '
        'picSelect
        '
        Me.picSelect.Image = Global.LCARSmain.My.Resources.Resources.box
        Me.picSelect.Location = New System.Drawing.Point(13, 59)
        Me.picSelect.Name = "picSelect"
        Me.picSelect.Size = New System.Drawing.Size(202, 144)
        Me.picSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSelect.TabIndex = 3
        Me.picSelect.TabStop = False
        '
        'ScreenChooserDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(461, 446)
        Me.Controls.Add(Me.StandardButton1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picScreen4)
        Me.Controls.Add(Me.picScreen2)
        Me.Controls.Add(Me.picScreen3)
        Me.Controls.Add(Me.picScreen1)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.picSelect)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScreenChooserDialog"
        Me.Text = "Interface Selector"
        CType(Me.picScreen4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScreen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScreen3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScreen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents picScreen1 As System.Windows.Forms.PictureBox
    Friend WithEvents picScreen3 As System.Windows.Forms.PictureBox
    Friend WithEvents picScreen2 As System.Windows.Forms.PictureBox
    Friend WithEvents picScreen4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOK As LCARS.Controls.StandardButton
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents picSelect As System.Windows.Forms.PictureBox
End Class
