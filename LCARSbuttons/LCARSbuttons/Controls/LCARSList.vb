Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

Namespace Controls
    Public Class LCARSList
        Inherits ListBox

        Public Sub New()
            MyBase.New()
            ' Needed to reset default values
            ResetFont()
            ResetBackColor()
            ResetForeColor()
            ResetBorderStyle()
            MyBase.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        End Sub

#Region " Overriding default property values "

#Region " Font "
        Protected Shared defFont As New Font("LCARS", 16, FontStyle.Regular, GraphicsUnit.Point)

        Public Overrides Sub ResetFont()
            Font = defFont
        End Sub

        Public Function ShouldSerializeFont() As Boolean
            Return Not defFont.Equals(Font)
        End Function

        Public Overrides Property Font() As System.Drawing.Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal value As System.Drawing.Font)
                MyBase.Font = value
                MyBase.ItemHeight = value.Height + DefaultPadding.Vertical
            End Set
        End Property
#End Region

#Region " Back Color "
        Protected Shared defBackColor As Color = Color.Black

        Public Overrides Sub ResetBackColor()
            MyBase.BackColor = defBackColor
        End Sub

        Public Function ShouldSerializeBackColor() As Boolean
            Return Not defBackColor = MyBase.BackColor
        End Function
#End Region

#Region " Fore Color "
        Protected Shared defForeColor As Color = Color.Orange

        Public Overrides Sub ResetForeColor()
            MyBase.ForeColor = defForeColor
        End Sub

        Public Function ShouldSerializeForeColor() As Boolean
            Return Not MyBase.ForeColor = defForeColor
        End Function
#End Region

#Region " Border "
        Protected Shared defBorder As BorderStyle = Windows.Forms.BorderStyle.FixedSingle

        Public Sub ResetBorderStyle()
            MyBase.BorderStyle = defBorder
        End Sub

        Public Function ShouldSerializeBorderStyle() As Boolean
            Return MyBase.BorderStyle <> defBorder
        End Function
#End Region
#End Region

        Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            If e.Index < 0 Then Return
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e = New DrawItemEventArgs(e.Graphics, _
                                          e.Font, _
                                          e.Bounds, _
                                          e.Index, _
                                          e.State Xor DrawItemState.Selected, _
                                          Color.White, _
                                          Color.Black)
            End If

            e.DrawBackground()
            Dim b As Brush = New SolidBrush(e.ForeColor)
            If e.Index >= Me.Items.Count Then
                'Draw the name only for design-time
                If Me.DesignMode Then
                    e.Graphics.DrawString(Me.Name, e.Font, b, e.Bounds, StringFormat.GenericDefault)
                End If
            Else
                Dim format As StringFormat = New StringFormat(StringFormat.GenericDefault)
                format.SetTabStops(0, TabStops)
                e.Graphics.DrawString(Me.Items(e.Index).ToString(), e.Font, b, e.Bounds, format)
            End If
        End Sub

        Private _tabs() As Single = {}

        Public Overridable Property TabStops() As Single()
            Get
                Return _tabs
            End Get
            Set(ByVal value As Single())
                _tabs = value
                Me.Invalidate()
            End Set
        End Property

        Public Shadows Sub RefreshItem(ByVal index As Integer)
            MyBase.RefreshItem(index)
        End Sub
    End Class
End Namespace