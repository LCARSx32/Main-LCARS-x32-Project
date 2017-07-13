Public Class frmMainscreen4
    Implements IAutohide

    Private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        Me.myBusiness = b
    End Sub

    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        myBusiness.progShowing = pnlStart.Visible
        If pnlStart.Visible Then
            pnlMain.Left += pnlStart.Width + 6
            pnlMain.Width -= pnlStart.Width + 6
        Else
            pnlMain.Left -= pnlStart.Width + 6
            pnlMain.Width += pnlStart.Width + 6
        End If
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen4
        End Get
    End Property

    Private Sub myUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myUserButtons.Click
        If gridUserButtons.Visible Then
            pnlMain.Width += gridUserButtons.Width + 6
        Else
            pnlMain.Width -= gridUserButtons.Width + 6
        End If
    End Sub
End Class