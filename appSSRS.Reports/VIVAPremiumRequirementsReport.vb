﻿Public Class VIVAPremiumRequirementsReport

    Function ROP(ByVal PRNROP As String) As String
        If PRNROP = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function ProgramProvider(ByVal VPCProgram As Integer) As Integer
        If VPCProgram = "102" Then
            Return "Monarch 2"
        ElseIf VPCProgram = "104" Then
            Return "Monarch 2"
        ElseIf VPCProgram = "108" Then
            Return "Monarch 1"
        End If
    End Function

    Function AnnivMonth(ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date)) As Integer
        If Not IsNothing(premiumadvancedate) Then
            Return Month(premiumadvancedate)
        Else
            Return Month(aniversarydate)
        End If
    End Function

    Function AnnualStmtDate(ByVal annualstatementdate As Nullable(Of Date)) As Nullable(Of Date)
        If Not IsNothing(annualstatementdate) Then
            Return FormatDateTime(annualstatementdate, 2)
        Else
            Return ""
        End If
    End Function

    Function ThirdPartyAuth(ByVal third_party_auth As String, ByVal doesnotacceptthirdpa As String, ByVal restrictedauth As String) As String
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

    Function RunningOff(ByVal cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String) As String
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

    Function Month1(ByVal date_addl_prem_due As Nullable(Of Date), ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date), cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal) As String
        Dim monthNumber
        monthNumber = 1
        Dim CurrentDate As Date
        CurrentDate = Today()

        If DateDiff("m", DateAdd("m", monthNumber - 1, CurrentDate), date_addl_prem_due) <= 0 Then '-- on or after due date
            If DateDiff("m", DateAdd("m", monthNumber - 1, CurrentDate), NextAnnivDate(premiumadvancedate, aniversarydate) <= 0 Then '-- on or after next anniv. date
                Return PremAfterAnniv(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, calc_method, last_coi, ga_charge)
            Else
                Return {@PremBeforeAnniv}
            End If
        End If
    End Function

    Function NextAnnivDate(ByVal premiumadvancedate As Nullable(Of Date), ByVal aniversarydate As Nullable(Of Date)) As Nullable(Of Date)
        Dim annivDate, i
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

    Function PremAfterAnniv(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal) As String
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Monthly GA") > 0 Or calc_method = "Shadow Calculation (Special)" Then
            Return LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge)
        Else
            Return (LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge) * 1.1) / (1 - {@NextYearPremExp})
        End If
    End Function

    Function LastCOI(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal last_coi As Decimal, ByVal ga_charge As Decimal) As String
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "CV") > 0 Or InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "CSV") > 0 Then
            Return last_coi
        ElseIf InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "GA") > 0 Or InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Shadow") > 0 Then
            Return ga_charge
        Else
            Return 0
        End If
    End Function

    Function PremBeforeAnniv(cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String, ByVal calc_method As Decimal, ByVal last_coi As Decimal, ByVal ga_charge As Decimal, ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal) As String
        If InStr(RunningOff(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated), "Monthly GA") > 0 Or calc_method = "Shadow Calculation (Special)" Then
            Return LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge)
        Else
            Return (LastCOI(cv, csv, monthly_ga, annual_ga, shaow_acct, coi_estimated, last_coi, ga_charge) * 1.1) / (1 - NextYearPremExp(, NextEstPrmExpense, NextPremExpense)
        End If
    End Function

    Function NextYearPremExp(ByVal NextEstPrmExpense As Decimal, ByVal NextPremExpense As Decimal) As Decimal
        If Not IsNothing(NextEstPrmExpense) Then
            Return NextEstPrmExpense
        Else
            Return NextPremExpense
        End If
    End Function








End Class