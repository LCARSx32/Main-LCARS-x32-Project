Imports System.Drawing

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class TextButton
        Inherits LCARS.LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            'RemoveHandler lblText.MouseEnter, AddressOf MyBase.lblText_MouseEnter
            'RemoveHandler lblText.MouseLeave, AddressOf MyBase.lblText_MouseLeave
        End Sub

        'UserControl1 overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StandardButton
            '
            Me.Name = "TextButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ButtonTextHeight = 24
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region " Global Variables "

        Dim myType As TextButtonType = TextButtonType.DoublePills
        Dim myTextAlign As ContentAlignment = ContentAlignment.MiddleRight
        Dim textSize As FontData

#End Region

#Region " Enums"

        Public Enum TextButtonType
            NoPills = 0
            DoublePills = 1
            LeftPill = 2
            RightPill = 3
        End Enum

        Public Structure FontData
            Dim Left, Top, Right, Bottom, Width, Height As Integer
        End Structure

#End Region

#Region " Properties "

        Public Property ButtonType() As TextButtonType
            Get
                Return myType
            End Get
            Set(ByVal value As TextButtonType)
                myType = value
                Me.DrawAllButtons()
            End Set
        End Property

        Public Overrides Property ButtonTextAlign() As System.Drawing.ContentAlignment
            Get
                Return myTextAlign
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                myTextAlign = value
                Me.DrawAllButtons()
            End Set
        End Property


        Public Shadows Property ButtonTextHeight() As Integer
            Get
                Return textHeight
            End Get
            Set(ByVal value As Integer)
                textHeight = value
                textSize = getFontDimmensions(New Font("LCARS", value, FontStyle.Regular, GraphicsUnit.Point), ButtonText)
                Me.DrawAllButtons()
            End Set
        End Property

        Public Overrides Property ButtonText() As String
            Get
                Return myText
            End Get
            Set(ByVal value As String)
                myText = value.ToUpper
                'Me.lblText.Text = ""
                textSize = getFontDimmensions(New Font("LCARS", textHeight, FontStyle.Regular, GraphicsUnit.Point), myText)
                Me.DrawAllButtons()
            End Set
        End Property

#End Region

#Region " Functions "

        Private Function getFontDimmensions(ByVal myFont As Font, ByVal Text As String) As FontData
            Dim myData As FontData = New FontData
            Dim x, y As Integer
            Dim myG As Graphics
            myFont = New Font("LCARS", ButtonTextHeight, FontStyle.Regular, GraphicsUnit.Point)
            Dim textSize As SizeF = Me.CreateGraphics.MeasureString(Text, myFont)
            If Text = "" Then
                Return New FontData
            End If



            Dim mybitmap As Bitmap = New Bitmap(Convert.ToInt16(textSize.Width), Convert.ToInt16(textSize.Height))

            myG = Graphics.FromImage(mybitmap)
            myG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            myG.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            myG.DrawString(Text, myFont, Brushes.Black, 0, 0)

            myData.Left = mybitmap.Width
            myData.Top = mybitmap.Height
            myData.Bottom = 0
            myData.Right = 0

            For x = 0 To mybitmap.Width - 1
                For y = 0 To mybitmap.Height - 1
                    If mybitmap.GetPixel(x, y).ToArgb = Drawing.Color.Black.ToArgb Then
                        If myData.Left > x Then
                            myData.Left = x
                        End If

                        If myData.Top > y Then
                            myData.Top = y
                        End If

                        If myData.Right < x Then
                            myData.Right = x
                        End If

                        If myData.Bottom < y Then
                            myData.Bottom = y
                        End If
                    End If
                Next
            Next

            myData.Height = myData.Bottom - myData.Top
            myData.Width = myData.Right - myData.Left

            Return myData

        End Function

#End Region

#Region " Draw TextButton "

        Public Overrides Function DrawButton() As Bitmap
            If Me.Width > 0 And Me.Height > 0 Then
                Dim mybitmap As Bitmap = New Bitmap(1, 1)
                If Me.ButtonTextHeight > 0 Then

                    Dim g As Graphics
                    Dim mybrush As Drawing.SolidBrush = New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
                    Dim myfont As Font = New Font("LCARS", Me.ButtonTextHeight, FontStyle.Regular, GraphicsUnit.Point)
                    Dim drawHeight As Integer

                    If Me.RedAlert = LCARSalert.Red Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.Red)
                    ElseIf Me.RedAlert = LCARSalert.White Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.White)
                    ElseIf Me.RedAlert = LCARSalert.Yellow Then
                        mybrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                    ElseIf inRedAlert = LCARSalert.Custom Then
                        mybrush = New Drawing.SolidBrush(_customAlertColor)
                    End If

                    If textSize.Height = 0 Then
                        textSize = New FontData
                        textSize.Height = Me.Height
                    End If

                    mybitmap = New Bitmap(Me.Size.Width, textSize.Height)
                    g = Graphics.FromImage(mybitmap)

                    If InStr(Me.ButtonText.ToUpper, "Q") > 0 Then
                        drawHeight = textSize.Height - (textSize.Height \ 10)
                        Me.Height = mybitmap.Height
                    Else
                        drawHeight = textSize.Height
                        Me.Height = drawHeight
                    End If



                    'Draw black background
                    g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

                    'Set graphics to use smoothing
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

                    Select Case myType
                        Case TextButtonType.DoublePills
                            g.FillEllipse(mybrush, 0, 0, drawHeight, drawHeight)
                            g.FillEllipse(mybrush, Me.Width - drawHeight, 0, drawHeight, drawHeight)
                            g.FillRectangle(Brushes.Black, drawHeight \ 2, 0, Me.Width - drawHeight, drawHeight)
                            g.FillRectangle(mybrush, drawHeight \ 2, 0, drawHeight \ 2, drawHeight)
                            g.FillRectangle(mybrush, drawHeight + 6, 0, (Me.Width - (drawHeight * 2)) - 12, drawHeight)
                            g.FillRectangle(mybrush, Me.Width - drawHeight, 0, drawHeight \ 2, drawHeight)
                    End Select
                    If Me.ButtonText <> "" Then
                        If InStr(myTextAlign.ToString.ToLower, "right") > 0 Then
                            g.FillRectangle(Brushes.Black, Me.Width - ((textSize.Width + drawHeight) + 12), 0, textSize.Width + 6, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, Me.Width - (((textSize.Width + textSize.Left) + drawHeight) + 6), -textSize.Top)
                        End If

                        If InStr(myTextAlign.ToString.ToLower, "left") > 0 Then
                            g.FillRectangle(Brushes.Black, drawHeight + 6, 0, textSize.Width + 6, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, (drawHeight - textSize.Left) + 6, -textSize.Top)
                        End If

                        If InStr(myTextAlign.ToString.ToLower, "center") > 0 Then
                            g.FillRectangle(Brushes.Black, (Me.Width \ 2) - ((textSize.Width + 12) \ 2), 0, textSize.Width + 12, drawHeight)
                            g.DrawString(Me.ButtonText, myfont, Brushes.Orange, ((Me.Width \ 2) - (textSize.Width \ 2)) - textSize.Left, -textSize.Top)
                        End If

                    End If

                End If
                Return mybitmap
            Else
                Return New Bitmap(1, 1)
            End If
        End Function

#End Region

    End Class
End Namespace