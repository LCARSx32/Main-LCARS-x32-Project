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
        Me.elbTop = New LCARS.Controls.Elbow
        Me.elbBottom = New LCARS.Controls.Elbow
        Me.sbUp = New LCARS.Controls.FlatButton
        Me.fbExt = New LCARS.Controls.FlatButton
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.sbCancel = New LCARS.Controls.StandardButton
        Me.lblCurrentSelected = New System.Windows.Forms.Label
        Me.hpLocation = New LCARS.Controls.HalfPillButton
        Me.hpPrompt = New LCARS.Controls.HalfPillButton
        Me.gridMyComp = New LCARS.Controls.ButtonGrid
        Me.SuspendLayout()
        '
        'elbTop
        '
        Me.elbTop.ButtonText = ""
        Me.elbTop.ButtonWidth = 100
        Me.elbTop.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbTop.Location = New System.Drawing.Point(12, 12)
        Me.elbTop.Name = "elbTop"
        Me.elbTop.Size = New System.Drawing.Size(141, 44)
        Me.elbTop.TabIndex = 0
        '
        'elbBottom
        '
        Me.elbBottom.ButtonText = ""
        Me.elbBottom.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.elbBottom.ButtonWidth = 100
        Me.elbBottom.Clickable = False
        Me.elbBottom.Color = LCARS.LCARScolorStyles.StaticTan
        Me.elbBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbBottom.Location = New System.Drawing.Point(12, 441)
        Me.elbBottom.Name = "elbBottom"
        Me.elbBottom.Size = New System.Drawing.Size(141, 44)
        Me.elbBottom.TabIndex = 1
        '
        'sbUp
        '
        Me.sbUp.ButtonText = "UP A DIRECTORY"
        Me.sbUp.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbUp.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbUp.Lit = False
        Me.sbUp.Location = New System.Drawing.Point(12, 62)
        Me.sbUp.Name = "sbUp"
        Me.sbUp.Size = New System.Drawing.Size(100, 25)
        Me.sbUp.TabIndex = 2
        Me.sbUp.Text = "UP A DIRECTORY"
        '
        'fbExt
        '
        Me.fbExt.ButtonText = ""
        Me.fbExt.Clickable = False
        Me.fbExt.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbExt.Location = New System.Drawing.Point(12, 94)
        Me.fbExt.Name = "fbExt"
        Me.fbExt.Size = New System.Drawing.Size(100, 341)
        Me.fbExt.TabIndex = 3
        '
        'sbOK
        '
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbOK.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.sbOK.Location = New System.Drawing.Point(420, 421)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.Size = New System.Drawing.Size(74, 28)
        Me.sbOK.TabIndex = 5
        Me.sbOK.Text = "OK"
        '
        'sbCancel
        '
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCancel.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(328, 421)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(74, 28)
        Me.sbCancel.TabIndex = 5
        Me.sbCancel.Text = "CANCEL"
        '
        'lblCurrentSelected
        '
        Me.lblCurrentSelected.AutoSize = True
        Me.lblCurrentSelected.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentSelected.ForeColor = System.Drawing.Color.Orange
        Me.lblCurrentSelected.Location = New System.Drawing.Point(129, 414)
        Me.lblCurrentSelected.Name = "lblCurrentSelected"
        Me.lblCurrentSelected.Size = New System.Drawing.Size(70, 24)
        Me.lblCurrentSelected.TabIndex = 6
        Me.lblCurrentSelected.Text = "Current File"
        '
        'hpLocation
        '
        Me.hpLocation.ButtonText = "C:\"
        Me.hpLocation.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hpLocation.Clickable = False
        Me.hpLocation.Color = LCARS.LCARScolorStyles.StaticTan
        Me.hpLocation.Location = New System.Drawing.Point(159, 12)
        Me.hpLocation.Name = "hpLocation"
        Me.hpLocation.Size = New System.Drawing.Size(334, 25)
        Me.hpLocation.TabIndex = 7
        Me.hpLocation.Text = "C:\"
        '
        'hpPrompt
        '
        Me.hpPrompt.ButtonText = ""
        Me.hpPrompt.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hpPrompt.Clickable = False
        Me.hpPrompt.Color = LCARS.LCARScolorStyles.StaticTan
        Me.hpPrompt.Location = New System.Drawing.Point(159, 460)
        Me.hpPrompt.Name = "hpPrompt"
        Me.hpPrompt.Size = New System.Drawing.Size(334, 25)
        Me.hpPrompt.TabIndex = 7
        '
        'gridMyComp
        '
        Me.gridMyComp.Location = New System.Drawing.Point(118, 43)
        Me.gridMyComp.MinimumSize = New System.Drawing.Size(50, 50)
        Me.gridMyComp.Name = "gridMyComp"
        Me.gridMyComp.Size = New System.Drawing.Size(376, 368)
        Me.gridMyComp.TabIndex = 8
        Me.gridMyComp.Text = "ButtonGrid1"
        '
        'frmFileSelect
        '
        Me.AcceptButton = Me.sbOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(505, 497)
        Me.Controls.Add(Me.gridMyComp)
        Me.Controls.Add(Me.hpPrompt)
        Me.Controls.Add(Me.hpLocation)
        Me.Controls.Add(Me.lblCurrentSelected)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.fbExt)
        Me.Controls.Add(Me.sbUp)
        Me.Controls.Add(Me.elbBottom)
        Me.Controls.Add(Me.elbTop)
        Me.ForeColor = System.Drawing.Color.OrangeRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFileSelect"
        Me.Text = "frmFileSelect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elbTop As LCARS.Controls.Elbow
    Friend WithEvents elbBottom As LCARS.Controls.Elbow
    Friend WithEvents sbUp As LCARS.Controls.FlatButton
    Friend WithEvents fbExt As LCARS.Controls.FlatButton
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents hpLocation As LCARS.Controls.HalfPillButton
    Friend WithEvents hpPrompt As LCARS.Controls.HalfPillButton
    Friend WithEvents gridMyComp As LCARS.Controls.ButtonGrid
    Private WithEvents lblCurrentSelected As System.Windows.Forms.Label
End Class
