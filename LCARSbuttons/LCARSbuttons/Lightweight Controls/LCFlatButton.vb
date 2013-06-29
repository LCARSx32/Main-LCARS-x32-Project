Option Strict On
Imports System.Drawing

Namespace LightweightControls

    ''' <summary>
    ''' Lightweight implementation of the <see cref="Controls.FlatButton">FlatButton</see>
    ''' </summary>
    ''' <remarks>
    ''' Several other controls derive from this one by overriding <see cref="LCFlatButton.Redraw">Redraw</see> and adding properties.
    ''' </remarks>
    Public Class LCFlatButton
        Implements ILightweightControl, LCARS.IAlertable, IDisposable

        ''' <summary>
        ''' The bitmap of the control's interface
        ''' </summary>
        ''' <remarks>This is used as a buffer to draw to, which is then passed to the
        ''' parent control to be drawn to the screen.
        ''' </remarks>
        Protected myBitmap As New Bitmap(1, 1)
        Protected _bounds As Rectangle
        Protected _text As String = "LCARS"
        Protected _visibleText As String = _text
        Protected _color As LCARScolorStyles = LCARScolorStyles.MiscFunction
        Protected _TextAlign As ContentAlignment = ContentAlignment.TopLeft
        Protected _holdDraw As Boolean = False
        Protected _font As New Font("LCARS", 14, FontStyle.Regular, GraphicsUnit.Point)
        Dim _data As Object
        Dim _data2 As Object
        Protected _CustomAlertColor As New Color()
        Protected _InAlert As LCARSalert = LCARSalert.Normal
        Protected _mouseDown As Boolean = False
        Protected _forceCaps As Boolean = True
        Protected WithEvents _tmrScroll As New Timers.Timer(100)
        Protected _lit As Boolean = True
        Protected _flashing As Boolean = False
        Protected _flashOn As Boolean = False
        Protected WithEvents _tmrFlash As New Timers.Timer(1000)
        Protected _beeping As Boolean = True
        Protected sound As System.Media.SoundPlayer
        Protected _clickable As Boolean = True
        Protected _autoEllipsis As Boolean = True
        Protected _ellipsisMode As EllipsisModes = EllipsisModes.Character
        Protected _textArea As RectangleF
        Protected _parent As System.Windows.Forms.Control
        Public ColorsAvailable As New LCARScolor()
        Public Event Update(ByVal sender As ILightweightControl) Implements ILightweightControl.Update
        Public Event Click As EventHandler
        Public Event MouseEnter As EventHandler
        Public Event MouseDown As System.Windows.Forms.MouseEventHandler
        Public Event MouseMove As System.Windows.Forms.MouseEventHandler
        Public Event MouseUp As System.Windows.Forms.MouseEventHandler
        Public Event MouseLeave As EventHandler
        Public Event DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

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

        ''' <summary>
        ''' Returns current bitmap for the button's interface
        ''' </summary>
        ''' <returns>Bitmap for the button's interface</returns>
        ''' <remarks>
        ''' Calling this function does not cause a redraw, unless the bitmap is not drawn yet. In such a case, the control will redraw
        ''' itself, then return the bitmap.
        ''' </remarks>
        Public Function GetBitmap() As System.Drawing.Bitmap Implements ILightweightControl.GetBitmap
            If myBitmap Is Nothing Then
                HoldDraw = False
            End If
            Return myBitmap
        End Function

        ''' <summary>
        ''' Causes the control to redraw
        ''' </summary>
        ''' <remarks>
        ''' This sub will completely refresh the bitmap of the control, then raise the <see cref="Update">Update</see> event.
        ''' It should be overridden in child classes.
        ''' </remarks>
        Public Overridable Sub Redraw() Implements ILightweightControl.Redraw
            If Not _holdDraw Then
                If _bounds.Height > 0 And _bounds.Width > 0 Then
                    myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(myBitmap)
                    Dim myBrush As SolidBrush = GetBrush()
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.Clear(System.Drawing.Color.Black)
                    'Draw basic shape
                    g.FillRectangle(myBrush, New Rectangle(0, 0, _bounds.Width, _bounds.Height))
                    'Draw text
                    DrawText(New Rectangle(0, 0, Me.Width, Me.Height), g)
                    ChangeLit(g)
                    g.Dispose()
                    RaiseEvent Update(Me)
                End If
            End If
        End Sub
        ''' <summary>
        ''' Returns the standard color brush.
        ''' </summary>
        ''' <returns>Solid Brush according to standard color rules</returns>
        ''' <remarks>This should be used with the Color property to save rewriting code.</remarks>
        Protected Function GetBrush() As SolidBrush
            Dim myBrush As SolidBrush
            If _mouseDown Then
                myBrush = New SolidBrush(System.Drawing.Color.White)
            Else
                If _InAlert = LCARSalert.Red Then
                    myBrush = New SolidBrush(System.Drawing.Color.Red)
                ElseIf _InAlert = LCARSalert.Yellow Then
                    myBrush = New SolidBrush(System.Drawing.Color.Yellow)
                ElseIf _InAlert = LCARSalert.White Then
                    myBrush = New SolidBrush(System.Drawing.Color.White)
                ElseIf _InAlert = LCARSalert.Custom Then
                    myBrush = New SolidBrush(_CustomAlertColor)
                Else
                    myBrush = New SolidBrush(ColorsAvailable.getColor(_color))
                End If
            End If
            Return myBrush
        End Function

        ''' <summary>
        ''' Darkens the control if not lit
        ''' </summary>
        ''' <param name="g">Graphics object being used to draw the control</param>
        ''' <remarks>
        ''' The entire control will be darkened, so do not use this if you need something else.
        ''' </remarks>
        Protected Sub ChangeLit(ByVal g As Graphics)
            If (_flashing And _flashOn) Or ((Not Flashing) And (Not _lit)) Then
                Dim darkBrush As New SolidBrush(Drawing.Color.FromArgb(128, 0, 0, 0))
                g.FillRectangle(darkBrush, 0, 0, Me.Width, Me.Height)
            End If
        End Sub

        ''' <summary>
        ''' Draws the text of the control in specified area.
        ''' </summary>
        ''' <param name="area">Valid area to draw text in.</param>
        ''' <param name="g">Graphics object being used to draw the control.</param>
        ''' <remarks>This sub will handle all auto-ellipsis functionality and alignment.
        ''' </remarks>
        Protected Sub DrawText(ByVal area As RectangleF, ByVal g As Graphics)
            _textArea = area
            Dim format As New StringFormat()
            format.FormatFlags = StringFormatFlags.NoWrap
            If _tmrScroll.Enabled Or Not _autoEllipsis Then
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
            If _tmrScroll.Enabled Then
                format.Alignment = StringAlignment.Near
            Else
                If _TextAlign = ContentAlignment.BottomCenter Or _TextAlign = ContentAlignment.MiddleCenter Or _TextAlign = ContentAlignment.TopCenter Then
                    format.Alignment = StringAlignment.Center
                ElseIf _TextAlign = ContentAlignment.BottomRight Or _TextAlign = ContentAlignment.MiddleRight Or _TextAlign = ContentAlignment.TopRight Then
                    format.Alignment = StringAlignment.Far
                ElseIf _TextAlign = ContentAlignment.BottomLeft Or _TextAlign = ContentAlignment.MiddleLeft Or _TextAlign = ContentAlignment.TopLeft Then
                    format.Alignment = StringAlignment.Near
                End If
            End If
            If _TextAlign = ContentAlignment.TopCenter Or _TextAlign = ContentAlignment.TopLeft Or _TextAlign = ContentAlignment.TopRight Then
                format.LineAlignment = StringAlignment.Near
            ElseIf _TextAlign = ContentAlignment.MiddleCenter Or _TextAlign = ContentAlignment.MiddleLeft Or _TextAlign = ContentAlignment.MiddleRight Then
                format.LineAlignment = StringAlignment.Center
            ElseIf _TextAlign = ContentAlignment.BottomCenter Or _TextAlign = ContentAlignment.BottomLeft Or _TextAlign = ContentAlignment.BottomRight Then
                format.LineAlignment = StringAlignment.Far
            End If
            If _forceCaps Then
                g.DrawString(_visibleText.ToUpper(), _font, Brushes.Black, area, format)
            Else
                g.DrawString(_visibleText, _font, Brushes.Black, area, format)
            End If
        End Sub
        ''' <summary>
        ''' Raises the click event of the control
        ''' </summary>
        ''' <remarks>If the control has detected the mouse as down, this sub will reset it to normal and redraw the control.</remarks>
        Public Sub doClick() Implements ILightweightControl.doClick
            If _clickable Then
                RaiseEvent Click(Me, New EventArgs)
                If _mouseDown Then
                    _mouseDown = False
                    Redraw()
                End If
            End If
        End Sub
        'Handles text scrolling
        Private Sub _tmrScroll_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles _tmrScroll.Elapsed
            _visibleText = _visibleText.Substring(1) & _visibleText.Substring(0, 1)
            Redraw()
        End Sub
        'Handles button flashing
        Private Sub _tmrFlash_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles _tmrFlash.Elapsed
            _flashOn = Not _flashOn
            Redraw()
        End Sub

        ''' <summary>
        ''' Handles most events of the control
        ''' </summary>
        ''' <param name="eventName">Type of event to raise</param>
        ''' <remarks></remarks>
        Public Sub doEvent(ByVal eventName As ILightweightControl.LightweightEvents) Implements ILightweightControl.doEvent
            Select Case eventName
                Case ILightweightControl.LightweightEvents.Click
                    doClick()
                Case ILightweightControl.LightweightEvents.MouseDown
                    If _clickable Then
                        _mouseDown = True
                        Redraw()
                    End If
                    RaiseEvent MouseDown(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                Case ILightweightControl.LightweightEvents.MouseUp
                    If _clickable Then
                        _mouseDown = False
                        Redraw()
                    End If
                    RaiseEvent MouseUp(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                Case ILightweightControl.LightweightEvents.MouseEnter
                    Scrolling = True
                    RaiseEvent MouseEnter(Me, New EventArgs)
                Case ILightweightControl.LightweightEvents.MouseLeave
                    Scrolling = False
                    RaiseEvent MouseLeave(Me, New EventArgs)
                Case ILightweightControl.LightweightEvents.Update
                    RaiseEvent Update(Me)
                Case ILightweightControl.LightweightEvents.DoubleClick
                    RaiseEvent DoubleClick(Me, New EventArgs)
                Case ILightweightControl.LightweightEvents.MouseMove
                    RaiseEvent MouseMove(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                Case Else
                    Throw New NotImplementedException("The requested event for this control does not exist")
            End Select
        End Sub

        Private Sub Beep(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
            If _beeping Then
                Dim t As New Threading.Thread(AddressOf BeepThread)
                t.Start()
            End If
        End Sub

        Private Sub BeepThread()
            Dim soundPath As String = GetSetting("LCARS X32", "Application", "ButtonSound", "")
            If System.IO.File.Exists(soundPath) Then
                sound = New System.Media.SoundPlayer(soundPath)
            Else
                sound = New System.Media.SoundPlayer(My.Resources._207)
            End If
            sound.Play()
        End Sub

        Public Sub SetParent(ByVal NewParent As System.Windows.Forms.Control) Implements ILightweightControl.SetParent
            _parent = NewParent
            _tmrFlash.SynchronizingObject = _parent
            _tmrScroll.SynchronizingObject = _parent
        End Sub
#Region " Properties "
        ''' <summary>
        ''' The bounds of the control
        ''' </summary>
        ''' <value>The current bounds of the control</value>
        ''' <returns>The new bounds of the control</returns>
        ''' <remarks>
        ''' These bounds are in pixels for a parent control's client area. A redraw will only be triggered if the new value is
        ''' different from the current value.
        ''' </remarks>
        Public Property Bounds() As System.Drawing.Rectangle Implements ILightweightControl.Bounds
            Get
                Return _bounds
            End Get
            Set(ByVal value As System.Drawing.Rectangle)
                If Not _bounds = value Then
                    _bounds = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The height of the control.
        ''' </summary>
        ''' <value>The new height for the control</value>
        ''' <returns>The current height of the control</returns>
        ''' <remarks>
        ''' This is an alias for Bounds.Height, and is included to make handling lightweight controls more similar to standard
        ''' controls. A redraw will only be triggered if the new value is different from the current value.
        ''' </remarks>
        Public Property Height() As Integer Implements ILightweightControl.Height
            Get
                Return _bounds.Height
            End Get
            Set(ByVal value As Integer)
                If Not _bounds.Height = value Then
                    _bounds.Height = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The width of the control.
        ''' </summary>
        ''' <value>The current width of the control</value>
        ''' <returns>The new width for the control</returns>
        ''' <remarks>
        ''' This is an alias for Bounds.Width, and is included to make handling lightweight controls more similar to standard
        ''' controls. A redraw will only be triggered if the new value is different from the current value.
        ''' </remarks>
        Public Property Width() As Integer Implements ILightweightControl.Width
            Get
                Return _bounds.Width
            End Get
            Set(ByVal value As Integer)
                If Not _bounds.Width = value Then
                    _bounds.Width = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The text of the control
        ''' </summary>
        ''' <value>New text for the control</value>
        ''' <returns>Current text of the control</returns>
        ''' <remarks>
        ''' A redraw will always be triggered when this text is changed.
        ''' </remarks>
        Public Property Text() As String Implements ILightweightControl.Text
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
                _visibleText = value
                Redraw()
            End Set
        End Property

        ''' <summary>
        ''' The alignment for the control text
        ''' </summary>
        ''' <remarks>
        ''' In derived controls, this refers to the alignment within the valid text area
        ''' only, not the entire control.
        ''' </remarks>
        Public Property TextAlign() As ContentAlignment
            Get
                Return _TextAlign
            End Get
            Set(ByVal value As ContentAlignment)
                _TextAlign = value
                Redraw()
            End Set
        End Property

        ''' <summary>
        ''' Prevents the control from redrawing
        ''' </summary>
        ''' <remarks>
        ''' Setting this property to true will trigger a redraw, regardless of its previous
        ''' value.
        ''' </remarks>
        Public Property HoldDraw() As Boolean Implements ILightweightControl.HoldDraw
            Get
                Return _holdDraw
            End Get
            Set(ByVal value As Boolean)
                _holdDraw = value
                If Not HoldDraw Then
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The left position of the control, relative to its parent container
        ''' </summary>
        Public Property Left() As Integer Implements ILightweightControl.Left
            Get
                Return _bounds.Left
            End Get
            Set(ByVal value As Integer)
                If Not value = _bounds.Left Then
                    _bounds = New Rectangle(value, _bounds.Top, _bounds.Width, _bounds.Height)
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The top position of the control, relative to its parent container
        ''' </summary>
        Public Property Top() As Integer Implements ILightweightControl.Top
            Get
                Return _bounds.Top
            End Get
            Set(ByVal value As Integer)
                If Not value = _bounds.Top Then
                    _bounds = New Rectangle(_bounds.Left, value, _bounds.Width, _bounds.Height)
                    Redraw()
                End If
            End Set
        End Property
        ''' <summary>
        ''' Data field for the control
        ''' </summary>
        ''' <remarks>
        ''' This is for the programmer's convenience in associating information with a control. There is no built-in functionality, 
        ''' so it is exactly what you make it.
        ''' </remarks>
        Public Property Data() As Object
            Get
                Return _data
            End Get
            Set(ByVal value As Object)
                _data = value
            End Set
        End Property

        ''' <summary>
        ''' Data field for the control
        ''' </summary>
        ''' <remarks>
        ''' This is for the programmer's convenience in associating information with a control. There is no built-in functionality, 
        ''' so it is exactly what you make it.
        ''' </remarks>
        Public Property Data2() As Object
            Get
                Return _data2
            End Get
            Set(ByVal value As Object)
                _data2 = value
            End Set
        End Property

        ''' <summary>
        ''' The color to display if RedAlert is set to Custom
        ''' </summary>
        Public Property CustomAlertColor() As System.Drawing.Color Implements IAlertable.CustomAlertColor
            Get
                Return _CustomAlertColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                _CustomAlertColor = value
                If _InAlert = LCARSalert.Custom Then
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The alert state of the control
        ''' </summary>
        Public Property RedAlert() As LCARSalert Implements IAlertable.RedAlert
            Get
                Return _InAlert
            End Get
            Set(ByVal value As LCARSalert)
                If Not value = _InAlert Then
                    _InAlert = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Sets the text scrolling  for the control
        ''' </summary>
        ''' <remarks>
        ''' This should only change in response to mouseover events
        ''' </remarks>
        Protected Property Scrolling() As Boolean
            Get
                Return _tmrScroll.Enabled
            End Get
            Set(ByVal value As Boolean)
                If Not _tmrScroll.Enabled = value Then
                    If value Then
                        Dim temp As New Bitmap(1, 1)
                        Dim g As Graphics = Graphics.FromImage(temp)
                        Dim textSize As SizeF = g.MeasureString(_text, _font)
                        g.Dispose()
                        If textSize.Width > _textArea.Width Then
                            _visibleText = _text & "              "
                            _tmrScroll.Enabled = value
                        End If
                    Else
                        _tmrScroll.Enabled = False
                        _visibleText = _text
                        Redraw()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Force text to display in all caps
        ''' </summary>
        ''' <remarks>
        ''' Does not change the value returned by the <see cref="Text">Text</see>
        ''' property. Setting this property to its current value will not trigger a redraw.
        ''' </remarks>
        Public Property ForceCaps() As Boolean
            Get
                Return _forceCaps
            End Get
            Set(ByVal value As Boolean)
                If Not value = _forceCaps Then
                    _forceCaps = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The color to display for the majority of the control
        ''' </summary>
        ''' <remarks>
        ''' Setting this property to its current value will not trigger a redraw.
        ''' </remarks>
        Public Property Color() As LCARS.LCARScolorStyles
            Get
                Return _color
            End Get
            Set(ByVal value As LCARS.LCARScolorStyles)
                If Not _color = value Then
                    _color = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The font to use when displaying the control's text
        ''' </summary>
        <System.ComponentModel.Browsable(False), System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
                Public Property Font() As Font
            Get
                Return _font
            End Get
            Set(ByVal value As Font)
                _font = value
                Redraw()
            End Set
        End Property

        ''' <summary>
        ''' Sets the lit state of the control
        ''' </summary>
        ''' <remarks>
        ''' Updating this property to a new value will require a full redraw. Setting this
        ''' property to its current value will not trigger a redraw.
        ''' </remarks>
        Public Property Lit() As Boolean
            Get
                Return _lit
            End Get
            Set(ByVal value As Boolean)
                If Not value = _lit Then
                    _lit = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Sets the flashing state of the control
        ''' </summary>
        ''' <remarks>
        ''' If flashing is enabled, it will occur on a separate thread.
        ''' </remarks>
        Public Property Flashing() As Boolean
            Get
                Return _flashing
            End Get
            Set(ByVal value As Boolean)
                If Not value = _flashing Then
                    _flashing = value
                    _tmrFlash.Enabled = value
                    If Not value Then
                        Redraw()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' The interval on which to change the lit state of the button for flashing
        ''' </summary>
        ''' <remarks>
        ''' A full flashing cycle is twice this interval.
        ''' </remarks>
        Public Property FlashInterval() As Double
            Get
                Return _tmrFlash.Interval
            End Get
            Set(ByVal value As Double)
                _tmrFlash.Interval = value
            End Set
        End Property

        ''' <summary>
        ''' The beeping option for the control
        ''' </summary>
        ''' <remarks>
        ''' Warning: high-pitched beeps can cause irritation in users. Use with caution!
        ''' </remarks>
        Public Property Beeping() As Boolean
            Get
                Return _beeping
            End Get
            Set(ByVal value As Boolean)
                _beeping = value
            End Set
        End Property

        ''' <summary>
        ''' Sets the clickable state of the control
        ''' </summary>
        Public Property Clickable() As Boolean
            Get
                Return _clickable
            End Get
            Set(ByVal value As Boolean)
                _clickable = value
            End Set
        End Property

        ''' <summary>
        ''' Sets the auto-ellipsis property of the control
        ''' </summary>
        Public Property AutoEllipsis() As Boolean
            Get
                Return _autoEllipsis
            End Get
            Set(ByVal value As Boolean)
                If Not value = _autoEllipsis Then
                    _autoEllipsis = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Sets the ellipsis mode for text clipping
        ''' </summary>
        ''' <remarks>
        ''' The default is nearest-character, but nearest-word can be specified if you wish.
        ''' </remarks>
        Public Property EllipsisMode() As EllipsisModes
            Get
                Return _ellipsisMode
            End Get
            Set(ByVal value As EllipsisModes)
                If Not value = _ellipsisMode Then
                    _ellipsisMode = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Height of the text for the control
        ''' </summary>
        Public Property TextHeight() As Single
            Get
                Return _font.Size
            End Get
            Set(ByVal value As Single)
                If Not value = _font.Size Then
                    _font = New Font("LCARS", value, FontStyle.Regular, GraphicsUnit.Point)
                    Redraw()
                End If
            End Set
        End Property
#End Region

#Region " IDisposable Support "
        Private disposedValue As Boolean = False
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    _tmrScroll.Enabled = False
                    _tmrFlash.Enabled = False
                End If

            End If
            Me.disposedValue = True
        End Sub
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace
