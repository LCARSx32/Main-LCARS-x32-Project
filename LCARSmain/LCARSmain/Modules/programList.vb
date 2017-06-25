Option Strict On

Imports System.Runtime.InteropServices
Imports System.IO

Public Module programList

#Region " Structures "

    Public Structure LNKinfo
        Dim Executable As String
        Dim Args As String
    End Structure

    Public Class StartItem
        Implements IComparable(Of StartItem)
        Public Name As String
        Public icon As Bitmap

        Public Function CompareTo(ByVal other As StartItem) As Integer Implements System.IComparable(Of StartItem).CompareTo
            If Me.GetType() Is other.GetType() Then
                Return Me.Name.CompareTo(other.Name)
            Else
                Return If(Me.GetType() Is GetType(DirectoryStartItem), -1, 1)
            End If
        End Function
    End Class

    Public Class FileStartItem
        Inherits StartItem
        Public Link As LNKinfo
    End Class

    Public Class DirectoryStartItem
        Inherits StartItem
        Public subItems As New List(Of StartItem)
    End Class

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

    Private Const SHGFI_ICON As Integer = &H100
    Private Const SHGFI_SMALLICON As Integer = &H1
    Private Const SHGFI_LARGEICON As Integer = &H0    ' Large icon

    Public Declare Auto Function LoadLibrary Lib "kernel32" (ByVal lpLibFileName As String) As IntPtr
    Public Declare Auto Function FreeLibrary Lib "kernel32" (ByVal hLibModule As IntPtr) As Integer
    Public Declare Auto Function LoadString Lib "user32" (<[In]()> ByVal hInstance As IntPtr, _
                                                          <[In]()> ByVal uID As UInteger, _
                                                          <[In](), Out()> ByVal lpBuffer As String, _
                                                          <[In]()> ByVal nBufferMax As Integer) _
                                                          As Integer
#End Region

    Dim startItems As DirectoryStartItem
    Dim dirIcon As Bitmap = My.Resources.folder

