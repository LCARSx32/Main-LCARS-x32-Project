'TODO: Sort out threads
'TODO: Clean up cross-thread signalling
'TODO: Options for how sounds are handled
'TODO: Fix sound muting
'TODO: Make cancel operation immediate
'TODO: Handle mode-select operations better

Option Strict On

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
        alertThread = New Thread(New ParameterizedThreadStart(AddressOf MainAlert))
        _cancelAlert = False
        alertThread.Start(alertables)

        PostMessage(HWND_BROADCAST, InterMsgID, New IntPtr(type), New IntPtr(11))
    End Sub

    Private Sub GetAlertPanels(ByVal baseControl As Control, ByRef alertables As List(Of List(Of LCARSbuttonClass)))
        Dim tag As Integer
        Dim item As LCARS.LCARSbuttonClass
        'check for child controls and add them to the proper list
        For Each myControl As Control In baseControl.Controls
            item = TryCast(myControl, LCARS.LCARSbuttonClass)
            If item IsNot Nothing _
                    AndAlso item.Tag IsNot Nothing _
                    AndAlso item.Tag.ToString() <> "" _
                    AndAlso Integer.TryParse(item.Tag.ToString(), tag) = True Then
                'it has a tag and is a container, so start it alerting!
                If tag >= alertables.Count Then 'Not enough lists yet
                    For i As Integer = alertables.Count To tag
                        alertables.Add(New List(Of LCARSbuttonClass))
                    Next
                End If
                alertables(tag).Add(item)
            End If
            If myControl.Controls.Count > 0 Then
                GetAlertPanels(myControl, alertables)
            End If
        Next
    End Sub

    Private Sub MainAlert(ByVal params As Object)
        Dim alertables As List(Of List(Of List(Of LCARSbuttonClass))) = _
                CType(params, List(Of List(Of List(Of LCARSbuttonClass))))

        alertSoundMode = CType([Enum].Parse(GetType(Microsoft.VisualBasic.AudioPlayMode), _
                                            GetSetting("LCARS x32", "Application", "AlertSoundMode", AudioPlayMode.WaitToComplete.ToString())),  _
                                            Microsoft.VisualBasic.AudioPlayMode)
        inAlert = True
        Dim mySoundPath As String = alertSound
        Dim soundThread As Thread = Nothing
        Dim screenThreads(alertables.Count - 1) As Threading.Thread
        ' Set initial color
        For Each myscreen As List(Of List(Of LCARSbuttonClass)) In alertables
            For Each mytag As List(Of LCARSbuttonClass) In myscreen
                For Each myButton As LCARSbuttonClass In mytag
                    initButton(myButton)
                Next
            Next
        Next
        Application.DoEvents()
        'do the alert until cancelAlert is set to true:
        Do Until _cancelAlert = True
            'Start the sound off
            If Not (mySoundPath = "") Then
                soundThread = New Threading.Thread(New ParameterizedThreadStart(AddressOf AlertSoundSub))
                soundThread.Start(mySoundPath)
            End If
            'Start the flashing on each screen
            For i As Integer = 0 To alertables.Count - 1
                screenThreads(i) = New Thread(New ParameterizedThreadStart(AddressOf AlertScreenSub))
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
        PostMessage(HWND_BROADCAST, InterMsgID, IntPtr.Zero, New IntPtr(7))
    End Sub

    Private Sub AlertSoundSub(ByVal params As Object)
        Dim soundPath As String = CType(params, String)
        Try
            My.Computer.Audio.Play(soundPath, alertSoundMode)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AlertScreenSub(ByVal params As Object)
        Dim alertables As List(Of List(Of LCARSbuttonClass)) = CType(params, List(Of List(Of LCARSbuttonClass)))
        'For each tag value
        For intloop As Integer = 0 To alertables.Count - 1
            'Flash each button
            For Each mycontrol As LCARSbuttonClass In alertables(intloop)
                If _cancelAlert = True Then
                    Exit Sub
                End If
                flashButton(mycontrol)
            Next
            'Clear flash from previous tag
            If intloop > 0 Then
                For Each mycontrol As LCARSbuttonClass In alertables(intloop - 1)
                    If _cancelAlert = True Then
                        Exit Sub
                    End If
                    unflashButton(mycontrol)
                Next
            End If
            'Redraw and wait
            Application.DoEvents()
            Thread.Sleep(flashDelay)
        Next
        'Clear last flash
        For Each mycontrol As LCARSbuttonClass In alertables(alertables.Count - 1)
            If _cancelAlert = True Then
                Exit Sub
            End If
            unflashButton(mycontrol)
        Next
        Application.DoEvents()
    End Sub

    Private Delegate Sub processButtonDelegate(ByVal button As LCARSbuttonClass)

    Private Sub initButton(ByVal button As LCARSbuttonClass)
        If button.InvokeRequired Then
            button.Invoke(New processButtonDelegate(AddressOf initButton), button)
        Else
            button.CustomAlertColor = alertColor
            button.RedAlert = LCARSalert.Custom
            Application.DoEvents()
        End If
    End Sub

    Private Sub unflashButton(ByVal button As LCARSbuttonClass)
        If button.InvokeRequired Then
            button.Invoke(New processButtonDelegate(AddressOf unflashButton), button)
        Else
            button.RedAlert = LCARSalert.Custom
            Application.DoEvents()
        End If
    End Sub

    Private Sub flashButton(ByVal button As LCARSbuttonClass)
        If button.InvokeRequired Then
            button.Invoke(New processButtonDelegate(AddressOf flashButton), button)
        Else
            button.RedAlert = LCARSalert.White
            Application.DoEvents()
        End If
    End Sub

    Private Sub resetAlert(ByVal button As LCARSbuttonClass)
        If button.InvokeRequired Then
            button.Invoke(New processButtonDelegate(AddressOf resetAlert), button)
        Else
            button.RedAlert = LCARS.LCARSalert.Normal
        End If
    End Sub
End Module
