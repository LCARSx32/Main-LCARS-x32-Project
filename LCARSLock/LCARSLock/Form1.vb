Public Class frmLock

#Region " SetWindowsPos "

    'All code from PInvoke.net

    <Flags()> _
Public Enum SetWindowPosFlags As UInteger
        ''' <summary>If the calling thread and the thread that owns the window are attached to different input queues,
        ''' the system posts the request to the thread that owns the window. This prevents the calling thread from
        ''' blocking its execution while other threads process the request.</summary>
        ''' <remarks>SWP_ASYNCWINDOWPOS</remarks>
        SynchronousWindowPosition = &H4000
        ''' <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        ''' <remarks>SWP_DEFERERASE</remarks>
        DeferErase = &H2000
        ''' <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        ''' <remarks>SWP_DRAWFRAME</remarks>
        DrawFrame = &H20
        ''' <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
        ''' the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
        ''' is sent only when the window's size is being changed.</summary>
        ''' <remarks>SWP_FRAMECHANGED</remarks>
        FrameChanged = &H20
        ''' <summary>Hides the window.</summary>
        ''' <remarks>SWP_HIDEWINDOW</remarks>
        HideWindow = &H80
        ''' <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
        ''' top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
        ''' parameter).</summary>
        ''' <remarks>SWP_NOACTIVATE</remarks>
        DoNotActivate = &H10
        ''' <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
        ''' contents of the client area are saved and copied back into the client area after the window is sized or
        ''' repositioned.</summary>
        ''' <remarks>SWP_NOCOPYBITS</remarks>
        DoNotCopyBits = &H100
        ''' <summary>Retains the current position (ignores X and Y parameters).</summary>
        ''' <remarks>SWP_NOMOVE</remarks>
        IgnoreMove = &H2
        ''' <summary>Does not change the owner window's position in the Z order.</summary>
        ''' <remarks>SWP_NOOWNERZORDER</remarks>
        DoNotChangeOwnerZOrder = &H200
        ''' <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
        ''' the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
        ''' window uncovered as a result of the window being moved. When this flag is set, the application must
        ''' explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        ''' <remarks>SWP_NOREDRAW</remarks>
        DoNotRedraw = &H8
        ''' <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        ''' <remarks>SWP_NOREPOSITION</remarks>
        DoNotReposition = &H200
        ''' <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        ''' <remarks>SWP_NOSENDCHANGING</remarks>
        DoNotSendChangingEvent = &H400
        ''' <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        ''' <remarks>SWP_NOSIZE</remarks>
        IgnoreResize = &H1
        ''' <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        ''' <remarks>SWP_NOZORDER</remarks>
        IgnoreZOrder = &H4
        ''' <summary>Displays the window.</summary>
        ''' <remarks>SWP_SHOWWINDOW</remarks>
        ShowWindow = &H40
    End Enum
    Public Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As SetWindowPosFlags) As Boolean

#End Region

    Public Declare Function FindWindow Lib "user32" _
    Alias "FindWindowA" (ByVal lpClassName As String, _
    ByVal lpWindowName As String) As IntPtr

    Private canClose As Boolean = False
    Private Sub frmLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not canClose
    End Sub


    Private Sub frmLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check password
        If GetSetting("LCARS x32", "Application", "AuthorizationCode", "") = "" Then
            LCARS.UI.MsgBox("Password is blank. If this is not what you want, reset it in the Settings menu.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Warning")
        End If
        'Hide explorer
        Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
        SetWindowPos(intReturn, 0, 0, 0, 0, 0, SetWindowPosFlags.HideWindow)
        'Set form to topmost and free-moving
        SetWindowPos(Me.Handle, New IntPtr(-1), 0, 0, My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height, SetWindowPosFlags.FrameChanged)
        'Lock task manager
        Shell("reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f")
        'Lock keyboard
        HookKeyboard()
        txtCode.Focus()
    End Sub

    Private Sub sbSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSubmit.Click
        If txtCode.Text = GetSetting("LCARS x32", "Application", "AuthorizationCode", "") Then
            canClose = True
            'Enable Task Manager
            Shell("reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f")
            UnhookKeyboard()
            Me.Close()
        Else
            LCARS.UI.MsgBox("Invalid.", MsgBoxStyle.SystemModal Or MsgBoxStyle.Critical, "Invalid")
            txtCode.Clear()
        End If
    End Sub


    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown, txtOld.KeyDown, txtNew.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender Is txtCode Then
                sbSubmit.doClick(sender, e)
            ElseIf sender Is txtNew Or sender Is txtOld Then
                sbReset.doClick(sender, e)
            End If
        End If
    End Sub

    Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Settings.Click
        pnlSettings.Visible = Not pnlSettings.Visible
    End Sub

    Private Sub sbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbReset.Click
        If txtOld.Text = GetSetting("LCARS x32", "Application", "AuthorizationCode", "") Then
            If txtNew.Text <> "" Then
                SaveSetting("LCARS x32", "Application", "AuthorizationCode", txtNew.Text)
                LCARS.UI.MsgBox("Password changed.", MsgBoxStyle.SystemModal Or MsgBoxStyle.Information, "Success")
                pnlSettings.Visible = False
                txtCode.Focus()
            Else
                LCARS.UI.MsgBox("Password cannot be blank.", MsgBoxStyle.SystemModal Or MsgBoxStyle.Information, "Error")
            End If
        Else
            LCARS.UI.MsgBox("Invalid.", MsgBoxStyle.SystemModal Or MsgBoxStyle.Critical, "Invalid")
        End If
        txtOld.Clear()
        txtNew.Clear()
    End Sub
End Class
