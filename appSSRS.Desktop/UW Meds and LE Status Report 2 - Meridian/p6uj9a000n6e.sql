SELECT
       "opportunity"."description" AS [Insured], 
       "medicalunderwriting"."insurancecompany" AS [Carrier], 
       "policies"."policynumber" AS [Policy #],
       "policies"."deathbenefit" AS [Death Benefit],
       "view_policy_consolidated"."client" AS [Client], 
       "view_premium_latest_by_source_date"."policy_status" AS [Policy Status], 
       "view_policy_consolidated"."program" AS [Policy Level Program #], 
       "view_coo_latest_confirmed"."new_owner_name" AS [Current Owner],
       "policies"."aniversarydate" AS [Anniv. Date], 
       "opportunity"."description" AS [@Age of Anniv. Date], --function AgeOfAnnivDate
       "policies"."premiumadvancedate" AS [Premium Advance Date], 
       "policies_ext"."orig_settlement_date" AS [Original Settlement Date],
       "opportunity"."description" AS [@Annualized LE Due Date], --function AnnualizedLEDueDate
       "opportunity"."description" AS [@Optimized Medical Records Due Date], --function OptimizedMedicalRecordsDueDate
       "opportunity"."description" AS [@Optimized LE Due Date], --function OptimizedLEDueDate
       "opportunity"."description" AS [@LE Target Date], --function LETargetDate
       "gmbh"."borrower" AS [Borrower Name],
       "gmbh"."gmbh_num" AS [GMBH #],
       "gmbh"."effective_date" AS [Effective Date], 
       "gmbh"."maturity_date" AS [Maturity Date], 
       "gmbh"."coll_rel_agrmnt_date" AS [Collateral Agreement Release Date], 
       "opportunity"."description" AS [@Most Recent Service AVS], --function MostRecentServiceAVS
       "opportunity"."description" AS [@Most Recent Service AVS Age], --function MostRecentServiceAVSAge
       "opportunity"."description" AS [@Most Recent Service AVS LE], --function MostRecentServiceAVSLE
       "opportunity"."description" AS [@Most Recent Service AVS Mortality Multiplier], --function MostRecentServiceAVSMortality
       "opportunity"."description" AS [@AVS Primary Diagnosis], --function AVSPrimaryDiagnosis
       "opportunity"."description" AS [@AVS Rolled?], --function AVSRolled
       "opportunity"."description" AS [@AVS Next Age Change], --function AVSAgeChange
       "opportunity"."description" AS [@Most Recent Service 21st], --function MostRecentService21st
       "opportunity"."description" AS [@Most Recent Service 21st Age], --function MostRecentService21StAge
       "opportunity"."description" AS [@Most Recent Service 21st LE], --function MostRecentService21StLE
       "opportunity"."description" AS [@Most Recent Service 21st Mortality Multiplier], --function MostRecentService21stMortality
       "opportunity"."description" AS [@Most Recent Service EMSI], --function MostRecentServiceEMSI
       "opportunity"."description" AS [@Most Recent Service EMSI Age], --function MostRecentServiceEMSIAge
       "opportunity"."description" AS [@Most Recent Service EMSI LE], --function MostRecentServiceEMSILE
       "opportunity"."description" AS [@Most Recent Service EMSI Mortality Multiplier], --function MostRecentServiceEMSIMortality
       "view_hipaa_latest_signature_linked"."signature_date" AS [Latest HIPAA Date], 
       "view_hipaa_latest_signature_linked"."entity" AS [Latest HIPAA Entity], 
       "view_hipaa_latest_signature_linked"."duration" AS [Latest HIPAA Duration], 
       "opportunity"."description" AS [@Latest HIPAA Northstar], --function LatestHIPAANorthstar
       "opportunity"."description" AS [@Latest Signed via POA], --function LatestSignedViaPOA
       "view_hipaa_latest_outstanding_hipaa_request"."lastrequest" AS [Latest Outstanding HIPAA Request], 
       "view_policy_hipaa_next_send_date"."nexthipaasenddate" AS [Next HIPAA Request],
       "opportunity"."description" AS [@Update In Progress], --function UpdateInProgress
       "viewlatest_all_rec_recv_date"."all_rec_recv_date" AS [Most Current All Records Received], 
       "opportunity"."description" AS [@Most Current All Records Received Age], --function MostCurrentAllRecordsReceivedAge
       "viewlast_aps_visit_date"."last_visit_date" AS [Last Visit Date], 
       "opportunity"."description" AS [@Last Visit Date Age], --function LastVisitDateAge
       "opportunity"."description" AS [@UW Exception Date], --function UWExceptionDate
       "opportunity"."description" AS [@UW Exception], --function UWException
       "opportunity"."description" AS [@UW Exception Add'l], --'function UWExceptionAddl
       "opportunity"."description" AS [@Legal Exception], --function LegalException
       "opportunity_ext"."legal_exception_string" AS [Legal Exception Reason], 
       "view_flags_issues_latest_by_confirm_date"."confirmationstatus" AS [Confirmation Status], 
       "view_flags_issues_latest_by_confirm_date"."confirmationstatusdate" AS [Confirmation Date], 
       "opportunity"."description" AS [@DOB String], --function DOBString
       "opportunity_ext"."date_of_death" AS [Date of Death], 
       "view_policy_consolidated"."kbc_policyid" AS [Lima Policy ID], 
       "view_policy_currentlocation"."location" AS [Original Policy Location], 
       "medicalunderwriting"."offer" AS [Offer],
       "view_le_top2_ncb_flat"."companyname" AS [Bank LE 1], 
       "view_le_top2_ncb_flat"."avsdate" AS [Bank LE 1 Report Date], 
       "view_le_top2_ncb_flat"."lifeexpectancy" AS [Bank LE 1 Months], 
       "view_le_top2_ncb_flat"."companytable" AS [Bank LE 1 Multiplier], 
       "view_le_top2_ncb_flat"."companyname2" AS [Bank LE 2], 
       "view_le_top2_ncb_flat"."avsdate2" AS [Bank LE 2 Report Date], 
       "view_le_top2_ncb_flat"."lifeexpectancy2" AS [Bank LE 2 Months], 
       "view_le_top2_ncb_flat"."companytable2" AS [Bank LE 2 Multiplier], 

       "policies"."policiesid", 
       "opportunity_ext"."aps_update_in_prog", 
       "opportunity_ext"."aps_update_in_prog2", 
       "opportunity_ext"."aps_update_in_prog3", 
       "underwriting"."apsupdateinprog_c_early", 
       "underwriting"."apsupdateinprog_c_early2", 
       "policies"."policy_exception", 
       "policies"."exception_value", 
       "opportunity_ext"."dob", 
       "view_aps_update_last_outstanding"."opportunityid", 
       "policies"."nulldateforcrystal", 
       "policies"."exception_date", 
       "opportunity_ext"."legal_exception", 
       "opportunity_ext"."legal_exception_date", 
       "policies"."exception_value2", 
       "view_le_latest_flat_service_2_nofilters"."emsi_multiplier"   AS "VLLFS2Nemsi_multiplier", 
       "view_le_latest_flat_service_bac_nofilters"."emsi_multiplier" AS "VLLFSBNemsi_multiplier", 
       "view_le_latest_flat_service_nofilters"."emsi_multiplier"     AS "VLLFSNemsi_multiplier", 
       "view_le_latest_flat_service_2_nofilters"."emsi_le"           AS "VLLFS2Nemsi_le", 
       "view_le_latest_flat_service_bac_nofilters"."emsi_le"         AS "VLLFSBNemsi_le", 
       "view_le_latest_flat_service_nofilters"."emsi_le"             AS "VLLFSNemsi_le", 
       "view_le_latest_flat_service_2_nofilters"."emsi_date"         AS "VLLFS2Nemsi_date", 
       "view_le_latest_flat_service_bac_nofilters"."emsi_date"       AS "VLLFSBNemsi_date", 
       "view_le_latest_flat_service_nofilters"."emsi_date"           AS "VLLFSNemsi_date", 
       "view_le_latest_flat_service_2_nofilters"."avs_multiplier"    AS "VLLFS2Navs_multiplier", 
       "view_le_latest_flat_service_bac_nofilters"."avs_multiplier"  AS "VLLFSBNavs_multiplier", 
       "view_le_latest_flat_service_nofilters"."avs_multiplier"      AS "VLLFSNavs_multiplier", 
       "view_le_latest_flat_service_2_nofilters"."avs_le"            AS "VLLFS2Navs_le", 
       "view_le_latest_flat_service_bac_nofilters"."avs_le"          AS "VLLFSBNavs_le", 
       "view_le_latest_flat_service_nofilters"."avs_le"              AS "VLLFSNavs_le", 
       "view_le_latest_flat_service_2_nofilters"."avs_date"          AS "VLLFS2Navs_date", 
       "view_le_latest_flat_service_bac_nofilters"."avs_date"        AS "VLLFSBNavs_date", 
       "view_le_latest_flat_service_nofilters"."avs_date"            AS "VLLFSNavs_date", 
       "view_le_latest_flat_service_2_nofilters"."tf_multiplier"     AS "VLLFS2Ntf_multiplier", 
       "view_le_latest_flat_service_bac_nofilters"."tf_multiplier"   AS "VLLFSBNtf_multiplier", 
       "view_le_latest_flat_service_nofilters"."tf_multiplier"       AS "VLLFSNtf_multiplier", 
       "view_le_latest_flat_service_2_nofilters"."tf_le"             AS "VLLFS2Ntf_le", 
       "view_le_latest_flat_service_bac_nofilters"."tf_le"           AS "VLLFSBNtf_le", 
       "view_le_latest_flat_service_nofilters"."tf_le"               AS "VLLFSNtf_le", 
       "view_le_latest_flat_service_2_nofilters"."tf_date"           AS "VLLFS2Ntf_date", 
       "view_le_latest_flat_service_bac_nofilters"."tf_date"         AS "VLLFSBNtf_date", 
       "view_le_latest_flat_service_nofilters"."tf_date"             AS "VLLFSNtf_date", 
       "view_le_latest_flat_service_2_nofilters"."avs_impairment"    AS "VLLFS2Navs_impairment", 
       "view_le_latest_flat_service_bac_nofilters"."avs_impairment"  AS "VLLFSBNavs_impairment", 
       "view_le_latest_flat_service_nofilters"."avs_impairment"      AS "VLLFSNavs_impairment", 
       "view_le_latest_flat_service_2_nofilters"."avs_rolled"        AS "VLLFS2Navs_rolled", 
       "view_le_latest_flat_service_bac_nofilters"."avs_rolled"      AS "VLLFSBNavs_rolled", 
       "view_le_latest_flat_service_nofilters"."avs_rolled"          AS "VLLFSNavs_rolled", 
       "view_le_latest_flat_service_monarch1_nofilters"."avs_date", 
       "view_le_latest_flat_service_monarch1_nofilters"."tf_date", 
       "view_le_latest_flat_service_monarch1_nofilters"."avs_le", 
       "view_le_latest_flat_service_monarch1_nofilters"."tf_le", 
       "view_le_latest_flat_service_monarch1_nofilters"."avs_multiplier", 
       "view_le_latest_flat_service_monarch1_nofilters"."tf_multiplier", 
       "view_le_latest_flat_service_monarch1_nofilters"."emsi_date", 
       "view_le_latest_flat_service_monarch1_nofilters"."emsi_le", 
       "view_le_latest_flat_service_monarch1_nofilters"."emsi_multiplier", 
       "view_hipaa_latest_signature_linked"."northstar_listed",
       "view_hipaa_latest_signature_linked"."signed_via_poa"

FROM   ((((((( 
             (( 
             (((((((((((("sysdba"."policies" "POLICIES" 
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
                                       ON 
                      "policies"."policiesid" = 
                      "view_premium_latest_by_source_date"."policiesid") 
                         LEFT OUTER JOIN "sysdba"."view_coo_latest_confirmed" 
                                         "View_COO_Latest_Confirmed" 
                                      ON "policies"."policiesid" = 
                         "view_coo_latest_confirmed"."policiesid") 
                        LEFT OUTER JOIN "sysdba"."view_policy_currentlocation" 
                                        "View_Policy_CurrentLocation" 
                                     ON "policies"."policiesid" = 
                        "view_policy_currentlocation"."policiesid") 
                       LEFT OUTER JOIN "sysdba"."gmbh" "GMBH" 
                                    ON 
                       "policies"."policiesid" = "gmbh"."policiesid") 
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
                   LEFT OUTER JOIN "sysdba"."view_hipaa_latest_signature_linked" 
                                   "View_HIPAA_Latest_Signature_Linked" 
                                ON 
"view_policy_consolidated"."policiesid" = 
"view_hipaa_latest_signature_linked"."policiesid") 
                  INNER JOIN "sysdba"."opportunity" "OPPORTUNITY" 
                          ON "medicalunderwriting"."opportunityid" = 
                             "opportunity"."opportunityid") 
                 INNER JOIN "sysdba"."opportunity_ext" "OPPORTUNITY_EXT" 
                         ON "opportunity"."opportunityid" = 
                            "opportunity_ext"."opportunityid") 
                LEFT OUTER JOIN "sysdba"."viewlast_aps_visit_date" 
                                "viewLast_APS_Visit_Date" 
                             ON "opportunity"."opportunityid" = 
                                "viewlast_aps_visit_date"."opportunityid") 
               LEFT OUTER JOIN "sysdba"."underwriting" "UNDERWRITING" 
                            ON "opportunity"."opportunityid" = 
                               "underwriting"."opportunityid") 
              LEFT OUTER JOIN "sysdba"."viewlatest_all_rec_recv_date" 
                              "viewLatest_All_Rec_Recv_Date" 
                           ON "opportunity"."opportunityid" = 
                              "viewlatest_all_rec_recv_date"."opportunityid") 
             LEFT OUTER JOIN "sysdba"."view_aps_update_last_outstanding" 
                             "View_APS_Update_Last_Outstanding" 
                          ON "opportunity"."opportunityid" = 
                             "view_aps_update_last_outstanding"."opportunityid") 
            LEFT OUTER JOIN 
            "sysdba"."view_hipaa_latest_outstanding_hipaa_request" 
            "View_HIPAA_Latest_Outstanding_HIPAA_Request" 
                         ON 
         "opportunity"."opportunityid" = 
         "view_hipaa_latest_outstanding_hipaa_request"."opportunityid") 
           LEFT OUTER JOIN "sysdba"."view_le_latest_flat_service_nofilters" 
                           "View_LE_Latest_Flat_Service_NoFilters" 
                        ON "opportunity"."opportunityid" = 
           "view_le_latest_flat_service_nofilters"."opportunityid") 
          LEFT OUTER JOIN "sysdba"."view_le_latest_flat_service_2_nofilters" 
                          "View_LE_Latest_Flat_Service_2_NoFilters" 
                       ON "opportunity"."opportunityid" = 
          "view_le_latest_flat_service_2_nofilters"."opportunityid") 
         LEFT OUTER JOIN "sysdba"."view_le_latest_flat_service_bac_nofilters" 
                         "View_LE_Latest_Flat_Service_BAC_NoFilters" 
                      ON "opportunity"."opportunityid" = 
         "view_le_latest_flat_service_bac_nofilters"."opportunityid") 
        LEFT OUTER JOIN 
        "sysdba"."view_le_latest_flat_service_monarch1_nofilters" 
        "View_LE_Latest_Flat_Service_Monarch1_NoFilters" 
                     ON "opportunity"."opportunityid" = 
        "view_le_latest_flat_service_monarch1_nofilters"."opportunityid") 
       LEFT OUTER JOIN "sysdba"."view_le_top2_ncb_flat" "View_LE_Top2_NCB_Flat" 
                    ON "opportunity"."opportunityid" = 
                       "view_le_top2_ncb_flat"."opportunityid" 
WHERE  NOT ( "view_policy_consolidated"."client" = '' 
              OR "view_policy_consolidated"."client" = 'Fortress' 
              OR "view_policy_consolidated"."client" = 'Fortress 2' 
              OR "view_policy_consolidated"."client" = 'Viva (Blackstone)' )