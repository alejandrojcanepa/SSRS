Public Class NorthStarTrusteeServicingReport
    Inherits BaseReport

    Function GroupLabel(ByVal date_of_death As Nullable(Of Date), ByVal client As String, ByVal payoff_date_service As Nullable(Of Date), ByVal program As String, ByVal VPCProvider As String, ByVal coll_rel_agrmnt_date As Nullable(Of Date), ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String, ByVal owner As String, ByVal policies_status As String, ByVal kbc_decision As String, ByVal VPLSLStatus As String, ByVal strike_price_paid As String, ByVal original_strike_price_check As String, ByVal adj_strike_price_check As String, ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String, ByVal VBPOAProvider As String) As String
        If Not (IsNothing(date_of_death)) Then
            Return 100
        ElseIf client = "Hyperion Fund" Then
            Return 5.9
        ElseIf client = "NLSS (Back-Up Service)" Then
            Return 5.99
        ElseIf program = "63" Then
            Return 5.96
        ElseIf program = "66" Then
            Return 5.97
        ElseIf program = "69" Then
            Return 5.985
        ElseIf program = "221" Then
            Return 5.986
        ElseIf program = "224" Then
            Return 5.987
        ElseIf program = "78" Then
            Return 5.988
        ElseIf program = "212" Then
            Return 5.989
        ElseIf program = "223" Then
            Return 5.9891
        ElseIf program = "74" Then
            Return 5.975
        ElseIf program = "76" Then
            Return 5.976
        ElseIf program = "65" Then
            Return 5.98
        ElseIf program = "108" Then
            Return 5.91
        ElseIf program = "112" Then
            Return 5.905
        ElseIf program = "120" Then
            Return 5.92
        ElseIf program = "102" Then
            Return 5.95
        ElseIf program = "110" Then
            Return 5.955
        ElseIf program = "201" Then
            Return 4.4
        ElseIf program = "250" Then
            Return 5.9892
        ElseIf program = "260" Then
            Return 5.98925
        ElseIf program = "270" Then
            Return 5.98926
        ElseIf program = "280" Then
            Return 5.98927
        ElseIf program = "225" Then
            Return 5.9893
        ElseIf Not (IsNothing(coll_rel_agrmnt_date)) Then
            Return 200
        ElseIf Not (IsNothing(confirmed_lapse_date)) Then
            Return 99
        ElseIf program = "100" Then
            Return 5.6
        ElseIf ltr_22_month_response = "Transaction Rescinded" Then
            Return 120
        ElseIf owner = "EFG" And policies_status = "Sold" Then
            Return 4.5
        ElseIf (_End(note_purchaser, endorsee) <> "Spurling Group LLC" And _End(note_purchaser, endorsee) <> "Spurling Group II LLC" And _End(note_purchaser, endorsee) <> "Stone Spring PC LLC" And _End(note_purchaser, endorsee) <> "Stone Spring PC, LLC" And InStr(_End(note_purchaser, endorsee), "MCC Buy Back") = 0 And _End(note_purchaser, endorsee) <> "") Then
            Return 98
        ElseIf _Pur(purchaser, VBPOAProvider) <> "" Then
            Return 97
        ElseIf kbc_decision = "Distressed/Surrender" Then
            Return 96
        ElseIf InStr(ltr_22_month_response, "Cash", 0) > 0 Or InStr(VPLSLStatus, "Cash", 0) > 0 Or (Not IsNothing(payoff_date_service) AndAlso (CStr(payoff_date_service)) <> "") Then
            Return 130
        ElseIf program = "53" Then
            Return 5
        ElseIf program = "57" Then
            Return 5.5
        ElseIf program = "101" Then
            Return 5.8
        ElseIf program = "106" Then
            Return 5.93
        ElseIf program = "107" Then
            Return 5.94
        ElseIf ltr_22_month_response = "Transaction Rescinded" Then
            Return 6
        ElseIf (IsNothing(strike_price_paid) Or (Not IsNothing(strike_price_paid) AndAlso strike_price_paid <> "")) And (VPCProvider = "Oceanus" Or VPCProvider = "Seaboard") Then
            Return 2.7
        ElseIf original_strike_price_check = "T" And (VPCProvider = "Oceanus" Or VPCProvider = "Seaboard") Then
            Return 2.6
        ElseIf adj_strike_price_check = "T" Then
            Return 2.5
        Else
            Return 4
        End If
    End Function


    Function GroupBy(ByVal program As String, ByVal strike_price_paid As String, ByVal adj_strike_price_check As String, ByVal date_of_death As Nullable(Of Date), ByVal client As String, ByVal payoff_date_service As Nullable(Of Date), ByVal VPCProvider As String, ByVal coll_rel_agrmnt_date As Nullable(Of Date), ByVal confirmed_lapse_date As Nullable(Of Date), ByVal ltr_22_month_response As String, ByVal owner As String, ByVal policies_status As String, ByVal kbc_decision As String, ByVal VPLSLStatus As String, ByVal original_strike_price_check As String, ByVal note_purchaser As String, ByVal endorsee As String, ByVal purchaser As String, ByVal VBPOAProvider As String) As String
        If GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 100 Then
            Return "Deceased"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.9 Then
            Return "Hyperion"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.905 Then
            Return "Blackstone Service"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.91 Then
            Return "Monarch 1 Service"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.92 Then
            Return "Hyperion II"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.93 Then
            Return "M2 to Del Mar"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.94 Then
            Return "Del Mar to PCH"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.95 Then
            Return "Monarch 2"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.955 Then
            Return "Monarch Misc"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.96 Then
            Return "J-Curve Loan Centurion"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.97 Then
            Return "J-Curve Centurion Private"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.975 Then
            Return "J-Curve Loan Centurion NCK"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.976 Then
            Return "J-Curve Service Centurion NCK"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.98 Then
            Return "J-Curve Loan AGI"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.985 Then
            Return "J-Curve Loan GISF"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.986 Then
            Return "J-Curve Loan Secure Capital"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.987 Then
            Return "J-Curve Loan MISC"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.988 Then
            Return "J-Curve Loan Surety"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.989 Then
            Return "J-Curve Loan Edgewater"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.9891 Then
            Return "J-Curve Service MCI"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.9892 Then
            Return "Corry Capital Advisers"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.98925 Then
            Return "Cromwell"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.98926 Then
            Return "LSS - JMD"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.98927 Then
            Return "ALS Capital Ventures"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.9893 Then
            Return "Europa EFG"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.99 Then
            Return "NLSS (Back-Up Service)"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 200 Then
            Return "Note Payoff"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 99 Then
            Return "Confirmed Lapse"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 4.5 Then
            Return "EFG Sold"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 4.4 Then
            Return "Fortress Additional PHL"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 98 Then
            Return "Sold Notes"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 97 Then
            Return "Sold Policies"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 96 Then
            Return "Distressed/Surrendered"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 130 Then
            Return "Cash Payoff"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 120 Then
            Return "Transaction Rescinded"
        ElseIf program = "53" Then
            Return "Lux Co Del Mar"
        ElseIf program = "57" Then
            Return "Lux Co Sonoma"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.6 Then
            Return "MCC to Lux Co"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 5.8 Then
            Return "Companion"
        ElseIf GroupLabel(date_of_death, client, payoff_date_service, program, VPCProvider, coll_rel_agrmnt_date, confirmed_lapse_date, ltr_22_month_response, owner, policies_status, kbc_decision, VPLSLStatus, strike_price_paid, original_strike_price_check, adj_strike_price_check, note_purchaser, endorsee, purchaser, VBPOAProvider) = 6 Then
            Return "Transaction Rescinded"
        ElseIf VPCProvider <> "Oceanus" And VPCProvider <> "Seaboard" Then
            Return "Other"
        Else
            If IsNothing(strike_price_paid) Or (Not IsNothing(strike_price_paid) AndAlso CStr(strike_price_paid) <> "") Then
                Return "Option Not Exercised"
            ElseIf original_strike_price_check = "T" Then
                Return "Regular Option Exercise"
            ElseIf adj_strike_price_check = "T" Then
                Return "Early Option Exercise"
            End If
        End If
    End Function

    Function PolicyAge(ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date), ByVal issueage As Long) As Double
        Dim age As Double
        Dim CurrentDate As Date
        CurrentDate = Today()

        If Not IsNothing(premiumadvancedate) Then
            age = DateDiff("d", premiumadvancedate, CurrentDate) / 365.0
        Else
            age = DateDiff("d", aniversarydate, CurrentDate) / 365.0
        End If
        Return issueage + FormatNumber(age, 2)
    End Function

    Function SeparateRequest(ByVal mer_need_sep_req As String) As String
        If mer_need_sep_req = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function ROP_func(ByVal rop As String) As String
        If rop = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function ROPDB(ByVal rop As String, ByVal total_death_benefit As Decimal, ByVal nullnumberforcrystal As Nullable(Of Decimal)) As Nullable(Of Decimal)
        If rop = "T" Then
            Return total_death_benefit
        Else
            Return nullnumberforcrystal
        End If
    End Function

    Function DBChange(ByVal db_change As String, ByVal deathbenefit As Decimal, ByVal partial_surrender_amount As Decimal, ByVal nullnumberforcrystal As Nullable(Of Decimal)) As Nullable(Of Decimal)
        If db_change <> "" Then
            Return deathbenefit + partial_surrender_amount
        Else
            Return nullnumberforcrystal
        End If
    End Function

    Function Owner_Trustee(ByVal new_owner_name As String, ByVal ilittrustee As String) As String
        If Not IsNothing(new_owner_name) Then
            Return new_owner_name
        Else
            Return ilittrustee
        End If
    End Function

    Function AgingInMonth(ByVal last_coi_date As Nullable(Of Date)) As String
        If Not IsNothing(last_coi_date) Then
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return CStr(DateDiff("d", last_coi_date, CurrentDate) / 30.42)
        End If
    End Function

    Function PolicyRunssOff(ByVal cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String) As String
        Dim str As String
        str = ""

        If cv = "T" Then str = str & "CV,"
        If csv = "T" Then str = str & "CSV,"
        If monthly_ga = "T" Then str = str & "Monthly GA,"
        If annual_ga = "T" Then str = str & "Annual GA,"
        If shaow_acct = "T" Then str = str & "Shadow Acc,"
        If coi_estimated = "T" Then str = str & "COI Estimated,"
        If Right(str, 1) = "," Then str = Left(str, Len(str) - 1)
        Return str
    End Function

    Function PolicyValuesAge(ByVal VPVSRLPVMost_recent_received As Nullable(Of Date)) As String
        If Not IsNothing(VPVSRLPVMost_recent_received) Then
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return CStr(DateDiff("d", VPVSRLPVMost_recent_received, CurrentDate) / 30.42)
        End If
    End Function

    Function IllustrationRe_request(ByVal rerequest_check As String) As String
        If rerequest_check = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function MinPayIllustrationRequestOpen(ByVal VILSSIllustration_run_date As Nullable(Of Date), ByVal VILSSDate_request_sent_to_carrier As Nullable(Of Date)) As Date
        If IsNothing(VILSSIllustration_run_date) And Not IsNothing(VILSSDate_request_sent_to_carrier) Then
            Return VILSSDate_request_sent_to_carrier
        End If
    End Function

    Function RateIncrease(ByVal VLRCNCorrespondence_type As String, ByVal VRINRate_increase As String) As String
        If Not IsNothing(VLRCNCorrespondence_type) Then
            If VRINRate_increase = "Y" Then
                Return "Yes"
            Else
                Return "No"
            End If
        Else
            Return ""
        End If
    End Function

    Function SSN2(ByVal ssn As String) As String
        If Len(ssn) = 9 Then
            Return Left(ssn, 3) & "-" & Mid(ssn, 4, 2) & "-" & Right(ssn, 4)
        Else
            Return ssn
        End If
    End Function

End Class
