''' <summary>
''' Clase para manejar la funcionalidad del reporte Third Party Authorization
''' </summary>
Public Class ThirdPartyAuthorizationReport
    Inherits BaseReport

    ''' <summary>
    ''' Obtiene un número que determina por que campo agrupar
    ''' </summary>
    ''' <param name="date_of_death">Corresponde al campo opportunity_ext.date_of_death</param>
    ''' <param name="policiy_owner">Corresponde al campo policies.owner</param>
    ''' <param name="programNumeral">Corresponde al campo view_3rd_party_authorization.program #</param>
    ''' <param name="confirmed_lapse_date">Corresponde al campo prem_reqs_new.confirmed_lapse_date</param>
    ''' <param name="ltr_22_month_response">Corresponde al campo loans.ltr_22_month_response</param>
    ''' <param name="note_purchaser">Corresponde al campo loans.note_purchaser</param>
    ''' <param name="endorsee">Corresponde al campo policies.endorsee</param>
    ''' <param name="purchaser">Corresponde al campo view_best_purchaser_offer_accepted.purchaser</param>
    ''' <param name="VBPOAProvider">Corresponde al campo view_best_purchaser_offer_accepted.provider</param>
    ''' <param name="kbc_decision">Corresponde al campo view_premium_latest_by_source_date.kbc_decision</param>
    ''' <param name="status">Corresponde al campo view_policy_lonsdale_status_latest.status</param>
    ''' <param name="payoff_date_service">Corresponde al campo loans.payoff_date_service</param>
    ''' <param name="VPCProgram">Corresponde al campo view_policy_consolidated.program</param>
    ''' <param name="strike_price_paid">Corresponde al campo option_exercise_notice.strike_price_paid</param>
    ''' <param name="VPCProvider">Corresponde al campo View_Policy_Consolidated.provider</param>
    ''' <param name="original_strike_price_check">Corresponde al campo option_exercise_notice.original_strike_price_check</param>
    ''' <param name="adj_strike_price_check">Corresponde al campo option_exercise_notice.adj_strike_price_check</param>
    ''' <returns>Un número entre 100 y 4 que determina por que campo agrupar</returns>
    Function GroupLabel(ByVal date_of_death As Nullable(Of Date), ByVal policiy_owner As String, ByVal programNumeral As String,
                        ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String,
                        ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String,
                        ByVal VBPOAProvider As String, ByVal kbc_decision As String, ByVal status As String,
                        ByVal payoff_date_service As Nullable(Of Date), ByVal VPCProgram As String, ByVal strike_price_paid As Nullable(Of Date),
                        ByVal VPCProvider As String, ByVal original_strike_price_check As String, ByVal adj_strike_price_check As String) As Decimal

        If Not IsNothing(date_of_death) Then
            Return 100
        ElseIf policiy_owner = "EFG" Then
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
        ElseIf VPCProgram = "53" Then
            Return 5
        ElseIf VPCProgram = 57 Then
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

    ''' <summary>
    ''' Obtiene el campo por el que se debe agrupar
    ''' </summary>
    ''' <param name="date_of_death">Corresponde al campo opportunity_ext.date_of_death</param>
    ''' <param name="policiy_owner">Corresponde al campo policies.owner</param>
    ''' <param name="programNumeral">Corresponde al campo view_3rd_party_authorization.program #</param>
    ''' <param name="confirmed_lapse_date">Corresponde al campo prem_reqs_new.confirmed_lapse_date</param>
    ''' <param name="ltr_22_month_response">Corresponde al campo loans.ltr_22_month_response</param>
    ''' <param name="note_purchaser">Corresponde al campo loans.note_purchaser</param>
    ''' <param name="endorsee">Corresponde al campo policies.endorsee</param>
    ''' <param name="purchaser">Corresponde al campo view_best_purchaser_offer_accepted.purchaser</param>
    ''' <param name="VBPOAProvider">Corresponde al campo view_best_purchaser_offer_accepted.provider</param>
    ''' <param name="kbc_decision">Corresponde al campo view_premium_latest_by_source_date.kbc_decision</param>
    ''' <param name="status">Corresponde al campo view_policy_lonsdale_status_latest.status</param>
    ''' <param name="payoff_date_service">Corresponde al campo loans.payoff_date_service</param>
    ''' <param name="VPCProgram">Corresponde al campo view_policy_consolidated.program</param>
    ''' <param name="strike_price_paid">Corresponde al campo option_exercise_notice.strike_price_paid</param>
    ''' <param name="VPCProvider">Corresponde al campo View_Policy_Consolidated.provider</param>
    ''' <param name="original_strike_price_check">Corresponde al campo option_exercise_notice.original_strike_price_check</param>
    ''' <param name="adj_strike_price_check">Corresponde al campo option_exercise_notice.adj_strike_price_check</param>
    ''' <returns>Un string con el campo por el que se debe agrupar</returns>
    Function GroupBy(ByVal date_of_death As Nullable(Of Date), ByVal policiy_owner As String, ByVal programNumeral As String,
                        ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String,
                        ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String,
                        ByVal VBPOAProvider As String, ByVal kbc_decision As String, ByVal status As String,
                        ByVal payoff_date_service As Nullable(Of Date), ByVal VPCProgram As String, ByVal strike_price_paid As Nullable(Of Date),
                        ByVal VPCProvider As String, ByVal original_strike_price_check As String, ByVal adj_strike_price_check As String) As String


        If GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 100 Then
            Return "Deceased"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 99 Then
            Return "Confirmed Lapse"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 98 Then
            Return "Sold Notes"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 97 Then
            Return "Sold Policies"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 96 Then
            Return "Distressed/Surrendered"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 95 Then
            Return "MCC to LuxCo"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 94 Then
            Return "MCC to HighField"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 80 Then
            Return "EFG"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 130 Then
            Return "Cash Payoff"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 120 Then
            Return "Transaction Rescinded"
        ElseIf VPCProgram = "53" Then
            Return "Lux Co Del Mar"
        ElseIf VPCProgram = "57" Then
            Return "Lux Co Sonoma"
        ElseIf GroupLabel(date_of_death, policiy_owner, programNumeral, confirmed_lapse_date, ltr_22_month_response, note_purchaser, endorsee, purchaser, VBPOAProvider, kbc_decision, status, payoff_date_service, VPCProgram, strike_price_paid, VPCProgram, original_strike_price_check, adj_strike_price_check) = 6 Then
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

End Class
