Imports System.Drawing

Namespace LightweightControls
    ''' <summary>
    ''' A lightweight implementation of the <see cref="LCARS.Controls.HalfPillButton">HalfPillButton</see>
    ''' </summary>
    Public Class LCHalfPillButton
        Inherits LCStandardButton

        ''' <summary>
        ''' Describes the sides that the pill can be on
        ''' </summary>
        Public Enum PillStyle
            Right = 0
            Left = 1
        End Enum

        Private _direction As PillStyle = PillStyle.Left

        ''' <summary>
        ''' Redraws the control
        ''' </summary>
        Public Overrides Sub Redraw()
            If Not _holdDraw Then
                If _bounds.Height > 0 And _bounds.Width > 0 Then
                    myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(myBitmap)
                    Dim myBrush As SolidBrush = GetBrush()
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.Clear(System.Drawing.Color.Black)
                    'Draw basic shape
                    Dim textArea As RectangleF
                    If _direction = PillStyle.Left Then
                        g.FillEllipse(myBrush, 0, 0, Me.Height, Me.Height)
                        textArea = New RectangleF(Me.Height / 2, 0, Me.Width - Me.Height / 2, Me.Height)
                    Else
                        g.FillEllipse(myBrush, New RectangleF(Me.Width - Me.Height, 0, Me.Height, Me.Height))
                        textArea = New RectangleF(0, 0, Me.Width - Me.Height / 2, Me.Height)
                    End If
                    g.FillRectangle(myBrush, textArea)
                    'Draw text
                    DrawText(textArea, g)
                    ChangeLit(g)
                    g.Dispose()
                    MyBase.doEvent(ILightweightControl.LightweightEvents.Update)
                End If
            End If
        End Sub

        ''' <summary>
        ''' The side of the control to be rounded
        ''' </summary>
        ''' <remarks>
        ''' Setting this property to its current value will not trigger a redraw
        ''' </remarks>
        Public Property PillDirection() As PillStyle
            Get
                Return _direction
            End Get
            Set(ByVal value As PillStyle)
                If Not value = _direction Then
                    _direction = value
                    Redraw()
                End If
            End Set
        End Property

#Region " Conversion "
        Public Overloads Shared Widening Operator CType(ByVal o As LCHalfPillButton) As LCARS.Controls.HalfPillButton
            Dim newButton As New LCARS.Controls.HalfPillButton
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
            newButton.ButtonStyle = o.PillDirection
            Return newButton
        End Operator
        Public Overloads Shared Narrowing Operator CType(ByVal o As LCARS.Controls.HalfPillButton) As LCHalfPillButton
            Dim newButton As New LCHalfPillButton
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
            newButton.PillDirection = o.ButtonStyle
            Return newButton
        End Operator
#End Region
    End Class

End Namespace