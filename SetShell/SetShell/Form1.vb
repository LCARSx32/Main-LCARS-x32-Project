Public Class Form1
    Private Declare Function GetShortPathName Lib "kernel32" Alias "GetShortPathNameA" (ByVal LongPath As String, ByVal ShortPath As String, ByVal cchBuffer As Integer) As Integer

    Const MAX_PATH As Integer = 260
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If rbLCARS.Checked = True Then
            SetShell(Application.StartupPath & "\LCARSmain.exe -s")
            MsgBox("Shell set successfully to LCARS x32.")
            Me.Close()
        Else
            SetShell("Explorer.exe")
            MsgBox("Shell set successfully to Windows Explorer.")
            Me.Close()

        End If
    End Sub

    Private Sub SetShell(ByVal ShellPath As String)
        If System.Environment.OSVersion.Platform = PlatformID.Win32NT Then
            '2000 - Current
            Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            myReg = myReg.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Winlogon", True)
            myReg.SetValue("Shell", ShellPath)

            myReg.Close()
        ElseIf System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            'Win98, 98SE, or ME (95 falls under this category, but doens't support .NET applications.
            Dim WinDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
            Dim sysIni As String = ""
            Dim strinput As String = ""

            If WinDir.Substring(Len(WinDir) - 1, 1) = "\" Then
                WinDir = WinDir.Substring(0, Len(WinDir) - 1)
            End If

            'a "cheat" to get the next folder up (which is the windows directory).
            WinDir = System.IO.Path.GetDirectoryName(WinDir)

            FileOpen(1, WinDir & "\system.ini", OpenMode.Input)
            Do Until EOF(1)
                Input(1, strinput)
                If strinput.Length >= 4 Then
                    If strinput.Substring(0, 5).ToLower = "shell" Then
                        If ShellPath.ToLower <> "explorer.exe" Then
                            Try
                                strinput = "shell=" & ToShortPath(ShellPath)
                            Catch ex As Exception
                                MsgBox("Error forming short path. No changes have been saved")
                                strinput = "shell=explorer.exe"
                            End Try
                        Else
                            strinput = "shell=" & ShellPath
                        End If
                    End If
                End If

                sysIni += strinput & vbNewLine
            Loop
            FileClose(1)

            FileOpen(1, WinDir & "\system.ini", OpenMode.Output)
            Print(1, sysIni)
            FileClose(1)
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim command As String = System.Environment.CommandLine.ToLower
        Dim commands() As String
        Try
            command = command.Substring(InStr(command, "/") - 1)


            commands = command.Split(" ")
            For Each mycommand As String In commands
                If mycommand = "/q" Then
                    Me.WindowState = FormWindowState.Minimized
                    Me.ShowInTaskbar = False

                End If
                If InStr(mycommand, "/set") > 0 Then
                    mycommand = mycommand.Substring(5)
                    If mycommand = "lcars" Then
                        SetShell(Application.StartupPath & "\LCARSmain.exe -s")
                        Me.Close()

                    ElseIf mycommand = "explorer" Then
                        SetShell("explorer.exe")
                        Me.Close()
                    Else
                        MsgBox("Unrecognised command.")
                        Me.Close()
                    End If
                End If
            Next
        Catch
        End Try

        If Process.GetProcessesByName("explorer").Length = 0 Then
            MsgBox("explorer not running.")
        Else
            MsgBox("explorer is running.")
        End If
    End Sub

    Public Function ToShortPath(ByVal FileName As String) As String
        Dim length As Integer, result As String
        result = Space(MAX_PATH)
        length = GetShortPathName(FileName, result, Len(result))
        If length Then
            Return result.Substring(0, length)
        Else
            Throw New IO.IOException("Unable to form short path.")
        End If
    End Function
End Class
