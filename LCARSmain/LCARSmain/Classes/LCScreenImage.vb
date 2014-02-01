Imports System.Drawing
Imports LCARS.LightweightControls

Public Class LCScreenImage
    Inherits LCARS.LightweightControls.LCFlatButton

    Private _image As Bitmap
    Private _selected As Boolean = False
    Private _BoxWidth As Integer = 10
    Private _padding As Integer = 3
    Private elbow As Bitmap

#Region " Properties "
    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
            Redraw()
        End Set
    End Property

    Public Property Selected() As Boolean
        Get
            Return _selected
        End Get
        Set(ByVal value As Boolean)
            If value <> _selected Then
                _selected = value
                Redraw()
            End If
        End Set
    End Property

    Public Property SelectionBoxWidth() As Integer
        Get
            Return _BoxWidth
        End Get
        Set(ByVal value As Integer)
            If _BoxWidth <> value Then
                _BoxWidth = value
                updateElbow()
                Redraw()
            End If
        End Set
    End Property
#End Region

    Public Sub New()
        updateElbow()
    End Sub

    Private Function GetBrushNoChange() As SolidBrush
        Return New SolidBrush(_colorsAvailable.getColor(_color))
    End Function

    Public Overrides Sub Redraw()
        If (Not _holdDraw) And _bounds.Width > 0 And _bounds.Height > 0 Then
            'Set up graphics
            Dim myBrush As Drawing.SolidBrush = GetBrushNoChange()
            myBitmap = New Bitmap(_bounds.Width, _bounds.Height)
            Dim g As Graphics = Graphics.FromImage(myBitmap)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.Clear(System.Drawing.Color.Black)

            'Draw image
            If Not _image Is Nothing Then
                Dim NewHeight As Integer = _bounds.Height - _BoxWidth * 2
                Dim NewWidth As Integer = NewHeight / _image.Height * _image.Width
                If NewWidth > _bounds.Width - _BoxWidth * 4 Then
                    NewWidth = _bounds.Width - _BoxWidth * 4
                    NewHeight = NewWidth / _image.Width * _image.Height
                End If
                Dim centerX As Integer = _BoxWidth * 2 + ((_bounds.Width - 4 * _BoxWidth) - NewWidth) / 2
                Dim centerY As Integer = _BoxWidth * 1.5 + ((_bounds.Height - 3 * _BoxWidth) - NewHeight) / 2
                g.DrawImage(_image, centerX, centerY, NewWidth, NewHeight)
            End If

            If _selected Then
                'Draw vertical bars
                g.FillRectangle(myBrush, 0, CInt(_BoxWidth * 1.5 + _padding), _BoxWidth, _bounds.Height - 3 * _BoxWidth - 2 * _padding)
                g.FillRectangle(myBrush, _bounds.Width - _BoxWidth, CInt(_BoxWidth * 1.5 + _padding), _BoxWidth, _bounds.Height - 3 * _BoxWidth - 2 * _padding)

                'Draw elbows
                g.DrawImage(elbow, 0, 0)
                elbow.RotateFlip(RotateFlipType.RotateNoneFlipY)
                g.DrawImage(elbow, 0, _bounds.Height - CInt(_BoxWidth * 1.5))
                elbow.RotateFlip(RotateFlipType.RotateNoneFlipX)
                g.DrawImage(elbow, _bounds.Width - _BoxWidth * 2, _bounds.Height - CInt(_BoxWidth * 1.5))
                elbow.RotateFlip(RotateFlipType.RotateNoneFlipY)
                g.DrawImage(elbow, _bounds.Width - _BoxWidth * 2, 0)
                elbow.RotateFlip(RotateFlipType.RotateNoneFlipX)
            End If

            'Cleanup
            g.Dispose()
            MyBase.doEvent(ILightweightControl.LightweightEvents.Update)
        End If

    End Sub

    Private Sub updateElbow()
        'Setup
        elbow = New Bitmap(_BoxWidth * 2, CInt(_BoxWidth * 1.5))
        Dim myBrush As Drawing.SolidBrush = GetBrushNoChange()
        Dim g As Graphics = Graphics.FromImage(elbow)
        g.Clear(Drawing.Color.Black)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        g.Clear(System.Drawing.Color.Black)

        g.FillEllipse(myBrush, 0, 0, _BoxWidth * 2, _BoxWidth * 2)
        g.FillRectangle(Brushes.Black, _BoxWidth, _BoxWidth, _BoxWidth, _BoxWidth)
        g.FillRectangle(Brushes.Black, CInt(3 * _BoxWidth / 2), CInt(_BoxWidth / 2), CInt(_BoxWidth / 2), CInt(_BoxWidth / 2))

        g.FillRectangle(myBrush, 0, _BoxWidth, _BoxWidth, _BoxWidth)
        g.FillRectangle(myBrush, _BoxWidth, 0, _BoxWidth, CInt(_BoxWidth / 2))

        g.FillEllipse(Brushes.Black, _BoxWidth, CInt(_BoxWidth / 2), _BoxWidth, _BoxWidth)
        g.Dispose()
    End Sub

End Class
