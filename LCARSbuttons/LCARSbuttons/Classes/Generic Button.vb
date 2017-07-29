Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

#Region " GenericButton "
''' <summary>
''' Generic LCARS button that all others inherit from
''' </summary>
''' <remarks>
''' This class can be placed directly on a form in the designer. If you do so, you will wind up with something resembling a Standard 
''' Button, but with fewer features. This class should only be used directly when you don't know what kind of LCARS button you're
''' dealing with. Almost everything in modBusiness is declared that way for exactly that reason. 
''' </remarks>
<System.ComponentModel.DefaultEvent("Click"), Designer(GetType(GenericButtonDesigner))> _
Public Class LCARSbuttonClass
    Implements LCARS.IAlertable, LCARS.IBeeping, LCARS.IColorable, IButtonControl
    Inherits System.Windows.Forms.Button


#Region " Control Design Information "
    ''' <summary>
    ''' Creates a new instance of the LCARButtonClass object
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        MyBase.DoubleBuffered = True
        Sound.Load()
        'Add any initialization after the InitializeComponent() call
    End Sub

    ''' <summary>
    ''' Disposes of the current instance of LCARSButtonClass
    ''' </summary>
    ''' <param name="disposing">Boolean indicating whether to dispose of internal components</param>
    ''' <remarks>Overriden to clean up the component list</remarks>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'Needed to end the flashing thread and allow button to be disposed at all
        If flashing Then
            flasher.Abort()
        End If
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
        'StandardButton
        '
        Me.Name = "LCARSbutton"
        Me.Size = New System.Drawing.Size(147, 36)
        'Me.Controls.Add(Me.lblText)
        'lblText.BringToFront()
        Me.ResumeLayout(False)
        Me.Text = "LCARS"



    End Sub
#End Region

#Region " Global Variables "
    Private WithEvents _ColorsAvailable As New LCARS.LCARScolor


    Dim myColor As LCARS.LCARScolorStyles = LCARScolorStyles.MiscFunction
    Dim isLit As Boolean = True
    Dim NormalButton As Bitmap
    Dim UnLitButton As Bitmap
    Protected inRedAlert As LCARS.LCARSalert = LCARSalert.Normal
    Dim RA As Boolean = False
    Private Shared Sound As New System.Media.SoundPlayer(My.Resources._207)
    Dim buttonData As Object
    Dim buttonData2 As Object
    Dim noDraw As Boolean = False
    Protected textHeight As Integer = 14
    Dim doBeep As Boolean = False
    Dim flashing As Boolean = False
    Dim flasher As Threading.Thread = New Threading.Thread(AddressOf flashThread)
    Dim flashingInterval As Integer = 500
    Dim isFlashing As Boolean
    Dim canClick As Boolean = True
    Dim oAlign As System.Drawing.ContentAlignment
    Dim WithEvents tmrTextScroll As New Timer
    Protected myText As String = "LCARS"
    Protected forceCapital As Boolean = True
    Private tmpStr As String = ""
    Protected _customAlertColor As Color
    Protected _textAlign As ContentAlignment = ContentAlignment.TopLeft
    Protected _font As Font = New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point)
    Protected _ellipsisMode As EllipsisModes = EllipsisModes.Character
    Protected _autoEllipsis As Boolean = True
    Protected _textVisible As Boolean = True
    Protected _textSize As Size = Me.Size
    Protected _textLocation As Point = New Point(0, 0)
#End Region

#Region " Event Handlers "
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        If canClick Then
            playSound()
            MyBase.OnClick(e)
        End If
    End Sub

    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        If canClick Then
            playSound()
            MyBase.OnDoubleClick(e)
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If canClick Then
            If _ColorsAvailable.getColor(myColor).ToArgb = System.Drawing.Color.White.ToArgb Then
                inRedAlert = LCARSalert.Red
            Else
                inRedAlert = LCARSalert.White
            End If
            DrawAllButtons()
            MyBase.OnMouseDown(e)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If canClick Then
            MyBase.OnMouseMove(e)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If canClick Then
            If RA = False Then
                Me.RedAlert = LCARSalert.Normal
            End If
            MyBase.OnMouseUp(e)
        End If
    End Sub
#End Region

#Region " Enum "
    ''' <summary>
    ''' Contains the types for different methods of AutoEllipsis functionality
    ''' </summary>
    Public Enum EllipsisModes
        ''' <summary>
        ''' Clips strings to the nearest character
        ''' </summary>
        Character = 0
        ''' <summary>
        ''' Clips strings to the nearest word
        ''' </summary>
        Word = 1
    End Enum

