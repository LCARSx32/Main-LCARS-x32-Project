Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Contains methods and functions that replicate various dialogs.
''' </summary>
''' <remarks>
''' To use these with minimal effor add this line to the top of your file:
''' <c>Imports LCARS.UI</c>
''' To switch back to standard Windows style dialogs, comment it out.
''' </remarks>
Public Class UI

    ''' <summary>
    ''' Displays an LCARS-style message box
    ''' </summary>
    ''' <param name="prompt">Prompt text to display</param>
    ''' <param name="buttons">Style of message box</param>
    ''' <param name="title">Title to display</param>
    ''' <returns>Button clicked</returns>
    ''' <remarks>
    ''' This is designed to be a full replacement for the standard message box. To convert
    ''' all message boxes produced by a file, add the line: <c>import LCARS.UI</c> to the top
    ''' of the file
    ''' </remarks>
    Public Shared Function MsgBox(ByVal prompt As Object, Optional ByVal buttons As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly, Optional ByVal title As String = "LCARS") As MsgBoxResult
        Dim myform As New LCARSMessageBoxForm(prompt, buttons, title)
        myform.ShowDialog()
        Dim result As MsgBoxResult = myform.buttonclick
        myform.Dispose()
        Return result
    End Function

    ''' <summary>
    ''' Displays an LCARS-style input box
    ''' </summary>
    ''' <param name="prompt">Prompt to display</param>
    ''' <param name="title">Title to display</param>
    ''' <param name="defaultResponse">Default response to fill in</param>
    ''' <param name="posX">X-coordinate. Defaults to center screen</param>
    ''' <param name="posY">Y-coordinate. Defaults to center screen</param>
    ''' <returns>Text entered into input box</returns>
    ''' <remarks>
    ''' This is designed to be a full replacement for the standard input box. To convert
    ''' all input boxes produced by a file, add the line: <c>import LCARS.UI</c> to the top
    ''' of the file
    '''</remarks>
    Public Shared Function inputbox(ByVal prompt As String, Optional ByVal title As String = "LCARS", Optional ByVal defaultResponse As String = "", Optional ByVal posX As Integer = -1, Optional ByVal posY As Integer = -1) As String
        Dim myform As New LCARSInputBoxForm(prompt, title, defaultResponse, posX, posY)
        myform.ShowDialog()
        Dim result As String = myform.txtInput.Text
        myform.Dispose()
        Return result
    End Function

End Class

#Region " LCARSMSGBOX "

