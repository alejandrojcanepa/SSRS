Public Class BaseReport
    Function _End(ByVal note_purchaser As String, ByVal endorsee As String) As String
        If IsNothing(note_purchaser) Or note_purchaser = "" Then
            Return endorsee
        Else
            Return note_purchaser
        End If
    End Function

    Function _Pur(ByVal purchaser As String, ByVal VBPOAProvider As String) As String
        If IsNothing(purchaser) Or Trim(purchaser) = "" Or Trim(purchaser) = "-" Then
            Return VBPOAProvider
        ElseIf Not (IsNothing(purchaser)) And Trim(purchaser) <> "" Then
            Return purchaser
        Else
            Return "n/a"
        End If
    End Function

End Class
