Option Strict On

Imports System.Drawing
Imports System.ComponentModel

Namespace Controls
    <DefaultEvent("ValueChanged")> _
    Public Class Slider
        Inherits System.Windows.Forms.Control
        Implements IColorable, IAlertable

#Region " LCARS colors and alerts "
        Private WithEvents _colors As New LCARScolor
        Private _redAlert As LCARSalert = LCARSalert.Normal
        Private _customAlertColor As Color = Nothing

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property ColorsAvailable() As LCARScolor Implements IColorable.ColorsAvailable
            Get
                Return _colors
            End Get
            Set(ByVal value As LCARScolor)
                _colors = value
                Me.Invalidate()
            End Set
        End Property

        Public Property CustomAlertColor() As System.Drawing.Color Implements IAlertable.CustomAlertColor
            Get
                Return _customAlertColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                If value = _customAlertColor Then Return
                _customAlertColor = value
                If _redAlert = LCARSalert.Custom Then
                    Me.Invalidate()
                End If
            End Set
        End Property

        <DefaultValue(LCARSalert.Normal)> _
        Public Property RedAlert() As LCARSalert Implements IAlertable.RedAlert
            Get
                Return _redAlert
            End Get
            Set(ByVal value As LCARSalert)
                If value = _redAlert Then Return
                _redAlert = value
                Me.Invalidate()
            End Set
        End Property
#End Region

        'TODO: Properties for padding
        'TODO: Make text configurable
        'TODO: Set up minimum size
        Private _min As Integer = 0
        Private _max As Integer = 100
        Private _value As Integer = 50
        Private _mouseDown As Boolean = False
        Private _mouseOffset As Integer = 0
        Private _padding As Integer = 5
        Private _buttonHeight As Integer = 30
        Private _color As LCARScolorStyles = LCARScolorStyles.MiscFunction
        Private _color2 As LCARScolorStyles = LCARScolorStyles.PrimaryFunction
        Private _lit As Boolean = True

        'Events
        Public Event ValueChanged As EventHandler

