Imports LCARS.UI

Public Class frmOptions

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tglShowHidden.State = My.Settings.showHidden
        tglSystem.State = My.Settings.showSystem
        tglReparse.State = My.Settings.showReparse
        tglCheck.State = My.Settings.check
        tglColor.State = My.Settings.ColorFiles
        tglDimHidden.State = My.Settings.dimHidden
        txtStartDir.Text = My.Settings.startDir
        If My.Settings.ClickMode = "Single" Then
            fbClickMode.Top = hpSingle.Top
        Else
            fbClickMode.Top = hpDouble.Top
        End If
        reloadList()
    End Sub

    Private Sub SbOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sbOK.Click
        If (System.IO.Directory.Exists(txtStartDir.Text) Or txtStartDir.Text = "") Then
            My.Settings.startDir = txtStartDir.Text
        Else
            MsgBox("Start directory invalid: setting not changed")
        End If
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub reloadList()
        lstShortcuts.Items.Clear()
        For i As Integer = 0 To My.Settings.shortcuts.Count - 1
            lstShortcuts.Items.Add(My.Settings.shortcutNames(i) & vbTab & My.Settings.shortcuts(i))
        Next
    End Sub
    Private Sub fbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbAdd.Click
        Dim strLable As String = inputbox("Enter name for new shortcut", "New Shortcut", "New Shortcut")
        If strLable = String.Empty Then Return
        Dim strPath As String = inputbox("Enter path of new shortcut", "New Shortcut", "")
        If strPath = String.Empty Then Return
        If (System.IO.Directory.Exists(strPath)) Then
            My.Settings.shortcuts.Add(strPath)
            My.Settings.shortcutNames.Add(strLable)
            reloadList()
        Else
            MsgBox("Invalid path")
        End If
    End Sub

    Private Sub fbAddSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbAddSystem.Click
        MsgBox("Not implemented yet!")
    End Sub

    Private Sub fbRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbRemove.Click
        If (lstShortcuts.SelectedIndex <> -1) Then
            My.Settings.shortcuts.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.RemoveAt(lstShortcuts.SelectedIndex)
            reloadList()
        End If
    End Sub

    Private Sub fbUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbUp.Click
        Dim index As Integer = lstShortcuts.SelectedIndex
        If index < 1 Then Return
        Dim strtemp As String = My.Settings.shortcuts.Item(index)
        My.Settings.shortcuts.RemoveAt(index)
        My.Settings.shortcuts.Insert(index - 1, strtemp)
        strtemp = My.Settings.shortcutNames.Item(index)
        My.Settings.shortcutNames.RemoveAt(index)
        My.Settings.shortcutNames.Insert(index - 1, strtemp)
        reloadList()
        lstShortcuts.SelectedIndex = index - 1
    End Sub

    Private Sub fbDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDown.Click
        Dim index As Integer = lstShortcuts.SelectedIndex
        If index < 0 Then Return
        If index = lstShortcuts.Items.Count - 1 Then Return
        Dim strtemp As String = My.Settings.shortcuts.Item(index)
        My.Settings.shortcuts.RemoveAt(index)
        My.Settings.shortcuts.Insert(index + 1, strtemp)
        strtemp = My.Settings.shortcutNames.Item(index)
        My.Settings.shortcutNames.RemoveAt(index)
        My.Settings.shortcutNames.Insert(index + 1, strtemp)
        reloadList()
        lstShortcuts.SelectedIndex = index + 1
    End Sub

    Private Sub fbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbEdit.Click
        If (lstShortcuts.SelectedIndex <> -1) Then
            My.Settings.shortcutNames.Item(lstShortcuts.SelectedIndex) = InputBox("Enter new name for shortcut", "Rename Shortcut", My.Settings.shortcutNames.Item(lstShortcuts.SelectedIndex))
            My.Settings.shortcuts.Item(lstShortcuts.SelectedIndex) = InputBox("Enter new path for shortcut", "Change Shortcut Path", My.Settings.shortcuts.Item(lstShortcuts.SelectedIndex))
            reloadList()
        End If
    End Sub

    Private Sub hpSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpSingle.Click
        fbClickMode.Top = hpSingle.Top
        My.Settings.ClickMode = "Single"
    End Sub

    Private Sub hpDouble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpDouble.Click
        fbClickMode.Top = hpDouble.Top
        My.Settings.ClickMode = "Double"
    End Sub

#Region " View toggles "
    Private Sub tglShowHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglShowHidden.Click
        My.Settings.showHidden = tglShowHidden.State
    End Sub

    Private Sub tglSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglSystem.Click
        My.Settings.showSystem = tglSystem.State
    End Sub

    Private Sub tglReparse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglReparse.Click
        My.Settings.showReparse = tglReparse.State
    End Sub

    Private Sub tglCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglCheck.Click
        My.Settings.check = tglCheck.State
    End Sub

    Private Sub tglColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglColor.Click
        My.Settings.ColorFiles = tglColor.State
    End Sub

    Private Sub tglDimHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tglDimHidden.Click
        My.Settings.dimHidden = tglDimHidden.State
    End Sub
#End Region

End Class
