Public Class YesNoAskControl
    ' Fields...
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        YesNoAskValue = YesNoAskEnum.Ask
    End Sub

    Dim mYesNoAskValue As YesNoAskEnum
    Public Property YesNoAskValue As YesNoAskEnum
        Get
            Select Case YesNoAskCombo.SelectedIndex
                Case 0
                    Return YesNoAskEnum.Yes
                Case 1
                    Return YesNoAskEnum.No
                Case 2
                    Return YesNoAskEnum.Ask
                Case Else
                    YesNoAskCombo.SelectedIndex = 2
                    Return YesNoAskEnum.Ask
            End Select
        End Get
        Set(ByVal Value As YesNoAskEnum)
            Select Case Value
                Case YesNoAskEnum.Yes
                    YesNoAskCombo.SelectedIndex = 0
                Case YesNoAskEnum.No
                    YesNoAskCombo.SelectedIndex = 1
                Case YesNoAskEnum.Ask
                    YesNoAskCombo.SelectedIndex = 2
                Case Else
                    YesNoAskCombo.SelectedIndex = 2
            End Select
        End Set
    End Property

End Class
