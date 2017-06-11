Option Strict On

Imports System.Runtime.InteropServices


Public Class VirtualDesktops

    ''' <summary>
    ''' Manages virtual desktops on Windows 10 Systems
    ''' </summary>
    ''' <remarks>
    ''' Thanks to Chris Lewis for his post on the Windows SDK Support Team Blog:
    ''' https://blogs.msdn.microsoft.com/winsdk/2015/09/10/virtual-desktop-switching-in-windows-10/
    ''' 
    ''' The code here is very similar, with some additional changes to handle operating on systems
    ''' without the virtual desktop API
    ''' </remarks>

    <ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("a5cd92ff-29be-454c-8d04-d82879fb3f1b")> _
    Private Interface IVirtualDesktopManager
        <PreserveSig()> _
        Function IsWindowOnCurrentDesktop(<[In]()> ByVal TopLevelWindow As IntPtr, _
                                          <Out()> ByRef OnCurrentDesktop As Integer) _
                                          As Integer

        <PreserveSig()> _
        Function GetWindowDesktopID(<[In]()> ByVal TopLevelWindow As IntPtr, _
                                    <Out()> ByRef CurrentDesktop As Guid) _
                                    As Integer
        <PreserveSig()> _
        Function MoveWindowToDesktop(<[In]()> ByVal TopLevelWindow As IntPtr, _
                                     <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal CurrentDesktop As Guid) _
                                     As Integer
    End Interface

    <ComImport(), Guid("aa509086-5ca9-4c25-8f95-589d3c07b48a")> _
    Private Class CVirtualDesktopManager
    End Class

    Private Imanager As IVirtualDesktopManager
    Private Cmanager As CVirtualDesktopManager

    Public Sub New()
        Try
            Cmanager = New CVirtualDesktopManager()
            Imanager = CType(Cmanager, IVirtualDesktopManager)
        Catch ex As COMException
            Cmanager = Nothing
            Imanager = Nothing
        End Try
    End Sub

    Public Function IsWindowOnCurrentVirtualDesktop(ByVal TopLevelWindow As IntPtr) As Boolean
        If Imanager Is Nothing Then Return True
        Dim result As Integer
        Dim hresult As Integer
        hresult = Imanager.IsWindowOnCurrentDesktop(TopLevelWindow, result)
        If hresult <> 0 Then
            Marshal.ThrowExceptionForHR(hresult)
        End If
        Return result <> 0
    End Function

    Public Function GetWindowDesktopID(ByVal TopLevelWindow As IntPtr) As Guid
        If Imanager Is Nothing Then Return Guid.Empty
        Dim result As Guid
        Dim hresult As Integer
        hresult = Imanager.GetWindowDesktopID(TopLevelWindow, result)
        If hresult <> 0 Then
            Marshal.ThrowExceptionForHR(hresult)
        End If
        Return result
    End Function

    Public Sub MoveWindowToDesktop(ByVal TopLevelWindow As IntPtr, ByVal CurrentDesktop As Guid)
        If Imanager Is Nothing Then Return
        Dim hresult As Integer
        hresult = Imanager.MoveWindowToDesktop(TopLevelWindow, CurrentDesktop)
        If hresult <> 0 Then
            Marshal.ThrowExceptionForHR(hresult)
        End If
    End Sub
End Class
