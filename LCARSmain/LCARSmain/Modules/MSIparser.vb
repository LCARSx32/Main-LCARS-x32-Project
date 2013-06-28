Imports System.Runtime.InteropServices
Imports System.Text


Public Class MSIparser
    <DllImport("msi.dll", CharSet:=CharSet.Auto)> _
    Friend Shared Function MsiGetShortcutTarget(ByVal targetFile As String, ByVal productCode As StringBuilder, ByVal featureID As StringBuilder, ByVal componentCode As StringBuilder) As Integer
    End Function

    Enum InstallState
        NotUsed = -7
        BadConfig = -6
        Incomplete = -5
        SourceAbsent = -4
        MoreData = -3
        InvalidArg = -2
        Unknown = -1
        Broken = 0
        Advertised = 1
        Removed = 1
        Absent = 2
        Local = 3
        Source = 4
    End Enum

    Public Const MaxFeatureLength As Integer = 38
    Public Const MaxGuidLength As Integer = 38
    Public Const MaxPathLength As Integer = 1024


    'INSTALLSTATE MsiGetComponentPath(
    '  LPCTSTR szProduct,
    '  LPCTSTR szComponent,
    '  LPTSTR lpPathBuf,
    '  DWORD* pcchBuf
    ');

    <DllImport("msi.dll", CharSet:=CharSet.Auto)> _
    Friend Shared Function MsiGetComponentPath(ByVal productCode As String, ByVal componentCode As String, ByVal componentPath As StringBuilder, ByRef componentPathBufferSize As Integer) As InstallState
    End Function

    Public Function ParseShortcut(ByVal file As String) As String

        Dim product As StringBuilder = New StringBuilder(MaxGuidLength + 1)
        Dim feature As StringBuilder = New StringBuilder(MaxFeatureLength + 1)
        Dim component As StringBuilder = New StringBuilder(MaxGuidLength + 1)

        MsiGetShortcutTarget(file, product, feature, component)

        Dim pathLength As Integer = MaxPathLength
        Dim path As StringBuilder = New StringBuilder(pathLength)

        Dim installState As InstallState = MsiGetComponentPath(product.ToString(), component.ToString(), path, pathLength)

        If installState = installState.Local Then
            Return path.ToString()
        Else
            Return Nothing
        End If

    End Function






End Class
