Imports LCARS.UI
Public Class frmUpdate

#Region " Window Resizing "
    Dim WithEvents interop As New LCARS.x32Interop

    Private Sub interop_BeepingChanged(ByVal Beeping As Boolean) Handles interop.BeepingChanged
        LCARS.SetBeeping(Me, Beeping)
    End Sub

    Private Sub interop_ColorsChanged() Handles interop.ColorsChanged
        LCARS.UpdateColors(Me)
    End Sub

    Private Sub interop_LCARSx32Closing() Handles interop.LCARSx32Closing
        Application.Exit()
    End Sub

#End Region

    'Files to have on server:
    '  version.txt: Contains version information for every file in LCARS. 
    '  copy of every file that needs to be updated.
    'version.txt description:
    '  Starts with one-line version designation. This is a date right now, but it can be any GUID
    '  Remainder of file is composed of unlimited number of entries formatted:
    '     [filename]
    '     [version designation]
    '     [download path]
    '     [md5 hash]
    '     [Class]
    '  We do not need an entry for every file in LCARS, only the ones that need to be updated from
    '  the initial release with auto-updates.

    Dim debugSwitch As Boolean = False
    Dim path() As String
    Dim version As String = ""
    Public updateList As New Collection
    Dim componentsLeft As Integer = 0
    Dim silent As Boolean = False


    Public Structure component
        Dim name As String
        Dim version As String
        Dim downloadPath As String
        Dim md5 As String
        Dim fileClass As String
        Dim data As String
    End Structure

    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not interop.Init() Then
            tmrResize.Enabled = True
        End If
        If GetSetting("LCARS x32", "Application", "DebugSwitch", "FALSE") Then
            rtbServer.Visible = True
        End If
        'Determine what update path we're on, and what the server is
        If GetSetting("LCARSUpdate", "Config", "UpdatePath", "release") = "release" Then
            path = GetSetting("LCARSUpdate", "Config", "ReleaseURL", "https://www.cx.com/0/filedata/getSharedFile/SNU2d6zrEeGnthICOA-R7w/QITqrazrEeGnthIFOA-R7w?download=true").Split(",")
        ElseIf GetSetting("LCARSUpdate", "Config", "UpdatePath", "release") = "experimental" Then
            path = GetSetting("LCARSUpdate", "Config", "ExperimentalURL", "https://www.cx.com/0/filedata/getSharedFile/SNU2d6zrEeGnthICOA-R7w/QITqrazrEeGnthIFOA-R7w?download=true").Split(",")
        Else
            path = GetSetting("LCARSUpdate", "Config", "CustomURL").Split(",")
        End If

        'Determine if being run automatically in "silent" mode.
        If Command() = "-s" Then
            silent = True
        End If

        'Randomize paths
        Dim i As Integer
        Dim rand As New Random()
        For i = 0 To path.Length - 1
            Dim r As Integer = rand.Next(0, path.Length)
            Dim temp As String = path(i)
            path(i) = path(r)
            path(r) = temp
        Next

        Dim checkThread As New Threading.Thread(AddressOf CheckServers)
        checkThread.Start(path)
    End Sub

    Private Sub CheckServers(ByVal path() As String)
        'Download version file and compare
        Dim found As Boolean = False
        For Each myPath As String In path
            Dim res As Boolean = CheckVersion(myPath)
            If res Then
                lblMessage.Text = "The following components must be updated. You cannot turn off your computer during the update."
                rtbServer.Text = myPath
                sbNext.Clickable = True
                sbNext.Lit = True
                found = True
                Exit For
            End If
        Next
        If Not found Then
            If Not silent Then
                MsgBox("No servers have responded. Try again in a few minutes.")
            End If
            End
        End If
    End Sub

    Private Function CheckVersion(ByVal path As String) As Boolean
        Try
            Dim localVersions As New ProgramVersions(Application.StartupPath & "\versions.txt")
            Dim host As New System.Net.WebClient
            Dim reader As System.IO.StreamReader
            Dim response As System.Net.HttpWebResponse
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(path)
            Dim proxy As System.Net.IWebProxy = System.Net.WebRequest.GetSystemWebProxy()
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            request.Proxy = proxy
            response = CType(request.GetResponse(), System.Net.HttpWebResponse)
            reader = New System.IO.StreamReader(response.GetResponseStream())
            version = reader.ReadLine()
            If localVersions.getGlobalVersion() = version Then
                If Not silent Then
                    MsgBox("LCARS x32 is up-to-date.")
                End If
                Me.Close()
                Return True
            ElseIf version = "Not ready" Then
                'I'm setting up the new files, so there probably will be a new update shortly
                Return False
            Else
                'The program is out of date
                'Code to read full version list and compare
                Do While reader.Peek() >= 0
                    'add the entry to internal memory
                    Dim myEntry As New component
                    myEntry.name = reader.ReadLine()
                    myEntry.version = reader.ReadLine()
                    myEntry.downloadPath = reader.ReadLine()
                    myEntry.md5 = reader.ReadLine()
                    myEntry.fileClass = reader.ReadLine()
                    'Compare it, and update if needed.
                    If myEntry.version <> localVersions.getVersion(myEntry.name) Then
                        updateList.Add(myEntry)
                        lstUpdates.Items.Add(myEntry.name)
                    End If
                Loop

            End If
            reader.Close()
            If Not response Is Nothing Then
                response.Close()
            End If
            Return True
        Catch ex As Exception 'If there is an error downloading, show connection error
            If Not silent Then
                Dim seeError As DialogResult = MsgBox("An error occured while updating." & vbNewLine & _
                                                      "If your computer is protected by a firewall, be sure that LCARS x32 can access the internet." & vbNewLine & _
                                                      "Do you wish to see a detailed error message?", MsgBoxStyle.YesNo)
                If seeError = Windows.Forms.DialogResult.Yes Then
                    MsgBox("Server: " & path & vbNewLine & ex.ToString())
                End If
            End If
            Return False
        End Try
    End Function

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        End 'This terminates the downloads too.
    End Sub

    Private Sub sbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbNext.Click
        'This sub should switch to the download screen and start the download threads
        'At this point, the update can still be canceled.
        'The computer can be used while the download progresses

        'switch to download screen
        sbNext.Visible = False
        pnlDownloadList.Visible = True
        pnlDownloadList.BringToFront()
        lblMessage.Text = "Downloading updates."
        Dim count As Integer = 0
        'initialize the download components
        For Each myComponent As component In updateList
            Dim progress As New Download(myComponent.downloadPath, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myComponent.name, myComponent.md5)
            progress.Width = pnlDownloadList.Width - 23
            progress.Height = 100
            'progress.Anchor = AnchorStyles.Top And AnchorStyles.Left 'And AnchorStyles.Right
            progress.Value = 0
            progress.Left = 0
            progress.Top = 105 * count
            progress.TopText = myComponent.name
            progress.BottomText = "Starting"
            pnlDownloadList.Controls.Add(progress)
            AddHandler progress.DownloadComplete, AddressOf downloadCompleted
            AddHandler progress.UpdateFailed, AddressOf updateFailed
            componentsLeft += 1
            count += 1
        Next
        'start download threads
        For Each myDownload As Download In pnlDownloadList.Controls
            myDownload.StartDownload()
        Next
        'Everything else is taken care of by the component
    End Sub

    Public Sub downloadCompleted()
        componentsLeft -= 1
        If componentsLeft = 0 Then
            sbCancel.Visible = False
            'Code to write install script and start the update installer.
            'Install script is composed of three sections
            '   Program Version: the version designation to store for the updated version
            '   File List: All files that will be copied to the root
            '       directory of the installation.
            '   Run List: .exe files that need to be run. These will not be copied. 
            '       Should be installers or anything that cannot be handled by the install script.
            '   Extract list: .zip files to be extracted to the installation root.
            '       Manual updates, ect. The .zip itself will not be copied, only extracted.
            '   Custom placement list: Anything that cannot go in the root directory.
            Dim myWriter As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Temp & "\script.txt")
            myWriter.WriteLine("Program Version")
            myWriter.WriteLine(version)
            myWriter.WriteLine("End Program Version")
            myWriter.WriteLine("File List")
            For Each myFile As component In updateList
                If myFile.fileClass = "File" Then
                    myWriter.WriteLine(myFile.name)
                    myWriter.WriteLine(myFile.version)
                End If
            Next
            myWriter.WriteLine("End File List")
            myWriter.WriteLine("Run List")
            For Each myFile As component In updateList
                If myFile.fileClass = "Run" Then
                    myWriter.WriteLine(myFile.name)
                    myWriter.WriteLine(myFile.version)
                End If
            Next
            myWriter.WriteLine("End Run List")
            myWriter.WriteLine("Extract List")
            For Each myFile As component In updateList
                If myFile.fileClass = "Extract" Then
                    myWriter.WriteLine(myFile.name)
                    myWriter.WriteLine(myFile.version)
                End If
            Next
            myWriter.WriteLine("End Extract List")
            myWriter.WriteLine("End Script")
            myWriter.Close()
            'End code for update script
            'Copy the script execution program and zip library to the temp dir
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\runInstallScript.exe", My.Computer.FileSystem.SpecialDirectories.Temp & "\runInstallScript.exe", True)
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Ionic.Zip.Reduced.dll", My.Computer.FileSystem.SpecialDirectories.Temp & "\Ionic.Zip.Reduced.dll", True)
            'Start the script execution program
            Try 'Try...Catch block needed if user cancels opening.
                Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\runInstallScript.exe")
            Catch ex As Exception
            End Try
            'Close the program
            Me.Close()
        End If
    End Sub

    Public Sub updateFailed(ByVal sender As Object)
        MsgBox("Update failed. Please retry at a later date.")
        sbCancel.doClick(sender, New EventArgs)
    End Sub

    Private Sub pnlDownloadList_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pnlDownloadList.Scroll
        For Each myDownload As Download In pnlDownloadList.Controls
            myDownload.Refresh()
        Next
    End Sub

    Private Sub tmrResize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrResize.Tick
        If Not Me.Bounds = Screen.PrimaryScreen.WorkingArea Then
            Me.Bounds = Screen.PrimaryScreen.WorkingArea
        End If
    End Sub

    Private Sub frmUpdate_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged, Me.SizeChanged
        Dim adjustedBounds As Rectangle = Screen.FromHandle(Me.Handle).WorkingArea
        adjustedBounds.Location -= Screen.FromHandle(Me.Handle).Bounds.Location
        If Not Me.MaximizedBounds = adjustedBounds Then
            Me.MaximizedBounds = adjustedBounds
        End If
    End Sub
End Class
