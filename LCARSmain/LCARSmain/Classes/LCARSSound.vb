Imports System.Collections.Generic

Public Class LCARSSound
    Private _name As String
    Private _enabled As Boolean
    Private _path As String
    Private _dpath As String
    Private player As System.Media.SoundPlayer

#Region " Sound Definitions "
    ' This section defines the sounds as they are actually used in code. The shared variables
    ' immediately following this comment are the sounds.
    ' 
    ' To add a new sound:
    '   * Create the sound as a Public Shared LCARSSound below, with a name and default path/resource
    '   * Add the sound to the array sounds() to allow its settings to be changed
    '   * If adding a new resource, add the resource in the property ResourceDict

    Public Shared ListeningSound As New LCARSSound("Listening for command", "ERESOURCE:computer.wav")
    Public Shared ConfirmSound As New LCARSSound("Confirm command", "ERESOURCE:Please_confirm.wav")
    Public Shared TimeoutSound As New LCARSSound("Command timed out", "ERESOURCE:computerbeep_43.wav")
    Private Shared ButtonSound As New btnBeep()

    Public Shared sounds() As LCARSSound = {ButtonSound, ListeningSound, ConfirmSound, TimeoutSound}

    Private Shared _resourceDict As Dictionary(Of String, System.IO.UnmanagedMemoryStream) = Nothing

    Public Shared ReadOnly Property ResourceDict() As Dictionary(Of String, System.IO.UnmanagedMemoryStream)
        Get
            If _resourceDict Is Nothing Then
                _resourceDict = New Dictionary(Of String, System.IO.UnmanagedMemoryStream)
                _resourceDict.Add("computer.wav", My.Resources.computer)
                _resourceDict.Add("Please_confirm.wav", My.Resources.Please_confirm)
                _resourceDict.Add("ack.wav", My.Resources.ack)
                _resourceDict.Add("095.wav", My.Resources._095)
                _resourceDict.Add("computerbeep_43.wav", My.Resources.computerbeep_43)
            End If
            Return _resourceDict
        End Get
    End Property

#End Region

    Public Sub New(ByVal name As String, ByVal dpath As String)
        _name = name
        _dpath = dpath
        Reload()
    End Sub

    Public Overridable Sub Reload()
        _path = GetSetting("LCARS x32", "Sounds", _name, _dpath)
        _enabled = _path.StartsWith("E")
        _path = _path.Substring(1)
        If Not load(_path) Then
            _path = _dpath.Substring(1)
            If Not load(_path) Then Debug.Print("Failed to load " & _path)
        End If
        player.LoadAsync()
    End Sub

    Private Function load(ByVal path As String) As Boolean
        If path.StartsWith("RESOURCE:") Then
            'Handle resource
            Dim rKey As String = path.Substring(9)
            If ResourceDict.ContainsKey(rKey) Then
                player = New System.Media.SoundPlayer(ResourceDict.Item(rKey))
                Return True
            End If
        Else
            'Handle file
            If System.IO.File.Exists(path) Then
                player = New System.Media.SoundPlayer(path)
                Return True
            End If
        End If
        Return False
    End Function

    Protected Overridable Sub save()
        'Note: While we're using "D" for disabled, any char will do, as long as it's not "E"
        SaveSetting("LCARS x32", "Sounds", _name, CStr(If(_enabled, "E", "D")) & _path)
    End Sub

    Public Sub Play()
        If _enabled Then player.Play()
    End Sub

    Public Overridable Sub Test()
        player.Play()
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public Overridable Property Path() As String
        Get
            Return _path
        End Get

        Set(ByVal value As String)
            _path = value
            If Not load(_path) Then
                _path = _dpath.Substring(1)
                Throw New IO.FileNotFoundException("Unable to load file", value)
            End If
            player.LoadAsync()
            save()
        End Set
    End Property

    Public Overridable Property Enabled() As Boolean
        Get
            Return _enabled
        End Get

        Set(ByVal value As Boolean)
            _enabled = value
            ' Don't need to reload.
            save()
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim b As New System.Text.StringBuilder
        b.Append(_name)
        b.Append(vbTab)
        If _enabled Then
            b.Append("Enabled")
        Else
            b.Append("Disabled")
        End If
        b.Append(vbTab)
        b.Append(Path)
        Return b.ToString()
    End Function

    Public Overridable ReadOnly Property CanUseResource() As Boolean
        Get
            Return True
        End Get
    End Property

    ''' <summary>
    ''' Shim class to handle button beep being stored differently
    ''' </summary>
    Private Class btnBeep
        Inherits LCARSSound

        Public Sub New()
            MyBase.New("Button beep", "")
        End Sub

        Public Overrides Sub Reload()
            _path = GetSetting("LCARS X32", "Application", "ButtonSound", "")
            _enabled = CBool(GetSetting("LCARS x32", "Application", "ButtonBeep", "True"))
        End Sub

        Protected Overrides Sub save()
            SaveSetting("LCARS X32", "Application", "ButtonSound", _path)
            SaveSetting("LCARS x32", "Application", "ButtonBeep", _enabled)
        End Sub

        Public Overrides Property Path() As String
            Get
                If _path = "" Then
                    Return "DEFAULT"
                Else
                    Return _path
                End If
            End Get
            Set(ByVal value As String)
                If value.StartsWith("RESOURCE:") Then
                    _path = "DEFAULT"
                End If
                _path = value
                save()
            End Set
        End Property

        Public Overrides ReadOnly Property CanUseResource() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Enabled() As Boolean
            Get
                Return MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)
                MyBase.Enabled = value
                SetBeeping(value)
            End Set
        End Property
    End Class
End Class