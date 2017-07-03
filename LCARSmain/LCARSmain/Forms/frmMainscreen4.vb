
Public Class frmMainscreen4
    Implements IAutohide

    private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        Me.myBusiness = b
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If myBusiness IsNot Nothing AndAlso myBusiness.isInit Then
            Dim mainWidth As Integer = pnlMainBar.Width
            Dim mainHeight As Integer = Me.Height - (myStartMenu.Bottom + 6)
            Dim mainLeft As Integer = 0
            Dim mainTop As Integer = myStartMenu.Bottom + 6

            If myBusiness.progShowing And Not myBusiness.userButtonsShowing Then
                mainWidth = pnlMainBar.Width - (pnlStart.Right + 6)
                mainLeft = pnlStart.Right + 6
            ElseIf myBusiness.userButtonsShowing And Not myBusiness.progShowing Then
                mainWidth = gridUserButtons.Left - 6
                mainLeft = 0
            ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing Then
                mainWidth = (gridUserButtons.Left - 6) - (pnlStart.Right + 6)
                mainLeft = pnlStart.Right + 6
            End If

            pnlMain.Bounds = New Rectangle(mainLeft, mainTop, mainWidth, mainHeight)
            myBusiness.UpdateRegion()
        End If
    End Sub

    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        myBusiness.progShowing = pnlStart.Visible
        myBusiness.userButtonsShowing = gridUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen4
        End Get
    End Property
End Class