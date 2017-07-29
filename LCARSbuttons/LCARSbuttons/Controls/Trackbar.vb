Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Controls
    <System.ComponentModel.DefaultEvent("Scroll")> _
    Public Class TrackBar
        Inherits Windows.Forms.Control
        Public Event Scroll As EventHandler
        'Global Variables
        Private _pages As Integer = 1
        Private _CurrentPage As Integer = 1
        Private _color As LCARScolorStyles = LCARScolorStyles.StaticTan
        Private _beeping As Boolean = True
        Private tempX As Integer = 0
        Private scrolling As Boolean = False
        Public ColorsAvailable As New LCARScolor
        'Permanent Controls
        Dim movingButton As New FlatButton

#Region " Properties "
        <DefaultValue(1)> _
        Public Property CurrentPage() As Integer
            Get
                Return _CurrentPage
            End Get
            Set(ByVal value As Integer)
                If value < _pages And value >= 0 Then
                    If Not _CurrentPage = value Then
                        _CurrentPage = value
                        If _pages > 1 Then
                            movingButton.Left = ((Me.Width - 5) / (_pages - 1)) * (_CurrentPage) - 2.5
                        End If
                        RaiseEvent Scroll(Me, New System.EventArgs)
                    End If
                End If
            End Set
        End Property

        <DefaultValue(1)> _
        Public Property Pages() As Integer
            Get
                Return _pages
            End Get
            Set(ByVal value As Integer)
                If Not value = _pages Then 'Check that the value actually changes
                    If value > 0 Then
                        _pages = value
                        If CurrentPage >= _pages Then
                            CurrentPage = 1
                        End If
                        If value = 1 Then 'If there is only one page
                            movingButton.Visible = False
                        Else 'If there is more than one page
                            movingButton.Visible = True
                            movingButton.Left = -2.5
                        End If
                        Me.Invalidate() 'Redraw
                    Else
                        Throw New IndexOutOfRangeException
                    End If
                End If
            End Set
        End Property

        <DefaultValue(GetType(LCARScolorStyles), "StaticTan")> _
        Public Property TickColor() As LCARScolorStyles
            Get
                Return _color
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color = value
                Me.Invalidate()
            End Set
        End Property

        <DefaultValue(True)> _
        Public Property Beeping() As Boolean
            Get
                Return _beeping
            End Get
            Set(ByVal value As Boolean)
                _beeping = value
            End Set
        End Property
#End Region

#Region " Event Handlers "
        Private Sub Me_Resize() Handles Me.Resize
            movingButton.Height = Me.Height
            Me.Invalidate()
        End Sub
        Private Sub Button_Mouse_Down(ByVal sender As Object, ByVal e As System.EventArgs)
            tempX = MousePosition.X - movingButton.Left
            scrolling = True
        End Sub
        Private Sub Button_Mouse_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            If scrolling Then
                movingButton.Left = MousePosition.X - tempX
            End If
        End Sub
        Private Sub Button_Mouse_Up(ByVal sender As Object, ByVal e As System.EventArgs)
            scrolling = False
            Dim page As Integer = (movingButton.Left + (Me.Width - 5) / (2 * _pages - 1)) \ ((Me.Width - 5) / (_pages - 1))
            If page < 0 Then
            	page = 0
            ElseIf page >= _pages
            	page = _pages - 1
            End If
            movingButton.Left = ((Me.Width - 5) / (_pages - 1)) * (page) - 2.5
            CurrentPage = page
        End Sub
        Private Sub Me_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
            If Pages > 1 Then
                Dim localPosition As Point = Me.PointToClient(Cursor.Position)
                Dim pagewidth As Decimal = Me.Width / (Pages - 1)
                Dim page As Integer = Math.Round((localPosition.X / pagewidth))
                movingButton.Left = ((Me.Width - 5) / (_pages - 1)) * (page) - 2.5
                CurrentPage = page
            End If
        End Sub
#End Region

#Region " Subs "

        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.Size = New Size(250, 15)
            Me.ResumeLayout()
        End Sub
        Public Sub New()
            InitializeComponent()
            With movingButton
                .Width = 15
                .Height = Me.Height
                .Left = -5
                .Top = 0
                .Text = ""
                .Visible = False
                .Beeping = False
            End With
            AddHandler movingButton.MouseDown, AddressOf Button_Mouse_Down
            AddHandler movingButton.MouseUp, AddressOf Button_Mouse_Up
            AddHandler movingButton.MouseMove, AddressOf Button_Mouse_Move
            Me.Controls.Add(movingButton)
            movingButton.BringToFront()
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim myG As Graphics = Me.CreateGraphics()
            Dim myBitmap As New Bitmap(Me.Width, Me.Height)
            Dim g As Graphics = Graphics.FromImage(myBitmap)
            Dim myBrush As New SolidBrush(ColorsAvailable.getColor(TickColor))
            'Draw base bar
            g.Clear(Color.Black)
            g.FillRectangle(myBrush, New Rectangle(0, Me.Height * 2 / 3, Me.Width, Me.Height / 3))
            If Pages > 1 Then
                Dim i As Integer
                Dim x As Decimal = (Me.Width - 5) / (_pages - 1)
                For i = 0 To Pages
                    'Code to draw all tick marks
                    g.FillRectangle(myBrush, New Rectangle(i * x, 0, 5, Me.Height))
                Next
            End If
            myG.DrawImage(myBitmap, New Point(0, 0))
        End Sub
        
#End Region

    End Class
End Namespace