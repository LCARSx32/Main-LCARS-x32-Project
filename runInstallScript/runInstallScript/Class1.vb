
#Region " Imports "

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

'Added for TabPanel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design.Serialization


#End Region

#Region " LCARS Enumerations "

Public Enum LCARScolorStyles
    FunctionUnavailable = 0
    SystemFunction = 1
    MiscFunction = 2
    CriticalFunction = 3
    NavigationFunction = 4
    LCARSDisplayOnly = 5
    PrimaryFunction = 6
    FunctionOffline = 7
    StaticTan = 8
    Orange = 9
    StaticBlue = 10
End Enum

Public Enum LCARSalert
    Normal = 0
    Red = 1
    White = 2
    Yellow = 3
End Enum

Public Enum LCARSarrowDirection
    Up = 0
    Down = 1
    Left = 2
    Right = 3
End Enum

#End Region

#Region " LCARS Color Class "

Public Class LCARScolor
    Dim colors() As String
    Sub New()
        Dim myColors As String

        myColors = GetSetting("LCARS x32", "Colors", "ColorMap", "NONE")

        If myColors <> "NONE" Then
            colors = myColors.Split(",")
        Else
            Dim DefaultColors() As String = {"#3366CC", "#99CCFF", "#CC99CC", "#FFCC00", "#FFFF99", "#CC6666", "#FFFFFF", "#FF0000", "#FFCC66", "Orange", "#99CCFF"}
            colors = DefaultColors
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(colors, ","))
        End If
    End Sub

    Public Sub ReloadColors()
        Dim myColors As String

        myColors = GetSetting("LCARS x32", "Colors", "ColorMap", "NONE")

        If myColors <> "NONE" Then
            colors = myColors.Split(",")
        Else
            Dim DefaultColors() As String = {"#3366CC", "#99CCFF", "#CC99CC", "#FFCC00", "#FFFF99", "#CC6666", "#FFFFFF", "#FF0000", "#FFCC66", "Orange", "#99CCFF"}
            colors = DefaultColors
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(colors, ","))
        End If
    End Sub

    Public Function getColors() As String()
        Return colors
    End Function

    Public Sub setColors(ByVal newColors() As String)
        Dim upper As Integer = newColors.GetUpperBound(0)
        Dim intloop As Integer

        If upper > newColors.GetUpperBound(0) Then
            upper = newColors.GetUpperBound(0)
        End If
        For intloop = 0 To upper
            colors(intloop) = newColors(intloop)
        Next

    End Sub

    Public Function IndexOf(ByVal Name As String) As Integer
        Dim myColor As LCARScolorStyles

        For i As Integer = 0 To 10
            myColor = i
            If myColor.ToString.ToLower = Name.ToLower Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Function getColor(ByVal index As LCARScolorStyles) As Color
        Dim code As String

        Select Case index
            Case 0
                code = colors(0)
            Case 1
                code = colors(1)
            Case 2
                code = colors(2)
            Case 3
                code = colors(3)
            Case 4
                code = colors(4)
            Case 5
                code = colors(5)
            Case 6
                code = colors(6)
            Case 7
                code = colors(7)
            Case 8
                code = colors(8)
            Case 9
                code = colors(9)
            Case 10
                code = colors(10)
            Case Else
                MsgBox("'INVALID COLOR CODE' recieved in function 'getColor'.  Please check your code and try again.", MsgBoxStyle.Exclamation, "ERROR!")
                Exit Function
        End Select

        Return ColorTranslator.FromHtml(code)
    End Function

End Class

#End Region

#Region " Generic LCARS Button "

#Region " GenericButton "
<System.ComponentModel.DefaultEvent("Click"), Designer(GetType(GenericButtonDesigner))> _
Public Class LCARSbuttonClass
    Inherits System.Windows.Forms.Control

#Region " Control Design Information "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Sound.Load()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    ' <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'lblText
        ' 
        Me.lblText.Text = "LCARS"
        Me.lblText.AutoSize = False
        Me.lblText.Font = New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblText.Anchor = 15
        Me.lblText.Location = New Point(0, 0)
        Me.lblText.BackColor = Drawing.Color.Transparent
        Me.lblText.ForeColor = Drawing.Color.Black
        Me.lblText.AutoEllipsis = True
        '
        'StandardButton
        '
        Me.Name = "LCARSbutton"
        Me.Size = New System.Drawing.Size(147, 36)
        Me.Controls.Add(Me.lblText)
        lblText.BringToFront()
        Me.ResumeLayout(False)
        Me.Text = "LCARS"



    End Sub
#End Region

#Region " Global Variables "
    'Left button constants
    Const lButtonClick = &H201
    Const lButtonUp = &H202
    Const lButtonDouble = &H203

    'Right button constants
    Const rButtonClick = &H204
    Const rButtonUp = &H205
    Const rButtonDouble = &H206

    'Middle button constants
    Const mButtonClick = &H207
    Const mButtonUp = &H208
    Const mButtonDouble = &H209

    Public ColorsAvailable As New LCARScolor


    Dim myColor As LCARScolorStyles = LCARScolorStyles.MiscFunction
    Dim isLit As Boolean = True
    Dim NormalButton As Bitmap
    Dim UnLitButton As Bitmap
    Dim playSound As Threading.Thread = New Threading.Thread(AddressOf SoundThread)
    Public inRedAlert As LCARSalert = LCARSalert.Normal
    Dim RA As Boolean = False
    Dim Sound As New System.Media.SoundPlayer(My.Resources._207)
    Dim buttonData As Object
    Dim buttonData2 As Object
    Dim noDraw As Boolean = False
    Public textHeight As Integer = 14
    Dim doBeep As Boolean = False
    Dim flashing As Boolean = False
    Dim litBuffer As Boolean
    Dim flasher As Threading.Thread = New Threading.Thread(AddressOf flashThread)
    Dim flashingInterval As Integer = 500
    Dim isFlashing As Boolean
    Dim canClick As Boolean = True
    Dim oAlign As System.Drawing.ContentAlignment
    Public Q As Object
    Private WithEvents lblText As New Label
    Dim scaleHight As Double = 14
    Dim WithEvents tmrTextScroll As New Timer
    Public myText As String = "LCARS"
    Public forceCapital As Boolean = True
#End Region

#Region " Events "

    Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)
    Public Shadows Event MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Shadows Event MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Shadows Event MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
#End Region

#Region " Properties "

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackgroundImage() As System.Drawing.Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            MyBase.BackgroundImage = value
        End Set
    End Property


    Public Overrides Property Text() As String
        Get
            Return ButtonText
        End Get
        Set(ByVal value As String)
            ButtonText = value
        End Set
    End Property

    <DefaultValue(ContentAlignment.BottomRight)> _
    Public Overridable Property ButtonTextAlign() As ContentAlignment
        Get

            Return lblText.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            lblText.TextAlign = value
        End Set
    End Property

    Protected Overrides ReadOnly Property ScaleChildren() As Boolean
        Get
            Return False
        End Get
    End Property

    <DefaultValue(True)> _
    Public Property _ForceCaps() As Boolean
        Get
            Return forceCapital
        End Get
        Set(ByVal value As Boolean)
            forceCapital = value
        End Set
    End Property

    <DefaultValue(True)> _
   Public Property AutoEllipsis() As Boolean
        Get
            Return lblText.AutoEllipsis
        End Get
        Set(ByVal value As Boolean)
            lblText.AutoEllipsis = value
        End Set
    End Property

    Public Property Clickable() As Boolean
        Get
            Return canClick
        End Get
        Set(ByVal value As Boolean)
            canClick = value
        End Set
    End Property

    <DefaultValue(False)> _
    Public Property Flash() As Boolean
        Get
            Return flashing
        End Get
        Set(ByVal value As Boolean)
            flashing = value
            If Me.DesignMode = False Then
                If flashing Then
                    flasher = New Threading.Thread(AddressOf flashThread)
                    flasher.Start()
                Else
                    flasher.Abort()
                    Lit = litBuffer
                End If
            End If

        End Set
    End Property

    Public Property FlashInterval() As Integer
        Get
            Return flashingInterval
        End Get
        Set(ByVal value As Integer)
            flashingInterval = value
        End Set
    End Property

    Public Property holdDraw() As Boolean
        Get
            Return noDraw
        End Get
        Set(ByVal value As Boolean)
            noDraw = value
            DrawAllButtons()
        End Set
    End Property

    Public Property Data() As Object
        Get
            Return buttonData
        End Get
        Set(ByVal value As Object)
            buttonData = value
        End Set
    End Property

    Public Property Data2() As Object
        Get
            Return buttonData2
        End Get
        Set(ByVal value As Object)
            buttonData2 = value
        End Set
    End Property

    <DefaultValue(LCARScolorStyles.NavigationFunction)> _
    Public Property Color() As LCARScolorStyles
        Get
            Return myColor
        End Get
        Set(ByVal value As LCARScolorStyles)
            myColor = value
            DrawAllButtons()
        End Set
    End Property

    <DefaultValue("LCARS Button")> _
    Public Overridable Property ButtonText() As String
        Get
            Return myText
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                value = New String("")
            End If
            If forceCapital Then
                myText = value.ToString.ToUpper
            Else
                myText = value
            End If

            lblText.Text = myText
            If textHeight = -1 Then
                ButtonTextHeight = -1
            End If
        End Set
    End Property
    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Overridable Property lblTextVisible() As Boolean
        Get
            Return lblText.Visible
        End Get
        Set(ByVal value As Boolean)
            lblText.Visible = value
        End Set
    End Property

    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Overridable Property lblTextAnchor() As AnchorStyles
        Get
            Return lblText.Anchor
        End Get
        Set(ByVal value As AnchorStyles)
            lblText.Anchor = value
        End Set
    End Property

    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Overridable Property lblTextLoc() As Point
        Get
            Return lblText.Location
        End Get
        Set(ByVal value As Point)
            lblText.Location = value
        End Set
    End Property

    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Overridable Property lblTextSize() As Point
        Get
            Return lblText.Size
        End Get
        Set(ByVal value As Point)
            lblText.Size = value
        End Set
    End Property

    Public Overridable Property ButtonTextHeight() As Integer
        Get
            Return textHeight
        End Get
        Set(ByVal value As Integer)
            textHeight = value
            If textHeight = -1 Then
                If lblText.Text <> "" Then
                    Dim mysize As New SizeF
                    Dim i As Integer = 1
                    Dim g As Graphics = Graphics.FromImage(New Bitmap(10, 10))
                    mysize = g.MeasureString(lblText.Text, New Font("LCARS", i, FontStyle.Regular, GraphicsUnit.Point))

                    Do Until mysize.Width >= lblText.Width - 8 Or mysize.Height >= lblText.Height
                        i += 1
                        mysize = g.MeasureString(lblText.Text, New Font("LCARS", i, FontStyle.Regular, GraphicsUnit.Point))
                    Loop
                    If i < 2 Then
                        i = 2
                    End If
                    lblText.Font = New Font("LCARS", i - 1, FontStyle.Regular, GraphicsUnit.Point)
                    textHeight = -1
                End If

            Else
                lblText.Font = New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point)
            End If
        End Set
    End Property

    Public Overridable Property Lit() As Boolean
        Get
            Return isLit
        End Get
        Set(ByVal value As Boolean)
            isLit = value
            litBuffer = isLit

            If isLit Then
                Me.BackgroundImage = NormalButton
                Me.Refresh()
            Else
                Me.BackgroundImage = UnLitButton
                Me.Refresh()
            End If
        End Set
    End Property

    Public Property RedAlert() As LCARSalert
        Get
            Return inRedAlert
        End Get
        Set(ByVal value As LCARSalert)
            inRedAlert = value
            If inRedAlert = LCARSalert.Normal Then
                RA = False
            Else
                RA = True
            End If
            DrawAllButtons()
        End Set
    End Property

    Public Overridable Property Beeping() As Boolean
        Get
            Return doBeep
        End Get
        Set(ByVal value As Boolean)
            doBeep = value
        End Set
    End Property

#End Region

#Region " Subs "
    <System.Diagnostics.DebuggerStepThrough()> _
    Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Try
            If canClick = False Then

                If m.Msg = lButtonClick Or m.Msg = lButtonUp Or m.Msg = lButtonDouble _
                Or m.Msg = rButtonClick Or m.Msg = rButtonUp Or m.Msg = rButtonDouble _
                Or m.Msg = mButtonClick Or m.Msg = mButtonUp Or m.Msg = mButtonDouble Then

                    Return

                End If
            End If

            If m.Msg = lButtonDouble Then
                m.Msg = lButtonClick
            End If

            MyBase.WndProc(m)
        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub ScaleControl(ByVal factor As System.Drawing.SizeF, ByVal specified As System.Windows.Forms.BoundsSpecified)
        Me.ButtonTextHeight = textHeight * factor.Height
        ' lblText.Scale(factor)
        MyBase.ScaleControl(factor, specified)
    End Sub

    Public Sub lblText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblText.Click
        If Me.canClick Then
            RaiseEvent Click(Me, e) 'pass clicks of the label onto the button.
            buttonDown()
        End If
    End Sub


    Private Sub lblText_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblText.DoubleClick
        If Me.canClick Then
            RaiseEvent Click(Me, e) 'pass clicks of the label onto the button.
            buttonDown()
        End If
    End Sub

    Public Sub lblText_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles lblText.MouseEnter
        myText = lblText.Text
        If Me.CreateGraphics.MeasureString(lblText.Text, lblText.Font).Width > lblText.Width Then
            tmrTextScroll.Interval = 200
            tmrTextScroll.Enabled = True
            oAlign = lblText.TextAlign
            lblText.AutoEllipsis = True
            If lblText.TextAlign < 16 Then
                'bottom aligned
                lblText.TextAlign = ContentAlignment.BottomLeft
            ElseIf lblText.TextAlign < 256 Then
                'middle aligned
                lblText.TextAlign = ContentAlignment.MiddleLeft
            Else
                'top aligned
                lblText.TextAlign = ContentAlignment.TopLeft

            End If
        End If

    End Sub

    Public Sub lblText_MouseLeave(ByVal sener As Object, ByVal e As EventArgs) Handles lblText.MouseLeave
        tmrTextScroll.Enabled = False
        lblText.AutoEllipsis = False

        If oAlign > 0 Then
            lblText.TextAlign = oAlign
        End If

        lblText.Text = myText

    End Sub

    Private Sub tmrTextScroll_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrTextScroll.Tick
        'Static tmpText As String
        'If tmpText = "" Then
        '    tmpText = myText
        'Else
        '    tmpText = tmpText.Substring(1) & " "
        '    If tmpText.Trim = "" Then
        '        tmpText = myText
        '    End If
        'End If
        'lblText.Text = tmpText
        Static tmpStr As String


        If tmpStr = "" Then

            tmpStr = myText & "              "
        Else
            tmpStr = tmpStr.Substring(1) & tmpStr.Substring(0, 1)
        End If

        lblText.Text = tmpStr




    End Sub

    Public Sub doClick(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Click
        If Me.canClick Then
            RaiseEvent Click(Me, e) 'allow the user to create a click event (for voice commands)
        End If
    End Sub

    'Public Shadows Sub doubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.DoubleClick
    '    If Me.canClick Then
    '        RaiseEvent Click(Me, e) 'If the user clicks quickly, react as two clicks instead of a doubleclick event.
    '    End If
    'End Sub

    Private Sub flashThread()
        Do Until flashing = False

            If isFlashing Then
                isFlashing = False
                Me.BackgroundImage = NormalButton
            Else
                isFlashing = True
                Me.BackgroundImage = UnLitButton
            End If

            Windows.Forms.Application.DoEvents()
            Threading.Thread.Sleep(flashingInterval)
        Loop
    End Sub

    Private Sub SoundThread()
        Dim soundPath As String = GetSetting("LCARS X32", "Application", "ButtonSound", Application.StartupPath & "\207.wav")
        If System.IO.File.Exists(soundPath) Then
            Sound = New System.Media.SoundPlayer(soundPath)
        Else
            Sound = New System.Media.SoundPlayer(My.Resources._207)
        End If
        Sound.Play()
    End Sub

    Public Sub DrawAllButtons()
        If noDraw = False Then
            If Not (Me.Width = 0 Or Me.Height = 0) Then
                If textHeight = -1 Then
                    ButtonTextHeight = -1 'resize the text

                End If
                'Draw and show the standard "normal" button.
                '----------------------------------------------------------------------
                NormalButton = DrawButton()

                'Draw the button that is displayed when the function of the button is 
                'unavailable or disabled.
                '-----------------------------------------------------------------------
                UnLitButton = drawUnlit(NormalButton)

                Lit = isLit
            End If
        End If
    End Sub

    Public Overridable Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        CheckForIllegalCrossThreadCalls = False
        Me.lblText.Size = Me.Size
    End Sub

    Private Sub Button_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DrawAllButtons()
    End Sub

    Private Sub lblText_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblText.MouseDown
        If canClick Then
            RaiseEvent MouseDown(Me, e)
            GenericButton_MouseDown(Me, e)
        End If
    End Sub
    Private Sub lblText_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblText.MouseMove
        If canClick Then
            RaiseEvent MouseMove(Me, e)
        End If
    End Sub



    Private Sub lblText_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblText.MouseUp
        If canClick Then
            RaiseEvent MouseUp(Me, e)
            GenericButton_MouseUp(Me, e)
        End If
    End Sub

    Private Sub GenericButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'Dim DownThread As Threading.Thread = New Threading.Thread(AddressOf buttonDown)
        'DownThread.Start()
        Dim lcarsColor As New LCARScolor
        If lcarsColor.getColor(myColor).ToArgb = System.Drawing.Color.White.ToArgb Then
            inRedAlert = LCARSalert.Red
        Else
            inRedAlert = LCARSalert.White
        End If
        DrawAllButtons()
    End Sub

    Private Sub GenericButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        If RA = False Then
            Me.RedAlert = LCARSalert.Normal
        End If
    End Sub

    Private Sub buttonDown()
        If doBeep Then
            playSound = New Threading.Thread(AddressOf SoundThread)
            playSound.Start()
        End If
    End Sub

#End Region

#Region " Draw Generic Button "

    Public Overridable Function DrawButton() As Bitmap
        Dim mybitmap As Bitmap
        Dim g As Graphics
        Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(myColor))

        If inRedAlert = 1 Then
            myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
        ElseIf inRedAlert = LCARSalert.White Then
            myBrush = New Drawing.SolidBrush(Drawing.Color.White)
        ElseIf inRedAlert = LCARSalert.Yellow Then
            myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
        End If

        Dim myfont As Font = New Font("LCARS", (Me.Height \ 2) + 4, FontStyle.Regular, GraphicsUnit.Point)

        mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
        g = Graphics.FromImage(mybitmap)

        Dim textSize As SizeF = g.MeasureString(lblText.Text, myfont)

        g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

        g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
        g.FillRectangle(myBrush, Me.Size.Height \ 2, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
        g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)

        Return mybitmap
    End Function

