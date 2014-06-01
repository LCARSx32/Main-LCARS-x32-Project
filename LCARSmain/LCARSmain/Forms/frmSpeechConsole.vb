'TODO: Show by screen index

Public Class frmSpeechConsole
    Dim oloc As Point
    Private Sub fbHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbHide.Click
        Me.Hide()
    End Sub

    Private Sub fbOnOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbOnOff.Click
        For Each myBusiness As modBusiness In curBusiness
            With myBusiness
                .mySpeech.Lit = Not .mySpeech.Lit
            End With
        Next
        If curBusiness(0).mySpeech.Lit Then
            If Listener Is Nothing Then Listener = New SpeechLib.SpInProcRecoContextClass
            Listener.State = SpeechLib.SpeechRecoContextState.SRCS_Enabled
            fbOnOff.Lit = True
            fbOnOff.Text = "Recognition on"
        Else
            Listener.State = SpeechLib.SpeechRecoContextState.SRCS_Disabled
            fbOnOff.Lit = False
            fbOnOff.Text = "Recognition off"
        End If
    End Sub

    Private Sub txtEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntry.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimulateRecognition(txtEntry.Text)
            lstHistory.SelectedIndex = lstHistory.Items.Count - 1
            lstHistory.SelectedIndex = -1
            txtEntry.Clear()
        End If
    End Sub

    Private Sub elbTop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles elbTop.MouseDown
        oloc = New Point(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub elbTop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles elbTop.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Left += MousePosition.X - oloc.X
            Me.Top += MousePosition.Y - oloc.Y
            oloc = New Point(MousePosition.X, MousePosition.Y)
            Application.DoEvents()
        End If
    End Sub

End Class