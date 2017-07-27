Option Strict On

Imports System.IO

Public Class frmRename
    Inherits LCARS.LCARSForm
    Private _path As String

    Public Sub New(ByVal curPath As String)
        InitializeComponent()
        TopLevel = False
        _path = curPath
        txtNew.Text = Path.GetFileName(_path)
        If Directory.Exists(_path) Then
            lblFileName.Text = "Directory Name"
        Else
            lblFileName.Text = "File Name"
        End If
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        Try
            If (Path.GetDirectoryName(_path).EndsWith("\")) Then 'Error checking added by Tim 5/57/11
                Rename(_path, Path.GetDirectoryName(_path) & txtNew.Text) 'Corrects renaming bug
            Else
                Rename(_path, Path.GetDirectoryName(_path) & "\" & txtNew.Text)
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Unable to rename:" & vbNewLine & ex.Message)
        End Try
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub

    Private Sub frmRename_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNew.Focus()
    End Sub
End Class