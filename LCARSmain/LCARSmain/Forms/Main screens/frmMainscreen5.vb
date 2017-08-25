Public Class frmMainscreen5
    Implements IAutohide

    Private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        myBusiness = b
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen5
        End Get
    End Property
End Class