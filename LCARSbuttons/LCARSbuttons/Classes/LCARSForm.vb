Public Class LCARSForm
    Inherits System.Windows.Forms.Form

#Region " Windows API "
    Private Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Private Structure RECT
        Dim Left_Renamed As Integer
        Dim Top_Renamed As Integer
        Dim Right_Renamed As Integer
        Dim Bottom_Renamed As Integer
    End Structure

    Private Structure MINMAXINFO
        Dim ptReserved As POINTAPI
        Dim ptMaxSize As POINTAPI
        Dim ptMaxPosition As POINTAPI
        Dim ptMinTrackSize As POINTAPI
        Dim ptMaxTrackSize As POINTAPI
    End Structure

    Private Structure MONITORINFO
        Dim cbSize As Int32
        Dim rcMonitor As RECT
        Dim rcWork As RECT
        Dim dwFlags As Int32
    End Structure

    Private Declare Function MonitorFromWindow Lib "user32" (ByVal hwnd As Int32, ByVal dwFlags As Int32) As Int32

    Private Declare Auto Function GetMonitorInfo Lib "user32" (ByVal hMonitor As Int32, ByRef lpmi As MONITORINFO) As Integer

    Private Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer

    Private Const MONITOR_DEFAULTTONEAREST As Int32 = &H2

    Private Const WM_MINMAXINFO As Integer = &H24
#End Region

    Private X32_MSG As Integer

#Region " Events "
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
#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = X32_MSG Then
            m.Result = 1
            Select Case m.LParam
                Case 2
                    OnColorsChange()
                Case 3
                    OnBeepingUpdate(GetSetting("LCARS x32", "Application", "ButtonBeep", "TRUE"))
                Case 11
                    OnAlertInitiated(m.WParam)
                Case 7
                    OnAlertEnded()
                Case 13
                    OnLCARSClosing()
            End Select

        ElseIf m.Msg = WM_MINMAXINFO Then
            Dim mmi As MINMAXINFO = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(MINMAXINFO))
            Dim monitor As Integer = MonitorFromWindow(Me.Handle, MONITOR_DEFAULTTONEAREST)
            If monitor <> 0 Then
                Dim minfo As MONITORINFO
                minfo.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(minfo)
                If GetMonitorInfo(monitor, minfo) <> 0 Then
                    mmi.ptMaxPosition.X = minfo.rcWork.Left_Renamed
                    mmi.ptMaxPosition.Y = minfo.rcWork.Top_Renamed
                    mmi.ptMaxSize.X = minfo.rcWork.Right_Renamed - minfo.rcWork.Left_Renamed
                    mmi.ptMaxSize.Y = minfo.rcWork.Bottom_Renamed - minfo.rcWork.Top_Renamed
                    System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, m.LParam, True)
                    m.Result = 1
                    Return
                End If
            End If
            m.Result = 0
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        X32_MSG = RegisterWindowMessageA("LCARS_X32_MSG")
        MyBase.OnLoad(e)
    End Sub

    Protected Overridable Sub OnColorsChange()
        LCARS.UpdateColors(Me)
    End Sub

    Protected Overridable Sub OnBeepingUpdate(ByVal beep As Boolean)
        LCARS.SetBeeping(Me, beep)
    End Sub

    Protected Overridable Sub OnAlertInitiated(ByVal alertID As Integer)
        RaiseEvent AlertInitiated(alertID)
    End Sub

    Protected Overridable Sub OnAlertEnded()
        RaiseEvent AlertEnded()
    End Sub

    Protected Overridable Sub OnLCARSClosing()
        Me.Close()
    End Sub
End Class
