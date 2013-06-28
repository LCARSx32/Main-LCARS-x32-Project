''' <summary>
''' Color constants for LCARS colors
''' </summary>
''' <remarks>Should not be expanded without rewriting LCARS Color Class</remarks>
Public Enum LCARScolorStyles
    FunctionUnavailable = 0
    SystemFunction = 1
    MiscFunction = 2
    CriticalFunction = 3
    NavigationFunction = 4
    LCARSDisplayOnly = 5
    PrimaryFunction = 6
    FunctionOffline = 7
    StaticTan = 8
    Orange = 9
    StaticBlue = 10
End Enum

''' <summary>
''' Constants for different alert types
''' </summary>
''' <remarks>Can be used for a crude custom coloring of buttons</remarks>
Public Enum LCARSalert
    Normal = 0
    ''' <summary>
    ''' Red color
    ''' </summary>
    ''' <remarks></remarks>
    Red = 1
    ''' <summary>
    ''' White color
    ''' </summary>
    ''' <remarks>Will show as red if used on a white button. Not used very often.</remarks>
    White = 2
    ''' <summary>
    ''' Yellow color
    ''' </summary>
    ''' <remarks>Not present in early builds.</remarks>
    Yellow = 3
    ''' <summary>
    ''' Custom color
    ''' </summary>
    ''' <remarks>Setting this activates previously set custom color. Used for all alerts in LCARSmain.</remarks>
    Custom = 4
End Enum

''' <summary>
''' Arrow directions for ArrowButton
''' </summary>
''' <remarks></remarks>
Public Enum LCARSarrowDirection
    Up = 0
    Down = 1
    Left = 2
    Right = 3
End Enum
