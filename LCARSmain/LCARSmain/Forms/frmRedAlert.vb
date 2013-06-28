Public Class frmRedAlert
    Public screenIndex As Integer

    Private Sub frmRedAlert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Property Message() As String
        Get
            Return lblMessage.Text
        End Get
        Set(ByVal value As String)
            lblMessage.Text = value
        End Set
    End Property

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click
        '  cancelAlert = True
        Me.Close()

    End Sub

    Private Sub tmrWA_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWA.Tick
        If Not Me.Bounds = Screen.AllScreens(screenIndex).WorkingArea Then
            Me.Bounds = Screen.AllScreens(screenIndex).WorkingArea
        End If
    End Sub


End Class