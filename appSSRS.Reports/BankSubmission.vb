Public Class BankSubmission
    ''' <summary>
    ''' Insured_Age
    ''' </summary>
    ''' <param name="dob">Matchs DB field opportunity_ext.dob</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function Insured_Age(ByVal dob As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As Decimal
        Return Round(DateDiff("D", dob, submission_date) / 365.25, 2)
    End Function

    ''' <summary>
    ''' Age Check
    ''' </summary>
    ''' <param name="dob">Matchs DB field opportunity_ext.dob</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function Age_Check(ByVal dob As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As String
        If Insured_Age(dob, submission_date) > 70.0 Then
            Return "G"
        ElseIf Insured_Age(dob, submission_date) > 68.0 Then
            Return "Y"
        Else
            Return "R"
        End If
    End Function

    ''' <summary>
    ''' DB_Check
    ''' </summary>
    ''' <param name="deathbenefit">Matchs DB field policies.deathbenefit</param>
    ''' <returns></returns>
    Function DB_Check(ByVal deathbenefit As Decimal) As String
        If deathbenefit > 20000000 Then
            Return "R"
        ElseIf deathbenefit > 10000000 Or deathbenefit < 1000000 Then
            Return "Y"
        Else
            Return "G"
        End If
    End Function

    ''' <summary>
    ''' Illustration_Date
    ''' </summary>
    ''' <param name="illustration_date_overwrite">Matchs DB field bank_submission.illustration_date_overwrite</param>
    ''' <param name="illustration_rec_latest">Matchs DB field view_illustration_latest_scenario1.illustration_rec_latest</param>
    ''' <returns></returns>
    Function Illustration_Date(ByVal illustration_date_overwrite As Nullable(Of Date), ByVal illustration_rec_latest As Nullable(Of Date)) As Nullable(Of Date)
        If Not IsNothing(illustration_date_overwrite) Then
            Return illustration_date_overwrite
        Else
            Return illustration_rec_latest
        End If
    End Function

    ''' <summary>
    ''' Illus_Check
    ''' </summary>
    ''' <param name="illustration_date_overwrite">Matchs DB field bank_submission.illustration_date_overwrite</param>
    ''' <param name="illustration_rec_latest">Matchs DB field view_illustration_latest_scenario1.illustration_rec_latest</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function Illus_Check(ByVal illustration_date_overwrite As Nullable(Of Date), ByVal illustration_rec_latest As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As String
        Dim d

        If Not IsNothing(Illustration_Date(illustration_date_overwrite, illustration_rec_latest)) Then
            d = DateDiff("D", Illustration_Date(illustration_date_overwrite, illustration_rec_latest), submission_date)

            If d <= 180 Then
                Return "G"
            Else
                Return "Y"
            End If
        Else

            Return ""
        End If
    End Function

    ''' <summary>
    ''' LE_Age_1
    ''' </summary>
    ''' <param name="certi_date1">Matchs DB field view_le_for_bank_submission.certi_date1</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function LE_Age_1(ByVal certi_date1 As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As Decimal
        Return Round(DateDiff("D", certi_date1, submission_date) / 30.42, 2)
    End Function

    ''' <summary>
    ''' LE_Age_2
    ''' </summary>
    ''' <param name="certi_date2">Matchs DB field view_le_for_bank_submission.certi_date2</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function LE_Age_2(ByVal certi_date2 As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As Decimal
        Return Round(DateDiff("D", certi_date2, submission_date) / 30.42, 2)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="certi_date1">Matchs DB field view_le_for_bank_submission.certi_date1</param>
    ''' <param name="certi_date2">Matchs DB field view_le_for_bank_submission.certi_date2</param>
    ''' <param name="submission_date">Matchs DB field bank_submission.submission_date</param>
    ''' <returns></returns>
    Function LE_Age_Check(ByVal certi_date1 As Nullable(Of Date), ByVal certi_date2 As Nullable(Of Date), ByVal submission_date As Nullable(Of Date)) As String
        If LE_Age_1(certi_date1, submission_date) <= 6.0 And LE_Age_2(certi_date2, submission_date) <= 6.0 Then
            Return "G"
        ElseIf LE_Age_1(certi_date1, submission_date) <= 12.0 And LE_Age_2(certi_date2, submission_date) <= 12.0 Then
            Return "Y"
        Else
            Return "R"
        End If
    End Function

    ''' <summary>
    ''' LE_Blend
    ''' </summary>
    ''' <param name="le1">Matchs DB field view_le_for_bank_submission.le1</param>
    ''' <param name="le2">Matchs DB field view_le_for_bank_submission.le2</param>
    ''' <returns></returns>
    Function LE_Blend(ByVal le1 As Double, ByVal le2 As Double) As Decimal
        'Dim l1, l2

        'l1 = {View_LE_For_Bank_Submission.LE1}
        'l2 = {View_LE_For_Bank_Submission.LE2}

        If le1 = 0 Or le2 = 0 Then
            Return le1 + le2
        ElseIf le1 > le2 Then
            Return Round(le1 * 0.7 + le2 * 0.3, 2)
        Else
            Return Round(le2 * 0.7 + le1 * 0.3, 2)
        End If
    End Function

    ''' <summary>
    ''' LE_Discrepancy
    ''' </summary>
    ''' <param name="le1">Matchs DB field view_le_for_bank_submission.le1</param>
    ''' <param name="le2">Matchs DB field view_le_for_bank_submission.le2</param>
    ''' <returns></returns>
    Function LE_Discrepancy(ByVal le1 As Double, ByVal le2 As Double) As Decimal
        'Dim l1, l2, r

        'l1 = {View_LE_For_Bank_Submission.LE1}
        'l2 = {View_LE_For_Bank_Submission.LE2}

        Dim r

        If le1 = 0 Or le2 = 0 Then
            r = 0
        ElseIf le1 > le2 Then
            r = (le1 - le2) / le1
        Else
            r = (le2 - le1) / le2
        End If

        Return r

    End Function

    ''' <summary>
    ''' LE_Check
    ''' </summary>
    ''' <param name="le1">Matchs DB field view_le_for_bank_submission.le1</param>
    ''' <param name="le2">Matchs DB field view_le_for_bank_submission.le2</param>
    ''' <returns></returns>
    Function LE_Check(ByVal le1 As Double, ByVal le2 As Double) As String
        If LE_Discrepancy(le1, le2) > 0.25 Then
            Return "Y"
        Else
            Return "G"
        End If

        'dim l1, l2, r

        'r = "G"
        'l1 = {View_LE_For_Bank_Submission.LE1}
        'l2 = {View_LE_For_Bank_Submission.LE2}

        'if l1 = 0 OR l2 = 0 THEN
        '    r = "G"
        'elseif l1 > l2 THEN
        '    if (l1-l2)/l2 > 0.25 THEN
        '        r = "Y"
        '    end if
        'else
        '    if (l2-l1)/l1 > 0.25 THEN
        '        r = "Y"
        '    end if
        'end if
        'formula = r
    End Function

    ''' <summary>
    ''' LE_Discrepancy_Str
    ''' </summary>
    ''' <param name="le1">Matchs DB field view_le_for_bank_submission.le1</param>
    ''' <param name="le2">Matchs DB field view_le_for_bank_submission.le2</param>
    ''' <returns></returns>
    Function LE_Discrepancy_Str(ByVal le1 As Double, ByVal le2 As Double) As String
        Return CStr(Round(LE_Discrepancy(le1, le2) * 100, 0)) & "%"
    End Function

    ''' <summary>
    ''' LE2_Check
    ''' </summary>
    ''' <param name="le1">Matchs DB field view_le_for_bank_submission.le1</param>
    ''' <param name="le2">Matchs DB field view_le_for_bank_submission.le2</param>
    ''' <returns></returns>
    Function LE2_Check(ByVal le1 As Double, ByVal le2 As Double) As String
        If LE_Blend(le1, le2) < 12 Or LE_Blend(le1, le2) > 180 Then
            Return "R"
        ElseIf LE_Blend(le1, le2) > 150 Then
            Return "Y"
        Else
            Return "G"
        End If
    End Function

    ''' <summary>
    ''' LTV
    ''' </summary>
    ''' <param name="loan_amt">Matchs DB field bank_submission.loan_amt</param>
    ''' <param name="policy_value">Matchs DB field bank_submission.policy_value</param>
    ''' <returns></returns>
    Function LTV(ByVal loan_amt As Decimal, ByVal policy_value As Decimal) As Decimal
        'Dim l, v

        'l = {BANK_SUBMISSION.LOAN_AMT}
        'v = {BANK_SUBMISSION.POLICY_VALUE}

        If policy_value > 0 And loan_amt > 0 Then
            Return Round(loan_amt / policy_value, 2)
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' LTV_Check
    ''' </summary>
    ''' <param name="loan_amt">Matchs DB field bank_submission.loan_amt</param>
    ''' <param name="policy_value">Matchs DB field bank_submission.policy_value</param>
    ''' <returns></returns>
    Function LTV_Check(ByVal loan_amt As Decimal, ByVal policy_value As Decimal) As String
        If LTV_Check(loan_amt, policy_value) = 0 Then
            Return ""
        ElseIf LTV_Check(loan_amt, policy_value) <= 0.7 Then
            Return "G"
        ElseIf LTV_Check(loan_amt, policy_value) <= 0.75 Then
            Return "Y"
        Else
            Return "R"
        End If
    End Function

    ''' <summary>
    ''' LTV_String
    ''' </summary>
    ''' <param name="loan_amt">Matchs DB field bank_submission.loan_amt</param>
    ''' <param name="policy_value">Matchs DB field bank_submission.policy_value</param>
    ''' <returns></returns>
    Function LTV_String(ByVal loan_amt As Decimal, ByVal policy_value As Decimal) As String
        If LTV(loan_amt, policy_value) > 0 Then
            Return LTV(loan_amt, policy_value) * 100 & "%"
        End If
    End Function

    ''' <summary>
    ''' MER
    ''' </summary>
    ''' <param name="mat_ext_rider_1_yn">Matchs DB field policy_audit.mat_ext_rider_1_yn</param>
    ''' <param name="mat_ext_rider_2_yn">Matchs DB field policy_audit.mat_ext_rider_2_yn</param>
    ''' <returns></returns>
    Function MER(ByVal mat_ext_rider_1_yn As String, ByVal mat_ext_rider_2_yn As String) As String
        If mat_ext_rider_1_yn = "No" Or mat_ext_rider_2_yn = "No" Then
            Return "No"
        Else
            Return "Yes"
        End If
    End Function

    ''' <summary>
    ''' MER_Check
    ''' </summary>
    ''' <param name="mat_ext_rider_1_yn">Matchs DB field policy_audit.mat_ext_rider_1_yn</param>
    ''' <param name="mat_ext_rider_2_yn">Matchs DB field policy_audit.mat_ext_rider_2_yn</param>
    ''' <returns></returns>
    Function MER_Check(ByVal mat_ext_rider_1_yn As String, ByVal mat_ext_rider_2_yn As String) As String
        If MER(mat_ext_rider_1_yn, mat_ext_rider_2_yn) = "No" Then
            Return "Y"
        Else
            Return "G"
        End If
    End Function

    ''' <summary>
    ''' Raiting_Check
    ''' </summary>
    ''' <param name="sp">Matchs DB field view_carrier_latest_rating.sp</param>
    ''' <returns></returns>
    Function Raiting_Check(ByVal sp As String) As String
        Dim r

        If sp = "" Then
            Return ""
        ElseIf InStr(sp, "(") > 0 Then
            r = Trim(Mid(sp, InStr(sp, "(")))
            If InStr(r, ")") > 0 Then
                r = Left(r, InStr(r, ")"))
            End If

            If CDbl(r) <= 6 Then
                Return "G"
            ElseIf CDbl(r) <= 9 Then
                Return "Y"
            Else
                Return "R"
            End If
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' ROP
    ''' </summary>
    ''' <param name="VPCRop">Matchs DB field view_policy_consolidated.rop</param>
    ''' <returns></returns>
    Function ROP(ByVal VPCRop As String) As String
        If VPCRop = "T" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    ''' <summary>
    ''' ROP_Check
    ''' </summary>
    ''' <param name="VPCRop">Matchs DB field view_policy_consolidated.rop</param>
    ''' <returns></returns>
    Function ROP_Check(ByVal VPCRop As String) As String
        If VPCRop = "T" Then
            Return "Y"
        Else
            Return "G"
        End If
    End Function

    ''' <summary>
    ''' Status_Check
    ''' </summary>
    ''' <param name="policy_status">Matchs DB field view_premium_latest_by_source_date.policy_status</param>
    ''' <returns></returns>
    Function Status_Check(ByVal policy_status As String) As String
        'TODO: Verificar que funcione correctamente. El original chequeaba que la comparación sea por string.:
        'InStr( {View_Premium_Latest_By_Source_Date.POLICY_STATUS}, "grace", 1 )

        If InStr(policy_status, "grace") > 0 Then
            Return "Y"
        Else
            Return "G"
        End If
    End Function

#Region "Métodos Auxiliares: No Copiar a Reporting Services"
    ''' <summary>
    ''' Product_Check
    ''' </summary>
    ''' <param name="productCheck">Matchs DB field bank_submission.product_check</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' ESTA FUNCION NO DEBE PASARSE A REPORTING SERVICES!
    ''' No tiene sentido. Utilizar directamente el campo
    ''' </remarks>
    Function Product_Check(ByVal productCheck As String) As String
        Return productCheck
    End Function


    ''' <summary>
    ''' Redondea un numero en .NET. 
    ''' </summary>
    ''' <param name="number">Numero a redondear</param>
    ''' <param name="decimals">Cantidad de decimales</param>
    ''' <returns>El numero redondeado</returns>
    ''' <remarks>
    ''' ESTA FUNCION NO DEBE PASARSE A REPORTING SERVICES!
    ''' Se debe utilizar el Round Nativo de VBScript. Esta función existe para dar la misma funcionalidad
    ''' </remarks>
    Function Round(ByVal number As Decimal, ByVal decimals As Integer) As Decimal
        Return Math.Round(number, decimals)
    End Function

#End Region

End Class

