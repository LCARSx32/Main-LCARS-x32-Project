Public Class x32Interop

#Region " API "
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer
    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Const WM_COPYDATA As Integer = &H4A
    Const HWND_BROADCAST As Integer = &HFFFF

    Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure

#End Region

#Region " Events "
    Public Event WorkingAreaChanged(ByVal NewArea As System.Drawing.Rectangle)
    Public Event AlertInitiated(ByVal AlertID As Integer)
    Public Event AlertEnded()
    Public Event BeepingChanged(ByVal Beeping As Boolean)
    Public Event ColorsChanged()
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
            Dim myData As New COPYDATASTRUCT
            myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))
            Dim myRect As New System.Drawing.Rectangle
            myRect = System.Runtime.InteropServices.Marshal.PtrToStructure(myData.lpData, GetType(System.Drawing.Rectangle))
            RaiseEvent WorkingAreaChanged(myRect)
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