#End Region

#Region " Draw Unlit Button "

    Private Function drawUnlit(ByVal normal As Bitmap) As Bitmap
        Dim fadeColor As Drawing.Color = Drawing.Color.FromArgb(128, 0, 0, 0)
        Dim mybitmap As Bitmap = New Bitmap(normal) 'make a copy of the normal button.
        Dim g As Graphics = Graphics.FromImage(mybitmap)
        Dim mybrush As New Drawing.SolidBrush(fadeColor)

        g.FillRectangle(mybrush, 0, 0, mybitmap.Width, mybitmap.Height)
        Return mybitmap
    End Function

#End Region

End Class
#End Region

#Region " GenericButton Designer "


Public Class GenericButtonDesigner
    'We had to import some extra classes to be able to use this, so scroll all the way up to
    'see which ones (they are commented).
    Inherits ControlDesigner
    Protected Overrides Sub PostFilterProperties(ByVal Properties As System.Collections.IDictionary)
        Dim myButton As New LCARSControls.FlatButton

        Properties.Remove("AccessibleName")
        Properties.Remove("AccessibleRole")
        Properties.Remove("AccessibleDescription")
        Properties.Remove("AllowDrop")
        Properties.Remove("BackColor")
        Properties.Remove("BackgroundImageLayout")
        Properties.Remove("CausesValidation")
        Properties.Remove("ContextMenuStrip")
        Properties.Remove("Enabled")
        Properties.Remove("Font")
        Properties.Remove("ForeColor")
        Properties.Remove("GenerateMember")
        Properties.Remove("ImeMode")
        Properties.Remove("Locked")
        Properties.Remove("Margin")
        Properties.Remove("MaximumSize")
        Properties.Remove("MinimumSize")
        Properties.Remove("Modifiers")
        Properties.Remove("Padding")
        Properties.Remove("RightToLeft")
    End Sub

End Class

#End Region

#End Region

#Region " Specific Controls "

Namespace LCARSControls

#Region " Standard Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class StandardButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "StandardButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Global Varibles "
        Dim myButtonType As LCARSbuttonStyles = LCARSbuttonStyles.Pill
#End Region

#Region " Properties "
        Public Property ButtonStyle() As LCARSbuttonStyles
            Get
                Return myButtonType
            End Get
            Set(ByVal value As LCARSbuttonStyles)
                myButtonType = value
                Me.DrawAllButtons()
            End Set
        End Property
#End Region

#Region " Subs "


        Public Overrides Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
            CheckForIllegalCrossThreadCalls = False
        End Sub

#End Region

#Region " Draw Standard Button "

#Region " Structures "

        Public Enum LCARSbuttonStyles
            Pill = 0
            RoundedSquare = 1
            RoundedSquareSlant = 2
            RoundedSquareBackSlant = 3
        End Enum


#End Region

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim halfHeight As Integer
            Dim quarterHeight As Integer
            Dim quarterWidth As Integer
            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            halfHeight = Me.Height \ 2
            quarterHeight = Me.Height \ 4
            quarterWidth = Me.Width \ 4



            If myButtonType = LCARSbuttonStyles.Pill Then
                g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
                g.FillRectangle(myBrush, halfHeight, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
                g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)


                Me.lblTextLoc = New Point(Me.Height \ 2, 0)
                Me.lblTextSize = New Size(Me.Width - Me.Height, Me.Height)

            Else
                g.FillEllipse(myBrush, New Rectangle(0, 0, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, 0, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(0, Me.Height - quarterHeight, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, Me.Height - quarterHeight, quarterHeight, quarterHeight))

                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, 0, Me.Width - quarterHeight, quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, Me.Height - quarterHeight, Me.Width - quarterHeight, quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(0, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(Me.Width - quarterHeight, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, quarterHeight \ 2, Me.Width - quarterHeight, Me.Height - quarterHeight))

                Select Case myButtonType
                    Case LCARSbuttonStyles.RoundedSquareSlant

                        Dim slant As Bitmap = New Bitmap(mybitmap)

                        Dim mypoints(2) As Point

                        mypoints(0) = New Point(Me.Width \ 4, 0)
                        mypoints(1) = New Point(Me.Width, 0)
                        mypoints(2) = New Point(0, Me.Height)

                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
                        g.DrawImage(slant, mypoints)

                        Me.lblTextLoc = New Point(Me.Width \ 4, 0)
                        Me.lblTextSize = New Size(Me.Width - (Me.Width \ 2), Me.Height)
                    Case LCARSbuttonStyles.RoundedSquareBackSlant

                        Dim slant As Bitmap = New Bitmap(mybitmap)

                        Dim mypoints(2) As Point

                        mypoints(0) = New Point(0, 0)
                        mypoints(1) = New Point(Me.Width - (Me.Width \ 4), 0)
                        mypoints(2) = New Point(Me.Width \ 4, Me.Height)

                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
                        g.DrawImage(slant, mypoints)

                        Me.lblTextLoc = New Point(Me.Width \ 4, 0)
                        Me.lblTextSize = New Size(Me.Width - (Me.Width \ 2), Me.Height)
                    Case Else
                        Me.lblTextLoc = New Point(0, 0)
                        Me.lblTextSize = New Size(Me.Width, Me.Height)
                End Select

            End If




            Return mybitmap
        End Function

#End Region

    End Class
#End Region

#Region " Half-Pill Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class HalfPillButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'HalfPillButton
            '
            Me.Name = "HalfPillButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region
        Dim _ButtonType As LCARSbuttonStyles = LCARSbuttonStyles.PillRight
#Region " Properties "

        Public Property ButtonStyle() As LCARSbuttonStyles
            Get
                Return _ButtonType
            End Get
            Set(ByVal value As LCARSbuttonStyles)
                _ButtonType = value
                Me.DrawAllButtons()
            End Set
        End Property

        '<DefaultValue(LCARS.LCARScolorStyles.NavigationFunction)> _
        'Public Property Color() As LCARS.LCARScolorStyles
        '    Get
        '        Return myColor
        '    End Get
        '    Set(ByVal value As LCARS.LCARScolorStyles)
        '        myColor = value
        '        DrawAllButtons()
        '    End Set
        'End Property

        '<DefaultValue("Standard Button")> _
        'Public Property ButtonText() As String
        '    Get
        '        Return myText
        '    End Get
        '    Set(ByVal value As String)
        '        myText = value
        '        DrawAllButtons()
        '    End Set
        'End Property

        'Public Property Lit() As Boolean
        '    Get
        '        Return isLit
        '    End Get
        '    Set(ByVal value As Boolean)
        '        isLit = value
        '        If isLit Then
        '            Me.BackgroundImage = NormalButton
        '            Me.Refresh()
        '        Else
        '            Me.BackgroundImage = UnLitButton
        '            Me.Refresh()
        '        End If
        '    End Set
        'End Property

#End Region

#Region " Hide Properties from View "
        '        <Browsable(False)> _
        '        Public Overrides Property text() As String
        '            Get
        '                Return ""
        '            End Get
        '            Set(ByVal value As String)
        '            End Set
        '        End Property

        '        <Browsable(False)> _
        '        Public Overrides Property BackColor() As Color
        '            Get
        '            End Get
        '            Set(ByVal value As Color)
        '            End Set
        '        End Property

        '        <Browsable(False)> _
        '                    Public Overrides Property contextmenu() As System.Windows.Forms.ContextMenu
        '            Get
        '                Return Nothing
        '            End Get
        '            Set(ByVal value As System.Windows.Forms.ContextMenu)
        '            End Set
        '        End Property

        '        <Browsable(False)> _
        '                    Public Overrides Property contextmenustrip() As System.Windows.Forms.ContextMenuStrip
        '            Get
        '                Return Nothing
        '            End Get
        '            Set(ByVal value As System.Windows.Forms.ContextMenuStrip)
        '            End Set
        '        End Property

        '        <Browsable(False)> _
        '            Public Overrides Property foreColor() As Color
        '            Get
        '                Return Nothing
        '            End Get
        '            Set(ByVal value As Color)
        '            End Set
        '        End Property

#End Region

#Region " Subs "
        'Private Sub SoundThread()
        '    Dim Sound As New System.Media.SoundPlayer(My.Resources._207)
        '    Sound.Play()
        'End Sub
        'Private Sub DrawAllButtons()
        '    'Draw and show the standard "normal" button.
        '    '----------------------------------------------------------------------
        '    NormalButton = DrawHalfPill()

        '    'Draw the button that is displayed when the function of the button is 
        '    'unavailable or disabled.
        '    '-----------------------------------------------------------------------
        '    UnLitButton = drawUnlit(NormalButton)

        '    'Draw the button that is displayed when the mouse is down (white button)
        '    '-----------------------------------------------------------------------

        '    'Temporarily copy the current color so we can reset it when we are done.
        '    colorBuffer = myColor
        '    'Set 'mycolor' to white
        '    myColor = LCARScolorStyles.PrimaryFunction
        '    'draw the down button and store it for later use.
        '    DownButton = DrawHalfPill()

        '    'reset the button color back to normal
        '    myColor = colorBuffer

        '    Lit = isLit
        'End Sub
        'Private Sub HalfPillButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        '    DrawAllButtons()
        'End Sub

        'Private Sub HalfPillButton_resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        '    DrawAllButtons()
        'End Sub

        'Private Sub HalfPillButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        '    Me.BackgroundImage = DownButton
        '    playSound = New Threading.Thread(AddressOf SoundThread)
        '    playSound.Start()
        'End Sub

        'Private Sub HalfPillButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        '    Lit = isLit
        'End Sub

#End Region

#Region " Draw Half-Pill Button "
#Region " Structures "

        Public Enum LCARSbuttonStyles
            PillRight = 0
            PillLeft = 1
            'RoundedSquareSlant = 2
            'RoundedSquareBackSlant = 3
        End Enum

#End Region

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            Select Case _ButtonType
                Case LCARSbuttonStyles.PillRight

                    g.FillRectangle(myBrush, 0, 0, Me.Size.Width - (Me.Size.Height \ 2), Me.Size.Height)
                    g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)


                    Me.lblTextSize = New Point(Me.Width - (Me.Height \ 2), Me.Height)

                Case LCARSbuttonStyles.PillLeft

                    Dim width As Integer
                    width = Me.Width - (Me.Height \ 2)

                    g.FillRectangle(myBrush, Me.Width - width, 0, width, Me.Size.Height)
                    g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)


                    Me.lblTextSize = New Point(width, Me.Height)
                    Me.lblTextLoc = New Point(Me.Width - width, Me.lblTextLoc.Y)


            End Select

            Return mybitmap
        End Function

#End Region

#Region " Draw Unlit Standard Button "

        'Private Function drawUnlit(ByVal normal As Bitmap) As Bitmap
        '    Dim fadeColor As Drawing.Color = Drawing.Color.FromArgb(180, 0, 0, 0)
        '    Dim mybitmap As Bitmap = New Bitmap(normal) 'make a copy of the normal button.
        '    Dim g As Graphics = Graphics.FromImage(mybitmap)
        '    Dim mybrush As New Drawing.SolidBrush(fadeColor)

        '    g.FillRectangle(mybrush, 0, 0, mybitmap.Width, mybitmap.Height)
        '    Return mybitmap
        'End Function

#End Region

#Region " Get Standard Color from LCARSbuttonStyles  "
        'Private Function getColor(ByVal index As LCARScolorStyles) As Color
        '    Dim code As String

        '    Select Case index
        '        Case 0
        '            code = "#3366CC"
        '        Case 1
        '            code = "#99CCFF"
        '        Case 2
        '            code = "#CC99CC"
        '        Case 3
        '            code = "#FFCC00"
        '        Case 4
        '            code = "#FFFF99"
        '        Case 5
        '            code = "#CC6666"
        '        Case 6
        '            code = "#FFFFFF"
        '        Case 7
        '            code = "#FF0000"
        '        Case 8
        '            code = "#FFCC66"
        '        Case 9
        '            code = ColorTranslator.ToHtml(System.Drawing.Color.Orange)
        '        Case 10
        '            code = "#99CCFF"
        '        Case Else
        '            MsgBox("'INVALID COLOR CODE' recieved in function 'getColor'.  Please check your code and try again.", MsgBoxStyle.Exclamation, "ERROR!")
        '            Exit Function
        '    End Select

        '    Return ColorTranslator.FromHtml(code)
        'End Function
#End Region

    End Class
#End Region

#Region " Complex Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class ComplexButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "ComplexButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Global Variables "

        Dim strSideText As String = "47"
        Dim staticWidth As Integer = -1
        Dim SideColor As LCARScolorStyles = LCARScolorStyles.Orange
        Dim sideBoxColor As LCARScolorStyles = LCARScolorStyles.Orange
        Dim Sound As New System.Media.SoundPlayer(My.Resources._207)

#End Region

#Region " Properties "

        Public Property SideText() As String
            Get
                Return strSideText
            End Get
            Set(ByVal value As String)
                strSideText = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideTextWidth() As Integer
            Get
                Return staticWidth
            End Get
            Set(ByVal value As Integer)
                staticWidth = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideTextColor() As LCARScolorStyles
            Get
                Return SideColor
            End Get
            Set(ByVal value As LCARScolorStyles)
                SideColor = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideBlockColor() As LCARScolorStyles
            Get
                Return sideBoxColor
            End Get
            Set(ByVal value As LCARScolorStyles)
                sideBoxColor = value
                DrawAllButtons()
            End Set
        End Property

#End Region

#Region " Subs "

        Public Overrides Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
            CheckForIllegalCrossThreadCalls = False
        End Sub


#End Region


#Region " Draw Complex Button "
        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim buttonTextSize As SizeF
            Dim sideTextSize As SizeF
            Dim curLeft As Integer = 0
            Dim textFont As Font = New Font("LCARS", (Me.Height \ 2) + 4, FontStyle.Regular, GraphicsUnit.Pixel)
            Dim sideFont As Font = New Font("LCARS", Me.Height + (Me.Height / 2.9), FontStyle.Regular, GraphicsUnit.Pixel)
            Dim myBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim sideBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(sideBoxColor))
            Dim sideTextBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(SideColor))

            If inRedAlert = 1 Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.Red)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf inRedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.White)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf inRedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            If strSideText Is Nothing Then
                strSideText = "47"
            End If

            'initialize the graphics
            mybitmap = New Bitmap(Me.Width, Me.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality


            'get the width and height of the fonts
            buttonTextSize = g.MeasureString(Me.ButtonText.ToUpper, textFont)
            sideTextSize = g.MeasureString(strSideText.ToUpper, sideFont)

            'draw the left orange block.  If the mouse is down, draw it white.
            g.FillRectangle(sideBrush, 0, 0, Me.Height \ 2, Me.Height)

            'set the curleft to the right side of what we have already drawn.
            curLeft = Me.Height \ 2

            If staticWidth > -1 Then
                curLeft += staticWidth - sideTextSize.Width
            Else
                curLeft -= Me.Height \ 5
            End If

            'draw the side text

            g.DrawString(strSideText.ToUpper, sideFont, sideTextBrush, curLeft, -Me.Height / 4.7)

            If strSideText <> "" Then
                curLeft = (curLeft + sideTextSize.Width) - (Me.Height \ 6)
            Else
                curLeft = curLeft + (Me.Height \ 10)
            End If

            'draw the main button area
            g.FillRectangle(myBrush, curLeft, 0, (Me.Width - curLeft) - (Me.Height + (Me.Height \ 10)), Me.Height)
            Me.lblTextLoc = New Point(curLeft, 0)
            Me.lblTextAnchor = AnchorStyles.None
            Me.lblTextSize = New Point((Me.Width - curLeft) - (Me.Height \ 2), Me.Height)

            curLeft += (Me.Width - curLeft) - (Me.Height + (Me.Height \ 10))

            'draw the button text

            ' g.DrawString(Me.ButtonText.ToUpper, textFont, Brushes.Black, curLeft - (buttonTextSize.Width + (Me.Height \ 10)), (Me.Height \ 2) - (Me.Height \ 10))

            curLeft -= Me.Height \ 10

            'draw the straight section of the right side pill shape
            g.FillRectangle(myBrush, curLeft, 0, Me.Height \ 2, Me.Height)

            'draw the curved end
            g.FillEllipse(myBrush, curLeft, 0, Me.Height, Me.Height)

            Return mybitmap

        End Function
#End Region

    End Class
#End Region

#Region " Text Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class TextButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "TextButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ButtonTextHeight = 24

            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Global Variables "

        Dim myType As TextButtonType = TextButtonType.DoublePills
        Dim myTextAlign As ContentAlignment = ContentAlignment.MiddleRight
        Dim textSize As FontData
        'Dim textHeight As Integer
        'Dim myText As String = "LCARS"

#End Region

#Region " Enums"

        Public Enum TextButtonType
            NoPills = 0
            DoublePills = 1
            LeftPill = 2
            RightPill = 3
        End Enum

        Public Structure FontData
            Dim Left, Top, Right, Bottom, Width, Height As Integer
        End Structure

#End Region

#Region " Properties "

        Public Property ButtonType() As TextButtonType
            Get
                Return myType
            End Get
            Set(ByVal value As TextButtonType)
                myType = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Overrides Property ButtonTextAlign() As System.Drawing.ContentAlignment
            Get
                Return myTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                myTextAlign = value
                Me.DrawAllButtons()
            End Set
        End Property


        Public Shadows Property ButtonTextHeight() As Integer
            Get
                Return textHeight
            End Get
            Set(ByVal value As Integer)
                textHeight = value
                textSize = getFontDimmensions(New Font("LCARS", value, FontStyle.Regular, GraphicsUnit.Point), ButtonText)
                Me.DrawAllButtons()
            End Set
        End Property

        Public Overrides Property ButtonText() As String
            Get
                Return myText
            End Get
            Set(ByVal value As String)
                myText = value.ToUpper
                textSize = getFontDimmensions(New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point), myText)
                Me.DrawAllButtons()
            End Set
        End Property

