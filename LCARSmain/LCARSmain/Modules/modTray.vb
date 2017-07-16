Option Strict On

Public Module modTray
    Private curTray As modBusiness = Nothing

    Public Sub GetTray(ByVal b As modBusiness)
        If curTray IsNot Nothing Then
            curTray.myHideTrayButton_Click(Nothing, Nothing)
        End If
        curTray = b
        SetParent(hTrayIcons, b.myTrayPanel.Handle)
    End Sub

    Public Sub ReturnTray(ByVal b As modBusiness)
        If curTray Is b Then 'Only return the tray if we actually have it.
            curTray = Nothing
            SetParent(hTrayIcons, hTrayParent)
        End If
    End Sub

    Public Sub UpdateTray()
        If curTray IsNot Nothing Then
            curTray.UpdateTray()
        End If
    End Sub
End Module
