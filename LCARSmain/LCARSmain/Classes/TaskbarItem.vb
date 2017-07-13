Public Class TaskbarItem
    Dim _closeButton As LCARS.Controls.FlatButton
    Dim _windowButton As LCARS.Controls.HalfPillButton
    Dim _index As Integer
    Dim _offset As Integer = 0
    Dim _app As ExternalApp
    Dim _topmostSavedState As Boolean
    Dim b As modBusiness

    Public Sub New(ByVal app As ExternalApp, ByVal b As modBusiness, ByVal index As Integer)
        _app = app
        _closeButton = New LCARS.Controls.FlatButton()
        Me.b = b
        Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
        With _closeButton
            .Size = New Point(20, 25)
            .Text = "X"
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .Color = LCARS.LCARScolorStyles.FunctionOffline
            .Top = 0
            .Data = app.HWND
            .Beeping = beeping
            AddHandler .Click, AddressOf CloseButton_Click
        End With
        _windowButton = New LCARS.Controls.HalfPillButton()
        With _windowButton
            .Size = New Point(100, 25)
            .Top = 0
            .Data = app.HWND
            .Beeping = beeping
            .ButtonTextAlign = ContentAlignment.TopLeft
            AddHandler .Click, AddressOf AppsButton_Click
            AddHandler .MouseDown, AddressOf WindowButton_MouseDown
        End With
        Update(WindowUpdateFlags.State Or WindowUpdateFlags.Text Or WindowUpdateFlags.Topmost)
        Me.Index = index
        b.myAppsPanel.Controls.Add(_closeButton)
        b.myAppsPanel.Controls.Add(_windowButton)
    End Sub

    Public Property Index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then Throw New ArgumentOutOfRangeException
            _index = value
            _closeButton.Left = (_index + _offset) * 134 + 31
            _windowButton.Left = (_index + _offset) * 134 + 56
        End Set
    End Property

    Public Property Offset() As Integer
        Get
            Return _offset
        End Get
        Set(ByVal value As Integer)
            _offset = value
            Index = _index
        End Set
    End Property

    Public Sub Update(ByVal flags As WindowUpdateFlags)
        If (flags And WindowUpdateFlags.State) = WindowUpdateFlags.State Then
            _windowButton.Lit = Not _app.Minimized
        End If
        If (flags And WindowUpdateFlags.Text) = WindowUpdateFlags.Text Then
            _windowButton.Text = _app.Text
        End If
        If (flags And WindowUpdateFlags.Topmost) = WindowUpdateFlags.Topmost Then
            If _app.topmost Then
                _windowButton.Color = LCARS.LCARScolorStyles.PrimaryFunction
            Else
                _windowButton.Color = LCARS.LCARScolorStyles.MiscFunction
            End If
        End If
    End Sub

    Public Sub Remove()
        b.myAppsPanel.Controls.Remove(_closeButton)
        b.myAppsPanel.Controls.Remove(_windowButton)
    End Sub

    'Red "X" next to the taskbar button
    Private Sub CloseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CloseWindow(CInt(CType(sender, LCARS.LCARSbuttonClass).Data))
    End Sub

    'Taskbar button
    Private Sub AppsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If _topmostSavedState Then
            If getWindowState(_app.HWND) <> WindowStates.MINIMIZED Then
                _windowButton.Data2 = getWindowState(_app.HWND)
                SetWindowState(_app.HWND, WindowStates.MINIMIZED)
            Else
                If Not _windowButton.Data2 Is Nothing Then
                    SetWindowState(_app.HWND, _windowButton.Data2)
                Else
                    SetWindowState(_app.HWND, WindowStates.NORMAL)
                End If
            End If
        Else
            If getWindowState(_app.HWND) = WindowStates.MINIMIZED Then
                If Not _windowButton.Data2 Is Nothing Then
                    SetWindowState(_app.HWND, _windowButton.Data2)
                Else
                    SetWindowState(_app.HWND, WindowStates.NORMAL)
                End If
            End If
            SetTopWindow(_app.HWND)
        End If
    End Sub

    Private Sub WindowButton_MouseDown(ByVal sender As Object, ByVal e As EventArgs)
        _topmostSavedState = _app.topmost
    End Sub
End Class
