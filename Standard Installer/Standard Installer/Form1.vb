Imports System.Runtime.InteropServices

Public Class Form1
    Dim installing As Integer = 0
    Dim installThread As New System.Threading.Thread(AddressOf installThreadSub)
    Private Event StatusChanged(ByVal message As String, ByVal Progress As Decimal)
    Private Event InstallFinished()
    Private Delegate Sub SetProgress(ByVal CurrentProgress As Decimal)
    Private Delegate Sub AddItem(ByVal NewItem As Object)
    Private Delegate Sub NoArgs()
#Region " API calls "
    <DllImport("gdi32")> _
    Public Shared Function AddFontResource(ByVal lpFileName As String) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
Shared Function WriteProfileString(ByVal lpszSection As String, ByVal lpszKeyName As String, ByVal lpszString As String) As Integer
    End Function

#End Region
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If installing = 0 Then
            Dim result As DialogResult = MsgBox("Are you sure you wish to cancel the installation?", MsgBoxStyle.YesNoCancel)
            If Not result = Windows.Forms.DialogResult.Yes Then
                e.Cancel = True
            End If
        ElseIf installing = 2 Then

        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInstallPath.Text = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\LCARS x32"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim browse As New FolderBrowserDialog()
        Dim res As Boolean = browse.ShowDialog()
        If res Then
            txtInstallPath.Text = browse.SelectedPath
        End If
    End Sub
    Private Sub installThreadSub()
        'Copy files
        RaiseEvent StatusChanged("Extracting files. This may take a few moments", 0.1)
        If Not System.IO.Directory.Exists(txtInstallPath.Text) Then
            System.IO.Directory.CreateDirectory(txtInstallPath.Text)
        End If
        Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(New System.IO.MemoryStream(My.Resources.CurrentVersion))
            zip.StatusMessageTextWriter = System.Console.Out
            'Status Messages will be sent to the console during extraction
            zip.ExtractAll(txtInstallPath.Text, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
        End Using
        'Install font
        RaiseEvent StatusChanged("Installing LCARS font.", 0.7)
        Try
            System.IO.File.Copy(txtInstallPath.Text & "\lcars.ttf", System.Environment.GetFolderPath(Environment.SpecialFolder.System) & "\..\Fonts\lcars.ttf", True)
            System.IO.File.Delete(txtInstallPath.Text & "\lcars.ttf")
            Const WM_FONTCHANGE As Integer = &H1D
            Const HWND_BROADCAST As Integer = &HFFFF
            AddFontResource(System.Environment.GetFolderPath(Environment.SpecialFolder.System) & "\..\fonts\lcars.ttf")
            SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0)
            WriteProfileString("fonts", "LCARS (TrueType)", "lcars.ttf")
        Catch ex As Exception
        End Try

        'Create shortcuts
        RaiseEvent StatusChanged("Creating Shortcuts", 0.9)
        Try
            Dim WshShell As New IWshRuntimeLibrary.WshShell
            Dim myShortCut As IWshRuntimeLibrary.WshShortcut = WshShell.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Desktop & "\LCARS x32.lnk")
            ' set the shortcut properties
            With myShortCut
                .TargetPath = txtInstallPath.Text & "\LCARSmain.exe"
                .WindowStyle = 1I
                .Description = "LCARS x32"
                .WorkingDirectory = txtInstallPath.Text
                .IconLocation = txtInstallPath.Text & "\LCARSmain.exe" & ", 0"
                .Arguments = String.Empty
                .Save()
            End With
        Catch ex As System.Exception
            MessageBox.Show("Could not create the shortcut" & Environment.NewLine & ex.ToString())
        End Try
        RaiseEvent StatusChanged("Installation complete", 1)
        RaiseEvent InstallFinished()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        pnlInstalling.Visible = True
        installThread = New Threading.Thread(AddressOf installThreadSub)
        installThread.Start()
    End Sub
    Private Sub Me_StatusChanged(ByVal message As String, ByVal CurrentProgress As Decimal) Handles Me.StatusChanged
        Try
            BeginInvoke(New SetProgress(AddressOf ChangeProgress), CurrentProgress * 100)
            BeginInvoke(New AddItem(AddressOf AddItemToListbox), message)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FinishInstall() Handles Me.InstallFinished
        If Me.InvokeRequired Then
            Me.Invoke(New NoArgs(AddressOf FinishInstall))
        Else
            Dim version As String = "ERROR"
            Try
                Using myreader As New System.IO.StreamReader(txtInstallPath.Text & "\versions.txt")
                    version = myreader.ReadLine()
                End Using
            Catch ex As Exception
            End Try
            MsgBox("LCARS x32 has finished installing." & vbNewLine & "You are now running version " & Version)
            End
        End If
    End Sub

    Private Sub ChangeProgress(ByVal CurrentProgress As Decimal)
        progress.Value = CurrentProgress
    End Sub

    Private Sub AddItemToListbox(ByVal item As String)
        lstInstalling.Items.Add(item)
    End Sub
End Class
