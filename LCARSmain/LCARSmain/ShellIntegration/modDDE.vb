Imports System.Runtime.InteropServices
Imports System.ComponentModel

Module modDDE
#Region " Constants "
    ''' <summary>
    ''' Initiate a DDE conversation
    ''' </summary>
    ''' <remarks>
    ''' Use SendMessage for this DDE message ONLY.
    ''' wParam: Handle to client window sending the message
    ''' lParam low-order word: atom that identifies the application requested.
    ''' lParam high-order word: atom that identifies the topic requested.
    ''' NULL lParam section indicates that all applications or topics are requested.
    ''' 
    ''' This message may be sent to all windows via HWND_BROADCAST or to a specific server window
    ''' directly.
    ''' 
    ''' The CLIENT is responsible for deleting the atoms after SendMessage returns.
    ''' 
    ''' Atoms cannot be reused in a WM_DDE_ACK message. The server must create new atoms.
    ''' </remarks>
    Public Const WM_DDE_INITIATE As Integer = WM_DDE_FIRST
    Public Const WM_DDE_TERMINATE As Integer = WM_DDE_FIRST + 1
    Public Const WM_DDE_ADVISE As Integer = WM_DDE_FIRST + 2
    Public Const WM_DDE_UNADVISE As Integer = WM_DDE_FIRST + 3
    ''' <summary>
    ''' Acknowledge a message
    ''' </summary>
    ''' <remarks>
    ''' Use SendMessage if responding to WM_DDE_INITIATE. Use PostMessage otherwise.
    ''' wParam: Handle to window sending/posting the message
    ''' 
    ''' When responding to WM_DDE_INITIATE:
    ''' lParam low-order word: Atom that identifies the replying application
    ''' lParam high-order word: Atom that identifies the topic of the conversation
    ''' 
    ''' When responding to WM_DDE_EXECUTE:
    ''' lParam low-order word: DDEACK structure specifying the state of the response
    ''' lParam high-order word: Handle to a global memory object that contains the command string
    '''     sent in the WM_DDE_EXECUTE message.
    ''' 
    ''' All other messages:
    ''' lParam low-order word: DDEACK structure specifying the state of the response
    ''' lParam high-order word: Global atom specifying the name of the data being responded to.
    ''' </remarks>
    Public Const WM_DDE_ACK As Integer = WM_DDE_FIRST + 4
    Public Const WM_DDE_DATA As Integer = WM_DDE_FIRST + 5
    Public Const WM_DDE_REQUEST As Integer = WM_DDE_FIRST + 6
    Public Const WM_DDE_POKE As Integer = WM_DDE_FIRST + 7
    Public Const WM_DDE_EXECUTE As Integer = WM_DDE_FIRST + 8
#End Region

#Region " Structures "
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DDEACK
        Private usFlags As UShort
        Public Property bAppReturnCode() As UShort
            Get
                Return (usFlags And &HFF00) >> 8
            End Get
            Set(ByVal value As UShort)
                If value > &HFF Then Throw New  _
                        ArgumentException("Return code must be no more than than 0xFF")
                usFlags = (usFlags And &HFF) Or (value << 8)
            End Set
        End Property
        Public Property fBusy() As Boolean
            Get
                Return (usFlags And &H2) = 2
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or &H2
                Else
                    usFlags = usFlags And &HFFFD
                End If
            End Set
        End Property
        Public Property fAck() As Boolean
            Get
                Return (usFlags And &H1) = 1
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or &H1
                Else
                    usFlags = usFlags And &HFFFE
                End If
            End Set
        End Property
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DDEADVISE
        Private usFlags As UShort
        Public Property fDeferUpd() As Boolean
            Get
                Return (usFlags And &H2) = 2
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or &H2
                Else
                    usFlags = usFlags And &HFFFD
                End If
            End Set
        End Property
        Public Property fAckReq() As Boolean
            Get
                Return (usFlags And &H1) = 1
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or &H1
                Else
                    usFlags = usFlags And &HFFFE
                End If
            End Set
        End Property
        Public cfFormat As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DDEDATA
        Private usFlags As UShort
        Public Property fResponse() As Boolean
            Get
                Return (usFlags And &H8) = 8
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or 8
                Else
                    usFlags = usFlags And &HFFF7
                End If
            End Set
        End Property
        Public Property fRelease() As Boolean
            Get
                Return (usFlags And &H4) = 4
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or 4
                Else
                    usFlags = usFlags And &HFFFB
                End If
            End Set
        End Property
        Public Property fAckReq() As Boolean
            Get
                Return (usFlags And &H1) = 1
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or 1
                Else
                    usFlags = usFlags And &HFFFE
                End If
            End Set
        End Property
        Public cfFormat As Short
        'TODO: Verify that the variable-size array marshals correctly
        Public Value As Byte()
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DDEPOKE
        Private usFlags As UShort
        Public Property fRelease() As Boolean
            Get
                Return (usFlags And &H4) = 4
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    usFlags = usFlags Or 4
                Else
                    usFlags = usFlags And &HFFFB
                End If
            End Set
        End Property
        Public cfFormat As Short
        Public Value As Byte()
    End Structure
#End Region

#Region " Function imports "
#Region " DDE "
    Public Declare Function PackDDElParam Lib "User32" (ByVal msg As UInteger, _
                                                        ByVal uiLo As UIntPtr, _
                                                        ByVal uiHi As UIntPtr) _
                                                        As IntPtr
    Public Declare Function UnpackDDElParam Lib "User32" (ByVal msg As UInteger, _
                                                          ByRef puiLo As UIntPtr, _
                                                          ByRef puiHi As UIntPtr) _
                                                          As Boolean
    Public Declare Function FreeDDElParam Lib "User32" (ByVal msg As UInteger, _
                                                        ByVal lParam As IntPtr) _
                                                        As Boolean
    Public Declare Function ReuseDDElParam Lib "User32" (ByVal lParam As IntPtr, _
                                                         ByVal msgIn As UInteger, _
                                                         ByVal msgOut As UInteger, _
                                                         ByVal uiLo As UIntPtr, _
                                                         ByVal uiHi As UIntPtr) _
                                                         As IntPtr
#End Region

    'Note: Imported by ORDINAL, not by name.
    <DllImport("shell32", EntryPoint:="#188")> _
    Private Sub ShellDDEInit(ByVal init As Boolean)
    End Sub
#End Region

    Public Sub handleDDE(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_DDE_ACK
                Debug.Print("DDE ACK")
            Case WM_DDE_ADVISE
                Debug.Print("DDE ADVISE")
            Case WM_DDE_DATA
                Debug.Print("DDE DATA")
            Case WM_DDE_EXECUTE
                Debug.Print("DDE EXECUTE")
            Case WM_DDE_INITIATE
                Debug.Print("DDE INITIATE")
            Case WM_DDE_POKE
                Debug.Print("DDE POKE")
            Case WM_DDE_REQUEST
                Debug.Print("DDE REQUEST")
            Case WM_DDE_TERMINATE
                Debug.Print("DDE TERMINATE")
            Case WM_DDE_UNADVISE
                Debug.Print("DDE UNADVISE")
            Case Else
                Debug.Print("Bad DDE message: {0}. Check code.", m.Msg)
        End Select
    End Sub

    Public Sub initDDE()
        'Create atoms?
        Try
            ShellDDEInit(True)
        Catch ex As EntryPointNotFoundException
            Debug.Print("Bad entry point")
        End Try
    End Sub

    Public Sub deinitDDE()
        Try
            ShellDDEInit(False)
        Catch ex As EntryPointNotFoundException
            Debug.Print("Bad entry point")
        End Try
    End Sub
End Module
