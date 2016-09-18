Imports System.Runtime.InteropServices

Public Class KnownFolderPaths

    ' This class makes use of SHGetFolderPath instead of SHGetKnownFolderPath.
    ' The reason for this is SHGetKnownFolderPath is only supported by Windows
    ' Vista and later. At the time of writing, LCARS x32 supports Windows 2000
    ' and up.

    Private Declare Unicode Function SHGetFolderPathW Lib "shell32" (ByVal hwnd As IntPtr, _
                                                             ByVal nFolder As Integer, _
                                                             ByVal hToken As Int32, _
                                                             ByVal dwFlags As Int32, _
                                                             ByVal pszPath As System.Text.StringBuilder) _
                                                            As Integer

    Private Const MAX_PATH As Integer = 260

    'See ShlObj.h in Windows SDK for further info
    Public Enum SpecialFolders As Integer
        Desktop = 0
        InternetExplorer = 1
        Programs = 2
        ControlPanel = 3
        Printers = 4
        MyDocuments = 5
        Favorites = 6
        Startup = 7
        Recent = 8
        SendTo = 9
        RecycleBin = &HA
        StartMenu = &HB
        ' 0x000C is not used
        MyMusic = &HD
        MyVideo = &HE
        DesktopDirectory = &H10
        MyComputer = &H11
        Network = &H12
        Nethood = &H13
        Fonts = &H14
        Templates = &H14
        Common_StartMenu = &H16
        Common_Programs = &H17
        Common_Startup = &H18
        Common_DesktopDirectory = &H19
        Appdata = &H1A
        Printhood = &H1B
        Local_Appdata = &H1C
        AltStartup = &H1D ' Non-localized startup
        Common_AltStartup = &H1E 'Non-localized common startup
        Common_Favorites = &H1F
        InternetCache = &H20
        Cookies = &H21
        History = &H22
        Common_Appdata = &H23
        Windows = &H24
        System = &H25
        ProgramFiles = &H26
        MyPictures = &H27
        Profile = &H28
        SystemX86 = &H29 ' RISC only
        ProgramFilesX86 = &H2A ' RISC only
        ProgramFiles_Common = &H2B
        ProgramFiles_CommonX86 = &H2C
        Common_Templates = &H2D
        Common_Documents = &H2E
        Common_Admintools = &H2F
        Admintools = &H30
        Connections = &H31
        ' 0x32 - 0x34 unassigned
        Common_Music = &H35
        Common_Pictures = &H36
        Common_Video = &H37
        Resources = &H38
        Resources_Localized = &H39
        Common_OEMLinks = &H3A
        CDBurnArea = &H3B
        ' 0x3C unused
        ComputersNearMe = &H3D
    End Enum

    Public Enum SpecialFolderOptions As Integer
        None = 0
        Create = &H8000
        NoVerify = &H4000
        NoUnexpand = &H2000
        NoAlias = &H1000
        PerUserInit = &H800
    End Enum

    Private Enum SHGFP_Flags As Int32
        CurrentLoc = 0
        DefaultLoc = 1
    End Enum

    Public Shared Function GetFolderPath(ByVal folder As SpecialFolders, Optional ByVal options As SpecialFolderOptions = SpecialFolderOptions.None) As String
        Dim path As New System.Text.StringBuilder(MAX_PATH)
        Dim res As Integer = SHGetFolderPathW(IntPtr.Zero, folder, 0, options, path)
        If res = 0 Then
            Return path.ToString()
        Else
            Return ""
        End If
    End Function
End Class

