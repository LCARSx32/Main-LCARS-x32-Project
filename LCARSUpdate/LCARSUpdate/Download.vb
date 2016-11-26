Imports LCARS.UI
<System.ComponentModel.ToolboxItem(False)> _
Friend Class Download
    Inherits LCARS.Controls.ProgressBar

    Public Event SizeAcquired(ByVal size As Long)
    Public Event StatusChanged(ByVal currentDownloaded As Long)
    Public Event DownloadComplete()
    Public Event DownloadFailed()
    Public Event UpdateFailed(ByVal sender As Object)

    Private downloadPath As String
    Private savePath As String
    Private md5 As String
    Private downloadSize As Long = 1
    Private _retryCount As Integer = 0
    Private downloadThread As System.Threading.Thread

    Private Delegate Sub SingleLongArg(ByVal status As Long)

    Public Property RetryCount() As Integer
        Get
            Return _retryCount
        End Get
        Set(ByVal value As Integer)
            _retryCount = value
        End Set
    End Property


    Public Sub New(ByVal path As String, ByVal file As String, ByVal md5Hash As String)
        downloadPath = path
        savePath = file
        md5 = md5Hash
    End Sub

    Public Sub StartDownload()
        downloadThread = New System.Threading.Thread(AddressOf DownloadSub)
        downloadThread.Start()
    End Sub
    Public Sub DownloadSub()
        Dim request As System.Net.WebRequest
        Dim response As System.Net.WebResponse = Nothing
        Dim responseStream As System.IO.Stream
        Dim length As Integer = 1024
        Dim byteArray(length) As Byte
        Try
            request = System.Net.WebRequest.Create(downloadPath)
            Dim proxy As System.Net.IWebProxy = System.Net.WebRequest.GetSystemWebProxy()
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            request.Proxy = proxy
            response = request.GetResponse()
            RaiseEvent SizeAcquired(response.ContentLength)
            responseStream = response.GetResponseStream()
            Using filestream As System.IO.FileStream = New System.IO.FileStream(savePath, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
                Dim tempBytes As Integer
                Dim totalDownloaded As Long = 0
                tempBytes = responseStream.Read(byteArray, 0, length)
                Do
                    filestream.Write(byteArray, 0, tempBytes)
                    totalDownloaded += tempBytes
                    RaiseEvent StatusChanged(totalDownloaded)
                    tempBytes = responseStream.Read(byteArray, 0, length)
                Loop While tempBytes <> 0
            End Using
            'Check with md5
            Me.BottomText = "Verifying"
            Dim hashArray As Byte()
            Dim myBuilder As New System.Text.StringBuilder
            Dim hashByte As Byte
            Dim myMD5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
            Using myStream As New System.IO.FileStream(savePath, IO.FileMode.Open, IO.FileAccess.Read)
                myMD5.ComputeHash(myStream)
            End Using
            hashArray = myMD5.Hash
            For Each hashByte In hashArray
                myBuilder.Append(String.Format("{0:X2}", hashByte))
            Next
            If md5 = myBuilder.ToString() Then
                RaiseEvent DownloadComplete()
            Else
                BottomText = "File corrupted"
                RaiseEvent DownloadFailed()
            End If

        Catch ex As Exception
            BottomText = "Failed"
            RaiseEvent DownloadFailed()
            If Not response Is Nothing Then
                response.Close()
            End If
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub Me_DownloadComplete() Handles Me.DownloadComplete
        Me.BottomText = "Completed"
        Me.Value = 1
    End Sub

    Public Sub Me_ProgressChanged(ByVal currentProgress As Long) Handles Me.StatusChanged
        If Me.InvokeRequired() Then
            Me.Invoke(New SingleLongArg(AddressOf Me_ProgressChanged), currentProgress)
        Else
            Dim percent As Decimal = currentProgress / downloadSize
            Me.Value = percent
            Me.BottomText = (percent * 100).ToString("F") & "% of " & downloadSize & " bytes."
        End If
    End Sub

    Public Sub Me_SizeAcquired(ByVal size As Long) Handles Me.SizeAcquired
        Me.downloadSize = size
    End Sub

    Public Sub Me_Failed() Handles Me.DownloadFailed
        If Me.RetryCount < CType(GetSetting("LCARSUpdate", "Config", "MaxRetry", "3"), Integer) Then
            RetryCount += 1
            Me.downloadSize = 0
            Me.Value = 0
            Me.BottomText = "Retrying"
            StartDownload()
        Else
            Dim result As MsgBoxResult = MsgBox("Maximum retry limit reached for component: " & System.IO.Path.GetFileName(savePath) & " !" & vbNewLine & "Do you wish to attempt to download again?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then
                Me.downloadSize = 0
                Me.Value = 0
                Me.BottomText = "Retrying"
                StartDownload()
            Else
                RaiseEvent UpdateFailed(Me)
            End If
        End If
    End Sub

End Class
