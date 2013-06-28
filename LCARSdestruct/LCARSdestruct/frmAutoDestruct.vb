Public Class frmAutoDestruct
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

    Dim endTime As TimeSpan
    Dim ShutdownOption As String
    Dim shutdownOptions As New cWrapExitWindows

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID And m.LParam = 13 Then
            Me.Close()
            End

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

        If sbStart.ButtonText = "START" Then
            My.Computer.Audio.Play(My.Resources._010, AudioPlayMode.Background)

            Dim myTime As TimeSpan = New TimeSpan(0, txtHours.Text, txtMinutes.Text, txtSeconds.Text, txtMilliseconds.Text)
            endTime = Now.TimeOfDay.Add(myTime)
            tmrCountdown.Enabled = True
            sbStart.ButtonText = "PAUSE"
        Else
            tmrCountdown.Enabled = False
            sbStart.ButtonText = "START"
        End If
    End Sub

    Private Sub tmrCountdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountdown.Tick
        Dim timeleft As TimeSpan = endTime.Subtract(Now.TimeOfDay)
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
                    shutDownOptions.ExitWindows(cWrapExitWindows.Action.Shutdown)
                Case "logoff"
                    shutDownOptions.ExitWindows(cWrapExitWindows.Action.LogOff)
                Case "alarm"
                    LCARS.Alerts.ActivateAlert("Red", Me.Handle)
            End Select
        End If
    End Sub

    Private Sub tmrWA_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWA.Tick
        'If Not Me.Bounds = Screen.PrimaryScreen.WorkingArea Then
        '    Me.Bounds = Screen.PrimaryScreen.WorkingArea
        'End If
    End Sub

    Private Sub hpShutDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpShutDown.Click
        fbSelected.Top = hpShutDown.Top
        ShutdownOption = "ShutDown"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.SystemFunction
    End Sub

    Private Sub frmAutoDestruct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(x32Handle, InterMsgID, Me.Handle, 1)

        ShutdownOption = GetSetting("LCARS x32", "Application", "AutoDestructOption", "alarm")

        Select Case ShutdownOption.ToLower
            Case "shutdown"
                hpShutDown_Click(sender, e)
            Case "logoff"
                hpLogOff_Click(sender, e)
            Case "alarm"
                hpAlarm_Click(sender, e)
        End Select

        Me.Bounds = Screen.PrimaryScreen.WorkingArea
        Application.DoEvents()

        Dim beeping As Boolean = Boolean.Parse(GetSetting("LCARS x32", "Application", "ButtonBeep", "FALSE"))

        setBeeping(Me, beeping)

    End Sub
    Private Sub setBeeping(ByVal baseControl As Control, ByVal beep As Boolean)
        For Each myControl As Control In baseControl.Controls
            If myControl.GetType.ToString.ToLower.Substring(0, 5) = "lcars" Then
                CType(myControl, LCARS.LCARSbuttonClass).Beeping = beep
            ElseIf myControl.Controls.Count > 1 Then
                setBeeping(myControl, beep)

            End If
        Next
    End Sub

    Private Sub hpLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpLogOff.Click
        fbSelected.Top = hpLogOff.Top
        ShutdownOption = "LogOff"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.PrimaryFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.SystemFunction
    End Sub

    Private Sub hpAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hpAlarm.Click
        fbSelected.Top = hpAlarm.Top
        ShutdownOption = "Alarm"
        SaveSetting("LCARS x32", "Application", "AutoDestructOption", ShutdownOption)
        hpShutDown.Color = LCARS.LCARScolorStyles.SystemFunction
        hpLogOff.Color = LCARS.LCARScolorStyles.SystemFunction
        hpAlarm.Color = LCARS.LCARScolorStyles.PrimaryFunction
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

    Private Sub pnl24hr_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl24hr.Paint

    End Sub
End Class