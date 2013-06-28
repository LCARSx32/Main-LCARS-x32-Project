Imports System.Drawing
Namespace LightweightControls
    ''' <summary>
    ''' Lightweight implementation of the <see cref="Controls.FlatButton">FlatButton</see>
    ''' </summary>
    Public Class LCStandardButton
        Inherits LCFlatButton

        ''' <summary>
        ''' Visual types for the standard button
        ''' </summary>
        Public Enum ButtonStyles
            ''' <summary>
            ''' Standard pill-shaped button
            ''' </summary>
            Pill = 0
            ''' <summary>
            ''' Rounded rectangle
            ''' </summary>
            RoundedSquare = 1
            ''' <summary>
            ''' Rounded rectangle stretched to a parallelogram
            ''' </summary>
            RoundedSquareSlant = 2
            ''' <summary>
            ''' Rounded rectangle stretched to a rear-slanted parallelogram
            ''' </summary>
            RoundedSquareBackSlant = 3
        End Enum

        Dim _buttonType As ButtonStyles = ButtonStyles.Pill


        ''' <summary>
        ''' Causes the control to redraw
        ''' </summary>
        ''' <remarks>
        ''' This sub will completely refresh the bitmap of the control, then raise the <see cref="Update">Update</see> event.
        ''' It should be overridden in child classes.
        ''' </remarks>
        Public Overrides Sub Redraw()
            If Not _holdDraw Then
                If _bounds.Height > 0 And _bounds.Width > 0 Then
                    myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(myBitmap)
                    Dim myBrush As SolidBrush = GetBrush()
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.Clear(System.Drawing.Color.Transparent)
                    'Draw basic shape
                    Dim textRect As RectangleF
                    If _buttonType = ButtonStyles.Pill Then
                        g.FillEllipse(myBrush, New Rectangle(0, 0, _bounds.Height, _bounds.Height))
                        g.FillEllipse(myBrush, New Rectangle(_bounds.Width - _bounds.Height, 0, _bounds.Height, _bounds.Height))
                        textRect = New RectangleF(CSng(_bounds.Height / 2), 0, _bounds.Width - _bounds.Height, _bounds.Height)
                        g.FillRectangle(myBrush, textRect)
                    Else
                        Dim diameter As Single = Me.Height / 4
                        g.FillEllipse(myBrush, New Rectangle(0, 0, diameter, diameter))
                        g.FillEllipse(myBrush, New RectangleF(0, Me.Height - diameter, diameter, diameter))
                        g.FillEllipse(myBrush, New RectangleF(Me.Width - diameter, 0, diameter, diameter))
                        g.FillEllipse(myBrush, New RectangleF(Me.Width - diameter, Me.Height - diameter, diameter, diameter))
                        textRect = New RectangleF(diameter / 2, 0, Me.Width - diameter, Me.Height)
                        g.FillRectangle(myBrush, textRect)
                        g.FillRectangle(myBrush, New RectangleF(0, diameter / 2, Me.Width, Me.Height - diameter))
                        If _buttonType = ButtonStyles.RoundedSquareSlant Or _buttonType = ButtonStyles.RoundedSquareBackSlant Then
                            Dim slant As Bitmap = New Bitmap(myBitmap)
                            Dim mypoints(2) As Point
                            If _buttonType = ButtonStyles.RoundedSquareSlant Then
                                mypoints(0) = New Point(Me.Width \ 4, 0)
                                mypoints(1) = New Point(Me.Width, 0)
                                mypoints(2) = New Point(0, Me.Height)
                            Else
                                mypoints(0) = New Point(0, 0)
                                mypoints(1) = New Point(Me.Width - (Me.Width \ 4), 0)
                                mypoints(2) = New Point(Me.Width \ 4, Me.Height)
                            End If
                            g.FillRectangle(Brushes.Black, myBitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
                            g.DrawImage(slant, mypoints)
                            textRect = New RectangleF(Me.Width / 4, 0, Me.Width / 2, Me.Height)
                        End If

                    End If
                    'Draw text
                    DrawText(textRect, g)
                    ChangeLit(g)
                    g.Dispose()
                    MyBase.doEvent(ILightweightControl.LightweightEvents.Update)
                End If
            End If
        End Sub

        ''' <summary>
        ''' Visual type of the button
        ''' </summary>
        ''' <value>New visual type</value>
        ''' <returns>Current visual type</returns>
        Public Property ButtonStyle() As ButtonStyles
            Get
                Return _buttonType
            End Get
            Set(ByVal value As ButtonStyles)
                If Not _buttonType = value Then
                    _buttonType = value
                    Redraw()
                End If
            End Set
        End Property
    End Class
End Namespace