Friend Class LCARSMessageBoxForm
    Inherits System.Windows.Forms.Form
    Public buttonclick As MsgBoxResult
    Private msgtype As MsgBoxStyle
    Private oloc As Point
    'Private Declare Auto Function MessageBeep Lib "user32.dll" (ByVal wType As Int32) As Boolean
    Public Sub New(ByVal prompt As Object, ByVal buttons As Microsoft.VisualBasic.MsgBoxStyle, ByVal title As String)
        'ByVal buttons As LCARScolorStyles,
        'Dim buttonclick As String = "OK"
        Dim colour As LCARS.LCARScolorStyles
        Dim cancleenabled, AbortVis, RetryVis, IgnoreVis, YesVis, NoVis As Boolean
        Dim okx, cx As Integer


        okx = 183
        cx = 50
        cancleenabled = False
        AbortVis = False
        RetryVis = False
        IgnoreVis = False
        YesVis = False
        NoVis = False


        ' enumeration splitter
        'buttons
        Dim butstyle(4) As Integer
        For ii As MsgBoxStyle = 0 To 5
            If (buttons And ii) <> 0 Then
                butstyle(0) = buttons And ii
            End If
        Next
        'style
        For ii As MsgBoxStyle = 16 To 64 Step 16
            If (buttons And ii) <> 0 Then
                butstyle(1) = buttons And ii
            End If
        Next
        'default button
        For ii As MsgBoxStyle = 256 To 768 Step 256
            If (buttons And ii) <> 0 Then
                butstyle(2) = buttons And ii
            End If
        Next
        'system modal
        If (buttons And MsgBoxStyle.SystemModal) <> 0 Then
            butstyle(3) = buttons And MsgBoxStyle.SystemModal
        End If
        'Special args
        For ii As MsgBoxStyle = MsgBoxStyle.MsgBoxHelp To MsgBoxStyle.MsgBoxRtlReading Step MsgBoxStyle.MsgBoxHelp
            If (buttons And ii) <> 0 Then
                butstyle(4) = buttons And ii
            End If
        Next
        ' end unumeration splitter

        Select Case butstyle(0)
            Case 0
                'vbOkOnly
                msgtype = MsgBoxStyle.OkOnly
            Case 1
                'vbOkCancle
                cancleenabled = True
                msgtype = MsgBoxStyle.OkCancel
            Case 2
                'vbAbortRetryIgnore
                AbortVis = True
                RetryVis = True
                IgnoreVis = True
                cancleenabled = True
                cx = 210
                okx = 115
                msgtype = MsgBoxStyle.AbortRetryIgnore
            Case 3
                'vbYesNoCancel
                cancleenabled = True
                YesVis = True
                NoVis = True
                okx = 210
                cx = 115
                msgtype = MsgBoxStyle.YesNoCancel
            Case 4
                'vbYesNo
                YesVis = True
                NoVis = True
                okx = 210
                cx = 115
                msgtype = MsgBoxStyle.YesNo
            Case 5
                'vbRetryCancle
                RetryVis = True
                cancleenabled = True
                msgtype = MsgBoxStyle.RetryCancel
        End Select
        Select Case butstyle(1)
            Case 16
                'vbCritical
                colour = LCARS.LCARScolorStyles.FunctionOffline
                'MessageBeep(MsgBoxStyle.Critical)
                ' pass redAlert() to LCARSmain if exists.
                Try

                Catch ex As Exception

                End Try
            Case 32
                'vbQuestion
                colour = LCARS.LCARScolorStyles.StaticBlue
                'MessageBeep(MsgBoxStyle.Question)
            Case 48
                'vbExclamation
                colour = LCARS.LCARScolorStyles.StaticTan
                'MessageBeep(MsgBoxStyle.Exclamation)
            Case 64
                'vbInformation
                colour = LCARS.LCARScolorStyles.LCARSDisplayOnly
                'MessageBeep(MsgBoxStyle.Information)
            Case Else
                colour = LCARS.LCARScolorStyles.StaticTan
                'MessageBeep(MsgBoxStyle.OkOnly)
        End Select
        Select Case butstyle(2)
            Case 256
                'vbDefaultButton2
            Case 512
                'vbDefaultButton3
            Case 768
                'vbDefaultbutton4
        End Select
        Select Case butstyle(4)
            Case 2
                'vbMsgBoxHelpButton
            Case 3
                'vbMsgBoxSetForground
            Case 4
                'vbMsgBoxRight
            Case 5
                'vbMsgBoxRtlReading
        End Select

        'draw form
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = New System.Drawing.Size(305, 200)
        Me.BackColor = Color.Black
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.TopMost = True


        'draw elbow1
        Dim elberr1 As New LCARS.Controls.Elbow
        Me.Controls.Add(elberr1)
        elberr1.Location = New System.Drawing.Point(0, 0)
        elberr1.Size = New System.Drawing.Size(80, 60)
        elberr1.ButtonHeight = 30
        elberr1.ButtonWidth = 10
        elberr1.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        elberr1.Color = colour
        elberr1.ButtonText = ""

        'draw 2nd elbow
        Dim elberr2 As New LCARS.Controls.Elbow
        Me.Controls.Add(elberr2)
        elberr2.Location = New System.Drawing.Point(0, 140)
        elberr2.Size = New System.Drawing.Size(80, 60)
        elberr2.ButtonHeight = 15
        elberr2.ButtonWidth = 10
        elberr2.Clickable = False
        elberr2.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        elberr2.Color = colour
        elberr2.ButtonText = ""

        'draw title
        Dim txtbtnerr As New LCARS.Controls.TextButton
        Me.Controls.Add(txtbtnerr)
        txtbtnerr.Location = New System.Drawing.Point(50, 0)
        txtbtnerr.Size = New System.Drawing.Size(255, 30)
        txtbtnerr.ButtonTextHeight = 31
        txtbtnerr.Color = colour
        txtbtnerr.ButtonText = title

        'draw vbar
        Dim fbverr As New LCARS.Controls.FlatButton
        Me.Controls.Add(fbverr)
        fbverr.Location = New System.Drawing.Point(0, 66)
        fbverr.Size = New System.Drawing.Size(10, 68)
        fbverr.Clickable = False
        fbverr.Color = colour
        fbverr.ButtonText = ""

        'draw bottombar
        Dim hpbverr As New LCARS.Controls.HalfPillButton
        Me.Controls.Add(hpbverr)
        hpbverr.Location = New System.Drawing.Point(85, 185)
        hpbverr.Size = New System.Drawing.Size(217, 15)
        hpbverr.Clickable = False
        hpbverr.Color = colour
        hpbverr.ButtonText = ""

        'draw text
        Dim txterr As New RichTextBox
        Me.Controls.Add(txterr)
        txterr.Location = New System.Drawing.Point(30, 36)
        txterr.Size = New System.Drawing.Size(243, 107)
        txterr.BackColor = Color.Black
        txterr.BorderStyle = BorderStyle.None
        txterr.WordWrap = True
        txterr.Font = New System.Drawing.Font("LCARS", 14, FontStyle.Regular)
        txterr.ForeColor = Color.Orange
        txterr.BringToFront()
        txterr.Text = prompt
        txterr.ReadOnly = True

        ' BUTTONS

        'draw OK/Yes/retry button
        Dim SBOkerr As New LCARS.Controls.StandardButton
        Me.Controls.Add(SBOkerr)
        With SBOkerr
            .Location = New System.Drawing.Point(okx, 149)
            .Size = New System.Drawing.Size(90, 30)
            .Color = LCARScolorStyles.PrimaryFunction
            .Name = "SBOkerr"
            If YesVis Then
                .ButtonText = "YES"
                AddHandler SBOkerr.Click, AddressOf OnsbYerrClick
            ElseIf RetryVis Then
                .ButtonText = "RETRY"
                AddHandler SBOkerr.Click, AddressOf OnsbRerrClick
            Else
                .ButtonText = "OK"
                AddHandler SBOkerr.Click, AddressOf OnsbokerrClick
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .BringToFront()
        End With

        'draw cancle/ignore button
        Dim SBCerr As New LCARS.Controls.StandardButton
        Me.Controls.Add(SBCerr)
        With SBCerr
            .Location = New System.Drawing.Point(cx, 149)
            .Size = New System.Drawing.Size(90, 30)
            .Name = "SBCerr"
            If cancleenabled Then .Color = LCARScolorStyles.CriticalFunction Else .Color = LCARScolorStyles.FunctionOffline
            If IgnoreVis Then
                .ButtonText = "IGNORE"
                AddHandler SBCerr.Click, AddressOf OnsbIerrClick
            Else
                .ButtonText = "CANCEL"
                AddHandler SBCerr.Click, AddressOf OnsbcerrClick
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .Flash = Not cancleenabled
            .Clickable = cancleenabled
            .BringToFront()
        End With


        'draw abort/no button
        Dim SBAerr As New LCARS.Controls.StandardButton
        Me.Controls.Add(SBAerr)
        With SBAerr
            .Location = New System.Drawing.Point(20, 149)
            .Size = New System.Drawing.Size(90, 30)
            .Color = LCARScolorStyles.CriticalFunction
            If AbortVis Then
                .ButtonText = "ABORT"
                AddHandler SBAerr.Click, AddressOf OnsbAerrClick
            ElseIf NoVis Then
                .ButtonText = "NO"
                AddHandler SBAerr.Click, AddressOf OnsbNerrClick
            Else
                SBAerr.Visible = False
            End If
            .ButtonTextAlign = ContentAlignment.MiddleCenter
            .BringToFront()
        End With
        Me.KeyPreview = True
        AddHandler Me.KeyDown, AddressOf Me_KeyDown
        AddHandler elberr1.MouseDown, AddressOf tbTitle_MouseDown
        AddHandler elberr1.MouseMove, AddressOf tbTitle_MouseMove
        AddHandler txtbtnerr.MouseDown, AddressOf tbTitle_MouseDown
        AddHandler txtbtnerr.MouseMove, AddressOf tbTitle_MouseMove
        'Application.DoEvents()
    End Sub

    Private Sub OnsbokerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Ok
        Me.Close()
    End Sub
    Private Sub OnsbcerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Cancel
        Me.Close()
    End Sub
    Private Sub OnsbAerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Abort
        Me.Close()
    End Sub
    Private Sub OnsbRerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Retry
        Me.Close()
    End Sub
    Private Sub OnsbIerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Ignore
        Me.Close()
    End Sub
    Private Sub OnsbYerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.Yes
        Me.Close()
    End Sub
    Private Sub OnsbNerrClick(ByVal sender As Object, ByVal e As System.EventArgs)
        buttonclick = MsgBoxResult.No
        Me.Close()
    End Sub
    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                If (msgtype = MsgBoxStyle.OkCancel Or msgtype = MsgBoxStyle.AbortRetryIgnore Or msgtype = MsgBoxStyle.YesNoCancel) Then
                    CType(Me.Controls.Find("SBCerr", True)(0), LCARS.LCARSbuttonClass).doClick(sender, e)
                End If
            Case Keys.Enter
                CType(Me.Controls.Find("SBOkerr", True)(0), LCARS.LCARSbuttonClass).doClick(sender, e)
        End Select
    End Sub
    Private Sub tbTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        oloc = New Point(MousePosition.X, MousePosition.Y)
    End Sub
    Private Sub tbTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Left += MousePosition.X - oloc.X
            Me.Top += MousePosition.Y - oloc.Y
            oloc = New Point(MousePosition.X, MousePosition.Y)
            Application.DoEvents()
        End If
    End Sub

