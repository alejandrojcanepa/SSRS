SELECT 
       "view_policy_consolidated"."name" AS [Case Name],
       "view_policy_consolidated"."insurancecompany" AS [Carrier],
       "policies"."policynumber" AS [Policy ],
       "view_policy_consolidated"."stateofissue" AS [State of Issue],
       "policies"."deathbenefit" AS [Death Benefit],
       "prem_reqs_new"."total_death_benefit" AS [Current Death Benefit],
       "view_policy_consolidated"."name" AS [@ROP], --funtion ROP
       "policies_ext"."db_change" AS [Death Benefit Change], 
       "medicalunderwriting"."productname" AS [Product],
       "view_policy_consolidated"."name" AS [@Program Provider], --function ProgramProvider
       "view_policy_consolidated"."programtext" AS [Program Name],
       "view_policy_consolidated"."program" AS [Program #], --used in the code as VPCProgram parameter
       "view_policy_client_current"."client" AS [Client],
       "view_policy_client_current"."startdate" AS [Client Date],
       "policies"."premiumadvancedate" AS [Prem. Adv. Date],
       "policies"."aniversarydate" AS [Anniv. Date],
       "view_policy_consolidated"."name" AS [@Anniv. Month], --function AnnivMonth
       "view_policy_consolidated"."name" AS [@Annual Stmt Date], --function AnnualStmtDate
       "prem_reqs_new"."source_of_information_d" AS [Date Carrier Called],
       "view_policy_consolidated"."name" AS [@Third Party Auth], --function ThirdPartyAuth
       "prem_reqs_new"."source_of_information" AS [Source of Info],
       "prem_reqs_new"."policy_status" AS [Policy Status],
       "prem_reqs_new"."confirmed_lapse_date" AS [Confirmed Lapse Date],
       "prem_reqs_new"."current_cash_value" AS [Current Cash Value],
       "prem_reqs_new"."current_surrender_value" AS [Current Cash Surrender Value],
       "prem_reqs_new"."last_coi" AS [Last COI],
       "view_fortress_general"."current year" AS [Current Policy Year],
       "view_fortress_general"."Current Prem Expense" AS [Current Year Policy Prem Exp],
       "view_fortress_general"."est_premium_expense" AS [Current Year Est Prem Exp],
       "view_fortress_general"."next prem expense" AS [Next Year Prem Exp], --used in the code as NextPremExpense
       "view_fortress_general"."next est prem expense" AS [Next Year Est Prem Exp], --used in the code as NextEstPrmExpense
       "view_policy_consolidated"."name" AS [@Running Off], --function OffRunningOff
       "prem_reqs_new"."ga_charge" AS [Last GA Amt./Shadow COI],
       "prem_reqs_new"."last_coi_date" AS [Date COI Taken],
       "prem_reqs_new"."date_addl_prem_due" AS [Date Addl Prem. Due],
       "view_policy_consolidated"."name" AS [@Month 1], --function Month_func with monthNum='1'
       "view_policy_consolidated"."name" AS [@Month 2], --function Month_func with monthNum='2'
       "view_policy_consolidated"."name" AS [@Month 3], --function Month_func with monthNum='3'
       "view_policy_consolidated"."name" AS [@Month 4], --function Month_func with monthNum='4'
       "view_policy_consolidated"."name" AS [@Month 5], --function Month_func with monthNum='5'
       "view_policy_consolidated"."name" AS [@Month 6], --function Month_func with monthNum='6'
       "view_policy_consolidated"."name" AS [@Month 7], --function Month_func with monthNum='7'
       "view_policy_consolidated"."name" AS [@Month 8], --function Month_func with monthNum='8'
       "view_policy_consolidated"."name" AS [@Month 9], --function Month_func with monthNum='9'
       "view_policy_consolidated"."name" AS [@Month 10], --function Month_func with monthNum='10'
       "view_policy_consolidated"."name" AS [@Month 11], --function Month_func with monthNum='11'
       "view_policy_consolidated"."name" AS [@Month 12], --function Month_func with monthNum='12'
       "view_policy_consolidated"."name" AS [@Month 13], --function Month_func with monthNum='13'
       "prem_reqs_new"."est_req_prem" AS [Est. Req. Premium],
       "view_policy_consolidated"."name" AS [@Adj. Req. Premium], --function AdjReqPremium
       "prem_reqs_new"."premnumberofmonth" AS [# of Mos],
       "view_policy_consolidated"."name" AS [@Adj. Req. Premium], --function OverridePremium
       "prem_reqs_new"."calc_method" AS [Calculation Method],
       "prem_reqs_new"."est_req_prem_date" AS [Addl Prem will Cover COI Thru],
       "PREM_REQS_CAT_2"."amount_paid" AS [Most Recent Premium Payment],
       "PREM_REQS_CAT_2"."date_addl_prem_paid" AS [Date Paid],
       "PREM_REQS_CAT_2"."paid_by" AS [Paid By],
       "PREM_REQS_CAT_2"."date_carrier_confirmed_premium" AS [Date Carrier Confirmed Payment],
       "view_totalpremiumpaid_consolidated"."totalpremiumpaid" AS [Total Premiums Paid To Date],
       "view_premium_latest_by_source_date"."kbc_decision" AS [Owner Decision],
       "view_premium_latest_by_source_date"."kbc_distressed_as_of" AS [As Of],
       "policies"."category" AS [Category],
       "viewlatest_policy_flag_items"."flagged_for" AS [Flagged For],
       "viewlatest_policy_flag_items"."flag_removed" AS [Flag Removed],       
       "view_latest_rate_change_notification"."correspondence_type" AS [Corresp. Type],
       "view_latest_rate_change_notification"."date_recvd" AS [Date Rec'd],
       "view_latest_rate_change_notification"."effective_date" AS [Effective Date],
       "settlement_purchase"."final_list" AS [Final List],
       "service_ext"."voc_date" AS [VOC Date],
       "service_ext"."voc_lien_rec" AS [VOC Lien Status],
       "service_ext"."voc_past_contest" AS [VOC Contestability Status],
       "service_ext"."carrier_call_date" AS [Carrier Call Date],
       "service_ext"."carrier_lien_rec" AS [CC Lien Status],
       "service_ext"."carrier_past_contest" AS [CC Contestability Status],
       "service_ext"."sub_tracking_ssn_d" AS [SSN Check],
       "service_ext"."ssn_issue" AS [SSN Issue Date],
       "service_ext"."issues" AS [SSN Issue],
       "service_ext"."issue_resolved" AS [SSN Issue Resolved],
       "view_illustration_latest_all"."illustration_rec" AS [Illustration Date],
       "view_illustration_latest_all"."scenario_req" AS [Illustration Scenario],
       "view_policy_consolidated"."client" AS [Client],
       "opportunity_ext"."date_of_death" AS [Date of Death],
       "settlement_purchase"."uniqueid" AS [Client ID],
       "opportunity_ext"."ssn" AS [SSN],
       "gmbh"."gmbh_num" AS [M2 to NCB],
       "view_policy_consolidated"."category" AS [Category],
       "north_channel_audit"."a1" AS [Service Checklist Input],
       "north_channel_audit"."a2" AS [Service Checklist Reviewed],
       "north_channel_audit"."ms" AS [Service Checklist Sign-Off],
       "north_channel_audit"."msd" AS [Service Checklist Date],
       "view_coo_latest_confirmed"."new_owner_name" AS [Current Owner],
       "view_coo_latest_confirmed"."change_owner_conf_date" AS [COO Confirmed Date],
       "view_coo_latest_confirmed"."change_owner_rec_date" AS [COO Recorded Date],
       "prem_reqs_new"."illustrationdaterun" AS [If Illustration, Date Run],
       "prem_reqs_new"."mapsdaterun" AS [If MAPS, Date Run],
       "prem_reqs_new"."mapscoi" AS [COI],
       "prem_reqs_new"."analyst" AS [Analyst],
       "prem_reqs_new"."audited_by" AS [Reviewer],
       "policies"."previous_program" AS [Previous Program #],

       "policies"."policiesid",
       "category_1"."prem_reqs_newid",
       "prem_reqs_new"."monthly_ga",
       "prem_reqs_new"."annual_ga",
       "prem_reqs_new"."cv",
       "prem_reqs_new"."csv",
       "prem_reqs_new"."shaow_acct",
       "view_policy_performance_latest"."annualstatementdate",
       "prem_reqs_new"."coi_estimated",
       "prem_reqs_new"."override_premium",
       "prem_reqs_new"."adj_est_prem",
       "service_ext"."third_party_auth",
       "service_ext"."doesnotacceptthirdpa",
       "service_ext"."restrictedauth",
       "view_policy_client_blackstone"."endreason",
       "prem_reqs_new"."rop" AS [PRNROP]

FROM   (((((((((((( 
                           ((((( 
                      ( 
                       ( 
                        ((("sysdba"."medicalunderwriting" "MEDICALUNDERWRITING" 
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
                                  ON 
                     "policies"."policiesid" = "gmbh"."policiesid") 
                    LEFT OUTER JOIN "sysdba"."view_fortress_general" 
                                    "View_Fortress_General" 
                                 ON "policies"."policiesid" = 
                                    "view_fortress_general"."policiesid") 
                   LEFT OUTER JOIN 
                   "sysdba"."view_latest_rate_change_notification" 
                   "View_Latest_Rate_Change_Notification" 
                                ON 
       "policies"."policiesid" = 
       "view_latest_rate_change_notification"."policiesid") 
       LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" 
                   ON "policies"."policiesid" = "policies_ext"."policiesid") 
        LEFT OUTER JOIN "sysdba"."service_ext" "SERVICE_EXT" 
                     ON "policies"."policiesid" = "service_ext"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_illustration_latest_all" 
                       "View_Illustration_latest_all" 
                    ON "policies"."policiesid" = 
                       "view_illustration_latest_all"."policiesid") 
       LEFT OUTER JOIN "sysdba"."settlement_purchase" "SETTLEMENT_PURCHASE" 
                   ON "policies"."policiesid" = 
                      "settlement_purchase"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_coo_latest_confirmed" 
                        "View_COO_Latest_Confirmed" 
                     ON "policies"."policiesid" = 
                        "view_coo_latest_confirmed"."policiesid") 
       LEFT OUTER JOIN "sysdba"."north_channel_audit" "NORTH_CHANNEL_AUDIT" 
                    ON "policies"."policiesid" = 
                       "north_channel_audit"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_policy_client_current" 
                      "View_Policy_Client_Current" 
                   ON "policies"."policiesid" = 
                      "view_policy_client_current"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_premium_latest_by_source_date" 
                        "View_Premium_Latest_By_Source_Date" 
                     ON "policies"."policiesid" = 
                        "view_premium_latest_by_source_date"."policiesid") 
       LEFT OUTER JOIN "sysdba"."view_policy_client_blackstone" 
                       "View_Policy_client_Blackstone" 
                    ON "policies"."policiesid" = 
                       "view_policy_client_blackstone"."policiesid") 
       INNER JOIN "sysdba"."view_viva_premium_report_scope" 
                 "View_Viva_Premium_Report_scope" 
              ON "policies"."policiesid" = 
                 "view_viva_premium_report_scope"."policiesid") 
        LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                     ON "category_1"."prem_reqs_newid" = 
                        "prem_reqs_new"."prem_reqs_newid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_CAT_2" 
                    ON "category_2"."prem_reqs_newid" = 
                       "PREM_REQS_CAT_2"."prem_reqs_newid" 