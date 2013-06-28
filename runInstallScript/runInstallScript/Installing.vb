Public Class Installing

    Public Event ProgressChanged(ByVal CurrentProgress As Decimal)
    Public Event DisplayMessage(ByVal ComponentName As String)
    Public Event UpdateComplete()

    Dim x32Closed As Boolean = False
    Dim fileList As New Collection
    Dim runList As New Collection
    Dim extractList As New Collection
    Dim customList As New Collection
    Dim version As String
    Dim InstallThread As System.Threading.Thread
    Dim path As String = GetSetting("LCARS x32", "Application", "InstallPath", "C:\Program Files\LCARS x32")
    Dim failed As Boolean = False

    Public Structure FileEntry
        Dim name As String
        Dim version As String
        Dim custom As String
    End Structure

#Region " Window Resizing "
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer
    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public InterMsgID As Integer
    Const WM_COPYDATA As Integer = &H4A
    Dim x32Handle As IntPtr = IntPtr.Zero
    Public Const HWND_BROADCAST As Integer = &HFFFF

    Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure
#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID And m.LParam = 13 Then
            x32Closed = True
        ElseIf m.Msg = WM_COPYDATA And m.WParam = x32Handle And Not x32Handle = IntPtr.Zero Then
            Dim myData As New COPYDATASTRUCT
            myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))

            Dim myRect As New Rectangle
            myRect = System.Runtime.InteropServices.Marshal.PtrToStructure(myData.lpData, GetType(Rectangle))

            If Not Me.Bounds = myRect Then
                Me.Bounds = myRect
            End If

        Else
            MyBase.WndProc(m)

        End If

    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        ClearTempDirectory()
        Me.Close()
    End Sub

    Private Sub Installing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Code for x32 messages
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(x32Handle, InterMsgID, Me.Handle, 1)
        'Set bounds
        Me.Bounds = Screen.PrimaryScreen.WorkingArea
        'Read install script
        Dim myReader As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp & "\script.txt")
        Dim mode As String = myReader.ReadLine()
        Dim line As String = mode
        While mode <> "End Script"
            Select Case mode
                Case "Program Version"
                    version = myReader.ReadLine()
                    myReader.ReadLine()
                    mode = myReader.ReadLine()
                Case "File List"
                    line = myReader.ReadLine()
                    Do While line <> "End File List"
                        Dim myEntry As New FileEntry
                        myEntry.name = line
                        myEntry.version = myReader.ReadLine()
                        fileList.Add(myEntry)
                        line = myReader.ReadLine()
                    Loop
                    mode = myReader.ReadLine()
                Case "Run List"
                    line = myReader.ReadLine()
                    Do While line <> "End Run List"
                        Dim myEntry As New FileEntry
                        myEntry.name = line
                        myEntry.version = myReader.ReadLine()
                        runList.Add(myEntry)
                        line = myReader.ReadLine()
                    Loop
                    mode = myReader.ReadLine()
                Case "Extract List"
                    line = myReader.ReadLine()
                    Do While line <> "End Extract List"
                        Dim myEntry As New FileEntry
                        myEntry.name = line
                        myEntry.version = myReader.ReadLine()
                        extractList.Add(myEntry)
                        line = myReader.ReadLine()
                    Loop
                    mode = myReader.ReadLine()
                Case Else
                    MsgBox("Problem reading update script.")
            End Select
        End While
        myReader.Close()
    End Sub

    Private Sub sbContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbContinue.Click
        If sbContinue.Text = "CONTINUE" Then
            sbCancel.Visible = False
            sbContinue.Visible = False
            lblMessage.Text = "Waiting for all LCARS programs to close."
            Application.DoEvents()
            Dim myData As New COPYDATASTRUCT
            myData.dwData = 5 'Code to close LCARS
            Dim MyCopyData As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(COPYDATASTRUCT)))
            System.Runtime.InteropServices.Marshal.StructureToPtr(myData, MyCopyData, False)
            Dim res As Integer = SendMessage(x32Handle, WM_COPYDATA, Me.Handle, MyCopyData)
            'Message sent, now change the screen.
            pnlInstalling.Visible = True
            pnlInstalling.BringToFront()
            Me.Bounds = Screen.PrimaryScreen.Bounds
            'Initialize the update thread
            InstallThread = New System.Threading.Thread(AddressOf InstallComponents)
            'Start the thread
            InstallThread.Start()
        Else
            Process.Start(path & "\LCARSmain.exe", "-u")
            Me.Close()
        End If
    End Sub
    Private Sub InstallComponents()
        'Set up progress
        Dim localVersions As New ProgramVersions(path & "\versions.txt")
        Dim componentsInstalled As Integer = 0
        Dim section As Decimal = 1 / (fileList.Count + customList.Count + extractList.Count + runList.Count)
        'Copy files
        For Each myComponent As FileEntry In fileList
            RaiseEvent DisplayMessage("Copying " & myComponent.name)
            Try
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myComponent.name, path & "\" & myComponent.name, True)
                localVersions.UpdateVersion(myComponent.name, myComponent.version)
            Catch ex As Exception
                failed = True
                RaiseEvent DisplayMessage("Copying failed")
            End Try
            componentsInstalled += 1
            RaiseEvent ProgressChanged(componentsInstalled * section)
        Next
        'Extract files
        For Each myComponent As FileEntry In extractList
            RaiseEvent DisplayMessage("Extracting " & myComponent.name)
            'Need code to extract the zip file
            Try
                Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myComponent.name)
                    zip.ExtractAll(path, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                End Using
                localVersions.UpdateVersion(myComponent.name, myComponent.version)
            Catch ex As Exception
                failed = True
                RaiseEvent DisplayMessage("Extraction failed")
            End Try
            componentsInstalled += 1
            RaiseEvent ProgressChanged(componentsInstalled * section)
        Next
        'Run files
        For Each myComponent As FileEntry In runList
            RaiseEvent DisplayMessage("Executing " & myComponent.name)
            Try
                Shell(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myComponent.name, AppWinStyle.NormalFocus, True)
                localVersions.UpdateVersion(myComponent.name, myComponent.version)
            Catch ex As Exception
                failed = True
                RaiseEvent DisplayMessage("Execution failed")
            End Try
            componentsInstalled += 1
            RaiseEvent ProgressChanged(componentsInstalled * section)
        Next
        If Not failed Then
            localVersions.UpdateGlobalVersion(version)
            localVersions.SaveFile()
        End If
        ClearTempDirectory()
        RaiseEvent UpdateComplete()
    End Sub
    Private Sub ClearTempDirectory()
        RaiseEvent DisplayMessage("Cleaning temp folder")
        For Each myFile As FileEntry In fileList
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myFile.name)
        Next
        For Each myFile As FileEntry In customList
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myFile.name)
        Next
        For Each myFile As FileEntry In extractList
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myFile.name)
        Next
        For Each myFile As FileEntry In runList
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & myFile.name)
        Next
        My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\script.txt")
    End Sub

    Private Sub Me_UpdateComplete() Handles Me.UpdateComplete
        pnlInstalling.Visible = False
        sbContinue.Text = "Finish"
        sbContinue.Visible = True
        If Not failed Then
            lblMessage.Text = "Update complete. You are now running version " & version & vbNewLine & "Press Finish to return to LCARS."
        Else
            lblMessage.Text = "Some components failed to update. Please re-run LCARSUpdate.exe to correct this problem."
        End If
    End Sub

    Private Sub Me_ShowMessage(ByVal Message As String) Handles Me.DisplayMessage
        lstStatus.Items.Add(Message)
    End Sub

    Private Sub Me_ProgressChanged(ByVal current As Decimal) Handles Me.ProgressChanged
        Progress.Value = current
        Progress.BottomText = current.ToString("F") & "% complete"
    End Sub
End Class