#End Region



#Region " Functions "

        Private Function getFontDimmensions(ByVal myFont As Font, ByVal Text As String) As FontData
            Dim myData As FontData = New FontData
            Dim x, y As Integer
            Dim myG As Graphics
            myFont = New Font("LCARS", ButtonTextHeight, FontStyle.Regular, GraphicsUnit.Point)
            Dim textSize As SizeF = Me.CreateGraphics.MeasureString(Text, myFont)
            If Text = "" Then
                Return New FontData
            End If



            Dim mybitmap As Bitmap = New Bitmap(Convert.ToInt16(textSize.Width), Convert.ToInt16(textSize.Height))

            myG = Graphics.FromImage(mybitmap)
            myG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            myG.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            myG.DrawString(Text, myFont, Brushes.Black, 0, 0)

            myData.Left = mybitmap.Width
            myData.Top = mybitmap.Height
            myData.Bottom = 0
            myData.Right = 0

            For x = 0 To mybitmap.Width - 1
                For y = 0 To mybitmap.Height - 1
                    If mybitmap.GetPixel(x, y).ToArgb = Drawing.Color.Black.ToArgb Then
                        If myData.Left > x Then
                            myData.Left = x
                        End If

                        If myData.Top > y Then
                            myData.Top = y
                        End If

                        If myData.Right < x Then
                            myData.Right = x
                        End If

                        If myData.Bottom < y Then
                            myData.Bottom = y
                        End If
                    End If
                Next
            Next

            myData.Height = myData.Bottom - myData.Top
            myData.Width = myData.Right - myData.Left

            Return myData

        End Function

#End Region

#Region " Draw TextButton "

        Public Overrides Function DrawButton() As Bitmap
            If Me.Width > 0 And Me.Height > 0 Then
                Dim mybitmap As Bitmap = New Bitmap(1, 1)
                If Me.ButtonTextHeight > 0 Then
                    Me.lblTextVisible = False

                    Dim g As Graphics
                    Dim mybrush As Drawing.SolidBrush = New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
                    Dim myfont As Font = New Font("LCARS", Me.ButtonTextHeight, FontStyle.Regular, GraphicsUnit.Point)
                    Dim drawHeight As Integer

                    If Me.RedAlert = LCARSalert.Red Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.Red)
                    ElseIf Me.RedAlert = LCARSalert.White Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.White)
                    ElseIf Me.RedAlert = LCARSalert.Yellow Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                    End If

                    If textSize.Height = 0 Then
                        textSize = New FontData
                        textSize.Height = Me.Height
                    End If

                    mybitmap = New Bitmap(Me.Size.Width, textSize.Height)
                    g = Graphics.FromImage(mybitmap)

                    If InStr(Me.ButtonText.ToUpper, "Q") > 0 Then
                        drawHeight = textSize.Height - (textSize.Height \ 10)
                        Me.Height = mybitmap.Height
                    Else
                        drawHeight = textSize.Height
                        Me.Height = drawHeight
                    End If



                    'Draw black background
                    g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

                    'Set graphics to use smoothing
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

                    Select Case myType
                        Case TextButtonType.DoublePills
                            g.FillEllipse(mybrush, 0, 0, drawHeight, drawHeight)
                            g.FillEllipse(mybrush, Me.Width - drawHeight, 0, drawHeight, drawHeight)
                            g.FillRectangle(Brushes.Black, drawHeight \ 2, 0, Me.Width - drawHeight, drawHeight)
                            g.FillRectangle(mybrush, drawHeight \ 2, 0, drawHeight \ 2, drawHeight)
                            g.FillRectangle(mybrush, drawHeight + 6, 0, (Me.Width - (drawHeight * 2)) - 12, drawHeight)
                            g.FillRectangle(mybrush, Me.Width - drawHeight, 0, drawHeight \ 2, drawHeight)
                    End Select
                    If Me.ButtonText <> "" Then
                        If InStr(myTextAlign.ToString.ToLower, "right") > 0 Then
                            g.FillRectangle(Brushes.Black, Me.Width - ((textSize.Width + drawHeight) + 12), 0, textSize.Width + 6, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, Me.Width - (((textSize.Width + textSize.Left) + drawHeight) + 6), -textSize.Top)
                        End If

                        If InStr(myTextAlign.ToString.ToLower, "left") > 0 Then
                            g.FillRectangle(Brushes.Black, drawHeight + 6, 0, textSize.Width + 6, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, (drawHeight - textSize.Left) + 6, -textSize.Top)
                        End If

                        If InStr(myTextAlign.ToString.ToLower, "center") > 0 Then
                            g.FillRectangle(Brushes.Black, (Me.Width \ 2) - ((textSize.Width + 12) \ 2), 0, textSize.Width + 12, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, ((Me.Width \ 2) - (textSize.Width \ 2)) - textSize.Left, -textSize.Top)
                        End If

                    End If


                    ''Draw the left pill shape
                    'g.FillEllipse(mybrush, 0, 0, Me.Size.Height, Me.Size.Height)
                    ''draw the uncurved portion of the pill shape
                    'g.FillRectangle(mybrush, (Me.Height \ 2) + 1, 0, Me.Height \ 2, Me.Height)

                    ''Draw the filler bar between the left pill shape and the text
                    'g.FillRectangle(mybrush, (Me.Height + (Me.Height \ 10) + 1), 0, (Me.Width - (textSize.Width + (Me.Height * 2))) + (Me.Height \ 5), Me.Height)

                    ''Draw the text
                    'Dim textBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(getColor(LCARScolorStyles.Orange))
                    'g.DrawString(Me.ButtonText.ToUpper, myfont, textBrush, (Me.Width - (textSize.Width + Me.Height)) + (Me.Height / 5), -(Me.Height / 4.7))

                    ''Draw the right pill shape
                    ''draw the stub
                    'g.FillRectangle(mybrush, Me.Width - Me.Height, 0, Me.Height \ 2, Me.Height)
                    ''draw the curved portion
                    'g.FillEllipse(mybrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)
                End If
                Return mybitmap
            Else
                Return New Bitmap(1, 1)
            End If
        End Function

#End Region

    End Class
#End Region

#Region " Flat Button "

    <System.ComponentModel.DefaultEvent("Click")> _
        Public Class FlatButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'FlatButtonButton
            '
            Me.Name = "FlatButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Subs "

        Private Sub FlatButton_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            Me.lblTextSize = Me.Size
        End Sub

#End Region

#Region " Draw Flat Button "

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New System.Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            Try
                mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            Catch ex As Exception
                mybitmap = New Bitmap(1, 1)
                mybitmap.SetPixel(0, 0, System.Drawing.Color.FromArgb(0, 0, 0, 0))

            End Try

            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(myBrush, 0, 0, mybitmap.Width, mybitmap.Height)

            'Select Case Me.ButtonTextAlign
            '    Case LCARStextStyles.TopLeft
            '        textLoc.X = 0
            '        textLoc.Y = 0
            '    Case LCARStextStyles.TopRight
            '        textLoc.X = (Me.Width - textSize.Width)
            '        textLoc.Y = 0

            '    Case LCARStextStyles.BottomLeft
            '        textLoc.X = 0
            '        textLoc.Y = (Me.Height - textSize.Height)

            '    Case LCARStextStyles.BottomRight
            '        textLoc.X = (Me.Width - textSize.Width)
            '        textLoc.Y = (Me.Height - textSize.Height)

            'End Select

            'g.DrawString(Me.ButtonText, myfont, Brushes.Black, textLoc.X, textLoc.Y)

            Return mybitmap
        End Function

#End Region

    End Class
#End Region

#Region " Elbow "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class Elbow
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "Elbow"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Structures "

        Public Enum LCARSelbowStyles
            UpperRight = 0
            LowerRight = 1
            UpperLeft = 2
            LowerLeft = 3
        End Enum

#End Region

#Region " Global Variables "

        Dim Style As LCARSelbowStyles
        ' Dim textAlign As LCARS.LCARStextStyles
        Dim barWidth As Integer = 200
        Dim barHeight As Integer = 25
        Dim ratio As Point = New Point(1, 1)
#End Region

#Region " Properties "

        Public Property ElbowRatio() As Point
            Get
                Return ratio
            End Get
            Set(ByVal value As Point)
                ratio = value
                Me.DrawAllButtons()
            End Set
        End Property


        Public Property ButtonWidth() As Integer
            Get
                Return barWidth
            End Get
            Set(ByVal value As Integer)
                barWidth = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Property ButtonHeight() As Integer
            Get
                Return barHeight
            End Get
            Set(ByVal value As Integer)
                barHeight = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Property ElbowStyle() As LCARSelbowStyles
            Get
                Return Style
            End Get
            Set(ByVal value As LCARSelbowStyles)
                Style = value
                Me.DrawAllButtons()
            End Set
        End Property

#End Region

#Region " Draw LCARS Style Elbows "

        Public Overrides Function DrawButton() As Bitmap

            Dim mybitmap As Bitmap = New Bitmap(Me.Width, Me.Height)
            Dim g As Graphics = Graphics.FromImage(mybitmap)
            Dim mybrush As System.Drawing.SolidBrush

            'set the brush to the selected color
            mybrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

            If Me.RedAlert = LCARSalert.Red Then
                mybrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                mybrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                mybrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            'Draw smooth curves (takes longer but looks oh so good!)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            'fill the background with black
            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            'draw the first elipse the size of the elbow
            g.FillEllipse(mybrush, 0, 0, Me.Height, Me.Height)


            g.FillRectangle(mybrush, 0, (Me.Height) \ 2, barWidth, (Me.Height \ 2) + (Me.Height \ 4))

            g.FillRectangle(mybrush, Me.Height \ 2, 0, Me.Width - (Me.Height \ 2), barHeight)

            g.FillRectangle(mybrush, Me.Height \ 2, barHeight, barWidth - (Me.Height \ 2), Me.Height - barHeight)

            g.FillRectangle(Brushes.Black, barWidth, barHeight, Me.Width - barWidth, Me.Height - barHeight)

            g.FillRectangle(mybrush, barWidth, barHeight, Me.Height \ 4, Me.Height \ 4)

            g.FillEllipse(Brushes.Black, barWidth, barHeight, Me.Height \ 2, Me.Height \ 2)

            Dim buffer As Bitmap = New Bitmap(mybitmap)
            Dim myPoints(2) As Point

            Select Case Style
                Case LCARSelbowStyles.UpperRight
                    myPoints(0) = New Point(Me.Width, 0)
                    myPoints(1) = New Point(0, 0)
                    myPoints(2) = New Point(Me.Width, Me.Height)
                Case LCARSelbowStyles.LowerRight
                    myPoints(0) = New Point(Me.Width, Me.Height)
                    myPoints(1) = New Point(0, Me.Height)
                    myPoints(2) = New Point(Me.Width, 0)
                Case LCARSelbowStyles.LowerLeft
                    myPoints(0) = New Point(0, Me.Height)
                    myPoints(1) = New Point(Me.Width, Me.Height)
                    myPoints(2) = New Point(0, 0)

            End Select

            g.DrawImage(buffer, myPoints)

            Return mybitmap

            mybitmap = Nothing
            g = Nothing
            mybrush.Dispose()
            GC.Collect()

        End Function
#End Region

    End Class
#End Region

#Region " Arrow Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class ArrowButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "ArrowButton"
            Me.Size = New System.Drawing.Size(50, 50)
            Me.ButtonText = ""
            Me.Text = ""
            Me.ResumeLayout(False)


        End Sub
#End Region

#Region " Global Variables "
        Dim ArrowDir As LCARSarrowDirection = LCARSarrowDirection.Up
#End Region

#Region " Properties "
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property Text() As String
            Get
                Return ""
            End Get
            Set(ByVal value As String)
                MyBase.Text = ""
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonText() As String
            Get
                Return ""
            End Get
            Set(ByVal value As String)
                MyBase.ButtonText = ""
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonTextAlign() As System.Drawing.ContentAlignment
            Get
                Return MyBase.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                MyBase.ButtonTextAlign = value
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonTextHeight() As Integer
            Get
                Return MyBase.ButtonTextHeight
            End Get
            Set(ByVal value As Integer)
                MyBase.ButtonTextHeight = value
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property AutoEllipsis()
            Get
                Return Nothing
            End Get
            Set(ByVal value)

            End Set
        End Property


        Public Property ArrowDirection() As LCARSarrowDirection
            Get
                Return ArrowDir
            End Get
            Set(ByVal value As LCARSarrowDirection)
                ArrowDir = value
                Me.DrawAllButtons()
            End Set
        End Property
#End Region

