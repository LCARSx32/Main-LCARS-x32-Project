Imports System.Runtime.InteropServices

Public Module programList

#Region " Structures "

    Public Structure LNKinfo
        Dim Executable As String
        Dim Args As String
        Dim icon As Bitmap
    End Structure

    Public Structure FileStartItem
        Dim Name As String
        Dim Link As LNKinfo
    End Structure

    Public Structure DirectoryStartItem
        Dim Name As String
        Dim subItems As Collection
        Dim icon As Bitmap
    End Structure

#End Region

#Region " API "

    Public Declare Auto Function ExtractIcon Lib "shell32" (ByVal hInstance As IntPtr, ByVal lpszExeFileName As String, ByVal nIconIndex As Integer) As IntPtr

    Private Structure SHFILEINFO
        Public hIcon As IntPtr            ' : icon
        Public iIcon As Integer           ' : icondex
        Public dwAttributes As Integer    ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0    ' Large icon
    Private nIndex = 0
#End Region

    Dim startItems As New Collection
    Dim dirIcon As Bitmap = New Bitmap(1, 1)

#Region " Properties "

    Public ReadOnly Property GetAllPrograms() As Collection
        Get
            startItems = GetPrograms()
            Return startItems
        End Get
    End Property

    Public Property DirectoryIcon() As Bitmap
        Get
            Return dirIcon
        End Get
        Set(ByVal value As Bitmap)
            dirIcon = value
        End Set
    End Property

#End Region


    Private Function GetPrograms(Optional ByVal path As String = "") As Collection
        Dim GlobalStartPath As String = ""
        Dim UserStartPath As String = ""
        Dim mydir As System.IO.DirectoryInfo
        Dim myFiles() As System.IO.FileSystemInfo
        Dim myDirs() As System.IO.FileSystemInfo
        Dim intloop As Integer
        Dim curDirectory As New DirectoryStartItem
        Dim curFile As New FileStartItem
        Dim buffer As New Collection
        Dim myLinkInfo As New LNKinfo
        Dim mySorter As New DirectorySort

        If path = "" Then
            Dim OSinfo As String = getOS()


            Select Case OSinfo
                Case "Win98"
                    GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                    UserStartPath = ""
                Case "WinNT3.51"
                    GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                    UserStartPath = ""
                Case "WinNT4.0"
                    GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                    UserStartPath = ""
                Case "Modern"
                    Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                    myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

                    UserStartPath = myReg.GetValue("Programs")
                    buffer = GetPrograms(UserStartPath)

                    myReg = Microsoft.Win32.Registry.LocalMachine
                    myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

                    GlobalStartPath = myReg.GetValue("Common Programs")
            End Select

            Dim tmpItems As New Collection
            tmpItems = GetPrograms(GlobalStartPath)

            If UserStartPath <> "" Then

                For Each myItem As Object In tmpItems

                    If myItem.GetType Is curFile.GetType Then

                        curFile = CType(myItem, programList.FileStartItem)

                        If Not buffer.Contains(curFile.Name) Then
                            buffer.Add(curFile)
                        End If

                    ElseIf myItem.GetType Is curDirectory.GetType Then

                        curDirectory = CType(myItem, programList.DirectoryStartItem)

                        If Not buffer.Contains(curDirectory.Name) Then
                            buffer.Add(curDirectory)
                        Else

                            For intloop = 1 To buffer.Count
                                If buffer(intloop).name.tolower = curDirectory.Name.ToLower Then
                                    buffer.Add(mergeDirs(buffer(intloop), curDirectory))
                                    buffer.Remove(intloop)
                                    Exit For
                                End If
                            Next

                        End If

                    End If
                Next
            Else
                buffer = tmpItems
            End If

            mySorter.sort(buffer)

        Else
            mydir = New System.IO.DirectoryInfo(path)


            myDirs = mydir.GetDirectories

            For intloop = 0 To myDirs.GetUpperBound(0)
                curDirectory = New DirectoryStartItem
                curDirectory.Name = myDirs(intloop).Name
                curDirectory.subItems = GetPrograms(myDirs(intloop).FullName)
                curDirectory.icon = My.Resources.folder
                buffer.Add(curDirectory, curDirectory.Name)
            Next

            myFiles = mydir.GetFiles

            For intloop = 0 To myFiles.GetUpperBound(0)
                If Not (myFiles(intloop).Name.ToLower = "desktop.ini" Or myFiles(intloop).Name.ToLower = "thumbs.db") Then

                    curFile = New FileStartItem
                    curFile.Name = myFiles(intloop).Name

                    myLinkInfo.Executable = myFiles(intloop).FullName
                    ' myLinkInfo.icon = getIcon(myLinkInfo.Executable)
                    curFile.Link = myLinkInfo

                    buffer.Add(curFile, curFile.Name)
                End If
            Next
        End If
        mySorter.sort(buffer)
        Return buffer
    End Function

    Private Function mergeDirs(ByVal dir1 As programList.DirectoryStartItem, ByVal dir2 As programList.DirectoryStartItem) As programList.DirectoryStartItem
        Dim newDir As programList.DirectoryStartItem = dir1
        Dim found As Boolean = False
        Dim mySorter As New DirectorySort

        For Each myItem2 As Object In dir2.subItems
            found = False
            Dim myItem1 As Object = New Object

            For Each myItem1 In newDir.subItems

                If myItem1.name = myItem2.name Then
                    found = True
                    Exit For
                End If
            Next

            If found = False Then
                newDir.subItems.Add(myItem2)
            Else
                If myItem2.GetType Is GetType(DirectoryStartItem) Then
                    newDir.subItems.Remove(myItem1.name)
                    newDir.subItems.Add(mergeDirs(myItem1, myItem2))

                End If
            End If
        Next

        mySorter.sort(newDir.subItems)



        Return newDir
    End Function


    Public Function getOS() As String
      
            Select Case System.Environment.OSVersion.Platform
            Case PlatformID.Win32Windows
                Return "Win98"
            Case PlatformID.Win32NT
                Select Case (System.Environment.OSVersion.Version.Major)
                    Case 3
                        Return "WinNT3.51"
                    Case 4
                        Return "WinNT4.0"
                    Case Is > 4
                        Return "Modern"
                End Select
        End Select

        Return Nothing

    End Function




    'Private Function getIcon(ByVal path As String) As Bitmap
    '    Dim myIcon As Bitmap
    '    'Try
    '    '    myIcon = Drawing.Icon.ExtractAssociatedIcon(path).ToBitmap 'Icon.FromHandle(hIcon).ToBitmap
    '    'Catch ex As Exception
    '    '    myIcon = New Bitmap(1, 1)
    '    'End Try

    '    Return myIcon
    'End Function


