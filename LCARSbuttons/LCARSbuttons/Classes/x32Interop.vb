''' <summary>
''' Allows for automatic notification of changes to the LCARS environment.
''' </summary>
''' <remarks>
''' This class links its window to the current running instance of LCARS x32, then receives messages
''' for the object that created it. These LCARS-specific messages are then passed on to standard
''' events for processing.
''' </remarks>
Public Class x32Interop

#Region " API "
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Const WM_COPYDATA As Integer = &H4A
    Const HWND_BROADCAST As Integer = &HFFFF

    Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure

#End Region

#Region " Events "
    ''' <summary>
    ''' Raised when the working area changes
    ''' </summary>
    ''' <param name="NewArea">Bounds of the new working area</param>
    ''' <remarks>
    ''' This event will not be raised immediately after the current instance has subscribed to LCARS
    ''' messages. The window that needs to resize will need to do so on its own on startup.
    ''' </remarks>
    <Obsolete("Replace by setting maximized bounds to match working area.", True)> _
    Public Event WorkingAreaChanged(ByVal NewArea As System.Drawing.Rectangle)
    ''' <summary>
    ''' Raised when an alert is initiated.
    ''' </summary>
    ''' <param name="AlertID">ID of the alert initiated</param>
    Public Event AlertInitiated(ByVal AlertID As Integer)
    ''' <summary>
    ''' Raised when the current alert has ended
    ''' </summary>
    ''' <remarks>
    ''' If an alert ends because another alert has replaced it, this event will not be raised, only a
    ''' new <see cref="AlertInitiated">AlertInitiated</see> event
    ''' </remarks>
    Public Event AlertEnded()
    ''' <summary>
    ''' Raised when the global beeping setting has changed
    ''' </summary>
    ''' <param name="Beeping">The new global beeping setting</param>
    Public Event BeepingChanged(ByVal Beeping As Boolean)
    ''' <summary>
    ''' Raised when the global color settings have been changed.
    ''' </summary>
    ''' <remarks>
    ''' No additional data is provided because the <see cref="LCARScolor">LCARS color</see> class
    ''' contains a method to reload the colors from the registry.
    ''' </remarks>
    Public Event ColorsChanged()
    ''' <summary>
    ''' Raised when the current instance of LCARS x32 is closing.
    ''' </summary>
    ''' <remarks>
    ''' When this is called, the window used to capture messages will also be closed. If further
    ''' LCARS message capturing is required, a new instance will need to be created.
    ''' </remarks>
    Public Event LCARSx32Closing()
#End Region

    Dim x32Handle As IntPtr = IntPtr.Zero
    Dim InterMsgID As Integer
    Dim receiver As New MessageReceiver
    Private Sub ProcessMessage(ByVal m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID Then
            m.Result = 1
            Select Case m.LParam
                Case 2
                    RaiseEvent ColorsChanged()
                Case 3
                    RaiseEvent BeepingChanged(GetSetting("LCARS x32", "Application", "ButtonBeep", "TRUE"))
                Case 11
                    RaiseEvent AlertInitiated(m.WParam)
                Case 7
                    RaiseEvent AlertEnded()
                Case 13
                    RaiseEvent LCARSx32Closing()
                    receiver.Close()
            End Select

        ElseIf m.Msg = WM_COPYDATA And m.WParam = x32Handle And Not x32Handle = IntPtr.Zero Then
            m.Result = 1

            'Obsolete: applications are expected to keep their own size.

            'Dim myData As New COPYDATASTRUCT
            'myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))
            'Dim myRect As New System.Drawing.Rectangle
            'myRect = System.Runtime.InteropServices.Marshal.PtrToStructure(myData.lpData, GetType(System.Drawing.Rectangle))
            'receiver.Bounds = myRect
            'RaiseEvent WorkingAreaChanged(myRect)
        End If
    End Sub

    ''' <summary>
    ''' Initializes the interop class.
    ''' </summary>
    ''' <returns>True if successful, false otherwise.</returns>
    ''' <remarks>
    ''' The class will immediately begin raising events after this sub is called, so all event handlers should be attached
    ''' beforehand.
    ''' </remarks>
    Public Function Init() As Boolean
        'Initialize reference to x32 and start receiving events
        AddHandler receiver.MessageRecieved, AddressOf ProcessMessage
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(x32Handle, InterMsgID, receiver.Handle, 1)
        Return x32Handle <> 0
    End Function

    Private Class MessageReceiver
        Inherits System.Windows.Forms.Form

        Public Event MessageRecieved(ByVal m As System.Windows.Forms.Message)
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            RaiseEvent MessageRecieved(m)
            MyBase.WndProc(m)
        End Sub
    End Class
End Class