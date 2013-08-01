Public Class ScreenChooserDialog
#Region "Old Code"
    'Dim _screenIndex As Integer
    'Private Sub frmPicScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Dim myBounds As Rectangle

    '   myBounds.X = 0
    '  myBounds.Y = 0
    ' myBounds.Width = 0
    'myBounds.Height = 0
    'For Each myScreen As Screen In Screen.AllScreens
    '   If myScreen.Bounds.X < myBounds.X Then
    '      myBounds.X = myScreen.Bounds.X
    ' End If
    'If myScreen.Bounds.Y < myBounds.Y Then
    '   myBounds.Y = myScreen.Bounds.Y
    'End If
    'myBounds.Width += myScreen.Bounds.Width
    'myBounds.Height += myScreen.Bounds.Height
    'Next

    'Dim xOffset As Integer = myBounds.X * -1
    'Dim yOffset As Integer = myBounds.Y * -1


    '   For i As Integer = 0 To Screen.AllScreens.GetUpperBound(0)
    'Dim myLabel As New Label
    'Dim tmpBounds As Rectangle
    '       tmpBounds = Screen.AllScreens(i).Bounds
    '      tmpBounds.X = tmpBounds.X + xOffset
    '     tmpBounds.Y = tmpBounds.Y + yOffset
    '    myLabel.Bounds = tmpBounds
    '     myLabel.Text = i
    '    myLabel.TextAlign = ContentAlignment.MiddleCenter
    '   myLabel.Font = New Font(Me.Font.FontFamily, Me.Height / 2, FontStyle.Regular, GraphicsUnit.Pixel)
    '  myLabel.ForeColor = Color.Orange
    ' Me.Controls.Add(myLabel)
    'AddHandler myLabel.Click, AddressOf myLabel_click
    'Next
    'Me.Bounds = myBounds



    'End Sub
    'Private Sub myLabel_click(ByVal sender As Object, ByVal e As System.EventArgs)
    '   ScreenIndex = sender.text
    '  Me.DialogResult = Windows.Forms.DialogResult.OK

    'End Sub
    'Public Property ScreenIndex() As Integer
    '   Get
    '      Return _screenIndex
    ' End Get
    'Set(ByVal value As Integer)
    '   _screenIndex = value
    'End Set
    'End Property

    'Private Sub lblNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '   Me.Dispose()
    'End Sub
#End Region
    Dim _ScreenId As Integer = 1
    Public ReadOnly Property ScreenID() As Integer
        Get
            Return _ScreenId
        End Get
    End Property
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click
        _ScreenId = 0
        Me.Close()
    End Sub

    Private Sub ScreenChooserDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            picScreen1.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\frmmainscreen1.jpg")
        Catch ex As Exception
            picScreen1.Image = My.Resources.frmmainscreen1
        End Try
        Try
            picScreen2.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\frmmainscreen2.jpg")
        Catch ex As Exception
            picScreen2.Image = My.Resources.frmmainscreen2
        End Try
        Try
            picScreen3.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\frmmainscreen3.jpg")
        Catch ex As Exception
            picScreen3.Image = My.Resources.frmmainscreen3
        End Try
        Try
            picScreen4.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\frmmainscreen4.jpg")
        Catch ex As Exception
            picScreen4.Image = My.Resources.frmmainscreen4
        End Try
    End Sub

    Private Sub picScreen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScreen1.Click
        _ScreenId = 1
        picSelect.Location = New Point(picScreen1.Location.X - 21, picScreen1.Location.Y - 14)
    End Sub

    Private Sub picScreen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScreen2.Click
        _ScreenId = 2
        picSelect.Location = New Point(picScreen2.Location.X - 21, picScreen2.Location.Y - 14)
    End Sub

    Private Sub picScreen3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScreen3.Click
        _ScreenId = 3
        picSelect.Location = New Point(picScreen3.Location.X - 21, picScreen3.Location.Y - 14)
    End Sub

    Private Sub picScreen4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScreen4.Click
        _ScreenId = 4
        picSelect.Location = New Point(picScreen4.Location.X - 21, picScreen4.Location.Y - 14)
    End Sub
End Class