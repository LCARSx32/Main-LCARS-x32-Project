Public Class LightweightControlEventArgs
    Inherits EventArgs

    Dim _moved As Boolean = True
    ''' <summary>
    ''' Returns a new instance of the LightweightControlEventArgs class
    ''' </summary>
    ''' <param name="Moved">Whether the control has been moved by the update</param>
    Public Sub New(ByVal Moved As Boolean)
        _moved = Moved
    End Sub
    ''' <summary>
    ''' Whether the control has been moved by the update
    ''' </summary>
    ''' <remarks>
    ''' If the control has not been moved, then only that section of the display needs to be updated. If the control has been moved,
    ''' then the old position must be updated as well.
    ''' </remarks>
    Public ReadOnly Property Moved() As Boolean
        Get
            Return _moved
        End Get
    End Property
End Class
