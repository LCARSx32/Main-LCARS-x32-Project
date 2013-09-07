''' <summary>
''' Marks a class as having a beeping property
''' </summary>
''' <remarks>
''' This is most often used to allow for a control to match the global beeping setting. Implementation
''' will vary based on whether there are subcontrols.
''' </remarks>
Public Interface IBeeping
    ''' <summary>
    ''' Sets the beeping property of the control.
    ''' </summary>
    Property Beeping() As Boolean
End Interface
