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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim LcarScolor1 As LCARS.LCARScolor = New LCARS.LCARScolor
        Dim LcarScolor2 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.FlatButton1 = New LCARS.Controls.FlatButton
        Me.Windowless = New LCARS.Controls.WindowlessContainer
        Me.myGrid = New LCARS.Controls.ButtonGrid
        Me.SuspendLayout()
        '
        'StandardButton1
        '
        Me.StandardButton1.BackgroundImage = CType(resources.GetObject("StandardButton1.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquareSlant
        Me.StandardButton1.ButtonText = "STANDARDBUTTON1"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.StandardButton1.ButtonTextHeight = 14
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.StandardButton1.ColorsAvailable = LcarScolor1
        Me.StandardButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.StandardButton1.lblTextLoc = New System.Drawing.Point(53, 0)
        Me.StandardButton1.lblTextSize = New System.Drawing.Size(107, 43)
        Me.StandardButton1.lblTextVisible = True
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(232, 12)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(213, 43)
        Me.StandardButton1.TabIndex = 2
        Me.StandardButton1.Text = "STANDARDBUTTON1"
        '
        'FlatButton1
        '
        Me.FlatButton1.BackgroundImage = CType(resources.GetObject("FlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.FlatButton1.Beeping = False
        Me.FlatButton1.ButtonText = "STANDARD"
        Me.FlatButton1.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FlatButton1.ButtonTextHeight = 14
        Me.FlatButton1.Clickable = True
        Me.FlatButton1.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.FlatButton1.ColorsAvailable = LcarScolor2
        Me.FlatButton1.CustomAlertColor = System.Drawing.Color.Empty
        Me.FlatButton1.Data = Nothing
        Me.FlatButton1.Data2 = Nothing
        Me.FlatButton1.FlashInterval = 500
        Me.FlatButton1.holdDraw = False
        Me.FlatButton1.lblTextAnchor = System.Windows.Forms.AnchorStyles.None
        Me.FlatButton1.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.FlatButton1.lblTextSize = New System.Drawing.Size(81, 25)
        Me.FlatButton1.lblTextVisible = True
        Me.FlatButton1.Lit = True
        Me.FlatButton1.Location = New System.Drawing.Point(13, 12)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.FlatButton1.Size = New System.Drawing.Size(81, 25)
        Me.FlatButton1.TabIndex = 1
        Me.FlatButton1.Text = "STANDARD"
        '
        'Windowless
        '
        Me.Windowless.Location = New System.Drawing.Point(12, 288)
        Me.Windowless.Name = "Windowless"
        Me.Windowless.Size = New System.Drawing.Size(757, 245)
        Me.Windowless.TabIndex = 3
        Me.Windowless.Text = "WindowlessContainer1"
        '
        'myGrid
        '
        Me.myGrid.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Vertical
        Me.myGrid.ControlPadding = 5
        Me.myGrid.ControlSize = New System.Drawing.Size(150, 40)
        Me.myGrid.CurrentPage = 1
        Me.myGrid.Location = New System.Drawing.Point(13, 60)
        Me.myGrid.MinimumSize = New System.Drawing.Size(155, 45)
        Me.myGrid.Name = "myGrid"
        Me.myGrid.Size = New System.Drawing.Size(756, 222)
        Me.myGrid.TabIndex = 4
        Me.myGrid.Text = "ButtonGrid1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(782, 545)
        Me.Controls.Add(Me.myGrid)
        Me.Controls.Add(Me.Windowless)
        Me.Controls.Add(Me.StandardButton1)
        Me.Controls.Add(Me.FlatButton1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LcarsCalender1 As LCARS.Controls.LCARSCalender
    Friend WithEvents FlatButton1 As LCARS.Controls.FlatButton
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents Windowless As LCARS.Controls.WindowlessContainer
    Friend WithEvents myGrid As LCARS.Controls.ButtonGrid

End Class
