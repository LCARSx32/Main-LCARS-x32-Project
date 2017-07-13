Option Strict On
Imports Microsoft.Win32

Public Class StartupPrograms
    Private Sub New()
        'Prevent instantiation
    End Sub

    Private Const RunRecordString As String = "RunStuffHasBeenRun"
    Private Const StartupRecordString As String = "StartupHasBeenRun"
    Private Const RunKey As String = "Software\Microsoft\Windows\CurrentVersion\Run"
    Private Const RunKey32 As String = "Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"
    Private Const RunOnceKey As String = "Software\Microsoft\Windows\CurrentVersion\RunOnce"
    Private Const RunOnceKey32 As String = "Software\Wow6432Node\Microsoft\Windows\CurrentVersion\RunOnce"
    Private Const ApprovedBase As String = "Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\"
    Private Const ApprovedRun As String = ApprovedBase & "Run"
    Private Const ApprovedRun32 As String = ApprovedBase & "Run32"
    Private Const ApprovedStartup As String = ApprovedBase & "StartupFolder"

#Region " Windows API "
    Private Declare Auto Function SHRestricted Lib "Shell32" (ByVal restriction As RestrictionsEnum) As Boolean

    Public Enum RestrictionsEnum As Integer
        REST_NONE
        REST_NORUN
        REST_NOCLOSE
        REST_NOSAVESET
        REST_NOFILEMENU
        REST_NOSETFOLDERS
        REST_NOSETTASKBAR
        REST_NODESKTOP
        REST_NOFIND
        REST_NODRIVES
        REST_NODRIVEAUTORUN
        REST_NODRIVETYPEAUTORUN
        REST_NONETHOOD
        REST_STARTBANNER
        REST_RESTRICTRUN
        REST_NOPRINTERTABS
        REST_NOPRINTERDELETE
        REST_NOPRINTERADD
        REST_NOSTARTMENUSUBFOLDERS
        REST_MYDOCSONNET
        REST_NOEXITTODOS
        REST_ENFORCESHELLEXTSECURITY
        REST_LINKRESOLVEIGNORELINKINFO
        REST_NOCOMMONGROUPS
        REST_SEPARATEDESKTOPPROCESS
        REST_NOWEB
        REST_NOTRAYCONTEXTMENU
        REST_NOVIEWCONTEXTMENU
        REST_NONETCONNECTDISCONNECT
        REST_STARTMENULOGOFF
        REST_NOSETTINGSASSIST
        REST_NOINTERNETICON
        REST_NORECENTDOCSHISTORY
        REST_NORECENTDOCSMENU
        REST_NOACTIVEDESKTOP
        REST_NOACTIVEDESKTOPCHANGES
        REST_NOFAVORITESMENU
        REST_CLEARRECENTDOCSONEXIT
        REST_CLASSICSHELL
        REST_NOCUSTOMIZEWEBVIEW
        REST_NOHTMLWALLPAPER
        REST_NOCHANGINGWALLPAPER
        REST_NODESKCOMP
        REST_NOADDDESKCOMP
        REST_NODELDESKCOMP
        REST_NOCLOSEDESKCOMP
        REST_NOCLOSE_DRAGDROPBAND
        REST_NOMOVINGBAND
        REST_NOEDITDESKCOMP
        REST_NORESOLVESEARCH
        REST_NORESOLVETRACK
        REST_FORCECOPYACLWITHFILE
        REST_NOLOGO3CHANNELNOTIFY
        REST_NOFORGETSOFTWAREUPDATE
        REST_NOSETACTIVEDESKTOP
        REST_NOUPDATEWINDOWS
        REST_NOCHANGESTARMENU
        REST_NOFOLDEROPTIONS
        REST_HASFINDCOMPUTERS
        REST_INTELLIMENUS
        REST_RUNDLGMEMCHECKBOX
        REST_ARP_ShowPostSetup
        REST_NOCSC
        REST_NOCONTROLPANEL
        REST_ENUMWORKGROUP
        REST_ARP_NOARP
        REST_ARP_NOREMOVEPAGE
        REST_ARP_NOADDPAGE
        REST_ARP_NOWINSETUPPAGE
        REST_GREYMSIADS
        REST_NOCHANGEMAPPEDDRIVELABEL
        REST_NOCHANGEMAPPEDDRIVECOMMENT
        REST_MaxRecentDocs
        REST_NONETWORKCONNECTIONS
        REST_FORCESTARTMENULOGOFF
        REST_NOWEBVIEW
        REST_NOCUSTOMIZETHISFOLDER
        REST_NOENCRYPTION
        REST_DONTSHOWSUPERHIDDEN
        REST_NOSHELLSEARCHBUTTON
        REST_NOHARDWARETAB
        REST_NORUNASINSTALLPROMPT
        REST_PROMPTRUNASINSTALLNETPATH
        REST_NOMANAGEMYCOMPUTERVERB
        REST_NORECENTDOCSNETHOOD
        REST_DISALLOWRUN
        REST_NOWELCOMESCREEN
        REST_RESTRICTCPL
        REST_DISALLOWCPL
        REST_NOSMBALLOONTIP
        REST_NOSMHELP
        REST_NOWINKEYS
        REST_NOENCRYPTONMOVE
        REST_NOLOCALMACHINERUN
        REST_NOCURRENTUSERRUN
        REST_NOLOCALMACHINERUNONCE
        REST_NOCURRENTUSERRUNONCE
        REST_FORCEACTIVEDESKTOPON
        REST_NOCOMPUTERSNEARME
        REST_NOVIEWONDRIVE
        REST_NONETCRAWL
        REST_NOSHAREDDOCUMENTS
        REST_NOSMMYDOCS
        REST_NOSMMYPICS
        REST_ALLOWBITBUCKDRIVES
        REST_NONLEGACYSHELLMODE
        REST_NOCONTROLPANELBARRICADE
        REST_NOSTARTPAGE
        REST_NOAUTOTRAYNOTIFY
        REST_NOTASKGROUPING
        REST_NOCDBURNING
        REST_MYCOMPNOPROP
        REST_MYDOCSNOPROP
        REST_NOSTARTPANEL
        REST_NODISPLAYAPPEARANCEPAGE
        REST_NOTHEMESTAB
        REST_NOVISUALSTYLECHOICE
        REST_NOSIZECHOICE
        REST_NOCOLORCHOICE
        REST_SETVISUALSTYLE
        REST_STARTRUNNOHOMEPATH
        REST_NOUSERNAMEINSTARTPANEL
        REST_NOMYCOMPUTERICON
        REST_NOSMNETWORKPLACES
        REST_NOSMPINNEDLIST
        REST_NOSMMYMUSIC
        REST_NOSMEJECTPC
        REST_NOSMMOREPROGRAMS
        REST_NOSMMFUPROGRAMS
        REST_NOTRAYITEMSDISPLAY
        REST_NOTOOLBARSONTASKBAR
        REST_NOSMCONFIGUREPROGRAMS
        REST_HIDECLOCK
        REST_NOLOWDISKSPACECHECKS
        REST_NOENTIRENETWORK
        REST_NODESKTOPCLEANUP
        REST_BITBUCKNUKEONDELETE
        REST_BITBUCKCONFIRMDELETE
        REST_BITBUCKNOPROP
        REST_NODISPBACKGROUND
        REST_NODISPSCREENSAVEPG
        REST_NODISPSETTINGSPG
        REST_NODISPSCREENSAVEPREVIEW
        REST_NODISPLAYCPL
        REST_HIDERUNASVERB
        REST_NOTHUMBNAILCACHE
        REST_NOSTRCMPLOGICAL
        REST_NOPUBLISHWIZARD
        REST_NOONLINEPRINTSWIZARD
        REST_NOWEBSERVICES
        REST_ALLOWUNHASHEDWEBVIEW
        REST_ALLOWLEGACYWEBVIEW
        REST_REVERTWEBVIEWSECURITY
        REST_INHERITCONSOLEHANDLES
        REST_SORTMAXITEMCOUNT
        REST_NOREMOTERECURSIVEEVENTS
        REST_NOREMOTECHANGENOTIFY
        REST_NOSIMPLENETIDLIST
        REST_NOENUMENTIRENETWORK
        REST_NODETAILSTHUMBNAILONNETWORK
        REST_NOINTERNETOPENWITH
        REST_ALLOWLEGACYLMZBEHAVIOR
        REST_DONTRETRYBADNETNAME
        REST_ALLOWFILECLSIDJUNCTIONS
        REST_NOUPNPINSTALL
        REST_ARP_DONTGROUPPATCHES
        REST_ARP_NOCHOOSEPROGRAMSPAGE
        REST_NODISCONNECT
        REST_NOSECURITY
        REST_NOFILEASSOCIATE
        REST_ALLOWCOMMENTTOGGLE
        REST_USEDESKTOPINICACHE
    End Enum

    'Note: This function is imported by ORDINAL, not by name.
    <System.Runtime.InteropServices.DllImport("shell32", EntryPoint:="#723")> _
    Private Shared Function SHCreateSessionKey(ByVal samDesired As Int32, <Runtime.InteropServices.Out()> ByRef phKey As Int32) As Integer
    End Function
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal phKey As Int32) As Integer
    Private Declare Auto Function RegCreateKeyEx Lib "advapi32" (ByVal hKey As Int32, _
                                                            ByVal lpSubKey As String, _
                                                            ByVal reserved As Int32, _
                                                            ByVal lpClass As String, _
                                                            ByVal dwOptions As Int32, _
                                                            ByVal samDesired As Int32, _
                                                            ByVal lpSecurityAttributes As Integer, _
                                                            <Runtime.InteropServices.Out()> ByRef phkResult As Int32, _
                                                            <Runtime.InteropServices.Out()> ByRef lpdwDisposition As Int32) _
                                                            As Integer
