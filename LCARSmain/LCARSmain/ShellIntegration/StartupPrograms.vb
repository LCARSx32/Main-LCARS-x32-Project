Option Strict On
Imports Microsoft.Win32

Public Class StartupPrograms
    Private Sub New()
        'Prevent instantiation
    End Sub

    Private Const RunRecordString As String = "RunStuffHasBeenRun"
    Private Const StartupRecordString As String = "StartupHasBeenRun"

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
    Private Shared Function SHCreateSessionKey(ByVal samDesired As Long, <Runtime.InteropServices.Out()> ByRef phKey As Int32) As Integer
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

    Private Shared Sub processKey(ByVal key As RegistryKey, Optional ByVal delete As Boolean = False)
        Dim isSafe As Boolean = Not (SystemInformation.BootMode = BootMode.Normal)
        Dim names As String() = key.GetValueNames()
        Dim val As String
        Dim DeleteAfterRun As Boolean
        For Each myName As String In names
            If Not String.IsNullOrEmpty(myName) Then
                val = CStr(key.GetValue(myName))

                'Expand environment variables if necessary
                If key.GetValueKind(myName) = RegistryValueKind.ExpandString Then
                    val = Environment.ExpandEnvironmentVariables(val)
                End If

                'Check safe mode
                If isSafe Then
                    If val.StartsWith("*") Then
                        val = val.TrimStart("*"c)
                    Else
                        Continue For
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
            End If
        Next
    End Sub

    Private Shared Sub StartUserRun(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOCURRENTUSERRUN) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", False)
        If myKey IsNot Nothing Then
            processKey(myKey)
            myKey.Close()
        End If
    End Sub

    Private Shared Sub StartUserRunOnce(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOCURRENTUSERRUNONCE) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunOnce", True)
        If myKey IsNot Nothing Then
            processKey(myKey, True)
            myKey.Close()
        End If
    End Sub

    Private Shared Sub StartMachineRun(ByVal force As Boolean)
        If SHRestricted(RestrictionsEnum.REST_NOLOCALMACHINERUN) Or force Then
            Return
        End If
        Dim myKey As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", False)
        If myKey IsNot Nothing Then
            processKey(myKey)
            myKey.Close()
        End If
    End Sub

    Private Shared Sub ProcessFolder(ByVal folder As IO.DirectoryInfo)
        Try
            For Each f As IO.FileInfo In folder.GetFiles()
                If Not f.Name.ToLower() = "desktop.ini" Then
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
            ProcessFolder(info)
        End If
    End Sub

    Private Shared Sub StartMachineStartup(ByVal force As Boolean)
        If SystemInformation.BootMode = BootMode.Normal Then
            Dim path As String = KnownFolderPaths.GetFolderPath(KnownFolderPaths.SpecialFolders.Common_Startup)
            Dim info As New System.IO.DirectoryInfo(path)
            ProcessFolder(info)
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
    Private Const STANDARD_RIGHTS_ALL As Long = &H1F0000
    Private Const SYNCHRONIZE As Long = &H100000
    Private Const KEY_QUERY_VALUE As Long = &H1
    Private Const KEY_SET_VALUE As Long = &H1
    Private Const KEY_CREATE_SUB_KEY As Long = &H1
    Private Const KEY_ENUMERATE_SUB_KEYS As Long = &H1
    Private Const KEY_NOTIFY As Long = &H1
    Private Const KEY_CREATE_LINK As Long = &H1

    Private Const KEY_ALL_ACCESS As Long = _
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
