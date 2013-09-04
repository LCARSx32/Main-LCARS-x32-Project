<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserButtons
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
        Me.lblFBTitle = New System.Windows.Forms.Label
        Me.sbDone = New LCARS.Controls.StandardButton
        Me.txtUBName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUBLoc = New System.Windows.Forms.TextBox
        Me.sbBrowse = New LCARS.Controls.StandardButton
        Me.sbMove = New LCARS.Controls.StandardButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblFBTitle
        '
        Me.lblFBTitle.AutoSize = True
        Me.lblFBTitle.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFBTitle.ForeColor = System.Drawing.Color.Orange
        Me.lblFBTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblFBTitle.Name = "lblFBTitle"
        Me.lblFBTitle.Size = New System.Drawing.Size(257, 54)
        Me.lblFBTitle.TabIndex = 2
        Me.lblFBTitle.Text = "FUNCTION BUTTONS"
        '
        'sbDone
        '
        Me.sbDone.AutoEllipsis = False
        Me.sbDone.Beeping = False
        Me.sbDone.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbDone.ButtonText = "OK"
        Me.sbDone.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDone.ButtonTextHeight = -1
        Me.sbDone.Clickable = True
        Me.sbDone.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbDone.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDone.Data = Nothing
        Me.sbDone.Data2 = Nothing
        Me.sbDone.FlashInterval = 500
        Me.sbDone.holdDraw = False
        Me.sbDone.Lit = True
        Me.sbDone.Location = New System.Drawing.Point(396, 12)
        Me.sbDone.Name = "sbDone"
        Me.sbDone.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDone.Size = New System.Drawing.Size(80, 24)
        Me.sbDone.TabIndex = 76
        Me.sbDone.Text = "OK"
        '
        'txtUBName
        '
        Me.txtUBName.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtUBName.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUBName.Location = New System.Drawing.Point(9, 79)
        Me.txtUBName.Name = "txtUBName"
        Me.txtUBName.Size = New System.Drawing.Size(463, 29)
        Me.txtUBName.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 21)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "TYPE FN BUTTON NAME BELOW:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 21)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "TYPE OR BROWSE TO COMMAND:"
        '
        'txtUBLoc
        '
        Me.txtUBLoc.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtUBLoc.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUBLoc.Location = New System.Drawing.Point(9, 143)
        Me.txtUBLoc.Name = "txtUBLoc"
        Me.txtUBLoc.Size = New System.Drawing.Size(359, 29)
        Me.txtUBLoc.TabIndex = 79
        '
        'sbBrowse
        '
        Me.sbBrowse.AutoEllipsis = False
        Me.sbBrowse.Beeping = False
        Me.sbBrowse.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbBrowse.ButtonText = "BROWSE"
        Me.sbBrowse.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbBrowse.ButtonTextHeight = -1
        Me.sbBrowse.Clickable = True
        Me.sbBrowse.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbBrowse.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbBrowse.Data = Nothing
        Me.sbBrowse.Data2 = Nothing
        Me.sbBrowse.FlashInterval = 500
        Me.sbBrowse.holdDraw = False
        Me.sbBrowse.Lit = True
        Me.sbBrowse.Location = New System.Drawing.Point(392, 148)
        Me.sbBrowse.Name = "sbBrowse"
        Me.sbBrowse.RedAlert = LCARS.LCARSalert.Normal
        Me.sbBrowse.Size = New System.Drawing.Size(80, 24)
        Me.sbBrowse.TabIndex = 81
        Me.sbBrowse.Text = "BROWSE"
        '
        'sbMove
        '
        Me.sbMove.AutoEllipsis = False
        Me.sbMove.Beeping = False
        Me.sbMove.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbMove.ButtonText = "MOVE"
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
        Me.sbMove.Location = New System.Drawing.Point(288, 12)
        Me.sbMove.Name = "sbMove"
        Me.sbMove.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMove.Size = New System.Drawing.Size(80, 24)
        Me.sbMove.TabIndex = 82
        Me.sbMove.Text = "MOVE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(5, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(427, 21)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Click 1 of the 12 Keyboard FN? Buttons to program it with above data then click O" & _
            "K to complete"
        '
        'UserButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(488, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.sbMove)
        Me.Controls.Add(Me.sbBrowse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUBLoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUBName)
        Me.Controls.Add(Me.sbDone)
        Me.Controls.Add(Me.lblFBTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UserButtons"
        Me.Text = "UserButtons"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFBTitle As System.Windows.Forms.Label
    Friend WithEvents sbDone As LCARS.Controls.StandardButton
    Friend WithEvents txtUBName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUBLoc As System.Windows.Forms.TextBox
    Friend WithEvents sbBrowse As LCARS.Controls.StandardButton
    Friend WithEvents sbMove As LCARS.Controls.StandardButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
