Public Class VivaWilmingtonWiringInstructionReport

    Function Amount(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal) As Decimal
        Return AdjReqPrem(override_premium, adj_est_prem)
    End Function

    Function AdjReqPrem(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal) As Decimal
        If Not IsNothing(override_premium) Then
            Return override_premium
        Else
            Return adj_est_prem
        End If
    End Function

End Class
