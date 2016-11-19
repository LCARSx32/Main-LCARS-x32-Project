Public Class LCARSForm
    Inherits System.Windows.Forms.Form

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

    Private Const MONITOR_DEFAULTTONEAREST As Int32 = &H2

    Private Const WM_MINMAXINFO As Integer = &H24

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_MINMAXINFO Then
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
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        MyBase.OnLoad(e)
    End Sub
End Class
