Public Class Corry_Capital_Premium_Requirements_Report

    Function GroupBy(ByVal date_of_death As Nullable(Of Date), ByVal VPCProgram As String) As String
        If Not IsNothing(date_of_death) Then
            Return "Z_Deceased"
        Else
            Return VPCProgram
        End If
    End Function

    Function GroupLabel(ByVal date_of_death As Nullable(Of Date), ByVal VPCProgram As String, ByVal program_name As String) As String
        If InStr(GroupBy(date_of_death, VPCProgram), "-") = 2 Then
            Return Mid(GroupBy(date_of_death, VPCProgram), 3)
        Else
            Return program_name
        End If
    End Function

    Function ROP(ByVal PRNROP As String) As String
        If PRNROP = "T" Then
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

    Function Program_Provider(ByVal VPCClient As String, ByVal VPCProgram As Integer, ByVal VPCProvider As String) As String
        If VPCClient = "NLSS (Back-Up Service)" Then
            Return "NLSS (Back-Up Service)"
        ElseIf VPCProgram = "69" Then
            Return "J-Curve Loan GISF"
        Else
            Return VPCProvider
        End If
    End Function

    Function Annual_Stmt_Date(ByVal annualstatementdate As Nullable(Of Date)) As Nullable(Of Date)
        If Not IsNothing(annualstatementdate) Then
            Return FormatDateTime(annualstatementdate, 2)
        Else
            Return ""
        End If
    End Function

    Function Running_Off(ByVal cv As String, ByVal csv As String, ByVal monthly_ga As String, ByVal annual_ga As String, ByVal shaow_acct As String, ByVal coi_estimated As String) As String
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

    Function Adj_Req_Premium(ByVal override_premium As Decimal, ByVal adj_est_prem As Decimal) As Decimal
        If Not IsNothing(override_premium) Then
            Return override_premium
        Else
            Return adj_est_prem
        End If

    End Function

    Function Override_Premium_func(ByVal override_premium As Decimal) As String
        If Not IsNothing(override_premium) Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function

End Class