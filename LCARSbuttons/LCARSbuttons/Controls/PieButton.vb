Imports System.Drawing

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class PieButton
        Inherits LCARS.LCARSbuttonClass

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
            Me.textSize = Me.Size
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
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
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

            g.Dispose()
            Dim myRegion As New Region(gPath)

            Me.Region = myRegion




            Return mybitmap
        End Function

#End Region

    End Class
End Namespace