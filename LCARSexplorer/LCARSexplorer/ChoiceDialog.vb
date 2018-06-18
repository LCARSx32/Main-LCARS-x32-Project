Imports LCARS.LightweightControls
Imports System.Drawing

Public Class ChoiceDialog(Of T)
    Dim _choices() As T
    Dim _names() As String
    Dim _selected As T
    Dim selector As New LCFlatButton() With _
                    {.Color = LCARS.LCARScolorStyles.PrimaryFunction, _
                     .Bounds = New Rectangle(0, 0, 30, 30), _
                     .Text = String.Empty}

    Public Sub New(ByVal choices() As T)
        InitializeComponent()
        _choices = choices
        Dim names As New List(Of String)(choices.Length - 1)
        For i As Integer = 0 To choices.Length - 1
            names(i) = choices(i).ToString()
        Next
        _names = names.ToArray()
        populateChoices()
    End Sub

    Public Sub New(ByVal choices() As T, ByVal displayNames() As String)
        InitializeComponent()
        _choices = choices
        _names = displayNames
        populateChoices()
    End Sub

    Private Sub populateChoices()
        'Need to measure strings to make sure they all fit.
        'Dim maxWidth As Integer = 0
        'Dim g As Graphics = Me.CreateGraphics()
        'For Each n As String In _names
        'Next
        'g.Dispose()
        lstChoices.Items.AddRange(_names)
    End Sub

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            tbTitle.Text = value
        End Set
    End Property

    Public Property Color() As LCARS.LCARScolorStyles
        Get
            Return tbTitle.Color
        End Get
        Set(ByVal value As LCARS.LCARScolorStyles)
            tbTitle.Color = value
        End Set
    End Property

    Public Property SelectedItem() As T
        Get
            Return _selected
        End Get
        Set(ByVal value As T)
            _selected = value
            'TODO: Set visual indicator
            lstChoices.SelectedIndex = Array.IndexOf(_choices, value)
        End Set
    End Property

    Private Sub lstChoices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChoices.SelectedIndexChanged
        If lstChoices.SelectedIndex = -1 Then
            _selected = Nothing
        Else
            _selected = _choices(lstChoices.SelectedIndex)
        End If
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        _selected = Nothing
    End Sub
End Class
