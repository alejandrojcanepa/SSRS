SELECT
       "policies"."sub_fund_group" AS [Sub Fund Group], 
       "view_policy_consolidated"."name" AS [Case Name], 
       "policies"."insuredname" AS [Client Name], 
       "view_policy_consolidated"."insurancecompany" AS [Carrier], 
       "policies"."policynumber" AS [Policy #], 
       "view_policy_consolidated"."stateofissue" AS [State of Issue], 
       "policies"."deathbenefit" AS [Death Benefit], 
       "prem_reqs_new"."total_death_benefit" AS [Current Death Benefit],
       "policies"."sub_fund_group" AS [@ROP], --Function ROP
       "policies_ext"."db_change" AS [Death Benefit Change], 
       "medicalunderwriting"."productname" AS [Product], 
       "policies"."sub_fund_group" AS [@VUL], --Function VUL
       "policies_ext"."mer" AS [ME], 
       "policies_ext"."mer_type" AS [ME Type], 
       "policies_ext"."mer_age" AS [ME Age], 
       "policies"."sub_fund_group" AS [@Program Provider], --Function Program_Provider
       "view_policy_consolidated"."program" AS [Program #], --used in the code as VPCProgram parameter
       "view_policy_consolidated"."client" AS [Client], --used in the code as VPCClient parameter
       "view_policy_client_previous"."client" AS [Previous Client], 
       "policies"."premiumadvancedate" AS [Prem. Adv. Date], 
       "policies"."aniversarydate" AS [Anniv. Date], 
       "policies"."sub_fund_group" AS [@Annual Stmt Date], --Function Annual_Stmt_Date
       "PREM_REQS_NEW_Prev"."source_of_information_d" AS [Date Carrier Called],
       "prem_reqs_new"."policy_status" AS [Policy Status], 
       "prem_reqs_new"."confirmed_lapse_date" AS [Confirmed Lapse Date], 
       "prem_reqs_new"."current_cash_value" AS [Current Cash Value], 
       "prem_reqs_new"."current_surrender_value" AS [Current Cash Surrender Value], 
       "prem_reqs_new"."last_coi" AS [Last COI], 
       "policies"."sub_fund_group" AS [@Running Off], --Function Running_Off
       "prem_reqs_new"."ga_charge" AS [Last GA Amt./Shadow COI], 
       "prem_reqs_new"."last_coi_date" AS [Date COI Taken], 
       "prem_reqs_new"."kbc_decision" AS [Owner Decision], 
       "prem_reqs_new"."kbc_distressed_as_of" AS [As Of], 
       "prem_reqs_new"."date_addl_prem_due" AS [Date Addl Prem. Due], 
       "prem_reqs_new"."est_req_prem" AS [Est. Req. Premium], 
       "policies"."sub_fund_group" AS [@Adj. Req. Premium], --Function Adj_Req_Premium
       "prem_reqs_new"."premnumberofmonth" AS [# of Mos], 
       "policies"."sub_fund_group" AS [@Override Premium], --Function Override_Premium_func
       "prem_reqs_new"."calc_method" AS [Calculation Method], 
       "prem_reqs_new"."est_req_prem_date" AS [Addl Prem will Cover COI Thru], 
       "PREM_REQS_CAT_2"."amount_paid" AS [Most Recent Premium Payment], 
       "PREM_REQS_CAT_2"."date_addl_prem_paid" AS [Date Paid], 
       "PREM_REQS_CAT_2"."paid_by" AS [Paid By], 
       "PREM_REQS_CAT_2"."date_carrier_confirmed_premium" AS [Date Carrier Confirmed Payment], 

       "policies"."policiesid", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "prem_reqs_new"."shaow_acct", 
       "prem_reqs_new"."coi_estimated", 
       "view_totalpremiumpaid_consolidated"."totalpremiumpaid", 
       "view_policy_consolidated"."provider" AS [VPCProvider], 
       "prem_reqs_new"."source_of_information_d", 
       "opportunity_ext"."date_of_death", 
       "view_policy_performance_latest"."annualstatementdate", 
       "viewlatest_policy_flag_items"."flagged_for", 
       "viewlatest_policy_flag_items"."flag_removed", 
       "prem_reqs_new"."override_premium", 
       "viewlatest_misc_corresp_rate_increase"."rate_increase", 
       "viewlatest_misc_corresp_rate_increase"."effective_date", 
       "gmbh"."coll_rel_agrmnt_date", 
       "prem_reqs_new"."adj_est_prem", 
       "view_latest_rate_change_notification"."correspondence_type", 
       "view_latest_rate_change_notification"."date_recvd", 
       "view_latest_rate_change_notification"."effective_date", 
       "service_ext"."sub_tracking_ssn_d", 
       "service_ext"."ssn_issue", 
       "service_ext"."issues", 
       "service_ext"."issue_resolved", 
       "prem_reqs_new"."analyst", 
       "prem_reqs_new"."audited_by", 
       "prem_reqs_new"."rop" AS [PRNROP], 
       "policies_ext"."product_carrier_vul", 
       "view_fortress_general"."current year", 
       "view_fortress_general"."current prem expense", 
       "view_fortress_general"."est_premium_expense", 
       "view_fortress_general"."next prem expense", 
       "view_fortress_general"."next est prem expense", 
       "opportunity_ext"."dob", 
       "view_policy_consolidated"."program_name", 
       "opportunity_ext"."ssn"
       
FROM   ((( 
         (((( 
            ( 
              (((( 
                         (((((("sysdba"."medicalunderwriting" 
                              "MEDICALUNDERWRITING" 
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
                     LEFT OUTER JOIN 
                     "sysdba"."view_totalpremiumpaid_consolidated" 
                     "View_TotalPremiumPaid_Consolidated" 
                                  ON "policies"."policiesid" = 
                     "view_totalpremiumpaid_consolidated"."policiesid") 
                    INNER JOIN "sysdba"."view_policy_consolidated" 
                               "View_Policy_Consolidated" 
                            ON "policies"."policiesid" = 
                               "view_policy_consolidated"."policiesid") 
                   LEFT OUTER JOIN "sysdba"."view_policy_performance_latest" 
                                   "View_Policy_Performance_Latest" 
                                ON 
                 "policies"."policiesid" = 
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
                           ON "policies"."policiesid" = 
                              "service_ext"."policiesid") 
             LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" 
                          ON "policies"."policiesid" = 
                             "policies_ext"."policiesid") 
            LEFT OUTER JOIN "sysdba"."view_policy_client_previous" 
                            "View_Policy_Client_Previous" 
                         ON "policies"."policiesid" = 
                            "view_policy_client_previous"."policiesid") 
           LEFT OUTER JOIN "sysdba"."view_fortress_general" 
                           "View_Fortress_General" 
                        ON "policies"."policiesid" = 
                           "view_fortress_general"."policiesid") 
          LEFT OUTER JOIN "sysdba"."category_1_prev" "CATEGORY_1_Prev" 
                       ON "policies"."policiesid" = 
                          "category_1_prev"."policiesid") 
         LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                      ON "category_1"."prem_reqs_newid" = 
                         "prem_reqs_new"."prem_reqs_newid") 
        LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_CAT_2" 
                     ON "category_2"."prem_reqs_newid" = 
                        "PREM_REQS_CAT_2"."prem_reqs_newid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW_Prev" 
                    ON "category_1_prev"."prem_reqs_newid" = 
                       "PREM_REQS_NEW_Prev"."prem_reqs_newid" 
WHERE  "view_policy_consolidated"."client" = 'Corry Capital' 