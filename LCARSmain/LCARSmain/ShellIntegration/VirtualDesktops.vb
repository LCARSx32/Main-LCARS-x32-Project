Option Strict On

Imports System.Runtime.InteropServices

Namespace VirtualDesktops
    Public Module VirtualDesktops
#Region " Structures "

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Size
            Public X As Integer
            Public Y As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Rect
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure
#End Region

#Region " COM Imports "

        Dim clsidImmersiveShell As New Guid("c2f03a33-21f5-47fa-b4bb-156362a2f239")
        Dim clsidVirtualDesktopAPIUnknown As New Guid("c5e0cdca-7b6e-41b2-9fc4-d93975cc467b")

#Region " IObjectArray "
        <ComImport(), _
        Guid("92ca9dcd-5622-4bba-a805-5e9f541bd8c9"), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
        Private Interface IObjectArray
            Function GetCount() As UInteger

            'TODO: Check that this actually works
            Function GetAt(ByVal iIndex As UInteger, _
                           ByRef riid As Guid, _
                           <Out(), MarshalAs(UnmanagedType.Interface)> _
                           ByVal ppvObject As Object) _
                           As Object
        End Interface

#End Region

#Region " Virtual Desktop Manager "
        ''' <summary>
        ''' Manages virtual desktops on Windows 10 Systems
        ''' </summary>
        ''' <remarks>
        ''' Thanks to Chris Lewis for his post on the Windows SDK Support Team Blog:
        ''' https://blogs.msdn.microsoft.com/winsdk/2015/09/10/virtual-desktop-switching-in-windows-10/
        ''' </remarks>

        <ComImport(), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
        GuidAttribute("a5cd92ff-29be-454c-8d04-d82879fb3f1b")> _
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

        <ComImport(), _
        Guid("aa509086-5ca9-4c25-8f95-589d3c07b48a")> _
        Private Class CVirtualDesktopManager
        End Class
#End Region

#Region " Virtual Desktop Manager (Internal) "
        'TODO: Add copies with appropriate GUID for older systems
        <ComImport(), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
        Guid("f31574d6-b682-4cdc-bd56-1827860abec6")> _
        Private Interface IVirtualDesktopManagerInternal14328
            Function GetCount() As Integer

            Sub MoveViewToDesktop(ByRef pView As IApplicationView, ByRef desktop As IVirtualDesktop)

            Function CanViewMoveDesktops(ByRef pView As IApplicationView) As Boolean

            Function GetCurrentDesktop() As IVirtualDesktop

            Function GetDesktops() As IObjectArray

            Function GetAdjacentDesktop(ByRef pDesktopReference As IVirtualDesktop, ByVal uDirection As AdjacentDesktop) As IVirtualDesktop

            Sub SwitchDesktop(ByRef desktop As IVirtualDesktop)

            Function CreateDesktopW() As IVirtualDesktop

            Sub RemoveDesktop(ByRef pRemove As IVirtualDesktop, ByRef pFallbackDesktop As IVirtualDesktop)

            Function FindDesktop(ByRef desktopId As Guid) As IVirtualDesktop

        End Interface

        Private Enum AdjacentDesktop As Integer
            left = 3
            right = 4
        End Enum
#End Region

#Region " IApplicationView "
        <ComImport(), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
        Guid("9ac0b5c8-1484-4c5b-9533-4134a0f97cea")> _
        Private Interface IApplicationView
            'TODO: Fill out interface definition
        End Interface
#End Region

#Region " IVirtualDesktop "
        <ComImport(), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
        Guid("FF72FFDD-BE7E-43FC-9C03-AD81681E88E4")> _
        Private Interface IVirtualDesktop
            <PreserveSig()> _
            Function IsViewVisible(<[In]()> ByRef pView As IApplicationView, _
                                   <Out()> ByRef pVisible As Integer) _
                                   As Integer
            <PreserveSig()> _
            Function GetID(<Out()> ByRef pGuid As Guid) As Integer
        End Interface
#End Region

#Region " IServiceProvider "
        <ComImport(), _
        Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
        ComVisible(False)> _
        Private Interface IServiceProvider
            <PreserveSig()> _
            Function QueryService(<[In]()> ByRef guidService As Guid, _
                                  <[In]()> ByRef riid As Guid, _
                                  <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppvObject As Object) _
                                  As <MarshalAs(UnmanagedType.I4)> Integer

        End Interface
#End Region

#End Region

        Private supportedOS As Boolean = False
        Private Imanager As IVirtualDesktopManager
        Private Cmanager As CVirtualDesktopManager
        Private managerInternal As IVirtualDesktopManagerInternal14328

        Public Sub Init()
            Try
                Cmanager = New CVirtualDesktopManager()
                Imanager = CType(Cmanager, IVirtualDesktopManager)
                supportedOS = Not shellMode
            Catch ex As COMException
            End Try
            Try
                'TODO: Figure out why this doesn't work in shell mode
                Dim shelltype As Type = Type.GetTypeFromCLSID(clsidImmersiveShell)
                Dim shell As IServiceProvider = CType(Activator.CreateInstance(shelltype), IServiceProvider)
                Dim ppvObject As Object = Nothing
                shell.QueryService(clsidVirtualDesktopAPIUnknown, GetType(IVirtualDesktopManagerInternal14328).GUID, ppvObject)
                managerInternal = CType(ppvObject, IVirtualDesktopManagerInternal14328)
            Catch ex As COMException
                Debug.Print("Failed to create internal desktop manager")
            End Try
        End Sub

        Public Function IsWindowOnCurrentVirtualDesktop(ByVal TopLevelWindow As IntPtr) As Boolean
            If Not supportedOS Then Return True
            Dim result As Integer
            Dim hresult As Integer
            hresult = Imanager.IsWindowOnCurrentDesktop(TopLevelWindow, result)
            If hresult <> 0 Then
                Marshal.ThrowExceptionForHR(hresult)
            End If
            Return result <> 0
        End Function

        Public Function GetWindowDesktopID(ByVal TopLevelWindow As IntPtr) As Guid
            If Not supportedOS Then Return Guid.Empty
            Dim result As Guid
            Dim hresult As Integer
            hresult = Imanager.GetWindowDesktopID(TopLevelWindow, result)
            If hresult <> 0 Then
                Marshal.ThrowExceptionForHR(hresult)
            End If
            Return result
        End Function

        Public Sub MoveWindowToDesktop(ByVal TopLevelWindow As IntPtr, ByVal CurrentDesktop As Guid)
            If Not supportedOS Then Return
            Dim hresult As Integer
            hresult = Imanager.MoveWindowToDesktop(TopLevelWindow, CurrentDesktop)
            If hresult <> 0 Then
                Marshal.ThrowExceptionForHR(hresult)
            End If
        End Sub
    End Module
End Namespace
