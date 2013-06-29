Public Class x32Interop
#Region " Events "
    Public Event WorkingAreaChanged(ByVal NewArea As System.Drawing.Rectangle)
    Public Event AlertInitiated(ByVal AlertID As Integer)
    Public Event AlertEnded As EventHandler
    Public Event BeepingChanged(ByVal Beeping As Boolean)
    Public Event ColorsChanged()
#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
    End Sub

    Public Sub Init()
        'Initialize reference to x32 and start receiving events
    End Sub
End Class