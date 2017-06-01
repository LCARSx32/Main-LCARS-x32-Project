'TODO: Sort out threads
'TODO: Clean up cross-thread signalling
'TODO: Options for how sounds are handled
'TODO: Fix sound muting
'TODO: Make cancel operation immediate
'TODO: Handle mode-select operations better

Imports System.Threading
Imports LCARS

Module modAlerts
    Private alertType As Integer
    Private alertColor As Color
    Private alertSound As String
    Private inAlert As Boolean = False
    Private alertThread As Thread
    Private alertSoundMode As Microsoft.VisualBasic.AudioPlayMode = AudioPlayMode.WaitToComplete
    Private flashDelay As Integer = 50 'Milliseconds
    Private _cancelAlert As Boolean = True
    Private _muteAlert As Boolean = False


    Public Sub CancelAlert()
        _cancelAlert = True
    End Sub

    Public ReadOnly Property AlertActive() As Boolean
        Get
            Return Not _cancelAlert
        End Get
    End Property

    Public Property AlertMuted() As Boolean
        Get
            Return _muteAlert
        End Get
        Set(ByVal value As Boolean)
            _muteAlert = value
        End Set
    End Property

    Public Sub GeneralAlert(ByVal type As Integer)
        If inAlert Then
            'Code for canceling, then starting new alert
            alertThread.Abort()
        End If
        CancelAlert()
        Dim alertstring As String = GetSetting("LCARS x32", "Alerts", type.ToString(), "Red|#FF0000|" & Application.StartupPath & "\red_alert.wav")
        Dim startIndex As Integer = alertstring.IndexOf("|")
        alertColor = ColorTranslator.FromHtml(alertstring.Substring(startIndex + 1, 7))
        alertSound = alertstring.Substring(startIndex + 9)
        Dim alertables As New List(Of List(Of List(Of LCARSbuttonClass)))
        For i As Integer = 0 To curBusiness.Count - 1
            alertables.Add(New List(Of List(Of LCARSbuttonClass)))
            GetAlertPanels(curBusiness(i).myForm, alertables(i))
        Next
        alertThread = New Thread(AddressOf MainAlert)
        _cancelAlert = False
        alertThread.Start(alertables)

        PostMessage(HWND_BROADCAST, InterMsgID, type, 11)
    End Sub

    Private Sub GetAlertPanels(ByVal baseControl As Control, ByRef alertables As List(Of List(Of LCARSbuttonClass)))
        Dim tag As Integer
        Dim item As LCARS.IAlertable
        'check for child controls and add them to the proper list
        For Each myControl As Control In baseControl.Controls
            item = TryCast(myControl, LCARS.LCARSbuttonClass)
            If Not item Is Nothing _
                    And Not myControl.Tag Is Nothing _
                    And myControl.Tag <> "" _
                    And Integer.TryParse(myControl.Tag, tag) = True Then
                'it has a tag and is a container, so start it alerting!
                If tag >= alertables.Count Then 'Not enough lists yet
                    For i As Integer = alertables.Count To tag
                        alertables.Add(New List(Of LCARSbuttonClass))
                    Next
                End If
                alertables(tag).Add(myControl)
            End If
            If myControl.Controls.Count > 0 Then
                GetAlertPanels(myControl, alertables)
            End If
        Next
    End Sub

    Private Sub MainAlert(ByVal alertables As List(Of List(Of List(Of LCARSbuttonClass))))
        alertSoundMode = GetSetting("LCARS x32", "Application", "AlertSoundMode", AudioPlayMode.WaitToComplete)
        inAlert = True
        Dim mySoundPath As String = alertSound
        Dim soundThread As Thread = Nothing
        Dim screenThreads(alertables.Count - 1) As Threading.Thread
        ' Set initial color
        For Each myscreen As List(Of List(Of LCARSbuttonClass)) In alertables
            For Each mytag As List(Of LCARSbuttonClass) In myscreen
                For Each myButton As LCARSbuttonClass In mytag
                    processButton(-1, myButton)
                Next
            Next
        Next
        Application.DoEvents()
        'do the alert until cancelAlert is set to true:
        Do Until _cancelAlert = True
            'Start the sound off
            If Not (mySoundPath = "") Then
                soundThread = New Threading.Thread(AddressOf AlertSoundSub)
                soundThread.Start(mySoundPath)
            End If
            'Start the flashing on each screen
            For i As Integer = 0 To alertables.Count - 1
                screenThreads(i) = New Thread(AddressOf AlertScreenSub)
                screenThreads(i).Start(alertables(i))
            Next
            'Wait for flash to end
            For Each mythread As Threading.Thread In screenThreads
                mythread.Join()
            Next
            'Wait for sound to end
            If Not mySoundPath = "" Then
                soundThread.Join()
            End If
        Loop

        For i As Integer = 0 To alertables.Count - 1 'For each screen
            For Each mytag As List(Of LCARSbuttonClass) In alertables(i)
                For Each mybutton As IAlertable In mytag
                    resetAlert(CType(mybutton, LCARS.LCARSbuttonClass))
                Next
            Next
        Next
        inAlert = False
        PostMessage(HWND_BROADCAST, InterMsgID, 0, 7)
    End Sub

    Private Delegate Sub processButtonDelegate(ByVal index As Integer, ByVal Button As LCARS.LCARSbuttonClass)

    Private Sub processButton(ByVal index As Integer, ByVal button As LCARS.LCARSbuttonClass)
        If (button.InvokeRequired) Then
            button.Invoke(New processButtonDelegate(AddressOf processButton), index, button)
        Else
            With button
                If .CustomAlertColor <> alertColor Then
                    .CustomAlertColor = alertColor
                End If
                If .Tag = index Then
                    .RedAlert = LCARS.LCARSalert.White
                    Application.DoEvents()
                Else
                    If .RedAlert <> LCARS.LCARSalert.Custom Then
                        .RedAlert = LCARS.LCARSalert.Custom
                        Application.DoEvents()
                    End If
                End If
            End With
        End If
    End Sub

    Private Delegate Sub resetAlertDelegate(ByVal button As LCARS.LCARSbuttonClass)

    Private Sub resetAlert(ByVal button As LCARS.LCARSbuttonClass)
        If button.InvokeRequired Then
            button.Invoke(New resetAlertDelegate(AddressOf resetAlert), button)
        Else
            button.RedAlert = LCARS.LCARSalert.Normal
        End If
    End Sub

    Private Sub AlertSoundSub(ByVal soundPath As String)
        Try
            My.Computer.Audio.Play(soundPath, alertSoundMode)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AlertScreenSub(ByVal alertables As List(Of List(Of LCARSbuttonClass)))
        'For each tag value
        For intloop As Integer = 0 To alertables.Count - 1
            'Flash each button
            For Each mycontrol As IAlertable In alertables(intloop)
                If _cancelAlert = True Then
                    Exit Sub
                End If
                processButton(intloop, mycontrol)
            Next
            'Clear flash from previous tag
            For Each mycontrol As IAlertable In alertables(If(intloop = 0, alertables.Count - 1, intloop - 1))
                If _cancelAlert = True Then
                    Exit Sub
                End If
                processButton(intloop, mycontrol)
            Next
            'Redraw and wait
            Application.DoEvents()
            Thread.Sleep(flashDelay)
        Next
        'Clear last flash
        For Each mycontrol As IAlertable In alertables(alertables.Count - 1)
            If _cancelAlert = True Then
                Exit Sub
            End If
            processButton(alertables.Count, mycontrol)
        Next
        Application.DoEvents()
    End Sub
End Module
