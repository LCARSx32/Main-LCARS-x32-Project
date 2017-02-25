<Assembly: System.Security.Permissions.PermissionSet(Security.Permissions.SecurityAction.RequestMinimum, name:="FullTrust")> 

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Dim hasfailed As Boolean = False
        Private isSettings As Boolean = False

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Command().ToLower().Contains("--settings") Then
                'Load settings
                If Process.GetProcessesByName("LCARSmain").Length = 1 Then
                    MainForm = frmSettings
                    isSettings = True
                Else
                    'Send message current instance to load settings.
                    InterMsgID = frmStartup.RegisterWindowMessage("LCARS_X32_MSG")
                    SendMessage(HWND_BROADCAST, InterMsgID, 0, 2)
                    End
                End If
            Else
                'Run as shell
                Dim x32Processes() As Process = Process.GetProcessesByName("LCARSmain")
                If x32Processes.Length > 1 Then
                    InterMsgID = frmStartup.RegisterWindowMessage("LCARS_X32_MSG")
                    If Debugger.IsAttached Then
                        Dim other As Process = Nothing
                        For Each p As Process In x32Processes
                            If p.Id <> Process.GetCurrentProcess().Id Then
                                other = p
                                Exit For
                            End If
                        Next
                        If other Is Nothing Then
                            MsgBox("Unable to find other process")
                        End If
                        Dim handle As IntPtr = New IntPtr(CInt(GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")))
                        While Not other.HasExited And handle <> IntPtr.Zero
                            Try
                                SendMessage(handle, WM_EXPLORER_CLOSE, IntPtr.Zero, IntPtr.Zero)
                            Catch ex As Exception
                                MsgBox(ex.ToString & vbNewLine & ex.StackTrace, Title:="Error taking control")
                            End Try
                            Threading.Thread.Sleep(1000)
                        End While
                    Else
                        'Send message to current instance to switch to shell mode
                        SendMessage(HWND_BROADCAST, InterMsgID, 0, 3)
                    End If
                End If
            End If
        End Sub
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If Not hasfailed Then
                hasfailed = True
                Try
                    Using mywriter As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop & "\LCARSError.txt", True)
                        mywriter.WriteLine(Now.ToLongDateString() & " " & Now.ToShortTimeString())
                        mywriter.WriteLine(e.Exception.ToString())
                        If Not e.Exception.InnerException Is Nothing Then
                            mywriter.WriteLine(e.Exception.InnerException.ToString())
                        End If
                        mywriter.WriteLine()
                        mywriter.WriteLine(My.Computer.Info.OSFullName)
                        mywriter.WriteLine()
                        LCARS.UI.MsgBox("An error has occured in LCARSmain.exe" & vbNewLine & "The error has been recorded in a text file on your desktop." & vbNewLine & "LCARS will now attempt to return to Windows.", _
                                         MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Critical Error")
                    End Using
                Catch ex As Exception
                    LCARS.UI.MsgBox("An error has occured in LCARSmain.exe" & vbNewLine & "The error could not be recorded." & vbNewLine & _
                                     "LCARS x32 will now attempt to return you to Windows.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Critical Error")
                End Try
                Try
                    e.ExitApplication = False
                    modSpeech.ExecuteCommand("deactivate")
                Catch ex As Exception
                    LCARS.UI.MsgBox("LCARS x32 could not close successfully. Please restart your computer.", MsgBoxStyle.Critical, "Critical Error")
                    End
                End Try
            Else
                LCARS.UI.MsgBox("LCARS x32 could not close successfully. Please restart your computer.", MsgBoxStyle.Critical, "Critical Error")
                End
            End If
        End Sub

        Public Sub SwitchToShellFromSettings()
            If isSettings Then
                Application.MainForm = frmStartup
                MainForm.Show()
            End If
        End Sub

        Public ReadOnly Property IsSettingsMode() As Boolean
            Get
                Return isSettings
            End Get
        End Property
    End Class

End Namespace

