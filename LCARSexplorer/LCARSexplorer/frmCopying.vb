Imports System.IO

Public Class frmCopying
    Dim copyThread As New System.Threading.Thread(AddressOf CopySub)
    Dim paths() As String
    Dim destination As String
    Dim copyAction As FileActions
    Private Event statusChanged(ByVal progress As Decimal, ByVal topText As String, ByVal bottomText As String, ByVal status As String)
    Public Event TaskCompleted As EventHandler
    Delegate Sub setText(ByVal text As String)
    Dim start As DateTime

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

    Public Sub New(ByVal sourcePaths() As String, ByVal fileDestination As String, Optional ByVal action As FileActions = FileActions.Copy)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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

    Private Sub Me_StatusChanged(ByVal progress As Decimal, ByVal topText As String, ByVal bottomText As String, ByVal status As String) Handles Me.statusChanged
        prgCopying.TopText = topText
        prgCopying.BottomText = bottomText
        prgCopying.Value = progress
        lblStatus.Text = status
    End Sub

    Private Sub CopySub()
        Dim totalSize As Long = 0
        Dim copiedSize As Long = 0
        Dim totalItems As Long = 0
        Dim copiedItems As Long = 0
        Dim overwriteAction As OverWriteActions = OverWriteActions.Undecided
        Dim mergeAction As MergeOptions = MergeOptions.Undecided
        RaiseEvent statusChanged(0, "Initializing", "0% complete", "Estimated time remaining: Calculating" & vbNewLine & "Items Remaining: Calculating" & vbNewLine & "Data Remaining: Calculating")
        'If Path.GetDirectoryName(paths(0)) = destination Then overwriteAction = OverWriteActions.MoveAndKeepBoth
        'Find the total size and items
        For Each myPath As String In paths
            If Directory.Exists(myPath) Then
                DirInit(New System.IO.DirectoryInfo(myPath), totalSize, totalItems)
            Else
                totalSize += My.Computer.FileSystem.GetFileInfo(myPath).Length() + 1
                totalItems += 1
            End If
            RaiseEvent statusChanged(0, "Initializing", "0% complete", "Estimated time remaining: Calculating" & vbNewLine & "Items Remaining: " & totalItems - copiedItems & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(totalSize - copiedSize))
        Next
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
                    RaiseEvent statusChanged(copiedSize / totalSize, Path.GetFileName(myPath), ((copiedSize / totalSize) * 100).ToString("F2") & "% complete", "Estimated time remaining: " & toStandardTime(((totalSize - copiedSize) * (Now - start).TotalSeconds / (totalSize))) & vbNewLine & "Items Remaining: " & totalItems - copiedItems & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(totalSize - copiedSize))
                    copiedSize += New FileInfo(myPath).Length + 1
                    copiedItems += 1
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
            'begin deleting
            For Each mypath As String In paths
                If Directory.Exists(mypath) Then
                    dirDelete(New DirectoryInfo(mypath), copiedSize, copiedItems, totalSize, totalItems)
                Else
                    RaiseEvent statusChanged(copiedSize / totalSize, Path.GetFileName(mypath), ((copiedSize / totalSize) * 100).ToString("F2") & "% complete", "Estimated time remaining: " & toStandardTime((totalSize - copiedSize) * (Now - start).TotalSeconds / (totalSize)) & vbNewLine & "Items Remaining: " & totalItems - copiedItems & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(totalSize - copiedSize))
                    copiedSize += New FileInfo(mypath).Length + 1
                    copiedItems += 1
                    Try
                        System.IO.File.Delete(mypath)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        RaiseEvent statusChanged(1, "Completed", "100% complete", "Time Remaining: 0 seconds" & vbNewLine & "Items Remaining: 0" & vbNewLine & "Data Remaining: 0B")
        RaiseEvent TaskCompleted(Me, New EventArgs)
        Me.Close()
    End Sub

    Private Function DirInit(ByVal d As DirectoryInfo, ByRef size As Long, ByRef items As Long) As Long
        ' Add file sizes.
        Dim fis As FileInfo() = d.GetFiles()
        Dim fi As FileInfo
        items += 1
        For Each fi In fis
            size += fi.Length + 1
            items += 1
            Try
                RaiseEvent statusChanged(0, "Initializing", "0% complete", "Estimated time remaining: Calculating" & vbNewLine & "Items Remaining: " & items & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(size))
            Catch ex As Exception
            End Try
        Next fi
        ' Add subdirectory sizes.
        Dim dis As DirectoryInfo() = d.GetDirectories()
        Dim di As DirectoryInfo
        For Each di In dis
            DirInit(di, size, items)
        Next di
        Return size
    End Function

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
                size += f.Length + 1
                items += 1
                'MsgBox((totalSize - size) / (totalSize / (Now - start).TotalSeconds))
                RaiseEvent statusChanged(size / totalSize, f.Name, ((size / totalSize) * 100).ToString("F2") & "% complete", "Estimated time remaining: " & toStandardTime((totalSize - size) * (Now - start).TotalSeconds / (totalSize)) & vbNewLine & "Items Remaining: " & totalItems - items & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(totalSize - size))
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

    Private Sub dirDelete(ByVal d As DirectoryInfo, ByRef size As Long, ByRef items As Long, ByVal totalSize As Long, ByVal totalItems As Long)
        Dim files As FileInfo() = d.GetFiles()
        For Each f As FileInfo In files
            size += f.Length + 1
            items += 1
            RaiseEvent statusChanged(size / totalSize, f.Name, ((size / totalSize) * 100).ToString("F2") & "% complete", "Estimated time remaining: Calculating" & vbNewLine & "Items Remaining: " & totalItems - items & vbNewLine & "Data Remaining: " & frmMyComp.ToDriveSize(totalSize - size))
            File.Delete(f.FullName)
        Next
        For Each di As DirectoryInfo In d.GetDirectories()
            dirDelete(di, size, items, totalSize, totalItems)
        Next
        Directory.Delete(d.FullName)
    End Sub

    Private Function toStandardTime(ByVal totalSeconds As Decimal) As String
        Dim myTime As System.TimeSpan = System.TimeSpan.FromSeconds(totalSeconds)
        Return myTime.ToString()
    End Function

End Class