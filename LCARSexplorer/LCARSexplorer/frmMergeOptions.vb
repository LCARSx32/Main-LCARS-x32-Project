Option Strict On

Public Class frmMergeOptions
    Dim _action As frmCopying.MergeOptions = frmCopying.MergeOptions.Undecided
    Dim _IsGlobal As Boolean = False
    Public ReadOnly Property action() As frmCopying.MergeOptions
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
                _action = frmCopying.MergeOptions.DoNotMove
            Case sbmerge.Lit
                _action = frmCopying.MergeOptions.Merge
            Case sbKeepBoth.Lit
                _action = frmCopying.MergeOptions.MoveAndKeepBoth
        End Select
        _IsGlobal = sbGlobal.Lit
        If _action = frmCopying.OverWriteActions.Undecided Then
            MsgBox("Please choose an option.")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub sbDoNotCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDoNotCopy.Click
        sbDoNotCopy.Lit = True
        sbmerge.Lit = False
        sbKeepBoth.Lit = False
    End Sub

    Private Sub sbOverwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbmerge.Click
        sbDoNotCopy.Lit = False
        sbmerge.Lit = True
        sbKeepBoth.Lit = False
    End Sub

    Private Sub sbKeepBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbKeepBoth.Click
        sbDoNotCopy.Lit = False
        sbmerge.Lit = False
        sbKeepBoth.Lit = True
    End Sub

    Private Sub sbGlobal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGlobal.Click
        sbGlobal.Lit = Not sbGlobal.Lit
    End Sub
End Class