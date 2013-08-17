Imports System.Drawing
'ToDo:
'Simplify Redraw()
Namespace LightweightControls
    ''' <summary>
    ''' Lightweight implementation of a 
    ''' <see cref="LCARS.Controls.ComplexButton">complex button</see>
    ''' </summary>
    Public Class LCComplexButton
        Inherits LCStandardButton
        Dim _sideText As String = "47"
        Dim _sideTextColor As LCARS.LCARScolorStyles = LCARScolorStyles.Orange
        Dim _sideBlockColor As LCARS.LCARScolorStyles = LCARScolorStyles.Orange
        Dim _staticWidth As Integer = -1

        ''' <summary>
        ''' Redraws the lightweight complex button
        ''' </summary>
        Public Overrides Sub Redraw()
            If Not _holdDraw Then
                If _bounds.Height > 0 And _bounds.Width > 0 Then
                    Dim sideFont As Font = New Font("LCARS", Me.Height + (Me.Height / 2.9), FontStyle.Regular, GraphicsUnit.Pixel)
                    'Set up brushes
                    Dim myBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
                    Dim sideBrush As Drawing.SolidBrush
                    Dim sideTextBrush As Drawing.SolidBrush
                    myBrush = GetBrush()
                    If _InAlert = LCARSalert.Normal And Not _mouseDown Then
                        sideBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(_sideBlockColor))
                        sideTextBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(_sideTextColor))
                    Else
                        sideBrush = myBrush
                        sideTextBrush = myBrush
                    End If

                    'Set up graphics and image
                    myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(myBitmap)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.Clear(System.Drawing.Color.Black)

                    'Left orange block
                    g.FillRectangle(sideBrush, 0, 0, Me.Height \ 2, Me.Height)
                    Dim curLeft As Integer = Me.Height \ 2
                    Dim sideTextSize As SizeF = g.MeasureString(_sideText.ToUpper, sideFont)

                    If _staticWidth > -1 Then
                        curLeft += _staticWidth - sideTextSize.Width
                    Else
                        curLeft -= Me.Height \ 5
                    End If

                    'draw the side text
                    g.DrawString(_sideText.ToUpper, sideFont, sideTextBrush, curLeft, -Me.Height / 4.7)
                    If _sideText <> "" Then
                        curLeft = (curLeft + sideTextSize.Width) - (Me.Height \ 6)
                    Else
                        curLeft = Me.Height / 2
                    End If
                    'Draw text and remainder of button
                    Dim textRect As New Rectangle(curLeft, 0, (Me.Width - curLeft) - Me.Height / 2, Me.Height)
                    g.FillRectangle(myBrush, textRect)
                    g.FillEllipse(myBrush, Me.Width - Me.Height, 0, Me.Height, Me.Height)
                    DrawText(textRect, g)
                    ChangeLit(g)
                    g.Dispose()
                    MyBase.doEvent(ILightweightControl.LightweightEvents.Update)
                End If
            End If
        End Sub

        ''' <summary>
        ''' Text to display on the side of the control
        ''' </summary>
        ''' <remarks>
        ''' If <see cref="LCARS.LightweightControls.LCComplexButton.SideTextWidth">SideTextWidth</see>
        ''' is set, the text will be constrained to a fixed area. If it has not been set,
        ''' the text area will resize to fit.
        ''' </remarks>
        Public Property SideText() As String
            Get
                Return _sideText
            End Get
            Set(ByVal value As String)
                _sideText = value
                Redraw()
            End Set
        End Property

        ''' <summary>
        ''' Color of the side text
        ''' </summary>
        Public Property SideTextColor() As LCARS.LCARScolorStyles
            Get
                Return _sideTextColor
            End Get
            Set(ByVal value As LCARS.LCARScolorStyles)
                If Not value = _sideTextColor Then
                    _sideTextColor = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color of the side block on the control
        ''' </summary>
        Public Property SideBlockColor() As LCARS.LCARScolorStyles
            Get
                Return _sideBlockColor
            End Get
            Set(ByVal value As LCARS.LCARScolorStyles)
                If Not value = _sideBlockColor Then
                    _sideBlockColor = value
                    Redraw()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Sets a static text width for the side text.
        ''' </summary>
        ''' <remarks>
        ''' If <see cref="LCARS.LightweightControls.LCComplexButton.SideTextWidth">SideTextWidth</see>
        ''' is set, the text will be constrained to a fixed area. If it has not been set,
        ''' the text area will resize to fit.
        ''' </remarks>
        Public Property SideTextWidth() As Integer
            Get
                Return _staticWidth
            End Get
            Set(ByVal value As Integer)
                If Not value = _staticWidth Then
                    _staticWidth = value
                    Redraw()
                End If
            End Set
        End Property
#Region " Conversion "
        Public Overloads Shared Widening Operator CType(ByVal o As LCComplexButton) As LCARS.Controls.ComplexButton
            Dim newButton As New LCARS.Controls.ComplexButton
            newButton.Text = o.Text
            newButton.Bounds = o.Bounds
            newButton.Data = o.Data
            newButton.Data2 = o.Data2
            newButton.ColorsAvailable = o.ColorsAvailable
            newButton.Color = o.Color
            newButton.AutoEllipsis = o.AutoEllipsis
            newButton.ButtonTextAlign = o.TextAlign
            newButton.Clickable = o.Clickable
            newButton.Flash = o.Flashing
            newButton.FlashInterval = CInt(o.FlashInterval)
            newButton.Font = o.Font
            newButton.holdDraw = o.HoldDraw
            newButton.CustomAlertColor = o.CustomAlertColor
            newButton.RedAlert = o.RedAlert
            newButton._ForceCaps = o.ForceCaps
            newButton.SideBlockColor = o.SideBlockColor
            newButton.SideText = o.SideText
            newButton.SideTextColor = o.SideTextColor
            newButton.SideTextWidth = o.SideTextWidth
            Return newButton
        End Operator
        Public Overloads Shared Narrowing Operator CType(ByVal o As LCARS.Controls.ComplexButton) As LCComplexButton
            Dim newButton As New LCComplexButton
            newButton.Text = o.Text
            newButton.Bounds = o.Bounds
            newButton.Data = o.Data
            newButton.Data2 = o.Data2
            newButton.ColorsAvailable = o.ColorsAvailable
            newButton.Color = o.Color
            newButton.AutoEllipsis = o.AutoEllipsis
            newButton.TextAlign = o.ButtonTextAlign
            newButton.Clickable = o.Clickable
            newButton.Flashing = o.Flash
            newButton.FlashInterval = CInt(o.FlashInterval)
            newButton.Font = o.Font
            newButton.HoldDraw = o.holdDraw
            newButton.CustomAlertColor = o.CustomAlertColor
            newButton.RedAlert = o.RedAlert
            newButton.ForceCaps = o._ForceCaps
            newButton.SideBlockColor = o.SideBlockColor
            newButton.SideText = o.SideText
            newButton.SideTextColor = o.SideTextColor
            newButton.SideTextWidth = o.SideTextWidth
            Return newButton
        End Operator
#End Region
    End Class
End Namespace
