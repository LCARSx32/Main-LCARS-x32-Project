<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileSelect))
        Me.elbTop = New LCARS.Controls.Elbow
        Me.elbBottom = New LCARS.Controls.Elbow
        Me.sbUp = New LCARS.Controls.FlatButton
        Me.fbExt = New LCARS.Controls.FlatButton
        Me.pnlMyComp = New System.Windows.Forms.Panel
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.lblCurrentSelected = New System.Windows.Forms.Label
        Me.hpLocation = New LCARS.Controls.HalfPillButton
        Me.scrlBar = New System.Windows.Forms.TrackBar
        Me.hpPrompt = New LCARS.Controls.HalfPillButton
        CType(Me.scrlBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'elbTop
        '
        Me.elbTop.BackgroundImage = CType(resources.GetObject("elbTop.BackgroundImage"), System.Drawing.Image)
        Me.elbTop.Beeping = False
        Me.elbTop.ButtonHeight = 25
        Me.elbTop.ButtonText = ""
        Me.elbTop.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.elbTop.ButtonTextHeight = 14
        Me.elbTop.ButtonWidth = 100
        Me.elbTop.Clickable = True
        Me.elbTop.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbTop.Data = Nothing
        Me.elbTop.Data2 = Nothing
        Me.elbTop.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbTop.FlashInterval = 500
        Me.elbTop.holdDraw = False
        Me.elbTop.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbTop.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbTop.lblTextSize = New System.Drawing.Point(141, 44)
        Me.elbTop.lblTextVisible = True
        Me.elbTop.Lit = True
        Me.elbTop.Location = New System.Drawing.Point(12, 12)
        Me.elbTop.Name = "elbTop"
        Me.elbTop.RedAlert = LCARS.LCARSalert.Normal
        Me.elbTop.Size = New System.Drawing.Size(141, 44)
        Me.elbTop.TabIndex = 0
        '
        'elbBottom
        '
        Me.elbBottom.BackgroundImage = CType(resources.GetObject("elbBottom.BackgroundImage"), System.Drawing.Image)
        Me.elbBottom.Beeping = False
        Me.elbBottom.ButtonHeight = 25
        Me.elbBottom.ButtonText = ""
        Me.elbBottom.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.elbBottom.ButtonTextHeight = 14
        Me.elbBottom.ButtonWidth = 100
        Me.elbBottom.Clickable = False
        Me.elbBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbBottom.Data = Nothing
        Me.elbBottom.Data2 = Nothing
        Me.elbBottom.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbBottom.FlashInterval = 500
        Me.elbBottom.holdDraw = False
        Me.elbBottom.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbBottom.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.elbBottom.lblTextSize = New System.Drawing.Point(141, 44)
        Me.elbBottom.lblTextVisible = True
        Me.elbBottom.Lit = True
        Me.elbBottom.Location = New System.Drawing.Point(12, 441)
        Me.elbBottom.Name = "elbBottom"
        Me.elbBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.elbBottom.Size = New System.Drawing.Size(141, 44)
        Me.elbBottom.TabIndex = 1
        '
        'sbUp
        '
        Me.sbUp.BackgroundImage = CType(resources.GetObject("sbUp.BackgroundImage"), System.Drawing.Image)
        Me.sbUp.Beeping = False
        Me.sbUp.ButtonText = "UP A DIRECTORY"
        Me.sbUp.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbUp.ButtonTextHeight = 14
        Me.sbUp.Clickable = True
        Me.sbUp.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbUp.Data = Nothing
        Me.sbUp.Data2 = Nothing
        Me.sbUp.FlashInterval = 500
        Me.sbUp.holdDraw = False
        Me.sbUp.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUp.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.sbUp.lblTextSize = New System.Drawing.Point(100, 25)
        Me.sbUp.lblTextVisible = True
        Me.sbUp.Lit = False
        Me.sbUp.Location = New System.Drawing.Point(12, 62)
        Me.sbUp.Name = "sbUp"
        Me.sbUp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUp.Size = New System.Drawing.Size(100, 25)
        Me.sbUp.TabIndex = 2
        Me.sbUp.Text = "UP A DIRECTORY"
        '
        'fbExt
        '
        Me.fbExt.BackgroundImage = CType(resources.GetObject("fbExt.BackgroundImage"), System.Drawing.Image)
        Me.fbExt.Beeping = False
        Me.fbExt.ButtonText = ""
        Me.fbExt.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbExt.ButtonTextHeight = 14
        Me.fbExt.Clickable = False
        Me.fbExt.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbExt.Data = Nothing
        Me.fbExt.Data2 = Nothing
        Me.fbExt.FlashInterval = 500
        Me.fbExt.holdDraw = False
        Me.fbExt.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbExt.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbExt.lblTextSize = New System.Drawing.Point(100, 341)
        Me.fbExt.lblTextVisible = True
        Me.fbExt.Lit = True
        Me.fbExt.Location = New System.Drawing.Point(12, 94)
        Me.fbExt.Name = "fbExt"
        Me.fbExt.RedAlert = LCARS.LCARSalert.Normal
        Me.fbExt.Size = New System.Drawing.Size(100, 341)
        Me.fbExt.TabIndex = 3
        '
        'pnlMyComp
        '
        Me.pnlMyComp.Location = New System.Drawing.Point(119, 62)
        Me.pnlMyComp.Name = "pnlMyComp"
        Me.pnlMyComp.Size = New System.Drawing.Size(374, 298)
        Me.pnlMyComp.TabIndex = 4
        '
        'sbOK
        '
        Me.sbOK.BackgroundImage = CType(resources.GetObject("sbOK.BackgroundImage"), System.Drawing.Image)
        Me.sbOK.Beeping = False
        Me.sbOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.ButtonTextHeight = 14
        Me.sbOK.Clickable = True
        Me.sbOK.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbOK.Data = Nothing
        Me.sbOK.Data2 = Nothing
        Me.sbOK.FlashInterval = 500
        Me.sbOK.holdDraw = False
        Me.sbOK.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOK.lblTextLoc = New System.Drawing.Point(14, 0)
        Me.sbOK.lblTextSize = New System.Drawing.Point(46, 28)
        Me.sbOK.lblTextVisible = True
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(420, 421)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(74, 28)
        Me.sbOK.TabIndex = 5
        Me.sbOK.Text = "OK"
        '
        'sbCancel
        '
        Me.sbCancel.BackgroundImage = CType(resources.GetObject("sbCancel.BackgroundImage"), System.Drawing.Image)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.lblTextLoc = New System.Drawing.Point(14, 0)
        Me.sbCancel.lblTextSize = New System.Drawing.Point(46, 28)
        Me.sbCancel.lblTextVisible = True
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(328, 421)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(74, 28)
        Me.sbCancel.TabIndex = 5
        Me.sbCancel.Text = "CANCEL"
        '
        'lblCurrentSelected
        '
        Me.lblCurrentSelected.AutoSize = True
        Me.lblCurrentSelected.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentSelected.Location = New System.Drawing.Point(129, 414)
        Me.lblCurrentSelected.Name = "lblCurrentSelected"
        Me.lblCurrentSelected.Size = New System.Drawing.Size(71, 24)
        Me.lblCurrentSelected.TabIndex = 6
        Me.lblCurrentSelected.Text = "Current File"
        '
        'hpLocation
        '
        Me.hpLocation.BackgroundImage = CType(resources.GetObject("hpLocation.BackgroundImage"), System.Drawing.Image)
        Me.hpLocation.Beeping = False
        Me.hpLocation.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpLocation.ButtonText = "C:\"
        Me.hpLocation.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hpLocation.ButtonTextHeight = 14
        Me.hpLocation.Clickable = False
        Me.hpLocation.Color = LCARS.LCARScolorStyles.StaticTan
        Me.hpLocation.Data = Nothing
        Me.hpLocation.Data2 = Nothing
        Me.hpLocation.FlashInterval = 500
        Me.hpLocation.holdDraw = False
        Me.hpLocation.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpLocation.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpLocation.lblTextSize = New System.Drawing.Point(334, 25)
        Me.hpLocation.lblTextVisible = True
        Me.hpLocation.Lit = True
        Me.hpLocation.Location = New System.Drawing.Point(159, 12)
        Me.hpLocation.Name = "hpLocation"
        Me.hpLocation.RedAlert = LCARS.LCARSalert.Normal
        Me.hpLocation.Size = New System.Drawing.Size(334, 25)
        Me.hpLocation.TabIndex = 7
        Me.hpLocation.Text = "C:\"
        '
        'scrlBar
        '
        Me.scrlBar.Location = New System.Drawing.Point(118, 366)
        Me.scrlBar.Maximum = 0
        Me.scrlBar.Name = "scrlBar"
        Me.scrlBar.Size = New System.Drawing.Size(376, 45)
        Me.scrlBar.TabIndex = 92
        Me.scrlBar.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.scrlBar.Visible = False
        '
        'hpPrompt
        '
        Me.hpPrompt.BackgroundImage = CType(resources.GetObject("hpPrompt.BackgroundImage"), System.Drawing.Image)
        Me.hpPrompt.Beeping = False
        Me.hpPrompt.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillRight
        Me.hpPrompt.ButtonText = ""
        Me.hpPrompt.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hpPrompt.ButtonTextHeight = 14
        Me.hpPrompt.Clickable = False
        Me.hpPrompt.Color = LCARS.LCARScolorStyles.StaticTan
        Me.hpPrompt.Data = Nothing
        Me.hpPrompt.Data2 = Nothing
        Me.hpPrompt.FlashInterval = 500
        Me.hpPrompt.holdDraw = False
        Me.hpPrompt.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hpPrompt.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.hpPrompt.lblTextSize = New System.Drawing.Point(334, 25)
        Me.hpPrompt.lblTextVisible = True
        Me.hpPrompt.Lit = True
        Me.hpPrompt.Location = New System.Drawing.Point(159, 460)
        Me.hpPrompt.Name = "hpPrompt"
        Me.hpPrompt.RedAlert = LCARS.LCARSalert.Normal
        Me.hpPrompt.Size = New System.Drawing.Size(334, 25)
        Me.hpPrompt.TabIndex = 7
        '
        'frmFileSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(505, 497)
        Me.Controls.Add(Me.scrlBar)
        Me.Controls.Add(Me.hpPrompt)
        Me.Controls.Add(Me.hpLocation)
        Me.Controls.Add(Me.lblCurrentSelected)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.pnlMyComp)
        Me.Controls.Add(Me.fbExt)
        Me.Controls.Add(Me.sbUp)
        Me.Controls.Add(Me.elbBottom)
        Me.Controls.Add(Me.elbTop)
        Me.ForeColor = System.Drawing.Color.OrangeRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFileSelect"
        Me.Text = "frmFileSelect"
        CType(Me.scrlBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elbTop As LCARS.Controls.Elbow
    Friend WithEvents elbBottom As LCARS.Controls.Elbow
    Friend WithEvents sbUp As LCARS.Controls.FlatButton
    Friend WithEvents fbExt As LCARS.Controls.FlatButton
    Friend WithEvents pnlMyComp As System.Windows.Forms.Panel
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents lblCurrentSelected As System.Windows.Forms.Label
    Friend WithEvents hpLocation As LCARS.Controls.HalfPillButton
    Friend WithEvents scrlBar As System.Windows.Forms.TrackBar
    Friend WithEvents hpPrompt As LCARS.Controls.HalfPillButton
End Class
