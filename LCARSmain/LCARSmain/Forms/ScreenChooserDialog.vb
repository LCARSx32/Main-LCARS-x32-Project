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
        Dim i As Integer = 1
        For Each myScreenType As Type In getMainScreenTypes()
            Dim myScreen As New LCScreenImage()
            myScreen.Text = myScreenType.Name
            myScreen.Data = i
            AddHandler myScreen.Click, AddressOf myScreen_Click
            Try
                'Get cached files (Will match screen aspect ratio)
                myScreen.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\" & myScreenType.Name & ".jpg")
            Catch ex As Exception
                'File didn't exist or was in use
                Try
                    'Get file from static member
                    Dim pInfo As Reflection.PropertyInfo = myScreenType.GetProperty("ScreenImage")
                    myScreen.Image = pInfo.GetValue(Nothing, Nothing)
                Catch ex2 As Exception
                    'Static member not implemented; display missing image
                    MsgBox("Unable to find image")
                End Try
            End Try
            gridScreens.Add(myScreen)
            i += 1
        Next
    End Sub

    Private Sub myScreen_Click(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To gridScreens.Count - 1
            CType(gridScreens.Items(i), LCScreenImage).Selected = False
        Next
        CType(sender, LCScreenImage).Selected = True
        _ScreenId = CType(CType(sender, LCScreenImage).Data, Integer)
    End Sub
End Class