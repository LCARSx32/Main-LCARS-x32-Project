'Imports LCARS.UI
Public Class Form1
    Dim oLoc As Point
    Dim moving As Boolean = False
    Dim myButton As New LCARS.LightweightControls.LCStandardButton
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With myButton
            .HoldDraw = True
            .Width = 150
            .Height = 40
            .Text = "The quick brown fox jumped over the lazy dogs."
            .Top = 10
            .Left = 10
            .HoldDraw = False
            AddHandler .MouseDown, AddressOf myButton_mouseDown
            AddHandler .MouseUp, AddressOf myButton_MouseUp
            AddHandler .MouseMove, AddressOf myButton_mouseMove
        End With
        Dim myBack As New LCARS.LightweightControls.LCFlatButton
        With myBack
            .HoldDraw = True
            .Width = Windowless.Width
            .Height = Windowless.Height
            .Top = 0
            .Left = 0
            .Color = LCARS.LCARScolorStyles.FunctionUnavailable
            .HoldDraw = False
        End With
        Windowless.Add(myBack)
        Windowless.Add(myButton)
        For i As Integer = 1 To 500
            Dim myTemp As New LCARS.LightweightControls.LCComplexButton
            myTemp.SideText = i
            myGrid.Add(myTemp)
            myTemp.Flashing = True
        Next
    End Sub
    Private Sub btnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBox(sender.text)
    End Sub
    Private Sub myButton_mouseDown(ByVal sender As Object, ByVal e As System.EventArgs)
        oLoc = Cursor.Position
        moving = True
    End Sub
    Private Sub myButton_mouseMove(ByVal sender As Object, ByVal e As System.EventArgs)
        If moving Then
            myButton.HoldDraw = True
            myButton.Left -= oLoc.X - Cursor.Position.X
            myButton.Top -= oLoc.Y - Cursor.Position.Y
            oLoc = Cursor.Position
            Windowless.Invalidate()
            myButton.HoldDraw = False
        End If
    End Sub
    Private Sub myButton_MouseUp()
        moving = False
    End Sub
End Class
