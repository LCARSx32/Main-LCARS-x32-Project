Option Strict On

Module CommonScreen
    Public curBusiness As New List(Of modBusiness)

    Public WithEvents mainTimer As New Timer

    Private clockText As String = ""
    Private lineStatus As PowerLineStatus = PowerLineStatus.Unknown
    Private battPercent As Short = -1
    Private barNumber As Short = -1

    Public Sub initCommonComponents(ByVal b As modBusiness)
        initClock(b)
        initPowerStatus(b)
    End Sub

    Private Sub mainTimer_tick(ByVal sender As Object, ByVal e As EventArgs) Handles mainTimer.Tick
        updateClock()
        updatePowerStatus()
        'Update screens
        For Each myBusiness As modBusiness In curBusiness
            If myBusiness.isInit Then
                myBusiness.mainTimer_Tick(Nothing, Nothing)
            End If
        Next
    End Sub

    Private Sub initClock(ByVal b As modBusiness)
        b.myClock.Text = clockText
    End Sub

    Private Sub updateClock()
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
            clockText = newText
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    myBusiness.myClock.Text = clockText
                End If
            Next
        End If
    End Sub

    Private Sub initPowerStatus(ByVal b As modBusiness)
        b.myBattPercent.Text = battPercent & "%"
        If lineStatus = PowerLineStatus.Offline Then
            b.myPowerSource.Text = "AUXILIARY"
        Else
            b.myPowerSource.Text = "PRIMARY"
        End If
        For i As Integer = 0 To b.bars.Length - 1
            b.bars(i).Lit = i < barNumber
        Next
    End Sub

    Private Sub updatePowerStatus()
        ' SystemInformation.PowerStatus is effectively a static object. However,
        ' every time we read a property, it updates its internal values, so we
        ' should do that as little as possible
        Dim newBattPercent As Short = CShort(SystemInformation.PowerStatus.BatteryLifePercent * 100)
        Dim newLineStatus As PowerLineStatus = SystemInformation.PowerStatus.PowerLineStatus
        Dim newBarNumber As Short = CShort(Math.Ceiling(newBattPercent / 10.0F))

        If battPercent <> newBattPercent Then
            battPercent = newBattPercent
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    myBusiness.myBattPercent.Text = battPercent & "%"
                End If
            Next
        End If

        If lineStatus <> newLineStatus Then
            lineStatus = newLineStatus
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    If lineStatus = PowerLineStatus.Offline Then
                        myBusiness.myPowerSource.Text = "AUXILIARY"
                    Else
                        myBusiness.myPowerSource.Text = "PRIMARY"
                    End If
                End If
            Next
        End If

        If newBarNumber <> barNumber Then
            For Each myBusiness As modBusiness In curBusiness
                If myBusiness.isInit Then
                    For i As Integer = 0 To myBusiness.bars.Length - 1
                        myBusiness.bars(i).Lit = i < newBarNumber
                    Next
                End If
            Next
            barNumber = newBarNumber
        End If
    End Sub
End Module
