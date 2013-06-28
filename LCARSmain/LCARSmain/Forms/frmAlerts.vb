Public Class frmAlerts
    Friend Sub loadAlerts()
        Dim alerts As List(Of String) = LCARS.Alerts.GetAllAlertNames()
        myGrid.Clear()
        For Each myalert As String In alerts
            Dim myButton As New LCARS.LightweightControls.LCStandardButton
            myButton.Text = myalert & " Alert"
            myButton.CustomAlertColor = LCARS.Alerts.GetAlertColor(myalert)
            myButton.RedAlert = LCARS.LCARSalert.Custom
            myButton.Data = LCARS.Alerts.GetAlertID(myalert)
            myButton.TextAlign = ContentAlignment.MiddleCenter
            AddHandler myButton.Click, AddressOf myAlert_Click
            myGrid.Add(myButton)
        Next
    End Sub


    Private Sub frmAlerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadAlerts()
        Me.Bounds = Screen.PrimaryScreen.WorkingArea
    End Sub

    Private Sub myAlert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GeneralAlert(CType(sender, LCARS.LightweightControls.LCStandardButton).Data)
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        cancelAlert = True
    End Sub
End Class