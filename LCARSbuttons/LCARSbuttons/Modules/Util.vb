Imports System.Drawing

''' <summary>
''' Contains utility functions for general use.
''' </summary>
''' <remarks>
''' This is the module for various things that don't fit in anywhere else, but are used in multiple places.
''' </remarks>
<HideModuleName()> _
Public Module Util
    ''' <summary>
    ''' Returns HTML-formatted color as a 7-character string.
    ''' </summary>
    ''' <param name="myColor">Color to translate to a string.</param>
    ''' <returns>String representation of input color.</returns>
    ''' <remarks>
    ''' Used in a few places, but mostly by the Alerts module. The string will always be in the format #RRGGBB, so you 
    ''' can be assured that it is a constant length.
    ''' </remarks>
    Public Function GetHexColor(ByVal myColor As Color) As String
        Dim myString As String = "#"
        Dim temp As String = Hex(myColor.R)
        If temp.Length = 1 Then
            temp = "0" & temp
        End If
        myString = myString & temp
        temp = Hex(myColor.G)
        If temp.Length = 1 Then
            temp = "0" & temp
        End If
        myString = myString & temp
        temp = Hex(myColor.B)
        If temp.Length = 1 Then
            temp = "0" & temp
        End If
        myString = myString & temp
        Return myString
    End Function

End Module
