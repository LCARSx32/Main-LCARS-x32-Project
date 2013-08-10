Imports System.Drawing
Namespace LightweightControls
    Public Class LCArrowButton
        Inherits LCFlatButton

        Private _arrowDirection As LCARS.LCARSarrowDirection = LCARSarrowDirection.Up
        Public Overrides Sub Redraw()
            If Not HoldDraw Then
                If Bounds.Width > 0 And Bounds.Height > 0 Then
                    myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(myBitmap)
                    Dim myBrush As SolidBrush = GetBrush()
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.Clear(System.Drawing.Color.Black)
                    g.FillRectangle(myBrush, 0, 0, _bounds.Width, _bounds.Height)
                    'Draw arrow
                    Dim myPoints(2) As Point
                    Select Case _arrowDirection
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

                    ChangeLit(g)
                    doEvent(ILightweightControl.LightweightEvents.Update)
                End If
            End If
        End Sub

        Public Property ArrowDirection() As LCARS.LCARSarrowDirection
            Get
                Return _arrowDirection
            End Get
            Set(ByVal value As LCARS.LCARSarrowDirection)
                _arrowDirection = value
                Redraw()
            End Set
        End Property
    End Class
End Namespace