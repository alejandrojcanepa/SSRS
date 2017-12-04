SELECT
       "view_policy_consolidated"."name" AS [Case Name], 
       "policies"."insuredname" AS [Client Name],
       "view_policy_consolidated"."insurancecompany" AS [Carrier], 
       "policies"."policynumber" AS [Policy #], 
       "view_policy_consolidated"."stateofissue" AS [State of Issue], 
       "policies"."deathbenefit" AS [Death Benefit], 
       "prem_reqs_new"."total_death_benefit" AS [Current Death Benefit], 
       "view_policy_consolidated"."name" AS [@ROP], --Function ROP
       "policies_ext"."db_change" AS [Death Benefit Change], 
       "medicalunderwriting"."productname" AS [Product], 
       "view_policy_consolidated"."name" AS [@VUL], --Function VUL
       "view_policy_consolidated"."name" AS [@Program Provider], --Function Program_Provider
       "view_policy_consolidated"."program" AS [Program #], --used in the code as VPCProgram parameter
       "view_policy_consolidated"."client" AS [Client], --used in the code as VPCClient parameter
       "view_policy_consolidated"."name" AS [@NCB Related], --Function NCB_Related_func
       "view_policy_client_previous"."client" AS [Previous Client], 
       "policies"."premiumadvancedate" AS [Prem. Adv. Date], 
       "policies"."aniversarydate" AS [@Anniv.], --Function Annual_Stmt_Date
       "prem_reqs_new"."source_of_information_d" AS [Date Carrier Called], 
       "prem_reqs_new"."policy_status" AS [Policy Status], 
       "prem_reqs_new"."confirmed_lapse_date" AS [Confirmed Lapse Date], 
       "prem_reqs_new"."current_cash_value" AS [Current Cash Value], 
       "prem_reqs_new"."current_surrender_value" AS [Current Cash Value], 
       "prem_reqs_new"."last_coi" AS [Last COI ], 
       "view_policy_consolidated"."name" AS [@Running Off], --Function Running_Off
       "prem_reqs_new"."ga_charge" AS [Last GA Amt./Shadow COI], 
       "prem_reqs_new"."last_coi_date" AS [Date COI Taken],        
       "prem_reqs_new"."kbc_decision" AS [Owner Decision], 
       "prem_reqs_new"."kbc_distressed_as_of" AS [As Of], 
       "prem_reqs_new"."date_addl_prem_due" AS [Date Addl Prem. Due], 
       "prem_reqs_new"."est_req_prem" AS [Est. Req. Premium], 
       "view_policy_consolidated"."name" AS [@Adj. Req. Premium], --Function Adj_Req_Premium
       "prem_reqs_new"."premnumberofmonth" AS [# of Mos], 
       "view_policy_consolidated"."name" AS [@Override Premium], --Function Override_Premium_func
       "prem_reqs_new"."calc_method" AS [Calculation Method], 
       "prem_reqs_new"."est_req_prem_date" AS [Addl Prem will Cover COI Thru], 
       "viewgmbh_payment_latest"."prem_request_toncb" AS [Request Premium to Accounting], 
       "PREM_REQS_CAT_2"."amount_paid" AS [Most Recent Premium Payment], 
       "PREM_REQS_CAT_2"."date_addl_prem_paid" AS [Date Paid], 
       "PREM_REQS_CAT_2"."paid_by" AS [Paid By], 
       "PREM_REQS_CAT_2"."date_carrier_confirmed_premium" AS [Date Carrier Confirmed Payment], 
       "gmbh"."gmbh_num" AS [GMBH #], 
       "gmbh"."effective_date" AS [Effective Date], 
       "gmbh"."borrower" AS [Borrower #1], 
       "gmbh"."borrower2" AS [Borrower #2], 
       "gmbh"."borrower3" AS [Borrower #3], 
       "gmbh"."sub" AS [Sub], 
       "gmbh"."maturity_date" AS [Maturity Date], 
       "gmbh"."coll_rel_agrmnt_date" AS [Collateral Rel Agmt Date], 
       "view_policy_consolidated"."name" AS [@PHL Rate Increase], --Function PHL_Rate_Increase
       "viewlatest_misc_corresp_rate_increase"."rate_increase" AS [Effective Date], 
       "opportunity_ext"."date_of_death" AS [Date of Death], 
       "view_totalpremiumpaid_consolidated"."totalpremiumpaid" AS [Total Premiums Paid To Date], 
       "viewlatest_policy_flag_items"."flagged_for" AS [Flagged For], 
       "viewlatest_policy_flag_items"."flag_removed" AS [Flag Removed],        
       "view_latest_rate_change_notification"."correspondence_type" AS [Coresp. Type], 
       "view_latest_rate_change_notification"."date_recvd" AS [Date Rec'd], 
       "view_latest_rate_change_notification"."effective_date" AS [Effective Date], 
       "policies"."category" AS [Category], 
       "view_gmbh_second_latest_proj_date"."proj_date" AS [2nd to the Last Sched Prem Due Date], 
       "view_gmbh_latest_proj_date"."proj_date" AS [Last Sched Prem Due Date], 
       "service_ext"."sub_tracking_ssn_d" AS [SSN Check], 
       "service_ext"."ssn_issue" AS [SSN Issue Date], 
       "service_ext"."issues" AS [SSN Issue], 
       "service_ext"."issue_resolved" AS [SSN Issue Resolved], 
       "north_channel_audit"."a1" AS [Service Checklist Input], 
       "north_channel_audit"."a2" AS [Service Checklist Reviewed], 
       "north_channel_audit"."ms" AS [Service Checklist Sign-Off], 
       "north_channel_audit"."msd" AS [Service Checklist Date], 
       "view_mdb_tracking_latest"."mdb_responsible" AS [MDB], 
       "view_mdb_tracking_latest"."owner_entity" AS [MDB Owner Entity], 
       "view_mdb_tracking_latest"."start_date" AS [MDB Start Date], 
       "view_mdb_tracking_latest"."end_date" AS [MDB End Date], 
       "prem_reqs_new"."analyst" AS [Analyst], 
       "prem_reqs_new"."audited_by" AS [Reviewer], 
       "view_fortress_general"."current year" AS [Current Policy Year], 
       "view_fortress_general"."current prem expense" AS [Current Year Policy Prem Exp], 
       "view_fortress_general"."est_premium_expense" AS [Current Year Est Prem Exp], 
       "view_fortress_general"."next prem expense" AS [Next Year Policy Prem Exp], 
       "view_fortress_general"."next est prem expense" AS [Next Year Est Prem Expense], 
       "opportunity_ext"."dob" AS [DOB],

       "policies"."policiesid", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "prem_reqs_new"."shaow_acct", 
       "prem_reqs_new"."coi_estimated", 
       "category_1"."prem_reqs_newid", 
       "view_policy_consolidated"."provider" AS [VPCProvider], 
       "view_policy_performance_latest"."annualstatementdate", 
       "prem_reqs_new"."override_premium", 
       "viewlatest_misc_corresp_rate_increase"."effective_date", 
       "prem_reqs_new"."adj_est_prem", 
       "policies_ext"."product_carrier_vul", 
       "view_ncb_premium_report_scope"."endreason", 
       "prem_reqs_new"."rop" AS [PRNROP],  
       "view_policy_client_current"."ncb_related"
       
FROM   (((((((((((((((((( 
                          ( 
                              ( 
                                ((("sysdba"."medicalunderwriting" 
                                  "MEDICALUNDERWRITING" 
                              INNER JOIN "sysdba"."policies" "POLICIES" 
                                      ON 
       "medicalunderwriting"."medicalunderwritingid" = 
       "policies"."medicalunderwritingid") 
                             LEFT OUTER JOIN "sysdba"."opportunity_ext" 
                                             "OPPORTUNITY_EXT" 
                                          ON 
                             "medicalunderwriting"."opportunityid" = 
                             "opportunity_ext"."opportunityid") 
                            LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" 
                                         ON "policies"."policiesid" = 
                                            "category_1"."policiesid") 
                           LEFT OUTER JOIN "sysdba"."category_2" "CATEGORY_2" 
                                        ON "policies"."policiesid" = 
                                           "category_2"."policiesid") 
                          LEFT OUTER JOIN 
                          "sysdba"."view_totalpremiumpaid_consolidated" 
                          "View_TotalPremiumPaid_Consolidated" 
                                       ON "policies"."policiesid" = 
                          "view_totalpremiumpaid_consolidated"."policiesid") 
                         LEFT OUTER JOIN "sysdba"."view_policy_consolidated" 
                                         "View_Policy_Consolidated" 
                                      ON 
                        "policies"."policiesid" = 
                        "view_policy_consolidated"."policiesid") 
                        LEFT OUTER JOIN 
                        "sysdba"."view_policy_performance_latest" 
                        "View_Policy_Performance_Latest" 
                                     ON "policies"."policiesid" = 
                        "view_policy_performance_latest"."policiesid") 
                       LEFT OUTER JOIN "sysdba"."viewlatest_policy_flag_items" 
                                       "viewLatest_Policy_Flag_Items" 
                                    ON "policies"."policiesid" = 
                       "viewlatest_policy_flag_items"."policiesid") 
                      LEFT OUTER JOIN "sysdba"."gmbh" "GMBH" 
                                   ON 
                      "policies"."policiesid" = "gmbh"."policiesid") 
                     LEFT OUTER JOIN 
                     "sysdba"."viewlatest_misc_corresp_rate_increase" 
                     "viewLatest_Misc_Corresp_Rate_Increase" 
                                  ON 
       "policies"."policiesid" = 
       "viewlatest_misc_corresp_rate_increase"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_latest_rate_change_notification" 
                        "View_Latest_Rate_Change_Notification" 
                     ON 
        "policies"."policiesid" = 
        "view_latest_rate_change_notification"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_gmbh_latest_proj_date" 
                       "View_GMBH_Latest_Proj_Date" 
                    ON "policies"."policiesid" = 
                       "view_gmbh_latest_proj_date"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_gmbh_second_latest_proj_date" 
                        "View_GMBH_Second_Latest_Proj_Date" 
                     ON "policies"."policiesid" = 
                        "view_gmbh_second_latest_proj_date"."policiesid") 
       LEFT OUTER JOIN "sysdba"."north_channel_audit" "NORTH_CHANNEL_AUDIT" 
                    ON "policies"."policiesid" = 
                       "north_channel_audit"."policiesid") 
        LEFT OUTER JOIN "sysdba"."service_ext" "SERVICE_EXT" 
                     ON "policies"."policiesid" = "service_ext"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_mdb_tracking_latest" 
                       "View_MDB_Tracking_Latest" 
                    ON "policies"."policiesid" = 
                       "view_mdb_tracking_latest"."policiesid") 
        LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" 
                     ON "policies"."policiesid" = "policies_ext"."policiesid") 
       INNER JOIN "sysdba"."view_ncb_premium_report_scope" 
                  "View_NCB_Premium_Report_scope" 
               ON "policies"."policiesid" = 
                  "view_ncb_premium_report_scope"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_policy_client_previous" 
                        "View_Policy_Client_Previous" 
                     ON "policies"."policiesid" = 
                        "view_policy_client_previous"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_policy_client_current" 
                       "View_Policy_Client_Current" 
                    ON "policies"."policiesid" = 
                       "view_policy_client_current"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_fortress_general" "View_Fortress_General" 
                     ON 
       "policies"."policiesid" = "view_fortress_general"."policiesid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                    ON "category_1"."prem_reqs_newid" = 
                       "prem_reqs_new"."prem_reqs_newid") 
        LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_CAT_2" 
                     ON "category_2"."prem_reqs_newid" = 
                        "PREM_REQS_CAT_2"."prem_reqs_newid") 
       LEFT OUTER JOIN "sysdba"."viewgmbh_payment_latest" 
                       "viewGMBH_PAYMENT_Latest" 
                    ON "gmbh"."policiesid" = 
                       "viewgmbh_payment_latest"."policiesid" 