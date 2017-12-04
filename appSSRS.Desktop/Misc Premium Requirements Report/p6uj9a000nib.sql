SELECT "policies"."policynumber", 
       "policies"."aniversarydate", 
       "policies"."deathbenefit", 
       "policies"."policiesid", 
       "prem_reqs_new"."est_req_prem_date", 
       "prem_reqs_new"."date_addl_prem_due", 
       "prem_reqs_new"."est_req_prem", 
       "prem_reqs_new"."calc_method", 
       "prem_reqs_new"."current_surrender_value", 
       "prem_reqs_new"."last_coi_date", 
       "prem_reqs_new"."last_coi", 
       "prem_reqs_new"."current_cash_value", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "PREM_REQS_CAT_2"."date_addl_prem_paid", 
       "PREM_REQS_CAT_2"."amount_paid", 
       "PREM_REQS_CAT_2"."paid_by", 
       "policies"."premiumadvancedate", 
       "view_totalpremiumpaid_consolidated"."totalpremiumpaid", 
       "view_policy_consolidated"."name", 
       "view_policy_consolidated"."insurancecompany", 
       "view_policy_consolidated"."program", 
       "view_policy_consolidated"."provider", 
       "prem_reqs_new"."source_of_information_d", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."shaow_acct", 
       "opportunity_ext"."date_of_death", 
       "medicalunderwriting"."productname", 
       "PREM_REQS_CAT_2"."date_carrier_confirmed_premium", 
       "view_policy_performance_latest"."annualstatementdate", 
       "prem_reqs_new"."policy_status", 
       "prem_reqs_new"."confirmed_lapse_date", 
       "policies"."insuredname", 
       "viewlatest_policy_flag_items"."flagged_for", 
       "viewlatest_policy_flag_items"."flag_removed", 
       "prem_reqs_new"."coi_estimated", 
       "prem_reqs_new"."override_premium", 
       "viewlatest_misc_corresp_rate_increase"."rate_increase", 
       "viewlatest_misc_corresp_rate_increase"."effective_date", 
       "gmbh"."coll_rel_agrmnt_date", 
       "view_policy_consolidated"."stateofissue", 
       "prem_reqs_new"."adj_est_prem", 
       "prem_reqs_new"."ga_charge", 
       "prem_reqs_new"."premnumberofmonth", 
       "view_latest_rate_change_notification"."correspondence_type", 
       "view_latest_rate_change_notification"."date_recvd", 
       "view_latest_rate_change_notification"."effective_date", 
       "view_policy_consolidated"."client", 
       "service_ext"."sub_tracking_ssn_d", 
       "service_ext"."ssn_issue", 
       "service_ext"."issues", 
       "service_ext"."issue_resolved", 
       "prem_reqs_new"."kbc_decision", 
       "prem_reqs_new"."kbc_distressed_as_of", 
       "prem_reqs_new"."analyst", 
       "prem_reqs_new"."audited_by", 
       "prem_reqs_new"."rop", 
       "policies_ext"."db_change", 
       "prem_reqs_new"."total_death_benefit", 
       "policies_ext"."product_carrier_vul", 
       "view_policy_client_previous"."client", 
       "view_fortress_general"."current year", 
       "view_fortress_general"."current prem expense", 
       "view_fortress_general"."est_premium_expense", 
       "view_fortress_general"."next prem expense", 
       "view_fortress_general"."next est prem expense", 
       "opportunity_ext"."dob", 
       "policies_ext"."mer", 
       "policies_ext"."mer_type", 
       "policies_ext"."mer_age", 
       "opportunity_ext"."ssn", 
       "policies"."sub_fund_group" 
FROM   (((((( 
            (((( 
                     (((((("sysdba"."medicalunderwriting" "MEDICALUNDERWRITING" 
                       INNER JOIN "sysdba"."policies" "POLICIES" 
                               ON 
"medicalunderwriting"."medicalunderwritingid" = 
"policies"."medicalunderwritingid") 
                      LEFT OUTER JOIN "sysdba"."opportunity_ext" 
                                      "OPPORTUNITY_EXT" 
                                   ON "medicalunderwriting"."opportunityid" = 
                                      "opportunity_ext"."opportunityid") 
                     LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" 
                                  ON 
                        "policies"."policiesid" = "category_1"."policiesid") 
                    LEFT OUTER JOIN "sysdba"."category_2" "CATEGORY_2" 
                                 ON 
                       "policies"."policiesid" = "category_2"."policiesid") 
                   LEFT OUTER JOIN "sysdba"."view_totalpremiumpaid_consolidated" 
                                   "View_TotalPremiumPaid_Consolidated" 
                                ON "policies"."policiesid" = 
                   "view_totalpremiumpaid_consolidated"."policiesid") 
                  INNER JOIN "sysdba"."view_policy_consolidated" 
                             "View_Policy_Consolidated" 
                          ON "policies"."policiesid" = 
                             "view_policy_consolidated"."policiesid") 
                 LEFT OUTER JOIN "sysdba"."view_policy_performance_latest" 
                                 "View_Policy_Performance_Latest" 
                              ON "policies"."policiesid" = 
                                 "view_policy_performance_latest"."policiesid") 
                LEFT OUTER JOIN "sysdba"."viewlatest_policy_flag_items" 
                                "viewLatest_Policy_Flag_Items" 
                             ON "policies"."policiesid" = 
                                "viewlatest_policy_flag_items"."policiesid") 
               LEFT OUTER JOIN "sysdba"."gmbh" "GMBH" 
                            ON "policies"."policiesid" = "gmbh"."policiesid") 
              LEFT OUTER JOIN "sysdba"."viewlatest_misc_corresp_rate_increase" 
                              "viewLatest_Misc_Corresp_Rate_Increase" 
                           ON 
              "policies"."policiesid" = 
              "viewlatest_misc_corresp_rate_increase"."policiesid") 
             LEFT OUTER JOIN "sysdba"."view_latest_rate_change_notification" 
                             "View_Latest_Rate_Change_Notification" 
                          ON 
       "policies"."policiesid" = 
       "view_latest_rate_change_notification"."policiesid") 
       LEFT OUTER JOIN "sysdba"."service_ext" "SERVICE_EXT" 
                   ON "policies"."policiesid" = "service_ext"."policiesid") 
        LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" 
                     ON "policies"."policiesid" = "policies_ext"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_policy_client_previous" 
                       "View_Policy_Client_Previous" 
                    ON "policies"."policiesid" = 
                       "view_policy_client_previous"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_fortress_general" "View_Fortress_General" 
                   ON "policies"."policiesid" = 
                      "view_fortress_general"."policiesid") 
        LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                     ON "category_1"."prem_reqs_newid" = 
                        "prem_reqs_new"."prem_reqs_newid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_CAT_2" 
                    ON "category_2"."prem_reqs_newid" = 
                       "PREM_REQS_CAT_2"."prem_reqs_newid" 
WHERE  ( "view_policy_consolidated"."client" = 'ALS Capital Ventures' 
          OR "view_policy_consolidated"."client" = 'Cromwell' 
          OR "view_policy_consolidated"."client" = 'H Ventures' 
          OR "view_policy_consolidated"."client" = 'Life Bond (DARR)' 
          OR "view_policy_consolidated"."client" = 'LSS - JMD' 
          OR "view_policy_consolidated"."client" = 'Mosaic' ) 