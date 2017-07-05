Public Class TaskbarItem
    Dim _closeButton As LCARS.Controls.FlatButton
    Dim _windowButton As LCARS.Controls.HalfPillButton
    Dim _index As Integer
    Dim _offset As Integer = 0
    Dim b As modBusiness

    Public Sub New(ByVal app As ExternalApp, ByVal b As modBusiness, ByVal index As Integer)
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
            .Text = app.Text
            .Size = New Point(100, 25)
            .Top = 0
            .Data = app.HWND
            .Beeping = beeping
            .ButtonTextAlign = ContentAlignment.TopLeft
            .Lit = Not app.Minimized
            AddHandler .Click, AddressOf AppsButton_Click
        End With
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

    Public Sub Update(ByVal app As ExternalApp, ByVal flags As WindowUpdateFlags)
        If (flags And WindowUpdateFlags.State) = WindowUpdateFlags.State Then
            _windowButton.Lit = Not app.Minimized
        End If
        If (flags And WindowUpdateFlags.Text) = WindowUpdateFlags.Text Then
            _windowButton.Text = app.Text
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
        Dim myButton As LCARS.LCARSbuttonClass = CType(sender, LCARS.LCARSbuttonClass)
        Dim myHandle As Integer = myButton.Data

        If myButton.Color = LCARS.LCARScolorStyles.PrimaryFunction Then
            If getWindowState(myHandle) <> WindowStates.MINIMIZED Then
                myButton.Data2 = getWindowState(myHandle)
                SetWindowState(myHandle, WindowStates.MINIMIZED)
            Else
                If Not myButton.Data2 Is Nothing Then
                    SetWindowState(myHandle, myButton.Data2)
                Else
                    SetWindowState(myHandle, WindowStates.NORMAL)
                End If
            End If
        Else
            If getWindowState(myHandle) = WindowStates.MINIMIZED Then
                If Not myButton.Data2 Is Nothing Then
                    SetWindowState(myHandle, myButton.Data2)
                Else
                    SetWindowState(myHandle, WindowStates.NORMAL)
                End If
            End If
            SetTopWindow(myHandle)
        End If
    End Sub
End Class
