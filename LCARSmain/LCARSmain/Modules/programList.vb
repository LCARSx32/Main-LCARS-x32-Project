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
        Dim iniData As INIReader = Nothing
        If File.Exists(iniPath) Then
            Try
                iniData = New INIReader(iniPath)
                element.Name = iniData.getValue(".ShellClassInfo", "LocalizedResourceName")
                If element.Name IsNot Nothing Then
                    element.Name = loadStringResource(element.Name)
                End If
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
                If iniData IsNot Nothing Then
                    Dim resourcestring As String = iniData.getValue("LocalizedFileNames", curFile.Name)
                    If resourcestring IsNot Nothing Then
                        resourcestring = loadStringResource(resourcestring)
                    End If
                    If resourcestring IsNot Nothing Then
                        curFile.Name = resourcestring
                    End If
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

    ''' <summary>
    ''' Get a string resource from a description in INI format
    ''' </summary>
    ''' <param name="resourceString">Resource string</param>
    ''' <returns>Null (Nothing) on failure</returns>
    Private Function loadStringResource(ByVal resourceString As String) As String
        'Parse string
        Static resourceRegex As New System.Text.RegularExpressions.Regex("@([^,]+),-?(\d+)", System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim m As System.Text.RegularExpressions.Match = resourceRegex.Match(resourceString)
        If Not m.Success Then Return Nothing
        Dim libStr As String = m.Groups(1).Value
        Dim resourceIndex As Integer = Integer.Parse(m.Groups(2).Value)
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
