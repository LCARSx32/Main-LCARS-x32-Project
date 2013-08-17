'Imports LCARS.UI
Public Class Form1

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Windowless.Add(CType(FlatButton2, LCARS.LightweightControls.LCFlatButton))
        Windowless.Add(CType(StandardButton1, LCARS.LightweightControls.LCStandardButton))
    End Sub
End Class
