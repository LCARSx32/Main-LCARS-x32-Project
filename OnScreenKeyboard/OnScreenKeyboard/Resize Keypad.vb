Public Class Resize_Keypad

    'required for drag option
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Resize_Keypad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Sets the resize panel to the last location chosen by user
        Me.Location = My.Settings.Resize_KeypadPosition

    End Sub


    Private Sub sbDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDone.Click

        'Sets the resize panel to the last location chosen by user
        My.Settings.Resize_KeypadPosition = Location
        frmKeyboard.frmKeyboard_ResizeEnd(sender, e)
        My.Settings.Save()
        Me.Hide()



    End Sub

    Private Sub sbWidthMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbWidthMinus.Click

        frmKeyboard.sbWidthMinus_Click(sender, e)

    End Sub

    Private Sub sbWidthPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbWidthPlus.Click

        frmKeyboard.sbWidthPlus_Click(sender, e)

    End Sub

    Private Sub sbHeightMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbHeightMinus.Click

        frmKeyboard.sbHeightMinus_Click(sender, e)

    End Sub

    Private Sub sbHeightPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbHeightPlus.Click

        frmKeyboard.sbHeightPlus_Click(sender, e)

    End Sub

    Private Sub sbIncrementMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbIncrementMinus.Click

        frmKeyboard.sbIncrementMinus_Click(sender, e)
        lblIncrement.Text = frmKeyboard.lblIncrement.Text

    End Sub

    Private Sub sbIncrementPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbIncrementPlus.Click

        frmKeyboard.sbIncrementPlus_Click(sender, e)
        lblIncrement.Text = frmKeyboard.lblIncrement.Text

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