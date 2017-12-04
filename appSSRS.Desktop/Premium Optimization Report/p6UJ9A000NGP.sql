SELECT
       "policies"."sub_fund_group" AS [Sub-Group], 
       "view_policy_consolidated"."name" AS [Case Name], 
       "policies"."insuredname" AS [Client Name], 
       "view_policy_consolidated"."insurancecompany" AS [Carrier], 
       "policies"."policynumber" AS [Policy #], 
       "view_policy_consolidated"."stateofissue" AS [State of Issue], 
       "policies"."deathbenefit" AS [Death Benefit], 
       "policies"."sub_fund_group" AS [@Current Death Benefit], --function CurrentDeathBenefit
       "policies"."sub_fund_group" AS [@ROP], --function ROP_func
       "policies_ext"."db_change" AS [Death Benefit Change], 
       "medicalunderwriting"."productname" AS [Product], 
       "policies"."sub_fund_group" AS [@VUL], --function VUL
       "policies_ext"."mer" AS [ME], 
       "policies_ext"."mer_type" AS [ME Type], 
       "policies_ext"."mer_age" AS [ME Age], 
       "policies"."sub_fund_group" AS [@Program Provider], --function ProgramProvider
       "view_policy_consolidated"."program" AS [Program #], --used in code as VPCProgram
       "view_policy_consolidated"."client" AS [Client], --used in code as VPCClient
       "view_policy_client_previous"."client" AS [Previous Client], 
       "policies"."premiumadvancedate" AS [Prem. Adv. Date], 
       "policies"."aniversarydate" AS [Anniv. Date], 
       "policies"."sub_fund_group" AS [@Annual Stmt Date], --function AnnualStmtDate
       "prem_reqs_new"."source_of_information_d" AS [Date Carrier Called], 
       "prem_reqs_new"."policy_status" AS [Policy Status], 
       "prem_reqs_new"."confirmed_lapse_date" AS [Confirmed Lapse Date], 
       "prem_reqs_new"."current_cash_value" AS [Current Cash Value], 
       "prem_reqs_new"."current_surrender_value" AS [Current Cash Surrender Value], 
       "prem_reqs_new"."last_coi" AS [Last COI ], 
       "policies"."sub_fund_group" AS [@Running Off], --function RunningOff
       "prem_reqs_new"."ga_charge" AS [Last GA Amt./Shadow COI], 
       "prem_reqs_new"."last_coi_date" AS [Date COI Taken], 
       "prem_reqs_new"."kbc_decision" AS [Owner Decision], 
       "prem_reqs_new"."kbc_distressed_as_of" AS [As Of], 
       "prem_reqs_new"."date_addl_prem_due" AS [Date Addl Prem. Due], 
       "prem_reqs_new"."est_req_prem" AS [Est. Req. Premium], 
       "policies"."sub_fund_group" AS [@Adj. Req. Premium], --function AdjReqPremium
       "prem_reqs_new"."premnumberofmonth" AS [# of Mos], 
       "policies"."sub_fund_group" AS [@Adj. Req. Premium], --function OverridePremium_func
       "prem_reqs_new"."calc_method" AS [Calculation Method], 
       "prem_reqs_new"."est_req_prem_date" AS [Addl Prem will Cover COI Thru], 
       "PREM_REQS_CAT_2"."amount_paid" AS [Most Recent Premium Payment], 
       "PREM_REQS_CAT_2"."date_addl_prem_paid" AS [Date Paid], 
       "PREM_REQS_CAT_2"."paid_by" AS [Paid By], 
       "PREM_REQS_CAT_2"."date_carrier_confirmed_premium" AS [Date Carrier Confirmed Payment], 
       "policies"."sub_fund_group" AS [@Rate Increase], --function RateIncrease
       "viewlatest_misc_corresp_rate_increase"."effective_date" AS [Effective Date], 
       "opportunity_ext"."date_of_death" AS [Date of Death],        
       "view_totalpremiumpaid_consolidated"."totalpremiumpaid" AS [TotalPremiumPaid], 
       "viewlatest_policy_flag_items"."flagged_for" AS [Flagged For], 
       "viewlatest_policy_flag_items"."flag_removed" AS [Flag Removed],
       "view_latest_rate_change_notification"."correspondence_type" AS [Coresp. Type], 
       "view_latest_rate_change_notification"."date_recvd" AS [Date Rec'd], 
       "view_latest_rate_change_notification"."effective_date" AS [Effective Date], 
       "service_ext"."sub_tracking_ssn_d" AS [SSN Check], 
       "service_ext"."ssn_issue" AS [SSN Issue Date], 
       "service_ext"."issues" AS [SSN Issue], 
       "service_ext"."issue_resolved" AS [SSN Issue Resolved], 
       "prem_reqs_new"."analyst" AS [Analyst], 
       "prem_reqs_new"."audited_by" AS [Reviewer], 
       "view_fortress_general"."current year" AS [Current Policy Year], 
       "view_fortress_general"."current prem expense" AS [Current Year Policy Prem Exp], 
       "view_fortress_general"."est_premium_expense" AS [Current Year Est Prem Exp], 
       "view_fortress_general"."next prem expense" AS [Next Year Policy Prem Exp], 
       "view_fortress_general"."next est prem expense" AS [Next Year Est Prem Expense], 
       "opportunity_ext"."dob" AS [DOB],        
       "opportunity_ext"."ssn" AS [SSN], 

       "policies"."policiesid", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "prem_reqs_new"."shaow_acct", 
       "prem_reqs_new"."coi_estimated", 
       "view_policy_consolidated"."provider" AS [VPCProvider], 
       "view_policy_performance_latest"."annualstatementdate", 
       "prem_reqs_new"."override_premium", 
       "viewlatest_misc_corresp_rate_increase"."rate_increase", 
       "gmbh"."coll_rel_agrmnt_date", 
       "prem_reqs_new"."adj_est_prem", 
       "prem_reqs_new"."rop", 
       "prem_reqs_new"."total_death_benefit", 
       "policies_ext"."partial_surrender_amount", 
       "policies_ext"."product_carrier_vul", 
       "view_policy_consolidated"."program_name"
       
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
WHERE  ( "view_policy_consolidated"."program" = '300' 
          OR "view_policy_consolidated"."program" = '301' 
          OR "view_policy_consolidated"."program" = '302' ) 