#Region " Draw Arrow Button "

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim myPoints(2) As Point

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If


            mybitmap = New Bitmap(Me.Width, Me.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(myBrush, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            Select Case ArrowDir
                Case LCARSarrowDirection.Up
                    myPoints(0) = New Point(Me.Width \ 2, Me.Height \ 5)
                    myPoints(1) = New Point(Me.Width \ 5, Me.Height - (Me.Height \ 5))
                    myPoints(2) = New Point(Me.Width - (Me.Width \ 5), Me.Height - (Me.Height \ 5))
                Case LCARSarrowDirection.Down
                    myPoints(0) = New Point(Me.Width \ 5, Me.Height \ 5)
                    myPoints(1) = New Point(Me.Width - (Me.Width \ 5), Me.Height \ 5)
                    myPoints(2) = New Point(Me.Width \ 2, Me.Height - (Me.Height \ 5))
                Case LCARSarrowDirection.Left
                    myPoints(0) = New Point(Me.Width \ 5, Me.Height \ 2)
                    myPoints(1) = New Point(Me.Width - (Me.Width \ 5), Me.Height \ 5)
                    myPoints(2) = New Point(Me.Width - (Me.Width \ 5), Me.Height - (Me.Height \ 5))
                Case LCARSarrowDirection.Right
                    myPoints(0) = New Point(Me.Width - (Me.Width \ 5), Me.Height \ 2)
                    myPoints(1) = New Point(Me.Width \ 5, Me.Height \ 5)
                    myPoints(2) = New Point(Me.Width \ 5, Me.Height - (Me.Height \ 5))
            End Select


            g.FillPolygon(Brushes.Black, myPoints)

            Return mybitmap
        End Function

#End Region

    End Class
#End Region

#Region " Level Indicator "
    Public Class LevelIndicator
        Inherits LCARSbuttonClass

        Dim myColor2 As LCARScolorStyles
        Dim intMax As Integer = 100
        Dim intMin, intVal As Integer
        Dim mySize As Point

#Region " Properties "
        <DefaultValue(100)> _
                Public Property Color2() As LCARScolorStyles
            Get
                Return myColor2
            End Get
            Set(ByVal value As LCARScolorStyles)
                myColor2 = value
                Me.DrawAllButtons()
            End Set
        End Property


        <DefaultValue(100)> _
        Public Property Max() As Integer
            Get
                Return intMax
            End Get
            Set(ByVal value As Integer)
                If value > intMin Then
                    intMax = value
                    Me.DrawAllButtons()
                Else
                    MsgBox("The Max value MUST be greater than the Min value.")
                End If
            End Set
        End Property


        <DefaultValue(0)> _
      Public Property Min() As Integer
            Get
                Return intMin
            End Get
            Set(ByVal value As Integer)
                If value < intMax Then
                    intMin = value
                    Me.DrawAllButtons()
                Else
                    MsgBox("The Min value MUST be lesser than the Max value.")
                End If
            End Set
        End Property

        <DefaultValue(0)> _
      Public Property Value() As Integer
            Get
                Return intVal
            End Get
            Set(ByVal value As Integer)
                If value >= intMin And value <= Max Then
                    intVal = value
                    Me.DrawAllButtons()
                Else
                    MsgBox("The Value MUST be between Min and Max.")
                End If
            End Set
        End Property
#End Region

        Sub New()
            Clickable = False
            ButtonTextAlign = ContentAlignment.MiddleCenter
        End Sub






        Public Overrides Function DrawButton() As Bitmap

            Dim mybitmap As Bitmap = New Bitmap(Me.Width, Me.Height)
            Dim g As Graphics = Graphics.FromImage(mybitmap)
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim myBrush2 As New Drawing.SolidBrush(ColorsAvailable.getColor(myColor2))
            Dim valHeight As Integer

            If intVal > 0 Then
                valHeight = ((Me.Height - 20) * intVal) \ intMax
            Else
                valHeight = 0
            End If

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If

            g.FillRectangle(Brushes.Black, New Rectangle(0, 0, Me.Width, Me.Height))

            g.FillRectangle(myBrush, New Rectangle(20, 10, Me.Width - 40, Me.Height - 20))



            g.FillRectangle(myBrush2, New Rectangle(20, ((Me.Height - 10) - valHeight), Me.Width - 40, valHeight))

            Dim myStep As Integer = (Me.Height - 22) \ 20
            If myStep < 1 Then
                myStep = 1
            End If
            For intloop As Integer = 10 To Me.Height - 12 Step myStep
                If intloop Mod 5 = 0 Then
                    g.FillRectangle(myBrush, New Rectangle(5, (Me.Height - intloop) - 2, 15, 2))
                    g.FillRectangle(myBrush, New Rectangle(Me.Width - 20, (Me.Height - intloop) - 2, 15, 2))

                Else
                    g.FillRectangle(Brushes.Red, New Rectangle(10, (Me.Height - intloop) - 2, 10, 2))
                    g.FillRectangle(Brushes.Red, New Rectangle(Me.Width - 20, (Me.Height - intloop) - 2, 10, 2))

                End If

            Next

            If intMax - intMin > 0 Then
                Me.ButtonText = Int((intVal / (intMax - intMin)) * 100) & "%"
            Else
                Me.ButtonText = "0%"
            End If

            g.Dispose()

            Return mybitmap
        End Function

    End Class



#End Region

#Region "TabControl"
    '    Public Class LCARSTabControl
    '        Inherits TabControl
    '#Region "Global Variables"

    '        Private _HeaderWidth As Integer
    '        Private _HeaderHeight As Integer

    '        Private _HeaderAlignment As System.Drawing.ContentAlignment
    '        Private _HeaderPadding As System.Windows.Forms.Padding
    '        Private _HeaderFont As Font
    '        Private _HeaderBackColor As LCARS.LCARScolorStyles = LCARScolorStyles.MiscFunction ' As Color
    '        Private _HeaderBackBrush As SolidBrush
    '        Private _HeaderBorderColor As Color
    '        Private _HeaderBackPen As Pen
    '        Private _HeaderForeColor As Color
    '        Private _HeaderForeBrush As SolidBrush
    '        Private _HeaderSelectedBackColor As LCARS.LCARScolorStyles = LCARScolorStyles.PrimaryFunction  ' As Color
    '        Private _HeaderSelectedBackBrush As SolidBrush '(ColorsAvailable.getColor(_HeaderSelectedBackColor))
    '        Private _HeaderSelectedForeColor As Color
    '        Private _HeaderSelectedForeBrush As Brush

    '        Private _BackColor As Color
    '        Private _BackBrush As System.Drawing.SolidBrush

    '        Public ColorsAvailable As New LCARS.LCARScolor
    '        Dim myColor As LCARS.LCARScolorStyles = LCARScolorStyles.LCARSDisplayOnly
    '        Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(myColor))
    '        Dim myColorSelected As LCARS.LCARScolorStyles = LCARScolorStyles.MiscFunction
    '        Dim myBrushSelected As New Drawing.SolidBrush(ColorsAvailable.getColor(myColorSelected))
    '        Dim topelb As New LCARS.Controls.Elbow
    '        Dim topbar As New LCARS.Controls.HalfPillButton
    '        Dim topbar2 As New LCARS.Controls.StandardButton
    '        ' Dim tabbutton(TabPages.count) As LCARS.Controls.FlatButton

    '#End Region

    '#Region " Header Properties "
    '        <System.ComponentModel.DefaultValue(100)> _
    '        Public Property HeaderWidth() As Integer
    '            Get
    '                Return Me._HeaderWidth
    '            End Get
    '            Set(ByVal value As Integer)
    '                Me._HeaderWidth = value
    '                Me.ItemSize = New Size(Me.ItemSize.Width, value)
    '            End Set
    '        End Property

    '        <System.ComponentModel.DefaultValue(32)> _
    '        Public Property HeaderHeight() As Integer
    '            Get
    '                Return Me._HeaderHeight
    '            End Get
    '            Set(ByVal value As Integer)
    '                Me._HeaderHeight = value
    '                Me.ItemSize = New Size(value, Me.ItemSize.Height)
    '            End Set
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(System.Windows.Forms.Padding), "3,3,3,3")> _
    '        Public Property HeaderPadding() As System.Windows.Forms.Padding
    '            Get
    '                Return Me._HeaderPadding
    '            End Get
    '            Set(ByVal value As System.Windows.Forms.Padding)
    '                Me._HeaderPadding = value
    '                Me.Invalidate()
    '            End Set
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(Color), "black")> _
    '        Public Property HeaderBorderColor() As Color
    '            Get
    '                Return Me._HeaderBorderColor
    '            End Get
    '            Set(ByVal value As Color)
    '                If Not value = Me._HeaderBorderColor Then
    '                    Me._HeaderBorderColor = value
    '                    If Me._HeaderBackPen IsNot Nothing Then
    '                        Me._HeaderBackPen.Dispose()
    '                        Me._HeaderBackPen = Nothing
    '                    End If
    '                    Me.Invalidate()
    '                End If
    '            End Set
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(Color), "LightGray")> _
    '        Public Property HeaderBackColor() As LCARScolorStyles
    '            Get
    '                Return Me._HeaderBackColor
    '            End Get
    '            Set(ByVal value As LCARScolorStyles)
    '                If Not value = Me._HeaderBackColor Then
    '                    Me._HeaderBackColor = value
    '                    If Me._HeaderBackBrush IsNot Nothing Then
    '                        Me._HeaderBackBrush.Dispose()
    '                        Me._HeaderBackBrush = Nothing
    '                    End If
    '                    Me.Invalidate()
    '                End If
    '            End Set
    '        End Property

    '        Private ReadOnly Property HeaderBackBrush() As SolidBrush
    '            Get
    '                If Me._HeaderBackBrush Is Nothing Then
    '                    Me._HeaderBackBrush = New SolidBrush((ColorsAvailable.getColor(Me.HeaderBackColor)))
    '                End If
    '                Return Me._HeaderBackBrush
    '            End Get
    '        End Property

    '        Private ReadOnly Property HeaderPen() As Pen
    '            Get
    '                If Me._HeaderBackPen Is Nothing Then
    '                    Me._HeaderBackPen = New Pen(Me.HeaderBorderColor)
    '                End If
    '                Return Me._HeaderBackPen
    '            End Get
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(Color), "Black")> _
    '        Public Property HeaderForeColor() As Color
    '            Get
    '                Return Me._HeaderForeColor
    '            End Get
    '            Set(ByVal value As Color)
    '                If Not value = Me._HeaderForeColor Then
    '                    Me._HeaderForeColor = value
    '                    If Me._HeaderForeBrush IsNot Nothing Then
    '                        Me._HeaderForeBrush.Dispose()
    '                        Me._HeaderForeBrush = Nothing
    '                    End If
    '                    Me.Invalidate()
    '                End If
    '            End Set
    '        End Property

    '        Private ReadOnly Property HeaderForeBrush() As SolidBrush
    '            Get
    '                If Me._HeaderForeBrush Is Nothing Then
    '                    Me._HeaderForeBrush = New SolidBrush(Me.HeaderForeColor)
    '                End If
    '                Return Me._HeaderForeBrush
    '            End Get
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(Color), "DarkGray")> _
    '        Public Property HeaderSelectedBackColor() As LCARScolorStyles
    '            Get
    '                Return Me._HeaderSelectedBackColor
    '            End Get
    '            Set(ByVal value As LCARScolorStyles)
    '                If Not value = Me._HeaderSelectedBackColor Then
    '                    Me._HeaderSelectedBackColor = value
    '                    If Me._HeaderSelectedBackBrush IsNot Nothing Then
    '                        Me._HeaderSelectedBackBrush.Dispose()
    '                        Me._HeaderSelectedBackBrush = Nothing
    '                    End If
    '                    Me.Invalidate()
    '                End If
    '            End Set
    '        End Property

    '        Private ReadOnly Property HeaderSelectedBackBrush() As SolidBrush
    '            Get
    '                If Me._HeaderSelectedBackBrush Is Nothing Then
    '                    Me._HeaderSelectedBackBrush = New SolidBrush(ColorsAvailable.getColor(Me.HeaderSelectedBackColor))
    '                End If
    '                Return Me._HeaderSelectedBackBrush
    '            End Get
    '        End Property

    '        <System.ComponentModel.DefaultValue(GetType(Color), "Black")> _
    '        Public Property HeaderSelectedForeColor() As Color
    '            Get
    '                Return Me._HeaderSelectedForeColor
    '            End Get
    '            Set(ByVal value As Color)
    '                If Not value = Me._HeaderSelectedForeColor Then
    '                    Me._HeaderSelectedForeColor = value
    '                    Me._HeaderSelectedForeBrush.Dispose()
    '                    Me._HeaderSelectedForeBrush = Nothing
    '                    Me.Invalidate()
    '                End If
    '            End Set
    '        End Property

    '        Private ReadOnly Property HeaderSelectedForeBrush() As SolidBrush
    '            Get
    '                If Me._HeaderSelectedForeBrush Is Nothing Then
    '                    Me._HeaderSelectedForeBrush = New SolidBrush(Me.HeaderSelectedForeColor)
    '                End If
    '                Return Me._HeaderSelectedForeBrush
    '            End Get
    '        End Property

    '        Public Property HeaderFont() As Font
    '            Get
    '                Return Me._HeaderFont
    '            End Get
    '            Set(ByVal value As Font)
    '                Me._HeaderFont = value
    '                Me.Invalidate()
    '            End Set
    '        End Property
    '#End Region

    '#Region "properties"

    '        Enum TabAlignment
    '            Top = 0
    '            Right = 3
    '        End Enum

    '        <System.ComponentModel.Browsable(True)> _
    '        Public Shadows Property Alignment() As LCARSTabControl.TabAlignment
    '            Get
    '                Return MyBase.Alignment
    '            End Get
    '            Set(ByVal value As LCARSTabControl.TabAlignment)
    '                MyBase.Alignment = value
    '                If value = TabAlignment.Right Then
    '                    Me.HeaderHeight = 32
    '                    Me.HeaderWidth = 100
    '                Else
    '                    Me.HeaderHeight = 100
    '                    Me.HeaderWidth = 32
    '                End If
    '            End Set
    '        End Property

    '        Private ReadOnly Property BackBrush() As SolidBrush
    '            Get
    '                If Me._BackBrush Is Nothing Then
    '                    Me._BackBrush = New SolidBrush(Me.BackColor)
    '                End If
    '                Return Me._BackBrush
    '            End Get
    '        End Property

    '#End Region

    '        Public Sub New()
    '            Me._HeaderWidth = 100
    '            Me._HeaderHeight = 32
    '            Me._HeaderAlignment = ContentAlignment.MiddleCenter
    '            Me._HeaderPadding = New Padding(3)
    '            Me._BackColor = Color.Black
    '            Me._HeaderBorderColor = Color.Black
    '            Me._HeaderFont = New Font("LCARS", 14, FontStyle.Regular, GraphicsUnit.Point)
    '            Me._HeaderForeColor = Color.Black
    '            Me._HeaderBackColor = LCARScolorStyles.NavigationFunction
    '            Me._HeaderSelectedBackColor = LCARScolorStyles.PrimaryFunction
    '            Me._HeaderSelectedForeColor = Color.Black

    '            Me.DrawMode = TabDrawMode.OwnerDrawFixed
    '            Me.SizeMode = TabSizeMode.Fixed
    '            Me.Alignment = TabAlignment.Right

    '            Me.ItemSize = New Size(Me.HeaderHeight, Me.HeaderWidth)

    '            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    '            Me.SetStyle(ControlStyles.UserPaint, True)

    '            'Call Me.DrawTabButton2(0)

    '        End Sub

    '        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '            Dim g As Graphics
    '            ''Dim r As Rectangle = New Rectangle(0, 0, 100, 32) 'me.GetTabRect(1)
    '            'Dim barwidth As Integer = 100
    '            'Dim barheight As Integer = 15

    '            g = e.Graphics
    '            If Me.Alignment = TabAlignment.Right Then
    '                'new method of showing elbows and topbar
    '                If Not Parent.Controls.Contains(topelb) Then
    '                    'Me.Top += 50
    '                    'Me.Height -= 50
    '                    With topelb
    '                        .ElbowStyle = Elbow.LCARSelbowStyles.UpperLeft
    '                        .ButtonHeight = 15
    '                        .ButtonText = ""
    '                        .Top = Me.Top '- 52
    '                        If Me.Alignment = TabAlignment.Right Then
    '                            .Width = 120
    '                            .ButtonWidth = 100
    '                            .Height = 50
    '                            .Left = Me.Left + (Me.Width - 120)
    '                        Else
    '                            Me.HeaderWidth = 45
    '                            .ButtonWidth = 15
    '                            .ButtonHeight = 40
    '                            .Height = 50
    '                            .Width = 50
    '                            .Left = Me.Left + (Me.Width - 50)
    '                            'UI.MsgBox("This side alignment is incomplete...")
    '                        End If
    '                        .Color = LCARScolorStyles.LCARSDisplayOnly
    '                        Parent.Controls.Add(topelb)
    '                        .BringToFront()
    '                        .Clickable = False
    '                    End With
    '                    With topbar
    '                        If Me.Alignment = TabAlignment.Right Then
    '                            .ButtonStyle = HalfPillButton.LCARSbuttonStyles.PillLeft
    '                            .Height = 15
    '                            .Width = Me.Width - 125
    '                            .Left = Me.Left
    '                            .Top = Me.Top '- 52       
    '                            Parent.Controls.Add(topbar)
    '                            .BringToFront()
    '                        Else
    '                            'Dim topbar As New StandardButton
    '                            With topbar2
    '                                .ButtonStyle = StandardButton.LCARSbuttonStyles.RoundedSquareSlant
    '                                .Height = 45
    '                                .Width = Me.Width - 125
    '                                .Left = Me.Left
    '                                .Top = Me.Top '- 52
    '                                Parent.Controls.Add(topbar2)
    '                                .BringToFront()
    '                            End With
    '                        End If
    '                        .ButtonText = ""
    '                        .Color = LCARScolorStyles.LCARSDisplayOnly
    '                        .Clickable = False
    '                    End With
    '                End If
    '            Else

    '            End If




    '            g.FillRectangle(Me.BackBrush, e.ClipRectangle)      ' background

    '            'g.FillRectangle(Me.HeaderBackBrush, 0, 0, Me.Width, 25)
    '            'draw the first elipse the size of the elbow
    '            'g.FillEllipse(myBrush, Me.Width - r.Height, 3, r.Height, r.Height)

    '            'g.FillRectangle(myBrush, (Me.Width - r.Width), (r.Height) \ 2, barwidth, (r.Height \ 2) + (r.Height \ 4))

    '            ''g.FillRectangle(myBrush, (Me.Width - (r.Width + 16)), 4, (r.Width + 8), barheight + 3)

    '            ''g.FillRectangle(myBrush, (Me.Width - (r.Height \ 2)), barheight, barwidth - (r.Height \ 2), r.Height - barheight)

    '            'g.FillRectangle(Brushes.Blue, (Me.Width - barwidth - 5), barheight, r.Height \ 2, r.Height - barheight)

    '            'g.FillRectangle(Brushes.LimeGreen, Me.Width - barwidth, barheight, r.Height \ 4, r.Height \ 2)

    '            ''g.FillEllipse(Brushes.Black, (Me.Width - (r.Width + 16)), barheight + 2, r.Height \ 2, r.Height \ 2)
    '            If Me.Alignment = TabAlignment.Right Then
    '                For i As Integer = 0 To Me.TabPages.Count - 1

    '                    'Call Me.DrawTabButton(g, i)
    '                    Call Me.DrawTabButton2(i)
    '                    'Call Me.DrawTabText(g, i)
    '                Next

    '            Else
    '                For i As Integer = 0 To Me.TabPages.Count - 1
    '                    Call Me.DrawTabButton(g, i)
    '                    'Call Me.DrawTabButton3(i)
    '                    Call Me.DrawTabText(g, i)
    '                Next
    '            End If

    '        End Sub
    '        Private Sub DrawTabButton2(ByVal i As Integer)
    '            Dim tabbutton(TabPages.Count) As FlatButton
    '            If Not Parent.Controls.Contains(tabbutton(i)) Then
    '                tabbutton(i) = New FlatButton
    '                tabbutton(i).ButtonText = Me.TabPages(i).Text
    '                tabbutton(i).Top = Me.Top + (i * 37) + 55
    '                tabbutton(i).Left = (Me.Width + Me.Left) - 100
    '                tabbutton(i).Width = 100
    '                tabbutton(i).Height = 32
    '                tabbutton(i).Tag = i
    '                tabbutton(i).Color = LCARScolorStyles.NavigationFunction

    '                'Dim s As String = ""

    '                's = s & " " & Parent.Controls.Contains(tabbutton(0)).ToString
    '                'MsgBox(s)

    '                If tabbutton(i).Top < (Me.Height - 32) Then
    '                    Parent.Controls.Add(tabbutton(i))
    '                    tabbutton(i).BringToFront()
    '                    AddHandler tabbutton(i).Click, AddressOf OntabbuttonClick
    '                    's = s & " " & Parent.Controls.Contains(tabbutton(0)).ToString
    '                    'MsgBox(s)

    '                Else
    '                    Dim scrlbutton As New ArrowButton
    '                    'Dim tst As New TextBox
    '                    'Parent.Controls.Add(tst)
    '                    'For int As Integer = 0 To (Parent.Controls.Count - 1)
    '                    's = s & " " & Parent.Controls.Contains(tst).ToString
    '                    'Next
    '                    'MsgBox(s)
    '                    If Parent.Controls.Contains(scrlbutton) = False Then
    '                        'Parent.Controls.Add(tst)
    '                        's = s & " " & Parent.Controls.Contains(tabbutton(i)).ToString
    '                        'MsgBox(s)
    '                        'tabbutton(i).Visible = False
    '                        'tabbutton(i - 1).Visible = False
    '                        'scrlbutton.Visible = True
    '                        scrlbutton.Top = Me.Top + (i * 37) + 55
    '                        scrlbutton.Left = (Me.Width + Me.Left) - 100
    '                        scrlbutton.Width = 100
    '                        scrlbutton.Height = 32
    '                        Parent.Controls.Add(scrlbutton)
    '                        scrlbutton.BringToFront()
    '                        scrlbutton.Tag = i
    '                        scrlbutton.Color = LCARScolorStyles.NavigationFunction
    '                        AddHandler scrlbutton.Click, AddressOf OnscrlbuttonClick

    '                    End If
    '                End If
    '            End If
    '            If i = (TabPages.Count - 1) And tabbutton(i).Top < (Me.Top + Me.Height - 32) Then
    '                Dim bbar As New FlatButton
    '                bbar.Top = tabbutton(i).Top + 37
    '                bbar.Size = New Size(100, (Me.Top + Me.Height - tabbutton(i).Top - 37))
    '                bbar.Left = tabbutton(i).Left
    '                bbar.Color = LCARScolorStyles.LCARSDisplayOnly
    '                Parent.Controls.Add(bbar)
    '                bbar.BringToFront()
    '                bbar.Clickable = False
    '            End If

    '        End Sub

    '        Private Sub DrawTabButton3(ByVal i As Integer)
    '            Dim tabbutton(TabPages.Count) As FlatButton
    '            If Not Parent.Controls.Contains(tabbutton(i)) Then
    '                tabbutton(i) = New FlatButton
    '                tabbutton(i).ButtonText = Me.TabPages(i).Text
    '                tabbutton(i).Top = Me.Top '+ (i * 37) + 55
    '                tabbutton(i).Left = ((Me.Width + Me.Left) - (i * 105)) - 100
    '                tabbutton(i).Width = 100
    '                tabbutton(i).Height = 32
    '                tabbutton(i).Tag = i
    '                tabbutton(i).Color = LCARScolorStyles.NavigationFunction

    '                'Dim s As String = ""

    '                's = s & " " & Parent.Controls.Contains(tabbutton(0)).ToString
    '                'MsgBox(s)

    '                If tabbutton(i).Top < (Me.Height - 32) Then
    '                    Parent.Controls.Add(tabbutton(i))
    '                    tabbutton(i).BringToFront()
    '                    AddHandler tabbutton(i).Click, AddressOf OntabbuttonClick
    '                    's = s & " " & Parent.Controls.Contains(tabbutton(0)).ToString
    '                    'MsgBox(s)

    '                Else
    '                    Dim scrlbutton As New ArrowButton
    '                    'Dim tst As New TextBox
    '                    'Parent.Controls.Add(tst)
    '                    'For int As Integer = 0 To (Parent.Controls.Count - 1)
    '                    's = s & " " & Parent.Controls.Contains(tst).ToString
    '                    'Next
    '                    'MsgBox(s)
    '                    If Parent.Controls.Contains(scrlbutton) = False Then
    '                        'Parent.Controls.Add(tst)
    '                        's = s & " " & Parent.Controls.Contains(tabbutton(i)).ToString
    '                        'MsgBox(s)
    '                        'tabbutton(i).Visible = False
    '                        'tabbutton(i - 1).Visible = False
    '                        'scrlbutton.Visible = True
    '                        scrlbutton.Top = Me.Top + (i * 37) + 55
    '                        scrlbutton.Left = (Me.Width + Me.Left) - 100
    '                        scrlbutton.Width = 100
    '                        scrlbutton.Height = 32
    '                        Parent.Controls.Add(scrlbutton)
    '                        scrlbutton.BringToFront()
    '                        scrlbutton.Tag = i
    '                        scrlbutton.Color = LCARScolorStyles.NavigationFunction
    '                        AddHandler scrlbutton.Click, AddressOf OnscrlbuttonClick

    '                    End If
    '                End If
    '            End If
    '            'If i = (TabPages.Count - 1) And tabbutton(i).Top < (Me.Top + Me.Height - 32) Then
    '            Dim bbar As New FlatButton
    '            bbar.Top = Me.Top + 55
    '            bbar.Size = New Size(15, (Me.Top + Me.Height - 110))
    '            bbar.Left = Me.Left + Me.Width - 15
    '            bbar.ButtonText = ""
    '            bbar.Color = LCARScolorStyles.LCARSDisplayOnly
    '            Parent.Controls.Add(bbar)
    '            bbar.BringToFront()
    '            'End If

    '        End Sub

    '        Private Sub OntabbuttonClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '            Dim btnClicked As LCARSbuttonClass = DirectCast(sender, LCARSbuttonClass)
    '            Dim intSBIndex As Integer = Integer.Parse(btnClicked.Tag)
    '            Me.SelectedTab.Hide()
    '            Me.SelectTab(intSBIndex)

    '        End Sub

    '        Private Sub OnscrlbuttonClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '            Dim btnClicked As LCARSbuttonClass = DirectCast(sender, LCARSbuttonClass)
    '            Dim intSBIndex As Integer = Integer.Parse(btnClicked.Tag)

    '            For i As Integer = (intSBIndex - 1) To Me.TabPages.Count - 1
    '                Call Me.DrawTabButton2(i)
    '            Next

    '            'UI.MsgBox("tab " & sender.ToString & " clicked also e = " & e.ToString & btnClicked.Tag)
    '        End Sub

    '        Private Sub DrawTabButton(ByVal g As Graphics, ByVal TabPageIndex As Integer)
    '            Dim r As Rectangle
    '            ' get the tab rectangle
    '            r = Me.GetTabRect(TabPageIndex)
    '            '# If Me.Alignment = TabAlignment.Right Or Me.Alignment = TabAlignment.Left Then
    '            ' increase its width we dont want the background in between
    '            r.Width = r.Width - r.Height
    '            r.Height -= 4
    '            'r.Y += (TabPageIndex * 2) '+ 40 ' bring down to make room for elbow, Not Work - Unable to click afterwards!
    '            r.X += (r.Height / 2)
    '            ' Else
    '            '    r.Size = New Drawing.Size(0, 0)
    '            'End If
    '            ' if first tab page
    '            If TabPageIndex = 0 Then
    '                ' reduce its height and move it a little bit lower
    '                ' since in tab control first tab button is displayed a little
    '                ' bit heigher
    '                'r.Height = r.Height - 2
    '                'r.Y = r.Y + 2
    '            End If
    '            ' if given tab button is selected
    '            If Me.SelectedIndex = TabPageIndex Then
    '                ' use selected properties
    '                g.FillRectangle(Me.HeaderSelectedBackBrush, r)

    '                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half

    '                g.FillEllipse(Me.HeaderSelectedBackBrush, r.X - (r.Height \ 2), r.Y, r.Height, r.Height)
    '                g.FillEllipse(Me.HeaderSelectedBackBrush, (r.X + r.Width) - (r.Height \ 2), r.Y, r.Height, r.Height)
    '                ' if currently focused then draw focus rectangle
    '                'If Me.Focused Then
    '                '   System.Windows.Forms.ControlPaint.DrawFocusRectangle(g, New Rectangle(r.Left + 2, r.Top + 2, r.Width - 4, r.Height - 5))
    '                'End If
    '            Else ' else (not the selected tab page)
    '                g.SmoothingMode = Drawing2D.SmoothingMode.None
    '                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.None

    '                g.FillRectangle(Me.HeaderBackBrush, r)

    '                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half

    '                g.FillEllipse(Me.HeaderBackBrush, r.X - (r.Height \ 2), r.Y, r.Height, r.Height)
    '                g.FillEllipse(Me.HeaderBackBrush, (r.X + r.Width) - (r.Height \ 2), r.Y, r.Height, r.Height)

    '            End If

    '            ' if first tab button
    '            If TabPageIndex = 0 Then
    '                ' draw a line on top
    '                'g.DrawLine(Me.HeaderPen, r.Left, r.Top, r.Right, r.Top)
    '            End If
    '            ' --- following block is a waste of time ---
    '            ' line at right
    '            'g.DrawLine(Me.HeaderPen, r.Right, r.Top, r.Right, r.Bottom - 1)
    '            ' line at bottom
    '            'g.DrawLine(Me.HeaderPen, r.Left, r.Bottom - 1, r.Right, r.Bottom - 1)
    '            ' no line at left since we want to give an effect of
    '            ' pages
    '            'If TabPageIndex = TabPages.Count - 1 Then g.FillRectangle(myBrush, r.Left, (r.Bottom + 5), r.Width, (Me.Height - (r.Bottom + 5 + 4))) ' where 4 is the page padding
    '            ' bring LCARS style down to bottom of control
    '        End Sub

    '        Private Sub DrawTabText(ByVal g As Graphics, ByVal TabPageIndex As Integer)
    '            Dim iX As Integer
    '            Dim iY As Integer
    '            Dim sText As String
    '            Dim sizeText As SizeF
    '            Dim rectTab As Rectangle

    '            ' get tab button rectangle
    '            rectTab = Me.GetTabRect(TabPageIndex)
    '            rectTab.Height -= 5

    '            sText = Me.TabPages(TabPageIndex).Text
    '            ' measure the size of text
    '            sizeText = g.MeasureString(sText, Me.HeaderFont)

    '            ' check text alignment
    '            'Select Case Me.HeaderAlignment
    '            '    Case ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft, ContentAlignment.TopLeft
    '            '        iX = rectTab.Left + Me.HeaderPadding.Left
    '            '    Case ContentAlignment.MiddleRight, ContentAlignment.BottomRight, ContentAlignment.TopRight
    '            '        iX = rectTab.Right - sizeText.Width - Me.HeaderPadding.Right
    '            '     Case ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter, ContentAlignment.TopCenter
    '            iX = rectTab.Left + (rectTab.Width - Me.HeaderPadding.Left - Me.HeaderPadding.Right - sizeText.Width) / 2
    '            'End Select

    '            'Select Case Me.HeaderAlignment
    '            '    Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
    '            '        iY = rectTab.Top + Me.HeaderPadding.Top
    '            '    Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
    '            '        iY = rectTab.Bottom - sizeText.Height - Me.HeaderPadding.Bottom
    '            '    Case ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight
    '            iY = rectTab.Top + (rectTab.Height - Me.HeaderPadding.Top - sizeText.Height) / 2
    '            'End Select

    '            'match text to buttons new lower position
    '            'iY += (TabPageIndex * 2) '+ 40 'worked but could not click

    '            ' if selected tab button
    '            If Me.SelectedIndex = TabPageIndex Then
    '                g.DrawString(sText, Me.HeaderFont, Me.HeaderSelectedForeBrush, iX, iY)
    '            Else
    '                g.DrawString(sText, Me.HeaderFont, Me.HeaderForeBrush, iX, iY)
    '            End If
    '        End Sub

    '        Protected Overrides Sub SetClientSizeCore(ByVal x As Integer, ByVal y As Integer)
    '            MyBase.SetClientSizeCore(x, y)
    '        End Sub

    '#Region " Hide some properties which can disturb our customization "
    '        <System.ComponentModel.DefaultValue(GetType(Color), "Black")> _
    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overrides Property BackColor() As Color
    '            Get
    '                Return Me._BackColor
    '            End Get
    '            Set(ByVal value As Color)
    '                '   If Not Me._BackColor = value Then
    '                '       Me._BackColor = value
    '                '       If Me._BackBrush IsNot Nothing Then
    '                '           Me._BackBrush.Dispose()
    '                '           Me._BackBrush = Nothing
    '                '       End If
    '                '       Me.Invalidate()
    '                '   End If
    '            End Set
    '        End Property

    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overloads Property DrawMode() As System.Windows.Forms.TabDrawMode
    '            Get
    '                Return MyBase.DrawMode
    '            End Get
    '            Set(ByVal value As System.Windows.Forms.TabDrawMode)
    '                MyBase.DrawMode = TabDrawMode.OwnerDrawFixed
    '            End Set
    '        End Property

    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overloads Property Appearance() As System.Windows.Forms.TabAppearance
    '            Get
    '                Return MyBase.Appearance
    '            End Get
    '            Set(ByVal value As System.Windows.Forms.TabAppearance)
    '                MyBase.Appearance = TabAppearance.Normal
    '            End Set
    '        End Property

    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overloads Property ItemSize() As Size
    '            Get
    '                Return MyBase.ItemSize
    '            End Get
    '            Set(ByVal value As Size)
    '                MyBase.ItemSize = value
    '            End Set
    '        End Property

    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overloads Property SizeMode() As System.Windows.Forms.TabSizeMode
    '            Get
    '                Return MyBase.SizeMode
    '            End Get
    '            Set(ByVal value As System.Windows.Forms.TabSizeMode)
    '                MyBase.SizeMode = TabSizeMode.Fixed
    '            End Set
    '        End Property

    '        <System.ComponentModel.Browsable(False)> _
    '        Public Overloads Property Multiline() As Boolean
    '            Get
    '                Return MyBase.Multiline
    '            End Get
    '            Set(ByVal value As Boolean)
    '                MyBase.Multiline = True
    '            End Set
    '        End Property
    '#End Region

    '    End Class


    '#Region "TabPage - Override"
    '    Public Class LCARSTabPage
    '        Inherits TabPage

    '        Public Sub New()

    '            Dim topbutt As New LCARS.Controls.HalfPillButton
    '            topbutt.ButtonText = ""
    '            Me.Controls.Add(topbutt)
    '            topbutt.Top = 0
    '            topbutt.ButtonStyle = LCARS.Controls.HalfPillButton.LCARSbuttonStyles.PillLeft
    '            topbutt.Color = LCARScolorStyles.LCARSDisplayOnly
    '            topbutt.Height = 15
    '            topbutt.Width = Me.Width
    '            Me.Size = New Drawing.Size(20, 10)

    '            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    '            Me.SetStyle(ControlStyles.UserPaint, True)
    '        End Sub

    '        Public Overrides Property AutoSize() As Boolean
    '            Get
    '                Return MyBase.AutoSize
    '            End Get
    '            Set(ByVal value As Boolean)
    '                MyBase.AutoSize = False
    '            End Set
    '        End Property

    '    End Class
    '#End Region

