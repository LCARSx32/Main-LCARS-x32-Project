Public Class UserButtons

    'required for drag option
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub UserButtons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = My.Settings.UserButtonslocation

    End Sub

    Private Sub sbDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDone.Click

        My.Settings.UserButtonslocation = Location
        My.Settings.Save()
        frmKeyboard.sbLock_click(sender, e)
        frmKeyboard.loadFNbuttons()
        txtUBLoc.Text = ""
        txtUBName.Text = ""
        Me.Hide()

    End Sub

    Private Sub sbBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbBrowse.Click

        Dim myfile As New OpenFileDialog
        Dim result As DialogResult

        result = myfile.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            txtUBLoc.Text = myfile.FileName
        End If

    End Sub



    Private Sub sbMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbMove.MouseDown

        drag = True 'Sets drag variable to true
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top

    End Sub



    Private Sub sbMove_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbMove.MouseMove

        'Drag Function
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If

    End Sub

    Private Sub sbMove_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbMove.MouseUp

        drag = False
        My.Settings.Save()
    End Sub


End Class