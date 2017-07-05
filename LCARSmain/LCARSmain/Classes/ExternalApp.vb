Option Strict On

Public Class ExternalApp
    Private _hwnd As Integer
    Private _text As String
    Private _hScreen As Integer
    Private _topmost As Boolean = False
    Private _minimized As Boolean

    Public Sub New(ByVal hwnd As Integer)
        _hwnd = hwnd
        'Get window text
        Dim sWindowText As String = Space(256)
        Dim lReturn As Integer = GetWindowText(hwnd, sWindowText, Len(sWindowText))
        If lReturn <> 0 Then
            _text = Left(sWindowText, lReturn)
        Else
            _text = "[No caption]"
        End If
        'Get screen
        _hScreen = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST)
        _minimized = (getWindowState(hwnd) = WindowStates.MINIMIZED)
    End Sub

    Public ReadOnly Property HWND() As Integer
        Get
            Return _hwnd
        End Get
    End Property

    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property hScreen() As Integer
        Get
            Return _hScreen
        End Get
        Set(ByVal value As Integer)
            _hScreen = value
        End Set
    End Property

    Public Property Minimized() As Boolean
        Get
            Return _minimized
        End Get
        Set(ByVal value As Boolean)
            _minimized = value
        End Set
    End Property

    Public Property topmost() As Boolean
        Get
            Return _topmost
        End Get
        Set(ByVal value As Boolean)
            _topmost = value
        End Set
    End Property
End Class
