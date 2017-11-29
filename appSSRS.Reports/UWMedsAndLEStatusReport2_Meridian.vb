Public Class UWMedsAndLEStatusReport2_Meridian

    Function Nextdob(ByVal dob As Nullable(Of Date))
        Dim CurrentDate As Date
        CurrentDate = Today()

        Dim result
        result = DateAdd("yyyy", Year(CurrentDate) - Year(dob), dob)
        If DateDiff("d", CurrentDate, result) < 0 Then dob = DateAdd("yyyy", 1, result)
        Return result

    End Function

    Function _21stNextAgeChange(ByVal dob As Nullable(Of Date))
        Return DateAdd("m", -6, Nextdob(dob))
    End Function


    Function AllRecsRecvdAge(ByVal all_rec_recv_date As Nullable(Of Date))
        If IsNothing(all_rec_recv_date) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", CDate(all_rec_recv_date), CurrentDate) / 30.42
        End If
    End Function

    Function APSUpdateInProg(ByVal aps_update_in_prog As String, ByVal aps_update_in_prog2 As String, ByVal aps_update_in_prog3 As String, ByVal apsupdateinprog_c_early As String, ByVal apsupdateinprog_c_early2 As String, ByVal opportunityid As String)
        If (aps_update_in_prog = "T" Or aps_update_in_prog2 = "T" Or aps_update_in_prog3 = "T" Or apsupdateinprog_c_early = "T" Or apsupdateinprog_c_early2 = "T") Or opportunityid <> "" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function AVSAgeChange(ByVal dob As Nullable(Of Date))
        If Not (IsNothing(dob)) Then
            Return DateAdd("m", -3, Nextdob(dob))
        End If
    End Function

    Function AVSPrimaryDiagnosis(ByVal Policy_Level_Program__ As String, ByVal VLLFS2Navs_impairment As String, ByVal VLLFSBNavs_impairment As String, ByVal VLLFSNavs_impairment As String)
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNavs_impairment
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Navs_impairment
        Else
            Return VLLFSNavs_impairment
        End If
    End Function

    Function IgnoreSyncToKBC(ByVal Policy_Level_Program__ As String)

        Dim prom
        If IsNumeric(Policy_Level_Program__) Then
            prom = CDbl(Policy_Level_Program__)

            If prom >= 53 And prom < 59 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Function AVSRolled(ByVal Policy_Level_Program__ As String, ByVal VLLFS2Navs_rolled As String, ByVal VLLFSBNavs_rolled As String, ByVal VLLFSNavs_rolled As String)
        If Policy_Level_Program__ = "59" Then
            If VLLFSBNavs_rolled = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            If VLLFS2Navs_rolled = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        Else
            If VLLFSNavs_rolled = "T" Then
                Return "Yes"
            Else
                Return ""
            End If
        End If
    End Function

    Function DOBString(ByVal dob As Nullable(Of Date))
        Return CStr(dob)
    End Function

    Function Exception(ByVal policy_exception As String, ByVal exception_value As String)
        If policy_exception = "T" Then
            Return exception_value
        Else
            Return ""
        End If
    End Function

    Function ExceptionDate(ByVal policy_exception As String, ByVal exception_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If policy_exception = "T" Then
            Return exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function FortressLEDueDate(ByVal Date_of_Death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If IsNothing(Date_of_Death) And Not (IsNothing(dob)) Then

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

    Function FortressMedicalRecordsDue(ByVal Date_of_Death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If IsNothing(Date_of_Death) And Not (IsNothing(dob)) Then
            Return DateAdd("d", -1, AVSAgeChange(dob))
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function LastVisitDateAge(ByVal Last_Visit_Date As Nullable(Of Date))
        If IsNothing(Last_Visit_Date) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", Last_Visit_Date, CurrentDate) / 30.42
        End If
    End Function

    Function LatestHIPAANorthstar(ByVal northstar_listed As String)
        If northstar_listed = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function LatestSignedViaPOA(ByVal signed_via_poa As String)
        If signed_via_poa = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function LEDueDate(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Navs_date As Nullable(Of Date), ByVal VLLFSBNavs_date As Nullable(Of Date), ByVal VLLFSNavs_date As Nullable(Of Date), ByVal avs_date As Nullable(Of Date), ByVal VLLFS2Ntf_date As Nullable(Of Date), ByVal VLLFSBNtf_date As Nullable(Of Date), ByVal VLLFSNtf_date As Nullable(Of Date), ByVal tf_date As Nullable(Of Date), ByVal VLLFS2Nemsi_date As Nullable(Of Date), ByVal VLLFSBNemsi_date As Nullable(Of Date), ByVal VLLFSNemsi_date As Nullable(Of Date), ByVal emsi_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))

        Dim d
        d = CDate("1/1/2050")

        If Not IsNothing(MostRecentServiceAVS(Policy_Level_Program__, client, VLLFS2Navs_date, VLLFSBNavs_date, VLLFSNavs_date, avs_date)) Then
            d = CDate(MostRecentServiceAVS(Policy_Level_Program__, client, VLLFS2Navs_date, VLLFSBNavs_date, VLLFSNavs_date, avs_date))
        End If

        If Not IsNothing(MostRecentService21st(Policy_Level_Program__, client, VLLFS2Ntf_date, VLLFSBNtf_date, VLLFSNtf_date, tf_date)) Then
            If MostRecentService21st(Policy_Level_Program__, client, VLLFS2Ntf_date, VLLFSBNtf_date, VLLFSNtf_date, tf_date) < d Then
                d = CDate(MostRecentService21st(Policy_Level_Program__, client, VLLFS2Ntf_date, VLLFSBNtf_date, VLLFSNtf_date, tf_date))
            End If
        End If

        If Not IsNothing(MostRecentServiceEMSI(Policy_Level_Program__, client, VLLFS2Nemsi_date, VLLFSBNemsi_date, VLLFSNemsi_date, emsi_date)) Then
            If MostRecentServiceEMSI(Policy_Level_Program__, client, VLLFS2Nemsi_date, VLLFSBNemsi_date, VLLFSNemsi_date, emsi_date) < d Then
                d = CDate(MostRecentServiceEMSI(Policy_Level_Program__, client, VLLFS2Nemsi_date, VLLFSBNemsi_date, VLLFSNemsi_date, emsi_date))
            End If
        End If

        If Year(d) = 2050 Then
            Return nulldateforcrystal
        Else
            Return DateAdd("d", 365, d)
        End If
    End Function

    Function MostRecentServiceAVS(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Navs_date As Nullable(Of Date), ByVal VLLFSBNavs_date As Nullable(Of Date), ByVal VLLFSNavs_date As Nullable(Of Date), ByVal avs_date As Nullable(Of Date))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNavs_date
        ElseIf client = "Monarch 1" Then
            Return avs_date
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Navs_date
        Else
            Return VLLFSNavs_date
        End If
    End Function

    Function MostRecentService21st(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Ntf_date As Nullable(Of Date), ByVal VLLFSBNtf_date As Nullable(Of Date), ByVal VLLFSNtf_date As Nullable(Of Date), ByVal tf_date As Nullable(Of Date))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNtf_date
        ElseIf client = "Monarch 1" Then
            Return tf_date
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Ntf_date
        Else
            Return VLLFSNtf_date
        End If
    End Function

    Function MostRecentServiceEMSI(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Nemsi_date As Nullable(Of Date), ByVal VLLFSBNemsi_date As Nullable(Of Date), ByVal VLLFSNemsi_date As Nullable(Of Date), ByVal emsi_date As Nullable(Of Date))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNemsi_date
        ElseIf client = "Monarch 1" Then
            Return emsi_date
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Nemsi_date
        Else
            Return VLLFSNemsi_date
        End If
    End Function

    Function LETargetDate(ByVal Maturity_Date As Nullable(Of Date), ByVal Premium_Advance_Date As Nullable(Of Date), ByVal Anniv__Date As Nullable(Of Date))
        '-- the LE Target Date is the actual date that is 75 to 105 days before the loan maturity date that = (later of Column I-Anniversary Date Day or Column J-Premium Advance Date Day) + 1.  
        '-- example: Policy date is 9/15/07; there is no Premium Advance Date. Target time period would be 1/3/14 to 2/3/14. The day would be the 15th +1 or the 16th. LE target date would be 1/16/14.

        If Not IsNothing(Maturity_Date) Then

            Dim theDay
            Dim pad
            Dim ad

            pad = Premium_Advance_Date
            ad = Anniv__Date

            If IsNothing(Premium_Advance_Date) Then
                theDay = Anniv__Date
            ElseIf IsNothing(Anniv__Date) Then
                theDay = Premium_Advance_Date
            ElseIf pad > ad Then
                theDay = Premium_Advance_Date
            Else
                theDay = Anniv__Date
            End If

            Dim day105prior
            day105prior = DateAdd("d", -105, Maturity_Date)

            '-- in case the day value is 31, we have to keep incrementing it until it enters the -75 and -105 range. we can't make the date.
            If theDay < day105prior Then
                Do While theDay < day105prior
                    theDay = DateAdd("m", 1, theDay)
                Loop

                Return DateAdd("d", 1, theDay)
            End If

        End If

    End Function

    Function LegalException(ByVal legal_exception As String, ByVal legal_exception_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date))
        If legal_exception = "T" Then
            Return legal_exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function MostRecentService21StAge(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Ntf_date As Nullable(Of Date), ByVal VLLFSBNtf_date As Nullable(Of Date), ByVal VLLFSNtf_date As Nullable(Of Date), ByVal tf_date As Nullable(Of Date))
        If IsNothing(MostRecentService21st(Policy_Level_Program__, client, VLLFS2Ntf_date, VLLFSBNtf_date, VLLFSNtf_date, tf_date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", MostRecentService21st(Policy_Level_Program__, client, VLLFS2Ntf_date, VLLFSBNtf_date, VLLFSNtf_date, tf_date), CurrentDate) / 30.42
        End If
    End Function

    Function MostRecentService21StLE(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Ntf_le As Nullable(Of Double), ByVal VLLFSBNtf_le As Nullable(Of Double), ByVal VLLFSNtf_le As Nullable(Of Double), ByVal tf_le As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNtf_le
        ElseIf client = "Monarch 1" Then
            Return tf_le
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Ntf_le
        Else
            Return VLLFSNtf_le
        End If
    End Function

    Function MostRecentService21stMortality(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Ntf_multiplier As Nullable(Of Double), ByVal VLLFSBNtf_multiplier As Nullable(Of Double), ByVal VLLFSNtf_multiplier As Nullable(Of Double), ByVal tf_multiplier As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNtf_multiplier
        ElseIf client = "Monarch 1" Then
            Return tf_multiplier
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Ntf_multiplier
        Else
            Return VLLFSNtf_multiplier
        End If
    End Function

    Function MostRecentServiceAVSAge(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Navs_date As Nullable(Of Date), ByVal VLLFSBNavs_date As Nullable(Of Date), ByVal VLLFSNavs_date As Nullable(Of Date), ByVal avs_date As Nullable(Of Date))
        If IsNothing(MostRecentServiceAVS(Policy_Level_Program__, client, VLLFS2Navs_date, VLLFSBNavs_date, VLLFSNavs_date, avs_date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", MostRecentServiceAVS(Policy_Level_Program__, client, VLLFS2Navs_date, VLLFSBNavs_date, VLLFSNavs_date, avs_date), CurrentDate) / 30.42
        End If
    End Function

    Function MostRecentServiceAVSLE(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Navs_le As Nullable(Of Double), ByVal VLLFSBNavs_le As Nullable(Of Double), ByVal VLLFSNavs_le As Nullable(Of Double), ByVal avs_le As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNavs_le
        ElseIf client = "Monarch 1" Then
            Return avs_le
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Navs_le
        Else
            Return VLLFSNavs_le
        End If
    End Function

    Function MostRecentServiceAVSMortality(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Navs_multiplier As Nullable(Of Double), ByVal VLLFSBNavs_multiplier As Nullable(Of Double), ByVal VLLFSNavs_multiplier As Nullable(Of Double), ByVal avs_multiplier As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNavs_multiplier
        ElseIf client = "Monarch 1" Then
            Return avs_multiplier
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Navs_multiplier
        Else
            Return VLLFSNavs_multiplier
        End If
    End Function

    Function MostRecentServiceEMSIAge(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Nemsi_date As Nullable(Of Date), ByVal VLLFSBNemsi_date As Nullable(Of Date), ByVal VLLFSNemsi_date As Nullable(Of Date), ByVal emsi_date As Nullable(Of Date))
        If IsNothing(MostRecentServiceEMSI(Policy_Level_Program__, client, VLLFS2Nemsi_date, VLLFSBNemsi_date, VLLFSNemsi_date, emsi_date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", MostRecentServiceEMSI(Policy_Level_Program__, client, VLLFS2Nemsi_date, VLLFSBNemsi_date, VLLFSNemsi_date, emsi_date), CurrentDate) / 30.42
        End If
    End Function

    Function MostRecentServiceEMSILE(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Nemsi_le As Nullable(Of Double), ByVal VLLFSBNemsi_le As Nullable(Of Double), ByVal VLLFSNemsi_le As Nullable(Of Double), ByVal emsi_le As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNemsi_le
        ElseIf client = "Monarch 1" Then
            Return emsi_le
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Nemsi_le
        Else
            Return VLLFSNemsi_le
        End If
    End Function

    Function MostRecentServiceEMSIMortality(ByVal Policy_Level_Program__ As String, ByVal client As String, ByVal VLLFS2Nemsi_multiplier As Nullable(Of Double), ByVal VLLFSBNemsi_multiplier As Nullable(Of Double), ByVal VLLFSNemsi_multiplier As Nullable(Of Double), ByVal emsi_multiplier As Nullable(Of Double))
        If Policy_Level_Program__ = "59" Then
            Return VLLFSBNemsi_multiplier
        ElseIf client = "Monarch 1" Then
            Return emsi_multiplier
        ElseIf IgnoreSyncToKBC(Policy_Level_Program__) Then
            Return VLLFS2Nemsi_multiplier
        Else
            Return VLLFSNemsi_multiplier
        End If
    End Function

    Function NumOfMonthesAnniversayDate(ByVal Anniv__Date As Nullable(Of Date))
        Dim lMonths As Double
        Dim lStartDay As Double
        Dim lEndDay As Double
        Dim FebruaryAdjustment As Double
        Dim EndDate As Date
        Dim StartDate As Date

        StartDate = Anniv__Date
        EndDate = Today()
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

        lStartDay = Day(StartDate)
        lEndDay = Day(EndDate)
        lMonths = DateDiff("M", StartDate, EndDate)

        Return ((lMonths * 30) + (lEndDay - lStartDay) - FebruaryAdjustment) / 30

    End Function

    Function UWExceptionAddl(ByVal policy_exception As String, ByVal exception_value2 As String)
        If policy_exception = "T" Then
            Return exception_value2
        Else
            Return ""
        End If
    End Function


End Class
