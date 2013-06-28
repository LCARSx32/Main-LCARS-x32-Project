Imports System.Drawing
Imports System.ComponentModel

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class ArrowButton
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
            Me.Name = "ArrowButton"
            Me.Size = New System.Drawing.Size(50, 50)
            Me.ButtonText = ""
            Me.Text = ""
            Me.ResumeLayout(False)


        End Sub
#End Region

#Region " Global Variables "
        Dim ArrowDir As LCARS.LCARSarrowDirection = LCARSarrowDirection.Up
#End Region

#Region " Properties "
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property Text() As String
            Get
                Return ""
            End Get
            Set(ByVal value As String)
                MyBase.Text = ""
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonText() As String
            Get
                Return ""
            End Get
            Set(ByVal value As String)
                MyBase.ButtonText = ""
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonTextAlign() As System.Drawing.ContentAlignment
            Get
                Return MyBase.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                MyBase.ButtonTextAlign = value
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property ButtonTextHeight() As Integer
            Get
                Return MyBase.ButtonTextHeight
            End Get
            Set(ByVal value As Integer)
                MyBase.ButtonTextHeight = value
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property AutoEllipsis()
            Get
                Return Nothing
            End Get
            Set(ByVal value)

            End Set
        End Property


        Public Property ArrowDirection() As LCARS.LCARSarrowDirection
            Get
                Return ArrowDir
            End Get
            Set(ByVal value As LCARS.LCARSarrowDirection)
                ArrowDir = value
                Me.DrawAllButtons()
            End Set
        End Property
#End Region

#Region " Draw Arrow Button "

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim myPoints(2) As Point

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
            End If


            mybitmap = New Bitmap(Me.Width, Me.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(myBrush, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            Select Case ArrowDir
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

            Return mybitmap
        End Function

#End Region

    End Class
End Namespace