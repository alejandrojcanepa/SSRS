SELECT DISTINCT "opportunity"."description", 
                "medicalunderwriting"."insurancecompany", 
                "policies"."policynumber",                 
                "policies"."deathbenefit", 
                "view_policy_consolidated"."client", 
                "view_premium_latest_by_source_date"."policy_status", 
                "view_policy_consolidated"."program", 
                "view_coo_latest_confirmed"."new_owner_name", 
                "policies"."aniversarydate", 
                "policies"."premiumadvancedate", 
                "policies_ext"."orig_settlement_date", 
                "view_le_latest_flat_service_viva"."avs_date", 
                "view_le_latest_flat_service_viva"."avs_le", 
                "view_le_latest_flat_service_viva"."avs_multiplier", 
                "view_le_latest_flat_service_viva"."avs_impairment", 
                "view_le_latest_flat_service_viva"."tf_date", 
                "view_le_latest_flat_service_viva"."tf_le", 
                "view_le_latest_flat_service_viva"."tf_le85", 
                "view_le_latest_flat_service_viva"."tf_multiplier", 
                "view_hipaa_latest_signature_linked_uw"."signature_date", 
                "view_hipaa_latest_signature_linked_uw"."entity", 
                "view_hipaa_latest_signature_linked_uw"."duration", 
                "view_hipaa_latest_outstanding_hipaa_request"."lastrequest", 
                "view_policy_hipaa_next_send_date"."nexthipaasenddate", 
                "viewlast_aps_visit_date"."last_visit_date", 
                "opportunity_ext"."legal_exception_string", 
                "view_flags_issues_latest_by_confirm_date"."confirmationstatus", 
                "view_flags_issues_latest_by_confirm_date"."confirmationstatusdate", 
                "opportunity_ext"."dob", 
                "opportunity_ext"."date_of_death", 
                "view_policy_consolidated"."kbc_policyid", 
                "view_policy_currentlocation"."location", 

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
                "view_oppotunity_latest_medical_records"."latestdate", 
                "underwriting"."outside_records_collected", 
                "view_le_latest_flat_service_viva"."fasano_date", 
                "view_le_latest_flat_service_viva"."fasano_le", 
                "view_le_latest_flat_service_viva"."fasano_multiplier", 
                "view_le_latest_flat_service_viva"."avs_rolled", 
                "view_le_latest_flat_service_viva"."fasano_impairment", 
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