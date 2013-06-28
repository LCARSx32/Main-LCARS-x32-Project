Imports System.Management

Public Class clsWMI

    '    Dim memTypes As String
    '         "Unknown= 0
    '1 = "Other"
    '2 = "SIP"
    '3 = "DIP"
    '4 = "ZIP"
    '5 = "SOJ"
    '6 = "Proprietary"
    '7 = "SIMM"
    '8 = "DIMM"
    '9 = "TSOP"
    '10 = "PGA"
    '11 = "RIMM"
    '12 = "SODIMM"
    '13 = "SRIMM"
    '14 = "SMD"
    '15 = "SSMP"
    '16 = "QFP"
    '17 = "TQFP"
    '18 = "SOIC"
    '19 = "LCC"
    '20 = "PLCC"
    '21 = "BGA"
    '22 = "FPBGA"
    '23 = "LGA"
    '    End Enum

    Private objOSsearch As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
    Private objCSsearch As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
    Private objMEMSearch As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory")

    Dim objOS(-1) As ManagementObject
    Dim objCS(-1) As ManagementObject
    Dim objMem(-1) As ManagementObject

    Private m_strComputerName As String
    Private m_strManufacturer As String
    Private m_StrModel As String
    Private m_strOSName As String
    Private m_strOSVersion As String
    Private m_strSystemType As String
    Private m_strTPM As String
    Private m_strWindowsDir As String
    Private m_strBootupState As String
    Private m_strSystemName As String
    Private m_strLogicalProcCount As String
    Private m_strPhysicalProcCount As String
    Private m_strMemoryCapacity As String



    Dim strProps(-1) As String


    Public Sub New()
        ReDim objOS(objOSsearch.Get.Count - 1)
        objOSsearch.Get.CopyTo(objOS, 0)

        ReDim objCS(objCSsearch.Get.Count - 1)
        objCSsearch.Get.CopyTo(objCS, 0)

        ReDim objMem(objMEMSearch.Get.Count - 1)
        objMEMSearch.Get.CopyTo(objMem, 0)

        Dim myProps As PropertyDataCollection
        For Each myObject As System.Management.ManagementObject In objOS
            myProps = myObject.Properties
            For Each myProp As PropertyData In myProps
                Dim myText As String
                myText = myProp.Name & " = "
                If Not myProp.Value Is Nothing Then

                    If IsArray(myProp.Value) Then
                        myText += String.Join("-", myProp.Value)
                    Else
                        myText += myProp.Value.ToString
                    End If

                Else
                    myText += "--"
                End If

                ReDim Preserve strProps(strProps.GetUpperBound(0) + 1)
                strProps(strProps.GetUpperBound(0)) = myText
            Next
            ReDim Preserve strProps(strProps.GetUpperBound(0) + 1)
            strProps(strProps.GetUpperBound(0)) = vbNewLine
        Next


    End Sub


    Public ReadOnly Property PropertyList() As String()
        Get
            Return strProps
        End Get
    End Property

    Public ReadOnly Property ComputerName() As String
        Get
            Return objOS(0)("csname").ToString()
        End Get

    End Property
    Public ReadOnly Property Manufacturer() As String
        Get
            Return objCS(0)("manufacturer").ToString()
        End Get

    End Property
    Public ReadOnly Property Model() As String
        Get
            Return objCS(0)("Model").ToString()
        End Get

    End Property
    Public ReadOnly Property OsName() As String
        Get
            Return objOS(0)("name").ToString()
        End Get

    End Property

    Public ReadOnly Property OSVersion() As String
        Get
            Return objOS(0)("version").ToString()
        End Get

    End Property
    Public ReadOnly Property SystemType() As String
        Get
            Return objCS(0)("systemtype").ToString
        End Get

    End Property
    Public ReadOnly Property TotalPhysicalMemory() As String
        Get
            Return objCS(0)("totalphysicalmemory").ToString()
        End Get

    End Property

    Public ReadOnly Property WindowsDirectory() As String
        Get
            Return objOS(0)("windowsdirectory").ToString()
        End Get

    End Property

    Public ReadOnly Property BootupState() As String
        Get
            Return objCS(0)("BootupState").ToString()
        End Get
    End Property

    Public ReadOnly Property SystemName() As String
        Get
            Return objCS(0)("Name").ToString
        End Get
    End Property

    Public ReadOnly Property LogicalProcessorCount() As String
        Get
            Return objCS(0)("NumberOfLogicalProcessors").ToString
        End Get
    End Property

    Public ReadOnly Property PhysicalProcessorCount() As String
        Get
            Return objCS(0)("NumberOfProcessors").ToString
        End Get
    End Property

    Public ReadOnly Property PhysicalMemoryCapacity() As String
        Get
            Dim totalMem As Long

            For Each myMem As System.Management.ManagementObject In objMem
                totalMem += CDbl(myMem("Capacity"))
            Next

            Return totalMem
        End Get
    End Property

    Public ReadOnly Property MemoryInfo() As String
        Get
            Dim myInfo As String = ""
            For Each myMem As System.Management.ManagementObject In objMem
                Dim Suffix As String = "B"
                Dim memSize As Integer

                memSize = myMem("Capacity")
                If memSize >= 1024 Then
                    memSize = memSize / 1024
                    Suffix = "KB"
                    If memSize >= 1024 Then
                        memSize = memSize / 1024
                        Suffix = "MB"
                        If memSize >= 1024 Then
                            memSize = memSize / 1024
                            Suffix = "GB"
                            If memSize >= 1024 Then
                                'TeraBytes of RAM?!
                                memSize = memSize / 1024
                                Suffix = "TB"
                            End If
                        End If
                    End If
                End If
                myInfo += "BANK: " & myMem("BankLabel") & " - CAPACITY: " & memSize & Suffix & " - DATA WIDTH: " & myMem("DataWidth") & " Bits - FORM FACTOR: " & myMem("FormFactor") & vbNewLine
            Next

            Return myInfo

        End Get
    End Property

End Class

