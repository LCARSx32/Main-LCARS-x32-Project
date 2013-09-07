''' <summary>
''' Marks a class as using LCARS colors and allows those colors to be accessed.
''' </summary>
''' <remarks>
''' This interface exposes the LCARScolor class, but that class is rarely directly set.
''' </remarks>
Public Interface IColorable
    ''' <summary>
    ''' Exposes LCARScolor class used by the control for color management
    ''' </summary>
    Property ColorsAvailable() As LCARS.LCARScolor
End Interface
