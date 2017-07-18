Public Class frmSelect
    Public Sub New()
        InitializeComponent()
        Dim myColor As New LCARS.LCARScolor
        Me.BackColor = myColor.getColor(LCARS.LCARScolorStyles.StaticBlue)
    End Sub
End Class