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

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Command().ToLower().Contains("--settings") Then
                MainForm = frmSettings
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
    End Class

End Namespace