#Region " Properties "

    Public ReadOnly Property GetAllPrograms() As DirectoryStartItem
        Get
            startItems = GetStartMenuItems()
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

    Private Function GetStartMenuItems() As DirectoryStartItem
        Dim element As DirectoryStartItem = Nothing
        Dim GlobalStartPath As String = ""
        Dim UserStartPath As String = ""
        Select Case System.Environment.OSVersion.Platform
            Case PlatformID.Win32Windows
                GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                UserStartPath = ""
            Case PlatformID.Win32NT
                Select Case (System.Environment.OSVersion.Version.Major)
                    Case 3, 4
                        GlobalStartPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                        UserStartPath = ""
                    Case Is > 4
                        Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                        myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

                        UserStartPath = myReg.GetValue("Programs").ToString()
                        element = GetPrograms(UserStartPath)

                        myReg = Microsoft.Win32.Registry.LocalMachine
                        myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)

                        GlobalStartPath = myReg.GetValue("Common Programs").ToString()
                End Select
        End Select
        Dim globalItems As DirectoryStartItem = GetPrograms(GlobalStartPath)
        If element IsNot Nothing Then
            mergeDirs(globalItems, element)
        End If
        element = globalItems
        Return element
    End Function


    Private Function GetPrograms(ByVal path As String) As DirectoryStartItem
        Dim mydir As New System.IO.DirectoryInfo(path)
        Dim myFiles() As System.IO.FileInfo = mydir.GetFiles()
        Dim myDirs() As System.IO.DirectoryInfo = mydir.GetDirectories()
        Dim curDirectory As DirectoryStartItem
        Dim curFile As FileStartItem
        Dim element As New DirectoryStartItem()
        Dim myLinkInfo As New LNKinfo()
        Const iniName As String = "desktop.ini"

        'Read subdirectories
        For intloop As Integer = 0 To myDirs.GetUpperBound(0)
            curDirectory = GetPrograms(myDirs(intloop).FullName)
            If curDirectory.Name Is Nothing Then
                curDirectory.Name = myDirs(intloop).Name
            End If
            curDirectory.icon = DirectoryIcon
            element.subItems.Add(curDirectory)
        Next

        'Check for desktop.ini
        Dim iniPath As String = mydir.FullName & IO.Path.DirectorySeparatorChar & iniName
        Dim localNames As New Dictionary(Of String, String)
        If File.Exists(iniPath) Then
            Try
                Using myReader As New IO.StreamReader(File.OpenRead(iniPath))
                    Dim line As String = ""
                    Do
                        line = myReader.ReadLine()
                        If line = "[.ShellClassInfo]" Then
                            line = myReader.ReadLine()
                            While line IsNot Nothing AndAlso line <> ""
                                If line.StartsWith("LocalizedResourceName") Then
                                    Dim index As Integer = line.IndexOf("@"c)
                                    If index <> -1 Then
                                        element.Name = loadStringResource(line.Substring(index + 1))
                                    End If
                                End If
                                line = myReader.ReadLine()
                            End While
                        ElseIf line = "[LocalizedFileNames]" Then
                            line = myReader.ReadLine()
                            While line IsNot Nothing AndAlso line <> ""
                                Dim index As Integer = line.IndexOf("=@")
                                If index <> -1 Then
                                    Dim fName As String = line.Substring(0, index)
                                    Dim lName As String = loadStringResource(line.Substring(index + 2))
                                    If lName IsNot Nothing AndAlso Not localNames.ContainsKey(fName) Then
                                        localNames.Add(fName, lName)
                                    End If
                                End If
                                line = myReader.ReadLine()
                            End While
                        End If
                    Loop Until myReader.EndOfStream
                End Using
            Catch ex As IOException
                Debug.Print("Error reading INI file: {0}", iniPath)
            Catch ex As OutOfMemoryException
                Debug.Print("Bad INI file: {0}", iniPath)
            End Try
        End If

        'Read files
        For Each myFile As FileInfo In myFiles
            If Not (myFile.Name.ToLower = iniName Or myFile.Name.ToLower = "thumbs.db") Then

                curFile = New FileStartItem()
                curFile.Name = myFile.Name
                If localNames.ContainsKey(curFile.Name) Then
                    curFile.Name = localNames.Item(curFile.Name)
                End If

                myLinkInfo.Executable = myFile.FullName
                'curFile.icon = getIcon(myLinkInfo.Executable)
                curFile.Link = myLinkInfo

                element.subItems.Add(curFile)
            End If
        Next
        element.subItems.Sort()
        Return element
    End Function

    ''' <summary>
    ''' Merges StartItems from dir2 into dir1
    ''' </summary>
    ''' <param name="dir1">StartItem to RECEIVE all items</param>
    ''' <param name="dir2">StartItem to SUPPLY items to merge</param>
    ''' <remarks>Subitems in both StartItems are assumed to be sorted</remarks>
    Private Sub mergeDirs(ByVal dir1 As programList.DirectoryStartItem, ByVal dir2 As programList.DirectoryStartItem)
        Dim dir1Loc As Integer = 0
        Dim dir2Loc As Integer = 0
        While dir1Loc < dir1.subItems.Count And dir2Loc < dir2.subItems.Count
            Dim comp As Integer = dir1.subItems(dir1Loc).CompareTo(dir2.subItems(dir2Loc))
            If comp < 0 Then
                'Element at dir1Loc comes before element at dir2Loc
                dir1Loc += 1
            ElseIf comp > 0 Then
                'Element at dir1Loc comes after element at dir2Loc
                dir1.subItems.Insert(dir1Loc, dir2.subItems(dir2Loc))
                dir1Loc += 1
                dir2Loc += 1
            Else
                If dir1.subItems(dir1Loc).GetType() Is GetType(DirectoryStartItem) Then
                    mergeDirs(CType(dir1.subItems(dir1Loc), DirectoryStartItem), _
                              CType(dir2.subItems(dir2Loc), DirectoryStartItem))
                Else
                    dir1.subItems(dir1Loc) = dir2.subItems(dir2Loc)
                End If
                dir1Loc += 1
                dir2Loc += 1
            End If
        End While
        If dir2Loc < dir2.subItems.Count Then
            For i As Integer = dir2Loc To dir2.subItems.Count - 1
                dir1.subItems.Add(dir2.subItems(i))
            Next
        End If
    End Sub

    Private Function getIcon(ByVal path As String) As Bitmap
        Dim myIcon As Bitmap
        Try
            myIcon = Drawing.Icon.ExtractAssociatedIcon(path).ToBitmap 'Icon.FromHandle(hIcon).ToBitmap
        Catch ex As Exception
            myIcon = My.Resources.folder
            Debug.Print("Failed")
        End Try

        Return myIcon
    End Function

    Private Function loadStringResource(ByVal resourceString As String) As String
        'Parse string
        Dim index As Integer = resourceString.IndexOf(","c)
        If index = -1 Then Return Nothing
        Dim libStr As String = resourceString.Substring(0, index)
        Dim resourceIndex As Integer
        If Not Integer.TryParse(resourceString.Substring(index + 1), resourceIndex) Then Return Nothing
        resourceIndex = Math.Abs(resourceIndex)
        Dim realLib As String = Environment.ExpandEnvironmentVariables(libStr)

        'Load library
        Dim hLib As IntPtr = LoadLibrary(realLib)
        If hLib = IntPtr.Zero Then Return Nothing

        'Get string
        Const bufferSize As Integer = 8192
        Dim buffer As String = Space(bufferSize)
        Dim ret As Integer = LoadString(hLib, CUInt(resourceIndex), buffer, bufferSize)

        'Free library
        If FreeLibrary(hLib) = 0 Then
            Debug.Print("Error freeing library")
        End If

        'Parse output
        If ret = 0 Then
            Return Nothing
        Else
            Return Left(buffer, ret)
        End If
    End Function

End Module
