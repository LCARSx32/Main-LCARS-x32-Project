Option Strict On

Public Class frmOverwriteOptions
    Dim _action As OverWriteActions = OverWriteActions.Undecided
    Dim _IsGlobal As Boolean = False
    Public ReadOnly Property action() As OverWriteActions
        Get
            Return _action
        End Get
    End Property
    Public ReadOnly Property IsGlobalSetting() As Boolean
        Get
            Return _IsGlobal
        End Get
    End Property
    Public Sub New(ByVal file As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblPrompt.Text = "The file: " & file & " already exists."
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        Select Case True
            Case sbDoNotCopy.Lit
                _action = OverWriteActions.DoNotMove
            Case sbOverwrite.Lit
                _action = OverWriteActions.Overwrite
            Case sbKeepBoth.Lit
                _action = OverWriteActions.MoveAndKeepBoth
        End Select
        _IsGlobal = sbGlobal.Lit
        If _action = OverWriteActions.Undecided Then
            MsgBox("Please choose an option.")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub sbDoNotCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDoNotCopy.Click
        sbDoNotCopy.Lit = True
        sbOverwrite.Lit = False
        sbKeepBoth.Lit = False
    End Sub

    Private Sub sbOverwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOverwrite.Click
        sbDoNotCopy.Lit = False
        sbOverwrite.Lit = True
        sbKeepBoth.Lit = False
    End Sub

    Private Sub sbKeepBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbKeepBoth.Click
        sbDoNotCopy.Lit = False
        sbOverwrite.Lit = False
        sbKeepBoth.Lit = True
    End Sub

    Private Sub sbGlobal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGlobal.Click
        sbGlobal.Lit = Not sbGlobal.Lit
    End Sub
End Class