#End Region

#Region " Properties "
    ''' <summary>
    ''' The font used by the label for drawing text.
    ''' </summary>
    ''' <value>New font to be used</value>
    ''' <returns>Current font in use</returns>
    ''' <remarks>
    ''' This property is hidden by default, and should only be used if you need to change the family of the font used.
    ''' Size can be changed through other properties.
    ''' </remarks>
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overrides Property Font() As System.Drawing.Font
        Get
            Return _font
        End Get
        Set(ByVal value As System.Drawing.Font)
            _font = value
            Me.Invalidate()
        End Set
    End Property


    ''' <summary>
    ''' The text of the control
    ''' </summary>
    ''' <value>New text to set</value>
    ''' <returns>Current text of the control.</returns>
    ''' <remarks>This property duplicates the functionality of the ButtonText property.</remarks>
    Public Overrides Property Text() As String
        Get
            Return ButtonText
        End Get
        Set(ByVal value As String)
            ButtonText = value
        End Set
    End Property

    ''' <summary>
    ''' Alignment for text on button
    ''' </summary>
    ''' <value>New alignment to use</value>
    ''' <returns>Current alignment</returns>
    ''' <remarks>Be careful if using this with an elbow; it can have interesting results...</remarks>
    <DefaultValue(ContentAlignment.BottomRight)> _
        Public Overridable Property ButtonTextAlign() As ContentAlignment
        Get
            Return _textAlign
        End Get
        Set(ByVal value As ContentAlignment)
            _textAlign = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides ReadOnly Property ScaleChildren() As Boolean
        Get
            Return False
        End Get
    End Property

    ''' <summary>
    ''' Forces text to be displayed as all-capitals
    ''' </summary>
    ''' <value>New setting</value>
    ''' <returns>Current setting</returns>
    ''' <remarks>
    ''' If this property is set to true, the text will be converted to all-capitals. If you are going to use that text for comparisons,
    ''' you should be sure to use .ToUpper() to ensure they are the same case.
    ''' </remarks>
    <DefaultValue(True)> _
        Public Property _ForceCaps() As Boolean
        Get
            Return forceCapital
        End Get
        Set(ByVal value As Boolean)
            forceCapital = value
        End Set
    End Property

    ''' <summary>
    ''' Cuts off text that is longer than the control with ...
    ''' </summary>
    ''' <value>New AutoEllipsis setting</value>
    ''' <returns>Current AutoEllipsis setting</returns>
    ''' <remarks>
    ''' If the text is longer than the control, it will be shown in a marquee when the user mouses over it. 
    ''' </remarks>
    <DefaultValue(True)> _
       Public Property AutoEllipsis() As Boolean
        Get
            Return _autoEllipsis
        End Get
        Set(ByVal value As Boolean)
            _autoEllipsis = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Sets whether the control can be clicked
    ''' </summary>
    ''' <value>New Clickable setting</value>
    ''' <returns>Current Clickable setting</returns>
    ''' <remarks>
    ''' If you are using a control as a static element, set this to false to prevent the user from trying to click on it.
    ''' </remarks>
    Public Property Clickable() As Boolean
        Get
            Return canClick
        End Get
        Set(ByVal value As Boolean)
            canClick = value
        End Set
    End Property

    ''' <summary>
    ''' Sets whether the control is flashing
    ''' </summary>
    ''' <value>New flashing setting</value>
    ''' <returns>Current flashing setting</returns>
    ''' <remarks>
    ''' This works by setting the RedAlert property of the control. If you use it, it should be for good reason.
    ''' </remarks>
    <DefaultValue(False)> _
        Public Property Flash() As Boolean
        Get
            Return flashing
        End Get
        Set(ByVal value As Boolean)
            flashing = value
            If Not Me.DesignMode Then
                If flashing Then
                    flasher = New Threading.Thread(AddressOf flashThread)
                    flasher.Start()
                Else
                    flasher.Abort()
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Length of flashing interval
    ''' </summary>
    ''' <value>New flash length</value>
    ''' <returns>Current flash length</returns>
    ''' <remarks></remarks>
    Public Property FlashInterval() As Integer
        Get
            Return flashingInterval
        End Get
        Set(ByVal value As Integer)
            flashingInterval = value
        End Set
    End Property

    ''' <summary>
    ''' Stops control from redrawing if set to true
    ''' </summary>
    ''' <value>New draw state</value>
    ''' <returns>Current draw state</returns>
    ''' <remarks>
    ''' This should be used to reduce CPU load when making many changes to a button's state that would require a redraw. Just
    ''' remember to set it to True when you've finished.
    ''' </remarks>
    Public Property holdDraw() As Boolean
        Get
            Return noDraw
        End Get
        Set(ByVal value As Boolean)
            noDraw = value
            DrawAllButtons()
        End Set
    End Property

    ''' <summary>
    ''' Data field for the control
    ''' </summary>
    ''' <value>New value</value>
    ''' <returns>Current value</returns>
    ''' <remarks>
    ''' This is for the programmer's convenience in associating information with a control. There is no built-in functionality, 
    ''' so it is exactly what you make it.
    ''' </remarks>
    Public Property Data() As Object
        Get
            Return buttonData
        End Get
        Set(ByVal value As Object)
            buttonData = value
        End Set
    End Property

    ''' <summary>
    ''' Data field for the control
    ''' </summary>
    ''' <value>New value</value>
    ''' <returns>Current value</returns>
    ''' <remarks>
    ''' This is for the programmer's convenience in associating information with a control. There is no built-in functionality, 
    ''' so it is exactly what you make it.
    ''' </remarks>
    Public Property Data2() As Object
        Get
            Return buttonData2
        End Get
        Set(ByVal value As Object)
            buttonData2 = value
        End Set
    End Property

    ''' <summary>
    ''' Primary color of the control.
    ''' </summary>
    ''' <remarks>
    ''' Do not attempt to use colors for visual effect. Color mappings may be changed by the end user, completely eliminating
    ''' any color matchings that may exist. Use colors based on the control's function.
    ''' </remarks>
    <DefaultValue(LCARS.LCARScolorStyles.NavigationFunction)> _
        Public Property Color() As LCARS.LCARScolorStyles
        Get
            Return myColor
        End Get
        Set(ByVal value As LCARS.LCARScolorStyles)
            myColor = value
            DrawAllButtons()
        End Set
    End Property

    ''' <summary>
    ''' The text displayed on the button.
    ''' </summary>
    ''' <remarks>
    ''' The button's <see cref="Text">Text</see> property is an alias of this property.
    ''' </remarks>
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
                myText = value.ToUpper
            Else
                myText = value
            End If
            tmpStr = myText
            If textHeight = -1 Then
                ButtonTextHeight = -1
            End If
            Me.Invalidate()
        End Set
    End Property
    ''' <summary>
    ''' Sets the visibility of the text
    ''' </summary>
    Protected Property lblTextVisible() As Boolean
        Get
            Return _textVisible
        End Get
        Set(ByVal value As Boolean)
            _textVisible = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Location of label used to display text
    ''' </summary>
    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
       Public Overridable Property lblTextLoc() As Point
        Get
            Return _textLocation
        End Get
        Set(ByVal value As Point)
            _textLocation = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Size of label used to display text
    ''' </summary>
    ''' <remarks>This label does not auto-size, and should be handled accordingly.</remarks>
    <Browsable(False), EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overridable Property lblTextSize() As Size
        Get
            Return _textSize
        End Get
        Set(ByVal value As Size)
            _textSize = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Height of the control's text
    ''' </summary>
    ''' <remarks>
    ''' For the <see cref="LCARS.Controls.TextButton">Text Button</see>, this directly sets the height of the control.
    ''' </remarks>
    Public Overridable Property ButtonTextHeight() As Integer
        Get
            Return textHeight
        End Get
        Set(ByVal value As Integer)
            textHeight = value
            If textHeight = -1 Then
                If myText <> "" Then
                    Dim mysize As New SizeF
                    Dim i As Integer = 1
                    Dim g As Graphics = Graphics.FromImage(New Bitmap(10, 10))
                    mysize = g.MeasureString(myText, New Font("LCARS", i, FontStyle.Regular, GraphicsUnit.Point))

                    Do Until mysize.Width >= Me.Width - 8 Or mysize.Height >= Me.Height
                        i += 1
                        mysize = g.MeasureString(myText, New Font("LCARS", i, FontStyle.Regular, GraphicsUnit.Point))
                    Loop
                    If i < 2 Then
                        i = 2
                    End If
                    _font = New Font("LCARS", i - 1, FontStyle.Regular, GraphicsUnit.Point)
                    textHeight = -1
                End If

            Else
                _font = New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point)
            End If
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Lit property of the control
    ''' </summary>
    ''' <remarks>
    ''' A control that is not lit has been dimmed by applying an alpha layer. This can be used to show a function that is availiable,
    ''' but turned off. An offline function should use the offline function color.
    ''' </remarks>
    Public Overridable Property Lit() As Boolean
        Get
            Return isLit
        End Get
        Set(ByVal value As Boolean)
            isLit = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' The alert status of the control.
    ''' </summary>
    Public Property RedAlert() As LCARS.LCARSalert Implements IAlertable.RedAlert
        Get
            Return inRedAlert
        End Get
        Set(ByVal value As LCARS.LCARSalert)
            inRedAlert = value
            If inRedAlert = LCARSalert.Normal Then
                RA = False
            Else
                RA = True
            End If
            DrawAllButtons()
        End Set
    End Property

    ''' <summary>
    ''' The color to display if RedAlert is set to Custom
    ''' </summary>
    ''' <remarks>
    ''' Setting this property will not result in any change in the display unless
    ''' the RedAlert property is set to Custom.
    ''' </remarks>
    Public Property CustomAlertColor() As Color Implements IAlertable.CustomAlertColor
        Get
            Return _customAlertColor
        End Get
        Set(ByVal value As Color)
            _customAlertColor = value
            DrawAllButtons()
        End Set
    End Property

    ''' <summary>
    ''' Sets whether the control will beep when clicked.
    ''' </summary>
    ''' <remarks>
    ''' This property should be set on application startup to match the global setting. This must be done manually.
    ''' </remarks>
    Public Overridable Property Beeping() As Boolean Implements IBeeping.Beeping
        Get
            Return doBeep
        End Get
        Set(ByVal value As Boolean)
            doBeep = value
        End Set
    End Property

    ''' <summary>
    ''' LCARSColorClass associated with this control.
    ''' </summary>
    ''' <remarks>
    ''' If you need to change the color of a control to a non-predefined color, this has the tools to do it. For example:
    ''' <code>
    ''' Dim myButton as LCARSbuttonClass
    ''' Dim myColors() as String = {"#3366CC", "#99CCFF", "#CC99CC", "#FFCC00", "#FFFF99", "#CC6666", "#FFFFFF", "#FF0000", "#FFCC66", "Orange", "#99CCFF"}
    ''' myButton.ColorsAvailable.setColors(myColors)
    ''' </code>
    ''' That code will set all colors used by this control to the defaults. Naturally you can be more specific if needed.
    ''' </remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ColorsAvailable() As LCARScolor Implements IColorable.ColorsAvailable
        Get
            Return _ColorsAvailable
        End Get
        Set(ByVal value As LCARScolor)
            _ColorsAvailable = value
            DrawAllButtons()
        End Set
    End Property

#End Region

#Region " Subs "
    Protected Overrides Sub ScaleControl(ByVal factor As System.Drawing.SizeF, ByVal specified As System.Windows.Forms.BoundsSpecified)
        Me.ButtonTextHeight = textHeight * factor.Height
        MyBase.ScaleControl(factor, specified)
    End Sub

    Private Sub lblText_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        If Me.CreateGraphics.MeasureString(myText, _font).Width > lblTextSize.Width Then
            tmrTextScroll.Interval = 200
            oAlign = _textAlign
            If _textAlign <= 16 Then
                'bottom aligned
                _textAlign = ContentAlignment.TopLeft
            ElseIf _textAlign <= 256 Then
                'middle aligned
                _textAlign = ContentAlignment.MiddleLeft
            Else
                'top aligned
                _textAlign = ContentAlignment.BottomLeft

            End If
            tmpStr = myText & "              "
            tmrTextScroll.Enabled = True
        End If

    End Sub

    Private Sub lblText_MouseLeave(ByVal sener As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        If tmrTextScroll.Enabled Then
            tmrTextScroll.Enabled = False

            If oAlign > 0 Then
                _textAlign = oAlign
            End If

            tmpStr = myText
            Me.Invalidate()
        End If
    End Sub

    Private Sub tmrTextScroll_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrTextScroll.Tick
        tmpStr = tmpStr.Substring(1) & tmpStr.Substring(0, 1)
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Raises a click event from this control, if clickable.
    ''' </summary>
    Public Sub doClick(ByVal sender As Object, ByVal e As EventArgs)
        OnClick(e)
    End Sub

    Private Sub flashThread()
        Try
            While flashing
                isFlashing = Not isFlashing
                Me.Invalidate()
                Windows.Forms.Application.DoEvents()
                Threading.Thread.Sleep(flashingInterval)
            End While
        Catch t As Threading.ThreadAbortException
            isFlashing = False
            Me.Invalidate()
        End Try
    End Sub

    Private Sub playSound()
        If Not doBeep Then Return
        Dim soundPath As String = GetSetting("LCARS X32", "Application", "ButtonSound", "")
        If Sound Is Nothing Or Sound.SoundLocation <> soundPath Then
            If System.IO.File.Exists(soundPath) Then
                Sound = New System.Media.SoundPlayer(soundPath)
            Else
                Sound = New System.Media.SoundPlayer(My.Resources._207)
            End If
        End If
        Sound.Play()
    End Sub

    ''' <summary>
    ''' Redraws the button and stores the bitmaps to memory.
    ''' </summary>
    Protected Sub DrawAllButtons()
        If noDraw = False Then
            If Not (Me.Width = 0 Or Me.Height = 0) Then
                If Not NormalButton Is Nothing Then
                    'UnlitButton does not require null check
                    NormalButton.Dispose()
                    UnLitButton.Dispose()
                End If
                'Draw and show the standard "normal" button.
                '----------------------------------------------------------------------
                NormalButton = DrawButton()

                'Draw the button that is displayed when the function of the button is 
                'unavailable or disabled.
                '-----------------------------------------------------------------------
                UnLitButton = drawUnlit(NormalButton)

                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub Button_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If textHeight = -1 Then
            ButtonTextHeight = -1 'resize the text
        End If
        DrawAllButtons()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If isLit Xor isFlashing Then
            e.Graphics.DrawImage(NormalButton, 0, 0)
        Else
            e.Graphics.DrawImage(UnLitButton, 0, 0)
        End If
        If lblTextVisible Then
            DrawText(e.Graphics)
        End If
    End Sub

    Private Sub ColorsUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ColorsAvailable.ColorsUpdated
        DrawAllButtons()
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
        ElseIf inRedAlert = LCARSalert.Custom Then
            myBrush = New Drawing.SolidBrush(_customAlertColor)
        End If

        mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
        g = Graphics.FromImage(mybitmap)

        g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

        g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
        g.FillRectangle(myBrush, Me.Size.Height \ 2, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
        g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)
        'Draw text:
        Me.lblTextLoc = New Point(0, 0)
        Me.lblTextSize = New Point(Me.Width - Me.Height, Me.Height)
        g.Dispose()
        Return mybitmap
    End Function

    ''' <summary>
    ''' Draws the text of the control in specified area.
    ''' </summary>
    ''' <param name="g">Graphics object being used to draw the control.</param>
    ''' <remarks>This sub will handle all auto-ellipsis functionality and alignment.
    ''' </remarks>
    Protected Sub DrawText(ByVal g As Graphics)
        If _textVisible Then
            Dim area As Rectangle = New Rectangle(_textLocation, _textSize)
            Dim format As New StringFormat()
            format.FormatFlags = StringFormatFlags.NoWrap
            If tmrTextScroll.Enabled Or Not _autoEllipsis Then
                If _ellipsisMode = EllipsisModes.Character Then
                    format.Trimming = StringTrimming.Character
                Else
                    format.Trimming = StringTrimming.Word
                End If
            Else
                If _ellipsisMode = EllipsisModes.Character Then
                    format.Trimming = StringTrimming.EllipsisCharacter
                Else
                    format.Trimming = StringTrimming.EllipsisWord
                End If
            End If
            If tmrTextScroll.Enabled Then
                format.Alignment = StringAlignment.Near
            Else
                If _textAlign = ContentAlignment.BottomCenter Or _textAlign = ContentAlignment.MiddleCenter Or _textAlign = ContentAlignment.TopCenter Then
                    format.Alignment = StringAlignment.Center
                ElseIf _textAlign = ContentAlignment.BottomRight Or _textAlign = ContentAlignment.MiddleRight Or _textAlign = ContentAlignment.TopRight Then
                    format.Alignment = StringAlignment.Far
                ElseIf _textAlign = ContentAlignment.BottomLeft Or _textAlign = ContentAlignment.MiddleLeft Or _textAlign = ContentAlignment.TopLeft Then
                    format.Alignment = StringAlignment.Near
                End If
            End If
            If _textAlign = ContentAlignment.TopCenter Or _textAlign = ContentAlignment.TopLeft Or _textAlign = ContentAlignment.TopRight Then
                format.LineAlignment = StringAlignment.Near
            ElseIf _textAlign = ContentAlignment.MiddleCenter Or _textAlign = ContentAlignment.MiddleLeft Or _textAlign = ContentAlignment.MiddleRight Then
                format.LineAlignment = StringAlignment.Center
            ElseIf _textAlign = ContentAlignment.BottomCenter Or _textAlign = ContentAlignment.BottomLeft Or _textAlign = ContentAlignment.BottomRight Then
                format.LineAlignment = StringAlignment.Far
            End If
            If _ForceCaps Then
                g.DrawString(tmpStr.ToUpper(), _font, Brushes.Black, area, format)
            Else
                g.DrawString(tmpStr, _font, Brushes.Black, area, format)
            End If
        End If
    End Sub


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
        Properties.Remove("AccessibleName")
        Properties.Remove("AccessibleRole")
        Properties.Remove("AccessibleDescription")
        Properties.Remove("AllowDrop")
        Properties.Remove("BackColor")
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
