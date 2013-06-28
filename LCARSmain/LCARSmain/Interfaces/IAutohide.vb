Public Interface IAutohide
    Enum AutoHideModes
        Disabled = 0
        Visible = 1
        Hidden = 2
    End Enum

    Sub SetAutoHide(ByVal value As AutoHideModes)

End Interface
