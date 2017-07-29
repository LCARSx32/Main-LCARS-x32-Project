Public Class frmRunProgram

    Private Sub fbBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbBrowse.Click
        Dim mybrowse As New LCARSexplorer.frmFileSelect("C:\Program Files", ".exe,.bat,", "Select Program")
        mybrowse.ShowDialog()
        If (mybrowse.DialogResult = Windows.Forms.DialogResult.OK) Then
            txtCommand.Text = mybrowse.ReturnPath
        End If
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        If (txtCommand.Text <> "") Then
            Try
                Process.Start("""" & txtCommand.Text & """")
                Me.Close()
            Catch ex As Exception
                MsgBox("Invalid command")
            End Try
        End If
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        sbOK.doClick(sender, e)
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        sbCancel.doClick(sender, e)
    End Sub

    Private Sub frmRunProgram_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCommand.Focus()
    End Sub
End Class