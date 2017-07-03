Option Strict On

Module CommonScreen
    Public curBusiness As New List(Of modBusiness)

    Public WithEvents mainTimer As New Timer

    Private Sub mainTimer_tick(ByVal sender As Object, ByVal e As EventArgs) Handles mainTimer.Tick
        updateClock()
        'Update screens
        For Each myBusiness As modBusiness In curBusiness
            If myBusiness.isInit Then
                myBusiness.mainTimer_Tick(Nothing, Nothing)
            End If
        Next
    End Sub

    Private Sub updateClock()
        Static clockText As String
        Dim newText As String

        'Get the time and date format
        If CBool(GetSetting("LCARS x32", "Application", "Stardate", "TRUE")) Then
            newText = LCARS.Stardate.getStardate(Now).ToString()
        Else
            Dim timeFormat As String
            Dim DateFormat As String
            Try
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Control Panel\International")
                timeFormat = CStr(myReg.GetValue("sTimeFormat", "h:mm:sstt"))
                DateFormat = CStr(myReg.GetValue("sShortDate", "M/d/yyyy"))
            Catch ex As Exception
                timeFormat = "h:mm:sstt"
                DateFormat = "M/d/yyyy"
            End Try
            newText = Format(Now, timeFormat) & " " & Format(Now.Date, DateFormat)
        End If
        If clockText <> newText Then
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    myBusiness.myClock.Text = newText
                End If
            Next
        End If
    End Sub
End Module