#Region " Properties "
        <DefaultValue(LCARScolorStyles.MiscFunction)> _
        Public Property MainColor() As LCARScolorStyles
            Get
                Return _color
            End Get
            Set(ByVal value As LCARScolorStyles)
                If value = _color Then Return
                _color = value
                Me.Invalidate()
            End Set
        End Property

        <DefaultValue(LCARScolorStyles.PrimaryFunction)> _
        Public Property ButtonColor() As LCARScolorStyles
            Get
                Return _color2
            End Get
            Set(ByVal value As LCARScolorStyles)
                If value = _color2 Then Return
                _color2 = value
                Me.Invalidate()
            End Set
        End Property

        <DefaultValue(True)> _
        Public Property Lit() As Boolean
            Get
                Return _lit
            End Get
            Set(ByVal value As Boolean)
                If value = _lit Then Return
                _lit = value
                Me.Invalidate()
            End Set
        End Property

        <DefaultValue(0)> _
        Public Property Min() As Integer
            Get
                Return _min
            End Get
            Set(ByVal value As Integer)
                If _min = value Then Return
                _min = value
                _value = clipValue(_value)
                Me.InvalidateBar()
            End Set
        End Property

        <DefaultValue(100)> _
        Public Property Max() As Integer
            Get
                Return _max
            End Get
            Set(ByVal value As Integer)
                If _max = value Then Return
                _max = value
                _value = clipValue(_value)
                Me.InvalidateBar()
            End Set
        End Property

        <DefaultValue(50)> _
        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
                If _value = value Then
                    If _mouseDown Then
                        Me.InvalidateBar()
                    End If
                Else
                    _value = clipValue(value)
                    Me.InvalidateBar()
                    OnValueChanged(New EventArgs())
                End If
            End Set
        End Property

        <DefaultValue(30)> _
        Public Property ButtonHeight() As Integer
            Get
                Return _buttonHeight
            End Get
            Set(ByVal value As Integer)
                If value = _buttonHeight Then Return
                'Can't be too small
                If value < Me.Width \ 4 Then
                    value = Me.Width \ 4
                End If
                'Or larger than half the bar
                If value > (Me.Height - Me.Width \ 2 - _padding * 2) \ 2 Then
                    value = (Me.Height - Me.Width \ 2 - _padding * 2) \ 2
                End If
                _buttonHeight = value
                Me.InvalidateBar()
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
            Me.Size = New Size(30, 200)
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim btnBounds As Rectangle = buttonBounds
            Dim mLoc As Point = PointToClient(MousePosition)
            If e.Button = Windows.Forms.MouseButtons.Left And btnBounds.Contains(mLoc) Then
                _mouseOffset = mLoc.Y - btnBounds.Top - btnBounds.Height \ 2
                _mouseDown = True
                Me.InvalidateBar()
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            If e.Button = Windows.Forms.MouseButtons.Left And _mouseDown Then
                _mouseDown = False
                Me.InvalidateBar()
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            'Check if mouse is actually within the control's bounds.
            If Me.Size.Width > e.Location.X And Me.Size.Height > e.Location.Y And _
                        e.Location.Y >= 0 And e.Location.X >= 0 Then
                If e.Button = Windows.Forms.MouseButtons.Left And _mouseDown Then
                    Dim h As Integer = Me.Height - Me.Width \ 2 - 2 * _padding - _buttonHeight
                    Dim y As Integer = PointToClient(MousePosition).Y - _padding - Me.Width \ 4 - _buttonHeight \ 2 - _mouseOffset
                    Dim newValue As Integer = CInt(Math.Round(y * (_min - _max) / h + _max))
                    Value = newValue 'Handles the rest of the update
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            If _mouseDown Then
                _mouseDown = False
                Me.InvalidateBar()
            End If
        End Sub

        ''' <summary>
        ''' Raises the ValueChanged event
        ''' </summary>
        ''' <param name="e">An EventArgs that contains the event data</param>
        ''' <remarks>
        ''' Derived classes should override this sub instead of handling the event. This avoids the
        ''' use of a delegate that would be required by the event.
        ''' </remarks>
        Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
            RaiseEvent ValueChanged(Me, e)
        End Sub

        ''' <summary>
        ''' Bounds of the button from current value or mouse position.
        ''' </summary>
        ''' <returns>Client-area coordinate rectangle</returns>
        ''' <remarks>
        ''' If the mouse is down, the rectangle will always be centered on it, minus the original mouse
        ''' offset. Otherwise, the rectangle will be centered on the current value.
        ''' </remarks>
        Protected ReadOnly Property buttonBounds() As Rectangle
            Get
                Dim h As Integer = Me.Height - Me.Width \ 2 - 2 * _padding - _buttonHeight
                Dim y As Double
                If _mouseDown Then
                    y = PointToClient(MousePosition).Y - _buttonHeight / 2 - Me.Width / 4 - _padding - _mouseOffset
                    If y < 0 Then
                        y = 0
                    ElseIf y > h Then
                        y = h
                    End If
                Else
                    y = (_value - _max) / (_min - _max) * h
                End If
                Return New Rectangle(0, CInt(y) + _padding + Me.Width \ 4, Me.Width, _buttonHeight)
            End Get
        End Property

        ''' <summary>
        ''' Invalidate only the bar section of the control.
        ''' </summary>
        ''' <remarks>
        ''' This saves drawing time by keeping the ellipses we already drew.
        ''' </remarks>
        Protected Sub InvalidateBar()
            Me.Invalidate(New Rectangle(0, Me.Width \ 4, Me.Width, Me.Height - Me.Width \ 2))
        End Sub

        ''' <summary>
        ''' Clip the given value to lie within the range of [min, max].
        ''' </summary>
        ''' <remarks>
        ''' Min does not have to be less than Max. The value will be clipped to lie between Min and
        ''' Max, inclusive.
        ''' </remarks>
        Protected Function clipValue(ByVal newValue As Integer) As Integer
            If _min < _max Then
                If newValue < _min Then
                    newValue = _min
                ElseIf newValue > _max Then
                    newValue = _max
                End If
            Else
                If newValue > _min Then
                    newValue = _min
                ElseIf newValue < _max Then
                    newValue = _max
                End If
            End If
            Return newValue
        End Function

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim g As Graphics = Nothing
            Dim mybitmap As Bitmap = Nothing
            'Setup buffering
            Dim useBuffer As Boolean = False
            If useBuffer Then
                mybitmap = New Bitmap(Me.Width, Me.Height)
                g = Graphics.FromImage(mybitmap)
            Else
                g = e.Graphics()
            End If
            Dim c As Color
            Dim c2 As Color
            Select Case _redAlert
                Case LCARSalert.Normal
                    c = ColorsAvailable.getColor(_color)
                Case LCARSalert.Red
                    c = Color.Red
                Case LCARSalert.White
                    c = Color.White
                Case LCARSalert.Yellow
                    c = Color.Yellow
                Case LCARSalert.Custom
                    c = _customAlertColor
                Case Else
                    c = Color.Red
            End Select
            If Not _lit Then
                c = Color.FromArgb(255, c.R \ 2, c.G \ 2, c.B \ 2)
            End If
            Dim btnRect As Rectangle = buttonBounds
            If _redAlert = LCARSalert.Normal Then
                If _mouseDown And btnRect.Contains(PointToClient(MousePosition)) Then
                    c2 = Color.Red
                Else
                    c2 = ColorsAvailable.getColor(_color2)
                End If
            Else
                c2 = c
            End If

            'Setup brushes
            Dim b As New SolidBrush(c)
            Dim b2 As New SolidBrush(c2)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            'Draw top/bottom ellipse sections if required
            If e.ClipRectangle.Height <> Me.Height - Me.Width \ 2 Then
                g.FillPie(b, 0, 0, Me.Width, Me.Width \ 2, 180, 180)
                g.FillPie(b, 0, Me.Height - Me.Width \ 2, Me.Width, Me.Width \ 2, 0, 180)
            End If

            'Draw main rectangles
            Dim railStart As Integer = Me.Width \ 4
            g.FillRectangle(b, 0, railStart, Me.Width, btnRect.Top - railStart - _padding)
            g.FillRectangle(b, 0, btnRect.Bottom + _padding, Me.Width, Me.Height - (btnRect.Bottom + _padding) - Me.Width \ 4)
            'Draw button
            g.FillRectangle(b2, btnRect)
            Dim f As New Font("LCARS", 16, FontStyle.Regular, GraphicsUnit.Point)
            g.DrawString(_value.ToString, f, Brushes.Black, btnRect)

            'Draw final image if buffered
            If useBuffer Then
                Dim myG As Graphics = e.Graphics()
                myG.DrawImage(mybitmap, New PointF(0, 0))
                myG.Dispose()
                g.Dispose()
                mybitmap.Dispose()
            Else
                g.Dispose()
            End If
        End Sub
    End Class
End Namespace