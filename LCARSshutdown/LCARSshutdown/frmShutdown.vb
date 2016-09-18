Public Class frmShutdown
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

    Dim WithEvents interop As New LCARS.x32Interop

    Private Sub interop_BeepingChanged(ByVal Beeping As Boolean) Handles interop.BeepingChanged
        LCARS.SetBeeping(Me, Beeping)
    End Sub

    Private Sub interop_ColorsChanged() Handles interop.ColorsChanged
        LCARS.UpdateColors(Me)
    End Sub

    Private Sub interop_LCARSx32Closing() Handles interop.LCARSx32Closing
        Application.Exit()
    End Sub

#End Region

    Dim shutdownOptions As New cWrapExitWindows


    Private Sub sbShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbShutdown.Click
        Me.Hide()
        CloseLCARS()
        shutdownOptions.ExitWindows(cWrapExitWindows.Action.Shutdown)
    End Sub

    Private Sub sbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExit.Click
        Me.Hide()
        CloseLCARS()
        If Not Process.GetProcessesByName("explorer").Length > 0 Then
            Process.Start("explorer.exe")
        End If
        End
    End Sub

    Private Sub sbRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRestart.Click
        Me.Hide()
        CloseLCARS()
        shutDownOptions.ExitWindows(cWrapExitWindows.Action.Restart)
    End Sub

    Private Sub sbLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLogOff.Click
        Me.Hide()
        CloseLCARS()
        shutDownOptions.ExitWindows(cWrapExitWindows.Action.LogOff)
    End Sub

    Private Sub sbSuspend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSuspend.Click
        Application.SetSuspendState(PowerState.Suspend, True, False)
    End Sub

    Private Sub sbHibernate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbHibernate.Click
        Application.SetSuspendState(PowerState.Hibernate, True, False)
    End Sub

    Private Sub frmShutdown_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        interop.Init()
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        Dim myCommands() As String = System.Environment.CommandLine.Split("/")

        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(InterMsgID, InterMsgID, Me.Handle, 1)

        Me.Bounds = Screen.PrimaryScreen.WorkingArea

        If myCommands.GetUpperBound(0) > 1 Then
            If myCommands(2) = "c" Then
                sbExit.doClick(New Object, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
    End Sub

    Private Sub CloseLCARS()
        Dim myData As New COPYDATASTRUCT
        myData.dwData = 5

        Dim MyCopyData As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(COPYDATASTRUCT)))
        System.Runtime.InteropServices.Marshal.StructureToPtr(myData, MyCopyData, False)

        Dim res As Integer = SendMessage(x32Handle, WM_COPYDATA, Me.Handle, MyCopyData)
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(MyCopyData)
    End Sub


    Private Sub sbLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLock.Click
        Try
            Process.Start(Application.StartupPath & "\LCARSLock.exe")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmShutdown_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged, Me.SizeChanged
        Dim adjustedBounds As Rectangle = Screen.FromHandle(Me.Handle).WorkingArea
        adjustedBounds.Location -= Screen.FromHandle(Me.Handle).Bounds.Location
        If Not Me.MaximizedBounds = adjustedBounds Then
            Me.MaximizedBounds = adjustedBounds
        End If
    End Sub
End Class