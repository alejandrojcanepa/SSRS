Public Class VIVAPremiumRequirementsReport

    Function GroupBy(ByVal date_of_death As Nullable(Of Date), ByVal confirmed_lapse_date As Nullable(Of Date), ByVal endreason As Nullable(Of Date))
        If Not IsNothing(date_of_death) Then
            Return 80
        ElseIf Not IsNothing(confirmed_lapse_date) Then
            Return 100
        ElseIf endreason <> "" Then
            Return 21
        Else
            Return 24
        End If
    End Function

    Function ROP(ByVal PRNROP As String)
        If PRNROP = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function ProgramProvider(ByVal VPCProgram As Integer)
        If VPCProgram = "102" Then
            Return "Monarch 2"
        ElseIf VPCProgram = "104" Then
            Return "Monarch 2"
        ElseIf VPCProgram = "108" Then
            Return "Monarch 1"
        End If
    End Function

    Function AnnivMonth(ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date))
        If Not IsNothing(premiumadvancedate) Then
            Return Month(premiumadvancedate)
        Else
            Return Month(aniversarydate)
        End If
    End Function

    Function AnnualStmtDate(ByVal annualstatementdate As Nullable(Of Date))
        If Not IsNothing(annualstatementdate) Then
            Return FormatDateTime(annualstatementdate, 2)
        Else
            Return ""
        End If
    End Function

    Function ThirdPartyAuth(ByVal third_party_auth As String, ByVal doesnotacceptthirdpa As String, ByVal restrictedauth As String)
        Dim res

        If third_party_auth = "T" Then
            res = "Expired,"
        Else
            res = ""
        End If
        If doesnotacceptthirdpa = "T" Then
            res = res & "Does Not Accept,"
        End If
        If restrictedauth = "T" Then
            res = res & "Restricted"
        End If
        If Right(res, 1) = "," Then res = Left(res, Len(res) - 1)
        Return res
    End Function

    Function RunningOff(ByVal cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String)
        Dim str
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

    'You will need to set the monthNumber parameter according to the report column that you're trying to show (ex: for the Month11 column, you need to set the value as "11")
    Function Month_func(ByVal date_addl_prem_due As Nullable(Of Date), ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date), cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal, ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal, ByVal monthNum As Integer)
        Dim monthNumber
        monthNumber = monthNum
        Dim CurrentDate As Date
        CurrentDate = Today()

        'Month 13 is special:
        If monthNum = 13 Then
            If Month(CurrentDate) = AnnivMonth(premiumadvancedate, aniversarydate) Then '-- if month 13 is same as anniv month (month 13 = month 1 = now)
                Return 1.1 * Month_func(date_addl_prem_due, premiumadvancedate, aniversarydate, cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, calc_method, last_coi, ga_charge, NextEstPrmExpense, NextPremExpense, 12) 'uses always month 12 to calculate
            End If
        End If

        'Then you use this for all the months from 1 to 13:
        If DateDiff("m", DateAdd("m", monthNumber - 1, CurrentDate), date_addl_prem_due) <= 0 Then '-- on or after due date
            If DateDiff("m", DateAdd("m", monthNumber - 1, CurrentDate), NextAnnivDate(premiumadvancedate, aniversarydate)) <= 0 Then '-- on or after next anniv. date
                Return PremAfterAnniv(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, calc_method, last_coi, ga_charge, NextEstPrmExpense, NextPremExpense)
            Else
                Return PremBeforeAnniv(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, calc_method, last_coi, ga_charge, NextEstPrmExpense, NextPremExpense)
            End If
        End If
    End Function

    Function NextAnnivDate(ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date))
        Dim annivDate
        Dim CurrentDate As Date
        CurrentDate = Today()

        If Not IsNothing(premiumadvancedate) Then
            annivDate = premiumadvancedate
        Else
            annivDate = aniversarydate
        End If

        Do While DateDiff("d", annivDate, CurrentDate) > 0
            annivDate = DateAdd("yyyy", 1, annivDate)
        Loop

        Return annivDate
    End Function

    Function PremAfterAnniv(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal, ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal)
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Monthly GA") > 0 Or calc_method = "Shadow Calculation (Special)" Then
            Return LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge)
        Else
            Return (LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge) * 1.1) / (1 - NextYearPremExp(NextEstPrmExpense, NextPremExpense))
        End If
    End Function

    Function LastCOI(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal)
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "CV") > 0 Or InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "CSV") > 0 Then
            Return last_coi
        ElseIf InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "GA") > 0 Or InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Shadow") > 0 Then
            Return ga_charge
        Else
            Return 0
        End If
    End Function

    Function PremBeforeAnniv(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As Decimal, ByVal last_coi As Decimal, ByVal ga_charge As Decimal, ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal)
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Monthly GA") > 0 Or calc_method = "Shadow Calculation (Special)" Then
            Return LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge)
        Else
            Return (LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge) * 1.1) / (1 - NextYearPremExp(NextEstPrmExpense, NextPremExpense))
        End If
    End Function

    Function NextYearPremExp(ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal)
        If Not IsNothing(NextEstPrmExpense) Then
            Return NextEstPrmExpense
        Else
            Return NextPremExpense
        End If
    End Function

    'This function is just to VBScript, you should probably use Month in the main formula
    Function Month(ByVal currentDate As Date)
        Return Convert.ToDateTime(currentDate).Month
    End Function

    Function AdjReqPremium(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal)
        If Not IsNothing(override_premium) Then
            Return override_premium
        Else
            Return adj_est_prem
        End If
    End Function

    Function OverridePremium(ByVal override_premium As Decimal)
        If Not IsNothing(override_premium) Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function

End Class