#End Region

#Region " Tab Control 2 "
    'The x32TabControl is made of two main parts:  The x32TabControl itself, and x32TabPages that get added
    'to it (just like the Windows Tab Control).

#Region " The Tab Control "

#Region " x32TabControl "

    'Set the defualt event to "SelectedTabChanged" (just makes it easier on the user).  At the same
    'time, apply the 'x32TabControlDesigner' which handles how x32TabControls interact with the 
    'Windows Form Designer (more info in the 'x32TabControlDesigner' class).
    <System.ComponentModel.DefaultEvent("SelectedTabChanged"), Designer(GetType(x32TabControlDesigner))> _
    Public Class x32TabControl
        Inherits Windows.Forms.Control


        'This is a global variable to hold the tabpages collection.  An underscore is used to 
        'denote that there is a property by the same name that this variable is linked to.
        Dim _TabPages As New x32TabPageCollection(Me)
        'The currently active tab.
        Dim _SelectedTab As x32TabPage

        'In case it's not obvious, this is the elbow in the top right of the x32TabControl.
        Dim topElbow As New LCARSControls.Elbow
        'Likewise, this is the heading bar at the very top of the control
        Dim myHeading As New FlatButton
        'and the buttonPanel that holds the tab buttons along the right side
        Public buttonPanel As New Panel
        'This label is used to display a message explaining how to add tabs when none
        'have been added and the control is in 'design time'.
        Dim message As New Label

        'An event that fires when a new tab has been selected.  Very useful for the user.
        Public Event SelectedTabChanged(ByVal Tab As x32TabPage, ByVal TabIndex As Integer)

        'Don't show it in the 'Properties' page, and remember it when the form is closed 
        '(Serialize it)
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property TabPages() As x32TabPageCollection
            'Returns a collection containing all of the tabs currently on the x32TabControl.
            Get
                Return _TabPages
            End Get
        End Property

        'Don't show it in the 'Properties' page
        <Browsable(False)> _
        Public Property SelectedTab() As x32TabPage
            'Gets or sets the tab that is currently selected.  What more can I say?
            Get
                Return _SelectedTab
            End Get
            Set(ByVal value As x32TabPage)
                _SelectedTab = value
                If _SelectedTab IsNot Nothing Then
                    'As long as the selected tab is something, show it.
                    ChangeTab(_SelectedTab)
                End If

            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            'Create the controls that make up the tabcontrol.  

            'These are:

            'The heading above the tab area (very top),
            With myHeading
                .ButtonText = ""
                .Width = Me.Width - 126
                .Height = 20
                .Left = 0
                .Top = 0
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                .Color = LCARScolorStyles.LCARSDisplayOnly
                .ButtonTextAlign = ContentAlignment.BottomLeft
            End With

            Me.Controls.Add(myHeading)

            'The elbow in the top right of the tabcontrol,
            With topElbow
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperRight
                .ButtonHeight = 20
                .ButtonWidth = 100
                .Width = 120
                .Height = 75
                .Left = Me.Width - .Width
                .Top = 0
                .ButtonText = "TABS"
                .ButtonTextAlign = ContentAlignment.BottomRight
                .Color = LCARScolorStyles.StaticTan
                .Clickable = False
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            End With

            Me.Controls.Add(topElbow)


            'And the panel that contains the buttons that act as the 'Tabs'.
            With buttonPanel
                .Width = 100
                .Height = Me.Height - topElbow.Bottom
                .Top = topElbow.Bottom
                .Left = Me.Width - .Width
                .BackColor = Color.Black
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            End With

            Me.Controls.Add(buttonPanel)

            TabPagesChanged()
            topElbow.SendToBack()
        End Sub

        Private Sub InitializeComponent()
            'Sets the default values for the x32TabControl.

            'Allow this control to contain other controls
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()

            'Don't redraw the control until we're done making changes.
            Me.SuspendLayout()

            Me.BackColor = Color.Black
            Me.Size = New System.Drawing.Size(400, 400)

            'Ok, now we can allow the control to draw again.
            Me.ResumeLayout(False)
        End Sub


        Friend Sub TabPagesChanged()
            'This Sub is called whenever a tab has been added or removed from the TabPages collection.

            'Remove all of the tabs from the control
            For Each mycontrol As Control In Me.Controls
                If mycontrol.GetType Is GetType(LCARSControls.x32TabPage) Then
                    Me.Controls.Remove(mycontrol)
                End If

            Next

            'Remove the tab's button from the buttonPanel.
            buttonPanel.Controls.Clear()

            'Add all of the tabs back to the control, so now the new ones are there, too 
            '(or old ones are gone...)
            For Each mytab As x32TabPage In Me.TabPages
                Me.Controls.Add(mytab)

                'Set the size of the tab equal to the area we want the tab to cover.  Basically,
                'everwhere our heading, elbow, and buttonpanel are not.
                mytab.Width = Me.Width - 110
                mytab.Height = Me.Height - 26
                mytab.Location = New Point(0, 26)

                'Set the anchor so the tab will resize with the tabcontrol
                mytab.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

                'Now that we have the tab added to the tab control, we need to create a button
                'that will bring it to the front when the user clicks it.
                Dim mybutton As New FlatButton
                mybutton.Width = 100
                mybutton.Height = 35
                mybutton.ButtonText = mytab.Text
                mybutton.ButtonTextAlign = ContentAlignment.BottomRight

                'It might be a good idea to make it so the user can select the color of the
                'tab.  It would make things more consistant.  For now, they are just set to 
                'MiscFunction.
                mybutton.Color = LCARScolorStyles.MiscFunction

                'Button beeping also needs to be handled.  I'm working on a way for new controls
                'and community made programs to easily interface with LCARSmain so they know when
                'they need to turn beeping on/off or when the colors have changed.
                mybutton.Beeping = False

                'position the button based on how many buttons are already there.
                mybutton.Top = (buttonPanel.Controls.Count * 41) + 6
                mybutton.Left = 0

                'By setting the button's 'Tag' property to the Tab it is associated with,
                'we can easily tell what button goes with what tab.
                mybutton.Tag = mytab

                'Make the button call "myButton_Click" whenever someone clicks on it.
                AddHandler mybutton.Click, AddressOf myButton_Click
                buttonPanel.Controls.Add(mybutton)
            Next


            'If there's any room left after all of tabs have been made, we need to fill the
            'empty space with another button that isn't clickable.
            If (buttonPanel.Controls.Count * 41) + 6 < buttonPanel.Height Then
                Dim mybutton As New FlatButton

                With mybutton
                    .Width = 100

                    'Start at the bottom of the last button
                    .Top = (buttonPanel.Controls.Count * 41) + 6

                    'and end at the bottom of the tab control.
                    .Height = buttonPanel.Height - .Top

                    .Color = LCARScolorStyles.StaticTan
                    .Clickable = False
                    .ButtonTextAlign = ContentAlignment.BottomRight

                    'have the button resize with the control.  We don't want it to get wider,
                    'that 100px so we leave AnchorStyles.Right out of the code.
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
                    buttonPanel.Controls.Add(mybutton)
                End With
            End If

            'If the "SelectedTab" property isn't set, then select the first tab added to the control.
            If SelectedTab Is Nothing Or TabPages.Contains(SelectedTab) = False Then
                If TabPages.Count > 0 Then
                    SelectedTab = TabPages(0)
                Else
                    SelectedTab = Nothing
                End If
            End If

            'There's a label placed on the form if no tabs have been added that explains how to 
            'add tabs to the control.  This message is only shown if there are no tabs and the 
            'control is in 'Design Time' (not executing, but rather in the designer).
            If TabPages.Count > 0 Then
                message.Visible = False
            Else
                message.Visible = True
            End If

            'Bring the tab that is currently set as selected to the front.
            ChangeTab(_SelectedTab)
        End Sub

        Private Sub ChangeTab(ByVal Tab As x32TabPage)
            'Brings the provided tab to the front of all of the other tabs and sets it as 
            'the selected tab. 

            'NOTE: _SelectedTab is used because if we used the property to set the selected tab, 
            'we would get into an 'endless loop' because the 'SelectedTab' property calls 
            ''ChangeTab' which in turn would call 'SelectedTab' again.  Not good!
            If Tab IsNot Nothing Then
                Tab.BringToFront()
                _SelectedTab = Tab

                'Set the heading(the bar at the top)'s text to the tab's text
                myHeading.Text = Tab.Text

                'Set the selected tabs button's color to white and all of the others to 'MiscFunction'
                For Each mybutton As FlatButton In buttonPanel.Controls
                    If mybutton.Tag Is Tab Then
                        mybutton.Color = LCARScolorStyles.PrimaryFunction
                    Else
                        mybutton.Color = LCARScolorStyles.MiscFunction
                    End If
                Next
            End If

            'Let the user of the control know that a tab has been selected.
            RaiseEvent SelectedTabChanged(Tab, TabPages.indexOf(Tab))

        End Sub

        Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Handles the user clicking on one of the tab buttons.

            '"Sender" is the button that the user clicked.  We can use it's tag property (that
            'was set in the 'TabPagesChanged' Sub) to bring the tab associated with this button to 
            'the front.
            ChangeTab(sender.tag)
        End Sub


        Private Sub LCARStabControl_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
            'This event fires when the control is added to the form or moved from one control to 
            'another.  The reason the following code is here rather than in the 'New' or 
            'InitializeComponents' Subs is because we have to wait until the control has been added
            'to the form or another control before we can check if any of those controls are running
            'in design time.

            'Here, we're checking if the control is running in "Design Time" or "Run Time".
            'Design Time is when you are editing the form in the designer.  Run Time is when you
            'execute the program.  We don't want to show a message explaining how to use the
            'x32TabControl unless they are a programmer!
            If IsDesignerHosted And Me.Controls.Contains(message) = False Then
                With message
                    .AutoSize = True
                    .Text = "There are currently no tabs." & vbNewLine & _
                              "Right click on the elbow and choose" & vbNewLine & _
                              "'Add Tab' to add new tabs to the control."

                    'Center the message in the Tab area.
                    .Left = ((Me.Width - 112) / 2) - (.Width / 2)
                    .Top = (Me.Height / 2) - (.Height / 2)

                    .ForeColor = Color.White

                    'by removing all of it's anchors, the control will stay centered.
                    .Anchor = AnchorStyles.None

                    Me.Controls.Add(message)

                    'It's sent to the back just in case a tab is there.  It shouldn't be, but if
                    'it is, this line ensures that the message is hidden behind it.
                    Me.SendToBack()
                End With
            End If
        End Sub

        Public ReadOnly Property IsDesignerHosted() As Boolean
            'Thanks to this (http://decav.com/blogs/andre/archive/2007/04/18/1078.aspx) 
            'website for explaining how to tell if you are in design time (editor) or run 
            'time (executing/running) whichi is what the below code does.

            Get
                Dim ctrl As Control = Me
                While ctrl IsNot Nothing
                    If ctrl.Site Is Nothing Then
                        'If a control does not have a site, then it's definately in 'Run Time'.
                        Return False
                    End If
                    If ctrl.Site.DesignMode = True Then
                        Return True
                    End If

                    'Check the control's parent to make sure it's not running in design time.
                    'if any of them are, then the whole program is.
                    ctrl = ctrl.Parent
                End While
                Return False
            End Get
        End Property

        Private Sub LCARStabControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
            'Fires when the x32TabControl is resized.

            'For whatever reason, anchors alone weren't working, so I had to add code here to move
            'the main components of the x32TabControl whenever the control was resized.
            topElbow.Left = Me.Width - topElbow.Width
            topElbow.Top = 0

            buttonPanel.Top = topElbow.Bottom
            buttonPanel.Left = Me.Width - buttonPanel.Width
            buttonPanel.Height = Me.Height - buttonPanel.Top

            myHeading.Width = Me.Width - 126
            myHeading.Top = 0
            myHeading.Left = 0
        End Sub
    End Class

#End Region

#Region " x32TabControlDesigner "

    'The x32TabControlDesigner allows us to control how the x32TabControl behaves when in "Design 
    'Time". It's the way we allow the user to right click on the elbow and choose 'Add Tab', and 
    'to allow them to click on the tab buttons. 
    Public Class x32TabControlDesigner
        'We had to import some extra classes to be able to use this, so scroll all the way up to
        'see which ones (they are commented).
        Inherits ControlDesigner

        'This holds a reference to the x32TabControl currently being modified.
        Dim myControl As x32TabControl

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            '"Component" is passed to the designer by the x32TabControl when it is added to a form.
            'We have to convert it from an IComponent to an x32TabControl.  Since it's actually 
            'already just an x32TabControl, we can use DirectCast to change it's type (just to 
            'make it easy on ourselves later).
            myControl = DirectCast(component, x32TabControl)

            'Here we're adding an event handler that will fire when something is added to our
            'control--in our case, x32TabPages.
            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            AddHandler c.ComponentRemoving, AddressOf OnComponentRemoving
        End Sub

        Private Sub OnComponentRemoving(ByVal sender As Object, ByVal e As ComponentEventArgs)
            'This sub is fired when a control is removed from our x32TabControl.

            'A lot of this was modified from code I found at: http://www.divelements.com/net/articles/designers/collectioncontrols.asp
            'It's a great article and helped A LOT.

            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            Dim mytabPage As x32TabPage
            Dim h As IDesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)
            Dim i As Integer

            'If the user is removing a TabPage
            If TypeOf e.Component Is x32TabPage Then
                mytabPage = DirectCast(e.Component, x32TabPage)
                If myControl.TabPages.Contains(mytabPage) Then
                    c.OnComponentChanging(myControl, Nothing)
                    myControl.TabPages.Remove(mytabPage)
                    c.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
                    Return
                End If
            End If

            'If the user is removing the control itself, remove all of the TabPages first.
            If e.Component Is myControl Then
                For i = myControl.TabPages.Count - 1 To 0 Step -1
                    mytabPage = myControl.TabPages(i)
                    c.OnComponentChanging(myControl, Nothing)
                    myControl.TabPages.Remove(mytabPage)
                    h.DestroyComponent(mytabPage)
                    c.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
                Next
            End If
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)

            'Unhook events
            RemoveHandler c.ComponentRemoving, AddressOf OnComponentRemoving

            MyBase.Dispose(disposing)
        End Sub

        Public Overrides ReadOnly Property AssociatedComponents() As System.Collections.ICollection
            'This and the 'OnComponentRemoving' sub are used to keep the "TabPages" Collection in
            'tact when the form is reloaded (called 'serialization').
            Get
                Return myControl.TabPages
            End Get
        End Property

        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            'Adds the 'Add Tab' option to the right click (context) menu of the x32TabControl and
            'associates the menu item with the 'AddTab' sub.
            Get
                Dim myVerbs As New DesignerVerbCollection()

                'Create the verb to add a tab
                myVerbs.Add(New DesignerVerb("&Add Tab", AddressOf AddTab))
                Return myVerbs
            End Get
        End Property

        Private Sub AddTab(ByVal sender As Object, ByVal e As EventArgs)
            'I don't understand everthing that goes on here.  I know that the end result is a new
            'tab being added to the x32TabPageControl.

            'Our new tab
            Dim mytabpage As x32TabPage

            'An instance of the IDesignerHost interface which allows us to create transactions
            'in the designer.
            Dim myHost As IDesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)

            'A transaction.  From what I read, I believe that this just allows our "Add Tab" to 
            'be undone using the "Undo" button.
            Dim myTransaction As DesignerTransaction

            'This is used to call events that are also used in the Undo and Redo functions.
            Dim myChangeService As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)

            'Set the name of the transaction.  I believe this also sets the starting point.
            myTransaction = myHost.CreateTransaction("Add Tab")
            'Create a new x32TabPage using the DesignerHost.
            mytabpage = DirectCast(myHost.CreateComponent(GetType(x32TabPage)), x32TabPage)
            'Let Visual Studio know we changed a component (our x32TabControl)
            myChangeService.OnComponentChanging(myControl, Nothing)
            'Add the tabpage to the tabcontrol.
            myControl.TabPages.Add(mytabpage)
            'Visual Studio... we changed it again.
            myChangeService.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
            'Finish the transaction so it knows when the "undo" should stop.
            myTransaction.Commit()
        End Sub

        Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
            'GetHitTest is allows us to make controls clickable during design time.  For example,
            'on the x32TabControl, you'll notice that even in the designer, you can switch tabs
            'by clicking on the relevant tab button.  Take this sub out and that won't work any
            'more.

            'Make sure that we have been added to a control. Otherwise, there's no point.
            If Me.Control IsNot Nothing Then

                'Convert the point from screen coordinates to coordinates based on our x32TabControl
                Dim mypoint As Point = CType(Me.Control, x32TabControl).buttonPanel.PointToClient(point)
                'Find out what control is under the mouse at that point.
                Dim child As Control = CType(Me.Control, x32TabControl).buttonPanel.GetChildAtPoint(mypoint)

                'If there's nothing under the mouse, don't bother.
                If child IsNot Nothing Then
                    If TypeOf child Is FlatButton Then
                        'If the control under the mouse is a flatbutton, let us click on it.
                        Return True
                    Else
                        'Otherwise... no clicky.
                        Return MyBase.GetHitTest(point)
                    End If
                End If
            End If

        End Function
    End Class

