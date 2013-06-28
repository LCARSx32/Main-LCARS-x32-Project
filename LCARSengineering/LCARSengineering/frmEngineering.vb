Public Class frmEngineering
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
#End Region

    Dim pData As Object
    Dim myWMI As Object
    Dim WMIavailable As Boolean = False

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID And m.LParam = 13 Then
            Me.Close()
            End

        ElseIf m.Msg = WM_COPYDATA And m.WParam = x32Handle And Not x32Handle = IntPtr.Zero Then
            Dim myData As New COPYDATASTRUCT
            myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))

            Dim myRect As New Rectangle
            myRect = System.Runtime.InteropServices.Marshal.PtrToStructure(myData.lpData, GetType(Rectangle))

            If Not Me.Bounds = myRect Then
                Me.Bounds = myRect
            End If

        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub tmrSysMon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSysMon.Tick
        'FileOpen(1, Application.StartupPath & "\eLog.txt", OpenMode.Output)
        Dim val As Integer = pData.getCPU
        'PrintLine(1, "Got CPU data.")


        liproc.Value = val
        'PrintLine(1, "Set CPU meter.")

        Dim myMem As Memory.MEMORYSTATUS = pData.memory.getmemory
        'PrintLine(1, "Got MemoryStatus object.")


        Dim totalMem As Int64 = (myMem.dwTotalPhys.ToUInt64() \ 1024) \ 1024
        'PrintLine(1, "Got total physical memory.")



        If (myMem.dwTotalPhys.ToUInt64() \ 1024) Mod 1024 > 0 Then
            totalMem += 1
        End If

        If totalMem >= 1024 Then
            lblMemTotal.Text = totalMem / 1024 & "GB"
        Else
            lblMemTotal.Text = totalMem & "MB"
        End If
        'PrintLine(1, "Parsed memory data.")


        Dim usedPercent As Integer = ((myMem.dwTotalPhys.ToUInt64() - myMem.dwAvailPhys.ToUInt64()) / myMem.dwTotalPhys.ToUInt64()) * 100
        'PrintLine(1, "Got used memory percentage.")

        liMem.Value = usedPercent
        'PrintLine(1, "Set used memory meter.")

        If WMIavailable = True Then
            'PrintLine(1, "WMI Available = TRUE")

            totalMem = (myWMI.PhysicalMemoryCapacity / 1024) / 1024
            'PrintLine(1, "Got WMI Total Physical Memory.")

            If totalMem >= 1024 Then
                Label2.Text = Math.Round(totalMem / 1024, 2) & "GB"
            Else
                Label2.Text = Math.Round(totalMem) & "MB"
            End If
            'PrintLine(1, "Parsed WMI memory.")

            Dim OSinfo() As String = myWMI.OsName.Split("|")
            'PrintLine(1, "Got OSInfo object.")

            lblMan.Text = myWMI.Manufacturer.ToUpper
            'PrintLine(1, "Got Manufacturer.")

            lblModel.Text = myWMI.Model.ToUpper
            'PrintLine(1, "Got Model.")

            lblOS.Text = OSinfo(0).ToUpper
            'PrintLine(1, "Got OS Text.")

            lblOSver.Text = myWMI.OSVersion.ToUpper
            'PrintLine(1, "Got OS version.")

            lblOSpart.Text = OSinfo(2).ToUpper
            'PrintLine(1, "Got OS partition.")

            lblOSDir.Text = OSinfo(1).ToUpper
            'PrintLine(1, "Got System Directory.")

            Try
                lblBootupState.Text = myWMI.BootupState.ToUpper
                'PrintLine(1, "Got Bootup state.")
            Catch ex As Exception

            End Try
            Try
                lblSystemName.Text = myWMI.SystemName.ToUpper
                'PrintLine(1, "Got System name.")
            Catch ex As Exception

            End Try
            Try
                lblPysProcCount.Text = myWMI.PhysicalProcessorCount.ToUpper
                'PrintLine(1, "Got Physical Processor Count.")
            Catch ex As Exception

            End Try
            Try
                lblLogProcCount.Text = myWMI.LogicalProcessorCount.ToUpper
                'PrintLine(1, "Got Logical Processor count.")
            Catch
            End Try


            Try
                lblMemInfo.Text = String.Join(vbNewLine, myWMI.PropertyList).ToUpper

                'PrintLine(1, "Got memory info.")
            Catch
            End Try
        Else
            'PrintLine(1, "WMI Available = FALSE")
        End If


        'PrintLine(1, "Got to end of timer.")
        'FileClose(1)

    End Sub

    Private Sub frmEngineering_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            pData.Terminate()
        End If
    End Sub

    Private Sub frmEngineering_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(x32Handle, InterMsgID, Me.Handle, 1)

        Me.Bounds = Screen.PrimaryScreen.WorkingArea

        If System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            pData = New Win98Data
            If pData.init = False Then
                MsgBox("Error initializing performance data.")
            End If
        Else
            pData = New WinNTData
        End If

        Try
            myWMI = New clsWMI
            pnlWMIdata.Visible = True
            WMIavailable = True
        Catch ex As Exception
            lblWMImessage.Visible = True
        End Try
        tmrSysMon_Tick(sender, e)

        tmrSysMon.Enabled = True

        'Dim myProps() As String = myWMI.PropertyList

        'For Each myProp As String In myProps
        '    ListBox1.Items.Add(myProp)
        'Next
    End Sub

    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
    End Sub

    Private Sub StandardButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub LevelIndicator1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(liProc.Size.ToString)
    End Sub

    Private Sub fbTopBorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub pnlWMIdata_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlWMIdata.Paint

    End Sub

    Private Sub label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label18.Click

    End Sub
