Public Class frmManageButtons
    Inherits LCARS.LCARSForm

    Dim isUBedit As Boolean = False
    Dim myBusiness As modBusiness

    Sub New(ByRef Business As modBusiness)
        InitializeComponent()
        myBusiness = Business
        Me.Bounds = Business.WorkingArea
    End Sub

    Private Sub sbUBbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUBbrowse.Click

        Dim myfile As New OpenFileDialog
        Dim result As DialogResult

        result = myfile.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            txtUBLoc.Text = myfile.FileName
        End If
    End Sub

    Private Sub sbUBok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUBok.Click
        If txtUBLoc.Text <> "" Then
            Dim myUserButton As New modBusiness.UserButtonInfo

            myUserButton.Name = txtUBName.Text
            myUserButton.Location = txtUBLoc.Text

            If isUBedit = False Then

                myBusiness.AddUserButton(myUserButton)
            Else
                myBusiness.EditUserButton(myUserButton, lstUserButtons.SelectedIndex)
                isUBedit = False
            End If

            txtUBName.Text = ""
            txtUBLoc.Text = ""

            loadButtons()
        Else
            LCARS.UI.MsgBox("You must specify a command location.")
        End If

    End Sub

    Private Sub sbUBaddCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUBaddCancel.Click
        Me.Close()

    End Sub

    Private Sub sbRemoveUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRemoveUB.Click
        If lstUserButtons.SelectedIndex > -1 Then
            Dim result As MsgBoxResult
            result = MsgBox("Are you sure you want to delete this button?", MsgBoxStyle.YesNo, "CONFIRM DELETION")
            If result = MsgBoxResult.Yes Then
                myBusiness.RemoveUserButton(lstUserButtons.SelectedIndex)
                loadButtons()
            End If
        End If
    End Sub

    Private Sub sbEditUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbEditUB.Click
        If lstUserButtons.SelectedIndex <> -1 Then
            txtUBName.Text = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex).Name
            txtUBLoc.Text = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex).Location
            isUBedit = True
        End If
    End Sub

    Private Sub frmManageButtons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadButtons()
    End Sub

    Private Sub loadButtons()
        Dim tempIndex As Integer = lstUserButtons.SelectedIndex
        myBusiness.loadUserButtons()
        lstUserButtons.Items.Clear()
        Dim index As Integer
        For index = 0 To myBusiness.myUserButtonCollection.Count - 1
            Dim myItem As modBusiness.UserButtonInfo = myBusiness.myUserButtonCollection(index)
            Try
                lstUserButtons.Items.Add(myItem.Name)
            Catch ex As Exception
                'MsgBox(ex.ToString())
            End Try
        Next
    End Sub


    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
    End Sub

    Private Sub sbUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUp.Click
        If lstUserButtons.SelectedIndex > 0 Then
            Dim tempIndex As Integer = lstUserButtons.SelectedIndex
            Dim temp As modBusiness.UserButtonInfo = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex - 1)
            myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex - 1) = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex)
            myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex) = temp
            myBusiness.SaveUserButtons()
            loadButtons()
            lstUserButtons.SelectedIndex = tempIndex - 1
        End If
    End Sub

    Private Sub sbDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDown.Click
        If lstUserButtons.SelectedIndex < lstUserButtons.Items.Count - 1 Then
            Dim tempindex As Integer = lstUserButtons.SelectedIndex
            Dim temp As modBusiness.UserButtonInfo = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex + 1)
            myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex + 1) = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex)
            myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex) = temp
            myBusiness.SaveUserButtons()
            loadButtons()
            lstUserButtons.SelectedIndex = tempindex + 1
        End If
    End Sub

    Private Sub sbToTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbToTop.Click
        If lstUserButtons.SelectedIndex > 0 Then
            Dim Temp As modBusiness.UserButtonInfo = myBusiness.myUserButtonCollection(lstUserButtons.SelectedIndex)
            'This for loop goes backwards. Please keep that in mind.
            For i As Integer = lstUserButtons.SelectedIndex To 1 Step -1
                myBusiness.myUserButtonCollection(i) = myBusiness.myUserButtonCollection(i - 1)
            Next
            myBusiness.myUserButtonCollection(0) = Temp
            myBusiness.SaveUserButtons()
            loadButtons()
            lstUserButtons.SelectedIndex = 0
        End If
    End Sub
End Class