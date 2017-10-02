Public Class UWMedsAndLEStatusReport2_Meridian
    ''' <summary>
    ''' Next DOB
    ''' </summary>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <returns></returns>
    Function Nextdob(ByVal dob As Nullable(Of Date))
        Dim result

        result = DateAdd("yyyy", Year(CurrentDate()) - Year(dob), dob)
        If DateDiff("d", CurrentDate(), result) < 0 Then dob = DateAdd("yyyy", 1, result)

        Return result

    End Function

    ''' <summary>
    ''' 21st Age Change
    ''' </summary>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <returns></returns>
    Function _21stNextAgeChange(ByVal dob As Nullable(Of Date))
        Return DateAdd("m", -6, Nextdob(dob))
    End Function


    ''' <summary>
    ''' All_Recs_Recvd_Age
    ''' </summary>
    ''' <param name="all_rec_recv_date">viewlatest_all_rec_recv_date.all_rec_recv_date</param>
    ''' <returns></returns>
    Function AllRecsRecvdAge(ByVal all_rec_recv_date As Nullable(Of Date))
        If IsNothing(AllRecsRecvd(all_rec_recv_date)) Then
            Return 0
        Else
            Return DateDiff("d", CDate(AllRecsRecvd(all_rec_recv_date)), CurrentDate()) / 30.42
        End If
    End Function


    ''' <summary>
    ''' APS_Update_In_Prog
    ''' </summary>
    ''' <param name="aps_update_in_prog">opportunity_ext.aps_update_in_prog </param>
    ''' <param name="aps_update_in_prog2">opportunity_ext.aps_update_in_prog2</param>
    ''' <param name="aps_update_in_prog3">opportunity_ext.aps_update_in_prog3</param>
    ''' <param name="apsupdateinprog_c_early">underwriting.apsupdateinprog_c_early</param>
    ''' <param name="apsupdateinprog_c_early2">underwriting.apsupdateinprog_c_early2</param>
    ''' <param name="opportunityid">view_aps_update_last_outstanding.opportunityid</param>
    ''' <returns></returns>
    Function APSUpdateInProg(ByVal aps_update_in_prog As String, ByVal aps_update_in_prog2 As String, ByVal aps_update_in_prog3 As String, ByVal apsupdateinprog_c_early As String, ByVal apsupdateinprog_c_early2 As String, ByVal opportunityid As String)
        If (aps_update_in_prog = "T" Or aps_update_in_prog2 = "T" Or aps_update_in_prog3 = "T" Or apsupdateinprog_c_early = "T" Or apsupdateinprog_c_early2 = "T") Or opportunityid <> "" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function


    ''' <summary>
    ''' AVS Age Change
    ''' </summary>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <returns></returns>
    ''' <remarks>duplicated on AVSNextAgeChange</remarks>
    Function AVSAgeChange(ByVal dob As Nullable(Of Date))
        If Not (IsNothing(dob)) Then
            Return DateAdd("m", -3, Nextdob(dob))
        End If
    End Function


    ''' <summary>
    ''' AVS primary diagnosis
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="avs_impairment1">view_le_latest_flat_service_2_nofilters.avs_impairment</param>
    ''' <param name="avs_impairment2">view_le_latest_flat_service_bac_nofilters.avs_impairment</param>
    ''' <param name="avs_impairment3">view_le_latest_flat_service_nofilters.avs_impairment</param>
    ''' <returns></returns>    ''' 
    Function AVSPrimaryDiagnosis(ByVal program As String, ByVal avs_impairment1 As String, ByVal avs_impairment2 As String, ByVal avs_impairment3 As String)
        If program = "59" Then
            Return avs_impairment2
        ElseIf IgnoreSyncToKBC(program) Then
            Return avs_impairment1
        Else
            Return avs_impairment3
        End If
    End Function


    ''' <summary>
    ''' Ignore Sync To KBC
    ''' </summary>
    ''' <param name="program">View_Policy_Consolidated.Program</param>
    ''' <returns></returns>
    Function IgnoreSyncToKBC(ByVal program As String)
        '-- request #3440. meridian programs should use diff. logic (ignore the KBC sync checkbox)
        Dim prom

        If IsNumeric(program) Then
            prom = CDbl(program)

            If prom >= 53 And prom < 59 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' AVS Rolled
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="avs_rolled1">view_le_latest_flat_service_2_nofilters.avs_rolled</param>
    ''' <param name="avs_rolled2">view_le_latest_flat_service_bac_nofilters.avs_rolled</param>
    ''' <param name="avs_rolled3">view_le_latest_flat_service_nofilters.avs_rolled</param>
    ''' <returns></returns>
    Function AVSRolled(ByVal program As String, ByVal avs_rolled1 As String, ByVal avs_rolled2 As String, ByVal avs_rolled3 As String)
        If program = "59" Then
            If avs_rolled2 = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        ElseIf IgnoreSyncToKBC(program) Then
            If avs_rolled1 = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        Else
            If avs_rolled3 = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        End If
    End Function

    ''' <summary>
    ''' DOB String
    ''' </summary>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <returns></returns>
    Function DOBString(ByVal dob As Nullable(Of Date))
        Return ToText(dob, "M/d/yyyy")
    End Function

    ''' <summary>
    ''' Exception
    ''' </summary>
    ''' <param name="policy_exception">policies.policy_exception</param>
    ''' <param name="exception_value">policies.exception_value</param>
    ''' <returns></returns>
    Function Exception(ByVal policy_exception As String, ByVal exception_value As String)
        If policy_exception = "T" Then
            Return exception_value
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Exception Date
    ''' </summary>
    ''' <param name="policy_exception">policies.policy_exception</param>
    ''' <param name="exception_date">policies.exception_date</param>
    ''' <param name="nulldateforcrystal">policies.nulldateforcrystal</param>
    ''' <returns></returns>
    Function ExceptionDate(ByVal policy_exception As String, ByVal exception_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If policy_exception = "T" Then
            Return exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    ''' <summary>
    ''' Fortress LE Due Date
    ''' </summary>
    ''' <param name="date_of_death">opportunity_ext.date_of_death</param>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <param name="nulldateforcrystal">policies.nulldateforcrystal</param>
    ''' <returns></returns>
    Function FortressLEDueDate(ByVal date_of_death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If IsNothing(date_of_death) And Not (IsNothing(dob)) Then

            Dim dd As Date

            If DateDiff("d", Nextdob(dob), CDate("2011/4/1")) > 0 Then '-- if the dob is less than April 2011, use next year
                dd = DateAdd("yyyy", 1, Nextdob(dob))
            Else
                dd = Nextdob(dob)
            End If
            Return DateAdd("d", -75, dd)
        Else
            Return nulldateforcrystal
        End If
    End Function


    ''' <summary>
    ''' Fortress Medical Records Due
    ''' </summary>
    ''' <param name="date_of_death">opportunity_ext.date_of_death</param>
    ''' <param name="dob">opportunity_ext.dob</param>
    ''' <param name="nulldateforcrystal">policies.nulldateforcrystal</param>
    ''' <returns></returns>
    Function FortressMedicalRecordsDue(ByVal date_of_death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If IsNothing(date_of_death) And Not (IsNothing(dob)) Then
            Return DateAdd("d", -1, AVSAgeChange(dob))
        Else
            Return nulldateforcrystal
        End If
    End Function

    ''' <summary>
    ''' Last_Visit_Date_Age
    ''' </summary>
    ''' <param name="last_visit_date">viewlast_aps_visit_date.last_visit_date</param>
    ''' <returns></returns>
    Function LastVisitDateAge(ByVal last_visit_date As Nullable(Of Date))
        If IsNothing(last_visit_date) Then
            Return 0
        Else
            Return DateDiff("d", last_visit_date, CurrentDate()) / 30.42
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="northstar_listed">view_hipaa_latest_signature_linked.northstar_listed</param>
    ''' <returns></returns>
    Function LatestHIPAANorthstar(ByVal northstar_listed As String)
        If northstar_listed = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Latest HIPAA Northstar
    ''' </summary>
    ''' <param name="signed_via_poa">view_hipaa_latest_signature_linked.signed_via_poa</param>
    ''' <returns></returns>
    Function LatestSignedViaPOA(ByVal signed_via_poa As String)
        If signed_via_poa = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' LE Due Date
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="avs_date1">view_le_latest_flat_service_2_nofilters.avs_date</param>
    ''' <param name="avs_date2">view_le_latest_flat_service_bac_nofilters.avs_date</param>
    ''' <param name="avs_date3">view_le_latest_flat_service_nofilters.avs_date</param>
    ''' <param name="avs_date4">view_le_latest_flat_service_monarch1_nofilters.avs_date</param>
    ''' <param name="tf_date1">view_le_latest_flat_service_2_nofilters.tf_date</param>
    ''' <param name="tf_date2">view_le_latest_flat_service_bac_nofilters.tf_date</param>
    ''' <param name="tf_date3">view_le_latest_flat_service_nofilters.tf_date</param>
    ''' <param name="tf_date4">view_le_latest_flat_service_monarch1_nofilters.tf_date</param>
    ''' <param name="emsi_date1">view_le_latest_flat_service_2_nofilters.emsi_date</param>
    ''' <param name="emsi_date2">view_le_latest_flat_service_bac_nofilters.emsi_date</param>
    ''' <param name="emsi_date3">view_le_latest_flat_service_nofilters.emsi_date</param>
    ''' <param name="emsi_date4">view_le_latest_flat_service_monarch1_nofilters.emsi_date</param>
    ''' <param name="nulldateforcrystal">policies.nulldateforcrystal</param>
    ''' <returns></returns>
    Function LEDUeDate(ByVal program As String, ByVal client As String, ByVal avs_date1 As Nullable(Of Date), ByVal avs_date2 As Nullable(Of Date), ByVal avs_date3 As Nullable(Of Date), ByVal avs_date4 As Nullable(Of Date), ByVal tf_date1 As Nullable(Of Date), ByVal tf_date2 As Nullable(Of Date), ByVal tf_date3 As Nullable(Of Date), ByVal tf_date4 As Nullable(Of Date), ByVal emsi_date1 As Nullable(Of Date), ByVal emsi_date2 As Nullable(Of Date), ByVal emsi_date3 As Nullable(Of Date), ByVal emsi_date4 As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        '-- earliest one among the 3 + 365
        Dim d
        d = CDate("1/1/2050")

        If Not IsNothing(MostRecentServiceAVS(program, client, avs_date1, avs_date2, avs_date3, avs_date4)) Then
            d = CDate(MostRecentServiceAVS(program, client, avs_date1, avs_date2, avs_date3, avs_date4))
        End If

        If Not IsNothing(MostRecentService21st(program, client, tf_date1, tf_date2, tf_date3, tf_date4)) Then
            If MostRecentService21st(program, client, tf_date1, tf_date2, tf_date3, tf_date4) < d Then
                d = CDate(MostRecentService21st(program, client, tf_date1, tf_date2, tf_date3, tf_date4))
            End If
        End If

        If Not IsNothing(MostRecentServiceEMSI(program, client, emsi_date1, emsi_date2, emsi_date3, emsi_date4)) Then
            If MostRecentServiceEMSI(program, client, emsi_date1, emsi_date2, emsi_date3, emsi_date4) < d Then
                d = CDate(MostRecentServiceEMSI(program, client, emsi_date1, emsi_date2, emsi_date3, emsi_date4))
            End If
        End If

        If Year(d) = 2050 Then
            Return nulldateforcrystal
        Else
            Return DateAdd("d", 365, d)
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service AVS
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="avs_date1">view_le_latest_flat_service_2_nofilters.avs_date</param>
    ''' <param name="avs_date2">view_le_latest_flat_service_bac_nofilters.avs_date</param>
    ''' <param name="avs_date3">view_le_latest_flat_service_nofilters.avs_date</param>
    ''' <param name="avs_date4">view_le_latest_flat_service_monarch1_nofilters.avs_date</param>
    ''' <returns></returns>
    Function MostRecentServiceAVS(ByVal program As String, ByVal client As String, ByVal avs_date1 As Nullable(Of Date), ByVal avs_date2 As Nullable(Of Date), ByVal avs_date3 As Nullable(Of Date), ByVal avs_date4 As Nullable(Of Date))
        If program = "59" Then
            Return avs_date2
        ElseIf client = "Monarch 1" Then
            Return avs_date4
        ElseIf IgnoreSyncToKBC(program) Then
            Return avs_date1
        Else
            Return avs_date3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service 21st
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="tf_date1">view_le_latest_flat_service_2_nofilters.tf_date</param>
    ''' <param name="tf_date2">view_le_latest_flat_service_bac_nofilters.tf_date</param>
    ''' <param name="tf_date3">view_le_latest_flat_service_nofilters.tf_date</param>
    ''' <param name="tf_date4">view_le_latest_flat_service_monarch1_nofilters.tf_date</param>
    ''' <returns></returns>
    Function MostRecentService21st(ByVal program As String, ByVal client As String, ByVal tf_date1 As Nullable(Of Date), ByVal tf_date2 As Nullable(Of Date), ByVal tf_date3 As Nullable(Of Date), ByVal tf_date4 As Nullable(Of Date))
        If program = "59" Then
            Return tf_date2
        ElseIf client = "Monarch 1" Then
            Return tf_date4
        ElseIf IgnoreSyncToKBC(program) Then
            Return tf_date1
        Else
            Return tf_date3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service EMSI
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="emsi_date1">view_le_latest_flat_service_2_nofilters.emsi_date</param>
    ''' <param name="emsi_date2">view_le_latest_flat_service_bac_nofilters.emsi_date</param>
    ''' <param name="emsi_date3">view_le_latest_flat_service_nofilters.emsi_date</param>
    ''' <param name="emsi_date4">view_le_latest_flat_service_monarch1_nofilters.emsi_date</param>
    ''' <returns></returns>
    Function MostRecentServiceEMSI(ByVal program As String, ByVal client As String, ByVal emsi_date1 As Nullable(Of Date), ByVal emsi_date2 As Nullable(Of Date), ByVal emsi_date3 As Nullable(Of Date), ByVal emsi_date4 As Nullable(Of Date))
        If program = "59" Then
            Return emsi_date2
        ElseIf client = "Monarch 1" Then
            Return emsi_date4
        ElseIf IgnoreSyncToKBC(program) Then
            Return emsi_date2
        Else
            Return emsi_date3
        End If
    End Function

    ''' <summary>
    ''' LE Target Date
    ''' </summary>
    ''' <param name="maturity_date">gmbh.maturity_date</param>
    ''' <param name="premiumadvancedate">policies.premiumadvancedate</param>
    ''' <param name="aniversarydate">policies.aniversarydate</param>
    ''' <returns></returns>
    Function LETargetDate(ByVal maturity_date As Nullable(Of Date), ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date))
        '-- the LE Target Date is the actual date that is 75 to 105 days before the loan maturity date that = (later of Column I-Anniversary Date Day or Column J-Premium Advance Date Day) + 1.  
        '-- example: Policy date is 9/15/07; there is no Premium Advance Date. Target time period would be 1/3/14 to 2/3/14. The day would be the 15th +1 or the 16th. LE target date would be 1/16/14.

        If Not IsNothing(maturity_date) Then

            '-- determine the day
            Dim theDay
            If IsNothing(premiumadvancedate) Then
                theDay = aniversarydate
            ElseIf IsNothing(aniversarydate) Then
                theDay = premiumadvancedate
            ElseIf premiumadvancedate > aniversarydate Then
                theDay = premiumadvancedate
            Else
                theDay = aniversarydate
            End If

            Dim day105prior
            day105prior = DateAdd("d", -105, maturity_date)

            '-- in case the day value is 31, we have to keep incrementing it until it enters the -75 and -105 range. we can't make the date.
            If theDay < day105prior Then
                Do While theDay < day105prior
                    theDay = DateAdd("m", 1, theDay)
                Loop

                Return DateAdd("d", 1, theDay)
            End If

        End If

    End Function

    ''' <summary>
    ''' Legal Exception
    ''' </summary>
    ''' <param name="legal_exception">opportunity_ext.legal_exception</param>
    ''' <param name="legal_exception_date">opportunity_ext.legal_exception_date</param>
    ''' <param name="nulldateforcrystal">policies.nulldateforcrystal</param>
    ''' <returns></returns>
    Function LegalException(ByVal legal_exception As String, ByVal legal_exception_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If LegalException = "T" Then
            Return legal_exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service 21st age
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="tf_date1">view_le_latest_flat_service_2_nofilters.tf_date</param>
    ''' <param name="tf_date2">view_le_latest_flat_service_bac_nofilters.tf_date</param>
    ''' <param name="tf_date3">view_le_latest_flat_service_nofilters.tf_date</param>
    ''' <param name="tf_date4">view_le_latest_flat_service_monarch1_nofilters.tf_date</param>
    ''' <returns></returns>
    Function MostRecentService21StAge(ByVal program As String, ByVal client As String, ByVal tf_date1 As Nullable(Of Date), ByVal tf_date2 As Nullable(Of Date), ByVal tf_date3 As Nullable(Of Date), ByVal tf_date4 As Nullable(Of Date))
        If IsNothing(MostRecentService21st(program, client, tf_date1, tf_date2, tf_date3, tf_date4)) Then
            Return 0
        Else
            Return DateDiff("d", MostRecentService21st(program, client, tf_date1, tf_date2, tf_date3, tf_date4), CurrentDate) / 30.42
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service 21st LE
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="tf_le1">view_le_latest_flat_service_2_nofilters.tf_le</param>
    ''' <param name="tf_le2">view_le_latest_flat_service_bac_nofilters.tf_le</param>
    ''' <param name="tf_le3">view_le_latest_flat_service_nofilters.tf_le</param>
    ''' <param name="tf_le4">view_le_latest_flat_service_monarch1_nofilters.tf_le</param>
    ''' <returns></returns>
    Function MostRecentService21StLE(ByVal program As String, ByVal client As String, ByVal tf_le1 As Nullable(Of Double), ByVal tf_le2 As Nullable(Of Double), ByVal tf_le3 As Nullable(Of Double), ByVal tf_le4 As Nullable(Of Double))
        If program = "59" Then
            Return tf_le2
        ElseIf client = "Monarch 1" Then
            Return tf_le4
        ElseIf IgnoreSyncToKBC(program) Then
            Return tf_le1
        Else
            Return tf_le3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service 21st mortality
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="tf_multiplier1">"view_le_latest_flat_service_2_nofilters"."tf_multiplier", </param>
    ''' <param name="tf_multiplier2">"view_le_latest_flat_service_bac_nofilters"."tf_multiplier", </param>
    ''' <param name="tf_multiplier3">"view_le_latest_flat_service_nofilters"."tf_multiplier", </param>
    ''' <param name="tf_multiplier4">"view_le_latest_flat_service_monarch1_nofilters"."tf_multiplier", </param>
    ''' <returns></returns>
    Function MostRecentService21stMortality(ByVal program As String, ByVal client As String, ByVal tf_multiplier1 As Nullable(Of Double), ByVal tf_multiplier2 As Nullable(Of Double), ByVal tf_multiplier3 As Nullable(Of Double), ByVal tf_multiplier4 As Nullable(Of Double))
        If program = "59" Then
            Return tf_multiplier2
        ElseIf client = "Monarch 1" Then
            Return tf_multiplier4
        ElseIf IgnoreSyncToKBC(program) Then
            Return tf_multiplier1
        Else
            Return tf_multiplier3
        End If
    End Function


    ''' <summary>
    ''' Most Recent Service AVS age
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="avs_date1">view_le_latest_flat_service_2_nofilters.avs_date</param>
    ''' <param name="avs_date2">view_le_latest_flat_service_bac_nofilters.avs_date</param>
    ''' <param name="avs_date3">view_le_latest_flat_service_nofilters.avs_date</param>
    ''' <param name="avs_date4">view_le_latest_flat_service_monarch1_nofilters.avs_date</param>
    ''' <returns></returns>
    Function MostRecentServiceAVSAge(ByVal program As String, ByVal client As String, ByVal avs_date1 As Nullable(Of Date), ByVal avs_date2 As Nullable(Of Date), ByVal avs_date3 As Nullable(Of Date), ByVal avs_date4 As Nullable(Of Date))
        If IsNothing(MostRecentServiceAVS(program, client, avs_date1, avs_date2, avs_date3, avs_date4)) Then
            Return 0
        Else
            Return DateDiff("d", MostRecentServiceAVS(program, client, avs_date1, avs_date2, avs_date3, avs_date4), CurrentDate) / 30.42
        End If
    End Function


    ''' <summary>
    ''' Most Recent Service AVS LE
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="avs_le1">view_le_latest_flat_service_2_nofilters.avs_le</param>
    ''' <param name="avs_le2">view_le_latest_flat_service_bac_nofilters.avs_le</param>
    ''' <param name="avs_le3">view_le_latest_flat_service_nofilters.avs_le</param>
    ''' <param name="avs_le4">view_le_latest_flat_service_monarch1_nofilters.avs_le</param>
    ''' <returns></returns>
    Function MostRecentServiceAVSLE(ByVal program As String, ByVal client As String, ByVal avs_le1 As Nullable(Of Double), ByVal avs_le2 As Nullable(Of Double), ByVal avs_le3 As Nullable(Of Double), ByVal avs_le4 As Nullable(Of Double))
        If program = "59" Then
            Return avs_le2
        ElseIf client = "Monarch 1" Then
            Return avs_le4
        ElseIf IgnoreSyncToKBC(program) Then
            Return avs_le1
        Else
            Return avs_le3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service AVS mortality
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="avs_multiplier1">view_le_latest_flat_service_2_nofilters.avs_multiplier</param>
    ''' <param name="avs_multiplier2">view_le_latest_flat_service_bac_nofilters.avs_multiplier</param>
    ''' <param name="avs_multiplier3">view_le_latest_flat_service_nofilters.avs_multiplier</param>
    ''' <param name="avs_multiplier4">view_le_latest_flat_service_monarch1_nofilters.avs_multiplier</param>
    ''' <returns></returns>
    Function MostRecentServiceAVSMortality(ByVal program As String, ByVal client As String, ByVal avs_multiplier1 As Nullable(Of Double), ByVal avs_multiplier2 As Nullable(Of Double), ByVal avs_multiplier3 As Nullable(Of Double), ByVal avs_multiplier4 As Nullable(Of Double))
        If program = "59" Then
            Return avs_multiplier2
        ElseIf client = "Monarch 1" Then
            Return avs_multiplier4
        ElseIf IgnoreSyncToKBC(program) Then
            Return avs_multiplier1
        Else
            Return avs_multiplier3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service EMSI age
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="emsi_date1">view_le_latest_flat_service_2_nofilters.emsi_date</param>
    ''' <param name="emsi_date2">view_le_latest_flat_service_bac_nofilters.emsi_date</param>
    ''' <param name="emsi_date3">view_le_latest_flat_service_nofilters.emsi_date</param>
    ''' <param name="emsi_date4">view_le_latest_flat_service_monarch1_nofilters.emsi_date</param>
    ''' <returns></returns>
    Function MostRecentServiceEMSIAge(ByVal program As String, ByVal client As String, ByVal emsi_date1 As Nullable(Of Date), ByVal emsi_date2 As Nullable(Of Date), ByVal emsi_date3 As Nullable(Of Date), ByVal emsi_date4 As Nullable(Of Date))
        If IsNothing(MostRecentServiceEMSI(program, client, emsi_date1, emsi_date2, emsi_date3, emsi_date4)) Then
            Return 0
        Else
            Return DateDiff("d", MostRecentServiceEMSI(program, client, emsi_date1, emsi_date2, emsi_date3, emsi_date4), CurrentDate) / 30.42
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service EMSI LE
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <param name="client">view_policy_consolidated.client</param>
    ''' <param name="emsi_le1">view_le_latest_flat_service_2_nofilters.emsi_le</param>
    ''' <param name="emsi_le2">view_le_latest_flat_service_bac_nofilters.emsi_le</param>
    ''' <param name="emsi_le3">view_le_latest_flat_service_nofilters.emsi_le</param>
    ''' <param name="emsi_le4">view_le_latest_flat_service_monarch1_nofilters.emsi_le</param>
    ''' <returns></returns>
    Function MostRecentServiceEMSILE(ByVal program As String, ByVal client As String, ByVal emsi_le1 As Nullable(Of Double), ByVal emsi_le2 As Nullable(Of Double), ByVal emsi_le3 As Nullable(Of Double), ByVal emsi_le4 As Nullable(Of Double))
        If program = "59" Then
            Return emsi_le2
        ElseIf client = "Monarch 1" Then
            Return emsi_le4
        ElseIf IgnoreSyncToKBC(program) Then
            Return emsi_le1
        Else
            Return emsi_le3
        End If
    End Function

    ''' <summary>
    ''' Most Recent Service EMSI mortality
    ''' </summary>
    ''' <param name="program"></param>
    ''' <param name="client"></param>
    ''' <param name="emsi_multiplier1">view_le_latest_flat_service_2_nofilters.emsi_multiplier</param>
    ''' <param name="emsi_multiplier2">view_le_latest_flat_service_bac_nofilters.emsi_multiplier</param>
    ''' <param name="emsi_multiplier3">view_le_latest_flat_service_nofilters.emsi_multiplier</param>
    ''' <param name="emsi_multiplier4">view_le_latest_flat_service_monarch1_nofilters.emsi_multiplier</param>
    ''' <returns></returns>
    Function MostRecentServiceEMSIMortality(ByVal program As String, ByVal client As String, ByVal emsi_multiplier1 As Nullable(Of Double), ByVal emsi_multiplier2 As Nullable(Of Double), ByVal emsi_multiplier3 As Nullable(Of Double), ByVal emsi_multiplier4 As Nullable(Of Double))
        If program = "59" Then
            Return emsi_multiplier2
        ElseIf client = "Monarch 1" Then
            Return emsi_multiplier4
        ElseIf IgnoreSyncToKBC(program) Then
            Return emsi_multiplier1
        Else
            Return emsi_multiplier3
        End If
    End Function


    ''' <summary>
    ''' Num of Monthes Anniversay Date
    ''' </summary>
    ''' <param name="aniversarydate">policies.aniversarydate</param>
    ''' <returns></returns>
    Function NumOfMonthesAnniversayDate(ByVal aniversarydate As Nullable(Of Date))
        Dim lMonths As Double
        Dim lStartDay As Double
        Dim lEndDay As Double
        Dim FebruaryAdjustment As Double
        Dim EndDate As Date
        Dim StartDate As Date

        StartDate = DateValue(aniversarydate)
        EndDate = CurrentDate()

        lStartDay = Day(StartDate)
        lEndDay = Day(EndDate)


        If lStartDay > 30 Then
            StartDate = DateValue(DateAdd("d", -1, StartDate))
        End If

        If (lEndDay = 31) And (lStartDay < 30) Then
            EndDate = DateValue(DateAdd("d", 1, EndDate))
        ElseIf (lEndDay = 31) And (lStartDay >= 30) Then
            EndDate = DateValue(DateAdd("d", -1, EndDate))
        End If

        'If IsLastDayInFebruary(StartDate) Then
        '    FebruaryAdjustment = 30 - Day(StartDate)
        'End If


        lStartDay = Day(StartDate)
        lEndDay = Day(EndDate)

        lMonths = DateDiff("M", StartDate, EndDate)

        Return ((lMonths * 30) + (lEndDay - lStartDay) - FebruaryAdjustment) / 30

    End Function

    ''' <summary>
    ''' UW Exception Add'l
    ''' </summary>
    ''' <param name="policy_exception">policies.policy_exception</param>
    ''' <param name="exception_value2">policies.exception_value2</param>
    ''' <returns></returns>
    Function UWExceptionAddl(ByVal policy_exception As String, ByVal exception_value2 As String)
        If policy_exception = "T" Then
            Return exception_value2
        Else
            Return ""
        End If
    End Function

#Region "Auxiliar Methods: This funcions should not be migrated to SSRS."

    ''' <summary>
    ''' Gets the current date, emulating the VBA function
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' This funcion should not be migrated to SSRS.
    ''' </remarks>
    Function CurrentDate() As Date
        Return Today()
    End Function

    ''' <summary>
    ''' All_Recs_Recvd
    ''' </summary>
    ''' <param name="all_rec_recv_date">viewlatest_all_rec_recv_date.all_rec_recv_date</param>
    ''' <returns></returns>
    ''' <remarks>This funcion should not be migrated to SSRS. Just use the original field instead</remarks>
    Function AllRecsRecvd(ByVal all_rec_recv_date As Nullable(Of Date))
        Return all_rec_recv_date
    End Function

    ''' <summary>
    ''' ToText
    ''' </summary>
    ''' <param name="d"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks>This funcion should not be migrated to SSRS.</remarks>
    Function ToText(ByVal d As Date, ByVal format As String)
        Return d.ToString(format)
    End Function


    ''' <summary>
    ''' ProgramNumber
    ''' </summary>
    ''' <param name="program">view_policy_consolidated.program</param>
    ''' <returns></returns>
    ''' <remarks>This funcion should not be migrated to SSRS. Just use the original field instead</remarks>
    Function ProgramNumber(ByVal program As String)
        Return program
    End Function

#End Region

End Class
