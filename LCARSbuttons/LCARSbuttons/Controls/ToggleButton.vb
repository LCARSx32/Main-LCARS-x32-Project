Option Strict On

Imports System.ComponentModel

Namespace Controls
    <DefaultEvent("Click")> _
    Public Class ToggleButton
        Inherits ComplexButton

        Private _trueText As String = "ON"
        Private _falseText As String = "OFF"

        Public Event StateChanged As EventHandler
        Public Sub New()
            State = True
        End Sub

        <DefaultValue(True)> _
        Public Property State() As Boolean
            Get
                Return Lit
            End Get
            Set(ByVal value As Boolean)
                Lit = value
                SideText = If(value, _trueText, _falseText)
                OnStateChanged()
            End Set
        End Property

        Protected Overridable Sub OnStateChanged()
            RaiseEvent StateChanged(Me, EventArgs.Empty)
        End Sub

        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            State = Not State
            MyBase.OnClick(e)
        End Sub

        <DefaultValue("ON")> _
        Public Property TrueText() As String
            Get
                Return _trueText
            End Get
            Set(ByVal value As String)
                _trueText = value
                If State Then
                    SideText = value
                End If
            End Set
        End Property

        <DefaultValue("OFF")> _
        Public Property FalseText() As String
            Get
                Return _falseText
            End Get
            Set(ByVal value As String)
                _falseText = value
                If Not State Then
                    SideText = value
                End If
            End Set
        End Property
    End Class
End Namespace
