Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    Public Class ProgressBar
        Inherits Control

#Region " Global Variables "

        'Global Variables
        Private _value As Decimal = 0.5
        Private _color1 As LCARScolorStyles = LCARScolorStyles.StaticTan
        Private _color2 As LCARScolorStyles = LCARScolorStyles.PrimaryFunction
        Private _horizontal As Integer = 10
        Private _vertical As Integer = 20
        Private _spacing As Integer = 5
        Private _style As ProgressBarStyle = ProgressBarStyle.Horizontal

        'Permanent Controls
        Private topLeft As New Elbow
        Private topRight As New Elbow
        Private bottomLeft As New Elbow
        Private bottomRight As New Elbow
        Private topBar As New FlatButton
        Private bottomBar As New FlatButton
        Private leftbar As New FlatButton
        Private rightBar As New FlatButton
        Private display As New FlatButton
#End Region

#Region " Enum "

        Public Enum ProgressBarStyle
            Horizontal = 0
            Vertical = 1
        End Enum

#End Region

#Region " Properties "

        Public Property Value() As Decimal
            Get
                Return _value
            End Get
            Set(ByVal value1 As Decimal)
                If value1 >= 0 And value1 <= 1 Then
                    _value = value1
                    redraw()
                End If
            End Set
        End Property

        Public Property Color1() As LCARScolorStyles
            Get
                Return _color1
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color1 = value
                topLeft.Color = value
                topRight.Color = value
                bottomLeft.Color = value
                bottomRight.Color = value
                topBar.Color = value
                bottomBar.Color = value
                rightBar.Color = value
                leftbar.Color = value
            End Set
        End Property

        Public Property Color2() As LCARScolorStyles
            Get
                Return _color2
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color2 = value
                display.Color = value
            End Set
        End Property

        Public Property TopText() As String
            Get
                Return topBar.Text
            End Get
            Set(ByVal value As String)
                topBar.Text = value
            End Set
        End Property

        Public Property TopTextAlign() As System.Drawing.ContentAlignment
            Get
                Return topBar.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                topBar.ButtonTextAlign = value
            End Set
        End Property

        Public Property BottomText() As String
            Get
                Return bottomBar.Text
            End Get
            Set(ByVal value As String)
                bottomBar.Text = value
            End Set
        End Property

        Public Property BottomTextAlign() As System.Drawing.ContentAlignment
            Get
                Return bottomBar.ButtonTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                bottomBar.ButtonTextAlign = value
            End Set
        End Property

        Public Property HorizontalBarThickness() As Integer
            Get
                Return _horizontal
            End Get
            Set(ByVal value As Integer)
                _horizontal = value
                redraw()
            End Set
        End Property

        Public Property VerticalBarThickness() As Integer
            Get
                Return _vertical
            End Get
            Set(ByVal value As Integer)
                _vertical = value
                redraw()
            End Set
        End Property

        Public Property Spacing() As Integer
            Get
                Return _spacing
            End Get
            Set(ByVal value As Integer)
                _spacing = value
                redraw()
            End Set
        End Property

        Public Property ProgressBarOrientation() As ProgressBarStyle
            Get
                Return _style
            End Get
            Set(ByVal value As ProgressBarStyle)
                _style = value
                redraw()
            End Set
        End Property

#End Region

#Region " Event Handlers "
        Public Sub Me_resize() Handles Me.Resize
            redraw()
        End Sub
#End Region

#Region " Subs "
        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 100)
            Me.ResumeLayout()
        End Sub
        Public Sub New()
            InitializeComponent()
            'Elbows
            With topLeft
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperLeft
                .Text = ""
                .Top = 0
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
            End With
            Me.Controls.Add(topLeft)
            With topRight
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperRight
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = 0
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(topRight)
            With bottomRight
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.LowerRight
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(bottomRight)
            With bottomLeft
                .Color = _color1
                .Clickable = False
                .ElbowStyle = Elbow.LCARSelbowStyles.LowerLeft
                .Text = ""
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            Me.Controls.Add(bottomLeft)
            'Bars
            With topBar
                .Color = _color1
                .Clickable = False
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = 0
                .Left = topLeft.Width
            End With
            Me.Controls.Add(topBar)
            With bottomBar
                .Color = _color1
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.BottomRight
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = Me.Height - .Height
                .Left = topLeft.Width
            End With
            Me.Controls.Add(bottomBar)
            With leftbar
                .Color = _color1
                .Clickable = False
                .Text = ""
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = 0
            End With
            Me.Controls.Add(leftbar)
            With rightBar
                .Color = _color1
                .Clickable = False
                .Text = ""
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = Me.Width - .Width
            End With
            Me.Controls.Add(rightBar)
            'Display
            With display
                .Color = _color2
                .Clickable = False
                .Text = ""
                If _style = ProgressBarStyle.Horizontal Then
                    .Height = rightBar.Height
                    .Width = topBar.Width * Value
                    .Top = topRight.Height
                    .Left = topRight.Width
                Else
                    .Height = rightBar.Height * _value
                    .Width = topBar.Width
                    .Top = Me.Height - (.Height + topRight.Height)
                    .Left = topRight.Width
                End If
            End With
            Me.Controls.Add(display)
        End Sub

        Public Sub redraw()
            With topLeft
                .Top = 0
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
            End With
            With topRight
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = 0
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            With bottomRight
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = Me.Width - .Width
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            With bottomLeft
                .Height = Spacing + _vertical
                .Width = Spacing + _horizontal
                .Top = Me.Height - .Height
                .Left = 0
                .ButtonWidth = _horizontal
                .ButtonHeight = _vertical
            End With
            'Bars
            With topBar
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = 0
                .Left = topLeft.Width
            End With
            With bottomBar
                .Height = _vertical
                .Width = Me.Width - (topLeft.Width * 2)
                .Top = Me.Height - .Height
                .Left = topLeft.Width
            End With
            With leftbar
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = 0
            End With
            With rightBar
                .Height = Me.Height - (topLeft.Height * 2)
                .Width = _horizontal
                .Top = topLeft.Height
                .Left = Me.Width - .Width
            End With
            'Display
            With display
                If _style = ProgressBarStyle.Horizontal Then
                    .Height = rightBar.Height
                    .Width = topBar.Width * Value
                    .Top = topRight.Height
                    .Left = topRight.Width
                Else
                    .Height = rightBar.Height * _value
                    .Width = topBar.Width
                    .Top = Me.Height - (.Height + topRight.Height)
                    .Left = topRight.Width
                End If
            End With

        End Sub

#End Region

    End Class
End Namespace