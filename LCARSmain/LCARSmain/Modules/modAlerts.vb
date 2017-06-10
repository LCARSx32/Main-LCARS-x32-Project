'TODO: Sort out threads
'TODO: Clean up cross-thread signalling
'TODO: Options for how sounds are handled
'TODO: Fix sound muting
'TODO: Make cancel operation immediate

Option Strict On

Imports System.Threading
Imports LCARS

''' <summary>
''' Contains methods for handling alerts
''' </summary>
''' <remarks>
''' All Public properties and subroutines are intended to be called from the UI thread unless
''' otherwise specified. Attempting to call them from any other thread may result in deadlocks,
''' undefined behavior, or other unpleasentness.
''' </remarks>
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
    Private alertableForms As New Dictionary(Of Form, List(Of List(Of LCARSbuttonClass)))
    Private alertablesLock As New Mutex()

    ''' <summary>
    ''' Register a form to be used when displaying alerts
    ''' </summary>
    ''' <param name="form">Form to be used</param>
    ''' <remarks>
    ''' This is currently used only by main screens. Any forms added by this method must be
    ''' removed with DeregisterAlertForm() before disposal.
    ''' </remarks>
    Public Sub RegisterAlertForm(ByVal form As Form)
        Dim myAlertables As New List(Of List(Of LCARSbuttonClass))
        GetAlertPanels(form, myAlertables)
        alertablesLock.WaitOne()
        alertableForms.Add(form, myAlertables)
        If AlertActive Then
            For Each mytag As List(Of LCARSbuttonClass) In myAlertables
                For Each mycontrol As LCARSbuttonClass In mytag
                    initButton(mycontrol)
                Next
            Next
        End If
        alertablesLock.ReleaseMutex()
    End Sub

    ''' <summary>
    ''' Remove a form from alertable forms list
    ''' </summary>
    ''' <param name="form">Form to be removed</param>
    Public Sub DeregisterAlertForm(ByVal form As Form)
        alertablesLock.WaitOne()
        alertableForms.Remove(form)
        alertablesLock.ReleaseMutex()
    End Sub

    ''' <summary>
    ''' Cancel a current alert
    ''' </summary>
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
            CancelAlert()
            alertThread.Abort()
        End If
        'Extract alert information
        Dim alertstring As String = GetSetting("LCARS x32", "Alerts", type.ToString(), "Red|#FF0000|" & Application.StartupPath & "\red_alert.wav")
        Dim startIndex As Integer = alertstring.IndexOf("|")
        alertColor = ColorTranslator.FromHtml(alertstring.Substring(startIndex + 1, 7))
        alertSound = alertstring.Substring(startIndex + 9)
        alertThread = New Thread(New ThreadStart(AddressOf MainAlert))
        alertThread.IsBackground = True
        _cancelAlert = False
        alertThread.Start()

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
                'it has a tag, so start it alerting!
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

    Private Sub MainAlert()
        'alertSoundMode = CType([Enum].Parse(alertSoundMode.GetType(), _
        '                                    GetSetting("LCARS x32", "Application", "AlertSoundMode", AudioPlayMode.WaitToComplete.ToString())),  _
        '                                    Microsoft.VisualBasic.AudioPlayMode)
        inAlert = True
        Dim mySoundPath As String = alertSound
        Dim soundThread As Thread = Nothing
        ' Set initial color
        For Each scr As List(Of List(Of LCARSbuttonClass)) In alertableForms.Values 'For each screen
            For Each mytag As List(Of LCARSbuttonClass) In scr
                For Each mybutton As LCARSbuttonClass In mytag
                    initButton(mybutton)
                Next
            Next
        Next
        Application.DoEvents()
        'do the alert until cancelAlert is set to true:
        Do Until _cancelAlert
            'Start the sound off
            If Not (mySoundPath = "") Then
                soundThread = New Threading.Thread(New ParameterizedThreadStart(AddressOf AlertSoundSub))
                soundThread.Start(mySoundPath)
            Else
                soundThread = Nothing
            End If
            'Start the flashing on each screen
            DoFlashes()
            'Wait for sound to end
            If soundThread IsNot Nothing Then
                soundThread.Join()
            End If
        Loop
        ' Reset all buttons
        For Each scr As List(Of List(Of LCARSbuttonClass)) In alertableForms.Values
            For Each mytag As List(Of LCARSbuttonClass) In scr
                For Each mybutton As LCARSbuttonClass In mytag
                    resetAlert(mybutton)
                Next
            Next
        Next
        'Signal end of alert
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

    Private Sub DoFlashes()
        Dim tag As Integer = 0
        Dim hasNext As Boolean = True
        'For each tag value
        While hasNext
            hasNext = False
            'Flash each button
            alertablesLock.WaitOne()
            For Each scr As List(Of List(Of LCARSbuttonClass)) In alertableForms.Values
                If scr.Count > tag Then
                    hasNext = True
                    For Each mycontrol As LCARSbuttonClass In scr(tag)
                        If _cancelAlert Then Exit For
                        flashButton(mycontrol)
                    Next
                End If
                'Clear flash from previous tag
                If tag > 0 AndAlso scr.Count >= tag Then
                    For Each mycontrol As LCARSbuttonClass In scr(tag - 1)
                        If _cancelAlert Then Exit For
                        unflashButton(mycontrol)
                    Next
                End If
                If _cancelAlert Then Exit For
            Next
            alertablesLock.ReleaseMutex()
            If _cancelAlert Then Exit Sub
            tag += 1
            'Wait
            Thread.Sleep(flashDelay)
        End While
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
            Application.DoEvents()
        End If
    End Sub
End Module
