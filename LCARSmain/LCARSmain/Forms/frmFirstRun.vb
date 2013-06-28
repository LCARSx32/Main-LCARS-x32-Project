Public Class frmFirstRun
    Private Sub fbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbExit.Click
        Me.Close()
        End
    End Sub

    Private Sub fbBeep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbBeep.Click
        If fbBeep.ButtonText = "TURN OFF BUTTON BEEPS" Then
            fbBeep.ButtonText = "Turn on button beeps"
            changeBeeps(False, Me)
        Else
            fbBeep.ButtonText = "turn off button beeps"
            changeBeeps(True, Me)
        End If

    End Sub

    Private Sub changeBeeps(ByVal doBeep As Boolean, ByVal beepControl As Control)
        For Each myControl As Control In beepControl.Controls
            If myControl.GetType.ToString.Contains("LCARS") Then
                CType(myControl, LCARS.LCARSbuttonClass).Beeping = doBeep
            Else
                If myControl.Controls.Count > 0 Then
                    changeBeeps(doBeep, myControl)
                End If
            End If
        Next
    End Sub

    Private Sub frmFirstRun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.Bounds = Panel1.Bounds
        TabControl1.SendToBack()
        TabControl1_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not Panel1.Tag Is Nothing Then
            Dim index As Integer = Convert.ToInt32(Panel1.Tag)
tryAgain1:
            For Each myControl As Control In Panel1.Controls
                TabControl1.TabPages(index).Controls.Add(myControl)
            Next
            If Panel1.Controls.Count > 0 Then
                GoTo tryAgain1
            End If
        End If

tryAgain2:
        For Each myControl As Control In TabControl1.SelectedTab.Controls
            Panel1.Controls.Add(myControl)
        Next
        If TabControl1.SelectedTab.Controls.Count > 0 Then
            GoTo tryAgain2
        End If

        Panel1.Tag = TabControl1.SelectedIndex
    End Sub

    Private Sub TextButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("works")
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click
        FlatButton2.Flash = False

        If TabControl1.SelectedIndex + 1 < TabControl1.TabPages.Count Then
            TabControl1.SelectedIndex += 1
        Else
            TabControl1.SelectedIndex = 0
        End If
        TabControl1_SelectedIndexChanged(sender, e)


    End Sub

    Private Sub picMain1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain1.Click
        picSelect.Location = New Point(picMain1.Left - 19, picMain1.Top - 15)

    End Sub

    Private Sub picMain2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMain2.Click
        picSelect.Location = New Point(picMain2.Left - 19, picMain2.Top - 15)

    End Sub
End Class