#End Region

    Private Enum ApprovedRecordState As Integer
        Approved = 2
        Disabled = 3
    End Enum

    ''' <summary>
    ''' Used to read a record stored in a StartupApproved subkey
    ''' </summary>
    ''' <remarks>
    ''' As of Windows 10 build 1607, the record is 12 bytes, with the first 4 being 
    ''' some form of indicator of state, and the last 8 as a filetime. This structure
    ''' is being kept for documentation, but is not actually used to avoid exceptions
    ''' if the format changes.
    ''' </remarks>
    Private Structure ApprovedRecord
        Public Sub New(ByVal bytes() As Byte)
            If bytes.Length = 12 Then
                State = BitConverter.ToInt32(bytes, 0)
                ModifiedTime = DateTime.FromFileTime(BitConverter.ToInt64(bytes, 4))
            Else
                State = -1
            End If
        End Sub

        Public State As Integer
        Public ModifiedTime As DateTime
    End Structure

    Public Shared Sub StartAll()
        Try
            Dim runKeysRun As Boolean = checkCompletion(RunRecordString)
            If Not runKeysRun Then
                'Local machine runonce is run by Setup
                StartMachineRun(False)
                StartUserRun(False)
            End If

            If Not checkCompletion(StartupRecordString) Then
                StartMachineStartup(False)
                StartUserStartup(False)
                WriteCompletion(StartupRecordString)
            End If

            If Not runKeysRun Then
                StartUserRunOnce(False)
                WriteCompletion(RunRecordString)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Shared Sub processKey(ByVal key As RegistryKey, ByVal approvedKey As RegistryKey, Optional ByVal delete As Boolean = False)
        Dim isSafe As Boolean = Not (SystemInformation.BootMode = BootMode.Normal)
        Dim names As String() = key.GetValueNames()
        Dim val As String
        Dim DeleteAfterRun As Boolean
        Dim keyType As RegistryValueKind
        For Each myName As String In names
            If String.IsNullOrEmpty(myName) Then
                Continue For
            End If
            keyType = key.GetValueKind(myName)
            If Not (keyType = RegistryValueKind.String Or keyType = RegistryValueKind.ExpandString) Then
                Debug.Print("Bad value type for key {0}", myName)
                Continue For
            End If
            val = CStr(key.GetValue(myName))

            'Expand environment variables if necessary
            If keyType = RegistryValueKind.ExpandString Then
                val = Environment.ExpandEnvironmentVariables(val)
            End If

            'Check safe mode
            If val.StartsWith("*") Then
                val = val.TrimStart("*"c)
            Else
                If isSafe Then
                    Continue For
                End If
            End If

            'Check approval
            If approvedKey IsNot Nothing Then
                Dim approvedObj As Object = approvedKey.GetValue(myName, Nothing)
                If approvedObj IsNot Nothing Then
                    If approvedKey.GetValueKind(myName) = RegistryValueKind.Binary Then
                        Dim bytes() As Byte = CType(approvedObj, Byte())
                        If bytes(0) <> ApprovedRecordState.Approved Then
                            Continue For
                        End If
                    End If
                End If
            End If

            DeleteAfterRun = delete And val.StartsWith("!")
            If DeleteAfterRun Then val = val.TrimStart("!"c)
            If delete And Not DeleteAfterRun Then
                Try
                    key.DeleteValue(myName)
                Catch ex As ArgumentException
                    'Key already deleted?
                Catch ex As Security.SecurityException
                    Debug.Print("Unable to clear runonce key: {0}, value {1}, access denied", key.Name, myName)
                End Try
            End If

            Try
                val = val.Trim()
                Shell(val, , False)
            Catch ex As Exception
                Debug.Print("Error running program {0}", val)
            End Try

            If DeleteAfterRun Then
                Try
                    key.DeleteValue(myName)
                Catch ex As ArgumentException
                    'Key already deleted?
                Catch ex As Security.SecurityException
                    Debug.Print("Unable to clear runonce key: {0}, value {1}, access denied", key.Name, myName)
                End Try
            End If
        Next
    End Sub

    Private Shared Sub StartUserRun(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOCURRENTUSERRUN) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RunKey, False)
        Dim approvedKey As RegistryKey = Registry.CurrentUser.OpenSubKey(ApprovedRun, False)
        If myKey IsNot Nothing Then
            processKey(myKey, approvedKey)
            myKey.Close()
        End If
        If approvedKey IsNot Nothing Then
            approvedKey.Close()
        End If
        myKey = Registry.CurrentUser.OpenSubKey(RunKey32, False)
        approvedKey = Registry.CurrentUser.OpenSubKey(ApprovedRun32, False)
        If myKey IsNot Nothing Then
            processKey(myKey, myKey)
            myKey.Close()
        End If
        If approvedKey IsNot Nothing Then
            approvedKey.Close()
        End If
    End Sub

    Private Shared Sub StartUserRunOnce(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOCURRENTUSERRUNONCE) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RunOnceKey, True)
        If myKey IsNot Nothing Then
            processKey(myKey, Nothing, True)
            myKey.Close()
        End If
        myKey = Registry.CurrentUser.OpenSubKey(RunOnceKey32, True)
        If myKey IsNot Nothing Then
            processKey(myKey, Nothing, True)
            myKey.Close()
        End If
    End Sub

    Private Shared Sub StartMachineRun(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOLOCALMACHINERUN) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.LocalMachine.OpenSubKey(RunKey, False)
        Dim approvedKey As RegistryKey = Registry.LocalMachine.OpenSubKey(ApprovedRun, False)
        If myKey IsNot Nothing Then
            processKey(myKey, approvedKey)
            myKey.Close()
        End If
        If approvedKey IsNot Nothing Then
            approvedKey.Close()
        End If
        myKey = Registry.LocalMachine.OpenSubKey(RunKey32, False)
        approvedKey = Registry.LocalMachine.OpenSubKey(ApprovedRun32, False)
        If myKey IsNot Nothing Then
            processKey(myKey, approvedKey)
            myKey.Close()
        End If
        If approvedKey IsNot Nothing Then
            approvedKey.Close()
        End If
    End Sub

    Private Shared Sub ProcessFolder(ByVal folder As IO.DirectoryInfo, ByVal approvedKey As RegistryKey)
        Try
            For Each f As IO.FileInfo In folder.GetFiles()
                If Not f.Name.ToLower() = "desktop.ini" Then
                    If approvedKey IsNot Nothing Then
                        Dim approvedObj As Object = approvedKey.GetValue(f.Name, Nothing)
                        If approvedObj IsNot Nothing Then
                            If approvedKey.GetValueKind(f.Name) = RegistryValueKind.Binary Then
                                Dim bytes() As Byte = CType(approvedObj, Byte())
                                If bytes(0) <> ApprovedRecordState.Approved Then
                                    Continue For
                                End If
                            End If
                        End If
                    End If
                    Try
                        Process.Start(f.FullName)
                    Catch ex As Exception
                        Debug.Print("Exception loading startup file {0}", f.FullName)
                    End Try
                End If
            Next
        Catch ex As IO.DirectoryNotFoundException
            ' Directory doesn't exist
        End Try
    End Sub

    Private Shared Sub StartUserStartup(ByVal force As Boolean)
        If SystemInformation.BootMode = BootMode.Normal Then
            Dim path As String = KnownFolderPaths.GetFolderPath(KnownFolderPaths.SpecialFolders.Startup)
            Dim info As New System.IO.DirectoryInfo(path)
            Dim approvedKey As RegistryKey = Registry.CurrentUser.OpenSubKey(ApprovedStartup, False)
            ProcessFolder(info, approvedKey)
            If approvedKey IsNot Nothing Then
                approvedKey.Close()
            End If
        End If
    End Sub

    Private Shared Sub StartMachineStartup(ByVal force As Boolean)
        If SystemInformation.BootMode = BootMode.Normal Then
            Dim path As String = KnownFolderPaths.GetFolderPath(KnownFolderPaths.SpecialFolders.Common_Startup)
            Dim info As New System.IO.DirectoryInfo(path)
            Dim approvedKey As RegistryKey = Registry.LocalMachine.OpenSubKey(ApprovedStartup, False)
            ProcessFolder(info, approvedKey)
            If approvedKey IsNot Nothing Then
                approvedKey.Close()
            End If
        End If
    End Sub

    Private Shared Sub WriteCompletion(ByVal name As String)
        Dim phKey As Int32
        Dim res As Integer
        res = SHCreateSessionKey(KEY_ALL_ACCESS, phKey)
        If res = 0 Then
            Dim childKey As Int32
            res = RegCreateKeyEx(phKey, name, 0, Nothing, REG_OPTION_VOLITILE, KEY_ALL_ACCESS, Nothing, childKey, Nothing)
            If res = 0 Then
                RegCloseKey(childKey)
            Else
                MsgBox("Unable to create subkey " & name)
            End If
            RegCloseKey(phKey)
        Else
            MsgBox("Unable to create session key")
        End If
    End Sub

    Private Shared Function checkCompletion(ByVal name As String) As Boolean
        Dim sessionID As Integer = getSessionID()
        Dim myKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\SessionInfo\" & sessionID, RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim mychild As RegistryKey = myKey.OpenSubKey(name, False)
        If mychild Is Nothing Then
            myKey.Close()
            Return False
        Else
            mychild.Close()
            myKey.Close()
            Return True
        End If
    End Function

    Private Shared Function getSessionID() As Integer
        Return Process.GetCurrentProcess().SessionId
    End Function

#Region " REGSAM definitions "
    Private Const STANDARD_RIGHTS_ALL As Int32 = &H1F0000
    Private Const SYNCHRONIZE As Int32 = &H100000
    Private Const KEY_QUERY_VALUE As Int32 = &H1
    Private Const KEY_SET_VALUE As Int32 = &H1
    Private Const KEY_CREATE_SUB_KEY As Int32 = &H1
    Private Const KEY_ENUMERATE_SUB_KEYS As Int32 = &H1
    Private Const KEY_NOTIFY As Int32 = &H1
    Private Const KEY_CREATE_LINK As Int32 = &H1

    Private Const KEY_ALL_ACCESS As Int32 = _
    (STANDARD_RIGHTS_ALL Or _
    KEY_QUERY_VALUE Or _
    KEY_SET_VALUE Or _
    KEY_CREATE_SUB_KEY Or _
    KEY_ENUMERATE_SUB_KEYS Or _
    KEY_NOTIFY Or _
    KEY_CREATE_LINK) And _
    Not SYNCHRONIZE

    Private Const REG_OPTION_VOLITILE As Int32 = 1
#End Region
End Class
