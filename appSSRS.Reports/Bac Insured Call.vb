Public Class BacInsuredCall_and_BACInsuredCallLogInternal

    Function ContactNumber(ByVal Contact_Number As String) As String
        If Not IsNothing(Contact_Number) Then
            Return "(" & (Left(Contact_Number, 3)) & ") " & (Mid(Contact_Number, 4, 3)) & "-" & Right(Contact_Number, 4)
        Else Return ""
        End If
    End Function

    Function PreferredContactNumber(ByVal Preferred_Contact_Numbers As String) As String
        If Not IsNothing(Preferred_Contact_Numbers) Then
            Return "(" & (Left(Preferred_Contact_Numbers, 3)) & ") " & (Mid(Preferred_Contact_Numbers, 4, 3)) & "-" & Right(Preferred_Contact_Numbers, 4)
        Else Return ""
        End If
    End Function

End Class