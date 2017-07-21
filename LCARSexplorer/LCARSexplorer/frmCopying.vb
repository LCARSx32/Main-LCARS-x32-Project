Option Strict On

Imports System.IO
Imports System.Threading

'TODO: Use better signaling than thread abort
'TODO: Verify correctness of copying
'TODO: Verify correctness of time estimate
'TODO: Handle access problems better

#Region " Enums "
Public Enum FileActions
    Copy = 0
    Cut = 1
    Delete = 2
End Enum

Public Enum MergeOptions
    Undecided = 0
    Merge = 1
    Overwrite = 1
    DoNotMove = 2
    MoveAndKeepBoth = 3
End Enum
#End Region

Public Class frmCopying
    Dim copyThread As New Thread(AddressOf CopySub)
    Dim paths() As String
    Dim destination As String
    Dim copyAction As FileActions
    Public Event TaskCompleted As EventHandler
    Dim _overwriteAction As MergeOptions = MergeOptions.Undecided
    Dim _mergeAction As MergeOptions = MergeOptions.Undecided

    'Status variables
    Dim statusLock As New Mutex()
    Dim start As DateTime = DateTime.MinValue
    Dim topText As String = "Initializing"
    Dim totalSize As Long = 0
    Dim copiedSize As Long = 0
    Dim totalItems As Long = 0
    Dim copiedItems As Long = 0


    Public Sub New(ByVal sourcePaths() As String, ByVal fileDestination As String, Optional ByVal action As FileActions = FileActions.Copy)
        InitializeComponent()

        paths = sourcePaths
        destination = fileDestination
        copyAction = action
        Select Case copyAction
            Case FileActions.Copy
                lblPaths.Text = "Copying from: " & Path.GetDirectoryName(sourcePaths(0)) & " to: " & destination
            Case FileActions.Cut
                lblPaths.Text = "Moving from: " & Path.GetDirectoryName(sourcePaths(0)) & " to: " & destination
                tbTitle.ButtonText = "Moving files"
            Case FileActions.Delete
                lblPaths.Text = "Deleting from: " & Path.GetDirectoryName(sourcePaths(0))
                tbTitle.Text = "Deleting files"
        End Select
        Me.Text = lblPaths.Text
        copyThread.Start()
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        copyThread.Abort()
        Me.Close()
    End Sub

    Private Sub tmrUIUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUIUpdate.Tick
        statusLock.WaitOne()
        prgCopying.TopText = topText
        Dim progress As Double = copiedSize / totalSize
        prgCopying.BottomText = String.Format("{0:F2}% complete", progress * 100)
        prgCopying.Value = CDec(progress)
        If start = DateTime.MinValue Then
            lblStatus.Text = String.Format("Estimated time remaining: Calculating" & vbNewLine & _
                                           "Items remaining: {0}" & vbNewLine & _
                                           "Data remaining: {1}", _
                                           totalItems, _
                                           ToDriveSize(totalSize))
        Else
            Dim timeEst As Double
            If progress = 1 Then
                timeEst = 0
            Else
                timeEst = (totalSize - copiedSize) * (Now - start).TotalSeconds / (totalSize)
            End If
            lblStatus.Text = String.Format("Estimated time remaining: {0}" & vbNewLine & _
                                           "Items remaining: {1}" & vbNewLine & _
                                           "Data remaining: {2}", _
                                           TimeSpan.FromSeconds(timeEst), _
                                           totalItems - copiedItems, _
                                           ToDriveSize(totalSize - copiedSize))
        End If
        statusLock.ReleaseMutex()
    End Sub

    Private Sub OnTaskComplete()
        If Me.InvokeRequired Then
            Me.Invoke(New Threading.ThreadStart(AddressOf OnTaskComplete))
        Else
            topText = "Completed"
            RaiseEvent TaskCompleted(Me, EventArgs.Empty)
            Me.Close()
        End If
    End Sub

    Private Sub CopySub()
        'Translate paths into FileSystemInfo's to simplify handling
        Dim infos(paths.Length - 1) As FileSystemInfo
        For i As Integer = 0 To paths.Length - 1
            If (File.GetAttributes(paths(i)) And FileAttributes.Directory) = FileAttributes.Directory Then
                infos(i) = New DirectoryInfo(paths(i))
            Else
                infos(i) = New FileInfo(paths(i))
            End If
        Next
        'Find the total size and items
        ReadSizes(infos)
        statusLock.WaitOne()
        start = Now
        statusLock.ReleaseMutex()
        Select Case copyAction
            Case FileActions.Copy
                'Automatically create duplicate if same path
                If Path.GetDirectoryName(paths(0)) = destination Then
                    _overwriteAction = MergeOptions.MoveAndKeepBoth
                    _mergeAction = MergeOptions.MoveAndKeepBoth
                End If
                CopyItems(infos, destination, False)
            Case FileActions.Cut
                If Path.GetDirectoryName(paths(0)) = destination Then
                    MsgBox("Files are already in place.")
                Else
                    CopyItems(infos, destination, True)
                End If
            Case FileActions.Delete
                DeleteItems(infos)
        End Select
        OnTaskComplete()
    End Sub

    Private Sub ReadSizes(ByVal infos() As FileSystemInfo)
        For Each info As FileSystemInfo In infos
            If info.GetType() Is GetType(DirectoryInfo) Then
                statusLock.WaitOne()
                totalItems += 1
                totalSize += 1 'Prevent divide by zero errors. Also, directories take up space.
                statusLock.ReleaseMutex()
                ReadSizes(DirectCast(info, DirectoryInfo).GetFileSystemInfos)
            Else
                statusLock.WaitOne()
                totalItems += 1
                totalSize += DirectCast(info, FileInfo).Length + 1
                statusLock.ReleaseMutex()
            End If
        Next
    End Sub


    Private Sub CopyItems(ByVal items() As FileSystemInfo, ByVal workingDir As String, ByVal move As Boolean)
        For Each item As FileSystemInfo In items
            'Update status
            statusLock.WaitOne()
            topText = item.Name
            statusLock.ReleaseMutex()
            Dim size As Long = 1
            'Handle copy
            If item.GetType() Is GetType(DirectoryInfo) Then
                Dim oldDir As DirectoryInfo = DirectCast(item, DirectoryInfo)
                Dim newDirName As String = checkDirName(Path.Combine(workingDir, oldDir.Name))
                If newDirName IsNot Nothing Then
                    Try
                        Directory.CreateDirectory(newDirName, oldDir.GetAccessControl())
                        Dim newDirInfo As DirectoryInfo = New DirectoryInfo(newDirName)
                        newDirInfo.Attributes = oldDir.Attributes
                        CopyItems(oldDir.GetFileSystemInfos(), newDirName, move)
                        If move Then
                            oldDir.Delete(False)
                        End If
                    Catch ex As Exception
                        MsgBox("Problem creating directory:" & vbNewLine & _
                               newDirName & vbNewLine & _
                               "Exception message:" & vbNewLine & _
                               ex.Message)
                    End Try
                End If
            Else
                Dim oldFile As FileInfo = DirectCast(item, FileInfo)
                size += oldFile.Length
                Dim newFileName As String = checkFileName(Path.Combine(workingDir, oldFile.Name))
                If newFileName IsNot Nothing Then
                    If move Then
                        Try
                            oldFile.MoveTo(newFileName)
                        Catch ex As Exception
                            MsgBox("Problem moving file" & vbNewLine _
                                   & oldFile.Name & vbNewLine _
                                   & "Exception message:" & vbNewLine _
                                   & ex.Message)
                        End Try
                    Else
                        Try
                            oldFile.CopyTo(newFileName, True)
                            Dim newFileInfo As New FileInfo(newFileName)
                            newFileInfo.Attributes = oldFile.Attributes
                            newFileInfo.SetAccessControl(oldFile.GetAccessControl())
                        Catch ex As Exception
                            MsgBox("Problem creating file:" & vbNewLine & _
                                   newFileName & vbNewLine & _
                                   "Exception message:" & vbNewLine & _
                                   ex.Message)
                        End Try
                    End If
                End If
            End If
            statusLock.WaitOne()
            copiedItems += 1
            copiedSize += size
            statusLock.ReleaseMutex()
        Next
    End Sub

    Private ReadOnly Property MergeAction(ByVal dir As String) As MergeOptions
        Get
            If _mergeAction = MergeOptions.Undecided Then
                Dim mergeDialogue As New frmMergeOptions(dir, False)
                mergeDialogue.ShowDialog()
                If mergeDialogue.IsGlobalSetting Then
                    _mergeAction = mergeDialogue.action
                End If
                Return mergeDialogue.action
            Else
                Return _mergeAction
            End If
        End Get
    End Property

    Private ReadOnly Property OverwriteAction(ByVal file As String) As MergeOptions
        Get
            If _overwriteAction = MergeOptions.Undecided Then
                Dim mergeDialogue As New frmMergeOptions(file, True)
                mergeDialogue.ShowDialog()
                If mergeDialogue.IsGlobalSetting Then
                    _overwriteAction = mergeDialogue.action
                End If
                Return mergeDialogue.action
            Else
                Return _overwriteAction
            End If
        End Get
    End Property

    Private Function checkDirName(ByVal name As String) As String
        If Directory.Exists(name) Then
            Select Case MergeAction(name)
                Case MergeOptions.Merge
                    Return name
                Case MergeOptions.DoNotMove
                    Return Nothing
                Case MergeOptions.MoveAndKeepBoth
                    Dim i As Integer = 0
                    While Directory.Exists(String.Format("{0} ({1})", name, i))
                        i += 1
                    End While
                    Return String.Format("{0} ({1})", name, i)
                Case Else 'Should never happen
                    Return Nothing
            End Select
        Else
            Return name
        End If
    End Function

    Private Function checkFileName(ByVal name As String) As String
        If File.Exists(name) Then
            Select Case OverwriteAction(name)
                Case MergeOptions.Overwrite
                    Return name
                Case MergeOptions.DoNotMove
                    Return Nothing
                Case MergeOptions.MoveAndKeepBoth
                    Dim i As Integer = 0
                    Dim leading As String = Path.GetFileNameWithoutExtension(name)
                    Dim trailing As String = Path.GetExtension(name)
                    While File.Exists(String.Format("{0} ({1}){2}", leading, i, trailing))
                        i += 1
                    End While
                    Return String.Format("{0} ({1}){2}", leading, i, trailing)
                Case Else 'Should never happen
                    Return Nothing
            End Select
        Else
            Return name
        End If
    End Function

    Private Sub DeleteItems(ByVal items() As FileSystemInfo)
        For Each item As FileSystemInfo In items
            statusLock.WaitOne()
            topText = item.Name
            statusLock.ReleaseMutex()
            Dim size As Long = 1
            If item.GetType() Is GetType(DirectoryInfo) Then
                DeleteItems(DirectCast(item, DirectoryInfo).GetFileSystemInfos())
            Else
                size += DirectCast(item, FileInfo).Length
            End If
            Try
                item.Delete()
            Catch ex As Security.SecurityException
                MsgBox("You do not have permission to delete this item" & vbNewLine _
                       & item.FullName)
            Catch ex As IOException
                MsgBox("Unable to delete file:" & vbNewLine _
                       & item.FullName & vbNewLine _
                       & "Item is in use ")
            End Try
            statusLock.WaitOne()
            copiedItems += 1
            copiedSize += size
            statusLock.ReleaseMutex()
        Next
    End Sub
End Class