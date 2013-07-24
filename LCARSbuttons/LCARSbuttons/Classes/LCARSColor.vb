Imports System.Drawing

''' <summary>
''' Contains methods for mapping and displaying LCARS colors
''' </summary>
''' <remarks>Every button has one of these. If you want custom colors, use it!</remarks>
Public Class LCARScolor
    Dim colors() As String

    '''<summary>
    ''' Raised when colors have been updated.
    ''' </summary>
    Public Event ColorsUpdated As EventHandler

    ''' <summary>
    ''' Returns new LCARScolor object
    ''' </summary>
    ''' <remarks>Will initialize to system defaults if present, otherwise standard colors.</remarks>
    Sub New()
        Dim myColors As String

        myColors = GetSetting("LCARS x32", "Colors", "ColorMap", "NONE")

        If myColors <> "NONE" Then
            colors = myColors.Split(",")
        Else
            Dim DefaultColors() As String = {"#3366CC", "#99CCFF", "#CC99CC", "#FFCC00", "#FFFF99", "#CC6666", "#FFFFFF", "#FF0000", "#FFCC66", "Orange", "#99CCFF"}
            colors = DefaultColors
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(colors, ","))
        End If
    End Sub

    ''' <summary>
    ''' Refreshes colors
    ''' </summary>
    ''' <remarks>Retrieves stored colors, or initializes system colors to standard colors if none are saved.
    ''' Will then raise a <see cref="ColorsUpdated">ColorsUpdated</see> event.</remarks>
    Public Sub ReloadColors()
        Dim myColors As String

        myColors = GetSetting("LCARS x32", "Colors", "ColorMap", "NONE")

        If myColors <> "NONE" Then
            colors = myColors.Split(",")
        Else
            Dim DefaultColors() As String = {"#3366CC", "#99CCFF", "#CC99CC", "#FFCC00", "#FFFF99", "#CC6666", "#FFFFFF", "#FF0000", "#FFCC66", "Orange", "#99CCFF"}
            colors = DefaultColors
            SaveSetting("LCARS x32", "Colors", "ColorMap", Join(colors, ","))
        End If
        RaiseEvent ColorsUpdated(Me, New EventArgs)
    End Sub

    ''' <summary>
    ''' Returns current colors stored by this instance
    ''' </summary>
    ''' <returns>array of HTML-formatted colors</returns>
    ''' <remarks></remarks>
    Public Function getColors() As String()
        Return colors
    End Function

    ''' <summary>
    ''' Sets colors for this instance
    ''' </summary>
    ''' <param name="newColors">String array of HTML-formatted colors. Must be the correct length.</param>
    ''' <remarks>Use this to set custom colors. Will crash if too many colors are specified.</remarks>
    Public Sub setColors(ByVal newColors() As String)
        Dim upper As Integer = newColors.GetUpperBound(0)
        Dim intloop As Integer

        If upper > newColors.GetUpperBound(0) Then
            upper = newColors.GetUpperBound(0)
        End If
        For intloop = 0 To upper
            colors(intloop) = newColors(intloop)
        Next

    End Sub

    ''' <summary>
    ''' Gets index of LCARS color
    ''' </summary>
    ''' <param name="Name">Name of color</param>
    ''' <returns>Integer representation of LCARS color designation</returns>
    ''' <remarks>Integer returned is the same as the enum. Use that instead if possible.</remarks>
    Public Shared Function IndexOf(ByVal Name As String) As Integer
        Dim myColor As LCARScolorStyles

        For i As Integer = 0 To 10
            myColor = i
            If myColor.ToString.ToLower = Name.ToLower Then
                Return i
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' Gets actual color for LCARS color designation
    ''' </summary>
    ''' <param name="index">Value of color to look up</param>
    ''' <returns>System.Drawing.Color of specified designation</returns>
    ''' <remarks>Only returns color for this instance. If custom colors have been specified, it will return those.</remarks>
    Public Function getColor(ByVal index As LCARScolorStyles) As Color
        Dim code As String

        Select Case index
            Case 0
                code = colors(0)
            Case 1
                code = colors(1)
            Case 2
                code = colors(2)
            Case 3
                code = colors(3)
            Case 4
                code = colors(4)
            Case 5
                code = colors(5)
            Case 6
                code = colors(6)
            Case 7
                code = colors(7)
            Case 8
                code = colors(8)
            Case 9
                code = colors(9)
            Case 10
                code = colors(10)
            Case Else
                MsgBox("'INVALID COLOR CODE' recieved in function 'getColor'.  Please check your code and try again.", MsgBoxStyle.Exclamation, "ERROR!")
                Exit Function
        End Select

        Return ColorTranslator.FromHtml(code)
    End Function

End Class
