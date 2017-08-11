Imports System.Runtime.InteropServices
Imports System.ComponentModel

''' <summary>
''' Listens for clipboard change notifications and propagates them through .NET events
''' </summary>
''' <remarks>
''' There are two native APIs for getting notified of a clipboard contents change. The oldest,
''' using SetClipboardViewer and associated functions makes use of a chain of windows. When
''' registering for notifications, a window is added to the end of the chain. A window in the
''' chain is responsible for passing update messages to windows further down. Likewise, when
''' a window is destroyed, it *must* notify the remaining windows in the chain that it is to
''' be removed. Terminated processes and programming errors can easily break this chain,
''' resulting in problems in unrelated applications. Unfortunately, this API is the only one
''' supported on Windows XP and below.
''' 
''' The second API is only supported on Windows Vista and up, but it lacks the problems of the
''' older API. This API is used by the ClipboardListener on any system that supports it, only
''' falling back to the older API if necessary.
''' </remarks>
Public Class ClipboardListener
    Inherits NativeWindow

#Region " Windows API "
#Region " Clipboard Format Listener (Vista and up) "
    ''' <summary>
    ''' Window message received when using clipboard format listener API
    ''' </summary>
    ''' <remarks>
    ''' wParam: Not used and must be zero
    ''' lParam: Not used and must be zero
    ''' Return value: Zero if successfully processed
    ''' </remarks>
    Private Const WM_CLIPBOARDUPDATE As Integer = &H31D

    ''' <summary>
    ''' Register the given window to receive clipboard update messages
    ''' </summary>
    ''' <param name="hwnd">Handle of window to receive messages</param>
    ''' <returns>True on success</returns>
    ''' <remarks>
    ''' Call GetLastError to determine failure reason. (Marshal.GetLastWin32Error())
    ''' </remarks>
    <DllImport("user32", SetLastError:=True)> _
    Private Shared Function AddClipboardFormatListener(ByVal hwnd As Int32) As Boolean
    End Function
    ''' <summary>
    ''' De-register the given window to receive clipboard update messages
    ''' </summary>
    ''' <param name="hwnd">Handle of window to de-register</param>
    ''' <returns>True on success</returns>
    ''' <remarks>
    ''' Call GetLastError to determine failure reason. (Marshal.GetLastWin32Error())
    ''' </remarks>
    <DllImport("user32", SetLastError:=True)> _
    Private Shared Function RemoveClipboardFormatListener(ByVal hwnd As Int32) As Boolean
    End Function
#End Region

#Region " Clipboard Viewer Chain (Fragile and used as fallback) "
    Private Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    <DllImport("user32", CharSet:=CharSet.Auto, SetLasterror:=True)> _
    Private Shared Function SetClipboardViewer(ByVal hWndNewViewer As IntPtr) As IntPtr
    End Function

    Private Declare Auto Function ChangeClipboardChain Lib "user32" (ByVal hwndRemove As IntPtr, ByVal hwndNewNext As IntPtr) As Boolean

    Private Const ERROR_SUCCESS As Integer = 0
    ''' <summary>
    ''' Received when the clipboard changes
    ''' </summary>
    ''' <remarks>
    ''' Must be re-sent to the next in chain window
    ''' wParam: Not used and must be zero
    ''' lParam: Not used and must be zero
    ''' Return value: Zero if successfully processed
    ''' </remarks>
    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    ''' <summary>
    ''' Received when the clipboard chain changes
    ''' </summary>
    ''' <remarks>
    ''' wParam: Window being removed from the chain
    ''' lParam: New next in chain for window preceeding removed window
    ''' Return value: Zero if successfully processed
    ''' If the current next in chain is the window being removed, the new next in chain
    ''' should be stored instead. In all cases, the message should be forwarded to the next
    ''' in chain, or new next in chain if applicable.
    ''' </remarks>
    Private Const WM_CHANGECBCHAIN As Integer = &H30D
#End Region
#End Region

    ''' <summary>
    ''' Raised when the clipboard's contents have changed
    ''' </summary>
    Public Event ClipboardChanged As EventHandler

    Dim clipboardChain As Boolean = False
    Dim nextInChain As IntPtr = IntPtr.Zero
    Dim parent As Form

    ''' <summary>
    ''' Create a new clipboard listener attached to the given form
    ''' </summary>
    ''' <param name="parent">Form to attach to</param>
    ''' <exception cref="Win32Exception">Raised if an unmanaged error occurs while attaching</exception>
    Public Sub New(ByVal parent As Form)
        Me.parent = parent
        If parent.IsHandleCreated Then
            OnHandleCreated(parent, EventArgs.Empty)
        Else
            AddHandler parent.HandleCreated, AddressOf OnHandleCreated
        End If
        AddHandler parent.HandleDestroyed, AddressOf OnHandleDestroyed
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_CLIPBOARDUPDATE
                OnClipboardChanged(EventArgs.Empty)
                m.Result = IntPtr.Zero
            Case WM_DRAWCLIPBOARD
                If nextInChain <> IntPtr.Zero Then
                    SendMessage(nextInChain, WM_DRAWCLIPBOARD, Nothing, Nothing)
                End If
                OnClipboardChanged(EventArgs.Empty)
                m.Result = IntPtr.Zero
            Case WM_CHANGECBCHAIN
                If m.WParam = nextInChain Then
                    nextInChain = m.LParam
                End If
                If nextInChain <> IntPtr.Zero Then
                    SendMessage(nextInChain, WM_CHANGECBCHAIN, m.WParam, m.LParam)
                End If
                m.Result = IntPtr.Zero
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    ''' <summary>
    ''' Raises the ClipboardChanged event
    ''' </summary>
    ''' <param name="e">Event args</param>
    Protected Overridable Sub OnClipboardChanged(ByVal e As EventArgs)
        RaiseEvent ClipboardChanged(Me, e)
    End Sub

    Private Sub OnHandleCreated(ByVal sender As Object, ByVal e As EventArgs)
        AssignHandle(parent.Handle)
        Try
            If Not AddClipboardFormatListener(Me.Handle.ToInt32()) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), _
                                         "Error setting clipboard listener")
            End If
        Catch ex As EntryPointNotFoundException
            'Unsupported OS for AddClipboardFormatListener. Use fallback
            nextInChain = SetClipboardViewer(Me.Handle)
            If nextInChain = IntPtr.Zero Then
                'Could be no next window, so we have to check this
                Dim err As Integer = Marshal.GetLastWin32Error()
                If err <> ERROR_SUCCESS Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error(), _
                                             "Error adding to clipboard chain")
                End If
            End If
            clipboardChain = True
        End Try
    End Sub

    Private Sub OnHandleDestroyed(ByVal sender As Object, ByVal e As EventArgs)
        If clipboardChain Then
            'There is NO error check required here, according to MSDN
            ChangeClipboardChain(Me.Handle, nextInChain)
        Else
            If Not RemoveClipboardFormatListener(Me.Handle.ToInt32()) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), _
                                         "Error removing clipboard listener")
            End If
        End If
        ReleaseHandle()
    End Sub
End Class
