Imports System.Drawing
Imports System.ComponentModel

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class HalfPillButton
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
            'HalfPillButton
            '
            Me.Name = "HalfPillButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region
        Dim _ButtonType As LCARSbuttonStyles = LCARSbuttonStyles.PillRight
#Region " Properties "
        <DefaultValue(GetType(LCARSbuttonStyles), "PillRight")> _
        Public Property ButtonStyle() As LCARSbuttonStyles
            Get
                Return _ButtonType
            End Get
            Set(ByVal value As LCARSbuttonStyles)
                _ButtonType = value
                Me.DrawAllButtons()
            End Set
        End Property


#End Region

#Region " Draw Half-Pill Button "
#Region " Structures "

        Public Enum LCARSbuttonStyles
            PillRight = 0
            PillLeft = 1
        End Enum

#End Region

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

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

            Select Case _ButtonType
                Case LCARSbuttonStyles.PillRight
                    g.FillRectangle(myBrush, 0, 0, Me.Size.Width - (Me.Size.Height \ 2), Me.Size.Height)
                    g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)
                    Me.textLoc = New Point(0, 0)
                Case LCARSbuttonStyles.PillLeft
                    g.FillRectangle(myBrush, Me.Size.Height \ 2, 0, Me.Size.Width - (Me.Size.Height \ 2), Me.Size.Height)
                    g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
                    Me.textLoc = New Point(Me.Height \ 2, 0)
            End Select
            Me.textSize = New Size(Me.Size.Width - (Me.Size.Height \ 2), Me.Size.Height)
            g.Dispose()
            Return mybitmap
        End Function

#End Region

    End Class
End Namespace