#End Region

#Region " x32TabCollection "

    Public Class x32TabPageCollection
        Inherits CollectionBase
        'This class keeps track of all the tabs on the x32TabControl.  It's a fairly simple class,
        'as the 'CollectionBase' class does all of the heavy lifting.

        'The x32TabControl the current instance of x32TabCollection is running inside of
        Private Parent As x32TabControl

        Friend Sub New(ByVal Control As x32TabControl)
            'When an x32TabControl creates it's TabPages collection, it passes itself as the single
            'parameter so we can tell what x32TabControl goes with the collection.
            Me.Parent = Control
        End Sub

        Default Public ReadOnly Property Item(ByVal Index As Integer) As x32TabPage
            'Returns whatever tabpage is at the given index.
            Get
                Return DirectCast(List(Index), x32TabPage)
            End Get
        End Property

        Public Function Contains(ByVal tab As x32TabPage) As Boolean
            'Returns 'true' if the tab is in the collection and 'false' if it is not.
            Return List.Contains(tab)
        End Function

        Public Function Add(ByVal tab As x32TabPage) As Integer
            'Adds the supplied tab to the tab collection and returns it's new index
            Dim i As Integer
            i = List.Add(tab)
            Parent.TabPagesChanged()
            Return i
        End Function

        Public Function indexOf(ByVal tab As x32TabPage)
            'Returns the index of the given tab in the collection
            Return List.IndexOf(tab)
        End Function

        Public Sub Remove(ByVal Tab As x32TabPage)
            'Removes the given tab from the collection.  I know... duh. But comments are necessary evils.
            List.Remove(Tab)
            Tab = Nothing
            Parent.TabPagesChanged()
        End Sub
    End Class

#End Region

#End Region

#Region " Tab Pages "

#Region " x32TabPage "

    'Associate the x32TabPageDesigner with the x32TabPage class, Associate it also with the
    'x32TabPageConverter (used in the serialization process), don't show it in the toolbox, and
    'allow x32TabPages to have other controls drug-and-dropped onto them.
    <Designer(GetType(x32TabPageDesigner)), TypeConverter(GetType(x32TabPageConverter)), DesignTimeVisible(False), ToolboxItem(False), Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", GetType(IDesigner))> _
    Public Class x32TabPage
        Inherits Control

        'The text of the x32TabPage (what shows on the button and the heading).
        Dim _text As String = "NEW TAB"

        Sub New()
            _text = "NEW TAB"
            'This is LCARS after all.  We can't settle for a gray background.
            Me.BackColor = Color.Black
        End Sub

        Sub New(ByVal TabText As String)
            _text = TabText
            Me.BackColor = Color.Black
        End Sub

        Public Overrides Property Text() As String
            'Gets or sets the tabs button and heading text.
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                'It's LCARS.  Text is UPPER CASE! unless it isn't...
                _text = value.ToUpper

                If Me.Parent IsNot Nothing Then
                    'Update the tabs
                    CType(Me.Parent, x32TabControl).TabPagesChanged()
                End If
            End Set
        End Property

    End Class

#End Region

#Region " x32TabPageDesigner "

    Public Class x32TabPageDesigner
        Inherits ParentControlDesigner
        'Specifies how the x32TabPage interacts with the user in the Windows Form Designer.
        'Basically, all this class does is locks the x32TabControl so it can't be moved or
        'resized.  

        'Our parent control
        Dim myControl As x32TabPage

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            myControl = DirectCast(component, x32TabPage)
        End Sub

        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
            'SelectionRules.Locked prevents the user from being able to move or resize the 
            'x32TabPage in the designer.
            Get
                Return SelectionRules.Locked
            End Get
        End Property
    End Class

#End Region

#Region " x32TabPageConverter "

    Friend Class x32TabPageConverter
        Inherits TypeConverter

        'A class to convert x32TabPages during the serialization process.  Don't ask me, I pretty
        'much just changed the word 'button' from the example to 'x32TabPage' and it worked...

        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destType As Type) As Boolean
            If destType Is GetType(InstanceDescriptor) Then
                Return True
            End If

            Return MyBase.CanConvertTo(context, destType)
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
            If destType Is GetType(InstanceDescriptor) Then
                Dim ci As System.Reflection.ConstructorInfo = GetType(x32TabPage).GetConstructor(System.Type.EmptyTypes)

                Return New InstanceDescriptor(ci, Nothing, False)
            End If

            Return MyBase.ConvertTo(context, culture, value, destType)
        End Function
    End Class

#End Region

#End Region

#End Region

#Region " Calender Control "
    ', Designer(GetType(x32TabControlDesigner))> _
    <System.ComponentModel.DefaultEvent("SelectedDateChanged")> _
    Public Class LCARSCalender
        Inherits Windows.Forms.Control
        Public Event SelectedDateChanged(ByVal SelectedDate As DateTime)
        'Global Variables
        Dim _year As Integer = 2000
        Dim _month As Integer = 1
        Dim _selectedDate As DateTime
        Dim _padding As Integer = 5
        'Permanent Controls
        Dim myYearButton As New FlatButton
        Dim myYearRight As New ArrowButton
        Dim myYearLeft As New ArrowButton
        Dim myMonthButton As New FlatButton
        Dim myMonthRight As New ArrowButton
        Dim myMonthLeft As New ArrowButton
        Dim myDays As New Panel
        Dim mySunday As New FlatButton
        Dim myMonday As New FlatButton
        Dim myTuesday As New FlatButton
        Dim myWednesday As New FlatButton
        Dim myThursday As New FlatButton
        Dim myFriday As New FlatButton
        Dim mySaturday As New FlatButton

        Public Enum Months
            January = 1
            February = 2
            March = 3
            April = 4
            May = 5
            June = 6
            July = 7
            August = 8
            September = 9
            October = 10
            November = 11
            December = 12
        End Enum
#Region " Properties "
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                If value < 10000 And value > 0 Then
                    _year = value
                    myYearButton.ButtonText = _year
                    ShowDays()
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property
        Public Property Month() As Months
            Get
                Return _month
            End Get
            Set(ByVal value As Months)
                _month = value
                Select Case _month
                    Case 1
                        myMonthButton.ButtonText = "January"
                    Case 2
                        myMonthButton.ButtonText = "February"
                    Case 3
                        myMonthButton.ButtonText = "March"
                    Case 4
                        myMonthButton.ButtonText = "April"
                    Case 5
                        myMonthButton.ButtonText = "May"
                    Case 6
                        myMonthButton.ButtonText = "June"
                    Case 7
                        myMonthButton.ButtonText = "July"
                    Case 8
                        myMonthButton.ButtonText = "August"
                    Case 9
                        myMonthButton.ButtonText = "September"
                    Case 10
                        myMonthButton.ButtonText = "October"
                    Case 11
                        myMonthButton.ButtonText = "November"
                    Case 12
                        myMonthButton.ButtonText = "December"
                End Select
                ShowDays()
            End Set
        End Property
        Public Property ButtonPadding() As Integer
            Get
                Return _padding
            End Get
            Set(ByVal value As Integer)
                If value >= 0 Then
                    _padding = value
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property
        Public Property SelectedDate() As DateTime
            Get
                Return _selectedDate
            End Get
            Set(ByVal value As DateTime)
                _selectedDate = value
                Year = _selectedDate.Year
                Month = _selectedDate.Month
                'ShowDays()
            End Set
        End Property
#End Region