End Class


Public Class Win98Data

    Dim hKey As Microsoft.Win32.RegistryKey
    Public Memory As New Memory

    Public Function Init() As Boolean

        Try
            'start the counter by reading the value of the 'StartStat' key
            hKey = Microsoft.Win32.Registry.DynData
            hKey = hKey.OpenSubKey("PerfStats\StartStat", True)
            hKey.GetValue("KERNEL\CPUUsage").ToString()

            'get current counter's value
            hKey = Microsoft.Win32.Registry.DynData
            hKey = hKey.OpenSubKey("PerfStats\StatData")

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetCPU() As Integer
        Dim result As Byte() = hKey.GetValue("KERNEL\CPUUsage", 0)
        Return CInt(result(0))
    End Function

   


    Public Sub Terminate()
        hKey.Close()

        'stopping the counter
        hKey = Microsoft.Win32.Registry.DynData
        hKey = hKey.OpenSubKey("PerfStats\StopStat", True)

        hKey.GetValue("KERNEL\CPUUsage", 0)
        hKey.Close()
    End Sub
End Class

Public Class WinNTData
    Dim myProcUsage As New System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total")
    Dim ramCounter As New System.Diagnostics.PerformanceCounter("Memory", "Available MBytes")
    Dim myInfo As New Devices.ComputerInfo
    Public Memory As New Memory

    Public ReadOnly Property GetCPU() As Integer
        Get
            Return CInt(myProcUsage.NextValue)
        End Get
    End Property

    Public ReadOnly Property GetMemUsed() As Integer
        Get
            Return myInfo.TotalPhysicalMemory - ramCounter.NextValue
        End Get
    End Property

    Public ReadOnly Property GetMemRemaining() As Integer
        Get
            Return ramCounter.NextValue
        End Get
    End Property

    Public ReadOnly Property GetTotalPhysicalMemory() As Integer
        Get
            Return myInfo.TotalPhysicalMemory()
        End Get
    End Property
End Class

Public Class Memory
    'Public Structure MEMORYSTATUS
    '    Dim dwLength As Integer
    '    Dim dwMemoryLoad As Integer
    '    Dim dwTotalPhys As Int64
    '    Dim dwAvailPhys As Int64
    '    Dim dwTotalPageFile As Integer
    '    Dim dwAvailPageFile As Integer
    '    Dim dwTotalVirtual As Integer
    '    Dim dwAvailVirtual As Integer
    'End Structure
    Public Structure MEMORYSTATUS
        Dim dwLength As UInt32
        Dim dwMemoryLoad As UInt32
        Dim dwTotalPhys As UIntPtr
        Dim dwAvailPhys As UIntPtr
        Dim dwTotalPageFile As UIntPtr
        Dim dwAvailPageFile As UIntPtr
        Dim dwTotalVirtual As UIntPtr
        Dim dwAvailVirtual As UIntPtr
    End Structure

    Private Declare Function GlobalMemoryStatus Lib "kernel32" _
           (ByRef ms As MEMORYSTATUS) As Integer

    Public Function GetMemory() As MEMORYSTATUS
        Dim ms As MEMORYSTATUS
        'ms.dwLength = Len(ms)
        GlobalMemoryStatus(ms)
        Return ms
        ms = Nothing
    End Function
End Class