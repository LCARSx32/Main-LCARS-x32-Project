Option Explicit On
Public Class Hlpfrm

    Dim x32hlpx As Integer
    Dim x32hlpy As Integer
    Dim cursorx As Integer
    Dim cursory As Integer

    Dim isMoving As Boolean = False
    Dim isInit As Boolean = False
    Dim oLoc As Point

    'Rusoaica's variables
    Dim _number_of_pages As Integer
    'Dim _chapters() As String
    Dim LCARSbutton As New LCARS.LCARSbuttonClass
    Dim LCARStype As Type = LCARSbutton.GetType


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TopMost = True

        Dim myScreen As Screen = Screen.FromPoint(New Point(Me.Left, Me.Top))

        Dim tmpStr As String = GetSetting("x32_Help", "Settings", "Size", myScreen.Bounds.Width * 0.75 & ", " & 250)
        Dim split() As String = tmpStr.Split(",")

        Me.Width = split(0)
        Me.Height = split(1)

        tmpStr = GetSetting("x32_Help", "Settings", "Location", myScreen.Bounds.Left + myScreen.Bounds.Width * 0.125 & ", " & myScreen.Bounds.Height - Me.Height)

        split = tmpStr.Split(",")

        Me.Left = split(0)
        Me.Top = split(1)

        isInit = True

        SaveSetting("x32_Help", "Settings", "Size", Me.Width & ", " & Me.Height)

        'Get manual directory
        Dim directoryPath As String

        If Command.Length > 0 Then 'Passed as argument
            directoryPath = Command()
        ElseIf System.IO.Directory.Exists(Application.StartupPath & "\LCARS x32 Manual") Then 'Default directory
            directoryPath = Application.StartupPath & "\LCARS x32 Manual"
        Else 'Chosen by user if no other indication
            Dim myPicker As New FolderBrowserDialog
            myPicker.ShowDialog()
            directoryPath = myPicker.SelectedPath
        End If
        If Not System.IO.Directory.Exists(directoryPath) Then 'Probably bad argument
            MsgBox("Unable to find manual directory. Program will exit.")
            End
        End If
        If Not System.IO.File.Exists(directoryPath & "\Index.txt") Then 'No index file. Could make assumption and just load files.
            MsgBox("Manual index file not found. Program will exit.")
            End
        End If

        Using myReader As New System.IO.StreamReader(directoryPath & "\Index.txt")
            While myReader.Peek() >= 0
                Dim chapterData() As String = myReader.ReadLine().Split("|")
                _number_of_pages += 1
                Dim ChapterString As New LCARS.LightweightControls.LCFlatButton
                With ChapterString
                    .Text = _number_of_pages & ". " & chapterData(0)
                    .Data = directoryPath & "\" & chapterData(1)
                End With
                btgChapters.Add(ChapterString)
                AddHandler ChapterString.Click, AddressOf ChapterString_Click

            End While
        End Using
        'Start Rusoaica's code
        'Dim _directory_info As New IO.DirectoryInfo(directoryPath)
        'Dim _file_info As IO.FileInfo() = _directory_info.GetFiles("*.htm")
        'Dim _file_info_ref As IO.FileInfo
        'For Each _file_info_ref In _file_info
        '    'ReDim Preserve _chapters(_number_of_pages)
        '    '_chapters(_number_of_pages) = _file_info_ref.FullName
        '    _number_of_pages += 1
        '    Dim ChapterString As New LCARS.LightweightControls.LCFlatButton
        '    With ChapterString
        '        .Text = _number_of_pages & ". " & _file_info_ref.Name.Remove(_file_info_ref.Name.Length - _file_info_ref.Extension.Length)
        '        .Data = _file_info_ref.FullName
        '    End With
        '    btgChapters.Add(ChapterString)
        '    AddHandler ChapterString.Click, AddressOf ChapterString_Click
        'Next

        SetBeeping(GetSetting("LCARS x32", "Application", "ButtonBeep", "TRUE"), Me)
        btgChapters.Items(0).doClick()
    End Sub

    Private Sub FlatButton8_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click

        Me.Close()
        End

    End Sub

    Private Sub Elbow4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Elbow4.MouseDown

        oLoc = Windows.Forms.Cursor.Position

    End Sub

    Private Sub Elbow4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Elbow4.MouseMove

        'Drag Function
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Top += Windows.Forms.Cursor.Position.Y - oLoc.Y
            Me.Left += Windows.Forms.Cursor.Position.X - oLoc.X
            oLoc = Windows.Forms.Cursor.Position
        End If

    End Sub

    Private Sub hlpfrm_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If isInit = True Then SaveSetting("x32_Help", "Settings", "Location", Me.Left & ", " & Me.Top)

    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click

        webChapterContainer.Focus()
        SendKeys.Send("{pgup}")

    End Sub

    Private Sub FlatButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click

        webChapterContainer.Focus()
        SendKeys.Send("{pgdn}")

    End Sub

    Private Sub Elbow1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Elbow1.MouseDown
        cursory = Windows.Forms.Cursor.Position.Y
        x32hlpy = Me.Height
    End Sub

    Private Sub Elbow1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Elbow1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Height = x32hlpy + (Windows.Forms.Cursor.Position.Y - cursory)
        End If
    End Sub

    Private Sub Elbow1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Elbow1.MouseUp
        SaveSetting("x32_Help", "Settings", "Size", Me.Width & ", " & Me.Height)
    End Sub

    Private Sub btnwidth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnwidth.MouseDown
        cursorx = Windows.Forms.Cursor.Position.X
        x32hlpx = Me.Width
    End Sub

    Private Sub btnwidth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnwidth.MouseUp
        SaveSetting("x32_Help", "Settings", "Size", Me.Width & ", " & Me.Height)
    End Sub

    Private Sub btnwidth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnwidth.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Width = x32hlpx + (Windows.Forms.Cursor.Position.X - cursorx)
        End If
    End Sub

    Public Sub SetBeeping(ByVal Enabled As Boolean, ByVal searchContainer As Control)

        For Each myControl As Control In searchContainer.Controls
            If myControl.GetType.IsSubclassOf(GetType(LCARS.LCARSbuttonClass)) Then
                Try
                    CType(myControl, LCARS.LCARSbuttonClass).Beeping = Enabled
                Catch ex As Exception
                End Try
            ElseIf myControl.GetType.IsSubclassOf(GetType(LCARS.Controls.WindowlessContainer)) Then
                For i As Integer = 0 To CType(myControl, LCARS.Controls.WindowlessContainer).Count - 1
                    CType(CType(myControl, LCARS.Controls.WindowlessContainer).Items(i), LCARS.LightweightControls.LCFlatButton).Beeping = Enabled
                Next
            Else
                If myControl.Controls.Count > 0 Then
                    SetBeeping(Enabled, myControl)
                End If
            End If
        Next
    End Sub

    Private Sub ChapterString_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        webChapterContainer.Navigate(sender.data)
    End Sub

    Private Sub webChapterContainer_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles webChapterContainer.DocumentTitleChanged
        txtTitle.Text = webChapterContainer.DocumentTitle
    End Sub
End Class
