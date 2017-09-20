Public Class UWMedsAndLEStatusReport_Viva

    Function 21stNextAgeChange (ByVal DOB As Nullable(Of Date)) As Nullable(Of Date)
        Return DateAdd("m", -6, NextDOB)
    End Function

    Function MostRecentServiceFasanoAge() As 
    If IsNothing(@Most Recent Service Fasano) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", @Most Recent Service Fasano, CurrentDate) / 30.42
        End If
    End Function

    Function LatestHIPAANorthstar(ByVal northstar_listed As String) As String
        If northstar_listed = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function LatestHIPAASignedViaPOA(ByVal signed_via_poa As String) As String
        If signed_via_poa = "T" Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function UpdateInProgress(ByVal aps_update_in_prog As String, ByVal aps_update_in_prog2 As String, ByVal aps_update_in_prog3 As String, ByVal apsupdateinprog_c_early As String, ByVal apsupdateinprog_c_early2 As String, ByVal opportunityid As String) As String
        If (aps_update_in_prog = "T" Or
            aps_update_in_prog2 = "T" Or
            aps_update_in_prog3 = "T" Or
            apsupdateinprog_c_early = "T" Or
            apsupdateinprog_c_early2 = "T") Or
            opportunityid <> "" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Function OutsideCollectionDate(ByVal outside_records_collected As Nullable(Of Date)) As String
        If LatestDate = outside_records_collected Then
            Return "Yes"
        Else
            Return ""
        End If
    End Function

    Function MostCurrentAllRecordsReceivedAge() As Integer
        If IsNothing(@All_Recs_Recvd) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", CDate(@All_Recs_Recvd), CurrentDate) / 30.42
         End If
    End Function

    Function LastVisitDateAge(ByVal last_visit_date As Nullable(Of Date)) As Integer
        If IsNothing(last_visit_date) Then
            Return 0
        Else
            Dim CurrentDate As Date
            CurrentDate = Today()
            Return DateDiff("d", last_visit_date, CurrentDate) / 30.42
        End If
    End Function

    Function UWExceptionDate(ByVal policy_exception As String, ByVal exception_date As Nullable(Of Date), ByVal nulldateforcrystal As Nullable(Of Date)) As Nullable(Of Date)
        If policy_exception = "T" Then
            Return exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function

    Function UWException(ByVal policy_exception As String, ByVal exception_value As String) As String
        If policy_exception = "T" Then
            Return exception_value
        Else
            Return ""
        End If
    End Function

    Function UWExceptionAdd(ByVal policy_exception As String, ByVal exception_value2 As String) As String
        If policy_exception = "T" Then
            Return exception_value2
        Else
            Return ""
        End If
    End Function

    Function LegalException(ByVal legal_exception As String, ByVal legal_exception_date As Date, ByVal nulldateforcrystal As Nullable(Of Date)) As Nullable(Of Date)
        If legal_exception = "T" Then
            Return legal_exception_date
        Else
            Return nulldateforcrystal
        End If
    End Function


End Class