End Class

#End Region

#Region " LCARSInputBox "
Friend Class LCARSInputBoxForm
    Inherits System.Windows.Forms.Form
    Public txtInput As New TextBox
    Friend WithEvents tbTitle As New LCARS.Controls.TextButton
    Private oloc As Point
    Public Sub New(ByVal prompt As String, ByVal title As String, ByVal defaultResponse As String, ByVal posX As Integer, ByVal posY As Integer)
        Me.BackColor = Color.Black
        Me.ForeColor = Color.Orange
        Me.Size = New Size(400, 200)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If posX = -1 Then
            posX = Screen.AllScreens(0).Bounds.Width / 2 - 200
        End If
        If posY = -1 Then
            posY = Screen.AllScreens(0).Bounds.Height / 2 - 100
        End If

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(posX, posY)
        With tbTitle
            .Width = 390
            .Height = 30
            .Location = New Point(5, 5)
            .Text = title
            .Clickable = True
        End With
        Me.Controls.Add(tbTitle)

        Dim tbBottom As New LCARS.Controls.TextButton
        With tbBottom
            .Width = 390
            .Top = 195 - .Height
            .Left = 5
            .Text = ""
            .Clickable = False
        End With
        Me.Controls.Add(tbBottom)

        Dim txtPrompt As New RichTextBox
        With txtPrompt
            .Width = 390
            .Height = 65
            .Top = tbTitle.Bottom + 7
            .Left = 5
            .Text = prompt
            .BackColor = Color.Black
            .ForeColor = Color.Orange
            .BorderStyle = BorderStyle.None
            .Font = New Font("LCARS", 14, FontStyle.Regular)
            .ReadOnly = True
            .WordWrap = True
        End With
        Me.Controls.Add(txtPrompt)

        With txtInput
            .Left = 10
            .Width = 380
            .Top = txtPrompt.Bottom + 7
            .BackColor = Color.Black
            .ForeColor = Color.Orange
            .Font = New System.Drawing.Font("LCARS", 14, FontStyle.Regular)
            .Text = defaultResponse
            .TabIndex = 0
        End With
        txtInput.Focus()
        Me.Controls.Add(txtInput)

        Dim sbOK As New LCARS.Controls.StandardButton
        With sbOK
            .Height = tbBottom.Height
            .Top = tbBottom.Top - 7 - .Height
            .Width = 70
            .Left = 325
            .Color = LCARScolorStyles.PrimaryFunction
            .Text = "OK"
            .ButtonTextAlign = ContentAlignment.MiddleCenter
        End With
        Me.Controls.Add(sbOK)
        AddHandler sbOK.Click, AddressOf sbOK_Click

        Dim sbCancel As New LCARS.Controls.StandardButton
        With sbCancel
            .Height = tbBottom.Height
            .Top = tbBottom.Top - 7 - .Height
            .Width = 70
            .Left = 248
            .Color = LCARScolorStyles.CriticalFunction
            .Text = "Cancel"
            .ButtonTextAlign = ContentAlignment.MiddleCenter
        End With
        Me.Controls.Add(sbCancel)
        AddHandler sbCancel.Click, AddressOf sbCancel_Click
        Me.AcceptButton = sbOK
        Me.CancelButton = sbCancel
    End Sub

    Private Sub sbOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub sbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtInput.Text = ""
        Me.Close()
    End Sub

    Private Sub tbTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbTitle.MouseDown
        oloc = New Point(MousePosition.X, MousePosition.Y)
    End Sub
    Private Sub tbTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbTitle.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Left += MousePosition.X - oloc.X
            Me.Top += MousePosition.Y - oloc.Y
            oloc = New Point(MousePosition.X, MousePosition.Y)
            Application.DoEvents()
        End If
    End Sub
End Class
#End Region
