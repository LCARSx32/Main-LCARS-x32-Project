Imports System.Drawing
Imports System.ComponentModel

Namespace Controls
    Public Class LevelIndicator
        Inherits LCARS.LCARSbuttonClass

        Dim myColor2 As LCARScolorStyles
        Dim intMax As Integer = 100
        Dim intMin, intVal As Integer
        Dim mySize As Point

#Region " Properties "
        <DefaultValue(100)> _
                Public Property Color2() As LCARScolorStyles
            Get
                Return myColor2
            End Get
            Set(ByVal value As LCARScolorStyles)
                myColor2 = value
                Me.DrawAllButtons()
            End Set
        End Property


        <DefaultValue(100)> _
        Public Property Max() As Integer
            Get
                Return intMax
            End Get
            Set(ByVal value As Integer)
                If value > intMin Then
                    intMax = value
                    Me.DrawAllButtons()
                Else
                    MsgBox("The Max value MUST be greater than the Min value.")
                End If
            End Set
        End Property


        <DefaultValue(0)> _
      Public Property Min() As Integer
            Get
                Return intMin
            End Get
            Set(ByVal value As Integer)
                If value < intMax Then
                    intMin = value
                    Me.DrawAllButtons()
                Else
                    MsgBox("The Min value MUST be lesser than the Max value.")
                End If
            End Set
        End Property

        <DefaultValue(0)> _
      Public Property Value() As Integer
            Get
                Return intVal
            End Get
            Set(ByVal value As Integer)
                If value >= intMin And value <= Max Then
                    intVal = value
                    If intMax - intMin > 0 Then
                        Me.ButtonText = Int((intVal / (intMax - intMin)) * 100) & "%"
                    Else
                        Me.ButtonText = "0%"
                    End If

                    Me.DrawAllButtons()
                Else
                    MsgBox("The Value MUST be between Min and Max.")
                End If
            End Set
        End Property
#End Region

        Sub New()
            Clickable = False
            ButtonTextAlign = ContentAlignment.MiddleCenter
        End Sub






        Public Overrides Function DrawButton() As Bitmap

            Dim mybitmap As Bitmap = New Bitmap(Me.Width, Me.Height)
            Dim g As Graphics = Graphics.FromImage(mybitmap)
            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
            Dim myBrush2 As New Drawing.SolidBrush(ColorsAvailable.getColor(myColor2))
            Dim valHeight As Integer

            If intVal > 0 Then
                valHeight = ((Me.Height - 20) * intVal) \ intMax
            Else
                valHeight = 0
            End If

            If Me.RedAlert = LCARSalert.Red Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
            ElseIf Me.RedAlert = LCARSalert.White Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
            ElseIf Me.RedAlert = LCARSalert.Yellow Then
                myBrush = New Drawing.SolidBrush(Drawing.Color.Yellow)
            ElseIf inRedAlert = LCARSalert.Custom Then
                myBrush = New Drawing.SolidBrush(_customAlertColor)
            End If

            g.FillRectangle(Brushes.Black, New Rectangle(0, 0, Me.Width, Me.Height))

            g.FillRectangle(myBrush, New Rectangle(20, 10, Me.Width - 40, Me.Height - 20))



            g.FillRectangle(myBrush2, New Rectangle(20, ((Me.Height - 10) - valHeight), Me.Width - 40, valHeight))

            Dim myStep As Integer = (Me.Height - 22) \ 20
            If myStep < 1 Then
                myStep = 1
            End If
            For intloop As Integer = 10 To Me.Height - 12 Step myStep
                If intloop Mod 5 = 0 Then
                    g.FillRectangle(myBrush, New Rectangle(5, (Me.Height - intloop) - 2, 15, 2))
                    g.FillRectangle(myBrush, New Rectangle(Me.Width - 20, (Me.Height - intloop) - 2, 15, 2))

                Else
                    g.FillRectangle(Brushes.Red, New Rectangle(10, (Me.Height - intloop) - 2, 10, 2))
                    g.FillRectangle(Brushes.Red, New Rectangle(Me.Width - 20, (Me.Height - intloop) - 2, 10, 2))

                End If

            Next
            lblTextSize = Me.Size
            g.Dispose()

            Return mybitmap
        End Function

    End Class
End Namespace