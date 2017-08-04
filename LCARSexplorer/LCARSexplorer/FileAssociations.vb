Imports Microsoft.Win32

Module FileAssociations
    Public Function GetTypeOpenWith(ByVal type As String) As String
        Try
            'Find the exension's key
            Dim extKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(type)
            If extKey Is Nothing Then
                Return "Extension not registered"
            End If
            Dim extDefault As String = CStr(extKey.GetValue(String.Empty, String.Empty))
            If extDefault = String.Empty Then
                'Check for PersistentHandler?
                Return "Handler not registered"
            Else
                'Find the handler's key
                Dim handlerKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(extDefault)
                If handlerKey Is Nothing Then Return "Registered handler deleted"
                'Check for shell interaction subkey
                Dim shellKey As RegistryKey = handlerKey.OpenSubKey("shell", False)
                If shellKey Is Nothing Then Return "No shell handler found"
                'Get default verb
                Dim verbs() As String = shellKey.GetSubKeyNames()
                Dim defaultVerb As String = CStr(shellKey.GetValue(String.Empty))
                If String.IsNullOrEmpty(defaultVerb) Then
                    defaultVerb = verbs(0)
                End If
                'Find command for verb
                Dim verbKey As RegistryKey = shellKey.OpenSubKey(defaultVerb)
                If verbKey Is Nothing Then verbKey = shellKey.OpenSubKey(verbs(0))
                Dim commandKey As RegistryKey = verbKey.OpenSubKey("Command")
                If commandKey Is Nothing Then Return "Shell command not defined (May be other handler)"
                Return CStr(commandKey.GetValue(String.Empty, String.Empty))
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

End Module
