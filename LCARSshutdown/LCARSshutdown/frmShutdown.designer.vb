<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShutdown
    Inherits LCARS.LCARSForm

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
        Me.sbShutdown.ButtonText = "SHUT DOWN"
        Me.sbShutdown.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbShutdown.ButtonTextHeight = 18
        Me.sbShutdown.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbShutdown.Location = New System.Drawing.Point(331, 219)
        Me.sbShutdown.Name = "sbShutdown"
        Me.sbShutdown.Size = New System.Drawing.Size(153, 36)
        Me.sbShutdown.TabIndex = 0
        Me.sbShutdown.Text = "SHUT DOWN"
        '
        'sbRestart
        '
        Me.sbRestart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbRestart.ButtonText = "RESTART"
        Me.sbRestart.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbRestart.ButtonTextHeight = 18
        Me.sbRestart.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbRestart.Location = New System.Drawing.Point(331, 177)
        Me.sbRestart.Name = "sbRestart"
        Me.sbRestart.Size = New System.Drawing.Size(153, 36)
        Me.sbRestart.TabIndex = 1
        Me.sbRestart.Text = "RESTART"
        '
        'sbLogOff
        '
        Me.sbLogOff.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbLogOff.ButtonText = "LOG OFF"
        Me.sbLogOff.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbLogOff.ButtonTextHeight = 18
        Me.sbLogOff.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbLogOff.Location = New System.Drawing.Point(331, 135)
        Me.sbLogOff.Name = "sbLogOff"
        Me.sbLogOff.Size = New System.Drawing.Size(153, 36)
        Me.sbLogOff.TabIndex = 2
        Me.sbLogOff.Text = "LOG OFF"
        '
        'sbSuspend
        '
        Me.sbSuspend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbSuspend.ButtonText = "SUSPEND"
        Me.sbSuspend.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSuspend.ButtonTextHeight = 18
        Me.sbSuspend.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbSuspend.Location = New System.Drawing.Point(156, 177)
        Me.sbSuspend.Name = "sbSuspend"
        Me.sbSuspend.Size = New System.Drawing.Size(153, 36)
        Me.sbSuspend.TabIndex = 3
        Me.sbSuspend.Text = "SUSPEND"
        '
        'sbHibernate
        '
        Me.sbHibernate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbHibernate.ButtonText = "HIBERNATE"
        Me.sbHibernate.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbHibernate.ButtonTextHeight = 18
        Me.sbHibernate.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHibernate.Location = New System.Drawing.Point(156, 135)
        Me.sbHibernate.Name = "sbHibernate"
        Me.sbHibernate.Size = New System.Drawing.Size(153, 36)
        Me.sbHibernate.TabIndex = 4
        Me.sbHibernate.Text = "HIBERNATE"
        '
        'sbExit
        '
        Me.sbExit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbExit.ButtonText = "CLOSE LCARS"
        Me.sbExit.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExit.ButtonTextHeight = 18
        Me.sbExit.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbExit.Location = New System.Drawing.Point(331, 309)
        Me.sbExit.Name = "sbExit"
        Me.sbExit.Size = New System.Drawing.Size(153, 36)
        Me.sbExit.TabIndex = 5
        Me.sbExit.Text = "CLOSE LCARS"
        '
        'sbExitMyComp
        '
        Me.sbExitMyComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExitMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbExitMyComp.ButtonText = "X"
        Me.sbExitMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExitMyComp.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbExitMyComp.Location = New System.Drawing.Point(605, 4)
        Me.sbExitMyComp.Name = "sbExitMyComp"
        Me.sbExitMyComp.Size = New System.Drawing.Size(33, 32)
        Me.sbExitMyComp.TabIndex = 57
        Me.sbExitMyComp.Text = "X"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.ButtonText = "DEACTIVATE"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.tbTitle.ButtonTextHeight = 32
        Me.tbTitle.Clickable = False
        Me.tbTitle.Location = New System.Drawing.Point(12, 4)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(587, 32)
        Me.tbTitle.TabIndex = 62
        Me.tbTitle.Text = "DEACTIVATE"
        '
        'sbLock
        '
        Me.sbLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sbLock.ButtonText = "LOCK"
        Me.sbLock.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbLock.ButtonTextHeight = 18
        Me.sbLock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbLock.Location = New System.Drawing.Point(156, 309)
        Me.sbLock.Name = "sbLock"
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
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
