Public Class VivaWellsFargoWiringInstructionReport

    Function PayDate() As Nullable(Of Date)
    End Function

    Function Amount(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal) As Decimal
        If Not IsNothing(override_premium) Then
            Return override_premium
        Else
            Return adj_est_prem
        End If
    End Function

    Function ClientId() As String
    End Function

    'It should receive a policyID as a parameter. The return is still unclear
    Function SEIAccount(ByVal policiesid As String) As String
        If policiesid = "Q6UJ9A00LGV0" Then
            Return "48571001"
        Else
            Return "84207301"
        End If
    End Function

    Function CheckAddress() As String
    End Function

    Function CheckCity_State_ZipCode() As String
    End Function

End Class
