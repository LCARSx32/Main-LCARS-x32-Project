Public Class frmMergeOptions
    Dim _action As MergeOptions = MergeOptions.Undecided
    Dim _IsGlobal As Boolean = False
    Public ReadOnly Property action() As MergeOptions
        Get
            Return _action
        End Get
    End Property
    Public ReadOnly Property IsGlobalSetting() As Boolean
        Get
            Return _IsGlobal
        End Get
    End Property
    Public Sub New(ByVal file As String, ByVal isFile As Boolean)
        InitializeComponent()
        If isFile Then
            lblPrompt.Text = "The file: " & file & " already exists."
            sbmerge.Text = "Overwrite"
            sbKeepBoth.Text = "Keep both files"
            tbTitle.Text = "Overwrite file?"
        Else
            lblPrompt.Text = "The directory: " & file & " already exists."
        End If
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        Select Case True
            Case sbDoNotCopy.Lit
                _action = MergeOptions.DoNotMove
            Case sbmerge.Lit
                _action = MergeOptions.Merge
            Case sbKeepBoth.Lit
                _action = MergeOptions.MoveAndKeepBoth
        End Select
        If _action = MergeOptions.Undecided Then
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
        _IsGlobal = sbGlobal.Lit
    End Sub
End Class