Public Interface IAutohide
    Enum AutoHideModes
        Disabled = 0
        Visible = 1
        Hidden = 2
    End Enum

    <Flags()> _
    Enum AutohideEdges
        Top = 1
        Left = 2
        Bottom = 4
        Right = 8
    End Enum

    Function getAutohideEdges() As AutohideEdges

End Interface
