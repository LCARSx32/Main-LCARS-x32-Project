Namespace Controls
    <System.ComponentModel.Designer(GetType(LCARSLabelDesigner))> _
    Public Class LCARSLabel
        Inherits System.Windows.Forms.Label
        Implements LCARS.IColorable

        Private _ColorsAvailable As New LCARScolor
        Private _color As LCARScolorStyles = LCARScolorStyles.Orange
        Private _textHeight As Integer = 18

        Public Sub New()
            AddHandler _ColorsAvailable.ColorsUpdated, AddressOf Me_ColorsUpdated
            Me.BackColor = Drawing.Color.Black
            Me_ColorsUpdated()
            Me.Font = New System.Drawing.Font("LCARS", _textHeight, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        End Sub

        Private Sub Me_ColorsUpdated()
            ForeColor = _ColorsAvailable.getColor(_color)
            Me.Refresh()
        End Sub

        <System.ComponentModel.DesignerSerializationVisibility(ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property ColorsAvailable() As LCARScolor Implements IColorable.ColorsAvailable
            Get
                Return _ColorsAvailable
            End Get
            Set(ByVal value As LCARScolor)
                _ColorsAvailable = value
                Me_ColorsUpdated()
            End Set
        End Property

        Public Property Color() As LCARScolorStyles
            Get
                Return _color
            End Get
            Set(ByVal value As LCARScolorStyles)
                _color = value
                Me_ColorsUpdated()
            End Set
        End Property

        Public Property TextHeight() As Integer
            Get
                Return _textHeight
            End Get
            Set(ByVal value As Integer)
                _textHeight = value
                Me.Font = New System.Drawing.Font("LCARS", _textHeight, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            End Set
        End Property
    End Class

#Region " Designer "
    Friend Class LCARSLabelDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner
        Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
            MyBase.PostFilterProperties(properties)
            properties.Remove("ForeColor")
            properties.Remove("BackColor")
            properties.Remove("Font")
        End Sub
    End Class
#End Region
End Namespace
