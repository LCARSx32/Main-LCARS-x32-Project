''' <summary>
''' An object capable of being set to an alert state
''' </summary>
''' <remarks>
''' This allows objects to implement their own alert functionality without relying on
''' inheritance to access the properties.
''' </remarks>
Public Interface IAlertable
    ''' <summary>
    ''' The alert status of the object
    ''' </summary>
    ''' <remarks>
    ''' Sets the actual alert status of the object
    ''' </remarks>
    Property RedAlert() As LCARS.LCARSalert
    ''' <summary>
    ''' The color to display if RedAlert is set to Custom
    ''' </summary>
    ''' <remarks>
    ''' Setting this property will not result in any change in the display unless
    ''' the RedAlert property is set to Custom
    ''' </remarks>
    Property CustomAlertColor() As System.Drawing.Color
End Interface
