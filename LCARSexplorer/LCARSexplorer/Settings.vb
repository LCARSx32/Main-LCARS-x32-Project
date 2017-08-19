Namespace My

    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings
        Private Const settingsVersion As Integer = 1

        Public Sub TryUpgrade()
            If My.Settings.version <> 0 Then
                Return 'Already upgraded
            End If
            My.Settings.Upgrade()
            Dim i As Integer = 0
            If My.Settings.version = 0 Then
                'Add system shortcuts by default
                For Each ss As SystemShortcut In SystemShortcut.DefinedFolders
                    My.Settings.shortcutNames.Insert(i, ss.Name)
                    My.Settings.shortcuts.Insert(i, ss.SettingsName)
                    i += 1
                Next
            End If
            My.Settings.version = settingsVersion
        End Sub
    End Class
End Namespace
