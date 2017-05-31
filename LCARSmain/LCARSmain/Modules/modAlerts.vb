'TODO: Sort out threads
'TODO: Avoid searching through alertables for each update
'TODO: Use strongly typed Lists instead of untyped Collection
'TODO: Clean up cross-thread signalling
'TODO: Options for how sounds are handled
'TODO: Fix sound muting
'TODO: Make cancel operation immediate

Module modAlerts
    Private alertType As Integer
    Private alertColor As Color
    Private alertSound As String
    Private inAlert As Boolean = False
    Private alertThread As Threading.Thread
    Private alertSoundMode As Microsoft.VisualBasic.AudioPlayMode = AudioPlayMode.WaitToComplete
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
        'TODO: Set by screen index
        Dim alertables(curBusiness.Count - 1) As Collection
        For i As Integer = 0 To alertables.Length - 1
            alertables(i) = GetAlertPanels(curBusiness(i).myForm)
        Next
        alertThread = New Threading.Thread(AddressOf MainAlert)
        _cancelAlert = False
        alertThread.Start(alertables)

        PostMessage(HWND_BROADCAST, InterMsgID, type, 11)
    End Sub

    Private Function GetAlertPanels(ByVal baseControl As Control) As Collection
        Dim Alertables As New Collection
        Dim LCARSbutton As New LCARS.LCARSbuttonClass
        Dim LCARStype As Type = LCARSbutton.GetType
        Dim buffer As Integer

        'check for child controls and set them to alert also.
        For Each myControl As Control In baseControl.Controls
            If myControl.Controls.Count > 0 Then
                If Not myControl.GetType.IsSubclassOf(LCARStype) And Not myControl.Tag Is Nothing And myControl.Tag <> "" And Integer.TryParse(myControl.Tag, buffer) = True Then
                    'it has a tag and is a container, so start it alerting!
                    Alertables.Add(myControl)
                End If
                If Not myControl.GetType.IsSubclassOf(LCARStype) Then
                    Dim subAlertables As New Collection
                    subAlertables = GetAlertPanels(myControl)

                    For Each subControl As Control In subAlertables
                        Alertables.Add(subControl)
                    Next
                End If

            End If
        Next

        If Not baseControl.Tag Is Nothing And baseControl.Tag <> "" And Integer.TryParse(baseControl.Tag, buffer) = True Then
            Alertables.Add(baseControl)
        End If

        Return Alertables
    End Function

    Private Sub MainAlert(ByVal alertables() As Collection)
        Dim LCARSbutton As New LCARS.LCARSbuttonClass
        Dim LCARStype As Type = LCARSbutton.GetType
        Dim buffer As Integer
        alertSoundMode = GetSetting("LCARS x32", "Application", "AlertSoundMode", AudioPlayMode.WaitToComplete)
        inAlert = True
        Dim highestTag(alertables.Length - 1) As Integer
        For i As Integer = 0 To alertables.Length - 1 'For each screen
            For Each myControl As Control In alertables(i)
                If Not myControl.Tag Is Nothing And myControl.Tag <> "" And Integer.TryParse(myControl.Tag, buffer) = True Then
                    If buffer > highestTag(i) Then
                        highestTag(i) = buffer
                    End If
                End If
            Next
        Next
        Dim mySoundPath As String = alertSound
        Dim soundThread As Threading.Thread = Nothing
        Dim screenThreads(alertables.Length - 1) As Threading.Thread
        'do the alert until cancelAlert is set to true:
        Do Until _cancelAlert = True
            'Start the sound off
            If Not (mySoundPath = "") Then
                soundThread = New Threading.Thread(AddressOf AlertSoundSub)
                soundThread.Start(mySoundPath)
            End If
            'Start the flashing on each screen
            For i As Integer = 0 To alertables.Length - 1
                screenThreads(i) = New Threading.Thread(AddressOf AlertScreenSub)
                Dim myparams As New AlertScreenSubParameters()
                myparams.alertables = alertables(i)
                myparams.highestTag = highestTag(i)
                screenThreads(i).Start(myparams)
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

        For i As Integer = 0 To alertables.Length - 1 'For each screen
            For Each myBaseControl As Control In alertables(i)
                For Each mybutton As Control In myBaseControl.Controls
                    If mybutton.GetType.IsSubclassOf(LCARStype) Then
                        resetAlert(CType(mybutton, LCARS.LCARSbuttonClass))
                    End If
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

    Private Structure AlertScreenSubParameters
        Dim alertables As Collection
        Dim highestTag As Integer
    End Structure

    Private Sub AlertScreenSub(ByVal params As AlertScreenSubParameters)
        For intloop As Integer = 0 To params.highestTag
            For Each myBaseControl As Control In params.alertables

                If _cancelAlert = True Then
                    Exit Sub
                End If

                For Each myButton As Control In myBaseControl.Controls

                    If _cancelAlert = True Then
                        Exit Sub
                    End If
                    Dim myLCARSButton As LCARS.LCARSbuttonClass = TryCast(myButton, LCARS.LCARSbuttonClass)
                    If Not myLCARSButton Is Nothing Then
                        processButton(intloop, myLCARSButton)
                    End If

                    Application.DoEvents()
                Next
            Next
            Threading.Thread.Sleep(50)
        Next

    End Sub
End Module
