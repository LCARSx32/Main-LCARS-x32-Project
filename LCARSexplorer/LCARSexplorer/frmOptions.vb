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
        Dim strLable As String = InputBox("Enter name for new shortcut", "New Shortcut", "New Shortcut")
        Dim strPath As String = InputBox("Enter path of new shortcut", "New Shortcut", "")
        If (System.IO.Directory.Exists(strPath)) Then
            My.Settings.shortcuts.Add(strPath)
            My.Settings.shortcutNames.Add(strLable)
            reloadList()
        Else
            MsgBox("Invalid path")
        End If
    End Sub

    Private Sub fbRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbRemove.Click
        If (lstShortcuts.SelectedIndex <> -1) Then
            My.Settings.shortcuts.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.RemoveAt(lstShortcuts.SelectedIndex)
            reloadList()
        End If
    End Sub

    Private Sub fbUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbUp.Click
        If (lstShortcuts.SelectedIndex > 0) Then
            Dim strtemp As String = My.Settings.shortcuts.Item(lstShortcuts.SelectedIndex)
            My.Settings.shortcuts.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcuts.Insert(lstShortcuts.SelectedIndex - 1, strtemp)
            strtemp = My.Settings.shortcutNames.Item(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.Insert(lstShortcuts.SelectedIndex - 1, strtemp)
            reloadList()
        End If
    End Sub

    Private Sub fbDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDown.Click
        If (lstShortcuts.SelectedIndex <> -1 And lstShortcuts.SelectedIndex < lstShortcuts.Items.Count - 1) Then
            Dim strtemp As String = My.Settings.shortcuts.Item(lstShortcuts.SelectedIndex)
            My.Settings.shortcuts.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcuts.Insert(lstShortcuts.SelectedIndex + 1, strtemp)
            strtemp = My.Settings.shortcutNames.Item(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.RemoveAt(lstShortcuts.SelectedIndex)
            My.Settings.shortcutNames.Insert(lstShortcuts.SelectedIndex + 1, strtemp)
            reloadList()
        End If
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
