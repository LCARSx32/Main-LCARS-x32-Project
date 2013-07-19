'Imports LCARS.UI
Public Class Form1
    Dim WithEvents interop As New LCARS.x32Interop
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 500
            Dim myTemp As New LCARS.LightweightControls.LCComplexButton
            myTemp.SideText = i
            myGrid.Add(myTemp)
            myTemp.Flashing = True
        Next
        interop.Init()
    End Sub

    Private Sub interop_AlertEnded() Handles interop.AlertEnded
        StandardButton1.Text = "No Alert"
    End Sub

    Private Sub interop_AlertInitiated(ByVal AlertID As Integer) Handles interop.AlertInitiated
        StandardButton1.Text = AlertID
    End Sub

    Private Sub interop_BeepingChanged(ByVal Beeping As Boolean) Handles interop.BeepingChanged
        FlatButton1.Text = Beeping.ToString()
    End Sub

    Private Sub interop_ColorsChanged() Handles interop.ColorsChanged
        MsgBox("Colors updated")
    End Sub

    Private Sub interop_LCARSx32Closing() Handles interop.LCARSx32Closing
        Me.Close()
    End Sub

    Private Sub interop_WorkingAreaChanged(ByVal NewArea As System.Drawing.Rectangle) Handles interop.WorkingAreaChanged
        Me.Bounds = NewArea
    End Sub


End Class
