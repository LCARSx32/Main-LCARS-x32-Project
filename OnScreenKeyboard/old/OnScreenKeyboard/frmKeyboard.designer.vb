<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeyboard))
        Me.pnlKeyboard = New System.Windows.Forms.Panel
        Me.pnlResize = New System.Windows.Forms.Panel
        Me.sbIncrementMinus = New LCARS.Controls.StandardButton
        Me.sbIncrementPlus = New LCARS.Controls.StandardButton
        Me.lblIncrement = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.sbHeightMinus = New LCARS.Controls.StandardButton
        Me.sbHeightPlus = New LCARS.Controls.StandardButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.sbWidthMinus = New LCARS.Controls.StandardButton
        Me.sbWidthPlus = New LCARS.Controls.StandardButton
        Me.lblResizeTitle = New System.Windows.Forms.Label
        Me.sbF8 = New LCARS.Controls.StandardButton
        Me.sbF7 = New LCARS.Controls.StandardButton
        Me.sbF6 = New LCARS.Controls.StandardButton
        Me.sbF9 = New LCARS.Controls.StandardButton
        Me.sbF10 = New LCARS.Controls.StandardButton
        Me.sbF11 = New LCARS.Controls.StandardButton
        Me.sbF12 = New LCARS.Controls.StandardButton
        Me.sbF4 = New LCARS.Controls.StandardButton
        Me.sbF5 = New LCARS.Controls.StandardButton
        Me.sbF3 = New LCARS.Controls.StandardButton
        Me.sbF2 = New LCARS.Controls.StandardButton
        Me.sbF1 = New LCARS.Controls.StandardButton
        Me.sbDEL = New LCARS.Controls.StandardButton
        Me.sbESC = New LCARS.Controls.StandardButton
        Me.abLeft = New LCARS.Controls.ArrowButton
        Me.abRight = New LCARS.Controls.ArrowButton
        Me.abDown = New LCARS.Controls.ArrowButton
        Me.abUp = New LCARS.Controls.ArrowButton
        Me.sbSpace = New LCARS.Controls.StandardButton
        Me.sbRAlt = New LCARS.Controls.StandardButton
        Me.sbRwin = New LCARS.Controls.StandardButton
        Me.sbRCtrl = New LCARS.Controls.StandardButton
        Me.sbLAlt = New LCARS.Controls.StandardButton
        Me.sbLWin = New LCARS.Controls.StandardButton
        Me.sbLCtrl = New LCARS.Controls.StandardButton
        Me.sbLShift = New LCARS.Controls.StandardButton
        Me.sbComma = New LCARS.Controls.StandardButton
        Me.sbM = New LCARS.Controls.StandardButton
        Me.sbN = New LCARS.Controls.StandardButton
        Me.sbPeriod = New LCARS.Controls.StandardButton
        Me.sbForwardSlash = New LCARS.Controls.StandardButton
        Me.sbV = New LCARS.Controls.StandardButton
        Me.sbB = New LCARS.Controls.StandardButton
        Me.sbRShift = New LCARS.Controls.StandardButton
        Me.sbC = New LCARS.Controls.StandardButton
        Me.sbX = New LCARS.Controls.StandardButton
        Me.sbZ = New LCARS.Controls.StandardButton
        Me.sbCaps = New LCARS.Controls.StandardButton
        Me.sbK = New LCARS.Controls.StandardButton
        Me.sbJ = New LCARS.Controls.StandardButton
        Me.sbH = New LCARS.Controls.StandardButton
        Me.sbL = New LCARS.Controls.StandardButton
        Me.sbSemiColon = New LCARS.Controls.StandardButton
        Me.sbQuote = New LCARS.Controls.StandardButton
        Me.sbF = New LCARS.Controls.StandardButton
        Me.sbG = New LCARS.Controls.StandardButton
        Me.sbEnter = New LCARS.Controls.StandardButton
        Me.sbD = New LCARS.Controls.StandardButton
        Me.sbS = New LCARS.Controls.StandardButton
        Me.sbA = New LCARS.Controls.StandardButton
        Me.sbTilde = New LCARS.Controls.StandardButton
        Me.sb8 = New LCARS.Controls.StandardButton
        Me.sb7 = New LCARS.Controls.StandardButton
        Me.sb6 = New LCARS.Controls.StandardButton
        Me.sb9 = New LCARS.Controls.StandardButton
        Me.sb0 = New LCARS.Controls.StandardButton
        Me.sbMinus = New LCARS.Controls.StandardButton
        Me.sbEqual = New LCARS.Controls.StandardButton
        Me.sb4 = New LCARS.Controls.StandardButton
        Me.sb5 = New LCARS.Controls.StandardButton
        Me.sbBack = New LCARS.Controls.StandardButton
        Me.sb3 = New LCARS.Controls.StandardButton
        Me.sb2 = New LCARS.Controls.StandardButton
        Me.sb1 = New LCARS.Controls.StandardButton
        Me.sbTab = New LCARS.Controls.StandardButton
        Me.sbI = New LCARS.Controls.StandardButton
        Me.sbU = New LCARS.Controls.StandardButton
        Me.sbY = New LCARS.Controls.StandardButton
        Me.sbO = New LCARS.Controls.StandardButton
        Me.sbP = New LCARS.Controls.StandardButton
        Me.sbLBracket = New LCARS.Controls.StandardButton
        Me.sbRBracket = New LCARS.Controls.StandardButton
        Me.sbR = New LCARS.Controls.StandardButton
        Me.sbT = New LCARS.Controls.StandardButton
        Me.sbBackSlash = New LCARS.Controls.StandardButton
        Me.sbE = New LCARS.Controls.StandardButton
        Me.sbW = New LCARS.Controls.StandardButton
        Me.sbQ = New LCARS.Controls.StandardButton
        Me.sbTitle = New LCARS.Controls.StandardButton
        Me.StandardButton1 = New LCARS.Controls.StandardButton
        Me.sbChangeSize = New LCARS.Controls.StandardButton
        Me.sbDone = New LCARS.Controls.StandardButton
        Me.pnlKeyboard.SuspendLayout()
        Me.pnlResize.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlKeyboard
        '
        Me.pnlKeyboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKeyboard.BackColor = System.Drawing.Color.Black
        Me.pnlKeyboard.Controls.Add(Me.sbF8)
        Me.pnlKeyboard.Controls.Add(Me.sbF7)
        Me.pnlKeyboard.Controls.Add(Me.sbF6)
        Me.pnlKeyboard.Controls.Add(Me.sbF9)
        Me.pnlKeyboard.Controls.Add(Me.sbF10)
        Me.pnlKeyboard.Controls.Add(Me.sbF11)
        Me.pnlKeyboard.Controls.Add(Me.sbF12)
        Me.pnlKeyboard.Controls.Add(Me.sbF4)
        Me.pnlKeyboard.Controls.Add(Me.sbF5)
        Me.pnlKeyboard.Controls.Add(Me.sbF3)
        Me.pnlKeyboard.Controls.Add(Me.sbF2)
        Me.pnlKeyboard.Controls.Add(Me.sbF1)
        Me.pnlKeyboard.Controls.Add(Me.sbDEL)
        Me.pnlKeyboard.Controls.Add(Me.sbESC)
        Me.pnlKeyboard.Controls.Add(Me.abLeft)
        Me.pnlKeyboard.Controls.Add(Me.abRight)
        Me.pnlKeyboard.Controls.Add(Me.abDown)
        Me.pnlKeyboard.Controls.Add(Me.abUp)
        Me.pnlKeyboard.Controls.Add(Me.sbSpace)
        Me.pnlKeyboard.Controls.Add(Me.sbRAlt)
        Me.pnlKeyboard.Controls.Add(Me.sbRwin)
        Me.pnlKeyboard.Controls.Add(Me.sbRCtrl)
        Me.pnlKeyboard.Controls.Add(Me.sbLAlt)
        Me.pnlKeyboard.Controls.Add(Me.sbLWin)
        Me.pnlKeyboard.Controls.Add(Me.sbLCtrl)
        Me.pnlKeyboard.Controls.Add(Me.sbLShift)
        Me.pnlKeyboard.Controls.Add(Me.sbComma)
        Me.pnlKeyboard.Controls.Add(Me.sbM)
        Me.pnlKeyboard.Controls.Add(Me.sbN)
        Me.pnlKeyboard.Controls.Add(Me.sbPeriod)
        Me.pnlKeyboard.Controls.Add(Me.sbForwardSlash)
        Me.pnlKeyboard.Controls.Add(Me.sbV)
        Me.pnlKeyboard.Controls.Add(Me.sbB)
        Me.pnlKeyboard.Controls.Add(Me.sbRShift)
        Me.pnlKeyboard.Controls.Add(Me.sbC)
        Me.pnlKeyboard.Controls.Add(Me.sbX)
        Me.pnlKeyboard.Controls.Add(Me.sbZ)
        Me.pnlKeyboard.Controls.Add(Me.sbCaps)
        Me.pnlKeyboard.Controls.Add(Me.sbK)
        Me.pnlKeyboard.Controls.Add(Me.sbJ)
        Me.pnlKeyboard.Controls.Add(Me.sbH)
        Me.pnlKeyboard.Controls.Add(Me.sbL)
        Me.pnlKeyboard.Controls.Add(Me.sbSemiColon)
        Me.pnlKeyboard.Controls.Add(Me.sbQuote)
        Me.pnlKeyboard.Controls.Add(Me.sbF)
        Me.pnlKeyboard.Controls.Add(Me.sbG)
        Me.pnlKeyboard.Controls.Add(Me.sbEnter)
        Me.pnlKeyboard.Controls.Add(Me.sbD)
        Me.pnlKeyboard.Controls.Add(Me.sbS)
        Me.pnlKeyboard.Controls.Add(Me.sbA)
        Me.pnlKeyboard.Controls.Add(Me.sbTilde)
        Me.pnlKeyboard.Controls.Add(Me.sb8)
        Me.pnlKeyboard.Controls.Add(Me.sb7)
        Me.pnlKeyboard.Controls.Add(Me.sb6)
        Me.pnlKeyboard.Controls.Add(Me.sb9)
        Me.pnlKeyboard.Controls.Add(Me.sb0)
        Me.pnlKeyboard.Controls.Add(Me.sbMinus)
        Me.pnlKeyboard.Controls.Add(Me.sbEqual)
        Me.pnlKeyboard.Controls.Add(Me.sb4)
        Me.pnlKeyboard.Controls.Add(Me.sb5)
        Me.pnlKeyboard.Controls.Add(Me.sbBack)
        Me.pnlKeyboard.Controls.Add(Me.sb3)
        Me.pnlKeyboard.Controls.Add(Me.sb2)
        Me.pnlKeyboard.Controls.Add(Me.sb1)
        Me.pnlKeyboard.Controls.Add(Me.sbTab)
        Me.pnlKeyboard.Controls.Add(Me.sbI)
        Me.pnlKeyboard.Controls.Add(Me.sbU)
        Me.pnlKeyboard.Controls.Add(Me.sbY)
        Me.pnlKeyboard.Controls.Add(Me.sbO)
        Me.pnlKeyboard.Controls.Add(Me.sbP)
        Me.pnlKeyboard.Controls.Add(Me.sbLBracket)
        Me.pnlKeyboard.Controls.Add(Me.sbRBracket)
        Me.pnlKeyboard.Controls.Add(Me.sbR)
        Me.pnlKeyboard.Controls.Add(Me.sbT)
        Me.pnlKeyboard.Controls.Add(Me.sbBackSlash)
        Me.pnlKeyboard.Controls.Add(Me.sbE)
        Me.pnlKeyboard.Controls.Add(Me.sbW)
        Me.pnlKeyboard.Controls.Add(Me.sbQ)
        Me.pnlKeyboard.Location = New System.Drawing.Point(7, 45)
        Me.pnlKeyboard.Name = "pnlKeyboard"
        Me.pnlKeyboard.Size = New System.Drawing.Size(1020, 413)
        Me.pnlKeyboard.TabIndex = 52
        '
        'pnlResize
        '
        Me.pnlResize.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlResize.Controls.Add(Me.sbDone)
        Me.pnlResize.Controls.Add(Me.sbIncrementMinus)
        Me.pnlResize.Controls.Add(Me.sbIncrementPlus)
        Me.pnlResize.Controls.Add(Me.lblIncrement)
        Me.pnlResize.Controls.Add(Me.Label3)
        Me.pnlResize.Controls.Add(Me.Label2)
        Me.pnlResize.Controls.Add(Me.sbHeightMinus)
        Me.pnlResize.Controls.Add(Me.sbHeightPlus)
        Me.pnlResize.Controls.Add(Me.Label1)
        Me.pnlResize.Controls.Add(Me.sbWidthMinus)
        Me.pnlResize.Controls.Add(Me.sbWidthPlus)
        Me.pnlResize.Controls.Add(Me.lblResizeTitle)
        Me.pnlResize.Location = New System.Drawing.Point(305, 131)
        Me.pnlResize.Name = "pnlResize"
        Me.pnlResize.Size = New System.Drawing.Size(425, 203)
        Me.pnlResize.TabIndex = 95
        Me.pnlResize.Visible = False
        '
        'sbIncrementMinus
        '
        Me.sbIncrementMinus.AutoEllipsis = False
        Me.sbIncrementMinus.BackgroundImage = CType(resources.GetObject("sbIncrementMinus.BackgroundImage"), System.Drawing.Image)
        Me.sbIncrementMinus.Beeping = False
        Me.sbIncrementMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbIncrementMinus.ButtonText = "–"
        Me.sbIncrementMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbIncrementMinus.ButtonTextHeight = -1
        Me.sbIncrementMinus.Clickable = True
        Me.sbIncrementMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbIncrementMinus.Data = Nothing
        Me.sbIncrementMinus.Data2 = Nothing
        Me.sbIncrementMinus.FlashInterval = 500
        Me.sbIncrementMinus.holdDraw = False
        Me.sbIncrementMinus.Lit = True
        Me.sbIncrementMinus.Location = New System.Drawing.Point(312, 95)
        Me.sbIncrementMinus.Name = "sbIncrementMinus"
        Me.sbIncrementMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbIncrementMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbIncrementMinus.TabIndex = 64
        '
        'sbIncrementPlus
        '
        Me.sbIncrementPlus.AutoEllipsis = False
        Me.sbIncrementPlus.BackgroundImage = CType(resources.GetObject("sbIncrementPlus.BackgroundImage"), System.Drawing.Image)
        Me.sbIncrementPlus.Beeping = False
        Me.sbIncrementPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbIncrementPlus.ButtonText = "+"
        Me.sbIncrementPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbIncrementPlus.ButtonTextHeight = -1
        Me.sbIncrementPlus.Clickable = True
        Me.sbIncrementPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbIncrementPlus.Data = Nothing
        Me.sbIncrementPlus.Data2 = Nothing
        Me.sbIncrementPlus.FlashInterval = 500
        Me.sbIncrementPlus.holdDraw = False
        Me.sbIncrementPlus.Lit = True
        Me.sbIncrementPlus.Location = New System.Drawing.Point(372, 95)
        Me.sbIncrementPlus.Name = "sbIncrementPlus"
        Me.sbIncrementPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbIncrementPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbIncrementPlus.TabIndex = 63
        '
        'lblIncrement
        '
        Me.lblIncrement.AutoSize = True
        Me.lblIncrement.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrement.ForeColor = System.Drawing.Color.Orange
        Me.lblIncrement.Location = New System.Drawing.Point(330, 62)
        Me.lblIncrement.Name = "lblIncrement"
        Me.lblIncrement.Size = New System.Drawing.Size(77, 30)
        Me.lblIncrement.TabIndex = 62
        Me.lblIncrement.Text = "20 PIXELS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(307, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 30)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "INCREMENT BY:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(187, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 30)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "HEIGHT"
        '
        'sbHeightMinus
        '
        Me.sbHeightMinus.AutoEllipsis = False
        Me.sbHeightMinus.BackgroundImage = CType(resources.GetObject("sbHeightMinus.BackgroundImage"), System.Drawing.Image)
        Me.sbHeightMinus.Beeping = False
        Me.sbHeightMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbHeightMinus.ButtonText = "–"
        Me.sbHeightMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbHeightMinus.ButtonTextHeight = -1
        Me.sbHeightMinus.Clickable = True
        Me.sbHeightMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHeightMinus.Data = Nothing
        Me.sbHeightMinus.Data2 = Nothing
        Me.sbHeightMinus.FlashInterval = 500
        Me.sbHeightMinus.holdDraw = False
        Me.sbHeightMinus.Lit = True
        Me.sbHeightMinus.Location = New System.Drawing.Point(159, 95)
        Me.sbHeightMinus.Name = "sbHeightMinus"
        Me.sbHeightMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHeightMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbHeightMinus.TabIndex = 59
        '
        'sbHeightPlus
        '
        Me.sbHeightPlus.AutoEllipsis = False
        Me.sbHeightPlus.BackgroundImage = CType(resources.GetObject("sbHeightPlus.BackgroundImage"), System.Drawing.Image)
        Me.sbHeightPlus.Beeping = False
        Me.sbHeightPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbHeightPlus.ButtonText = "+"
        Me.sbHeightPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbHeightPlus.ButtonTextHeight = -1
        Me.sbHeightPlus.Clickable = True
        Me.sbHeightPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbHeightPlus.Data = Nothing
        Me.sbHeightPlus.Data2 = Nothing
        Me.sbHeightPlus.FlashInterval = 500
        Me.sbHeightPlus.holdDraw = False
        Me.sbHeightPlus.Lit = True
        Me.sbHeightPlus.Location = New System.Drawing.Point(224, 95)
        Me.sbHeightPlus.Name = "sbHeightPlus"
        Me.sbHeightPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbHeightPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbHeightPlus.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(34, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 30)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "WIDTH"
        '
        'sbWidthMinus
        '
        Me.sbWidthMinus.AutoEllipsis = False
        Me.sbWidthMinus.BackgroundImage = CType(resources.GetObject("sbWidthMinus.BackgroundImage"), System.Drawing.Image)
        Me.sbWidthMinus.Beeping = False
        Me.sbWidthMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbWidthMinus.ButtonText = "–"
        Me.sbWidthMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbWidthMinus.ButtonTextHeight = -1
        Me.sbWidthMinus.Clickable = True
        Me.sbWidthMinus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbWidthMinus.Data = Nothing
        Me.sbWidthMinus.Data2 = Nothing
        Me.sbWidthMinus.FlashInterval = 500
        Me.sbWidthMinus.holdDraw = False
        Me.sbWidthMinus.Lit = True
        Me.sbWidthMinus.Location = New System.Drawing.Point(9, 95)
        Me.sbWidthMinus.Name = "sbWidthMinus"
        Me.sbWidthMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbWidthMinus.Size = New System.Drawing.Size(43, 35)
        Me.sbWidthMinus.TabIndex = 56
        '
        'sbWidthPlus
        '
        Me.sbWidthPlus.AutoEllipsis = False
        Me.sbWidthPlus.BackgroundImage = CType(resources.GetObject("sbWidthPlus.BackgroundImage"), System.Drawing.Image)
        Me.sbWidthPlus.Beeping = False
        Me.sbWidthPlus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbWidthPlus.ButtonText = "+"
        Me.sbWidthPlus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbWidthPlus.ButtonTextHeight = -1
        Me.sbWidthPlus.Clickable = True
        Me.sbWidthPlus.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbWidthPlus.Data = Nothing
        Me.sbWidthPlus.Data2 = Nothing
        Me.sbWidthPlus.FlashInterval = 500
        Me.sbWidthPlus.holdDraw = False
        Me.sbWidthPlus.Lit = True
        Me.sbWidthPlus.Location = New System.Drawing.Point(70, 95)
        Me.sbWidthPlus.Name = "sbWidthPlus"
        Me.sbWidthPlus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbWidthPlus.Size = New System.Drawing.Size(43, 35)
        Me.sbWidthPlus.TabIndex = 55
        '
        'lblResizeTitle
        '
        Me.lblResizeTitle.AutoSize = True
        Me.lblResizeTitle.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResizeTitle.ForeColor = System.Drawing.Color.Orange
        Me.lblResizeTitle.Location = New System.Drawing.Point(0, 1)
        Me.lblResizeTitle.Name = "lblResizeTitle"
        Me.lblResizeTitle.Size = New System.Drawing.Size(196, 54)
        Me.lblResizeTitle.TabIndex = 0
        Me.lblResizeTitle.Text = "RESIZE KEYPAD"
        '
        'sbF8
        '
        Me.sbF8._ForceCaps = False
        Me.sbF8.AutoEllipsis = False
        Me.sbF8.BackgroundImage = CType(resources.GetObject("sbF8.BackgroundImage"), System.Drawing.Image)
        Me.sbF8.Beeping = False
        Me.sbF8.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF8.ButtonText = "F8"
        Me.sbF8.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF8.ButtonTextHeight = -1
        Me.sbF8.Clickable = True
        Me.sbF8.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF8.Data = "F8"
        Me.sbF8.Data2 = "F8"
        Me.sbF8.FlashInterval = 500
        Me.sbF8.holdDraw = False
        Me.sbF8.Lit = True
        Me.sbF8.Location = New System.Drawing.Point(624, 0)
        Me.sbF8.Name = "sbF8"
        Me.sbF8.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF8.Size = New System.Drawing.Size(64, 48)
        Me.sbF8.TabIndex = 94
        Me.sbF8.Tag = "8"
        '
        'sbF7
        '
        Me.sbF7._ForceCaps = False
        Me.sbF7.AutoEllipsis = False
        Me.sbF7.BackgroundImage = CType(resources.GetObject("sbF7.BackgroundImage"), System.Drawing.Image)
        Me.sbF7.Beeping = False
        Me.sbF7.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF7.ButtonText = "F7"
        Me.sbF7.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF7.ButtonTextHeight = -1
        Me.sbF7.Clickable = True
        Me.sbF7.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF7.Data = "F7"
        Me.sbF7.Data2 = "F7"
        Me.sbF7.FlashInterval = 500
        Me.sbF7.holdDraw = False
        Me.sbF7.Lit = True
        Me.sbF7.Location = New System.Drawing.Point(556, 0)
        Me.sbF7.Name = "sbF7"
        Me.sbF7.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF7.Size = New System.Drawing.Size(64, 48)
        Me.sbF7.TabIndex = 93
        Me.sbF7.Tag = "7"
        '
        'sbF6
        '
        Me.sbF6._ForceCaps = False
        Me.sbF6.AutoEllipsis = False
        Me.sbF6.BackgroundImage = CType(resources.GetObject("sbF6.BackgroundImage"), System.Drawing.Image)
        Me.sbF6.Beeping = False
        Me.sbF6.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF6.ButtonText = "F6"
        Me.sbF6.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF6.ButtonTextHeight = -1
        Me.sbF6.Clickable = True
        Me.sbF6.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF6.Data = "F6"
        Me.sbF6.Data2 = "F6"
        Me.sbF6.FlashInterval = 500
        Me.sbF6.holdDraw = False
        Me.sbF6.Lit = True
        Me.sbF6.Location = New System.Drawing.Point(486, 0)
        Me.sbF6.Name = "sbF6"
        Me.sbF6.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF6.Size = New System.Drawing.Size(64, 48)
        Me.sbF6.TabIndex = 92
        Me.sbF6.Tag = "6"
        '
        'sbF9
        '
        Me.sbF9._ForceCaps = False
        Me.sbF9.AutoEllipsis = False
        Me.sbF9.BackgroundImage = CType(resources.GetObject("sbF9.BackgroundImage"), System.Drawing.Image)
        Me.sbF9.Beeping = False
        Me.sbF9.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF9.ButtonText = "F9"
        Me.sbF9.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF9.ButtonTextHeight = -1
        Me.sbF9.Clickable = True
        Me.sbF9.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF9.Data = "F9"
        Me.sbF9.Data2 = "F9"
        Me.sbF9.FlashInterval = 500
        Me.sbF9.holdDraw = False
        Me.sbF9.Lit = True
        Me.sbF9.Location = New System.Drawing.Point(694, 0)
        Me.sbF9.Name = "sbF9"
        Me.sbF9.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF9.Size = New System.Drawing.Size(64, 48)
        Me.sbF9.TabIndex = 91
        Me.sbF9.Tag = "9"
        '
        'sbF10
        '
        Me.sbF10._ForceCaps = False
        Me.sbF10.AutoEllipsis = False
        Me.sbF10.BackgroundImage = CType(resources.GetObject("sbF10.BackgroundImage"), System.Drawing.Image)
        Me.sbF10.Beeping = False
        Me.sbF10.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF10.ButtonText = "F10"
        Me.sbF10.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF10.ButtonTextHeight = -1
        Me.sbF10.Clickable = True
        Me.sbF10.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF10.Data = "F10"
        Me.sbF10.Data2 = "F10"
        Me.sbF10.FlashInterval = 500
        Me.sbF10.holdDraw = False
        Me.sbF10.Lit = True
        Me.sbF10.Location = New System.Drawing.Point(764, 0)
        Me.sbF10.Name = "sbF10"
        Me.sbF10.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF10.Size = New System.Drawing.Size(64, 48)
        Me.sbF10.TabIndex = 90
        Me.sbF10.Tag = "10"
        '
        'sbF11
        '
        Me.sbF11._ForceCaps = False
        Me.sbF11.AutoEllipsis = False
        Me.sbF11.BackgroundImage = CType(resources.GetObject("sbF11.BackgroundImage"), System.Drawing.Image)
        Me.sbF11.Beeping = False
        Me.sbF11.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF11.ButtonText = "F11"
        Me.sbF11.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF11.ButtonTextHeight = -1
        Me.sbF11.Clickable = True
        Me.sbF11.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF11.Data = "F11"
        Me.sbF11.Data2 = "F11"
        Me.sbF11.FlashInterval = 500
        Me.sbF11.holdDraw = False
        Me.sbF11.Lit = True
        Me.sbF11.Location = New System.Drawing.Point(834, 0)
        Me.sbF11.Name = "sbF11"
        Me.sbF11.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF11.Size = New System.Drawing.Size(64, 48)
        Me.sbF11.TabIndex = 89
        Me.sbF11.Tag = "11"
        '
        'sbF12
        '
        Me.sbF12._ForceCaps = False
        Me.sbF12.AutoEllipsis = False
        Me.sbF12.BackgroundImage = CType(resources.GetObject("sbF12.BackgroundImage"), System.Drawing.Image)
        Me.sbF12.Beeping = False
        Me.sbF12.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF12.ButtonText = "F12"
        Me.sbF12.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF12.ButtonTextHeight = -1
        Me.sbF12.Clickable = True
        Me.sbF12.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF12.Data = "F12"
        Me.sbF12.Data2 = "F12"
        Me.sbF12.FlashInterval = 500
        Me.sbF12.holdDraw = False
        Me.sbF12.Lit = True
        Me.sbF12.Location = New System.Drawing.Point(904, 0)
        Me.sbF12.Name = "sbF12"
        Me.sbF12.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF12.Size = New System.Drawing.Size(64, 48)
        Me.sbF12.TabIndex = 88
        Me.sbF12.Tag = "12"
        '
        'sbF4
        '
        Me.sbF4._ForceCaps = False
        Me.sbF4.AutoEllipsis = False
        Me.sbF4.BackgroundImage = CType(resources.GetObject("sbF4.BackgroundImage"), System.Drawing.Image)
        Me.sbF4.Beeping = False
        Me.sbF4.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF4.ButtonText = "F4"
        Me.sbF4.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF4.ButtonTextHeight = -1
        Me.sbF4.Clickable = True
        Me.sbF4.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF4.Data = "F4"
        Me.sbF4.Data2 = "F4"
        Me.sbF4.FlashInterval = 500
        Me.sbF4.holdDraw = False
        Me.sbF4.Lit = True
        Me.sbF4.Location = New System.Drawing.Point(346, 0)
        Me.sbF4.Name = "sbF4"
        Me.sbF4.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF4.Size = New System.Drawing.Size(64, 48)
        Me.sbF4.TabIndex = 87
        Me.sbF4.Tag = "4"
        '
        'sbF5
        '
        Me.sbF5._ForceCaps = False
        Me.sbF5.AutoEllipsis = False
        Me.sbF5.BackgroundImage = CType(resources.GetObject("sbF5.BackgroundImage"), System.Drawing.Image)
        Me.sbF5.Beeping = False
        Me.sbF5.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF5.ButtonText = "F5"
        Me.sbF5.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF5.ButtonTextHeight = -1
        Me.sbF5.Clickable = True
        Me.sbF5.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF5.Data = "F5"
        Me.sbF5.Data2 = "F5"
        Me.sbF5.FlashInterval = 500
        Me.sbF5.holdDraw = False
        Me.sbF5.Lit = True
        Me.sbF5.Location = New System.Drawing.Point(416, 0)
        Me.sbF5.Name = "sbF5"
        Me.sbF5.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF5.Size = New System.Drawing.Size(64, 48)
        Me.sbF5.TabIndex = 86
        Me.sbF5.Tag = "5"
        '
        'sbF3
        '
        Me.sbF3._ForceCaps = False
        Me.sbF3.AutoEllipsis = False
        Me.sbF3.BackgroundImage = CType(resources.GetObject("sbF3.BackgroundImage"), System.Drawing.Image)
        Me.sbF3.Beeping = False
        Me.sbF3.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF3.ButtonText = "F3"
        Me.sbF3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF3.ButtonTextHeight = -1
        Me.sbF3.Clickable = True
        Me.sbF3.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF3.Data = "F3"
        Me.sbF3.Data2 = "F3"
        Me.sbF3.FlashInterval = 500
        Me.sbF3.holdDraw = False
        Me.sbF3.Lit = True
        Me.sbF3.Location = New System.Drawing.Point(276, 0)
        Me.sbF3.Name = "sbF3"
        Me.sbF3.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF3.Size = New System.Drawing.Size(64, 48)
        Me.sbF3.TabIndex = 85
        Me.sbF3.Tag = "3"
        '
        'sbF2
        '
        Me.sbF2._ForceCaps = False
        Me.sbF2.AutoEllipsis = False
        Me.sbF2.BackgroundImage = CType(resources.GetObject("sbF2.BackgroundImage"), System.Drawing.Image)
        Me.sbF2.Beeping = False
        Me.sbF2.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF2.ButtonText = "F2"
        Me.sbF2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF2.ButtonTextHeight = -1
        Me.sbF2.Clickable = True
        Me.sbF2.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF2.Data = "F2"
        Me.sbF2.Data2 = "F2"
        Me.sbF2.FlashInterval = 500
        Me.sbF2.holdDraw = False
        Me.sbF2.Lit = True
        Me.sbF2.Location = New System.Drawing.Point(206, 0)
        Me.sbF2.Name = "sbF2"
        Me.sbF2.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF2.Size = New System.Drawing.Size(64, 48)
        Me.sbF2.TabIndex = 84
        Me.sbF2.Tag = "2"
        '
        'sbF1
        '
        Me.sbF1._ForceCaps = False
        Me.sbF1.AutoEllipsis = False
        Me.sbF1.BackgroundImage = CType(resources.GetObject("sbF1.BackgroundImage"), System.Drawing.Image)
        Me.sbF1.Beeping = False
        Me.sbF1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF1.ButtonText = "F1"
        Me.sbF1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF1.ButtonTextHeight = -1
        Me.sbF1.Clickable = True
        Me.sbF1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF1.Data = "F1"
        Me.sbF1.Data2 = "F1"
        Me.sbF1.FlashInterval = 500
        Me.sbF1.holdDraw = False
        Me.sbF1.Lit = True
        Me.sbF1.Location = New System.Drawing.Point(136, 0)
        Me.sbF1.Name = "sbF1"
        Me.sbF1.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF1.Size = New System.Drawing.Size(64, 48)
        Me.sbF1.TabIndex = 83
        Me.sbF1.Tag = "1"
        '
        'sbDEL
        '
        Me.sbDEL.AutoEllipsis = False
        Me.sbDEL.BackgroundImage = CType(resources.GetObject("sbDEL.BackgroundImage"), System.Drawing.Image)
        Me.sbDEL.Beeping = False
        Me.sbDEL.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbDEL.ButtonText = "DEL"
        Me.sbDEL.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbDEL.ButtonTextHeight = -1
        Me.sbDEL.Clickable = True
        Me.sbDEL.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbDEL.Data = "DEL"
        Me.sbDEL.Data2 = "DEL"
        Me.sbDEL.FlashInterval = 500
        Me.sbDEL.holdDraw = False
        Me.sbDEL.Lit = True
        Me.sbDEL.Location = New System.Drawing.Point(974, 0)
        Me.sbDEL.Name = "sbDEL"
        Me.sbDEL.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDEL.Size = New System.Drawing.Size(43, 48)
        Me.sbDEL.TabIndex = 82
        Me.sbDEL.Tag = "15"
        '
        'sbESC
        '
        Me.sbESC.AutoEllipsis = False
        Me.sbESC.BackgroundImage = CType(resources.GetObject("sbESC.BackgroundImage"), System.Drawing.Image)
        Me.sbESC.Beeping = False
        Me.sbESC.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbESC.ButtonText = "ESC"
        Me.sbESC.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbESC.ButtonTextHeight = -1
        Me.sbESC.Clickable = True
        Me.sbESC.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbESC.Data = "ESC"
        Me.sbESC.Data2 = "ESC"
        Me.sbESC.FlashInterval = 500
        Me.sbESC.holdDraw = False
        Me.sbESC.Lit = True
        Me.sbESC.Location = New System.Drawing.Point(4, 0)
        Me.sbESC.Name = "sbESC"
        Me.sbESC.RedAlert = LCARS.LCARSalert.Normal
        Me.sbESC.Size = New System.Drawing.Size(59, 48)
        Me.sbESC.TabIndex = 81
        Me.sbESC.Tag = "15"
        '
        'abLeft
        '
        Me.abLeft.ArrowDirection = LCARS.LCARSarrowDirection.Left
        Me.abLeft.AutoEllipsis = False
        Me.abLeft.BackgroundImage = CType(resources.GetObject("abLeft.BackgroundImage"), System.Drawing.Image)
        Me.abLeft.Beeping = True
        Me.abLeft.ButtonText = ""
        Me.abLeft.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.abLeft.ButtonTextHeight = 14
        Me.abLeft.Clickable = True
        Me.abLeft.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.abLeft.Data = Nothing
        Me.abLeft.Data2 = Nothing
        Me.abLeft.FlashInterval = 500
        Me.abLeft.holdDraw = False
        Me.abLeft.Lit = True
        Me.abLeft.Location = New System.Drawing.Point(812, 345)
        Me.abLeft.Name = "abLeft"
        Me.abLeft.RedAlert = LCARS.LCARSalert.Normal
        Me.abLeft.Size = New System.Drawing.Size(64, 64)
        Me.abLeft.TabIndex = 80
        '
        'abRight
        '
        Me.abRight.ArrowDirection = LCARS.LCARSarrowDirection.Right
        Me.abRight.AutoEllipsis = False
        Me.abRight.BackgroundImage = CType(resources.GetObject("abRight.BackgroundImage"), System.Drawing.Image)
        Me.abRight.Beeping = True
        Me.abRight.ButtonText = ""
        Me.abRight.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.abRight.ButtonTextHeight = 14
        Me.abRight.Clickable = True
        Me.abRight.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.abRight.Data = Nothing
        Me.abRight.Data2 = Nothing
        Me.abRight.FlashInterval = 500
        Me.abRight.holdDraw = False
        Me.abRight.Lit = True
        Me.abRight.Location = New System.Drawing.Point(952, 345)
        Me.abRight.Name = "abRight"
        Me.abRight.RedAlert = LCARS.LCARSalert.Normal
        Me.abRight.Size = New System.Drawing.Size(64, 64)
        Me.abRight.TabIndex = 79
        '
        'abDown
        '
        Me.abDown.ArrowDirection = LCARS.LCARSarrowDirection.Down
        Me.abDown.AutoEllipsis = False
        Me.abDown.BackgroundImage = CType(resources.GetObject("abDown.BackgroundImage"), System.Drawing.Image)
        Me.abDown.Beeping = True
        Me.abDown.ButtonText = ""
        Me.abDown.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.abDown.ButtonTextHeight = 14
        Me.abDown.Clickable = True
        Me.abDown.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.abDown.Data = Nothing
        Me.abDown.Data2 = Nothing
        Me.abDown.FlashInterval = 500
        Me.abDown.holdDraw = False
        Me.abDown.Lit = True
        Me.abDown.Location = New System.Drawing.Point(882, 345)
        Me.abDown.Name = "abDown"
        Me.abDown.RedAlert = LCARS.LCARSalert.Normal
        Me.abDown.Size = New System.Drawing.Size(64, 64)
        Me.abDown.TabIndex = 78
        '
        'abUp
        '
        Me.abUp.ArrowDirection = LCARS.LCARSarrowDirection.Up
        Me.abUp.AutoEllipsis = False
        Me.abUp.BackgroundImage = CType(resources.GetObject("abUp.BackgroundImage"), System.Drawing.Image)
        Me.abUp.Beeping = True
        Me.abUp.ButtonText = ""
        Me.abUp.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.abUp.ButtonTextHeight = 14
        Me.abUp.Clickable = True
        Me.abUp.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.abUp.Data = Nothing
        Me.abUp.Data2 = Nothing
        Me.abUp.FlashInterval = 500
        Me.abUp.holdDraw = False
        Me.abUp.Lit = True
        Me.abUp.Location = New System.Drawing.Point(882, 275)
        Me.abUp.Name = "abUp"
        Me.abUp.RedAlert = LCARS.LCARSalert.Normal
        Me.abUp.Size = New System.Drawing.Size(64, 64)
        Me.abUp.TabIndex = 77
        '
        'sbSpace
        '
        Me.sbSpace._ForceCaps = False
        Me.sbSpace.AutoEllipsis = False
        Me.sbSpace.BackgroundImage = CType(resources.GetObject("sbSpace.BackgroundImage"), System.Drawing.Image)
        Me.sbSpace.Beeping = False
        Me.sbSpace.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbSpace.ButtonText = " "
        Me.sbSpace.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbSpace.ButtonTextHeight = -1
        Me.sbSpace.Clickable = True
        Me.sbSpace.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbSpace.Data = " "
        Me.sbSpace.Data2 = " "
        Me.sbSpace.FlashInterval = 500
        Me.sbSpace.holdDraw = False
        Me.sbSpace.Lit = True
        Me.sbSpace.Location = New System.Drawing.Point(280, 345)
        Me.sbSpace.Name = "sbSpace"
        Me.sbSpace.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSpace.Size = New System.Drawing.Size(364, 64)
        Me.sbSpace.TabIndex = 73
        Me.sbSpace.Tag = "56"
        '
        'sbRAlt
        '
        Me.sbRAlt._ForceCaps = False
        Me.sbRAlt.AutoEllipsis = False
        Me.sbRAlt.BackgroundImage = CType(resources.GetObject("sbRAlt.BackgroundImage"), System.Drawing.Image)
        Me.sbRAlt.Beeping = False
        Me.sbRAlt.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRAlt.ButtonText = "ALT"
        Me.sbRAlt.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRAlt.ButtonTextHeight = -1
        Me.sbRAlt.Clickable = True
        Me.sbRAlt.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbRAlt.Data = "ALT"
        Me.sbRAlt.Data2 = "ALT"
        Me.sbRAlt.FlashInterval = 500
        Me.sbRAlt.holdDraw = False
        Me.sbRAlt.Lit = True
        Me.sbRAlt.Location = New System.Drawing.Point(650, 346)
        Me.sbRAlt.Name = "sbRAlt"
        Me.sbRAlt.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRAlt.Size = New System.Drawing.Size(48, 64)
        Me.sbRAlt.TabIndex = 72
        Me.sbRAlt.Tag = "57"
        '
        'sbRwin
        '
        Me.sbRwin._ForceCaps = False
        Me.sbRwin.AutoEllipsis = False
        Me.sbRwin.BackgroundImage = CType(resources.GetObject("sbRwin.BackgroundImage"), System.Drawing.Image)
        Me.sbRwin.Beeping = False
        Me.sbRwin.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRwin.ButtonText = "WIN"
        Me.sbRwin.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRwin.ButtonTextHeight = -1
        Me.sbRwin.Clickable = True
        Me.sbRwin.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbRwin.Data = "WIN"
        Me.sbRwin.Data2 = "WIN"
        Me.sbRwin.FlashInterval = 500
        Me.sbRwin.holdDraw = False
        Me.sbRwin.Lit = True
        Me.sbRwin.Location = New System.Drawing.Point(704, 345)
        Me.sbRwin.Name = "sbRwin"
        Me.sbRwin.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRwin.Size = New System.Drawing.Size(48, 64)
        Me.sbRwin.TabIndex = 71
        Me.sbRwin.Tag = "58"
        '
        'sbRCtrl
        '
        Me.sbRCtrl._ForceCaps = False
        Me.sbRCtrl.AutoEllipsis = False
        Me.sbRCtrl.BackgroundImage = CType(resources.GetObject("sbRCtrl.BackgroundImage"), System.Drawing.Image)
        Me.sbRCtrl.Beeping = False
        Me.sbRCtrl.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRCtrl.ButtonText = "CTRL"
        Me.sbRCtrl.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRCtrl.ButtonTextHeight = -1
        Me.sbRCtrl.Clickable = True
        Me.sbRCtrl.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbRCtrl.Data = "CTRL"
        Me.sbRCtrl.Data2 = "CTRL"
        Me.sbRCtrl.FlashInterval = 500
        Me.sbRCtrl.holdDraw = False
        Me.sbRCtrl.Lit = True
        Me.sbRCtrl.Location = New System.Drawing.Point(758, 345)
        Me.sbRCtrl.Name = "sbRCtrl"
        Me.sbRCtrl.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRCtrl.Size = New System.Drawing.Size(48, 64)
        Me.sbRCtrl.TabIndex = 70
        Me.sbRCtrl.Tag = "59!"
        '
        'sbLAlt
        '
        Me.sbLAlt._ForceCaps = False
        Me.sbLAlt.AutoEllipsis = False
        Me.sbLAlt.BackgroundImage = CType(resources.GetObject("sbLAlt.BackgroundImage"), System.Drawing.Image)
        Me.sbLAlt.Beeping = False
        Me.sbLAlt.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbLAlt.ButtonText = "ALT"
        Me.sbLAlt.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbLAlt.ButtonTextHeight = -1
        Me.sbLAlt.Clickable = True
        Me.sbLAlt.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbLAlt.Data = "ALT"
        Me.sbLAlt.Data2 = "ALT"
        Me.sbLAlt.FlashInterval = 500
        Me.sbLAlt.holdDraw = False
        Me.sbLAlt.Lit = True
        Me.sbLAlt.Location = New System.Drawing.Point(188, 345)
        Me.sbLAlt.Name = "sbLAlt"
        Me.sbLAlt.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLAlt.Size = New System.Drawing.Size(86, 64)
        Me.sbLAlt.TabIndex = 69
        Me.sbLAlt.Tag = "55"
        '
        'sbLWin
        '
        Me.sbLWin._ForceCaps = False
        Me.sbLWin.AutoEllipsis = False
        Me.sbLWin.BackgroundImage = CType(resources.GetObject("sbLWin.BackgroundImage"), System.Drawing.Image)
        Me.sbLWin.Beeping = False
        Me.sbLWin.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbLWin.ButtonText = "WIN"
        Me.sbLWin.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbLWin.ButtonTextHeight = -1
        Me.sbLWin.Clickable = True
        Me.sbLWin.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbLWin.Data = "WIN"
        Me.sbLWin.Data2 = "WIN"
        Me.sbLWin.FlashInterval = 500
        Me.sbLWin.holdDraw = False
        Me.sbLWin.Lit = True
        Me.sbLWin.Location = New System.Drawing.Point(96, 345)
        Me.sbLWin.Name = "sbLWin"
        Me.sbLWin.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLWin.Size = New System.Drawing.Size(86, 64)
        Me.sbLWin.TabIndex = 68
        Me.sbLWin.Tag = "54"
        '
        'sbLCtrl
        '
        Me.sbLCtrl._ForceCaps = False
        Me.sbLCtrl.AutoEllipsis = False
        Me.sbLCtrl.BackgroundImage = CType(resources.GetObject("sbLCtrl.BackgroundImage"), System.Drawing.Image)
        Me.sbLCtrl.Beeping = False
        Me.sbLCtrl.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbLCtrl.ButtonText = "CTRL"
        Me.sbLCtrl.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbLCtrl.ButtonTextHeight = -1
        Me.sbLCtrl.Clickable = True
        Me.sbLCtrl.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbLCtrl.Data = "CTRL"
        Me.sbLCtrl.Data2 = "CTRL"
        Me.sbLCtrl.FlashInterval = 500
        Me.sbLCtrl.holdDraw = False
        Me.sbLCtrl.Lit = True
        Me.sbLCtrl.Location = New System.Drawing.Point(4, 345)
        Me.sbLCtrl.Name = "sbLCtrl"
        Me.sbLCtrl.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLCtrl.Size = New System.Drawing.Size(86, 64)
        Me.sbLCtrl.TabIndex = 67
        Me.sbLCtrl.Tag = "53."
        '
        'sbLShift
        '
        Me.sbLShift._ForceCaps = False
        Me.sbLShift.AutoEllipsis = False
        Me.sbLShift.BackgroundImage = CType(resources.GetObject("sbLShift.BackgroundImage"), System.Drawing.Image)
        Me.sbLShift.Beeping = False
        Me.sbLShift.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbLShift.ButtonText = "SHIFT"
        Me.sbLShift.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbLShift.ButtonTextHeight = -1
        Me.sbLShift.Clickable = True
        Me.sbLShift.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbLShift.Data = "SHIFT"
        Me.sbLShift.Data2 = "SHIFT"
        Me.sbLShift.FlashInterval = 500
        Me.sbLShift.holdDraw = False
        Me.sbLShift.Lit = True
        Me.sbLShift.Location = New System.Drawing.Point(4, 275)
        Me.sbLShift.Name = "sbLShift"
        Me.sbLShift.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLShift.Size = New System.Drawing.Size(126, 64)
        Me.sbLShift.TabIndex = 55
        Me.sbLShift.Tag = "41."
        '
        'sbComma
        '
        Me.sbComma._ForceCaps = False
        Me.sbComma.AutoEllipsis = False
        Me.sbComma.BackgroundImage = CType(resources.GetObject("sbComma.BackgroundImage"), System.Drawing.Image)
        Me.sbComma.Beeping = False
        Me.sbComma.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbComma.ButtonText = ","
        Me.sbComma.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbComma.ButtonTextHeight = -1
        Me.sbComma.Clickable = True
        Me.sbComma.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbComma.Data = ","
        Me.sbComma.Data2 = "<"
        Me.sbComma.FlashInterval = 500
        Me.sbComma.holdDraw = False
        Me.sbComma.Lit = True
        Me.sbComma.Location = New System.Drawing.Point(626, 275)
        Me.sbComma.Name = "sbComma"
        Me.sbComma.RedAlert = LCARS.LCARSalert.Normal
        Me.sbComma.Size = New System.Drawing.Size(60, 64)
        Me.sbComma.TabIndex = 54
        Me.sbComma.Tag = "49"
        '
        'sbM
        '
        Me.sbM._ForceCaps = False
        Me.sbM.AutoEllipsis = False
        Me.sbM.BackgroundImage = CType(resources.GetObject("sbM.BackgroundImage"), System.Drawing.Image)
        Me.sbM.Beeping = False
        Me.sbM.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbM.ButtonText = "m"
        Me.sbM.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbM.ButtonTextHeight = -1
        Me.sbM.Clickable = True
        Me.sbM.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbM.Data = "m"
        Me.sbM.Data2 = "M"
        Me.sbM.FlashInterval = 500
        Me.sbM.holdDraw = False
        Me.sbM.Lit = True
        Me.sbM.Location = New System.Drawing.Point(556, 275)
        Me.sbM.Name = "sbM"
        Me.sbM.RedAlert = LCARS.LCARSalert.Normal
        Me.sbM.Size = New System.Drawing.Size(64, 64)
        Me.sbM.TabIndex = 53
        Me.sbM.Tag = "48"
        '
        'sbN
        '
        Me.sbN._ForceCaps = False
        Me.sbN.AutoEllipsis = False
        Me.sbN.BackgroundImage = CType(resources.GetObject("sbN.BackgroundImage"), System.Drawing.Image)
        Me.sbN.Beeping = False
        Me.sbN.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbN.ButtonText = "n"
        Me.sbN.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbN.ButtonTextHeight = -1
        Me.sbN.Clickable = True
        Me.sbN.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbN.Data = "n"
        Me.sbN.Data2 = "N"
        Me.sbN.FlashInterval = 500
        Me.sbN.holdDraw = False
        Me.sbN.Lit = True
        Me.sbN.Location = New System.Drawing.Point(486, 275)
        Me.sbN.Name = "sbN"
        Me.sbN.RedAlert = LCARS.LCARSalert.Normal
        Me.sbN.Size = New System.Drawing.Size(64, 64)
        Me.sbN.TabIndex = 52
        Me.sbN.Tag = "47"
        '
        'sbPeriod
        '
        Me.sbPeriod._ForceCaps = False
        Me.sbPeriod.AutoEllipsis = False
        Me.sbPeriod.BackgroundImage = CType(resources.GetObject("sbPeriod.BackgroundImage"), System.Drawing.Image)
        Me.sbPeriod.Beeping = False
        Me.sbPeriod.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbPeriod.ButtonText = "."
        Me.sbPeriod.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbPeriod.ButtonTextHeight = -1
        Me.sbPeriod.Clickable = True
        Me.sbPeriod.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbPeriod.Data = "."
        Me.sbPeriod.Data2 = ">"
        Me.sbPeriod.FlashInterval = 500
        Me.sbPeriod.holdDraw = False
        Me.sbPeriod.Lit = True
        Me.sbPeriod.Location = New System.Drawing.Point(692, 276)
        Me.sbPeriod.Name = "sbPeriod"
        Me.sbPeriod.RedAlert = LCARS.LCARSalert.Normal
        Me.sbPeriod.Size = New System.Drawing.Size(60, 64)
        Me.sbPeriod.TabIndex = 51
        Me.sbPeriod.Tag = "50"
        '
        'sbForwardSlash
        '
        Me.sbForwardSlash._ForceCaps = False
        Me.sbForwardSlash.AutoEllipsis = False
        Me.sbForwardSlash.BackgroundImage = CType(resources.GetObject("sbForwardSlash.BackgroundImage"), System.Drawing.Image)
        Me.sbForwardSlash.Beeping = False
        Me.sbForwardSlash.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbForwardSlash.ButtonText = "/"
        Me.sbForwardSlash.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbForwardSlash.ButtonTextHeight = -1
        Me.sbForwardSlash.Clickable = True
        Me.sbForwardSlash.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbForwardSlash.Data = "/"
        Me.sbForwardSlash.Data2 = "?"
        Me.sbForwardSlash.FlashInterval = 500
        Me.sbForwardSlash.holdDraw = False
        Me.sbForwardSlash.Lit = True
        Me.sbForwardSlash.Location = New System.Drawing.Point(758, 275)
        Me.sbForwardSlash.Name = "sbForwardSlash"
        Me.sbForwardSlash.RedAlert = LCARS.LCARSalert.Normal
        Me.sbForwardSlash.Size = New System.Drawing.Size(60, 64)
        Me.sbForwardSlash.TabIndex = 50
        Me.sbForwardSlash.Tag = "51"
        '
        'sbV
        '
        Me.sbV._ForceCaps = False
        Me.sbV.AutoEllipsis = False
        Me.sbV.BackgroundImage = CType(resources.GetObject("sbV.BackgroundImage"), System.Drawing.Image)
        Me.sbV.Beeping = False
        Me.sbV.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbV.ButtonText = "v"
        Me.sbV.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbV.ButtonTextHeight = -1
        Me.sbV.Clickable = True
        Me.sbV.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbV.Data = "v"
        Me.sbV.Data2 = "V"
        Me.sbV.FlashInterval = 500
        Me.sbV.holdDraw = False
        Me.sbV.Lit = True
        Me.sbV.Location = New System.Drawing.Point(346, 275)
        Me.sbV.Name = "sbV"
        Me.sbV.RedAlert = LCARS.LCARSalert.Normal
        Me.sbV.Size = New System.Drawing.Size(64, 64)
        Me.sbV.TabIndex = 48
        Me.sbV.Tag = "45"
        '
        'sbB
        '
        Me.sbB._ForceCaps = False
        Me.sbB.AutoEllipsis = False
        Me.sbB.BackgroundImage = CType(resources.GetObject("sbB.BackgroundImage"), System.Drawing.Image)
        Me.sbB.Beeping = False
        Me.sbB.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbB.ButtonText = "b"
        Me.sbB.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbB.ButtonTextHeight = -1
        Me.sbB.Clickable = True
        Me.sbB.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbB.Data = "b"
        Me.sbB.Data2 = "B"
        Me.sbB.FlashInterval = 500
        Me.sbB.holdDraw = False
        Me.sbB.Lit = True
        Me.sbB.Location = New System.Drawing.Point(416, 275)
        Me.sbB.Name = "sbB"
        Me.sbB.RedAlert = LCARS.LCARSalert.Normal
        Me.sbB.Size = New System.Drawing.Size(64, 64)
        Me.sbB.TabIndex = 47
        Me.sbB.Tag = "46"
        '
        'sbRShift
        '
        Me.sbRShift._ForceCaps = False
        Me.sbRShift.AutoEllipsis = False
        Me.sbRShift.BackgroundImage = CType(resources.GetObject("sbRShift.BackgroundImage"), System.Drawing.Image)
        Me.sbRShift.Beeping = False
        Me.sbRShift.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRShift.ButtonText = "SHIFT"
        Me.sbRShift.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRShift.ButtonTextHeight = -1
        Me.sbRShift.Clickable = True
        Me.sbRShift.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbRShift.Data = "SHIFT"
        Me.sbRShift.Data2 = "SHIFT"
        Me.sbRShift.FlashInterval = 500
        Me.sbRShift.holdDraw = False
        Me.sbRShift.Lit = True
        Me.sbRShift.Location = New System.Drawing.Point(824, 275)
        Me.sbRShift.Name = "sbRShift"
        Me.sbRShift.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRShift.Size = New System.Drawing.Size(52, 64)
        Me.sbRShift.TabIndex = 46
        Me.sbRShift.Tag = "52"
        '
        'sbC
        '
        Me.sbC._ForceCaps = False
        Me.sbC.AutoEllipsis = False
        Me.sbC.BackgroundImage = CType(resources.GetObject("sbC.BackgroundImage"), System.Drawing.Image)
        Me.sbC.Beeping = False
        Me.sbC.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbC.ButtonText = "c"
        Me.sbC.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbC.ButtonTextHeight = -1
        Me.sbC.Clickable = True
        Me.sbC.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbC.Data = "c"
        Me.sbC.Data2 = "C"
        Me.sbC.FlashInterval = 500
        Me.sbC.holdDraw = False
        Me.sbC.Lit = True
        Me.sbC.Location = New System.Drawing.Point(276, 275)
        Me.sbC.Name = "sbC"
        Me.sbC.RedAlert = LCARS.LCARSalert.Normal
        Me.sbC.Size = New System.Drawing.Size(64, 64)
        Me.sbC.TabIndex = 45
        Me.sbC.Tag = "44"
        '
        'sbX
        '
        Me.sbX._ForceCaps = False
        Me.sbX.AutoEllipsis = False
        Me.sbX.BackgroundImage = CType(resources.GetObject("sbX.BackgroundImage"), System.Drawing.Image)
        Me.sbX.Beeping = False
        Me.sbX.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbX.ButtonText = "x"
        Me.sbX.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbX.ButtonTextHeight = -1
        Me.sbX.Clickable = True
        Me.sbX.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbX.Data = "x"
        Me.sbX.Data2 = "X"
        Me.sbX.FlashInterval = 500
        Me.sbX.holdDraw = False
        Me.sbX.Lit = True
        Me.sbX.Location = New System.Drawing.Point(206, 275)
        Me.sbX.Name = "sbX"
        Me.sbX.RedAlert = LCARS.LCARSalert.Normal
        Me.sbX.Size = New System.Drawing.Size(64, 64)
        Me.sbX.TabIndex = 44
        Me.sbX.Tag = "43"
        '
        'sbZ
        '
        Me.sbZ._ForceCaps = False
        Me.sbZ.AutoEllipsis = False
        Me.sbZ.BackgroundImage = CType(resources.GetObject("sbZ.BackgroundImage"), System.Drawing.Image)
        Me.sbZ.Beeping = False
        Me.sbZ.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbZ.ButtonText = "z"
        Me.sbZ.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbZ.ButtonTextHeight = -1
        Me.sbZ.Clickable = True
        Me.sbZ.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbZ.Data = "z"
        Me.sbZ.Data2 = "Z"
        Me.sbZ.FlashInterval = 500
        Me.sbZ.holdDraw = False
        Me.sbZ.Lit = True
        Me.sbZ.Location = New System.Drawing.Point(136, 275)
        Me.sbZ.Name = "sbZ"
        Me.sbZ.RedAlert = LCARS.LCARSalert.Normal
        Me.sbZ.Size = New System.Drawing.Size(64, 64)
        Me.sbZ.TabIndex = 43
        Me.sbZ.Tag = "42"
        '
        'sbCaps
        '
        Me.sbCaps._ForceCaps = False
        Me.sbCaps.AutoEllipsis = False
        Me.sbCaps.BackgroundImage = CType(resources.GetObject("sbCaps.BackgroundImage"), System.Drawing.Image)
        Me.sbCaps.Beeping = False
        Me.sbCaps.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbCaps.ButtonText = "CAPS "
        Me.sbCaps.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbCaps.ButtonTextHeight = -1
        Me.sbCaps.Clickable = True
        Me.sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbCaps.Data = "CAPS"
        Me.sbCaps.Data2 = "CAPS"
        Me.sbCaps.FlashInterval = 500
        Me.sbCaps.holdDraw = False
        Me.sbCaps.Lit = True
        Me.sbCaps.Location = New System.Drawing.Point(4, 205)
        Me.sbCaps.Name = "sbCaps"
        Me.sbCaps.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCaps.Size = New System.Drawing.Size(102, 64)
        Me.sbCaps.TabIndex = 42
        Me.sbCaps.Tag = "28."
        '
        'sbK
        '
        Me.sbK._ForceCaps = False
        Me.sbK.AutoEllipsis = False
        Me.sbK.BackgroundImage = CType(resources.GetObject("sbK.BackgroundImage"), System.Drawing.Image)
        Me.sbK.Beeping = False
        Me.sbK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbK.ButtonText = "k"
        Me.sbK.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbK.ButtonTextHeight = -1
        Me.sbK.Clickable = True
        Me.sbK.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbK.Data = "k"
        Me.sbK.Data2 = "K"
        Me.sbK.FlashInterval = 500
        Me.sbK.holdDraw = False
        Me.sbK.Lit = True
        Me.sbK.Location = New System.Drawing.Point(602, 205)
        Me.sbK.Name = "sbK"
        Me.sbK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbK.Size = New System.Drawing.Size(64, 64)
        Me.sbK.TabIndex = 41
        Me.sbK.Tag = "36"
        '
        'sbJ
        '
        Me.sbJ._ForceCaps = False
        Me.sbJ.AutoEllipsis = False
        Me.sbJ.BackgroundImage = CType(resources.GetObject("sbJ.BackgroundImage"), System.Drawing.Image)
        Me.sbJ.Beeping = False
        Me.sbJ.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbJ.ButtonText = "j"
        Me.sbJ.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbJ.ButtonTextHeight = -1
        Me.sbJ.Clickable = True
        Me.sbJ.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbJ.Data = "j"
        Me.sbJ.Data2 = "J"
        Me.sbJ.FlashInterval = 500
        Me.sbJ.holdDraw = False
        Me.sbJ.Lit = True
        Me.sbJ.Location = New System.Drawing.Point(532, 205)
        Me.sbJ.Name = "sbJ"
        Me.sbJ.RedAlert = LCARS.LCARSalert.Normal
        Me.sbJ.Size = New System.Drawing.Size(64, 64)
        Me.sbJ.TabIndex = 40
        Me.sbJ.Tag = "35"
        '
        'sbH
        '
        Me.sbH._ForceCaps = False
        Me.sbH.AutoEllipsis = False
        Me.sbH.BackgroundImage = CType(resources.GetObject("sbH.BackgroundImage"), System.Drawing.Image)
        Me.sbH.Beeping = False
        Me.sbH.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbH.ButtonText = "h"
        Me.sbH.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbH.ButtonTextHeight = -1
        Me.sbH.Clickable = True
        Me.sbH.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbH.Data = "h"
        Me.sbH.Data2 = "H"
        Me.sbH.FlashInterval = 500
        Me.sbH.holdDraw = False
        Me.sbH.Lit = True
        Me.sbH.Location = New System.Drawing.Point(462, 205)
        Me.sbH.Name = "sbH"
        Me.sbH.RedAlert = LCARS.LCARSalert.Normal
        Me.sbH.Size = New System.Drawing.Size(64, 64)
        Me.sbH.TabIndex = 39
        Me.sbH.Tag = "34"
        '
        'sbL
        '
        Me.sbL._ForceCaps = False
        Me.sbL.AutoEllipsis = False
        Me.sbL.BackgroundImage = CType(resources.GetObject("sbL.BackgroundImage"), System.Drawing.Image)
        Me.sbL.Beeping = False
        Me.sbL.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbL.ButtonText = "l"
        Me.sbL.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbL.ButtonTextHeight = -1
        Me.sbL.Clickable = True
        Me.sbL.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbL.Data = "l"
        Me.sbL.Data2 = "L"
        Me.sbL.FlashInterval = 500
        Me.sbL.holdDraw = False
        Me.sbL.Lit = True
        Me.sbL.Location = New System.Drawing.Point(672, 205)
        Me.sbL.Name = "sbL"
        Me.sbL.RedAlert = LCARS.LCARSalert.Normal
        Me.sbL.Size = New System.Drawing.Size(64, 64)
        Me.sbL.TabIndex = 38
        Me.sbL.Tag = "37"
        '
        'sbSemiColon
        '
        Me.sbSemiColon._ForceCaps = False
        Me.sbSemiColon.AutoEllipsis = False
        Me.sbSemiColon.BackgroundImage = CType(resources.GetObject("sbSemiColon.BackgroundImage"), System.Drawing.Image)
        Me.sbSemiColon.Beeping = False
        Me.sbSemiColon.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbSemiColon.ButtonText = ";"
        Me.sbSemiColon.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbSemiColon.ButtonTextHeight = -1
        Me.sbSemiColon.Clickable = True
        Me.sbSemiColon.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbSemiColon.Data = ";"
        Me.sbSemiColon.Data2 = ":"
        Me.sbSemiColon.FlashInterval = 500
        Me.sbSemiColon.holdDraw = False
        Me.sbSemiColon.Lit = True
        Me.sbSemiColon.Location = New System.Drawing.Point(742, 205)
        Me.sbSemiColon.Name = "sbSemiColon"
        Me.sbSemiColon.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSemiColon.Size = New System.Drawing.Size(64, 64)
        Me.sbSemiColon.TabIndex = 37
        Me.sbSemiColon.Tag = "38"
        '
        'sbQuote
        '
        Me.sbQuote._ForceCaps = False
        Me.sbQuote.AutoEllipsis = False
        Me.sbQuote.BackgroundImage = CType(resources.GetObject("sbQuote.BackgroundImage"), System.Drawing.Image)
        Me.sbQuote.Beeping = False
        Me.sbQuote.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbQuote.ButtonText = "'"
        Me.sbQuote.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbQuote.ButtonTextHeight = -1
        Me.sbQuote.Clickable = True
        Me.sbQuote.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbQuote.Data = "'"
        Me.sbQuote.Data2 = """"
        Me.sbQuote.FlashInterval = 500
        Me.sbQuote.holdDraw = False
        Me.sbQuote.Lit = True
        Me.sbQuote.Location = New System.Drawing.Point(812, 205)
        Me.sbQuote.Name = "sbQuote"
        Me.sbQuote.RedAlert = LCARS.LCARSalert.Normal
        Me.sbQuote.Size = New System.Drawing.Size(64, 64)
        Me.sbQuote.TabIndex = 36
        Me.sbQuote.Tag = "39"
        '
        'sbF
        '
        Me.sbF._ForceCaps = False
        Me.sbF.AutoEllipsis = False
        Me.sbF.BackgroundImage = CType(resources.GetObject("sbF.BackgroundImage"), System.Drawing.Image)
        Me.sbF.Beeping = False
        Me.sbF.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbF.ButtonText = "f"
        Me.sbF.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbF.ButtonTextHeight = -1
        Me.sbF.Clickable = True
        Me.sbF.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbF.Data = "f"
        Me.sbF.Data2 = "F"
        Me.sbF.FlashInterval = 500
        Me.sbF.holdDraw = False
        Me.sbF.Lit = True
        Me.sbF.Location = New System.Drawing.Point(322, 205)
        Me.sbF.Name = "sbF"
        Me.sbF.RedAlert = LCARS.LCARSalert.Normal
        Me.sbF.Size = New System.Drawing.Size(64, 64)
        Me.sbF.TabIndex = 34
        Me.sbF.Tag = "32"
        '
        'sbG
        '
        Me.sbG._ForceCaps = False
        Me.sbG.AutoEllipsis = False
        Me.sbG.BackgroundImage = CType(resources.GetObject("sbG.BackgroundImage"), System.Drawing.Image)
        Me.sbG.Beeping = False
        Me.sbG.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbG.ButtonText = "g"
        Me.sbG.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbG.ButtonTextHeight = -1
        Me.sbG.Clickable = True
        Me.sbG.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbG.Data = "g"
        Me.sbG.Data2 = "G"
        Me.sbG.FlashInterval = 500
        Me.sbG.holdDraw = False
        Me.sbG.Lit = True
        Me.sbG.Location = New System.Drawing.Point(392, 205)
        Me.sbG.Name = "sbG"
        Me.sbG.RedAlert = LCARS.LCARSalert.Normal
        Me.sbG.Size = New System.Drawing.Size(64, 64)
        Me.sbG.TabIndex = 33
        Me.sbG.Tag = "33"
        '
        'sbEnter
        '
        Me.sbEnter._ForceCaps = False
        Me.sbEnter.AutoEllipsis = False
        Me.sbEnter.BackgroundImage = CType(resources.GetObject("sbEnter.BackgroundImage"), System.Drawing.Image)
        Me.sbEnter.Beeping = False
        Me.sbEnter.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbEnter.ButtonText = "ENTER"
        Me.sbEnter.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbEnter.ButtonTextHeight = -1
        Me.sbEnter.Clickable = True
        Me.sbEnter.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbEnter.Data = "ENTER"
        Me.sbEnter.Data2 = "ENTER"
        Me.sbEnter.FlashInterval = 500
        Me.sbEnter.holdDraw = False
        Me.sbEnter.Lit = True
        Me.sbEnter.Location = New System.Drawing.Point(882, 205)
        Me.sbEnter.Name = "sbEnter"
        Me.sbEnter.RedAlert = LCARS.LCARSalert.Normal
        Me.sbEnter.Size = New System.Drawing.Size(134, 64)
        Me.sbEnter.TabIndex = 32
        Me.sbEnter.Tag = "40"
        '
        'sbD
        '
        Me.sbD._ForceCaps = False
        Me.sbD.AutoEllipsis = False
        Me.sbD.BackgroundImage = CType(resources.GetObject("sbD.BackgroundImage"), System.Drawing.Image)
        Me.sbD.Beeping = False
        Me.sbD.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbD.ButtonText = "d"
        Me.sbD.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbD.ButtonTextHeight = -1
        Me.sbD.Clickable = True
        Me.sbD.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbD.Data = "d"
        Me.sbD.Data2 = "D"
        Me.sbD.FlashInterval = 500
        Me.sbD.holdDraw = False
        Me.sbD.Lit = True
        Me.sbD.Location = New System.Drawing.Point(252, 205)
        Me.sbD.Name = "sbD"
        Me.sbD.RedAlert = LCARS.LCARSalert.Normal
        Me.sbD.Size = New System.Drawing.Size(64, 64)
        Me.sbD.TabIndex = 31
        Me.sbD.Tag = "31"
        '
        'sbS
        '
        Me.sbS._ForceCaps = False
        Me.sbS.AutoEllipsis = False
        Me.sbS.BackgroundImage = CType(resources.GetObject("sbS.BackgroundImage"), System.Drawing.Image)
        Me.sbS.Beeping = False
        Me.sbS.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbS.ButtonText = "s"
        Me.sbS.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbS.ButtonTextHeight = -1
        Me.sbS.Clickable = True
        Me.sbS.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbS.Data = "s"
        Me.sbS.Data2 = "S"
        Me.sbS.FlashInterval = 500
        Me.sbS.holdDraw = False
        Me.sbS.Lit = True
        Me.sbS.Location = New System.Drawing.Point(182, 205)
        Me.sbS.Name = "sbS"
        Me.sbS.RedAlert = LCARS.LCARSalert.Normal
        Me.sbS.Size = New System.Drawing.Size(64, 64)
        Me.sbS.TabIndex = 30
        Me.sbS.Tag = "30"
        '
        'sbA
        '
        Me.sbA._ForceCaps = False
        Me.sbA.AutoEllipsis = False
        Me.sbA.BackgroundImage = CType(resources.GetObject("sbA.BackgroundImage"), System.Drawing.Image)
        Me.sbA.Beeping = False
        Me.sbA.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbA.ButtonText = "a"
        Me.sbA.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbA.ButtonTextHeight = -1
        Me.sbA.Clickable = True
        Me.sbA.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbA.Data = "a"
        Me.sbA.Data2 = "A"
        Me.sbA.FlashInterval = 500
        Me.sbA.holdDraw = False
        Me.sbA.Lit = True
        Me.sbA.Location = New System.Drawing.Point(112, 205)
        Me.sbA.Name = "sbA"
        Me.sbA.RedAlert = LCARS.LCARSalert.Normal
        Me.sbA.Size = New System.Drawing.Size(64, 64)
        Me.sbA.TabIndex = 29
        Me.sbA.Tag = "29"
        '
        'sbTilde
        '
        Me.sbTilde._ForceCaps = False
        Me.sbTilde.AutoEllipsis = False
        Me.sbTilde.BackgroundImage = CType(resources.GetObject("sbTilde.BackgroundImage"), System.Drawing.Image)
        Me.sbTilde.Beeping = False
        Me.sbTilde.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbTilde.ButtonText = "`"
        Me.sbTilde.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbTilde.ButtonTextHeight = -1
        Me.sbTilde.Clickable = True
        Me.sbTilde.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbTilde.Data = "`"
        Me.sbTilde.Data2 = "~"
        Me.sbTilde.FlashInterval = 500
        Me.sbTilde.holdDraw = False
        Me.sbTilde.Lit = True
        Me.sbTilde.Location = New System.Drawing.Point(4, 65)
        Me.sbTilde.Name = "sbTilde"
        Me.sbTilde.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTilde.Size = New System.Drawing.Size(54, 64)
        Me.sbTilde.TabIndex = 28
        Me.sbTilde.Tag = "0"
        '
        'sb8
        '
        Me.sb8._ForceCaps = False
        Me.sb8.AutoEllipsis = False
        Me.sb8.BackgroundImage = CType(resources.GetObject("sb8.BackgroundImage"), System.Drawing.Image)
        Me.sb8.Beeping = False
        Me.sb8.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb8.ButtonText = "8"
        Me.sb8.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb8.ButtonTextHeight = -1
        Me.sb8.Clickable = True
        Me.sb8.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb8.Data = "8"
        Me.sb8.Data2 = "*"
        Me.sb8.FlashInterval = 500
        Me.sb8.holdDraw = False
        Me.sb8.Lit = True
        Me.sb8.Location = New System.Drawing.Point(552, 65)
        Me.sb8.Name = "sb8"
        Me.sb8.RedAlert = LCARS.LCARSalert.Normal
        Me.sb8.Size = New System.Drawing.Size(64, 64)
        Me.sb8.TabIndex = 27
        Me.sb8.Tag = "8"
        '
        'sb7
        '
        Me.sb7._ForceCaps = False
        Me.sb7.AutoEllipsis = False
        Me.sb7.BackgroundImage = CType(resources.GetObject("sb7.BackgroundImage"), System.Drawing.Image)
        Me.sb7.Beeping = False
        Me.sb7.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb7.ButtonText = "7"
        Me.sb7.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb7.ButtonTextHeight = -1
        Me.sb7.Clickable = True
        Me.sb7.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb7.Data = "7"
        Me.sb7.Data2 = "&"
        Me.sb7.FlashInterval = 500
        Me.sb7.holdDraw = False
        Me.sb7.Lit = True
        Me.sb7.Location = New System.Drawing.Point(484, 65)
        Me.sb7.Name = "sb7"
        Me.sb7.RedAlert = LCARS.LCARSalert.Normal
        Me.sb7.Size = New System.Drawing.Size(64, 64)
        Me.sb7.TabIndex = 26
        Me.sb7.Tag = "7"
        '
        'sb6
        '
        Me.sb6._ForceCaps = False
        Me.sb6.AutoEllipsis = False
        Me.sb6.BackgroundImage = CType(resources.GetObject("sb6.BackgroundImage"), System.Drawing.Image)
        Me.sb6.Beeping = False
        Me.sb6.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb6.ButtonText = "6"
        Me.sb6.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb6.ButtonTextHeight = -1
        Me.sb6.Clickable = True
        Me.sb6.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb6.Data = "6"
        Me.sb6.Data2 = "^"
        Me.sb6.FlashInterval = 500
        Me.sb6.holdDraw = False
        Me.sb6.Lit = True
        Me.sb6.Location = New System.Drawing.Point(414, 65)
        Me.sb6.Name = "sb6"
        Me.sb6.RedAlert = LCARS.LCARSalert.Normal
        Me.sb6.Size = New System.Drawing.Size(64, 64)
        Me.sb6.TabIndex = 25
        Me.sb6.Tag = "6"
        '
        'sb9
        '
        Me.sb9._ForceCaps = False
        Me.sb9.AutoEllipsis = False
        Me.sb9.BackgroundImage = CType(resources.GetObject("sb9.BackgroundImage"), System.Drawing.Image)
        Me.sb9.Beeping = False
        Me.sb9.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb9.ButtonText = "9"
        Me.sb9.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb9.ButtonTextHeight = -1
        Me.sb9.Clickable = True
        Me.sb9.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb9.Data = "9"
        Me.sb9.Data2 = "("
        Me.sb9.FlashInterval = 500
        Me.sb9.holdDraw = False
        Me.sb9.Lit = True
        Me.sb9.Location = New System.Drawing.Point(622, 65)
        Me.sb9.Name = "sb9"
        Me.sb9.RedAlert = LCARS.LCARSalert.Normal
        Me.sb9.Size = New System.Drawing.Size(64, 64)
        Me.sb9.TabIndex = 24
        Me.sb9.Tag = "9"
        '
        'sb0
        '
        Me.sb0._ForceCaps = False
        Me.sb0.AutoEllipsis = False
        Me.sb0.BackgroundImage = CType(resources.GetObject("sb0.BackgroundImage"), System.Drawing.Image)
        Me.sb0.Beeping = False
        Me.sb0.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb0.ButtonText = "0"
        Me.sb0.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb0.ButtonTextHeight = -1
        Me.sb0.Clickable = True
        Me.sb0.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb0.Data = "0"
        Me.sb0.Data2 = ")"
        Me.sb0.FlashInterval = 500
        Me.sb0.holdDraw = False
        Me.sb0.Lit = True
        Me.sb0.Location = New System.Drawing.Point(692, 65)
        Me.sb0.Name = "sb0"
        Me.sb0.RedAlert = LCARS.LCARSalert.Normal
        Me.sb0.Size = New System.Drawing.Size(64, 64)
        Me.sb0.TabIndex = 23
        Me.sb0.Tag = "10"
        '
        'sbMinus
        '
        Me.sbMinus._ForceCaps = False
        Me.sbMinus.AutoEllipsis = False
        Me.sbMinus.BackgroundImage = CType(resources.GetObject("sbMinus.BackgroundImage"), System.Drawing.Image)
        Me.sbMinus.Beeping = False
        Me.sbMinus.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbMinus.ButtonText = "-"
        Me.sbMinus.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbMinus.ButtonTextHeight = -1
        Me.sbMinus.Clickable = True
        Me.sbMinus.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbMinus.Data = "-"
        Me.sbMinus.Data2 = "_"
        Me.sbMinus.FlashInterval = 500
        Me.sbMinus.holdDraw = False
        Me.sbMinus.Lit = True
        Me.sbMinus.Location = New System.Drawing.Point(762, 65)
        Me.sbMinus.Name = "sbMinus"
        Me.sbMinus.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMinus.Size = New System.Drawing.Size(64, 64)
        Me.sbMinus.TabIndex = 22
        Me.sbMinus.Tag = "11"
        '
        'sbEqual
        '
        Me.sbEqual._ForceCaps = False
        Me.sbEqual.AutoEllipsis = False
        Me.sbEqual.BackgroundImage = CType(resources.GetObject("sbEqual.BackgroundImage"), System.Drawing.Image)
        Me.sbEqual.Beeping = False
        Me.sbEqual.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbEqual.ButtonText = "="
        Me.sbEqual.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbEqual.ButtonTextHeight = -1
        Me.sbEqual.Clickable = True
        Me.sbEqual.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbEqual.Data = "="
        Me.sbEqual.Data2 = "+"
        Me.sbEqual.FlashInterval = 500
        Me.sbEqual.holdDraw = False
        Me.sbEqual.Lit = True
        Me.sbEqual.Location = New System.Drawing.Point(833, 65)
        Me.sbEqual.Name = "sbEqual"
        Me.sbEqual.RedAlert = LCARS.LCARSalert.Normal
        Me.sbEqual.Size = New System.Drawing.Size(64, 64)
        Me.sbEqual.TabIndex = 21
        Me.sbEqual.Tag = "12"
        '
        'sb4
        '
        Me.sb4._ForceCaps = False
        Me.sb4.AutoEllipsis = False
        Me.sb4.BackgroundImage = CType(resources.GetObject("sb4.BackgroundImage"), System.Drawing.Image)
        Me.sb4.Beeping = False
        Me.sb4.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb4.ButtonText = "4"
        Me.sb4.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb4.ButtonTextHeight = -1
        Me.sb4.Clickable = True
        Me.sb4.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb4.Data = "4"
        Me.sb4.Data2 = "$"
        Me.sb4.FlashInterval = 500
        Me.sb4.holdDraw = False
        Me.sb4.Lit = True
        Me.sb4.Location = New System.Drawing.Point(274, 65)
        Me.sb4.Name = "sb4"
        Me.sb4.RedAlert = LCARS.LCARSalert.Normal
        Me.sb4.Size = New System.Drawing.Size(64, 64)
        Me.sb4.TabIndex = 20
        Me.sb4.Tag = "4"
        '
        'sb5
        '
        Me.sb5._ForceCaps = False
        Me.sb5.AutoEllipsis = False
        Me.sb5.BackgroundImage = CType(resources.GetObject("sb5.BackgroundImage"), System.Drawing.Image)
        Me.sb5.Beeping = False
        Me.sb5.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb5.ButtonText = "5"
        Me.sb5.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb5.ButtonTextHeight = -1
        Me.sb5.Clickable = True
        Me.sb5.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb5.Data = "5"
        Me.sb5.Data2 = "%"
        Me.sb5.FlashInterval = 500
        Me.sb5.holdDraw = False
        Me.sb5.Lit = True
        Me.sb5.Location = New System.Drawing.Point(344, 65)
        Me.sb5.Name = "sb5"
        Me.sb5.RedAlert = LCARS.LCARSalert.Normal
        Me.sb5.Size = New System.Drawing.Size(64, 64)
        Me.sb5.TabIndex = 19
        Me.sb5.Tag = "5"
        '
        'sbBack
        '
        Me.sbBack._ForceCaps = False
        Me.sbBack.AutoEllipsis = False
        Me.sbBack.BackgroundImage = CType(resources.GetObject("sbBack.BackgroundImage"), System.Drawing.Image)
        Me.sbBack.Beeping = False
        Me.sbBack.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbBack.ButtonText = "BACKSPACE"
        Me.sbBack.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbBack.ButtonTextHeight = -1
        Me.sbBack.Clickable = True
        Me.sbBack.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbBack.Data = "BACKSPACE"
        Me.sbBack.Data2 = "BACKSPACE"
        Me.sbBack.FlashInterval = 500
        Me.sbBack.holdDraw = False
        Me.sbBack.Lit = True
        Me.sbBack.Location = New System.Drawing.Point(903, 65)
        Me.sbBack.Name = "sbBack"
        Me.sbBack.RedAlert = LCARS.LCARSalert.Normal
        Me.sbBack.Size = New System.Drawing.Size(113, 64)
        Me.sbBack.TabIndex = 18
        Me.sbBack.Tag = "13"
        '
        'sb3
        '
        Me.sb3._ForceCaps = False
        Me.sb3.AutoEllipsis = False
        Me.sb3.BackgroundImage = CType(resources.GetObject("sb3.BackgroundImage"), System.Drawing.Image)
        Me.sb3.Beeping = False
        Me.sb3.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb3.ButtonText = "3"
        Me.sb3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb3.ButtonTextHeight = -1
        Me.sb3.Clickable = True
        Me.sb3.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb3.Data = "3"
        Me.sb3.Data2 = "#"
        Me.sb3.FlashInterval = 500
        Me.sb3.holdDraw = False
        Me.sb3.Lit = True
        Me.sb3.Location = New System.Drawing.Point(204, 65)
        Me.sb3.Name = "sb3"
        Me.sb3.RedAlert = LCARS.LCARSalert.Normal
        Me.sb3.Size = New System.Drawing.Size(64, 64)
        Me.sb3.TabIndex = 17
        Me.sb3.Tag = "3"
        '
        'sb2
        '
        Me.sb2._ForceCaps = False
        Me.sb2.AutoEllipsis = False
        Me.sb2.BackgroundImage = CType(resources.GetObject("sb2.BackgroundImage"), System.Drawing.Image)
        Me.sb2.Beeping = False
        Me.sb2.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb2.ButtonText = "2"
        Me.sb2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb2.ButtonTextHeight = -1
        Me.sb2.Clickable = True
        Me.sb2.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb2.Data = "2"
        Me.sb2.Data2 = "@"
        Me.sb2.FlashInterval = 500
        Me.sb2.holdDraw = False
        Me.sb2.Lit = True
        Me.sb2.Location = New System.Drawing.Point(134, 65)
        Me.sb2.Name = "sb2"
        Me.sb2.RedAlert = LCARS.LCARSalert.Normal
        Me.sb2.Size = New System.Drawing.Size(64, 64)
        Me.sb2.TabIndex = 16
        Me.sb2.Tag = "2"
        '
        'sb1
        '
        Me.sb1._ForceCaps = False
        Me.sb1.AutoEllipsis = False
        Me.sb1.BackgroundImage = CType(resources.GetObject("sb1.BackgroundImage"), System.Drawing.Image)
        Me.sb1.Beeping = False
        Me.sb1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sb1.ButtonText = "1"
        Me.sb1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sb1.ButtonTextHeight = -1
        Me.sb1.Clickable = True
        Me.sb1.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sb1.Data = "1"
        Me.sb1.Data2 = "!"
        Me.sb1.FlashInterval = 500
        Me.sb1.holdDraw = False
        Me.sb1.Lit = True
        Me.sb1.Location = New System.Drawing.Point(64, 65)
        Me.sb1.Name = "sb1"
        Me.sb1.RedAlert = LCARS.LCARSalert.Normal
        Me.sb1.Size = New System.Drawing.Size(64, 64)
        Me.sb1.TabIndex = 15
        Me.sb1.Tag = "1"
        '
        'sbTab
        '
        Me.sbTab._ForceCaps = False
        Me.sbTab.AutoEllipsis = False
        Me.sbTab.BackgroundImage = CType(resources.GetObject("sbTab.BackgroundImage"), System.Drawing.Image)
        Me.sbTab.Beeping = False
        Me.sbTab.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbTab.ButtonText = "TAB"
        Me.sbTab.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbTab.ButtonTextHeight = -1
        Me.sbTab.Clickable = True
        Me.sbTab.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbTab.Data = "TAB"
        Me.sbTab.Data2 = "TAB"
        Me.sbTab.FlashInterval = 500
        Me.sbTab.holdDraw = False
        Me.sbTab.Lit = True
        Me.sbTab.Location = New System.Drawing.Point(4, 135)
        Me.sbTab.Name = "sbTab"
        Me.sbTab.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTab.Size = New System.Drawing.Size(86, 64)
        Me.sbTab.TabIndex = 14
        Me.sbTab.Tag = "14."
        '
        'sbI
        '
        Me.sbI._ForceCaps = False
        Me.sbI.AutoEllipsis = False
        Me.sbI.BackgroundImage = CType(resources.GetObject("sbI.BackgroundImage"), System.Drawing.Image)
        Me.sbI.Beeping = False
        Me.sbI.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbI.ButtonText = "i"
        Me.sbI.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbI.ButtonTextHeight = -1
        Me.sbI.Clickable = True
        Me.sbI.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbI.Data = "i"
        Me.sbI.Data2 = "I"
        Me.sbI.FlashInterval = 500
        Me.sbI.holdDraw = False
        Me.sbI.Lit = True
        Me.sbI.Location = New System.Drawing.Point(586, 135)
        Me.sbI.Name = "sbI"
        Me.sbI.RedAlert = LCARS.LCARSalert.Normal
        Me.sbI.Size = New System.Drawing.Size(64, 64)
        Me.sbI.TabIndex = 13
        Me.sbI.Tag = "22"
        '
        'sbU
        '
        Me.sbU._ForceCaps = False
        Me.sbU.AutoEllipsis = False
        Me.sbU.BackgroundImage = CType(resources.GetObject("sbU.BackgroundImage"), System.Drawing.Image)
        Me.sbU.Beeping = False
        Me.sbU.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbU.ButtonText = "u"
        Me.sbU.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbU.ButtonTextHeight = -1
        Me.sbU.Clickable = True
        Me.sbU.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbU.Data = "u"
        Me.sbU.Data2 = "U"
        Me.sbU.FlashInterval = 500
        Me.sbU.holdDraw = False
        Me.sbU.Lit = True
        Me.sbU.Location = New System.Drawing.Point(516, 135)
        Me.sbU.Name = "sbU"
        Me.sbU.RedAlert = LCARS.LCARSalert.Normal
        Me.sbU.Size = New System.Drawing.Size(64, 64)
        Me.sbU.TabIndex = 12
        Me.sbU.Tag = "21"
        '
        'sbY
        '
        Me.sbY._ForceCaps = False
        Me.sbY.AutoEllipsis = False
        Me.sbY.BackgroundImage = CType(resources.GetObject("sbY.BackgroundImage"), System.Drawing.Image)
        Me.sbY.Beeping = False
        Me.sbY.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbY.ButtonText = "y"
        Me.sbY.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbY.ButtonTextHeight = -1
        Me.sbY.Clickable = True
        Me.sbY.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbY.Data = "y"
        Me.sbY.Data2 = "Y"
        Me.sbY.FlashInterval = 500
        Me.sbY.holdDraw = False
        Me.sbY.Lit = True
        Me.sbY.Location = New System.Drawing.Point(446, 135)
        Me.sbY.Name = "sbY"
        Me.sbY.RedAlert = LCARS.LCARSalert.Normal
        Me.sbY.Size = New System.Drawing.Size(64, 64)
        Me.sbY.TabIndex = 11
        Me.sbY.Tag = "20"
        '
        'sbO
        '
        Me.sbO._ForceCaps = False
        Me.sbO.AutoEllipsis = False
        Me.sbO.BackgroundImage = CType(resources.GetObject("sbO.BackgroundImage"), System.Drawing.Image)
        Me.sbO.Beeping = False
        Me.sbO.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbO.ButtonText = "o"
        Me.sbO.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbO.ButtonTextHeight = -1
        Me.sbO.Clickable = True
        Me.sbO.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbO.Data = "o"
        Me.sbO.Data2 = "O"
        Me.sbO.FlashInterval = 500
        Me.sbO.holdDraw = False
        Me.sbO.Lit = True
        Me.sbO.Location = New System.Drawing.Point(656, 135)
        Me.sbO.Name = "sbO"
        Me.sbO.RedAlert = LCARS.LCARSalert.Normal
        Me.sbO.Size = New System.Drawing.Size(64, 64)
        Me.sbO.TabIndex = 10
        Me.sbO.Tag = "23"
        '
        'sbP
        '
        Me.sbP._ForceCaps = False
        Me.sbP.AutoEllipsis = False
        Me.sbP.BackgroundImage = CType(resources.GetObject("sbP.BackgroundImage"), System.Drawing.Image)
        Me.sbP.Beeping = False
        Me.sbP.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbP.ButtonText = "p"
        Me.sbP.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbP.ButtonTextHeight = -1
        Me.sbP.Clickable = True
        Me.sbP.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbP.Data = "p"
        Me.sbP.Data2 = "P"
        Me.sbP.FlashInterval = 500
        Me.sbP.holdDraw = False
        Me.sbP.Lit = True
        Me.sbP.Location = New System.Drawing.Point(726, 135)
        Me.sbP.Name = "sbP"
        Me.sbP.RedAlert = LCARS.LCARSalert.Normal
        Me.sbP.Size = New System.Drawing.Size(64, 64)
        Me.sbP.TabIndex = 9
        Me.sbP.Tag = "24"
        '
        'sbLBracket
        '
        Me.sbLBracket._ForceCaps = False
        Me.sbLBracket.AutoEllipsis = False
        Me.sbLBracket.BackgroundImage = CType(resources.GetObject("sbLBracket.BackgroundImage"), System.Drawing.Image)
        Me.sbLBracket.Beeping = False
        Me.sbLBracket.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbLBracket.ButtonText = "["
        Me.sbLBracket.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbLBracket.ButtonTextHeight = -1
        Me.sbLBracket.Clickable = True
        Me.sbLBracket.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbLBracket.Data = "["
        Me.sbLBracket.Data2 = "{"
        Me.sbLBracket.FlashInterval = 500
        Me.sbLBracket.holdDraw = False
        Me.sbLBracket.Lit = True
        Me.sbLBracket.Location = New System.Drawing.Point(796, 135)
        Me.sbLBracket.Name = "sbLBracket"
        Me.sbLBracket.RedAlert = LCARS.LCARSalert.Normal
        Me.sbLBracket.Size = New System.Drawing.Size(64, 64)
        Me.sbLBracket.TabIndex = 8
        Me.sbLBracket.Tag = "25"
        '
        'sbRBracket
        '
        Me.sbRBracket._ForceCaps = False
        Me.sbRBracket.AutoEllipsis = False
        Me.sbRBracket.BackgroundImage = CType(resources.GetObject("sbRBracket.BackgroundImage"), System.Drawing.Image)
        Me.sbRBracket.Beeping = False
        Me.sbRBracket.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRBracket.ButtonText = "]"
        Me.sbRBracket.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbRBracket.ButtonTextHeight = -1
        Me.sbRBracket.Clickable = True
        Me.sbRBracket.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbRBracket.Data = "]"
        Me.sbRBracket.Data2 = "}"
        Me.sbRBracket.FlashInterval = 500
        Me.sbRBracket.holdDraw = False
        Me.sbRBracket.Lit = True
        Me.sbRBracket.Location = New System.Drawing.Point(866, 135)
        Me.sbRBracket.Name = "sbRBracket"
        Me.sbRBracket.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRBracket.Size = New System.Drawing.Size(64, 64)
        Me.sbRBracket.TabIndex = 7
        Me.sbRBracket.Tag = "26"
        '
        'sbR
        '
        Me.sbR._ForceCaps = False
        Me.sbR.AutoEllipsis = False
        Me.sbR.BackgroundImage = CType(resources.GetObject("sbR.BackgroundImage"), System.Drawing.Image)
        Me.sbR.Beeping = False
        Me.sbR.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbR.ButtonText = "r"
        Me.sbR.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbR.ButtonTextHeight = -1
        Me.sbR.Clickable = True
        Me.sbR.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbR.Data = "r"
        Me.sbR.Data2 = "R"
        Me.sbR.FlashInterval = 500
        Me.sbR.holdDraw = False
        Me.sbR.Lit = True
        Me.sbR.Location = New System.Drawing.Point(306, 135)
        Me.sbR.Name = "sbR"
        Me.sbR.RedAlert = LCARS.LCARSalert.Normal
        Me.sbR.Size = New System.Drawing.Size(64, 64)
        Me.sbR.TabIndex = 6
        Me.sbR.Tag = "18"
        '
        'sbT
        '
        Me.sbT._ForceCaps = False
        Me.sbT.AutoEllipsis = False
        Me.sbT.BackgroundImage = CType(resources.GetObject("sbT.BackgroundImage"), System.Drawing.Image)
        Me.sbT.Beeping = False
        Me.sbT.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbT.ButtonText = "t"
        Me.sbT.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbT.ButtonTextHeight = -1
        Me.sbT.Clickable = True
        Me.sbT.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbT.Data = "t"
        Me.sbT.Data2 = "T"
        Me.sbT.FlashInterval = 500
        Me.sbT.holdDraw = False
        Me.sbT.Lit = True
        Me.sbT.Location = New System.Drawing.Point(376, 135)
        Me.sbT.Name = "sbT"
        Me.sbT.RedAlert = LCARS.LCARSalert.Normal
        Me.sbT.Size = New System.Drawing.Size(64, 64)
        Me.sbT.TabIndex = 5
        Me.sbT.Tag = "19"
        '
        'sbBackSlash
        '
        Me.sbBackSlash._ForceCaps = False
        Me.sbBackSlash.AutoEllipsis = False
        Me.sbBackSlash.BackgroundImage = CType(resources.GetObject("sbBackSlash.BackgroundImage"), System.Drawing.Image)
        Me.sbBackSlash.Beeping = False
        Me.sbBackSlash.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbBackSlash.ButtonText = "\"
        Me.sbBackSlash.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbBackSlash.ButtonTextHeight = -1
        Me.sbBackSlash.Clickable = True
        Me.sbBackSlash.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbBackSlash.Data = "\"
        Me.sbBackSlash.Data2 = "|"
        Me.sbBackSlash.FlashInterval = 500
        Me.sbBackSlash.holdDraw = False
        Me.sbBackSlash.Lit = True
        Me.sbBackSlash.Location = New System.Drawing.Point(936, 135)
        Me.sbBackSlash.Name = "sbBackSlash"
        Me.sbBackSlash.RedAlert = LCARS.LCARSalert.Normal
        Me.sbBackSlash.Size = New System.Drawing.Size(80, 64)
        Me.sbBackSlash.TabIndex = 3
        Me.sbBackSlash.Tag = "27"
        '
        'sbE
        '
        Me.sbE._ForceCaps = False
        Me.sbE.AutoEllipsis = False
        Me.sbE.BackgroundImage = CType(resources.GetObject("sbE.BackgroundImage"), System.Drawing.Image)
        Me.sbE.Beeping = False
        Me.sbE.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbE.ButtonText = "e"
        Me.sbE.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbE.ButtonTextHeight = -1
        Me.sbE.Clickable = True
        Me.sbE.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbE.Data = "e"
        Me.sbE.Data2 = "E"
        Me.sbE.FlashInterval = 500
        Me.sbE.holdDraw = False
        Me.sbE.Lit = True
        Me.sbE.Location = New System.Drawing.Point(236, 135)
        Me.sbE.Name = "sbE"
        Me.sbE.RedAlert = LCARS.LCARSalert.Normal
        Me.sbE.Size = New System.Drawing.Size(64, 64)
        Me.sbE.TabIndex = 2
        Me.sbE.Tag = "17"
        '
        'sbW
        '
        Me.sbW._ForceCaps = False
        Me.sbW.AutoEllipsis = False
        Me.sbW.BackgroundImage = CType(resources.GetObject("sbW.BackgroundImage"), System.Drawing.Image)
        Me.sbW.Beeping = False
        Me.sbW.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbW.ButtonText = "w"
        Me.sbW.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbW.ButtonTextHeight = -1
        Me.sbW.Clickable = True
        Me.sbW.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbW.Data = "w"
        Me.sbW.Data2 = "W"
        Me.sbW.FlashInterval = 500
        Me.sbW.holdDraw = False
        Me.sbW.Lit = True
        Me.sbW.Location = New System.Drawing.Point(166, 135)
        Me.sbW.Name = "sbW"
        Me.sbW.RedAlert = LCARS.LCARSalert.Normal
        Me.sbW.Size = New System.Drawing.Size(64, 64)
        Me.sbW.TabIndex = 1
        Me.sbW.Tag = "16"
        '
        'sbQ
        '
        Me.sbQ._ForceCaps = False
        Me.sbQ.AutoEllipsis = False
        Me.sbQ.BackgroundImage = CType(resources.GetObject("sbQ.BackgroundImage"), System.Drawing.Image)
        Me.sbQ.Beeping = False
        Me.sbQ.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbQ.ButtonText = "q"
        Me.sbQ.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbQ.ButtonTextHeight = -1
        Me.sbQ.Clickable = True
        Me.sbQ.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbQ.Data = "q"
        Me.sbQ.Data2 = "Q"
        Me.sbQ.FlashInterval = 500
        Me.sbQ.holdDraw = False
        Me.sbQ.Lit = True
        Me.sbQ.Location = New System.Drawing.Point(96, 135)
        Me.sbQ.Name = "sbQ"
        Me.sbQ.RedAlert = LCARS.LCARSalert.Normal
        Me.sbQ.Size = New System.Drawing.Size(64, 64)
        Me.sbQ.TabIndex = 0
        Me.sbQ.Tag = "15"
        '
        'sbTitle
        '
        Me.sbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitle.AutoEllipsis = False
        Me.sbTitle.BackgroundImage = CType(resources.GetObject("sbTitle.BackgroundImage"), System.Drawing.Image)
        Me.sbTitle.Beeping = False
        Me.sbTitle.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbTitle.ButtonText = "KEYPAD"
        Me.sbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.sbTitle.ButtonTextHeight = -1
        Me.sbTitle.Clickable = True
        Me.sbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbTitle.Data = Nothing
        Me.sbTitle.Data2 = Nothing
        Me.sbTitle.FlashInterval = 500
        Me.sbTitle.holdDraw = False
        Me.sbTitle.Lit = True
        Me.sbTitle.Location = New System.Drawing.Point(7, 4)
        Me.sbTitle.Name = "sbTitle"
        Me.sbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTitle.Size = New System.Drawing.Size(828, 35)
        Me.sbTitle.TabIndex = 53
        '
        'StandardButton1
        '
        Me.StandardButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StandardButton1.AutoEllipsis = False
        Me.StandardButton1.BackgroundImage = CType(resources.GetObject("StandardButton1.BackgroundImage"), System.Drawing.Image)
        Me.StandardButton1.Beeping = False
        Me.StandardButton1.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.StandardButton1.ButtonText = "X"
        Me.StandardButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StandardButton1.ButtonTextHeight = -1
        Me.StandardButton1.Clickable = True
        Me.StandardButton1.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.StandardButton1.Data = Nothing
        Me.StandardButton1.Data2 = Nothing
        Me.StandardButton1.FlashInterval = 500
        Me.StandardButton1.holdDraw = False
        Me.StandardButton1.Lit = True
        Me.StandardButton1.Location = New System.Drawing.Point(981, 4)
        Me.StandardButton1.Name = "StandardButton1"
        Me.StandardButton1.RedAlert = LCARS.LCARSalert.Normal
        Me.StandardButton1.Size = New System.Drawing.Size(43, 35)
        Me.StandardButton1.TabIndex = 54
        '
        'sbChangeSize
        '
        Me.sbChangeSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbChangeSize.AutoEllipsis = False
        Me.sbChangeSize.BackgroundImage = CType(resources.GetObject("sbChangeSize.BackgroundImage"), System.Drawing.Image)
        Me.sbChangeSize.Beeping = False
        Me.sbChangeSize.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbChangeSize.ButtonText = "RESIZE KEYPAD"
        Me.sbChangeSize.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbChangeSize.ButtonTextHeight = -1
        Me.sbChangeSize.Clickable = True
        Me.sbChangeSize.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbChangeSize.Data = Nothing
        Me.sbChangeSize.Data2 = Nothing
        Me.sbChangeSize.FlashInterval = 500
        Me.sbChangeSize.holdDraw = False
        Me.sbChangeSize.Lit = True
        Me.sbChangeSize.Location = New System.Drawing.Point(841, 4)
        Me.sbChangeSize.Name = "sbChangeSize"
        Me.sbChangeSize.RedAlert = LCARS.LCARSalert.Normal
        Me.sbChangeSize.Size = New System.Drawing.Size(134, 35)
        Me.sbChangeSize.TabIndex = 55
        '
        'sbDone
        '
        Me.sbDone.AutoEllipsis = False
        Me.sbDone.BackgroundImage = CType(resources.GetObject("sbDone.BackgroundImage"), System.Drawing.Image)
        Me.sbDone.Beeping = False
        Me.sbDone.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbDone.ButtonText = "DONE"
        Me.sbDone.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbDone.ButtonTextHeight = -1
        Me.sbDone.Clickable = True
        Me.sbDone.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbDone.Data = Nothing
        Me.sbDone.Data2 = Nothing
        Me.sbDone.FlashInterval = 500
        Me.sbDone.holdDraw = False
        Me.sbDone.Lit = True
        Me.sbDone.Location = New System.Drawing.Point(303, 148)
        Me.sbDone.Name = "sbDone"
        Me.sbDone.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDone.Size = New System.Drawing.Size(112, 35)
        Me.sbDone.TabIndex = 56
        '
        'frmKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1034, 464)
        Me.Controls.Add(Me.pnlResize)
        Me.Controls.Add(Me.sbChangeSize)
        Me.Controls.Add(Me.StandardButton1)
        Me.Controls.Add(Me.sbTitle)
        Me.Controls.Add(Me.pnlKeyboard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKeyboard"
        Me.Text = "On Screen Keyboard"
        Me.TopMost = True
        Me.pnlKeyboard.ResumeLayout(False)
        Me.pnlResize.ResumeLayout(False)
        Me.pnlResize.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlKeyboard As System.Windows.Forms.Panel
    Friend WithEvents sbSpace As LCARS.Controls.StandardButton
    Friend WithEvents sbRAlt As LCARS.Controls.StandardButton
    Friend WithEvents sbRwin As LCARS.Controls.StandardButton
    Friend WithEvents sbRCtrl As LCARS.Controls.StandardButton
    Friend WithEvents sbLAlt As LCARS.Controls.StandardButton
    Friend WithEvents sbLWin As LCARS.Controls.StandardButton
    Friend WithEvents sbLCtrl As LCARS.Controls.StandardButton
    Friend WithEvents sbLShift As LCARS.Controls.StandardButton
    Friend WithEvents sbComma As LCARS.Controls.StandardButton
    Friend WithEvents sbM As LCARS.Controls.StandardButton
    Friend WithEvents sbN As LCARS.Controls.StandardButton
    Friend WithEvents sbPeriod As LCARS.Controls.StandardButton
    Friend WithEvents sbForwardSlash As LCARS.Controls.StandardButton
    Friend WithEvents sbV As LCARS.Controls.StandardButton
    Friend WithEvents sbB As LCARS.Controls.StandardButton
    Friend WithEvents sbRShift As LCARS.Controls.StandardButton
    Friend WithEvents sbC As LCARS.Controls.StandardButton
    Friend WithEvents sbX As LCARS.Controls.StandardButton
    Friend WithEvents sbZ As LCARS.Controls.StandardButton
    Friend WithEvents sbCaps As LCARS.Controls.StandardButton
    Friend WithEvents sbK As LCARS.Controls.StandardButton
    Friend WithEvents sbJ As LCARS.Controls.StandardButton
    Friend WithEvents sbH As LCARS.Controls.StandardButton
    Friend WithEvents sbL As LCARS.Controls.StandardButton
    Friend WithEvents sbSemiColon As LCARS.Controls.StandardButton
    Friend WithEvents sbQuote As LCARS.Controls.StandardButton
    Friend WithEvents sbF As LCARS.Controls.StandardButton
    Friend WithEvents sbG As LCARS.Controls.StandardButton
    Friend WithEvents sbEnter As LCARS.Controls.StandardButton
    Friend WithEvents sbD As LCARS.Controls.StandardButton
    Friend WithEvents sbS As LCARS.Controls.StandardButton
    Friend WithEvents sbA As LCARS.Controls.StandardButton
    Friend WithEvents sbTilde As LCARS.Controls.StandardButton
    Friend WithEvents sb8 As LCARS.Controls.StandardButton
    Friend WithEvents sb7 As LCARS.Controls.StandardButton
    Friend WithEvents sb6 As LCARS.Controls.StandardButton
    Friend WithEvents sb9 As LCARS.Controls.StandardButton
    Friend WithEvents sb0 As LCARS.Controls.StandardButton
    Friend WithEvents sbMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbEqual As LCARS.Controls.StandardButton
    Friend WithEvents sb4 As LCARS.Controls.StandardButton
    Friend WithEvents sb5 As LCARS.Controls.StandardButton
    Friend WithEvents sbBack As LCARS.Controls.StandardButton
    Friend WithEvents sb3 As LCARS.Controls.StandardButton
    Friend WithEvents sb2 As LCARS.Controls.StandardButton
    Friend WithEvents sb1 As LCARS.Controls.StandardButton
    Friend WithEvents sbTab As LCARS.Controls.StandardButton
    Friend WithEvents sbI As LCARS.Controls.StandardButton
    Friend WithEvents sbU As LCARS.Controls.StandardButton
    Friend WithEvents sbY As LCARS.Controls.StandardButton
    Friend WithEvents sbO As LCARS.Controls.StandardButton
    Friend WithEvents sbP As LCARS.Controls.StandardButton
    Friend WithEvents sbLBracket As LCARS.Controls.StandardButton
    Friend WithEvents sbRBracket As LCARS.Controls.StandardButton
    Friend WithEvents sbR As LCARS.Controls.StandardButton
    Friend WithEvents sbT As LCARS.Controls.StandardButton
    Friend WithEvents sbBackSlash As LCARS.Controls.StandardButton
    Friend WithEvents sbE As LCARS.Controls.StandardButton
    Friend WithEvents sbW As LCARS.Controls.StandardButton
    Friend WithEvents sbQ As LCARS.Controls.StandardButton
    Friend WithEvents abLeft As LCARS.Controls.ArrowButton
    Friend WithEvents abRight As LCARS.Controls.ArrowButton
    Friend WithEvents abDown As LCARS.Controls.ArrowButton
    Friend WithEvents abUp As LCARS.Controls.ArrowButton
    Friend WithEvents sbESC As LCARS.Controls.StandardButton
    Friend WithEvents sbDEL As LCARS.Controls.StandardButton
    Friend WithEvents sbF8 As LCARS.Controls.StandardButton
    Friend WithEvents sbF7 As LCARS.Controls.StandardButton
    Friend WithEvents sbF6 As LCARS.Controls.StandardButton
    Friend WithEvents sbF9 As LCARS.Controls.StandardButton
    Friend WithEvents sbF10 As LCARS.Controls.StandardButton
    Friend WithEvents sbF11 As LCARS.Controls.StandardButton
    Friend WithEvents sbF12 As LCARS.Controls.StandardButton
    Friend WithEvents sbF4 As LCARS.Controls.StandardButton
    Friend WithEvents sbF5 As LCARS.Controls.StandardButton
    Friend WithEvents sbF3 As LCARS.Controls.StandardButton
    Friend WithEvents sbF2 As LCARS.Controls.StandardButton
    Friend WithEvents sbF1 As LCARS.Controls.StandardButton
    Friend WithEvents sbTitle As LCARS.Controls.StandardButton
    Friend WithEvents StandardButton1 As LCARS.Controls.StandardButton
    Friend WithEvents sbChangeSize As LCARS.Controls.StandardButton
    Friend WithEvents pnlResize As System.Windows.Forms.Panel
    Friend WithEvents lblResizeTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sbHeightMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbHeightPlus As LCARS.Controls.StandardButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sbWidthMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbWidthPlus As LCARS.Controls.StandardButton
    Friend WithEvents lblIncrement As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sbIncrementPlus As LCARS.Controls.StandardButton
    Friend WithEvents sbIncrementMinus As LCARS.Controls.StandardButton
    Friend WithEvents sbDone As LCARS.Controls.StandardButton
End Class
