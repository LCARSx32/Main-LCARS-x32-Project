Imports LCARS.UI

Public Class frmAutoDestruct
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

    Private Sub WorkingAreaUpdated(ByVal NewArea As System.Drawing.Rectangle) Handles interop.WorkingAreaChanged
        Me.Bounds = NewArea
    End Sub

#End Region

    Dim endTime As DateTime
    Dim ShutdownOption As String
    Dim shutdownOptions As New cWrapExitWindows
    Dim alertList As List(Of String)
    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        tmrCountdown.Enabled = False
        LCARS.Alerts.DeactivateAlert(Me.Handle)
        Me.Close()

    End Sub

    Private Sub sbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbStart.Click
        If txtHours.Text = "" Then
            txtHours.Text = "00"
        End If
        If txtMinutes.Text = "" Then
            txtMinutes.Text = "00"
        End If
        If txtSeconds.Text = "" Then
            txtSeconds.Text = "00"
        End If
        If txtMilliseconds.Text = "" Then
            txtMilliseconds.Text = "00"
        End If
        If txtExternal.Text = "" And ShutdownOption.ToLower() = "external" Then
            MsgBox("No external command has been provided.")
            Exit Sub
        End If
        If sbStart.ButtonText = "START" Then
            My.Computer.Audio.Play(My.Resources._010, AudioPlayMode.Background)

            Dim myTime As TimeSpan = New TimeSpan(0, txtHours.Text, txtMinutes.Text, txtSeconds.Text, txtMilliseconds.Text)
            endTime = Now.Add(myTime)
            tmrCountdown.Enabled = True
            sbStart.ButtonText = "PAUSE"
        Else
            tmrCountdown.Enabled = False
            sbStart.ButtonText = "START"
        End If
    End Sub

    Private Sub tmrCountdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountdown.Tick
        Dim timeleft As TimeSpan = endTime.Subtract(Now)
        If timeleft > New TimeSpan(0, 0, 0, 0, 0) Then
            txtHours.Text = timeleft.Hours.ToString("00")
            txtMinutes.Text = timeleft.Minutes.ToString("00")
            txtSeconds.Text = timeleft.Seconds.ToString("00")
            txtMilliseconds.Text = timeleft.Milliseconds.ToString("00")
            If (timeleft > New TimeSpan(0, 1, 0) And timeleft < New TimeSpan(0, 0, 1, 0, 25)) Then
                My.Computer.Audio.Play(My.Resources._050, AudioPlayMode.Background)
            End If
        Else
            sbStart.ButtonText = "START"
            txtMilliseconds.Text = "00"
            tmrCountdown.Enabled = False
            Select Case ShutdownOption.ToLower
                Case "shutdown"
                    shutdownOptions.ExitWindows(cWrapExitWindows.Action.Shutdown)
                Case "logoff"
                    shutdownOptions.ExitWindows(cWrapExitWindows.Action.LogOff)
                Case "alarm"
                    Try
                        LCARS.Alerts.ActivateAlert(alertList(cbAlertType.SelectedIndex), Me.Handle)
                    Catch ex As Exception
                        LCARS.Alerts.ActivateAlert(0, Me.Handle)
                        MsgBox("Alert was not found")
                    End Try
                Case "external"
                    Try
                        Shell(txtExternal.Text, AppWinStyle.NormalFocus, False)
                    Catch ex As Exception
                        MsgBox("Error starting command")
                    End Try
            End Select
        End If
    End Sub

    Private Sub hpShutDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpShutDown.Click
        fbSelected.Top = hpShutDown.Top
        ShutdownOption = "ShutDown"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.SystemFunction
        hpExternal.Color = LCARS.LCARScolorStyles.SystemFunction
        cbAlertType.Visible = False
        txtExternal.Visible = False
    End Sub

    Private Sub frmAutoDestruct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        interop.Init()
        ShutdownOption = GetSetting("LCARS x32", "Application", "AutoDestructOption", "alarm")
        alertList = LCARS.GetAllAlertNames()
        For Each myName As String In alertList
            cbAlertType.Items.Add(myName & " Alert")
        Next
        cbAlertType.SelectedIndex = 0
        Select Case ShutdownOption.ToLower
            Case "shutdown"
                hpShutDown_Click(sender, e)
            Case "logoff"
                hpLogOff_Click(sender, e)
            Case "alarm"
                hpAlarm_Click(sender, e)
            Case "external"
                hpExternal_Click(sender, e)
        End Select
        txtExternal.Text = GetSetting("LCARS x32", "Application", "AutoDestructCommand", "")
        AddHandler txtExternal.TextChanged, AddressOf txtExternal_TextChanged
        Me.Bounds = Screen.PrimaryScreen.WorkingArea
        Application.DoEvents()

    End Sub
    Private Sub hpLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpLogOff.Click
        fbSelected.Top = hpLogOff.Top
        ShutdownOption = "LogOff"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.SystemFunction
        hpExternal.Color = LCARS.LCARScolorStyles.SystemFunction
        cbAlertType.Visible = False
        txtExternal.Visible = False
    End Sub

    Private Sub hpAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpAlarm.Click
        fbSelected.Top = hpAlarm.Top
        ShutdownOption = "Alarm"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpExternal.Color = LCARS.LCARScolorStyles.SystemFunction
        cbAlertType.Visible = True
        txtExternal.Visible = False
    End Sub

    Private Sub fbMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMode.Click
        If pnl12hr.Visible = True Then
            pnl12hr.Visible = False
            pnl24hr.Visible = True
        ElseIf pnl24hr.Visible = True Then
            pnl24hr.Visible = False
        Else
            pnl12hr.Visible = True
        End If
    End Sub

    Private Sub hpExternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpExternal.Click
        fbSelected.Top = hpExternal.Top
        ShutdownOption = "External"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.SystemFunction
        hpExternal.Color = LCARS.LCARScolorStyles.PrimaryFunction
        cbAlertType.Visible = False
        txtExternal.Visible = True
    End Sub

    Private Sub txtExternal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveSetting("LCARS x32", "Application", "AutoDestructCommand", txtExternal.Text)
    End Sub
End Class