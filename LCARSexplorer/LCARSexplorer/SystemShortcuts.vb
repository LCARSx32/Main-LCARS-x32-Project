Public Class SystemShortcut
    Public Const systemPrefix As String = "SYSTEM:\"

    Private _name As String
    Private _location As String
    Private _settingsName As String

    Private Shared _defined() As SystemShortcut = Nothing

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Location() As String
        Get
            Return _location
        End Get
    End Property

    Public ReadOnly Property SettingsName() As String
        Get
            Return _settingsName
        End Get
    End Property

    Public Shared ReadOnly Property DefinedFolders() As SystemShortcut()
        Get
            If _defined Is Nothing Then
                Dim knownGood() As SystemShortcut = { _
                    New SystemShortcut("My Computer", "", "COMPUTER"), _
                    New SystemShortcut("Desktop", My.Computer.FileSystem.SpecialDirectories.Desktop, "DESKTOP"), _
                    New SystemShortcut("My Documents", My.Computer.FileSystem.SpecialDirectories.MyDocuments, "DOCUMENTS"), _
                    New SystemShortcut("My Pictures", My.Computer.FileSystem.SpecialDirectories.MyPictures, "PICTURES"), _
                    New SystemShortcut("My Music", My.Computer.FileSystem.SpecialDirectories.MyMusic, "MUSIC")}
                Dim validList As New List(Of SystemShortcut)(knownGood)
                Dim myVideosPath As String = KnownFolderPaths.GetFolderPath(KnownFolderPaths.SpecialFolders.MyVideo)
                If myVideosPath = String.Empty Then
                    myVideosPath = GetSetting("LCARS x32", "Application", "Videos", "")
                End If
                If myVideosPath <> String.Empty Then
                    validList.Add(New SystemShortcut("My Videos", myVideosPath, "VIDEOS"))
                End If
                _defined = validList.ToArray()
            End If
            Return _defined
        End Get
    End Property

    Public Shared Function FromSettingsName(ByVal SettingsName As String) As SystemShortcut
        For Each s As SystemShortcut In DefinedFolders
            If s.SettingsName = SettingsName Then
                Return s
            End If
        Next
        Return Nothing
    End Function

    Private Sub New(ByVal name As String, ByVal location As String, ByVal settingsName As String)
        _name = name
        _location = location
        _settingsName = systemPrefix & settingsName
    End Sub
End Class