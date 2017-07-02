
Public Class frmMainscreen4
    Implements IAutohide
    Dim isInit As Boolean = False
    Public myBusiness As New modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top
    End Function

    Public Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)
    End Sub

    Private Sub frmMainscreen4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
        Me.Show()
        Application.DoEvents()
        isInit = True
        pnlMainBar_SizeChanged(New Object, New System.EventArgs)
        myBusiness.mainTimer.Enabled = True
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit Then
            Dim mainWidth As Integer = pnlMainBar.Width
            Dim mainHeight As Integer = Me.Height - (myStartMenu.Bottom + 6)
            Dim mainLeft As Integer = 0
            Dim mainTop As Integer = myStartMenu.Bottom + 6

            If myBusiness.progShowing And Not myBusiness.userButtonsShowing Then
                mainWidth = pnlMainBar.Width - (pnlProgs.Right + 6)
                mainLeft = pnlProgs.Right + 6
            ElseIf myBusiness.userButtonsShowing And Not myBusiness.progShowing Then
                mainWidth = gridUserButtons.Left - 6
                mainLeft = 0
            ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing Then
                mainWidth = (gridUserButtons.Left - 6) - (pnlProgs.Right + 6)
                mainLeft = pnlProgs.Right + 6
            End If

            pnlMain.Bounds = New Rectangle(mainLeft, mainTop, mainWidth, mainHeight)
            myBusiness.UpdateRegion()
        End If
    End Sub

    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlProgs.Visible = Not pnlProgs.Visible
        myBusiness.progShowing = pnlProgs.Visible
        myBusiness.userButtonsShowing = gridUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen4
        End Get
    End Property
End Class