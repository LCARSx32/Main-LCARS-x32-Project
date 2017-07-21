Option Strict On

Imports System.IO
Imports System.Threading

'TODO: Combine Overwrite and Merge options enums and dialogs

#Region " Enums "
Public Enum FileActions
    Copy = 0
    Cut = 1
    Delete = 2
End Enum

Public Enum OverWriteActions
    Undecided = 0
    Overwrite = 1
    DoNotMove = 2
    MoveAndKeepBoth = 3
End Enum

Public Enum MergeOptions
    Undecided = 0
    Merge = 1
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
    Dim start As DateTime = DateTime.MinValue

    'Status variables
    Dim statusLock As New Mutex()
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
            RaiseEvent TaskCompleted(Me, EventArgs.Empty)
            Me.Close()
        End If
    End Sub

    Private Sub CopySub()
        Dim overwriteAction As OverWriteActions = OverWriteActions.Undecided
        Dim mergeAction As MergeOptions = MergeOptions.Undecided
        'If Path.GetDirectoryName(paths(0)) = destination Then overwriteAction = OverWriteActions.MoveAndKeepBoth
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
        Dim cut As Boolean = False
        Dim delete As Boolean = False
        If copyAction = FileActions.Cut Then
            cut = True
        ElseIf copyAction = FileActions.Delete Then
            delete = True
        End If
        start = Now
        If Not delete Then
            'begin copying
            For Each myPath As String In paths
                If Directory.Exists(myPath) Then
                    dirCopy(New System.IO.DirectoryInfo(myPath), destination & "\" & New DirectoryInfo(myPath).Name, cut, overwriteAction, mergeAction, copiedSize, copiedItems, totalSize, totalItems)
                Else
                    statusLock.WaitOne()
                    topText = Path.GetFileName(myPath)
                    copiedSize += New FileInfo(myPath).Length + 1
                    copiedItems += 1
                    statusLock.ReleaseMutex()
                    If File.Exists(destination & "\" & Path.GetFileName(myPath)) Then
                        Dim action As OverWriteActions = overwriteAction
                        If action = OverWriteActions.Undecided Then
                            Dim myForm As New frmOverwriteOptions(destination & Path.GetFileName(myPath))
                            myForm.ShowDialog()
                            action = myForm.action
                            If myForm.IsGlobalSetting Then
                                overwriteAction = action
                            End If
                        End If
                        Select Case action
                            Case OverWriteActions.Overwrite
                                Try
                                    System.IO.File.Copy(myPath, destination & "\" & Path.GetFileName(myPath), True)
                                Catch ex As Exception
                                End Try
                            Case OverWriteActions.MoveAndKeepBoth
                                Try
                                    System.IO.File.Copy(myPath, destination & "\" & Path.GetFileNameWithoutExtension(myPath) & " - 2" & Path.GetExtension(myPath))
                                Catch ex As Exception
                                End Try
                        End Select
                    Else
                        Try
                            System.IO.File.Copy(myPath, destination & "\" & Path.GetFileName(myPath))
                            If cut Then
                                System.IO.File.Delete(myPath)
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                End If
            Next
        Else
            DeleteItems(infos)
        End If
        statusLock.WaitOne()
        topText = "Completed"
        statusLock.ReleaseMutex()
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
                totalItems += DirectCast(info, FileInfo).Length + 1
                statusLock.ReleaseMutex()
            End If
        Next
    End Sub

    Private Sub dirCopy(ByVal d As DirectoryInfo, ByVal workingDir As String, ByVal delete As Boolean, ByRef conflictAction As OverWriteActions, ByRef mergeAction As MergeOptions, ByRef size As Long, ByRef items As Long, ByVal totalSize As Long, ByVal totalItems As Long)
        Dim LocAction As MergeOptions = mergeAction
        Dim copy As Boolean = True
        Dim directoryList As DirectoryInfo() = d.GetDirectories()
        Dim Filelist As FileInfo() = d.GetFiles()
        If Directory.Exists(workingDir) Then
            If LocAction = MergeOptions.Undecided Then
                Dim myForm As New frmMergeOptions(workingDir)
                myForm.ShowDialog()
                LocAction = myForm.action
                If myForm.IsGlobalSetting Then
                    mergeAction = LocAction
                End If
            End If
            If LocAction = MergeOptions.MoveAndKeepBoth Then
                Dim i As Integer = 2
                Do Until Not Directory.Exists(workingDir & " - " & i)
                    i += 1
                Loop
                workingDir = workingDir & " - " & i
            End If
            If LocAction = MergeOptions.DoNotMove Then copy = False
        Else
            Directory.CreateDirectory(workingDir)
        End If
        If copy Then
            Dim files As FileInfo() = Filelist
            For Each f As FileInfo In files
                statusLock.WaitOne()
                size += f.Length + 1
                items += 1
                topText = f.Name
                statusLock.ReleaseMutex()
                'copy file
                If File.Exists(workingDir & "\" & Path.GetFileName(f.FullName)) Then
                    Dim action As OverWriteActions = conflictAction
                    If action = OverWriteActions.Undecided Then
                        Dim myForm As New frmOverwriteOptions(workingDir & Path.GetFileName(f.FullName))
                        myForm.ShowDialog()
                        action = myForm.action
                        If myForm.IsGlobalSetting Then
                            conflictAction = action
                        End If
                    End If
                    Select Case action
                        Case OverWriteActions.Overwrite
                            Try
                                If delete Then
                                    System.IO.File.Move(f.FullName, workingDir & "\" & Path.GetFileName(f.FullName))
                                Else
                                    System.IO.File.Copy(f.FullName, workingDir & "\" & Path.GetFileName(f.FullName), True)
                                End If
                            Catch ex As Exception
                            End Try
                        Case OverWriteActions.MoveAndKeepBoth
                            Try
                                If delete Then
                                    System.IO.File.Move(f.FullName, workingDir & "\" & Path.GetFileNameWithoutExtension(f.FullName) & " - 2" & Path.GetExtension(f.FullName))
                                Else
                                    System.IO.File.Copy(f.FullName, workingDir & "\" & Path.GetFileNameWithoutExtension(f.FullName) & " - 2" & Path.GetExtension(f.FullName))
                                End If
                            Catch ex As Exception
                            End Try
                    End Select
                Else
                    Try
                        If delete Then
                            System.IO.File.Move(f.FullName, workingDir & "\" & Path.GetFileName(f.FullName))
                        Else
                            System.IO.File.Copy(f.FullName, workingDir & "\" & Path.GetFileName(f.FullName))
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        For Each di As DirectoryInfo In directoryList
            dirCopy(di, workingDir & "\" & di.Name, delete, conflictAction, mergeAction, size, items, totalSize, totalItems)
        Next
        If copy Then
            If delete Then
                Directory.Delete(d.FullName)
            End If
        End If
    End Sub

    Private Sub DeleteItems(ByVal items() As FileSystemInfo)
        For Each item As FileSystemInfo In items
            Dim size As Long = 1
            If item.GetType() Is GetType(DirectoryInfo) Then
                DeleteItems(DirectCast(item, DirectoryInfo).GetFileSystemInfos())
            Else
                size += DirectCast(item, FileInfo).Length
            End If
            statusLock.WaitOne()
            topText = item.Name
            statusLock.ReleaseMutex()
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