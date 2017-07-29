Imports System.IO
Imports Microsoft.Win32
Imports System.Text

Public Class frmProperties
    Inherits LCARS.LCARSForm

    Public Sub New(ByVal selectedFiles() As String)
        InitializeComponent()
        TopLevel = False
        If selectedFiles.Length = 1 Then
            Dim path As String = selectedFiles(0)
            If path.Length = 3 Then
                'it's a drive
                loadDriveProps(path)
            Else
                If Directory.Exists(path) Then
                    'its a folder
                    loadFolderProps(path)
                Else
                    'its a file
                    loadFileProps(path)
                End If
            End If
        Else
            'Multiple things have been selected.
            loadMultipleProps(selectedFiles)
        End If
    End Sub

    Private Sub loadDriveProps(ByVal path As String)
        Dim myInfo As DriveInfo = New DriveInfo(path.Substring(0, 1))

        lblDriveType.Text = myInfo.DriveType.ToString()
        If myInfo.IsReady = True Then
            Dim AvailablePercent As Double = (myInfo.AvailableFreeSpace / myInfo.TotalSize) * 100
            Dim Used As Long = myInfo.TotalSize - myInfo.TotalFreeSpace

            lblCapacity.Text = ToDriveSize(myInfo.TotalSize)
            lblUsed.Text = ToDriveSize(Used)
            lblFree.Text = ToDriveSize(myInfo.TotalFreeSpace)
            lblFS.Text = myInfo.DriveFormat
            liDrive.Color = LCARS.LCARScolorStyles.Orange
            liDrive.Value = CInt(AvailablePercent)
            lblDrive.Text = "Drive: " & myInfo.Name
        Else
            'The drive is offline.
            lblCapacity.Text = "N/A"
            lblUsed.Text = "N/A"
            lblFS.Text = "N/A"
            liDrive.Value = 0
            liDrive.Color = LCARS.LCARScolorStyles.FunctionOffline
            lblDrive.Text = "Drive: " & myInfo.Name & "(OFFLINE)"
        End If
        pnlDrive.Visible = True
    End Sub

    Private Sub loadFolderProps(ByVal path As String)
        Try
            lblFolderPathValue.Text = path
            lblFolderSizeValue.Text = ToDriveSize(DirSize(New System.IO.DirectoryInfo(path)))
            Dim createTime As DateTime = System.IO.Directory.GetCreationTime(path)
            If CBool(GetSetting("LCARS x32", "Application", "Stardate", "FALSE")) Then
                lblFolderCreatedValue.Text = LCARS.Stardate.getStardate(createTime).ToString()
            Else
                lblFolderCreatedValue.Text = createTime.ToString()
            End If
            lblContainsValue.Text = System.IO.Directory.GetDirectories(path).Length & " directories, " & System.IO.Directory.GetFiles(path).Length & " files"
        Catch ex As Exception
            lblFolderSizeValue.Text = "N/A"
            lblFolderCreatedValue.Text = "N/A"
            lblContains.Text = "N/A"
        End Try
        pnlFolder.Visible = True
    End Sub

    Private Sub loadFileProps(ByVal path As String)
        Try
            lblPathValue.Text = path
            Dim size As Long = My.Computer.FileSystem.GetFileInfo(path).Length()
            lblSizeValue.Text = ToDriveSize(size)
            If (GetSetting("LCARS x32", "Application", "Stardate", "FALSE") <> "TRUE") Then
                lblCreatedValue.Text = System.IO.File.GetCreationTime(path).ToString("g")
                lblModifiedValue.Text = System.IO.File.GetLastWriteTime(path).ToString("g")
                lblAccessedValue.Text = System.IO.File.GetLastAccessTime(path).ToString("g")
            Else
                lblCreatedValue.Text = LCARS.Stardate.getStardate(System.IO.File.GetCreationTime(path)).ToString()
                lblModifiedValue.Text = LCARS.Stardate.getStardate(System.IO.File.GetLastWriteTime(path)).ToString()
                lblAccessedValue.Text = LCARS.Stardate.getStardate(System.IO.File.GetLastAccessTime(path)).ToString()
            End If
            'finding what it opens with
            sbChangeProgram.Visible = True
            Try
                Dim strExtension As String = System.IO.Path.GetExtension(path)
                Dim myKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(strExtension)
                Dim myKeyTwo As RegistryKey = Registry.ClassesRoot.OpenSubKey(CStr(myKey.GetValue("")) & "\shell\open\command")
                lblOpensWithValue.Text = CStr(myKeyTwo.GetValue(""))
            Catch ex As Exception
                lblOpensWithValue.Text = ""
                sbChangeProgram.Visible = False
            End Try
        Catch ex As Exception
            lblSizeValue.Text = "N/A"
            lblCreatedValue.Text = "N/A"
            lblModifiedValue.Text = "N/A"
            lblAccessedValue.Text = "N/A"
            lblOpensWithValue.Text = "N/A"
            sbChangeProgram.Visible = False
        End Try
        pnlFile.Visible = True
    End Sub

    Private Sub loadMultipleProps(ByVal selectedFiles() As String)
        Dim myString As New StringBuilder()
        If selectedFiles(0).Length = 3 Then
            'We're viewing drives
            myString.Append("Number of drives: " & selectedFiles.Length & vbNewLine)
        Else
            'We have multiple files/folders
            myString.Append("Number of items: " & selectedFiles.Length & vbNewLine)
            Dim numberFiles As Integer = 0
            Dim numberFolders As Integer = 0
            Dim size As Long = 0
            For Each myFile As String In selectedFiles
                If Directory.Exists(myFile) Then
                    numberFolders += 1
                    size += DirSize(New System.IO.DirectoryInfo(myFile))
                Else
                    numberFiles += 1
                    size += My.Computer.FileSystem.GetFileInfo(myFile).Length()
                End If
            Next
            myString.Append("     Files: " & numberFiles & vbNewLine)
            myString.Append("     Folders: " & numberFolders & vbNewLine & vbNewLine)
            myString.Append("Total size: " & ToDriveSize(size))
        End If
        'Display the string
        lblMultipleOut.Text = myString.ToString()
        pnlMultiple.Visible = True
    End Sub

    Private Sub sbChangeProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbChangeProgram.Click
        MsgBox("This function is not fully working; everything displays properly, but no changes to file associations are made.")
        Dim mySelect As frmFileSelect = New frmFileSelect("C:\Program Files\", ".exe,.bat,", "Select program executable")
        mySelect.ShowDialog()
        If (mySelect.DialogResult = Windows.Forms.DialogResult.OK) Then
            Dim newProg As String = mySelect.ReturnPath
            'need to find which registry key to edit
        End If
    End Sub

    Private Sub sbCloseProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCloseProperties.Click
        Me.Close()
    End Sub
End Class