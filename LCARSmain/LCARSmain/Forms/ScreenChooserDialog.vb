Public Class ScreenChooserDialog
    Private screenType As Type = Nothing
    Private WithEvents interop As LCARS.x32Interop
    Private _screenIndex As Integer

    Public Sub New(ByVal screenIndex As Integer)
        InitializeComponent()
        _screenIndex = screenIndex
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not screenType Is Nothing Then
            curBusiness(_screenIndex).mainTimer.Enabled = False
            curBusiness(_screenIndex).tmrAutohide.enabled = False
            curBusiness(_screenIndex).myForm.Dispose()
            Dim myForm As Form = CType(Activator.CreateInstance(screenType, _screenIndex), Form)
            myForm.Show()
        End If
        Me.Close()
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub

    Private Sub ScreenChooserDialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For i As Integer = 0 To gridScreens.Count - 1
            Dim myScreenImage As LCScreenImage = CType(gridScreens.Items(i), LCScreenImage)
            If Not myScreenImage.Image Is Nothing Then
                myScreenImage.Image.Dispose()
            End If
        Next
    End Sub

    Private Sub ScreenChooserDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each myScreenType As Type In getMainScreenTypes()
            Dim myScreen As New LCScreenImage()
            myScreen.Text = myScreenType.Name
            myScreen.Data = myScreenType
            AddHandler myScreen.Click, AddressOf myScreen_Click
            Try
                'Get cached files (Will match screen aspect ratio)
                myScreen.Image = System.Drawing.Image.FromFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images\" & myScreenType.Name & "_" & _screenIndex & ".jpg")
            Catch ex As Exception
                'File didn't exist or was in use
                Dim pInfo As Reflection.PropertyInfo = myScreenType.GetProperty("ScreenImage")
                If Not pInfo Is Nothing Then
                    myScreen.Image = pInfo.GetValue(Nothing, Nothing)
                End If
            End Try
            gridScreens.Add(myScreen)
        Next
        interop = New LCARS.x32Interop()
        interop.Init()
        Me.Bounds = Screen.AllScreens(_screenIndex).Bounds
    End Sub

    Private Sub myScreen_Click(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To gridScreens.Count - 1
            CType(gridScreens.Items(i), LCScreenImage).Selected = False
        Next
        CType(sender, LCScreenImage).Selected = True
        screenType = CType(CType(sender, LCScreenImage).Data, Type)
    End Sub

    Private Sub ScreenChooserDialog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize, Me.LocationChanged
        Dim adjustedBounds As Rectangle = Screen.FromHandle(Me.Handle).WorkingArea
        adjustedBounds.Location -= Screen.FromHandle(Me.Handle).Bounds.Location
        If Not Me.MaximizedBounds = adjustedBounds Then
            Me.MaximizedBounds = adjustedBounds
        End If
    End Sub
End Class