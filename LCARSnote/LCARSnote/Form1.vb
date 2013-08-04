Imports LCARS.Controls

Public Class Form1
    Dim dirtyBoxes(-1) As RichTextBox

    Private Sub sbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOpen.Click

        Dim myfile As New OpenFileDialog
        Dim result As DialogResult

        result = myfile.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then

            Dim myPage As New x32TabPage(System.IO.Path.GetFileName(myfile.FileName))
            Dim myNote As New RichTextBox

            xtNote.TabPages.Add(myPage)

            myNote.Name = "myNote"
            myNote.Bounds = New Rectangle(0, 0, myPage.Width, myPage.Height)
            myNote.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            myNote.BackColor = Color.Black
            myNote.ForeColor = Color.Orange
            myNote.BorderStyle = BorderStyle.None

            myNote.Font = New Font("LCARS", 16, FontStyle.Regular, GraphicsUnit.Point)

            myNote.LoadFile(myfile.FileName)


            myPage.Controls.Add(myNote)


            AddHandler myNote.TextChanged, AddressOf myNote_TextChanged
        End If
    End Sub

    Private Sub sbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbNew.Click
        Dim myPage As New x32TabPage(GetDocName)
        Dim myNote As New RichTextBox

        xtNote.TabPages.Add(myPage)

        myNote.Name = "myNote"
        myNote.Bounds = New Rectangle(0, 0, myPage.Width, myPage.Height)
        myNote.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        myNote.BackColor = Color.Black
        myNote.ForeColor = Color.Orange
        myNote.BorderStyle = BorderStyle.None
        myNote.AcceptsTab = True
        myNote.Font = New Font("LCARS", 16, FontStyle.Regular, GraphicsUnit.Point)

        myPage.Controls.Add(myNote)

        AddHandler myNote.TextChanged, AddressOf myNote_TextChanged
    End Sub

    Private Sub myNote_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mybox As RichTextBox = CType(sender, RichTextBox)

        If Array.IndexOf(dirtyBoxes, mybox) = -1 Then
            ReDim Preserve dirtyBoxes(dirtyBoxes.Length)
            dirtyBoxes(dirtyBoxes.GetUpperBound(0)) = mybox
        End If
    End Sub

    Private Function GetDocName() As String
        Dim docCount As Integer = 1

        For Each myTab As x32TabPage In xtNote.TabPages
            If myTab.Text.Contains("NEW DOCUMENT") Then
                docCount += 1
            End If
        Next

        Return "NEW DOCUMENT" & docCount

    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.PrimaryScreen.WorkingArea

    End Sub

    Private Sub sbFullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFullScreen.Click
        If Me.Bounds = Screen.PrimaryScreen.Bounds Then
            Me.Bounds = Screen.PrimaryScreen.WorkingArea
        Else
            Me.Bounds = Screen.PrimaryScreen.Bounds
        End If
    End Sub

    Private Sub sbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSave.Click
        Dim myFile As New LCARS.LCARSfileBrowseDialog(LCARS.LCARSfileBrowseDialog.LCARSDialogType.Save)
        Dim result As DialogResult


        If Me.Bounds = Screen.PrimaryScreen.Bounds Then
            myFile.Fullscreen = True
        Else
            myFile.Fullscreen = False
        End If

        myFile.FileName = xtNote.SelectedTab.Text & ".TXT"


        result = myFile.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Dim mybox As RichTextBox = CType(xtNote.SelectedTab.Controls("myNote"), RichTextBox)
            Select Case System.IO.Path.GetExtension(myFile.FileName).ToLower
                Case ".rtf", ".doc"
                    mybox.SaveFile(myFile.FileName)
                Case Else
                    FileOpen(1, myFile.FileName, OpenMode.Output)
                    Print(1, mybox.Text)
                    FileClose(1)
            End Select
        End If

    End Sub

    Private Sub sbSaveCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbX.Click
        Me.Close()
        End
    End Sub

    Private Sub xtNote_SelectedTabChanged(ByVal Tab As LCARS.Controls.x32TabPage, ByVal TabIndex As System.Int32) Handles xtNote.SelectedTabChanged
        If xtNote.TabPages.Count > 0 Then
            sbSave.Lit = True
            sbSave.Clickable = True

            sbSaveAs.Lit = True
            sbSaveAs.Clickable = True

            sbClose.Lit = True
            sbClose.Clickable = True


            sbNew.Flash = False
        Else
            sbSave.Lit = False
            sbSave.Clickable = False

            sbSaveAs.Lit = False
            sbSaveAs.Clickable = False

            sbClose.Lit = False
            sbClose.Clickable = False

            sbNew.Flash = True
        End If
    End Sub

    Private Sub sbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbClose.Click
        Dim mybox As RichTextBox = CType(xtNote.SelectedTab.Controls("myNote"), RichTextBox)

        If Array.IndexOf(dirtyBoxes, mybox) > -1 Then
            Dim result As MsgBoxResult
            result = LCARS.UI.MsgBox("Would you like to save the changes to the file '" & xtNote.SelectedTab.Text & "'?", MsgBoxStyle.YesNo, "SAVE FILE?")

            If result = MsgBoxResult.Yes Then
                sbSave_Click(sender, e)
            End If

        End If
        xtNote.TabPages.Remove(xtNote.SelectedTab)

    End Sub
End Class
