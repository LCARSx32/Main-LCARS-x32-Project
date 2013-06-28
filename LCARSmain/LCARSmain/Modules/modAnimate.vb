Module modAnimate

    Public Structure AnimateParams
        Dim myPanel As Control
        Dim MakeVisible As Boolean
        Dim interval As Integer
        Dim AnimateSubPanels As Boolean
    End Structure

    Public Sub AnimatePanel(ByRef myPanel As Control, ByVal makeVisible As Boolean, Optional ByVal interval As Integer = 10, Optional ByVal AnimateSubPanels As Boolean = True, Optional ByVal Wait As Boolean = False)
        Dim mythread As New Threading.ParameterizedThreadStart(AddressOf doAnimate)
        Dim mystarter As New Threading.Thread(AddressOf mythread.Invoke)

        Dim myParams As New AnimateParams

        myParams.myPanel = myPanel
        myParams.MakeVisible = makeVisible
        myParams.interval = interval
        myParams.AnimateSubPanels = AnimateSubPanels

        If Wait = False Then
            mystarter.Start(myParams)
        Else
            mythread.Invoke(myParams)

        End If

    End Sub

    Public Sub doAnimate(ByVal params As Object)

        Dim index As Integer
        Dim myPanel As Control
        Dim makeVisible As Boolean
        Dim interval As Integer
        Dim animateSubPanels As Boolean

        With CType(params, AnimateParams)
            myPanel = .myPanel
            makeVisible = .MakeVisible
            interval = .interval
            animateSubPanels = .AnimateSubPanels
        End With

        If makeVisible = True Then
            'Code to show the controls:
            If animateSubPanels = True Then
                For Each myControl As Control In myPanel.Controls
                    If myControl.Controls.Count > 0 And Not myControl.GetType.ToString.Substring(0, 5).ToLower = "lcars" And myControl.Visible = True Then
                        AnimatePanel(myControl, True, interval)
                    End If
                Next
            End If

            If Not myPanel.Tag Is Nothing Then
                Dim upper As Integer = -1

                If Integer.TryParse(myPanel.Tag, upper) Then
                    Do Until index >= upper


                        For Each myControl As Control In myPanel.Controls
                            If Not myControl.Tag Is Nothing And myControl.Tag <> "" Then
                                If myControl.Tag = index Then
                                    myControl.Visible = True
                                    Application.DoEvents()
                                End If
                            End If

                        Next

                        index += 1
                        Application.DoEvents()
                        Threading.Thread.Sleep(interval)
                    Loop
                End If

            End If

        Else
            'Code to hide the controls:

            'close all sub panels first.
            If animateSubPanels = True Then
                For Each myControl As Control In myPanel.Controls
                    If myControl.Controls.Count > 0 And Not myControl.GetType.ToString.Substring(0, 4).ToLower = "lcars" And myControl.Visible = True Then
                        AnimatePanel(myControl, False, interval)
                    End If
                Next
            End If

            If Not myPanel.Tag Is Nothing Then
                If Not myPanel.Tag Is Nothing Then
                    If Integer.TryParse(myPanel.Tag, index) Then
                        index -= 1
                    Else
                        index = -1
                    End If

                End If
            End If


            Do Until index = -1
                For Each myControl As Control In myPanel.Controls
                    If Not myControl.Tag Is Nothing And myControl.Tag <> "" Then
                        If myControl.Tag = index Then
                            myControl.Visible = False
                            Application.DoEvents()
                        End If
                    End If
                Next

                index -= 1
                Application.DoEvents()
                Threading.Thread.Sleep(interval)
            Loop

            GC.Collect()

        End If

    End Sub

End Module
