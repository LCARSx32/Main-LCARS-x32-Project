Public Class frmPic
    Inherits LCARS.LCARSForm

    'a collection to hold the paths to our pictures

    Dim myFiles As New Collection

    'index keeps track of where we are in the array.  It represents the location of the current image.
    Dim index As Integer
    Dim origpicboxwidth As Integer
    Dim origpicboxheight As Integer
    Const shiftDelta As Integer = 30

    Private Sub frmPic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'sets initial picture box status to empty & prevents icon from displaying in pic box
        picturebox1.InitialImage = Nothing

        'Extracts path from file clicked in folder views
        Dim file As String()
        file = Environment.GetCommandLineArgs()
        If file.Length > 1 Then
            'loads image into picturebox
            picturebox1.ImageLocation = file(1).ToString()

        Else

            If file.Length < 1 Then
                picturebox1.Image = Nothing
            End If
        End If

    End Sub

    Private Sub loadImages(ByVal curIndex As Integer)
        If myFiles.Count > 0 Then
            Dim lastIndex As Integer
            Dim nextIndex As Integer

            If curIndex > 1 Then
                lastIndex = curIndex - 1
            Else
                lastIndex = myFiles.Count
            End If

            If curIndex + 1 <= myFiles.Count Then
                nextIndex = curIndex + 1
            Else
                nextIndex = 1
            End If

            If Not picturebox1.Image Is Nothing Then
                picturebox1.Image.Dispose()
            End If

            Dim myinfo As New System.IO.FileInfo(myFiles(curIndex))

            picturebox1.Image = Image.FromFile(myFiles(curIndex))
            lblInfo.Text = myinfo.Name & vbNewLine & vbNewLine & _
                          "RESOLUTION: " & picturebox1.Image.Width & "x" & picturebox1.Image.Height & vbNewLine & _
                         "FILE SIZE: " & myinfo.Length & " bytes" & vbNewLine & _
           "CREATED: " & myinfo.CreationTime.ToShortDateString & vbNewLine & _
            "MODIFIED: " & myinfo.LastWriteTime.ToShortDateString & vbNewLine
            '"NAME: " & myinfo.FullName.ToString & vbNewLine


            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)



            lastIndex = Nothing
            nextIndex = Nothing
        End If

    End Sub



    Private Sub tmrShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrShow.Tick
        abNext_Click(sender, e)



    End Sub

    Private Sub sbShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbShow.Click



        tmrShow.Enabled = Not tmrShow.Enabled

        If tmrShow.Enabled = True Then
            sbShow.ButtonText = "Stop Slideshow"

        Else
            sbShow.ButtonText = "Start Slideshow"



        End If
    End Sub

    Private Sub sbBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbBrowse.Click
        Dim myDir As New FolderBrowserDialog
        Dim result As DialogResult

        result = myDir.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            Dim tmpFiles() As String = System.IO.Directory.GetFiles(myDir.SelectedPath)

            For Each curFile As String In tmpFiles
                Dim ext As String = System.IO.Path.GetExtension(curFile).ToLower

                If ext = ".jpg" Or ext = ".jpeg" Or ext = ".gif" Or ext = ".bmp" _
               Or ext = ".png" Or ext = ".tif" Or ext = ".tiff" Then
                    myFiles.Add(curFile)
                End If
                ext = Nothing
                curFile = Nothing
            Next

            tmpFiles = Nothing

            index = 1
            loadImages(index)



        End If

        origpicboxwidth = picturebox1.Width
        origpicboxheight = picturebox1.Height
    End Sub

    Private Sub abNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abNext.Click

        If index + 1 > myFiles.Count Then
            ''we're past the end of the array, so start over
            index = 1
        Else
            index += 1
        End If

        loadImages(index)
    End Sub

    Private Sub abPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abPrev.Click

        picturebox1.SizeMode = PictureBoxSizeMode.Zoom

        If index > 1 Then
            index -= 1
        Else
            index = myFiles.Count
        End If

        loadImages(index)
    End Sub


    Private Sub fbZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbZoomOut.Click

        If picturebox1.Image IsNot Nothing Then

            picturebox1.Width = CInt(picturebox1.Width * 0.8)
            picturebox1.Height = CInt(picturebox1.Height * 0.8)

            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)

        End If

    End Sub

    Private Sub fbZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbZoomIn.Click

        If picturebox1.Image IsNot Nothing Then


            picturebox1.Width = CInt(picturebox1.Width * 1.2)
            picturebox1.Height = CInt(picturebox1.Height * 1.2)
            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)

        End If

    End Sub

    Private Sub fbActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbActual.Click
        If picturebox1.Image IsNot Nothing Then
            picturebox1.SizeMode = PictureBoxSizeMode.Zoom
            picturebox1.Size = New Size(origpicboxwidth, origpicboxheight)

            Dim picboxlocx As Integer = 3
            Dim picboxlocy As Integer = 3
            picturebox1.Location = New Point(picboxlocx, picboxlocy)

            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)
        End If
    End Sub



    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton1.Click


        If picturebox1.Image IsNot Nothing Then
            picturebox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            picturebox1.Refresh()
        End If

    End Sub

    Private Sub ArrowButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton2.Click

        If picturebox1.Image IsNot Nothing Then
            picturebox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            picturebox1.Refresh()
        End If

    End Sub


    Private Sub sbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExit.Click
        Me.Close()
    End Sub

    Private shiftButton As LCARS.Controls.FlatButton

    Private Sub shiftButtonDown(ByVal sender As Object, ByVal e As EventArgs) Handles up.MouseDown, dwn.MouseDown, lft.MouseDown, rht.MouseDown
        If picturebox1.Image Is Nothing Then Return
        shiftButton = DirectCast(sender, LCARS.Controls.FlatButton)
        tmrShift.Start()
        shiftTimer_Tick(sender, e)
    End Sub

    Private Sub shiftButtonUp(ByVal sender As Object, ByVal e As EventArgs) Handles up.MouseUp, dwn.MouseUp, lft.MouseUp, rht.MouseUp
        tmrShift.Stop()
        shiftButton = Nothing
    End Sub

    Private Sub shiftTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrShift.Tick
        If shiftButton Is up Then
            picturebox1.Top += shiftDelta
        ElseIf shiftButton Is dwn Then
            picturebox1.Top -= shiftDelta
        ElseIf shiftButton Is lft Then
            picturebox1.Left += shiftDelta
        ElseIf shiftButton Is rht Then
            picturebox1.Left -= shiftDelta
        End If
    End Sub
End Class
