Public Class UWMedsAndLEStatusReport_Viva

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

    Function Nextdob(ByVal dob As Nullable(Of Date)) As Date
        If Not (IsNothing(dob)) Then

            Dim dobdate As Date
            dobdate = DateAdd("yyyy", Year(Today()) - Year(dob), dob)

            If DateDiff("d", Today(), dobdate) < 0 Then dobdate = DateAdd("yyyy", 1, dobdate)
            Return dobdate
        End If
    End Function

    'duplicated on AVSNextAgeChange
    Function AVSAgeChange(ByVal dob As Nullable(Of Date)) As Date
        If Not (IsNothing(dob)) Then
            Return DateAdd("m", -3, Nextdob(dob))
        End If
    End Function

    Function OptimizedMedicalRecordsDueDate(ByVal date_of_death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date)) As Date
        If IsNothing(date_of_death) And Not (IsNothing(dob)) Then
            Return DateAdd("d", -1, AVSAgeChange(dob))
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function AnnualizedLEDueDate(ByVal avs_date As Nullable(Of Date), ByVal tf_date As Nullable(Of Date), ByVal fasano_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date)) As Nullable(Of Date)

        Dim ALEDDdate As Date
        ALEDDdate = CDate("1/1/2050")

        If Not (IsNothing(avs_date)) Then
            ALEDDdate = CDate(avs_date)
        End If
        If Not (IsNothing(tf_date)) Then
            If tf_date < ALEDDdate Then
                ALEDDdate = CDate(tf_date)
            End If
        End If
        If Not (IsNothing(fasano_date)) Then
            If fasano_date < ALEDDdate Then
                ALEDDdate = CDate(fasano_date)
            End If
        End If
        If Year(ALEDDdate) = 2050 Then
            Return nulldateforcrystal
        Else
            Return DateAdd("d", 365, ALEDDdate)
        End If
    End Function

    Function OptimizedLEDueDate(ByVal date_of_death As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date)) As Nullable(Of Date)
        If IsNothing(date_of_death) And Not (IsNothing(dob)) Then

            Dim OLEDDdate As Date

            If DateDiff("d", Nextdob(dob), CDate("2011/4/1")) > 0 Then '-- if the dob is less than April 2011, use next year
                OLEDDdate = DateAdd("yyyy", 1, Nextdob(dob))
            Else
                OLEDDdate = Nextdob(dob)
            End If
            Return DateAdd("d", -75, OLEDDdate)
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function LETargetDate(ByVal program As String, ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date), ByVal dob As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date)) As Nullable(Of Date)
        '-- request #8691 and #8735
        If program = "112" Then

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
            changeDay = Day(AVSAgeChange(dob))
            LETargetDate_date = DateAdd("d", theDay - changeDay + 1, AVSAgeChange(dob))

            '-- possibly previous month is ok
            If changeDay + 28 - theDay <= 5 Then
                LETargetDate_date = DateAdd("m", -1, LETargetDate_date)
            End If
            '-- at this time, LETargetDate is at same month and year as avs date, with plus 1
            '-- BUT: If the LE Target DAY falls within 5 days BEFORE the AVS age change date, LE target date = AVS age change date.      
            If DateDiff("d", LETargetDate_date, AVSAgeChange(dob)) > 0 Then
                If DateDiff("d", LETargetDate_date, AVSAgeChange(dob)) <= 5 Then
                    LETargetDate_date = AVSAgeChange(dob)
                    '-- If it falls more than 5 days before the AVS age change date, then LE target date is the next occurrence of that day in the following month.
                Else
                    LETargetDate_date = DateAdd("m", 1, LETargetDate_date)
                End If
            End If
            Return LETargetDate_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function MostRecentServiceAVS(ByVal avs_date As Nullable(Of Date)) As Nullable(Of Date)
        MostRecentServiceAVS = avs_date
    End Function

    Function MostRecentServiceAVSAge(ByVal avs_date As Nullable(Of Date)) As Integer
        If IsNothing(MostRecentServiceAVS(avs_date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", MostRecentServiceAVS(avs_date), CurrentDate) / 30.42
        End If
    End Function

    Function AVSRolled_calc(ByVal avs_rolled As String) As String
        If avs_rolled = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    'duplicated on AVSAgeChange
    Function AVSNextAgeChange(ByVal dob As Nullable(Of Date)) As Nullable(Of Date)
        AVSNextAgeChange = AVSAgeChange(dob)
    End Function

    Function MostRecentService21st(ByVal tf_date As Date) As Date
        MostRecentService21st = tf_date
    End Function

    Function MostRecentService21stAge(ByVal tf_date As Date) As Integer
        If IsNothing(MostRecentService21st(tf_date)) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", (MostRecentService21st(tf_date)), CurrentDate) / 30.42
        End If
    End Function

End Class