#Region " Event Handlers "
        Public Sub YearUp()
            If _year < 9999 Then
                Year += 1
            End If
        End Sub
        Public Sub YearDown()
            If _year > 1 Then
                Year -= 1
            End If
        End Sub
        Public Sub MonthUp()
            If _month < 12 Then
                Month += 1
            Else
                YearUp()
                Month = 1
            End If
        End Sub
        Public Sub MonthDown()
            If _month > 1 Then
                Month -= 1
            Else
                YearDown()
                Month = 12
            End If
        End Sub
        Public Sub Day_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            For Each mybutton As FlatButton In myDays.Controls
                mybutton.RedAlert = LCARSalert.Normal
            Next
            CType(sender, FlatButton).RedAlert = LCARSalert.White
            _selectedDate = CType(CType(sender, FlatButton).Data, DateTime)
            RaiseEvent SelectedDateChanged(SelectedDate)
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Size = standardSize
                .Top = 0
                .Left = 0
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearLeft.Click, AddressOf YearDown
            Me.Controls.Add(myYearLeft)
            With myYearRight
                .Size = standardSize
                .Top = 0
                .Left = Me.Size.Width - standardSize.Width
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearRight.Click, AddressOf YearUp
            Me.Controls.Add(myYearRight)
            With myYearButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = 0
                .Left = standardSize.Width + _padding
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.MiddleCenter
                .ButtonText = _year
            End With
            Me.Controls.Add(myYearButton)
            'Month buttons
            With myMonthLeft
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = 0
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthLeft.Click, AddressOf MonthDown
            Me.Controls.Add(myMonthLeft)
            With myMonthRight
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = Me.Size.Width - standardSize.Width
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthRight.Click, AddressOf MonthUp
            Me.Controls.Add(myMonthRight)
            With myMonthButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = standardSize.Height + _padding
                .Left = standardSize.Width + _padding
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.MiddleCenter
                Select Case _month
                    Case 1
                        .ButtonText = "January"
                    Case 2
                        .ButtonText = "February"
                    Case 3
                        .ButtonText = "March"
                    Case 4
                        .ButtonText = "April"
                    Case 5
                        .ButtonText = "May"
                    Case 6
                        .ButtonText = "June"
                    Case 7
                        .ButtonText = "July"
                    Case 8
                        .ButtonText = "August"
                    Case 9
                        .ButtonText = "September"
                    Case 10
                        .ButtonText = "October"
                    Case 11
                        .ButtonText = "November"
                    Case 12
                        .ButtonText = "December"
                End Select
            End With
            Me.Controls.Add(myMonthButton)
            'Day of Week buttons
            With mySunday
                .Top = (standardSize.Height + _padding) * 2
                .Left = 0
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Sunday"
                .Clickable = False
            End With
            Me.Controls.Add(mySunday)
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Monday"
                .Clickable = False
            End With
            Me.Controls.Add(myMonday)
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Tuesday"
                .Clickable = False
            End With
            Me.Controls.Add(myTuesday)
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Wednesday"
                .Clickable = False
            End With
            Me.Controls.Add(myWednesday)
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Thursday"
                .Clickable = False
            End With
            Me.Controls.Add(myThursday)
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Friday"
                .Clickable = False
            End With
            Me.Controls.Add(myFriday)
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Saturday"
                .Clickable = False
            End With
            Me.Controls.Add(mySaturday)
            'Panel to hold all the individual date buttons
            With myDays
                .Top = (standardSize.Height + _padding) * 3
                .Left = 0
                .Width = Me.Size.Width
                .Height = Me.Size.Height - .Top
            End With
            ShowDays()
            Me.Controls.Add(myDays)
        End Sub
        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 250)
            Me.ResumeLayout()
        End Sub
        Public Sub ShowDays()
            myDays.Controls.Clear()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height + _padding) / 9 - _padding)
            Dim i As Integer
            Dim j As Integer
            Dim x As Integer = 1
            For i = 0 To 5
                For j = 0 To 6
                    Dim mybutton As New FlatButton
                    Dim myDate As DateTime
                    Try
                        myDate = New DateTime(Year, Month, x)
                        If myDate.DayOfWeek = j Then
                            With mybutton
                                .Size = standardSize
                                .Top = i * (standardSize.Height + _padding)
                                .Left = (j) * (standardSize.Width + _padding)
                                .ButtonTextAlign = ContentAlignment.MiddleCenter
                                .ButtonText = x
                                .Data = myDate
                                If .Data = New Date(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day) Then
                                    .RedAlert = LCARSalert.White
                                End If
                            End With
                            AddHandler mybutton.Click, AddressOf Day_Click
                            myDays.Controls.Add(mybutton)
                            x += 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        End Sub
        Public Sub Calender_Resize() Handles Me.Resize
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Size = standardSize
                .Top = 0
                .Left = 0
            End With
            With myYearRight
                .Size = standardSize
                .Top = 0
                .Left = Me.Size.Width - standardSize.Width
            End With
            With myYearButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = 0
                .Left = standardSize.Width + _padding
            End With
            'Month buttons
            With myMonthLeft
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = 0
            End With
            With myMonthRight
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = Me.Size.Width - standardSize.Width
            End With
            With myMonthButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = standardSize.Height + _padding
                .Left = standardSize.Width + _padding
            End With
            'Day of Week buttons
            With mySunday
                .Top = (standardSize.Height + _padding) * 2
                .Left = 0
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(mySunday)
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myMonday)
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myTuesday)
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myWednesday)
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myThursday)
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myFriday)
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(mySaturday)
            'Panel to hold all the individual date buttons
            With myDays
                .Top = (standardSize.Height + _padding) * 3
                .Left = 0
                .Width = Me.Size.Width
                .Height = Me.Size.Height - .Top
            End With
            ShowDays()
        End Sub
    End Class
#End Region

#Region " Pie Button "

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class PieButton
        Inherits LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'FlatButtonButton
            '
            Me.Name = "FlatButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Enums "

        Public Enum PieButtonStyles
            UpperLeft
            UpperRight
            LowerLeft
            LowerRight
        End Enum

#End Region

#Region " Variables "

        Dim _ButtonStyle As PieButtonStyles = PieButtonStyles.UpperLeft
        Dim _CircleRadius As Integer = 0
        Dim _CircleLocation As Point = New Point(0, 0)
#End Region

#Region " Properties "

        Public Property ButtonStyle() As PieButtonStyles
            Get
                Return _ButtonStyle
            End Get
            Set(ByVal value As PieButtonStyles)
                _ButtonStyle = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Property CircleRadius() As Integer
            Get
                Return _CircleRadius
            End Get
            Set(ByVal value As Integer)
                _CircleRadius = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Property CircleLocation() As Point
            Get
                Return _CircleLocation
            End Get
            Set(ByVal value As Point)
                _CircleLocation = value
                Me.DrawAllButtons()
            End Set
        End Property


#End Region

#Region " Subs "

        Private Sub PieButton_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            Me.lblTextSize = Me.Size
        End Sub

#End Region

#Region " Draw Pie Button "

        Public Overrides Function DrawButton() As Bitmap

            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            End If


            Try
                mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            Catch ex As Exception
                mybitmap = New Bitmap(1, 1)
                mybitmap.SetPixel(0, 0, System.Drawing.Color.FromArgb(0, 0, 0, 0))

            End Try

            g = Graphics.FromImage(mybitmap)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            Dim points(2) As Point
            Dim gPath As System.Drawing.Drawing2D.GraphicsPath
            Dim pointTypes(2) As Byte
            pointTypes(0) = CByte(System.Drawing.Drawing2D.PathPointType.Line)
            pointTypes(1) = CByte(System.Drawing.Drawing2D.PathPointType.Line)
            pointTypes(2) = CByte(System.Drawing.Drawing2D.PathPointType.Line)

            gPath = New System.Drawing.Drawing2D.GraphicsPath
            gPath.AddRectangle(New Rectangle(0, 0, Me.Width, Me.Height))

            Select Case _ButtonStyle
                Case PieButtonStyles.UpperLeft
                    points(0) = New Point(0, 0)
                    points(1) = New Point(Me.Width, 0)
                    points(2) = New Point(Me.Width, Me.Height)

                    gPath = New System.Drawing.Drawing2D.GraphicsPath(points, pointTypes)

                    g.FillPath(myBrush, gPath)


                    'Dim pts(3) As Point
                    'pts(0) = New Point(0, 0)
                    'pts(1) = New Point(0, Me.Height)
                    'pts(2) = New Point(Me.Width, Me.Height)
                    'pts(3) = New Point(Me.Width, 0)

                    'Dim ptTypes(3) As Byte
                    'ptTypes(0) = CByte(System.Drawing.Drawing2D.PathPointType.Line)
                    'ptTypes(1) = CByte(System.Drawing.Drawing2D.PathPointType.Line)
                    'ptTypes(2) = CByte(System.Drawing.Drawing2D.PathPointType.Line)
                    'ptTypes(3) = CByte(System.Drawing.Drawing2D.PathPointType.Line)

                    'Dim mypath As New System.Drawing.Drawing2D.GraphicsPath(pts, ptTypes)

                    'Dim nRegion As New Region(mypath)

                    'nRegion.Exclude(gPath)

                    'Me.Region = nRegion


                    points(0) = New Point(0, 0)
                    points(1) = New Point(0, Me.Height)
                    points(2) = New Point(Me.Width, Me.Height)

                Case PieButtonStyles.LowerLeft
                    points(0) = New Point(0, 0)
                    points(1) = New Point(0, Me.Height)
                    points(2) = New Point(Me.Width, Me.Height)

                    gPath = New System.Drawing.Drawing2D.GraphicsPath(points, pointTypes)

                    g.FillPath(myBrush, gPath)
                    points(0) = New Point(0, 0)
                    points(1) = New Point(0, Me.Height)
                    points(2) = New Point(Me.Width, Me.Height)

            End Select


            g.FillEllipse(Brushes.Black, New Rectangle(_CircleLocation.X - _CircleRadius, _CircleLocation.Y - _CircleRadius, _CircleRadius * 2, _CircleRadius * 2))

            gPath.AddEllipse(New Rectangle(_CircleLocation.X - _CircleRadius, _CircleLocation.Y - _CircleRadius, _CircleRadius * 2, _CircleRadius * 2))

            gPath.AddLines(points)



            Dim myRegion As New Region(gPath)

            Me.Region = myRegion




            Return mybitmap
        End Function

#End Region

    End Class

#End Region

#Region " Track Bar "
    <System.ComponentModel.DefaultEvent("Scroll")> _
    Public Class TrackBar
        Inherits Windows.Forms.Control
        Public Event Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Global Variables
        Private _pages As Integer = 1
        Private _CurrentPage As Integer = 1
        Private _color As LCARScolorStyles = LCARScolorStyles.StaticTan
        Private _beeping As Boolean = True
        Private tempX As Integer = 0
        Private scrolling As Boolean = False
        'Permanent Controls
        Dim baseBar As New FlatButton
        Dim movingButton As New FlatButton
        Dim tickPanel As New Panel

#Region " Properties "
        Public Property CurrentPage() As Integer
            Get
                Return _CurrentPage
            End Get
            Set(ByVal value As Integer)
                If value < _pages And value >= 0 Then
                    _CurrentPage = value
                    RaiseEvent Scroll(Me, New System.EventArgs)
                End If
            End Set
        End Property

        Public Property Pages() As Integer
            Get
                Return _pages
            End Get
            Set(ByVal value As Integer)
                If value > 0 Then
                    _pages = value
                    If CurrentPage >= _pages Then
                        CurrentPage = 1
                    End If
                    If value = 1 Then 'If there is only one page
                        movingButton.Visible = False
                    Else 'If there is more than one page
                        movingButton.Visible = True
                        movingButton.Left = -2.5
                    End If
                    redraw()
                Else
                    Throw New IndexOutOfRangeException
                End If
            End Set
        End Property
        Public Property TickColor() As LCARScolorStyles
            Get
                Return _color
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color = value
                redraw()
            End Set
        End Property
        Public Property Beeping() As Boolean
            Get
                Return _beeping
            End Get
            Set(ByVal value As Boolean)
                _beeping = value
                redraw()
            End Set
        End Property
#End Region

#Region " Event Handlers "
        Public Sub Me_Resize() Handles Me.Resize
            redraw()
        End Sub
        Public Sub Tick_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            'code to set position of moving button
            movingButton.Left = ((Me.Width - 5) / (_pages - 1)) * (sender.data - 1) - 2.5
            CurrentPage = sender.data
        End Sub
        Public Sub Button_Mouse_Down(ByVal sender As Object, ByVal e As System.EventArgs)
            tempX = MousePosition.X - movingButton.Left
            scrolling = True
        End Sub
        Public Sub Button_Mouse_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            If scrolling Then
                movingButton.Left = MousePosition.X - tempX
            End If
        End Sub
        Public Sub Button_Mouse_Up(ByVal sender As Object, ByVal e As System.EventArgs)
            scrolling = False
            Dim page As Integer = (movingButton.Left + (Me.Width - 5) / (2 * _pages - 1)) \ ((Me.Width - 5) / (_pages - 1))
            movingButton.Left = ((Me.Width - 5) / (_pages - 1)) * (page) - 2.5
            CurrentPage = page
        End Sub
#End Region

#Region " Subs "

        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 15)
            Me.ResumeLayout()
        End Sub
        Public Sub New()
            InitializeComponent()
            With baseBar
                .Width = Me.Width
                .Height = Me.Height / 3
                .Top = .Height * 2
                .Left = 0
                .Text = ""
                .Clickable = False
                .Color = TickColor
            End With
            Me.Controls.Add(baseBar)
            With movingButton
                .Width = 15
                .Height = Me.Height
                .Left = -5
                .Top = 0
                .Text = ""
                .Visible = False
                .Beeping = False
            End With
            AddHandler movingButton.MouseDown, AddressOf Button_Mouse_Down
            AddHandler movingButton.MouseUp, AddressOf Button_Mouse_Up
            AddHandler movingButton.MouseMove, AddressOf Button_Mouse_Move
            Me.Controls.Add(movingButton)
            With tickPanel
                .Width = Me.Width
                .Height = 2 * Me.Height / 3
                .Left = 0
                .Top = 0
            End With
            Me.Controls.Add(tickPanel)
        End Sub
        Public Sub LoadTabs()
            tickPanel.Controls.Clear()
            If Pages > 1 Then
                Dim i As Integer
                Dim x As Decimal = (Me.Width - 5) / (_pages - 1)
                For i = 0 To Pages
                    'Code to draw all tick marks
                    Dim myTick As New FlatButton
                    With myTick
                        .Left = i * x
                        .Top = 0
                        .Width = 5
                        .Height = Me.Height
                        .Text = ""
                        .Color = TickColor
                        .Data = i + 1
                        .Beeping = _beeping
                    End With
                    AddHandler myTick.Click, AddressOf Tick_Click
                    tickPanel.Controls.Add(myTick)
                Next
            End If
        End Sub
        Public Sub redraw()
            With baseBar
                .Width = Me.Width
                .Height = Me.Height / 3
                .Top = .Height * 2
                .Left = 0
                .Color = TickColor
            End With
            With movingButton
                .Width = 15
                .Height = Me.Height
                .Left = -5
                .Top = 0
            End With
            With tickPanel
                .Width = Me.Width
                .Height = 2 * Me.Height / 3
                .Left = 0
                .Top = 0
            End With
            LoadTabs()
        End Sub
#End Region

    End Class

#End Region

#Region " Progress Bar "

    Public Class ProgressBar
        Inherits Control

#Region " Global Variables "

        'Global Variables
        Private _value As Decimal = 0.5
        Private _color1 As LCARScolorStyles = LCARScolorStyles.StaticTan
        Private _color2 As LCARScolorStyles = LCARScolorStyles.PrimaryFunction
        Private _horizontal As Integer = 10
        Private _vertical As Integer = 20
        Private _spacing As Integer = 5
        Private _style As ProgressBarStyle = ProgressBarStyle.Horizontal

        'Permanent Controls
        Private topLeft As New Elbow
        Private topRight As New Elbow
        Private bottomLeft As New Elbow
        Private bottomRight As New Elbow
        Private topBar As New FlatButton
        Private bottomBar As New FlatButton
        Private leftbar As New FlatButton
        Private rightBar As New FlatButton
        Private display As New FlatButton
#End Region

#Region " Enum "

        Public Enum ProgressBarStyle
            Horizontal = 0
            Vertical = 1
        End Enum

#End Region

#Region " Properties "

        Public Property Value() As Decimal
            Get
                Return _value
            End Get
            Set(ByVal value1 As Decimal)
                If value1 >= 0 And value1 <= 1 Then
                    _value = value1
                    redraw()
                End If
            End Set
        End Property

        Public Property Color1() As LCARScolorStyles
            Get
                Return _color1
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color1 = value
                topLeft.Color = value
                topRight.Color = value
                bottomLeft.Color = value
                bottomRight.Color = value
                topBar.Color = value
                bottomBar.Color = value
                rightBar.Color = value
                leftbar.Color = value
            End Set
        End Property

        Public Property Color2() As LCARScolorStyles
            Get
                Return _color2
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color2 = value
                display.Color = value
            End Set
        End Property

        Public Property TopText() As String
            Get
                Return topBar.Text
            End Get
            Set(ByVal value As String)
                topBar.Text = value
            End Set
        End Property

        Public Property TopTextAlign() As System.Drawing.ContentAlignment
            Get
                Return topBar.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                topBar.ButtonTextAlign = value
            End Set
        End Property

        Public Property BottomText() As String
            Get
                Return bottomBar.Text
            End Get
            Set(ByVal value As String)
                bottomBar.Text = value
            End Set
        End Property

        Public Property BottomTextAlign() As System.Drawing.ContentAlignment
            Get
                Return bottomBar.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                bottomBar.ButtonTextAlign = value
            End Set
        End Property

        Public Property HorizontalBarThickness() As Integer
            Get
                Return _horizontal
            End Get
            Set(ByVal value As Integer)
                _horizontal = value
                redraw()
            End Set
        End Property

        Public Property VerticalBarThickness() As Integer
            Get
                Return _vertical
            End Get
            Set(ByVal value As Integer)
                _vertical = value
                redraw()
            End Set
        End Property

        Public Property Spacing() As Integer
            Get
                Return _spacing
            End Get
            Set(ByVal value As Integer)
                _spacing = value
                redraw()
            End Set
        End Property

        Public Property ProgressBarOrientation() As ProgressBarStyle
            Get
                Return _style
            End Get
            Set(ByVal value As ProgressBarStyle)
                _style = value
                redraw()
            End Set
        End Property

