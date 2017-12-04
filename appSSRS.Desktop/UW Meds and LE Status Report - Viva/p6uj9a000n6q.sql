SELECT DISTINCT 
                "opportunity"."description" AS [Insured], 
                "medicalunderwriting"."insurancecompany" AS [Carrier], 
                "policies"."policynumber" AS [Policy #],                 
                "policies"."deathbenefit" AS [Death Benefit], 
                "view_policy_consolidated"."client" AS [Client], 
                "view_premium_latest_by_source_date"."policy_status" AS [Policy Status], 
                "view_policy_consolidated"."program" AS [Policy Level Program #], 
                "view_coo_latest_confirmed"."new_owner_name" AS [Policy Level Program #], 
                "policies"."aniversarydate" AS [Anniv. Date], 
                "opportunity"."description" AS [@Age of Anniv. Date], --function AgeOfAnniversary
                "policies"."premiumadvancedate" AS [Premium Advance  Date], 
                "policies_ext"."orig_settlement_date" AS [Original Settlement Date], 
                "opportunity"."description" AS [@Annualized LE Due Date], --function AnnualizedLEDueDate
                "opportunity"."description" AS [@Optimized Medical Records Due Date], --function OptimizedMedicalRecordsDueDate
                "opportunity"."description" AS [@Optimized LE Due Date], --function OptimizedLEDueDate
                "opportunity"."description" AS [@LE Target Date], --function LETargetDate
                "view_le_latest_flat_service_viva"."avs_date" AS [Most Recent Service AVS], 
                "opportunity"."description" AS [@Most Recent Service AVS Age], --function MostRecentServiceAVSAge
                "view_le_latest_flat_service_viva"."avs_le" AS [Most Recent Service AVS LE], 
                "view_le_latest_flat_service_viva"."avs_multiplier" AS [Most Recent Service AVS Mortality Multiplier], 
                "view_le_latest_flat_service_viva"."avs_impairment" AS [AVS Primary Diagnosis], 
                "opportunity"."description" AS [@AVS Rolled?], --function AVSRolled_func
                "opportunity"."description" AS [@AVS Next Age Change],--function AVSNextAgeChange
                "view_le_latest_flat_service_viva"."tf_date" AS [Most Recent Service 21st], 
                "opportunity"."description" AS [@Most Recent Service 21st Age], --function MostRecentService21stAge
                "view_le_latest_flat_service_viva"."tf_le" AS [Most Recent Service 21st LE], 
                "view_le_latest_flat_service_viva"."tf_le85" AS [Most Recent Service 21st 85% LE], 
                "view_le_latest_flat_service_viva"."tf_multiplier" AS [Most Recent Service 21st Mortality Multiplier], 
                "opportunity"."description" AS [@21st Next Age Change], --function _21stNextAgeChange
                "view_le_latest_flat_service_viva"."fasano_date" AS [Most Recent Service Fasano], 
                "opportunity"."description" AS [@Most Recent Service Fasano Age], --function MostRecentServiceFasanoAge
                "view_le_latest_flat_service_viva"."fasano_le" AS [Most Recent Service Fasano LE], 
                "view_le_latest_flat_service_viva"."fasano_multiplier" AS [Most Recent Service Fasano Mortality Multiplier], 
                "view_le_latest_flat_service_viva"."fasano_impairment" AS [Fasano Primary Diagnosis], 
                "view_hipaa_latest_signature_linked_uw"."signature_date" AS [Latest HIPAA Date], 
                "view_hipaa_latest_signature_linked_uw"."entity" AS [Latest HIPAA Entity], 
                "view_hipaa_latest_signature_linked_uw"."duration" AS [Latest HIPAA Duration], 
                "opportunity"."description" AS [@Latest HIPAA Northstar], --function LatestHIPAANorthstar
                "opportunity"."description" AS [@Latest HIPAA Signed via POA], --function LatestHIPAASignedViaPOA
                "view_hipaa_latest_outstanding_hipaa_request"."lastrequest" AS [Latest Outstanding HIPAA Request], 
                "view_policy_hipaa_next_send_date"."nexthipaasenddate" AS [Next HIPAA Request], 
                "opportunity"."description" AS [@Update In Progress], --function UpdateInProgress
                "view_oppotunity_latest_medical_records"."latestdate" AS [Most Current All Records Received], 
                "opportunity"."description" AS [@Outside Collection Date], --function OutsideCollectionDate
                "opportunity"."description" AS [@Most Current All Records Received Age], --function MostCurrentAllRecordsReceivedAge
                "viewlast_aps_visit_date"."last_visit_date" AS [Last Visit Date], 
                "opportunity"."description" AS [@Last Visit Date Age], --function LastVisitDateAge
                "opportunity"."description" AS [@UW Exception Date], --function UWExceptionDate
                "opportunity"."description" AS [@UW Exception], --function UWException
                "opportunity"."description" AS [@UW Exception Add'l], --function UWExceptionAdd
                "opportunity"."description" AS [@Legal Exception], --function LegalException
                "opportunity_ext"."legal_exception_string" AS [Legal Exception Reason], 
                "view_flags_issues_latest_by_confirm_date"."confirmationstatus" AS [Confirmation Status], 
                "view_flags_issues_latest_by_confirm_date"."confirmationstatusdate" AS [Confirmation Date], 
                "opportunity_ext"."dob" AS [DOB String], 
                "opportunity_ext"."date_of_death" AS [Date of Death], 
                "view_policy_consolidated"."kbc_policyid" AS [Lima Policy ID], 
                "view_policy_currentlocation"."location" AS [Original Policy Location], 

                "policies"."policiesid",
                "opportunity_ext"."aps_update_in_prog", 
                "opportunity_ext"."aps_update_in_prog2", 
                "opportunity_ext"."aps_update_in_prog3", 
                "underwriting"."apsupdateinprog_c_early", 
                "underwriting"."apsupdateinprog_c_early2", 
                "policies"."policy_exception", 
                "policies"."exception_value", 
                "view_aps_update_last_outstanding"."opportunityid", 
                "policies"."nulldateforcrystal", 
                "policies"."exception_date", 
                "opportunity_ext"."legal_exception", 
                "opportunity_ext"."legal_exception_date", 
                "policies"."exception_value2", 
                "underwriting"."outside_records_collected", 
                "view_le_latest_flat_service_viva"."avs_rolled", 
                "view_hipaa_latest_signature_linked_uw"."northstar_listed", 
                "view_hipaa_latest_signature_linked_uw"."signed_via_poa" 
FROM   ((((((( 
             ((((((((("sysdba"."policies" "POLICIES" 
                       INNER JOIN "sysdba"."medicalunderwriting" 
                                  "MEDICALUNDERWRITING" 
                               ON "policies"."medicalunderwritingid" = 
                                  "medicalunderwriting"."medicalunderwritingid") 
                      LEFT OUTER JOIN "sysdba"."view_policy_consolidated" 
                                      "View_Policy_Consolidated" 
                                   ON "policies"."policiesid" = 
                                      "view_policy_consolidated"."policiesid") 
                     LEFT OUTER JOIN 
                     "sysdba"."view_premium_latest_by_source_date" 
                     "View_Premium_Latest_By_Source_Date" 
                                  ON "policies"."policiesid" = 
                     "view_premium_latest_by_source_date"."policiesid") 
                    LEFT OUTER JOIN "sysdba"."view_coo_latest_confirmed" 
                                    "View_COO_Latest_Confirmed" 
                                 ON "policies"."policiesid" = 
                                    "view_coo_latest_confirmed"."policiesid") 
                   LEFT OUTER JOIN "sysdba"."view_policy_currentlocation" 
                                   "View_Policy_CurrentLocation" 
                                ON "policies"."policiesid" = 
                                   "view_policy_currentlocation"."policiesid") 
                  LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" 
                               ON 
                "policies"."policiesid" = "policies_ext"."policiesid") 
                 LEFT OUTER JOIN 
                 "sysdba"."view_flags_issues_latest_by_confirm_date" 
                 "View_Flags_Issues_Latest_By_Confirm_Date" 
                              ON 
               "policies"."policiesid" = 
               "view_flags_issues_latest_by_confirm_date"."policiesid") 
                LEFT OUTER JOIN "sysdba"."view_policy_hipaa_next_send_date" 
                                "View_Policy_HIPAA_Next_Send_Date" 
                             ON "policies"."policiesid" = 
                                "view_policy_hipaa_next_send_date"."policiesid") 
               LEFT OUTER JOIN "sysdba"."view_hipaa_latest_signature_linked_uw" 
                               "View_HIPAA_Latest_Signature_Linked_UW" 
                            ON 
               "policies"."policiesid" = 
               "view_hipaa_latest_signature_linked_uw"."policiesid") 
              INNER JOIN "sysdba"."opportunity" "OPPORTUNITY" 
                      ON "medicalunderwriting"."opportunityid" = 
                         "opportunity"."opportunityid") 
             INNER JOIN "sysdba"."opportunity_ext" "OPPORTUNITY_EXT" 
                     ON 
         "opportunity"."opportunityid" = "opportunity_ext"."opportunityid") 
            LEFT OUTER JOIN "sysdba"."viewlast_aps_visit_date" 
                            "viewLast_APS_Visit_Date" 
                         ON "opportunity"."opportunityid" = 
                            "viewlast_aps_visit_date"."opportunityid") 
           LEFT OUTER JOIN "sysdba"."underwriting" "UNDERWRITING" 
                        ON 
         "opportunity"."opportunityid" = "underwriting"."opportunityid") 
          LEFT OUTER JOIN "sysdba"."view_aps_update_last_outstanding" 
                          "View_APS_Update_Last_Outstanding" 
                       ON "opportunity"."opportunityid" = 
                          "view_aps_update_last_outstanding"."opportunityid") 
         LEFT OUTER JOIN "sysdba"."view_hipaa_latest_outstanding_hipaa_request" 
                         "View_HIPAA_Latest_Outstanding_HIPAA_Request" 
                      ON "opportunity"."opportunityid" = 
         "view_hipaa_latest_outstanding_hipaa_request"."opportunityid") 
        LEFT OUTER JOIN "sysdba"."view_oppotunity_latest_medical_records" 
                        "View_Oppotunity_latest_medical_records" 
                     ON 
       "opportunity"."opportunityid" = 
       "view_oppotunity_latest_medical_records"."opportunityid") 
       LEFT OUTER JOIN "sysdba"."view_le_latest_flat_service_viva" 
                       "View_LE_Latest_Flat_Service_viva" 
                    ON "opportunity"."opportunityid" = 
                       "view_le_latest_flat_service_viva"."opportunityid" 
WHERE  "view_policy_consolidated"."client" = 'Viva (Blackstone)' 