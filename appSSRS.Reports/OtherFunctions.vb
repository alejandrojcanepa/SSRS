Public Class OtherFunctions
    Function AgeOfAnniversary(ByVal aniversarydate As Nullable(Of Date)) As String

        Dim lMonths As Double
        Dim lStartDay As Double
        Dim lEndDay As Double
        Dim FebruaryAdjustment As Double
        Dim EndDate As Date
        Dim StartDate As Date

        StartDate = DateValue(aniversarydate)
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

        Return FormatNumber(((lMonths * 30) + (lEndDay - lStartDay) - FebruaryAdjustment) / 30, 1)

    End Function

    Function NextDOB(ByVal DOB As Nullable(Of Date)) As Date
        If Not (IsNothing(DOB)) Then

            Dim dobdate As Date
            dobdate = DateAdd("yyyy", Year(Today()) - Year(DOB), DOB)

            If DateDiff("d", Today(), dobdate) < 0 Then dobdate = DateAdd("yyyy", 1, dobdate)
            Return dobdate
        End If
    End Function

    'duplicated on AVSNextAgeChange
    Function AVSAgeChange(ByVal DOB As Nullable(Of Date)) As Date
        If Not (IsNothing(DOB)) Then
            Return DateAdd("m", -3, NextDOB(DOB))
        End If
    End Function

    Function OptimizedMedicalRecordsDueDate(ByVal DATE_OF_DEATH As Nullable(Of Date), ByVal DOB As Nullable(Of Date), ByVal NullDateForCrystal As Nullable(Of Date)) As Date
        If IsNothing(DATE_OF_DEATH) And Not (IsNothing(DOB)) Then
            Return DateAdd("d", -1, AVSAgeChange(DOB))
        Else
            Return NullDateForCrystal
        End If

    End Function

    Function AnnualizedLEDueDate(ByVal AVS_Date As Nullable(Of Date), ByVal TF_Date As Nullable(Of Date), ByVal Fasano_Date As Nullable(Of Date), ByVal NullDateForCrystal As Nullable(Of Date)) As Nullable(Of Date)

        Dim ALEDDdate As Date
        ALEDDdate = CDate("1/1/2050")

        If Not (IsNothing(AVS_Date)) Then
            ALEDDdate = CDate(AVS_Date)
        End If

        If Not (IsNothing(TF_Date)) Then
            If TF_Date < ALEDDdate Then
                ALEDDdate = CDate(TF_Date)
            End If
        End If

        If Not (IsNothing(Fasano_Date)) Then
            If Fasano_Date < ALEDDdate Then
                ALEDDdate = CDate(Fasano_Date)
            End If
        End If

        If Year(ALEDDdate) = 2050 Then
            Return NullDateForCrystal
        Else
            Return DateAdd("d", 365, ALEDDdate)
        End If

    End Function

    Function OptimizedLEDueDate(ByVal DATE_OF_DEATH As Nullable(Of Date), ByVal DOB As Nullable(Of Date), ByVal NullDateForCrystal As Nullable(Of Date)) As Nullable(Of Date)

        If IsNothing(DATE_OF_DEATH) And Not (IsNothing(DOB)) Then
            Dim OLEDDdate As Date

            If DateDiff("d", NextDOB(DOB), CDate("2011/4/1")) > 0 Then '-- if the DOB is less than April 2011, use next year
                OLEDDdate = DateAdd("yyyy", 1, NextDOB(DOB))
            Else
                OLEDDdate = NextDOB(DOB)
            End If
            Return DateAdd("d", -75, OLEDDdate)
        Else
            Return NullDateForCrystal
        End If

    End Function

    Function LETargetDate(ByVal Program As String, ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date), ByVal DOB As Nullable(Of Date), ByVal NullDateForCrystal As Nullable(Of Date)) As Nullable(Of Date)

        '-- request #8691 and #8735
        If Program = "112" Then
            Dim theDay As Integer

            'If Not IsNothing(premiumadvancedate) And Not IsNothing(aniversarydate) Then
            If premiumadvancedate.HasValue And aniversarydate.HasValue Then
                If premiumadvancedate.Value > aniversarydate.Value Then
                    theDay = Day(premiumadvancedate.Value)
                Else
                    theDay = Day(aniversarydate.Value)
                End If
            ElseIf Not (IsNothing(premiumadvancedate)) Then
                theDay = Day(premiumadvancedate)
            Else
                theDay = Day(aniversarydate)
            End If

            '-- get first date based on AVS date and Day(theDay)
            Dim changeDay As Integer
            Dim LETargetDate_date As Date
            changeDay = Day(AVSAgeChange(DOB))
            LETargetDate_date = DateAdd("d", theDay - changeDay + 1, AVSAgeChange(DOB))

            '-- possibly previous month is ok
            If changeDay + 28 - theDay <= 5 Then
                LETargetDate_date = DateAdd("m", -1, LETargetDate_date)
            End If

            '-- at this time, LETargetDate is at same month and year as avs date, with plus 1
            '-- BUT: If the LE Target DAY falls within 5 days BEFORE the AVS age change date, LE target date = AVS age change date.      
            If DateDiff("d", LETargetDate_date, AVSAgeChange(DOB)) > 0 Then
                If DateDiff("d", LETargetDate_date, AVSAgeChange(DOB)) <= 5 Then
                    LETargetDate_date = AVSAgeChange(DOB)
                    '-- If it falls more than 5 days before the AVS age change date, then LE target date is the next occurrence of that day in the following month.
                Else
                    LETargetDate_date = DateAdd("m", 1, LETargetDate_date)
                End If
            End If
            Return LETargetDate_date
        Else
            Return NullDateForCrystal
        End If

    End Function

    Function MostRecentServiceAVS(ByVal AVS_Date As Nullable(Of Date)) As Nullable(Of Date)
        MostRecentServiceAVS = AVS_Date
    End Function

    Function MostRecentServiceAVSAge(ByVal AVS_Date As Nullable(Of Date)) As Integer
        If IsNothing(MostRecentServiceAVS(AVS_Date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", MostRecentServiceAVS(AVS_Date), CurrentDate) / 30.42
        End If
    End Function

    Function AVSRolled_calc(ByVal AVS_Rolled As String) As String
        If AVS_Rolled = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function ReportToClient(ByVal FILTER_BAC As String, ByVal FILTER_CENTURION As String, ByVal FILTER_CLC As String, ByVal FILTER_FORTRESS As String, ByVal FILTER_HYPERION As String, ByVal FILTER_HYPERION_II As String, ByVal FILTER_MONARCH1 As String, ByVal FILTER_MONARCH2 As String, ByVal FILTER_MONARCHBAC As String, ByVal FILTER_PEACHTREE As String, ByVal FILTER_SUNDANCE As String, ByVal FOR_NCB As String) As String

        If FILTER_BAC = "T" _
            Or FILTER_CENTURION = "T" _
            Or FILTER_CLC = "T" _
            Or FILTER_FORTRESS = "T" _
            Or FILTER_HYPERION = "T" _
            Or FILTER_HYPERION_II = "T" _
            Or FILTER_MONARCH1 = "T" _
            Or FILTER_MONARCH2 = "T" _
            Or FILTER_MONARCHBAC = "T" _
            Or FILTER_PEACHTREE = "T" _
            Or FILTER_SUNDANCE = "T" _
            Or FOR_NCB = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function ContactNumber(ByVal CONTACT_NUMBER As String) As String

        Return "(" & (Left(CONTACT_NUMBER, 3)) & ") " & (Mid(CONTACT_NUMBER, 4, 3)) & "-" & Right(CONTACT_NUMBER, 4)

    End Function

    'duplicated on AVSAgeChange
    Function AVSNextAgeChange(ByVal DOB As Nullable(Of Date)) As Nullable(Of Date)
        AVSNextAgeChange = AVSAgeChange(DOB)
    End Function

    Function MostRecentService21st(ByVal TF_Date As Date) As Date
        MostRecentService21st = TF_Date
    End Function

    Function MostRecentService21stAge(ByVal TF_Date As Date) As Integer
        If IsNothing(MostRecentService21st(TF_Date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", (MostRecentService21st(TF_Date)), CurrentDate) / 30.42
        End If
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
