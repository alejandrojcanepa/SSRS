Public Class ThirdPartyAuthorizationReport
    Inherits BaseReport

    Function GroupLabel(ByVal date_of_death As Nullable(Of Date), ByVal policy_owner As String, ByVal programNumeral As String, ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String, ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String, ByVal VBPOAProvider As String, ByVal kbc_decision As String, ByVal status As String, ByVal payoff_date_service As Nullable(Of Date), ByVal program As String, ByVal strike_price_paid As Nullable(Of Date), ByVal VPCProvider As String, ByVal original_strike_price_check As String, ByVal adj_strike_price_check As String) As Decimal
        If Not IsNothing(date_of_death) Then
            Return 100
        ElseIf policy_owner = "EFG" Then
            Return 80
        ElseIf programNumeral = "100" Then
            Return 95
        ElseIf programNumeral = "0-H" Then
            Return 94
        ElseIf Not IsNothing(confirmed_lapse_date) Then
            Return 99
        ElseIf ltr_22_month_response = "Transaction Rescinded" Then
            Return 120
        ElseIf _End(note_purchaser, endorsee) <> "Spurling Group LLC" And _End(note_purchaser, endorsee) <> "Spurling Group II LLC" And _End(note_purchaser, endorsee) <> "Stone Spring PC LLC" And _End(note_purchaser, endorsee) <> "Stone Spring PC, LLC" And InStr(_End(note_purchaser, endorsee), "MCC Buy Back") = 0 And _End(note_purchaser, endorsee) <> "" Then
            Return 98
        ElseIf _Pur(purchaser, VBPOAProvider) <> "" Then
            Return 97
        ElseIf kbc_decision = "Distressed/Surrender" Then
            Return 96
        ElseIf InStr(ltr_22_month_response, "Cash", 0) > 0 Or InStr(status, "Cash", 0) > 0 Or (Not IsNothing(payoff_date_service) AndAlso CStr(payoff_date_service) <> "") Then
            Return 130
        ElseIf program = "53" Then
            Return 5
        ElseIf program = 57 Then
            Return 5.5
        ElseIf ltr_22_month_response = "Transaction Rescinded" Then
            Return 6
        ElseIf IsNothing(strike_price_paid) And VPCProvider = "Oceanus" Or VPCProvider = "Seaboard" Then
            Return 2.7
        ElseIf original_strike_price_check = "T" And VPCProvider = "Oceanus" Or VPCProvider = "Seaboard" Then
            Return 2.6
        ElseIf adj_strike_price_check = "T" Then
            Return 2.5
        Else
            Return 4
        End If
    End Function

    Function GroupBy(ByVal date_of_death As Nullable(Of Date), ByVal policy_owner As String, ByVal programNumeral As String, ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String, ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String, ByVal VBPOAProvider As String, ByVal kbc_decision As String, ByVal status As String, ByVal payoff_date_service As Nullable(Of Date), ByVal program As String, ByVal strike_price_paid As Nullable(Of Date), ByVal VPCProvider As String, ByVal original_strike_price_check As String, ByVal adj_strike_price_check As String) As String
        If GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 100 Then
            Return "Deceased"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 99 Then
            Return "Confirmed Lapse"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 98 Then
            Return "Sold Notes"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 97 Then
            Return "Sold Policies"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 96 Then
            Return "Distressed/Surrendered"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 95 Then
            Return "MCC to LuxCo"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 94 Then
            Return "MCC to HighField"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 80 Then
            Return "EFG"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 130 Then
            Return "Cash Payoff"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 120 Then
            Return "Transaction Rescinded"
        ElseIf program = "53" Then
            Return "Lux Co Del Mar"
        ElseIf program = "57" Then
            Return "Lux Co Sonoma"
        ElseIf GroupLabel(date_of_death, policy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, program, strike_price_paid, program, original_strike_price_check, adj_strike_price_check) = 6 Then
            Return "Transaction Rescinded"
        ElseIf VPCProvider <> "Oceanus" And VPCProvider <> "Seaboard" Then
            Return "Other"
        Else
            If IsNothing(strike_price_paid) Then
                Return "Option Not Exercised"
            ElseIf original_strike_price_check = "T" Then
                Return "Regular Option Exercise"
            ElseIf adj_strike_price_check = "T" Then
                Return "Early Option Exercise"
            End If
        End If

    End Function

    Function IndefiniteAuthorization(ByVal indefinite As String) As String
        If indefinite = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function COOIndefinteAuthorization(ByVal COO_Indefinite As String) As String
        If COO_Indefinite = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

End Class
