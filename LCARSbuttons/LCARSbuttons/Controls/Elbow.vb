Imports System.Drawing

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class Elbow
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
            ElseIf inRedAlert = LCARSalert.Custom Then
                mybrush = New Drawing.SolidBrush(_customAlertColor)
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
            Me.lblTextSize = Me.Size
            g.Dispose()
            Return mybitmap

            'mybitmap = Nothing
            'g = Nothing
            'mybrush.Dispose()
            'GC.Collect()

        End Function
#End Region

    End Class
End Namespace