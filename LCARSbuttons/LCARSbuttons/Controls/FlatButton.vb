Imports System.Drawing

Namespace Controls
    <System.ComponentModel.DefaultEvent("Click")> _
        Public Class FlatButton
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
            'FlatButtonButton
            '
            Me.Name = "FlatButton"
            Me.Size = New System.Drawing.Size(200, 100)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region " Draw Flat Button "

        Public Overrides Function DrawButton() As Bitmap
            Dim mybitmap As Bitmap
            Dim g As Graphics
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New System.Drawing.SolidBrush(Drawing.Color.Yellow)
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
            End If

            Try
                mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
            Catch ex As Exception
                mybitmap = New Bitmap(1, 1)
                mybitmap.SetPixel(0, 0, System.Drawing.Color.FromArgb(0, 0, 0, 0))

            End Try

            g = Graphics.FromImage(mybitmap)

            g.FillRectangle(myBrush, 0, 0, mybitmap.Width, mybitmap.Height)

            'Select Case Me.ButtonTextAlign
            '    Case LCARStextStyles.TopLeft
            '        textLoc.X = 0
            '        textLoc.Y = 0
            '    Case LCARStextStyles.TopRight
            '        textLoc.X = (Me.Width - textSize.Width)
            '        textLoc.Y = 0

            '    Case LCARStextStyles.BottomLeft
            '        textLoc.X = 0
            '        textLoc.Y = (Me.Height - textSize.Height)

            '    Case LCARStextStyles.BottomRight
            '        textLoc.X = (Me.Width - textSize.Width)
            '        textLoc.Y = (Me.Height - textSize.Height)

            'End Select

            'g.DrawString(Me.ButtonText, myfont, Brushes.Black, textLoc.X, textLoc.Y)
            Me.lblTextSize = Me.Size
            DrawText(g)
            g.Dispose()
            Return mybitmap
        End Function

#End Region

    End Class
End Namespace