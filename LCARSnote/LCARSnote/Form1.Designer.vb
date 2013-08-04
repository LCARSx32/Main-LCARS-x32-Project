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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim LcarScolor1 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor2 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor3 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor4 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor5 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor6 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor7 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.sbX = New LCARS.Controls.StandardButton
        Me.sbFullScreen = New LCARS.Controls.StandardButton
        Me.sbSaveAs = New LCARS.Controls.StandardButton
        Me.sbClose = New LCARS.Controls.StandardButton
        Me.sbOpen = New LCARS.Controls.StandardButton
        Me.sbSave = New LCARS.Controls.StandardButton
        Me.sbNew = New LCARS.Controls.StandardButton
        Me.xtNote = New LCARS.Controls.x32TabControl
        Me.SuspendLayout()
        '
        'sbX
        '
        Me.sbX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbX.BackgroundImage = CType(resources.GetObject("sbX.BackgroundImage"), System.Drawing.Image)
        Me.sbX.Beeping = False
        Me.sbX.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbX.ButtonText = "X"
        Me.sbX.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbX.ButtonTextHeight = 14
        Me.sbX.Clickable = True
        Me.sbX.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbX.ColorsAvailable = LcarScolor1
        Me.sbX.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbX.Data = Nothing
        Me.sbX.Data2 = Nothing
        Me.sbX.FlashInterval = 500
        Me.sbX.holdDraw = False
        Me.sbX.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbX.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.sbX.lblTextSize = New System.Drawing.Size(35, 35)
        Me.sbX.lblTextVisible = True
        Me.sbX.Lit = True
        Me.sbX.Location = New System.Drawing.Point(702, 6)
        Me.sbX.Name = "sbX"
        Me.sbX.RedAlert = LCARS.LCARSalert.Normal
        Me.sbX.Size = New System.Drawing.Size(35, 35)
        Me.sbX.TabIndex = 7
        Me.sbX.Text = "X"
        '
        'sbFullScreen
        '
        Me.sbFullScreen.BackgroundImage = CType(resources.GetObject("sbFullScreen.BackgroundImage"), System.Drawing.Image)
        Me.sbFullScreen.Beeping = False
        Me.sbFullScreen.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbFullScreen.ButtonText = "FULLSCREEN"
        Me.sbFullScreen.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbFullScreen.ButtonTextHeight = 14
        Me.sbFullScreen.Clickable = True
        Me.sbFullScreen.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbFullScreen.ColorsAvailable = LcarScolor2
        Me.sbFullScreen.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbFullScreen.Data = Nothing
        Me.sbFullScreen.Data2 = Nothing
        Me.sbFullScreen.FlashInterval = 500
        Me.sbFullScreen.holdDraw = False
        Me.sbFullScreen.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbFullScreen.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbFullScreen.lblTextSize = New System.Drawing.Size(65, 35)
        Me.sbFullScreen.lblTextVisible = True
        Me.sbFullScreen.Lit = True
        Me.sbFullScreen.Location = New System.Drawing.Point(594, 6)
        Me.sbFullScreen.Name = "sbFullScreen"
        Me.sbFullScreen.RedAlert = LCARS.LCARSalert.Normal
        Me.sbFullScreen.Size = New System.Drawing.Size(100, 35)
        Me.sbFullScreen.TabIndex = 6
        Me.sbFullScreen.Text = "FULLSCREEN"
        '
        'sbSaveAs
        '
        Me.sbSaveAs.BackgroundImage = CType(resources.GetObject("sbSaveAs.BackgroundImage"), System.Drawing.Image)
        Me.sbSaveAs.Beeping = False
        Me.sbSaveAs.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSaveAs.ButtonText = "SAVE AS"
        Me.sbSaveAs.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSaveAs.ButtonTextHeight = 14
        Me.sbSaveAs.Clickable = False
        Me.sbSaveAs.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbSaveAs.ColorsAvailable = LcarScolor3
        Me.sbSaveAs.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbSaveAs.Data = Nothing
        Me.sbSaveAs.Data2 = Nothing
        Me.sbSaveAs.FlashInterval = 500
        Me.sbSaveAs.holdDraw = False
        Me.sbSaveAs.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbSaveAs.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbSaveAs.lblTextSize = New System.Drawing.Size(55, 35)
        Me.sbSaveAs.lblTextVisible = True
        Me.sbSaveAs.Lit = False
        Me.sbSaveAs.Location = New System.Drawing.Point(211, 6)
        Me.sbSaveAs.Name = "sbSaveAs"
        Me.sbSaveAs.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSaveAs.Size = New System.Drawing.Size(90, 35)
        Me.sbSaveAs.TabIndex = 5
        Me.sbSaveAs.Text = "SAVE AS"
        '
        'sbClose
        '
        Me.sbClose.BackgroundImage = CType(resources.GetObject("sbClose.BackgroundImage"), System.Drawing.Image)
        Me.sbClose.Beeping = False
        Me.sbClose.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbClose.ButtonText = "CLOSE"
        Me.sbClose.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbClose.ButtonTextHeight = 14
        Me.sbClose.Clickable = False
        Me.sbClose.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbClose.ColorsAvailable = LcarScolor4
        Me.sbClose.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbClose.Data = Nothing
        Me.sbClose.Data2 = Nothing
        Me.sbClose.FlashInterval = 500
        Me.sbClose.holdDraw = False
        Me.sbClose.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbClose.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbClose.lblTextSize = New System.Drawing.Size(55, 35)
        Me.sbClose.lblTextVisible = True
        Me.sbClose.Lit = False
        Me.sbClose.Location = New System.Drawing.Point(458, 6)
        Me.sbClose.Name = "sbClose"
        Me.sbClose.RedAlert = LCARS.LCARSalert.Normal
        Me.sbClose.Size = New System.Drawing.Size(90, 35)
        Me.sbClose.TabIndex = 4
        Me.sbClose.Text = "CLOSE"
        '
        'sbOpen
        '
        Me.sbOpen.BackgroundImage = CType(resources.GetObject("sbOpen.BackgroundImage"), System.Drawing.Image)
        Me.sbOpen.Beeping = False
        Me.sbOpen.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOpen.ButtonText = "OPEN"
        Me.sbOpen.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbOpen.ButtonTextHeight = 14
        Me.sbOpen.Clickable = True
        Me.sbOpen.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbOpen.ColorsAvailable = LcarScolor5
        Me.sbOpen.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOpen.Data = Nothing
        Me.sbOpen.Data2 = Nothing
        Me.sbOpen.FlashInterval = 500
        Me.sbOpen.holdDraw = False
        Me.sbOpen.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbOpen.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbOpen.lblTextSize = New System.Drawing.Size(55, 35)
        Me.sbOpen.lblTextVisible = True
        Me.sbOpen.Lit = True
        Me.sbOpen.Location = New System.Drawing.Point(362, 6)
        Me.sbOpen.Name = "sbOpen"
        Me.sbOpen.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOpen.Size = New System.Drawing.Size(90, 35)
        Me.sbOpen.TabIndex = 3
        Me.sbOpen.Text = "OPEN"
        '
        'sbSave
        '
        Me.sbSave.BackgroundImage = CType(resources.GetObject("sbSave.BackgroundImage"), System.Drawing.Image)
        Me.sbSave.Beeping = False
        Me.sbSave.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSave.ButtonText = "SAVE"
        Me.sbSave.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSave.ButtonTextHeight = 14
        Me.sbSave.Clickable = False
        Me.sbSave.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbSave.ColorsAvailable = LcarScolor6
        Me.sbSave.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbSave.Data = Nothing
        Me.sbSave.Data2 = Nothing
        Me.sbSave.FlashInterval = 500
        Me.sbSave.holdDraw = False
        Me.sbSave.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbSave.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbSave.lblTextSize = New System.Drawing.Size(55, 35)
        Me.sbSave.lblTextVisible = True
        Me.sbSave.Lit = False
        Me.sbSave.Location = New System.Drawing.Point(115, 6)
        Me.sbSave.Name = "sbSave"
        Me.sbSave.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSave.Size = New System.Drawing.Size(90, 35)
        Me.sbSave.TabIndex = 2
        Me.sbSave.Text = "SAVE"
        '
        'sbNew
        '
        Me.sbNew.BackgroundImage = CType(resources.GetObject("sbNew.BackgroundImage"), System.Drawing.Image)
        Me.sbNew.Beeping = False
        Me.sbNew.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbNew.ButtonText = "NEW"
        Me.sbNew.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbNew.ButtonTextHeight = 14
        Me.sbNew.Clickable = True
        Me.sbNew.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbNew.ColorsAvailable = LcarScolor7
        Me.sbNew.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbNew.Data = Nothing
        Me.sbNew.Data2 = Nothing
        Me.sbNew.Flash = True
        Me.sbNew.FlashInterval = 500
        Me.sbNew.holdDraw = False
        Me.sbNew.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.sbNew.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbNew.lblTextSize = New System.Drawing.Size(55, 35)
        Me.sbNew.lblTextVisible = True
        Me.sbNew.Lit = True
        Me.sbNew.Location = New System.Drawing.Point(6, 6)
        Me.sbNew.Name = "sbNew"
        Me.sbNew.RedAlert = LCARS.LCARSalert.Normal
        Me.sbNew.Size = New System.Drawing.Size(90, 35)
        Me.sbNew.TabIndex = 1
        Me.sbNew.Text = "NEW"
        '
        'xtNote
        '
        Me.xtNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xtNote.BackColor = System.Drawing.Color.Black
        Me.xtNote.Location = New System.Drawing.Point(6, 47)
        Me.xtNote.Name = "xtNote"
        Me.xtNote.SelectedTab = Nothing
        Me.xtNote.Size = New System.Drawing.Size(731, 440)
        Me.xtNote.TabIndex = 0
        Me.xtNote.Text = "X32TabControl1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(744, 494)
        Me.Controls.Add(Me.sbX)
        Me.Controls.Add(Me.sbFullScreen)
        Me.Controls.Add(Me.sbSaveAs)
        Me.Controls.Add(Me.sbClose)
        Me.Controls.Add(Me.sbOpen)
        Me.Controls.Add(Me.sbSave)
        Me.Controls.Add(Me.sbNew)
        Me.Controls.Add(Me.xtNote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents xtNote As LCARS.Controls.x32TabControl
    Friend WithEvents sbNew As LCARS.Controls.StandardButton
    Friend WithEvents sbSave As LCARS.Controls.StandardButton
    Friend WithEvents sbOpen As LCARS.Controls.StandardButton
    Friend WithEvents sbClose As LCARS.Controls.StandardButton
    Friend WithEvents sbSaveAs As LCARS.Controls.StandardButton
    Friend WithEvents sbFullScreen As LCARS.Controls.StandardButton
    Friend WithEvents sbX As LCARS.Controls.StandardButton

End Class
