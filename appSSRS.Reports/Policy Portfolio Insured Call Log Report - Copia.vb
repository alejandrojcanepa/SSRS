Public Class PolicyPortfolioInsuredCallLogReport

    Function ContactNumber(ByVal contact_number As String) As String
        If Not IsNothing(contact_number) Then
            Return "(" & (Left(contact_number, 3)) & ") " & (Mid(contact_number, 4, 3)) & "-" & Right(contact_number, 4)
        Else Return ""
        End If
    End Function

    Function PreferredContactNumber(ByVal contact_number As String) As String
        If Not IsNothing(contact_number) Then
            Return "(" & (Left(contact_number, 3)) & ") " & (Mid(contact_number, 4, 3)) & "-" & Right(contact_number, 4)
        Else Return ""
        End If
    End Function

End Class