#End Region

#Region " Event Handlers "
        Public Sub Me_resize() Handles Me.Resize
            redraw()
        End Sub
#End Region

#Region " Subs "
        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 100)
            Me.ResumeLayout()
        End Sub
        Public Sub New()
            InitializeComponent()
            'Elbows
            With topLeft
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperLeft
                .Text = ""
                .Top = 0
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
            End With
            Me.Controls.Add(topLeft)
            With topRight
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperRight
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = 0
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(topRight)
            With bottomRight
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.LowerRight
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(bottomRight)
            With bottomLeft
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.LowerLeft
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(bottomLeft)
            'Bars
            With topBar
                .Color = _color1
                .Clickable = False
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = 0
                .Left = topLeft.Width
            End With
            Me.Controls.Add(topBar)
            With bottomBar
                .Color = _color1
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.BottomRight
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = Me.Height - .Height
                .Left = topLeft.Width
            End With
            Me.Controls.Add(bottomBar)
            With leftbar
                .Color = _color1
                .Clickable = False
                .Text = ""
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = 0
            End With
            Me.Controls.Add(leftbar)
            With rightBar
                .Color = _color1
                .Clickable = False
                .Text = ""
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = Me.Width - .Width
            End With
            Me.Controls.Add(rightBar)
            'Display
            With display
                .Color = _color2
                .Clickable = False
                .Text = ""
                If _style = ProgressBarStyle.Horizontal Then
                    .Height = rightBar.Height
                    .Width = topBar.Width * Value
                    .Top = topRight.Height
                    .Left = topRight.Width
                Else
                    .Height = rightBar.Height * _value
                    .Width = topBar.Width
                    .Top = Me.Height - (.Height + topRight.Height)
                    .Left = topRight.Width
                End If
            End With
            Me.Controls.Add(display)
        End Sub

        Public Sub redraw()
            With topLeft
                .Top = 0
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
            End With
            With topRight
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = 0
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            With bottomRight
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            With bottomLeft
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            'Bars
            With topBar
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = 0
                .Left = topLeft.Width
            End With
            With bottomBar
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = Me.Height - .Height
                .Left = topLeft.Width
            End With
            With leftbar
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = 0
            End With
            With rightBar
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = Me.Width - .Width
            End With
            'Display
            With display
                If _style = ProgressBarStyle.Horizontal Then
                    .Height = rightBar.Height
                    .Width = topBar.Width * Value
                    .Top = topRight.Height
                    .Left = topRight.Width
                Else
                    .Height = rightBar.Height * _value
                    .Width = topBar.Width
                    .Top = Me.Height - (.Height + topRight.Height)
                    .Left = topRight.Width
                End If
            End With

        End Sub

#End Region

    End Class
#End Region

#Region " ScrollPanel (Not finished!) "

    Public Class ScrollPanel
        Inherits Windows.Forms.Control

        ' Inherits LCARS.LCARSbuttonClass

        Sub New()
            Me.SetStyle(ControlStyles.ContainerControl, True)
        End Sub
    End Class

    '#Region " Option Button "

    '    <System.ComponentModel.DefaultEvent("Click")> _
    '    Public Class OptionButton
    '        Inherits LCARS.LCARSbuttonClass

    '#Region " Control Design Information "
    '        Public Sub New()
    '            MyBase.New()

    '            'This call is required by the Windows Form Designer.
    '            InitializeComponent()

    '            'Add any initialization after the InitializeComponent() call

    '        End Sub

    '        'UserControl1 overrides dispose to clean up the component list.
    '        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '            If disposing Then
    '                If Not (components Is Nothing) Then
    '                    components.Dispose()
    '                End If
    '            End If
    '            MyBase.Dispose(disposing)
    '        End Sub

    '        'Required by the Windows Form Designer
    '        Private components As System.ComponentModel.IContainer

    '        'NOTE: The following procedure is required by the Windows Form Designer
    '        'It can be modified using the Windows Form Designer.  
    '        'Do not modify it using the code editor.

    '        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '            Me.SuspendLayout()
    '            '
    '            'StandardButton
    '            '
    '            Me.Name = "StandardButton"
    '            Me.Size = New System.Drawing.Size(200, 100)
    '            Me.ResumeLayout(False)

    '        End Sub
    '#End Region

    '#Region " Enums "

    '        Public Enum LCARSButtonStyle
    '            left = 0
    '            right = 1
    '        End Enum

    '#End Region

    '#Region " Global Varibles "
    '        Dim myButtonType As LCARSButtonStyle = LCARSButtonStyle.right
    '#End Region

    '#Region " Properties "
    '        Public Property ButtonStyle() As LCARSButtonStyle
    '            Get
    '                Return myButtonType
    '            End Get
    '            Set(ByVal value As LCARSButtonStyle)
    '                myButtonType = value
    '                Me.DrawAllButtons()
    '            End Set
    '        End Property
    '#End Region

    '#Region " Subs "


    '        Public Overrides Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
    '            CheckForIllegalCrossThreadCalls = False
    '        End Sub

    '#End Region

    '#Region " Draw Standard Button "

    '        Public Overrides Function DrawButton() As Bitmap
    '            Dim mybitmap As Bitmap
    '            Dim g As Graphics
    '            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
    '            Dim halfHeight As Integer
    '            Dim quarterHeight As Integer
    '            Dim quarterWidth As Integer

    '            If Me.RedAlert = LCARSalert.Red Then
    '                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
    '            ElseIf Me.RedAlert = LCARSalert.White Then
    '                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
    '            End If

    '            mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
    '            g = Graphics.FromImage(mybitmap)

    '            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

    '            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

    '            halfHeight = Me.Height \ 2
    '            quarterHeight = Me.Height \ 4
    '            quarterWidth = Me.Width \ 4



    '            If myButtonType = LCARSButtonStyle.right Then
    '                g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
    '                g.FillRectangle(myBrush, halfHeight, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
    '                g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)


    '                lblText.Location = New Point(Me.Height \ 2, 0)
    '                lblText.Size = New Size(Me.Width - Me.Height, Me.Height)

    '            Else
    '                g.FillEllipse(myBrush, New Rectangle(0, 0, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, 0, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(0, Me.Height - quarterHeight, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, Me.Height - quarterHeight, quarterHeight, quarterHeight))

    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, 0, Me.Width - quarterHeight, quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, Me.Height - quarterHeight, Me.Width - quarterHeight, quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(0, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(Me.Width - quarterHeight, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, quarterHeight \ 2, Me.Width - quarterHeight, Me.Height - quarterHeight))

    '                Select Case myButtonType
    '                    Case LCARSbuttonStyles.RoundedSquareSlant

    '                        Dim slant As Bitmap = New Bitmap(mybitmap)

    '                        Dim mypoints(2) As Point

    '                        mypoints(0) = New Point(Me.Width \ 4, 0)
    '                        mypoints(1) = New Point(Me.Width, 0)
    '                        mypoints(2) = New Point(0, Me.Height)

    '                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
    '                        g.DrawImage(slant, mypoints)

    '                        lblText.Location = New Point(Me.Width \ 4, 0)
    '                        lblText.Size = New Size(Me.Width - (Me.Width \ 2), Me.Height)
    '                    Case Else
    '                        lblText.Location = New Point(0, 0)
    '                        lblText.Size = New Size(Me.Width, Me.Height)
    '                End Select

    '            End If




    '            Return mybitmap
    '        End Function

    '#End Region

    '    End Class
    '#End Region
#End Region

End Namespace

#End Region

#Region " LCARSMSGBOX "

'<Microsoft.VisualBasic.CompilerServices.StandardModule()> _
Public Class UI
    Shared buttonclick As MsgBoxResult
    Shared form As New Form
    Private Declare Auto Function MessageBeep Lib "user32.dll" (ByVal wType As Int32) As Boolean
    Private Sub New()
    End Sub
    Private Shared Sub shows(ByVal prompt As Object, ByVal buttons As Microsoft.VisualBasic.MsgBoxStyle, ByVal title As String)
        'ByVal buttons As LCARScolorStyles,
        'Dim buttonclick As String = "OK"
        Dim colour As LCARScolorStyles
        Dim cancleenabled, AbortVis, RetryVis, IgnoreVis, YesVis, NoVis As Boolean
        Dim okx, cx As Integer


        okx = 183
        cx = 50
        cancleenabled = False
        AbortVis = False
        RetryVis = False
        IgnoreVis = False
        YesVis = False
        NoVis = False


        ' enumeration splitter
        'buttons
        Dim butstyle(4) As Integer
        For ii As MsgBoxStyle = 0 To 5
            If (buttons And ii) <> 0 Then
                butstyle(0) = buttons And ii
            End If
        Next
        'style
        For ii As MsgBoxStyle = 16 To 64 Step 16
            If (buttons And ii) <> 0 Then
                butstyle(1) = buttons And ii
            End If
        Next
        'default button
        For ii As MsgBoxStyle = 256 To 768 Step 256
            If (buttons And ii) <> 0 Then
                butstyle(2) = buttons And ii
            End If
        Next
        'system modal
        If (buttons And MsgBoxStyle.SystemModal) <> 0 Then
            butstyle(3) = buttons And MsgBoxStyle.SystemModal
        End If
        'Special args
        For ii As MsgBoxStyle = MsgBoxStyle.MsgBoxHelp To MsgBoxStyle.MsgBoxRtlReading Step MsgBoxStyle.MsgBoxHelp
            If (buttons And ii) <> 0 Then
                butstyle(4) = buttons And ii
            End If
        Next
        ' end unumeration splitter

        Select Case butstyle(0)
            Case 0
                'vbOkOnly
            Case 1
                'vbOkCancle
                cancleenabled = True

            Case 2
                'vbAbortRetryIgnore
                AbortVis = True
                RetryVis = True
                IgnoreVis = True
                cancleenabled = True
                cx = 210
                okx = 115

            Case 3
                'vbYesNoCancle
                cancleenabled = True
                YesVis = True
                NoVis = True
                okx = 210
                cx = 115

            Case 4
                'vbYesNo
                YesVis = True
                NoVis = True
                okx = 210
                cx = 115

            Case 5
                'vbRetryCancle
                RetryVis = True
                cancleenabled = True

        End Select
        Select Case butstyle(1)
            Case 16
                'vbCritical
                colour = LCARScolorStyles.FunctionOffline
                MessageBeep(MsgBoxStyle.Critical)
                ' pass redAlert() to LCARSmain if exists.
                Try

                Catch ex As Exception

                End Try
            Case 32
                'vbQuestion
                colour = LCARScolorStyles.StaticBlue
                MessageBeep(MsgBoxStyle.Question)
            Case 48
                'vbExclamation
                colour = LCARScolorStyles.StaticTan
                MessageBeep(MsgBoxStyle.Exclamation)
            Case 64
                'vbInformation
                colour = LCARScolorStyles.LCARSDisplayOnly
                MessageBeep(MsgBoxStyle.Information)
            Case Else
                colour = LCARScolorStyles.StaticTan
                MessageBeep(MsgBoxStyle.OkOnly)
        End Select
        Select Case butstyle(2)
            Case 256
                'vbDefaultButton2
            Case 512
                'vbDefaultButton3
            Case 768
                'vbDefaultbutton4
        End Select
        Select Case butstyle(4)
            Case 2
                'vbMsgBoxHelpButton
            Case 3
                'vbMsgBoxSetForground
            Case 4
                'vbMsgBoxRight
            Case 5
                'vbMsgBoxRtlReading
        End Select

        'draw form
        form.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        form.Size = New System.Drawing.Size(305, 200)
        form.BackColor = Color.Black
        form.StartPosition = FormStartPosition.CenterScreen
        form.TopMost = True


        'draw elbow1
        Dim elberr1 As New LCARSControls.Elbow
        form.Controls.Add(elberr1)
        elberr1.Location = New System.Drawing.Point(0, 0)
        elberr1.Size = New System.Drawing.Size(80, 60)
        elberr1.ButtonHeight = 30
        elberr1.ButtonWidth = 10
        elberr1.Clickable = False
        elberr1.ElbowStyle = LCARSControls.Elbow.LCARSelbowStyles.UpperRight
        elberr1.Color = colour
        elberr1.ButtonText = ""

        'draw 2nd elbow
        Dim elberr2 As New LCARSControls.Elbow
        form.Controls.Add(elberr2)
        elberr2.Location = New System.Drawing.Point(0, 140)
        elberr2.Size = New System.Drawing.Size(80, 60)
        elberr2.ButtonHeight = 15
        elberr2.ButtonWidth = 10
        elberr2.Clickable = False
        elberr2.ElbowStyle = LCARSControls.Elbow.LCARSelbowStyles.LowerRight
        elberr2.Color = colour
        elberr2.ButtonText = ""

        'draw title
        Dim txtbtnerr As New LCARSControls.TextButton
        form.Controls.Add(txtbtnerr)
        txtbtnerr.Location = New System.Drawing.Point(50, 0)
        txtbtnerr.Size = New System.Drawing.Size(255, 30)
        txtbtnerr.ButtonTextHeight = 31
        txtbtnerr.Clickable = False
        txtbtnerr.Color = colour
        txtbtnerr.ButtonText = title

        'draw vbar
        Dim fbverr As New LCARSControls.FlatButton
        form.Controls.Add(fbverr)
        fbverr.Location = New System.Drawing.Point(0, 66)
        fbverr.Size = New System.Drawing.Size(10, 68)
        fbverr.Clickable = False
        fbverr.Color = colour
        fbverr.ButtonText = ""

        'draw bottombar
        Dim hpbverr As New LCARSControls.HalfPillButton
        form.Controls.Add(hpbverr)
        hpbverr.Location = New System.Drawing.Point(85, 185)
        hpbverr.Size = New System.Drawing.Size(217, 15)
        hpbverr.Clickable = False
        hpbverr.Color = colour
        hpbverr.ButtonText = ""

        'draw text
        Dim txterr As New RichTextBox
        form.Controls.Add(txterr)
        txterr.Location = New System.Drawing.Point(30, 36)
        txterr.Size = New System.Drawing.Size(243, 107)
        txterr.BackColor = Color.Black
        txterr.BorderStyle = BorderStyle.None
        txterr.WordWrap = True
        txterr.Font = New System.Drawing.Font("LCARS", 14, FontStyle.Regular)
        txterr.ForeColor = Color.Orange
        txterr.BringToFront()
        txterr.Text = prompt
        txterr.ReadOnly = True

        ' BUTTONS

        'draw OK/Yes/retry button
        Dim SBOkerr As New LCARSControls.StandardButton
        form.Controls.Add(SBOkerr)
        With SBOkerr
            .Location = New System.Drawing.Point(okx, 149)
            .Size = New System.Drawing.Size(90, 30)
            .Color = LCARScolorStyles.PrimaryFunction
            If YesVis Then
                .ButtonText = "YES"
                AddHandler SBOkerr.Click, AddressOf OnsbYerrClick
            ElseIf RetryVis Then
                .ButtonText = "RETRY"
                AddHandler SBOkerr.Click, AddressOf OnsbRerrClick
            Else
                .ButtonText = "OK"
                AddHandler SBOkerr.Click, AddressOf OnsbokerrClick
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .BringToFront()
        End With

        'draw cancle/ignore button
        Dim SBCerr As New LCARSControls.StandardButton
        form.Controls.Add(SBCerr)
        With SBCerr
            .Location = New System.Drawing.Point(cx, 149)
            .Size = New System.Drawing.Size(90, 30)
            If cancleenabled Then .Color = LCARScolorStyles.CriticalFunction Else .Color = LCARScolorStyles.FunctionOffline
            If IgnoreVis Then
                .ButtonText = "IGNORE"
                AddHandler SBCerr.Click, AddressOf OnsbIerrClick
            Else
                .ButtonText = "CANCEL"
                AddHandler SBCerr.Click, AddressOf OnsbcerrClick
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .Flash = Not cancleenabled
            .Clickable = cancleenabled
            .BringToFront()
        End With


        'draw abort/no button
        Dim SBAerr As New LCARSControls.StandardButton
        form.Controls.Add(SBAerr)
        With SBAerr
            .Location = New System.Drawing.Point(20, 149)
            .Size = New System.Drawing.Size(90, 30)
            .Color = LCARScolorStyles.CriticalFunction
            If AbortVis Then
                .ButtonText = "ABORT"
                AddHandler SBAerr.Click, AddressOf OnsbAerrClick
            ElseIf NoVis Then
                .ButtonText = "NO"
                AddHandler SBAerr.Click, AddressOf OnsbNerrClick
            Else
                SBAerr.Visible = False
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .BringToFront()
        End With

        'Dim form As New Form

        form.ShowDialog()

        'If msgalert Then
        'Do
        'For i As Integer = 0 To 4
        'alertbut(i).RedAlert = LCARSalert.White
        'If i > 0 Then
        'alertbut(i - 1).RedAlert = LCARSalert.Red
        'Else : alertbut(4).RedAlert = LCARSalert.Red
        'End If
        'Next
        Application.DoEvents()
        'Loop
        'End If
    End Sub

    Public Shared Function MsgBox(ByVal prompt As Object, Optional ByVal buttons As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly, Optional ByVal title As String = "LCARS") As MsgBoxResult
        'Public Sub errbox_load(ByVal prompt As String, Optional ByVal title As String = "ERROR", Optional ByVal alert As String = "NO")
        'LCARScolorStyles = LCARScolorStyles.StaticTan
        Application.DoEvents()
        shows(prompt, buttons, title)

        'msgbox("prompt as object", [buttons as microsoft.visualbasic.msgboxstyle 
        '= microsoft.visualbasic.msgboxstyle.defaultbutton1, "title as object = nothing) 
        'as microsoft.visualbasic.msgboxresult

        Return buttonclick
    End Function

    Private Shared Sub OnsbokerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Ok
        form.Dispose()
    End Sub
    Private Shared Sub OnsbcerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Cancel
        form.Dispose()
    End Sub
    Private Shared Sub OnsbAerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Abort
        form.Dispose()
    End Sub
    Private Shared Sub OnsbRerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Retry
        form.Dispose()
    End Sub
    Private Shared Sub OnsbIerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Ignore
        form.Dispose()
    End Sub
    Private Shared Sub OnsbYerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Yes
        form.Dispose()
    End Sub
    Private Shared Sub OnsbNerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.No
        form.Dispose()
    End Sub
End Class

#End Region
