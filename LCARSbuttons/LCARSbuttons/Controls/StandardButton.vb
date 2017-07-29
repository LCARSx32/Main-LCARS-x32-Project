Imports System.Drawing
Imports System.ComponentModel

Namespace Controls

    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class StandardButton
        Inherits LCARS.LCARSbuttonClass

#Region " Control Design Information "
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
            Me.Name = "StandardButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Global Varibles "
        Dim myButtonType As LCARSbuttonStyles = LCARSbuttonStyles.Pill
#End Region

#Region " Properties "
        <DefaultValue(GetType(LCARSbuttonStyles), "Pill")> _
        Public Property ButtonStyle() As LCARSbuttonStyles
            Get
                Return myButtonType
            End Get
            Set(ByVal value As LCARSbuttonStyles)
                myButtonType = value
                Me.DrawAllButtons()
            End Set
        End Property
#End Region

#Region " Structures "

        Public Enum LCARSbuttonStyles
            Pill = 0
            RoundedSquare = 1
            RoundedSquareSlant = 2
            RoundedSquareBackSlant = 3
        End Enum


#End Region

#Region " Draw Standard Button "

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim halfHeight As Integer
            Dim quarterHeight As Integer
            Dim quarterWidth As Integer
            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
            End If

            mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

            halfHeight = Me.Height \ 2
            quarterHeight = Me.Height \ 4
            quarterWidth = Me.Width \ 4



            If myButtonType = LCARSbuttonStyles.Pill Then
                g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
                g.FillRectangle(myBrush, halfHeight, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
                g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)


                Me.textLoc = New Point(Me.Height \ 2, 0)
                Me.textSize = New Size(Me.Width - Me.Height, Me.Height)

            Else
                g.FillEllipse(myBrush, New Rectangle(0, 0, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, 0, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(0, Me.Height - quarterHeight, quarterHeight, quarterHeight))
                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, Me.Height - quarterHeight, quarterHeight, quarterHeight))

                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, 0, Me.Width - quarterHeight, quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, Me.Height - quarterHeight, Me.Width - quarterHeight, quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(0, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(Me.Width - quarterHeight, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, quarterHeight \ 2, Me.Width - quarterHeight, Me.Height - quarterHeight))

                Select Case myButtonType
                    Case LCARSbuttonStyles.RoundedSquareSlant

                        Dim slant As Bitmap = New Bitmap(mybitmap)

                        Dim mypoints(2) As Point

                        mypoints(0) = New Point(Me.Width \ 4, 0)
                        mypoints(1) = New Point(Me.Width, 0)
                        mypoints(2) = New Point(0, Me.Height)

                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
                        g.DrawImage(slant, mypoints)

                        Me.textLoc = New Point(Me.Width \ 4, 0)
                        Me.textSize = New Size(Me.Width - (Me.Width \ 2), Me.Height)
                    Case LCARSbuttonStyles.RoundedSquareBackSlant

                        Dim slant As Bitmap = New Bitmap(mybitmap)

                        Dim mypoints(2) As Point

                        mypoints(0) = New Point(0, 0)
                        mypoints(1) = New Point(Me.Width - (Me.Width \ 4), 0)
                        mypoints(2) = New Point(Me.Width \ 4, Me.Height)

                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
                        g.DrawImage(slant, mypoints)

                        Me.textLoc = New Point(Me.Width \ 4, 0)
                        Me.textSize = New Size(Me.Width - (Me.Width \ 2), Me.Height)
                    Case Else
                        Me.textLoc = New Point(0, 0)
                        Me.textSize = New Size(Me.Width, Me.Height)
                End Select
            End If
            g.Dispose()
            Return mybitmap
        End Function

#End Region

    End Class
End Namespace