End Module

Class DirectorySort

    Public Sub sort(ByRef dir As Collection)
        Dim intloop As Integer
        Dim buffer As Object
        Dim result As Integer
        Dim needToSort As Boolean = True


        Do Until needToSort = False
            needToSort = False
            For intloop = 1 To dir.Count - 1
                result = Compare(dir.Item(intloop), dir.Item(intloop + 1))
                If result = 0 Then
                    buffer = dir.Item(intloop + 1)
                    dir.Remove(intloop + 1)
                    dir.Add(buffer, buffer.name, intloop)
                    needToSort = True
                End If
            Next
        Loop

    End Sub


    Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer
        Dim a, b As Object
        Dim dir As New programList.DirectoryStartItem
        Dim file As New programList.FileStartItem

        a = x
        b = y
        If a.GetType Is dir.GetType And b.GetType Is file.GetType Then
            Return 1
        ElseIf a.GetType Is b.GetType Then
            'they are the same type, sort them alphabetically
            If a.name.tolower < b.name.tolower Then
                Return 1
            ElseIf a.name.tolower > b.name.Tolower Then
                Return 0
            Else
                Return 1 'they are the same.  Technically, this should NEVER happen. 
            End If

            Return 1
        ElseIf a.GetType Is file.GetType And b.GetType Is dir.GetType Then
            Return 0
        End If
        'If x. is bigger than y then x.id-y.id will be positive. 
        'And if y.id is bigger, then x.id-y.id will be negative
        'And finally if they are equal then x.id-y.id will equal zero.
    End Function
End Class