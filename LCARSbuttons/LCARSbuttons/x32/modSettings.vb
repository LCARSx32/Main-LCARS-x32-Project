Imports System.IO


Namespace x32
    Public NotInheritable Class modSettings

        Private Sub New()
            'Private constructor to prevent initialization
        End Sub

        ''' <summary>
        ''' Options for InitializeSettings
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum SettingInitializationOptions
            All = 0
            Alerts = 1
            Update = 2
            RestoreToDefaults = 3
        End Enum
        ''' <summary>
        ''' Initializes settings, either to defaults or pragmatically
        ''' </summary>
        ''' <param name="mode">Sets mode for initialization. Can specify subsection</param>
        ''' <remarks></remarks>
        Public Shared Sub InitializeSettings(Optional ByVal mode As SettingInitializationOptions = SettingInitializationOptions.All)
            If InstallPath = "" Then
                Throw New Exception("Install path not initialized. Unable to initialize remaining settings.")
            End If
            upgradeSettings()
            If mode = SettingInitializationOptions.All Then
                SaveSetting("LCARS X32", "Application", "AutoDestructOption", GetSetting("LCARS X32", "Application", "AutoDestructOption", "Alarm"))
                SaveSetting("LCARS X32", "Application", "ButtonBeep", GetSetting("LCARS X32", "Application", "ButtonBeep", "TRUE"))
                SaveSetting("LCARS X32", "Application", "PanelCloseInterval", GetSetting("LCARS X32", "Application", "PanelCloseInterval", "50"))
                SaveSetting("LCARS X32", "Application", "PanelOpenInterval", GetSetting("LCARS X32", "Application", "PanelOpenInterval", "100"))
                SaveSetting("LCARS X32", "Application", "SpeechOn", GetSetting("LCARS X32", "Application", "SpeechOn", "True"))
                SaveSetting("LCARS X32", "Application", "Stardate", GetSetting("LCARS X32", "Application", "Stardate", "TRUE"))
                SaveSetting("LCARS X32", "Application", "ButtonSound", GetSetting("LCARS X32", "Application", "ButtonSound", InstallPath & "\207.wav"))
                SaveSetting("LCARS X32", "Application", "SpeechCode", GetSetting("LCARS X32", "Application", "SpeechCode", "409"))
                SaveSetting("LCARS X32", "Application", "RedAlertSound", GetSetting("LCARS X32", "Application", "RedAlertSound", InstallPath & "\red_alert.wav"))
                SaveSetting("LCARS X32", "Application", "Updates", GetSetting("LCARS X32", "Application", "Updates", "TRUE"))
                SaveSetting("LCARS X32", "Colors", "ColorMap", GetSetting("LCARS X32", "Colors", "ColorMap", "#3366CC,#99CCFF,#CC99CC,#FFCC00,#FFFF99,#CC6666,#FFFFFF,#FF0000,#FFCC66,Orange,#99CCFF"))
                SaveSetting("LCARS X32", "Application", "InstallPath", InstallPath)
            End If
            'Reset only update section. Included in "All"
            If mode = SettingInitializationOptions.All Or mode = SettingInitializationOptions.Update Then
                If GetSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL") = "https://googledrive.com/host/0B4oWzmqN8Sa7TDJtUnZrcFlfNjg/BetaVersion.txt" And _
                GetSetting("LCARSUpdate", "Config", "UpdatePath", "experimental") = "custom" Then
                    ' Restore to experimental
                    SaveSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL")
                    SaveSetting("LCARSUpdate", "Config", "UpdatePath", "experimental")
                End If
                SaveSetting("LCARSUpdate", "Config", "ReleaseURL", "http://www.lcarsx32.com/lcars/x32/ReleaseVersion.txt")
                SaveSetting("LCARSUpdate", "Config", "ExperimentalURL", "http://www.lcarsx32.com/lcars/x32/ExperimentalVersion.txt")
                SaveSetting("LCARSUpdate", "Config", "UpdatePath", GetSetting("LCARSUpdate", "Config", "UpdatePath", "Experimental"))
                SaveSetting("LCARSUpdate", "Config", "CustomURL", GetSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL"))
            End If
            'Reset only alert section. Included in "All"
            If mode = SettingInitializationOptions.Alerts Or mode = SettingInitializationOptions.All Or mode = SettingInitializationOptions.RestoreToDefaults Then
                'These IDs are hard coded and cannot be changed. However, changing them will have
                'interesting effects ... but usually result in crashes
                If mode = SettingInitializationOptions.RestoreToDefaults Then
                    'Will wipe any custom alerts!
                    TryDeleteSetting("LCARS x32", "Alerts")
                    SaveSetting("LCARS x32", "Alerts", "0", "Red|#FF0000|" & InstallPath & "\red_alert.wav")
                    SaveSetting("LCARS x32", "Alerts", "1", "Yellow|#FFFF00|")
                Else
                    SaveSetting("LCARS x32", "Alerts", "0", GetSetting("LCARS x32", "Alerts", "0", "Red|#FF0000|" & InstallPath & "\red_alert.wav"))
                    SaveSetting("LCARS x32", "Alerts", "1", GetSetting("LCARS x32", "Alerts", "1", "Yellow|#FFFF00|"))
                End If
            End If

            'Restore everything to defaults.
            'Will wipe ALL settings, including Personal Programs, custom commands, command aliases, and custom alerts
            If mode = SettingInitializationOptions.RestoreToDefaults Then
                TryDeleteSetting("LCARS x32")
                SaveSetting("LCARS X32", "Application", "AutoDestructOption", "Alarm")
                SaveSetting("LCARS X32", "Application", "ButtonBeep", "TRUE")
                SaveSetting("LCARS X32", "Application", "PanelCloseInterval", "50")
                SaveSetting("LCARS X32", "Application", "PanelOpenInterval", "100")
                SaveSetting("LCARS X32", "Application", "SpeechOn", "True")
                SaveSetting("LCARS X32", "Application", "Stardate", "TRUE")
                SaveSetting("LCARS X32", "Application", "ButtonSound", InstallPath & "\207.wav")
                SaveSetting("LCARS X32", "Application", "SpeechCode", "409")
                SaveSetting("LCARS X32", "Application", "RedAlertSound", InstallPath & "\red_alert.wav")
                SaveSetting("LCARS X32", "Application", "Updates", "TRUE")
                SaveSetting("LCARS X32", "Colors", "ColorMap", "#3366CC,#99CCFF,#CC99CC,#FFCC00,#FFFF99,#CC6666,#FFFFFF,#FF0000,#FFCC66,Orange,#99CCFF")
                SaveSetting("LCARSUpdate", "Config", "CustomURL", "Custom URL")
                SaveSetting("LCARS X32", "Application", "InstallPath", InstallPath)
                SaveSetting("LCARSUpdate", "Config", "ReleaseURL", "http://www.lcarsx32.com/lcars/x32/ReleaseVersion.txt")
                SaveSetting("LCARSUpdate", "Config", "ExperimentalURL", "http://www.lcarsx32.com/lcars/x32/ExperimentalVersion.txt")
                SaveSetting("LCARSUpdate", "Config", "UpdatePath", "Experimental")
            End If
        End Sub

        Private Shared Sub upgradeSettings()
            Dim ver As Version = SettingsVersion
            If ver.Major = 0 Then
                If ver.Minor = 7 Then
                    If ver.Build = 1 Then
                        'This is the first version that settings are actually tracked, so we can't
                        ' assume everything is there.
                        Dim oldButtonsFile As String = InstallPath & "\UserButtons.ini"
                        If File.Exists(oldButtonsFile) Then
                            Dim strinput As String = ""
                            Dim intCount As Integer = 0
                            FileOpen(1, oldButtonsFile, OpenMode.Input, OpenAccess.Read)
                            Do Until EOF(1)
                                Input(1, strinput)

                                If strinput <> "" Then
                                    Dim buttonName As String = strinput
                                    Input(1, strinput)
                                    SaveSetting("LCARS x32", "UserButtons", intCount.ToString("D2") & buttonName, strinput)
                                    intCount += 1
                                End If
                            Loop
                            FileClose(1)
                            Kill(oldButtonsFile)
                        End If

                        'Delete old screenshots
                        Dim ssDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LCARS x32\Images"
                        If Directory.Exists(ssDir) Then
                            Debug.Print("Found screenshot directory")
                            Dim oldFiles() As String = {"frmmainscreen1.jpg", _
                                                     "frmmainscreen2.jpg", _
                                                     "frmmainscreen3.jpg", _
                                                     "frmmainscreen4.jpg"}
                            For Each f As String In oldFiles
                                Dim filePath As String = ssDir & "\" & f
                                If File.Exists(filePath) Then
                                    Debug.Print("Found " & f)
                                    Try
                                        File.Delete(filePath)
                                    Catch ex As Exception
                                        Debug.Print("Unable to delete screenshot")
                                    End Try
                                End If
                            Next
                        End If
                        'Delete old settings
                        TryDeleteSetting("LCARS x32", "Load")
                        TryDeleteSetting("LCARS x32", "Application", "HideExplorer")
                        TryDeleteSetting("LCARS x32", "Application", "LangFile")
                        TryDeleteSetting("LCARS x32", "Application", "ShowTrayIcons")
                        TryDeleteSetting("LCARS x32", "Application", "Wallpaper")
                        TryDeleteSetting("LCARS x32", "Application", "WallpaperSizeMode")
                    End If
                End If
            End If
            SettingsVersion = New Version(0, 7, 2)
        End Sub

        Public Shared Property Wallpaper(ByVal screenIndex As Integer) As String
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "Wallpaper", "FederationLogo")
            End Get
            Set(ByVal value As String)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "Wallpaper", value)
            End Set
        End Property

        Public Shared Property WallpaperSizeMode(ByVal screenIndex As Integer) As Integer
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "WallpaperSizeMode", "2")
            End Get
            Set(ByVal value As Integer)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "WallpaperSizeMode", value)
            End Set
        End Property

        Public Shared Property MainScreen(ByVal screenIndex As Integer) As Integer
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "GUI form", "1")
            End Get
            Set(ByVal value As Integer)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "GUI form", value)
            End Set
        End Property

        Public Shared Property AutoHide(ByVal screenIndex As Integer) As Boolean
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "Autohide", "0")
            End Get
            Set(ByVal value As Boolean)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "Autohide", value)
            End Set
        End Property

        Public Shared Property ShowTrayIcons(ByVal screenIndex As Integer) As Boolean
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "ShowTrayIcons", "FALSE")
            End Get
            Set(ByVal value As Boolean)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "ShowTrayIcons", value)
            End Set
        End Property

        Public Shared Property LanguageFileName(ByVal screenIndex As Integer) As String
            Get
                Return GetSetting("LCARS x32", "Screen" & screenIndex, "LanguageFile", "Standard.lng")
            End Get
            Set(ByVal value As String)
                SaveSetting("LCARS x32", "Screen" & screenIndex, "LanguageFile", value)
            End Set
        End Property

        Public Shared Property InstallPath() As String
            Get
                Return GetSetting("LCARS x32", "Application", "InstallPath", "")
            End Get
            Set(ByVal value As String)
                SaveSetting("LCARS x32", "Application", "InstallPath", value)
            End Set
        End Property

        Public Shared Property CommandTimeout() As Double
            Get
                Return CDbl(GetSetting("LCARS x32", "Application", "CommandTimeout", "5.0"))
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 1
                SaveSetting("LCARS x32", "Application", "CommandTimeout", value.ToString())
            End Set
        End Property

        Public Shared Property CommandTimeoutEnabled() As Boolean
            Get
                Return CBool(GetSetting("LCARS x32", "Application", "CommandTimeoutEnabled", "TRUE"))
            End Get
            Set(ByVal value As Boolean)
                SaveSetting("LCARS x32", "Application", "CommandTimeoutEnabled", value)
            End Set
        End Property

        Private Shared Property SettingsVersion() As Version
            Get
                Dim v As String = GetSetting("LCARS x32", "Application", "SettingsVersion", "0.7.1")
                Dim chunks As String() = v.Split(".")
                Dim ret As Version = Nothing
                If chunks.Length = 3 Then
                    Try
                        Dim major As Integer = Integer.Parse(chunks(0))
                        Dim minor As Integer = Integer.Parse(chunks(1))
                        Dim build As Integer = Integer.Parse(chunks(2))
                        ret = New Version(major, minor, build)
                    Catch ex As Exception
                        'Invalid format, will restore to default
                    End Try
                End If
                If ret Is Nothing Then
                    SaveSetting("LCARS x32", "Application", "SettingsVersion", "0.7.1")
                    ret = New Version(0, 7, 1)
                End If
                Return ret
            End Get
            Set(ByVal value As Version)
                SaveSetting("LCARS x32", "Application", "SettingsVersion", _
                            String.Format("{0}.{1}.{2}", value.Major, value.Minor, value.Build))
            End Set
        End Property
    End Class
End Namespace