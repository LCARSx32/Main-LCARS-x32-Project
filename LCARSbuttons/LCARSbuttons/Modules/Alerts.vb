Option Strict On

Imports System.Drawing

''' <summary>
''' Contains methods for registering and using alerts.
''' </summary>
''' <remarks></remarks>
<HideModuleName()> _
Public Module Alerts
    Private Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure
    Private Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Const WM_COPYDATA As Integer = &H4A

    ''' <summary>
    ''' Registers a new alert with LCARS x32, or returns the ID of the alert with the same name.
    ''' </summary>
    ''' <param name="Name">The name your code will reference the alert by</param>
    ''' <param name="AlertColor">Color the alert will use. Ignored if alert by the same name already exists.</param>
    ''' <param name="SoundPath">Sound that will be played for the alert. Ignored if alert by the same name already exists.</param>
    ''' <returns>Integer representing the alert ID</returns>
    ''' <remarks>
    ''' Unless calling a red or yellow alert, use this to register the alert before activating it. The cost to do so is very slight,
    ''' and it will avoid any problems with nonexistant alerts being activated.
    ''' </remarks>
    Public Function RegisterAlert(ByVal Name As String, ByVal AlertColor As Color, Optional ByVal SoundPath As String = "") As Integer
        Dim result As Integer = -1
        Dim mysettings(,) As String = GetAllSettings("LCARS x32", "Alerts")

        For i As Integer = 0 To (mysettings.GetUpperBound(0))
            If Name = mysettings(i, 1).Substring(0, mysettings(i, 1).IndexOf("|")) Then
                result = CInt(mysettings(i, 0))
            End If
        Next

        If result = -1 Then
            Dim id As Integer = GetNewID()
            SaveSetting("LCARS x32", "Alerts", id.ToString(), Name & "|" & Util.GetHexColor(AlertColor) & "|" & SoundPath)
            Return id
        Else
            Return result
        End If
    End Function

    ''' <summary>
    ''' Registers a new alert with LCARS x32, or returns the ID of the alert with the same name.
    ''' </summary>
    ''' <param name="Name">The name your code will reference the alert by</param>
    ''' <param name="AlertColor">Color the alert will use as HTML-style color code. Ignored if alert by the same name already exists.</param>
    ''' <param name="SoundPath">Sound that will be played for the alert. Ignored if alert by the same name already exists.</param>
    ''' <returns>Integer representing the alert ID</returns>
    ''' <remarks>
    ''' Unless calling a red or yellow alert, use this to register the alert before activating it. The cost to do so is very slight,
    ''' and it will avoid any problems with nonexistant alerts being activated.<br />
    ''' This variant allows the color to be specified as an HTML-style color code.
    ''' </remarks>
    Public Function RegisterAlert(ByVal Name As String, ByVal AlertColor As String, Optional ByVal SoundPath As String = "") As Integer
        RegisterAlert(Name, ColorTranslator.FromHtml(AlertColor), SoundPath)
    End Function

    ''' <summary>
    ''' Returns the alert ID of a preexisting alert
    ''' </summary>
    ''' <param name="Name">Name of the alert to look up</param>
    ''' <returns>Alert ID as an integer</returns>
    ''' <exception cref="Exception">
    ''' Will throw an exception if the alert name does not exist.
    ''' </exception>
    ''' <remarks>
    ''' This is a shortcut for checking that your alert's ID hasn't changed since you registered it. There can be some time
    ''' savings over just using RegisterAlert, but RegisterAlert will register the alert if it does not already exist.
    ''' </remarks>
    Public Function GetAlertID(ByVal Name As String) As Integer
        Dim result As Integer = -1
        Dim mysettings(,) As String = GetAllSettings("LCARS x32", "Alerts")
        For i As Integer = 0 To (mysettings.GetUpperBound(0))
            If Name = mysettings(i, 1).Substring(0, mysettings(i, 1).IndexOf("|")) Then
                result = CInt(mysettings(i, 0))
            End If
        Next
        If result = -1 Then
            Throw New Exception("Given alert name does not exist")
        Else
            Return result
        End If
    End Function

    ''' <summary>
    ''' Sends a message to LCARS x32 to activate the specified alert.
    ''' </summary>
    ''' <param name="ID">ID of alert to call</param>
    ''' <param name="hwnd">Handle of calling object</param>
    ''' <remarks>Use this if you already have the alert ID.</remarks>
    Public Sub ActivateAlert(ByVal ID As Int32, ByVal hwnd As System.IntPtr)
        Dim myData As New COPYDATASTRUCT
        myData.dwData = New IntPtr(11)
        myData.cdData = Runtime.InteropServices.Marshal.SizeOf(ID)
        myData.lpData = Runtime.InteropServices.Marshal.AllocCoTaskMem(myData.cdData)
        Runtime.InteropServices.Marshal.StructureToPtr(ID, myData.lpData, False)
        Dim MyCopyData As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        System.Runtime.InteropServices.Marshal.StructureToPtr(myData, MyCopyData, True)

        SendMessage(New IntPtr(CInt(GetSetting("LCARS x32", "Application", "MainWindowHandle", "0"))), WM_COPYDATA, hwnd, MyCopyData)
        Runtime.InteropServices.Marshal.FreeCoTaskMem(myData.lpData)
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(MyCopyData)
    End Sub

    ''' <summary>
    ''' Sends a message to LCARS x32 to activate the specified alert.
    ''' </summary>
    ''' <param name="Name">Name of the alert to call</param>
    ''' <param name="hwnd">Handle of the calling object</param>
    ''' <exception cref="Exception">Throws an exception if the alert does not already exist.</exception>
    ''' <remarks>
    ''' This sub is a wrapper for the overloaded sub that requires an ID. Use this for convenience, but use the other if you
    ''' have the alert ID already. This is useful if you only need to call the Red or Yellow alerts.
    ''' </remarks>
    Public Sub ActivateAlert(ByVal Name As String, ByVal hwnd As System.IntPtr)
        ActivateAlert(GetAlertID(Name), hwnd)
    End Sub

    ''' <summary>
    ''' Cancels the current alert.
    ''' </summary>
    ''' <param name="hwnd">Handle of calling object.</param>
    ''' <remarks></remarks>
    Public Sub DeactivateAlert(ByVal hwnd As System.IntPtr)
        Dim myData As New COPYDATASTRUCT
        myData.dwData = New IntPtr(7)
        Dim MyCopyData As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        System.Runtime.InteropServices.Marshal.StructureToPtr(myData, MyCopyData, True)

        SendMessage(New IntPtr(CInt(GetSetting("LCARS x32", "Application", "MainWindowHandle", "0"))), WM_COPYDATA, hwnd, MyCopyData)
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(MyCopyData)
    End Sub

    ''' <summary>
    ''' Gets a list of all valid alert names
    ''' </summary>
    ''' <returns>A list of all current valid alert names.</returns>
    ''' <remarks>
    ''' Use this if you need a list of all valid alert names. This is used internally by the settings program and LCARSmain.</remarks>
    Public Function GetAllAlertNames() As List(Of String)
        Dim mySettings(,) As String = GetAllSettings("LCARS x32", "Alerts")
        Dim myAlerts As New List(Of String)
        For i As Integer = 0 To mySettings.GetUpperBound(0)
            myAlerts.Add(mySettings(i, 1).Substring(0, mySettings(i, 1).IndexOf("|")))
        Next
        Return myAlerts
    End Function

    ''' <summary>
    ''' Gets the color of an alert by name
    ''' </summary>
    ''' <param name="alertName">Name of alert to look up</param>
    ''' <returns>Color that will be displayed by the alert</returns>
    ''' <remarks></remarks>
    Public Function GetAlertColor(ByVal alertName As String) As Color
        Dim id As Integer = GetAlertID(alertName)
        Return GetAlertColor(id)
    End Function

    ''' <summary>
    ''' Returns the color of the alert given.
    ''' </summary>
    ''' <param name="alertID">Alert ID to look up</param>
    ''' <returns>Color of specified alert</returns>
    ''' <remarks></remarks>
    Public Function GetAlertColor(ByVal alertID As Integer) As Color
        Dim alertstring As String = GetSetting("LCARS x32", "Alerts", alertID.ToString(), "")
        Dim startIndex As Integer = alertstring.IndexOf("|")
        Return ColorTranslator.FromHtml(alertstring.Substring(startIndex + 1, 7))
    End Function

    ''' <summary>
    ''' Returns an unoccupied alert ID.
    ''' </summary>
    ''' <returns>ID found</returns>
    ''' <remarks>Do not make the assumption that alert IDs are consecutive. Use this function if you need an unoccupied one.</remarks>
    Public Function GetNewID() As Integer
        Dim i As Integer = 1
        Dim alertString As String = ""
        Do Until alertString = "Blank"
            i += 1
            alertString = GetSetting("LCARS x32", "Alerts", i.ToString(), "Blank")
        Loop
        Return i
    End Function

    ''' <summary>
    ''' Sends a message to x32 that there have been changes to the alerts.
    ''' </summary>
    ''' <param name="hwnd">Handle of caller</param>
    ''' <remarks>Call this whenever you have made changes, or those changes will not be noticed until x32 has restarted.</remarks>
    Public Sub RefreshAlerts(ByVal hwnd As IntPtr)
        Dim myData As New COPYDATASTRUCT
        myData.dwData = New IntPtr(12)
        Dim MyCopyData As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        System.Runtime.InteropServices.Marshal.StructureToPtr(myData, MyCopyData, True)

        SendMessage(New IntPtr(CInt(GetSetting("LCARS x32", "Application", "MainWindowHandle", "0"))), WM_COPYDATA, hwnd, MyCopyData)
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(MyCopyData)
    End Sub

    ''' <summary>
    ''' Deletes an alert
    ''' </summary>
    ''' <param name="id">ID of alert to delete</param>
    ''' <exception cref="System.Exception">Will raise generic exception if alert is system-defined or if alert does not exist.</exception>
    ''' <remarks>Use with caution, particularly if deleting someone else's alert</remarks>
    Public Sub DeleteAlert(ByVal id As Integer)
        If id > 1 Then
            If GetSetting("LCARS x32", "Alerts", id.ToString(), "") <> "" Then
                DeleteSetting("LCARS x32", "Alerts", id.ToString())
            End If
        Else
            Throw New Exception("Cannot delete a system-defined alert.")
        End If
    End Sub
End Module
