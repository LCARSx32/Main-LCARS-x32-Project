Imports System.Drawing
Imports System.Windows.Forms
Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
    Public Class ComplexButton
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
            Me.Name = "ComplexButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Global Variables "

        Dim strSideText As String = "47"
        Dim staticWidth As Integer = -1
        Dim SideColor As LCARS.LCARScolorStyles = LCARScolorStyles.Orange
        Dim sideBoxColor As LCARS.LCARScolorStyles = LCARScolorStyles.Orange
#End Region

#Region " Properties "

        Public Property SideText() As String
            Get
                Return strSideText
            End Get
            Set(ByVal value As String)
                strSideText = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideTextWidth() As Integer
            Get
                Return staticWidth
            End Get
            Set(ByVal value As Integer)
                staticWidth = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideTextColor() As LCARS.LCARScolorStyles
            Get
                Return SideColor
            End Get
            Set(ByVal value As LCARS.LCARScolorStyles)
                SideColor = value
                DrawAllButtons()
            End Set
        End Property

        Public Property SideBlockColor() As LCARS.LCARScolorStyles
            Get
                Return sideBoxColor
            End Get
            Set(ByVal value As LCARS.LCARScolorStyles)
                sideBoxColor = value
                DrawAllButtons()
            End Set
        End Property

#End Region

#Region " Subs "

        Protected Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
            CheckForIllegalCrossThreadCalls = False
        End Sub


#End Region


#Region " Draw Complex Button "
        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim buttonTextSize As SizeF
            Dim sideTextSize As SizeF
            Dim curLeft As Integer = 0
            Dim textFont As Font = New Font("LCARS", (Me.Height \ 2) + 4, FontStyle.Regular, GraphicsUnit.Pixel)
            Dim sideFont As Font = New Font("LCARS", Me.Height + (Me.Height / 2.9), FontStyle.Regular, GraphicsUnit.Pixel)
            Dim myBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim sideBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(sideBoxColor))
            Dim sideTextBrush As Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorsAvailable.getColor(SideColor))

            If inRedAlert = 1 Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.Red)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf inRedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.White)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf inRedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                sideBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
                sideTextBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
                sideBrush = New Drawing.SolidBrush(_customAlertColor)
                sideTextBrush = New Drawing.SolidBrush(_customAlertColor)
            End If

            If strSideText Is Nothing Then
                strSideText = "47"
            End If

            'initialize the graphics
            mybitmap = New Bitmap(Me.Width, Me.Height)
            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality


            'get the width and height of the fonts
            buttonTextSize = g.MeasureString(Me.ButtonText.ToUpper, textFont)
            sideTextSize = g.MeasureString(strSideText.ToUpper, sideFont)

            'draw the left orange block.  If the mouse is down, draw it white.
            g.FillRectangle(sideBrush, 0, 0, Me.Height \ 2, Me.Height)

            'set the curleft to the right side of what we have already drawn.
            curLeft = Me.Height \ 2

            If staticWidth > -1 Then
                curLeft += staticWidth - sideTextSize.Width
            Else
                curLeft -= Me.Height \ 5
            End If

            'draw the side text

            g.DrawString(strSideText.ToUpper, sideFont, sideTextBrush, curLeft, -Me.Height / 4.7)

            If strSideText <> "" Then
                curLeft = (curLeft + sideTextSize.Width) - (Me.Height \ 6)
            Else
                curLeft = curLeft + (Me.Height \ 10)
            End If

            'draw the main button area
            g.FillRectangle(myBrush, curLeft, 0, (Me.Width - curLeft) - (Me.Height + (Me.Height \ 10)), Me.Height)
            Me.textLoc = New Point(curLeft, 0)
            Me.textSize = New Point((Me.Width - curLeft) - (Me.Height \ 2), Me.Height)
            curLeft += (Me.Width - curLeft) - (Me.Height + (Me.Height \ 10))

            curLeft -= Me.Height \ 10

            'draw the straight section of the right side pill shape
            g.FillRectangle(myBrush, curLeft, 0, Me.Height \ 2, Me.Height)

            'draw the curved end
            g.FillEllipse(myBrush, curLeft, 0, Me.Height, Me.Height)
            Return mybitmap

        End Function
#End Region

    End Class
End Namespace