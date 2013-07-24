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

    Public Sub SetBeeping(ByVal Container As System.Windows.Forms.Control, ByVal Beeping As Boolean)
        Dim temp As IBeeping = TryCast(Container, IBeeping)
        If Not temp Is Nothing Then
            temp.Beeping = Beeping
        End If
        For Each myControl As System.Windows.Forms.Control In Container.Controls
            SetBeeping(myControl, Beeping)
        Next
        If Container.GetType.IsSubclassOf(GetType(LCARS.Controls.WindowlessContainer)) Then
            SetWindowlessBeeping(CType(Container, LCARS.Controls.WindowlessContainer), Beeping)
        End If
    End Sub

    Public Sub SetWindowlessBeeping(ByVal Container As LCARS.Controls.WindowlessContainer, ByVal Beeping As Boolean)
        For i As Integer = 0 To Container.Count - 1
            Dim temp As IBeeping = TryCast(Container.Items(i), IBeeping)
            If Not temp Is Nothing Then
                temp.Beeping = Beeping
            End If
        Next
    End Sub

    Public Sub UpdateColors(ByVal Container As System.Windows.Forms.Control)
        For Each myControl As System.Windows.Forms.Control In Container.Controls
            If myControl.GetType.IsSubclassOf(GetType(LCARS.LCARSbuttonClass)) Then
                CType(myControl, LCARS.LCARSbuttonClass).ColorsAvailable.ReloadColors()
                CType(myControl, LCARS.LCARSbuttonClass).DrawAllButtons()
            ElseIf myControl.GetType.IsSubclassOf(GetType(LCARS.Controls.WindowlessContainer)) Then
                'My apologies for the long and nested CType statements. The alternative is temp variables.
                For i As Integer = 0 To CType(Container, LCARS.Controls.WindowlessContainer).Count
                    If CType(Container, LCARS.Controls.WindowlessContainer).Items(i).GetType.IsSubclassOf(GetType(LCARS.LightweightControls.LCFlatButton)) Then
                        CType(CType(Container, LCARS.Controls.WindowlessContainer).Items(i), LCARS.LightweightControls.LCFlatButton).ColorsAvailable.ReloadColors()
                    End If
                Next
            Else
                If myControl.Controls.Count > 0 Then
                    UpdateColors(myControl)
                End If
            End If
        Next
    End Sub
End Module
