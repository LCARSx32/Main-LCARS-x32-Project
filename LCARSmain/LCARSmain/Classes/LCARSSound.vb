Imports System.Collections.Generic

Public Class LCARSSound
    Private _name As String
    Private enabled As Boolean
    Private path As String
    Private dpath As String
    Private player As System.Media.SoundPlayer

    Private Shared _resourceDict As Dictionary(Of String, System.IO.UnmanagedMemoryStream) = Nothing
    Public Shared ListeningSound As New LCARSSound("Listening for command", "ERESOURCE:computer.wav")
    Public Shared ConfirmSound As New LCARSSound("Confirm command", "ERESOURCE:Please_confirm.wav")

    Public Sub New(ByVal name As String, ByVal dpath As String)
        _name = name
        path = GetSetting("LCARS x32", "Sounds", name, dpath)
        enabled = path.StartsWith("E")
        path = path.Substring(1)
        If Not load(path) Then
            load(dpath)
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

    Public Shared ReadOnly Property ResourceDict() As Dictionary(Of String, System.IO.UnmanagedMemoryStream)
        Get
            If _resourceDict Is Nothing Then
                _resourceDict = New Dictionary(Of String, System.IO.UnmanagedMemoryStream)
                _resourceDict.Add("computer.wav", My.Resources.computer)
                _resourceDict.Add("Please_confirm.wav", My.Resources.Please_confirm)
                _resourceDict.Add("ack.wav", My.Resources.ack)
                _resourceDict.Add("095.wav", My.Resources._095)
            End If
            Return _resourceDict
        End Get
    End Property

    Public Sub Play()
        If enabled Then player.Play()
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property
End Class
