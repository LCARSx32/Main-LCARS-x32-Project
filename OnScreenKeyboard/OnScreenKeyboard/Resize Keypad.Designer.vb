<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Resize_Keypad
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
        Me.lblResizeTitle = New System.Windows.Forms.Label
        Me.sbIncrementMinus = New LCARS.Controls.StandardButton
        Me.sbIncrementPlus = New LCARS.Controls.StandardButton
        Me.lblIncrement = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.sbHeightMinus = New LCARS.Controls.StandardButton
        Me.sbHeightPlus = New LCARS.Controls.StandardButton
        Me.sbWidthMinus = New LCARS.Controls.StandardButton
        Me.sbWidthPlus = New LCARS.Controls.StandardButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.sbDone = New LCARS.Controls.StandardButton
        Me.sbMove = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'lblResizeTitle
        '
        Me.lblResizeTitle.AutoSize = True
        Me.lblResizeTitle.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResizeTitle.ForeColor = System.Drawing.Color.Orange
        Me.lblResizeTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblResizeTitle.Name = "lblResizeTitle"
        Me.lblResizeTitle.Size = New System.Drawing.Size(196, 54)
        Me.lblResizeTitle.TabIndex = 1
        Me.lblResizeTitle.Text = "RESIZE KEYPAD"
        '
        'sbIncrementMinus
        '
        Me.sbIncrementMinus.AutoEllipsis = False
        Me.sbIncrementMinus.Beeping = False
        Me.sbIncrementMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbIncrementMinus.ButtonText = "–"
        Me.sbIncrementMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbIncrementMinus.ButtonTextHeight = -1
        Me.sbIncrementMinus.Clickable = True
        Me.sbIncrementMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbIncrementMinus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbIncrementMinus.Data = Nothing
        Me.sbIncrementMinus.Data2 = Nothing
        Me.sbIncrementMinus.FlashInterval = 500
        Me.sbIncrementMinus.holdDraw = False
        Me.sbIncrementMinus.Lit = True
        Me.sbIncrementMinus.Location = New System.Drawing.Point(310, 103)
        Me.sbIncrementMinus.Name = "sbIncrementMinus"
        Me.sbIncrementMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbIncrementMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbIncrementMinus.TabIndex = 73
        Me.sbIncrementMinus.Text = "–"
        '
        'sbIncrementPlus
        '
        Me.sbIncrementPlus.AutoEllipsis = False
        Me.sbIncrementPlus.Beeping = False
        Me.sbIncrementPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbIncrementPlus.ButtonText = "+"
        Me.sbIncrementPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbIncrementPlus.ButtonTextHeight = -1
        Me.sbIncrementPlus.Clickable = True
        Me.sbIncrementPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbIncrementPlus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbIncrementPlus.Data = Nothing
        Me.sbIncrementPlus.Data2 = Nothing
        Me.sbIncrementPlus.FlashInterval = 500
        Me.sbIncrementPlus.holdDraw = False
        Me.sbIncrementPlus.Lit = True
        Me.sbIncrementPlus.Location = New System.Drawing.Point(370, 103)
        Me.sbIncrementPlus.Name = "sbIncrementPlus"
        Me.sbIncrementPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbIncrementPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbIncrementPlus.TabIndex = 72
        Me.sbIncrementPlus.Text = "+"
        '
        'lblIncrement
        '
        Me.lblIncrement.AutoSize = True
        Me.lblIncrement.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrement.ForeColor = System.Drawing.Color.Orange
        Me.lblIncrement.Location = New System.Drawing.Point(328, 70)
        Me.lblIncrement.Name = "lblIncrement"
        Me.lblIncrement.Size = New System.Drawing.Size(77, 30)
        Me.lblIncrement.TabIndex = 71
        Me.lblIncrement.Text = "20 PIXELS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(192, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 30)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "HEIGHT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(63, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 30)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "WIDTH"
        '
        'sbHeightMinus
        '
        Me.sbHeightMinus.AutoEllipsis = False
        Me.sbHeightMinus.Beeping = False
        Me.sbHeightMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbHeightMinus.ButtonText = "–"
        Me.sbHeightMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbHeightMinus.ButtonTextHeight = -1
        Me.sbHeightMinus.Clickable = True
        Me.sbHeightMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHeightMinus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbHeightMinus.Data = Nothing
        Me.sbHeightMinus.Data2 = Nothing
        Me.sbHeightMinus.FlashInterval = 500
        Me.sbHeightMinus.holdDraw = False
        Me.sbHeightMinus.Lit = True
        Me.sbHeightMinus.Location = New System.Drawing.Point(164, 103)
        Me.sbHeightMinus.Name = "sbHeightMinus"
        Me.sbHeightMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHeightMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbHeightMinus.TabIndex = 69
        Me.sbHeightMinus.Text = "–"
        '
        'sbHeightPlus
        '
        Me.sbHeightPlus.AutoEllipsis = False
        Me.sbHeightPlus.Beeping = False
        Me.sbHeightPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbHeightPlus.ButtonText = "+"
        Me.sbHeightPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbHeightPlus.ButtonTextHeight = -1
        Me.sbHeightPlus.Clickable = True
        Me.sbHeightPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHeightPlus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbHeightPlus.Data = Nothing
        Me.sbHeightPlus.Data2 = Nothing
        Me.sbHeightPlus.FlashInterval = 500
        Me.sbHeightPlus.holdDraw = False
        Me.sbHeightPlus.Lit = True
        Me.sbHeightPlus.Location = New System.Drawing.Point(229, 103)
        Me.sbHeightPlus.Name = "sbHeightPlus"
        Me.sbHeightPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHeightPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbHeightPlus.TabIndex = 68
        Me.sbHeightPlus.Text = "+"
        '
        'sbWidthMinus
        '
        Me.sbWidthMinus.AutoEllipsis = False
        Me.sbWidthMinus.Beeping = False
        Me.sbWidthMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbWidthMinus.ButtonText = "–"
        Me.sbWidthMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbWidthMinus.ButtonTextHeight = -1
        Me.sbWidthMinus.Clickable = True
        Me.sbWidthMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbWidthMinus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbWidthMinus.Data = Nothing
        Me.sbWidthMinus.Data2 = Nothing
        Me.sbWidthMinus.FlashInterval = 500
        Me.sbWidthMinus.holdDraw = False
        Me.sbWidthMinus.Lit = True
        Me.sbWidthMinus.Location = New System.Drawing.Point(38, 103)
        Me.sbWidthMinus.Name = "sbWidthMinus"
        Me.sbWidthMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbWidthMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbWidthMinus.TabIndex = 66
        Me.sbWidthMinus.Text = "–"
        '
        'sbWidthPlus
        '
        Me.sbWidthPlus.AutoEllipsis = False
        Me.sbWidthPlus.Beeping = False
        Me.sbWidthPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbWidthPlus.ButtonText = "+"
        Me.sbWidthPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbWidthPlus.ButtonTextHeight = -1
        Me.sbWidthPlus.Clickable = True
        Me.sbWidthPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbWidthPlus.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbWidthPlus.Data = Nothing
        Me.sbWidthPlus.Data2 = Nothing
        Me.sbWidthPlus.FlashInterval = 500
        Me.sbWidthPlus.holdDraw = False
        Me.sbWidthPlus.Lit = True
        Me.sbWidthPlus.Location = New System.Drawing.Point(95, 103)
        Me.sbWidthPlus.Name = "sbWidthPlus"
        Me.sbWidthPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbWidthPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbWidthPlus.TabIndex = 65
        Me.sbWidthPlus.Text = "+"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(305, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 30)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "INCREMENT BY:"
        '
        'sbDone
        '
        Me.sbDone.AutoEllipsis = False
        Me.sbDone.Beeping = False
        Me.sbDone.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbDone.ButtonText = "DONE"
        Me.sbDone.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDone.ButtonTextHeight = -1
        Me.sbDone.Clickable = True
        Me.sbDone.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbDone.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDone.Data = Nothing
        Me.sbDone.Data2 = Nothing
        Me.sbDone.Flash = True
        Me.sbDone.FlashInterval = 500
        Me.sbDone.holdDraw = False
        Me.sbDone.Lit = True
        Me.sbDone.Location = New System.Drawing.Point(301, 151)
        Me.sbDone.Name = "sbDone"
        Me.sbDone.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDone.Size = New System.Drawing.Size(112, 35)
        Me.sbDone.TabIndex = 75
        Me.sbDone.Text = "DONE"
        '
        'sbMove
        '
        Me.sbMove.AutoEllipsis = False
        Me.sbMove.Beeping = False
        Me.sbMove.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbMove.ButtonText = "MOVE RESIZE PAD"
        Me.sbMove.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbMove.ButtonTextHeight = -1
        Me.sbMove.Clickable = True
        Me.sbMove.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbMove.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbMove.Data = Nothing
        Me.sbMove.Data2 = Nothing
        Me.sbMove.FlashInterval = 500
        Me.sbMove.holdDraw = False
        Me.sbMove.Lit = True
        Me.sbMove.Location = New System.Drawing.Point(38, 151)
        Me.sbMove.Name = "sbMove"
        Me.sbMove.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMove.Size = New System.Drawing.Size(234, 35)
        Me.sbMove.TabIndex = 76
        Me.sbMove.Text = "MOVE RESIZE PAD"
        '
        'Resize_Keypad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(444, 198)
        Me.Controls.Add(Me.sbMove)
        Me.Controls.Add(Me.sbDone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.sbIncrementMinus)
        Me.Controls.Add(Me.sbIncrementPlus)
        Me.Controls.Add(Me.lblIncrement)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sbHeightMinus)
        Me.Controls.Add(Me.sbHeightPlus)
        Me.Controls.Add(Me.sbWidthMinus)
        Me.Controls.Add(Me.sbWidthPlus)
        Me.Controls.Add(Me.lblResizeTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Resize_Keypad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resize_Keypad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblResizeTitle As System.Windows.Forms.Label
    Friend WithEvents sbIncrementMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbIncrementPlus As LCARS.Controls.StandardButton
    Friend WithEvents lblIncrement As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sbHeightMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbHeightPlus As LCARS.Controls.StandardButton
    Friend WithEvents sbWidthMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbWidthPlus As LCARS.Controls.StandardButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sbDone As LCARS.Controls.StandardButton
    Friend WithEvents sbMove As LCARS.Controls.StandardButton
End Class
