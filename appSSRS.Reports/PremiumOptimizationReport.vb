Public Class PremiumOptimizationReport
    Inherits BaseReport

    Function GroupBy(ByVal date_of_death As Nullable(Of Date), VPCProgram As String) As String
        If Not IsNothing(date_of_death) Then
            Return "Z_Deceased"
        Else
            Return VPCProgram
        End If
    End Function

    Function GroupLabel(ByVal date_of_death As Nullable(Of Date), VPCProgram As String, ByVal program_name As String) As String
        If InStr(GroupBy(date_of_death, VPCProgram), "_") = 2 Then
            Return Mid(GroupBy(date_of_death, VPCProgram), 3)
        Else
            Return program_name
        End If
    End Function

    Function CurrentDeathBenefit(ByVal rop As String, ByVal total_death_benefit As String, ByVal db_change As String, ByVal deathbenefit As String, ByVal partial_surrender_amount As String) As String
        If rop = "T" Then
            Return total_death_benefit

        ElseIf db_change <> "" Then
            Return deathbenefit + partial_surrender_amount
        Else
            Return deathbenefit
        End If
    End Function

    Function ROP_func(ByVal rop As String) As String
        If rop = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function VUL(ByVal product_carrier_vul As String) As String
        If product_carrier_vul = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function ProgramProvider(ByVal VPCClient As String, ByVal VPCProgram As Integer, ByVal VPCProvider As String) As String
        If VPCClient = "NLSS (Back-Up Service)" Then
            Return "NLSS (Back-Up Service)"
        ElseIf VPCProgram = "69" Then
            Return "J-Curve Loan GISF"
        Else
            Return VPCProvider
        End If
    End Function

    Function AnnualStmtDate(ByVal annualstatementdate As Nullable(Of Date)) As Nullable(Of Date)
        If Not IsNothing(annualstatementdate) Then
            Return FormatDateTime(annualstatementdate, 2)
        Else
            Return ""
        End If
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

    Function AdjReqPremium(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal) As Decimal
        If Not IsNothing(override_premium) Then
            Return override_premium
        Else
            Return adj_est_prem
        End If
    End Function

    Function OverridePremium_func(ByVal override_premium As Decimal) As String
        If Not IsNothing(override_premium) Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function

    Function RateIncrease(ByVal rate_increase As String) As String
        If rate_increase = "Y" Then
            Return "Yes"
        ElseIf rate_increase = "" Then
            Return ""
        Else
            Return "No"
        End If
    End Function

End Class
