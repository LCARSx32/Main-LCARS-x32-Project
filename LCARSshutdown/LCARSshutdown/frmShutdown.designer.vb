<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShutdown
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShutdown))
        Me.sbShutdown = New LCARS.Controls.StandardButton
        Me.sbRestart = New LCARS.Controls.StandardButton
        Me.sbLogOff = New LCARS.Controls.StandardButton
        Me.sbSuspend = New LCARS.Controls.StandardButton
        Me.sbHibernate = New LCARS.Controls.StandardButton
        Me.sbExit = New LCARS.Controls.StandardButton
        Me.sbExitMyComp = New LCARS.Controls.StandardButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.sbLock = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'sbShutdown
        '
        Me.sbShutdown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbShutdown.BackgroundImage = CType(resources.GetObject("sbShutdown.BackgroundImage"), System.Drawing.Image)
        Me.sbShutdown.Beeping = False
        Me.sbShutdown.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbShutdown.ButtonText = "SHUT DOWN"
        Me.sbShutdown.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbShutdown.ButtonTextHeight = 18
        Me.sbShutdown.Clickable = True
        Me.sbShutdown.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbShutdown.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbShutdown.Data = Nothing
        Me.sbShutdown.Data2 = Nothing
        Me.sbShutdown.FlashInterval = 500
        Me.sbShutdown.holdDraw = False
        Me.sbShutdown.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbShutdown.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbShutdown.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbShutdown.lblTextVisible = True
        Me.sbShutdown.Lit = True
        Me.sbShutdown.Location = New System.Drawing.Point(331, 219)
        Me.sbShutdown.Name = "sbShutdown"
        Me.sbShutdown.RedAlert = LCARS.LCARSalert.Normal
        Me.sbShutdown.Size = New System.Drawing.Size(153, 36)
        Me.sbShutdown.TabIndex = 0
        Me.sbShutdown.Text = "SHUT DOWN"
        '
        'sbRestart
        '
        Me.sbRestart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbRestart.BackgroundImage = CType(resources.GetObject("sbRestart.BackgroundImage"), System.Drawing.Image)
        Me.sbRestart.Beeping = False
        Me.sbRestart.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbRestart.ButtonText = "RESTART"
        Me.sbRestart.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbRestart.ButtonTextHeight = 18
        Me.sbRestart.Clickable = True
        Me.sbRestart.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbRestart.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbRestart.Data = Nothing
        Me.sbRestart.Data2 = Nothing
        Me.sbRestart.FlashInterval = 500
        Me.sbRestart.holdDraw = False
        Me.sbRestart.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbRestart.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbRestart.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbRestart.lblTextVisible = True
        Me.sbRestart.Lit = True
        Me.sbRestart.Location = New System.Drawing.Point(331, 177)
        Me.sbRestart.Name = "sbRestart"
        Me.sbRestart.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRestart.Size = New System.Drawing.Size(153, 36)
        Me.sbRestart.TabIndex = 1
        Me.sbRestart.Text = "RESTART"
        '
        'sbLogOff
        '
        Me.sbLogOff.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbLogOff.BackgroundImage = CType(resources.GetObject("sbLogOff.BackgroundImage"), System.Drawing.Image)
        Me.sbLogOff.Beeping = False
        Me.sbLogOff.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbLogOff.ButtonText = "LOG OFF"
        Me.sbLogOff.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbLogOff.ButtonTextHeight = 18
        Me.sbLogOff.Clickable = True
        Me.sbLogOff.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbLogOff.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbLogOff.Data = Nothing
        Me.sbLogOff.Data2 = Nothing
        Me.sbLogOff.FlashInterval = 500
        Me.sbLogOff.holdDraw = False
        Me.sbLogOff.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbLogOff.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbLogOff.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbLogOff.lblTextVisible = True
        Me.sbLogOff.Lit = True
        Me.sbLogOff.Location = New System.Drawing.Point(331, 135)
        Me.sbLogOff.Name = "sbLogOff"
        Me.sbLogOff.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLogOff.Size = New System.Drawing.Size(153, 36)
        Me.sbLogOff.TabIndex = 2
        Me.sbLogOff.Text = "LOG OFF"
        '
        'sbSuspend
        '
        Me.sbSuspend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbSuspend.BackgroundImage = CType(resources.GetObject("sbSuspend.BackgroundImage"), System.Drawing.Image)
        Me.sbSuspend.Beeping = False
        Me.sbSuspend.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSuspend.ButtonText = "SUSPEND"
        Me.sbSuspend.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSuspend.ButtonTextHeight = 18
        Me.sbSuspend.Clickable = True
        Me.sbSuspend.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbSuspend.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbSuspend.Data = Nothing
        Me.sbSuspend.Data2 = Nothing
        Me.sbSuspend.FlashInterval = 500
        Me.sbSuspend.holdDraw = False
        Me.sbSuspend.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSuspend.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbSuspend.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbSuspend.lblTextVisible = True
        Me.sbSuspend.Lit = True
        Me.sbSuspend.Location = New System.Drawing.Point(156, 177)
        Me.sbSuspend.Name = "sbSuspend"
        Me.sbSuspend.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSuspend.Size = New System.Drawing.Size(153, 36)
        Me.sbSuspend.TabIndex = 3
        Me.sbSuspend.Text = "SUSPEND"
        '
        'sbHibernate
        '
        Me.sbHibernate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbHibernate.BackgroundImage = CType(resources.GetObject("sbHibernate.BackgroundImage"), System.Drawing.Image)
        Me.sbHibernate.Beeping = False
        Me.sbHibernate.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbHibernate.ButtonText = "HIBERNATE"
        Me.sbHibernate.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbHibernate.ButtonTextHeight = 18
        Me.sbHibernate.Clickable = True
        Me.sbHibernate.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHibernate.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbHibernate.Data = Nothing
        Me.sbHibernate.Data2 = Nothing
        Me.sbHibernate.FlashInterval = 500
        Me.sbHibernate.holdDraw = False
        Me.sbHibernate.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbHibernate.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbHibernate.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbHibernate.lblTextVisible = True
        Me.sbHibernate.Lit = True
        Me.sbHibernate.Location = New System.Drawing.Point(156, 135)
        Me.sbHibernate.Name = "sbHibernate"
        Me.sbHibernate.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHibernate.Size = New System.Drawing.Size(153, 36)
        Me.sbHibernate.TabIndex = 4
        Me.sbHibernate.Text = "HIBERNATE"
        '
        'sbExit
        '
        Me.sbExit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbExit.BackgroundImage = CType(resources.GetObject("sbExit.BackgroundImage"), System.Drawing.Image)
        Me.sbExit.Beeping = False
        Me.sbExit.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbExit.ButtonText = "CLOSE LCARS"
        Me.sbExit.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExit.ButtonTextHeight = 18
        Me.sbExit.Clickable = True
        Me.sbExit.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbExit.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbExit.Data = Nothing
        Me.sbExit.Data2 = Nothing
        Me.sbExit.FlashInterval = 500
        Me.sbExit.holdDraw = False
        Me.sbExit.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExit.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbExit.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbExit.lblTextVisible = True
        Me.sbExit.Lit = True
        Me.sbExit.Location = New System.Drawing.Point(331, 309)
        Me.sbExit.Name = "sbExit"
        Me.sbExit.RedAlert = LCARS.LCARSalert.Normal
        Me.sbExit.Size = New System.Drawing.Size(153, 36)
        Me.sbExit.TabIndex = 5
        Me.sbExit.Text = "CLOSE LCARS"
        '
        'sbExitMyComp
        '
        Me.sbExitMyComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExitMyComp.BackgroundImage = CType(resources.GetObject("sbExitMyComp.BackgroundImage"), System.Drawing.Image)
        Me.sbExitMyComp.Beeping = False
        Me.sbExitMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbExitMyComp.ButtonText = "X"
        Me.sbExitMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExitMyComp.ButtonTextHeight = 14
        Me.sbExitMyComp.Clickable = True
        Me.sbExitMyComp.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbExitMyComp.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbExitMyComp.Data = Nothing
        Me.sbExitMyComp.Data2 = Nothing
        Me.sbExitMyComp.FlashInterval = 500
        Me.sbExitMyComp.holdDraw = False
        Me.sbExitMyComp.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExitMyComp.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.sbExitMyComp.lblTextSize = New System.Drawing.Point(33, 32)
        Me.sbExitMyComp.lblTextVisible = True
        Me.sbExitMyComp.Lit = True
        Me.sbExitMyComp.Location = New System.Drawing.Point(605, 4)
        Me.sbExitMyComp.Name = "sbExitMyComp"
        Me.sbExitMyComp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbExitMyComp.Size = New System.Drawing.Size(33, 32)
        Me.sbExitMyComp.TabIndex = 57
        Me.sbExitMyComp.Text = "X"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.BackgroundImage = CType(resources.GetObject("tbTitle.BackgroundImage"), System.Drawing.Image)
        Me.tbTitle.Beeping = False
        Me.tbTitle.ButtonText = "DEACTIVATE"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.tbTitle.ButtonTextHeight = 32
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = True
        Me.tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.tbTitle.lblTextSize = New System.Drawing.Point(587, 29)
        Me.tbTitle.lblTextVisible = True
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(12, 4)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(587, 29)
        Me.tbTitle.TabIndex = 62
        Me.tbTitle.Text = "DEACTIVATE"
        '
        'sbLock
        '
        Me.sbLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbLock.BackgroundImage = CType(resources.GetObject("sbLock.BackgroundImage"), System.Drawing.Image)
        Me.sbLock.Beeping = False
        Me.sbLock.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbLock.ButtonText = "LOCK"
        Me.sbLock.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbLock.ButtonTextHeight = 18
        Me.sbLock.Clickable = True
        Me.sbLock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbLock.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbLock.Data = Nothing
        Me.sbLock.Data2 = Nothing
        Me.sbLock.FlashInterval = 500
        Me.sbLock.holdDraw = False
        Me.sbLock.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbLock.lblTextLoc = New System.Drawing.Point(18, 0)
        Me.sbLock.lblTextSize = New System.Drawing.Point(117, 36)
        Me.sbLock.lblTextVisible = True
        Me.sbLock.Lit = True
        Me.sbLock.Location = New System.Drawing.Point(156, 309)
        Me.sbLock.Name = "sbLock"
        Me.sbLock.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLock.Size = New System.Drawing.Size(153, 36)
        Me.sbLock.TabIndex = 63
        Me.sbLock.Text = "LOCK"
        '
        'frmShutdown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.sbLock)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.sbExitMyComp)
        Me.Controls.Add(Me.sbExit)
        Me.Controls.Add(Me.sbHibernate)
        Me.Controls.Add(Me.sbSuspend)
        Me.Controls.Add(Me.sbLogOff)
        Me.Controls.Add(Me.sbRestart)
        Me.Controls.Add(Me.sbShutdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShutdown"
        Me.Text = "DEACTIVATE"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbShutdown As LCARS.Controls.StandardButton
    Friend WithEvents sbRestart As LCARS.Controls.StandardButton
    Friend WithEvents sbLogOff As LCARS.Controls.StandardButton
    Friend WithEvents sbSuspend As LCARS.Controls.StandardButton
    Friend WithEvents sbHibernate As LCARS.Controls.StandardButton
    Friend WithEvents sbExit As LCARS.Controls.StandardButton
    Friend WithEvents sbExitMyComp As LCARS.Controls.StandardButton
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents sbLock As LCARS.Controls.StandardButton
End Class
