Public Class frmTaskManager

    Private Sub frmTaskManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myProcesses() = Process.GetProcesses()
        For Each myproc As Process In myProcesses
            lstProcesses.Items.Add(myproc.ProcessName)
        Next
    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click
        Me.Close()
    End Sub
End Class