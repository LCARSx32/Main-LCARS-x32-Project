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

    ''' <summary>
    ''' Sets the beeping of a control and all subcontrols
    ''' </summary>
    ''' <param name="Container">The control to set the beeping for</param>
    ''' <param name="Beeping">The beeping value to use</param>
    ''' <remarks>
    ''' If you are using windowless controls, the <see cref="Controls.WindowlessContainer">Windowless 
    ''' Container</see> will set the beeping for all of its windowless controls if its own beeping is set.
    ''' </remarks>
    Public Sub SetBeeping(ByVal Container As System.Windows.Forms.Control, ByVal Beeping As Boolean)
        Dim temp As IBeeping = TryCast(Container, IBeeping)
        If Not temp Is Nothing Then
            temp.Beeping = Beeping
        End If
        For Each myControl As System.Windows.Forms.Control In Container.Controls
            SetBeeping(myControl, Beeping)
        Next
    End Sub

    ''' <summary>
    ''' Sets the beeping of a control and all subcontrols to the system default
    ''' </summary>
    ''' <param name="Container">The control to set beeping for</param>
    ''' <remarks>
    ''' If you are using windowless controls, the <see cref="Controls.WindowlessContainer">Windowless 
    ''' Container</see> will set the beeping for all of its windowless controls if its own beeping is set.
    ''' </remarks>
    Public Sub SetBeeping(ByVal Container As System.Windows.Forms.Control)
        SetBeeping(Container, x32.modSettings.ButtonBeep)
    End Sub

    ''' <summary>
    ''' Reloads all colors from the registry for the specified container
    ''' </summary>
    ''' <param name="Container">The control to reload the colors for.</param>
    Public Sub UpdateColors(ByVal Container As System.Windows.Forms.Control)
        Dim temp As IColorable
        temp = TryCast(Container, IColorable)
        If Not temp Is Nothing Then
            temp.ColorsAvailable.ReloadColors()
        End If
        For Each myControl As System.Windows.Forms.Control In Container.Controls
            UpdateColors(myControl)
        Next
    End Sub

    ''' <summary>
    ''' Equivalent to DeleteSetting, but will not throw ArgumentException
    ''' </summary>
    ''' <returns>True if setting existed to be deleted</returns>
    Public Function TryDeleteSetting(ByVal AppName As String, Optional ByVal Section As String = Nothing, Optional ByVal Key As String = Nothing)
        Try
            DeleteSetting(AppName, Section, Key)
            Return True
        Catch ex As ArgumentException
            Return False
        End Try
    End Function
End Module
