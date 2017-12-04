SELECT
       "view_policy_consolidated"."name" AS [Insured Name], 
       "opportunity_ext"."age" AS [Client Age], 
       "view_policy_consolidated"."name" AS [@Policy Age], --Function PolicyAge
       "policies_ext"."mer" AS [ME], 
       "policies_ext"."mer_type" AS [ME Type], 
       "policies_ext"."mer_age" AS [ME Age], 
       "view_policy_consolidated"."name" AS [@Separate Request], --Function SeparateRequest
       "view_policy_consolidated"."insurancecompany" AS [Carrier], 
       "policies"."policynumber" AS [Policy No.], 
       "policies"."deathbenefit" AS [Death Benefit], 
       "view_policy_consolidated"."name" AS [@Current Death Benefit], --Function ROP_func
       "view_policy_consolidated"."name" AS [@ROP], --Function ROPDB
       "view_policy_consolidated"."name" AS [@Death Benefit Change], --Function DBChange
       "medicalunderwriting"."productname" AS [Product], 
       "view_policy_consolidated"."provider" AS [VPCProvider],
       "view_policy_consolidated"."program" AS [VPCProgram], 
       "view_policy_consolidated"."client" AS [Current Client], 
       "gmbh"."gmbh_num" AS [GMBH #], 
       "view_policy_consolidated"."name" AS [@Owner/Trustee], --Function Owner_Trustee
       "viewlatest_coo_by_number"."change_owner_sent_date" AS [COO Sent Date], 
       "policies"."aniversarydate" AS [Anniv.], 
       "policies"."premiumadvancedate" AS [Prem. Adv. Date], 
       "view_policy_product_maxdate"."max_anni_review_date" AS [Most Recent Anniv. Review Date], 
       "prem_reqs_new"."last_coi_date" AS [Date of Last COI], 
       "view_policy_consolidated"."name" AS [@Aging in Month], --Function AgingInMonth
       "prem_reqs_new"."date_addl_prem_due" AS [Next Add'l Prem Due], '
       "prem_reqs_new"."calc_method" AS [Calculation Method], 
       "policies_ext"."product_carrier_take_coi_age" AS [COI To Age], 
       "prem_reqs_new_cat_2"."date_addl_prem_paid" AS [Most Recent Prem Paid Date], 
       "prem_reqs_new_cat_2"."date_carrier_confirmed_premium" AS [Date Carrier Confirmed Prem. Payment], 
       "view_policy_consolidated"."name" AS [@Policy Runs off], --Function PolicyRunssOff
       "view_policy_performance_latest"."annualstatementdate" AS [Ann. Stmt. Date (Policy Perf.)], --used in the code as annualstatementdate parameter
       "view_policy_consolidated"."name" AS [@Annual Stmt. Age], --Function Annual_Stmt_Age
       "view_policy_consolidated"."name" AS [Type of Request], --This field should be always populated with "Annual Statement" value for all listed records
       "view_policy_value_stmt_req_latest_annual_stmt"."most_recent_submitted_carrier" as [Date Submitted to Carrier], 
       "view_policy_value_stmt_req_latest_annual_stmt"."request_sent_by" AS [Request Made By], 
       "view_policy_value_stmt_req_latest_annual_stmt"."date_received" AS [Date Received],
       "view_policy_performance_latest"."filetime" AS [Add Time],
       "view_policy_consolidated"."name" AS [Type of Request], --This field should be always populated with "Policy Values" value for all listed records
       "view_policy_value_stmt_req_latest_policy_values"."most_recent_submitted_carrier" as [Date Submitted to Carrier], 
       "view_policy_value_stmt_req_latest_policy_values"."request_sent_by" AS [Request Made By],
       "view_policy_value_stmt_req_latest_policy_values"."date_received" AS [Date Received],
       "view_policy_value_stmt_req_latest_policy_values"."complete_flag" AS [Request Complete], 
       "view_policy_consolidated"."name" AS [@Policy Values Age], --Function PolicyValuesAge
       "view_policy_consolidated"."name" AS [@Illustration Re-request], --Function IllustrationReRequest
       "view_illustration_latest_scenario1_service"."rerequest" AS [Reason], 
       "view_illustration_latest_scenario1_service"."request_made_by" AS [Level Illustration Request Made By], 
       "view_illustration_latest_scenario1_service"."request_sent_via" AS [Level Illustration Request Sent Via], 
       "view_illustration_latest_scenario1_service"."request_made" AS [Date Level  Illustration  submitted to Carrier],
       "view_illustration_latest_scenario1_service"."fpdate" AS [F/U Date], 
       "view_illustration_latest_scenario1_service"."reason" AS [Reason], 
       "view_illustration_latest_scenario1_service"."illustration_rec" AS [Level Illustration Run Date], 
       "view_illustration_latest_scenario1_service"."illustration_issue" AS [Level Illustration Issue], 
       "view_illustration_latest_scenario1_service"."filetime" AS [Add Time], 
       "view_illustration_latest_scenario1"."age_of_illustration" AS [Illustration Age], 
       "policies_ext"."product_carrier_will_run_minpa" AS [Carrier Will Run Min-Pay Illustration], 
       "view_illustration_latest_select_scenarios_2"."illustration run date" AS [Min Pay Illustration Run Date], 
       "view_policy_consolidated"."name" AS [@Min Pay Illustration Request Open], --Function MinPayIllustrationRequestOpen
       "view_illustration_latest_select_scenarios_2"."illustration_issue" AS [Min Pay Illustration Issue], 
       "view_illustration_latest_select_scenarios_2"."min pay illustration age" AS [Min Pay Illustration Age], 
       "view_illustration_latest_other"."illustration run date" AS [Other Illustration Run Date], 
       "view_illustration_latest_other"."illustration open" AS [Other Illustration Request Open],
       "view_illustration_latest_other"."illustration_issue" AS [Other Illustration Issue], 
       "view_illustration_latest_other"."other illustration age" AS [Other Illustration Age],
       "opportunity_ext"."date_of_death" AS [Date of Death], 
       "view_premium_latest_by_source_date"."kbc_decision" AS [Owner Decision], 
       "view_policy_value_stmt_req_latest_voc"."request_type" AS [Request Type], 
       "view_policy_value_stmt_req_latest_voc"."date_request_made" AS [Date submitted], 
       "view_policy_value_stmt_req_latest_voc"."request_sent_to" AS [Submitted To], 
       "view_policy_value_stmt_req_latest_voc"."date_submitted_carrier" AS [Date Submitted], 
       "view_policy_value_stmt_req_latest_voc"."request_sent_by" AS [Request Made By], 
       "view_policy_value_stmt_req_latest_voc"."most_recent_received" AS [Date Received], 
       "view_policy_value_stmt_req_latest_voc"."complete_flag" AS [Request Complete], 
       "gmbh"."coll_rel_agrmnt_date" AS [Collateral Rel Agmt Date], 
       "viewlatest_rate_increase_notification"."correspondence_type" AS [Correspondence Type], 
       "view_latest_rate_change_notification"."date_recvd" AS [Date Rec'd], 
       "view_latest_rate_change_notification"."effective_date" AS [Effective Date], 
       "view_policy_consolidated"."name" AS [@Rate Increase], --Function RateIncrease
       "opportunity_ext"."gender" AS [Gender], 
       "opportunity_ext"."dob" AS [Date of Birth], 
       "policies"."issueage" AS [Issue Age], 
       "service_ext"."sub_tracking_ssn_d" AS [SSN Check], 
       "service_ext"."ssn_issue" AS [SSN Issue], 
       "view_policy_consolidated"."name" AS [@SSN2], --Function SSN2
       "view_policy_mpicns"."mpic_provider" AS [MPIC Insurer], 
       "view_policy_mpicns"."mpic_effectivedate" AS [MPIC Effective Date], 
       "policies"."stateofissue" AS [State of Issue], 
       "policies_ext"."policy_type" AS [Policy Type], 
       "policies_ext"."product_type" AS [Product Type], 
       "policies_ext"."death_benefit_type" AS [Death Benefit Type],  
            
       "loans"."note_purchaser", 
       "policies"."endorsee", 
       "policies"."policiesid", 
       "view_policy_trustinfo"."ilittrustee", 
       "view_policy_consolidated"."loanagreementdate", 
       "view_policy_value_stmt_req_latest_policy_values"."most_recent_received" AS [VPVSRLPVMost_recent_received], 
       "option_exercise_notice"."strike_price_paid", 
       "option_exercise_notice"."adj_strike_price_check", 
       "option_exercise_notice"."original_strike_price_check", 
       "view_illustration_latest_scenario1_service"."rerequest_check", 
       "loans"."ltr_22_month_response", 
       "prem_reqs_new"."confirmed_lapse_date", 
       "viewlatest_rate_increase_notification"."rate_increase" AS [VRINRate_increase], 
       "view_coo_latest_confirmed"."new_owner_name", 
       "view_policy_lonsdale_status_latest"."status" AS [VPLSLStatus], 
       "loans"."payoff_date_service", 
       "view_best_purchaser_offer_accepted"."purchaser", 
       "view_best_purchaser_offer_accepted"."provider" AS [VBPOAProvider], 
       "policies"."owner", 
       "policies"."status", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "prem_reqs_new"."shaow_acct", 
       "prem_reqs_new"."coi_estimated", 
	     "view_latest_rate_change_notification"."correspondence_type" AS [VLRCNCorrespondence_type], 
	     "view_illustration_latest_select_scenarios"."date request sent to carrier" AS [VILSSDate_request_sent_to_carrier], 
	     "view_illustration_latest_select_scenarios"."illustration run date" AS [VILSSIllustration_run_date], 
	     "opportunity_ext"."ssn", 
  	   "policies_ext"."mer_need_sep_req", 
	     "prem_reqs_new"."rop", 
	     "prem_reqs_new"."total_death_benefit", 
	     "policies_ext"."db_change", 
  	   "policies_ext"."partial_surrender_amount", 
	     "policies"."nullnumberforcrystal"
	   
	   FROM ((((((((((((((((((( (( ( ( ( ( (( ((("sysdba"."medicalunderwriting" "MEDICALUNDERWRITING" INNER JOIN "sysdba"."policies" "POLICIES" ON "medicalunderwriting"."medicalunderwritingid" = "policies"."medicalunderwritingid") INNER JOIN "sysdba"."opportunity_ext" "OPPORTUNITY_EXT" ON "medicalunderwriting"."opportunityid" = "opportunity_ext"."opportunityid") LEFT OUTER JOIN "sysdba"."loans" "LOANS" ON "policies"."policiesid" = "loans"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_consolidated" "View_Policy_Consolidated" ON "policies"."policiesid" = "view_policy_consolidated"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_trustinfo" "View_Policy_TrustInfo" ON "policies"."policiesid" = "view_policy_trustinfo"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_value_stmt_req_latest_annual_stmt" "View_Policy_Value_Stmt_Req_Latest_Annual_Stmt" ON "policies"."policiesid" = "view_policy_value_stmt_req_latest_annual_stmt"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_value_stmt_req_latest_policy_values" "View_Policy_Value_Stmt_Req_Latest_Policy_Values" ON "policies"."policiesid" = "view_policy_value_stmt_req_latest_policy_values"."policiesid") LEFT OUTER JOIN "sysdba"."view_illustration_latest_scenario1_service" "View_Illustration_latest_scenario1_service" ON "policies"."policiesid" = "view_illustration_latest_scenario1_service"."policiesid") LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" ON "policies"."policiesid" = "category_1"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_performance_latest" "View_Policy_Performance_Latest" ON "policies"."policiesid" = "view_policy_performance_latest"."policiesid") LEFT OUTER JOIN "sysdba"."view_premium_latest_by_source_date" "View_Premium_Latest_By_Source_Date" ON "policies"."policiesid" = "view_premium_latest_by_source_date"."policiesid") LEFT OUTER JOIN "sysdba"."option_exercise_notice" "OPTION_EXERCISE_NOTICE" ON "policies"."policiesid" = "option_exercise_notice"."policiesid") LEFT OUTER JOIN "sysdba"."view_illustration_latest_scenario1" "VIEW_ILLUSTRATION_LATEST_SCENARIO1" ON "policies"."policiesid" = "view_illustration_latest_scenario1"."policiesid") LEFT OUTER JOIN "sysdba"."viewlatest_rate_increase_notification" "viewLatest_Rate_Increase_Notification" ON "policies"."policiesid" = "viewlatest_rate_increase_notification"."policiesid") LEFT OUTER JOIN "sysdba"."view_coo_latest_confirmed" "View_COO_Latest_Confirmed" ON "policies"."policiesid" = "view_coo_latest_confirmed"."policiesid") LEFT OUTER JOIN "sysdba"."viewlatest_coo_by_number" "viewLatest_COO_By_Number" ON "policies"."policiesid" = "viewlatest_coo_by_number"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_value_stmt_req_latest_voc" "View_Policy_Value_Stmt_Req_Latest_VOC" ON "policies"."policiesid" = "view_policy_value_stmt_req_latest_voc"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_lonsdale_status_latest" "View_Policy_Lonsdale_Status_Latest" ON "policies"."policiesid" = "view_policy_lonsdale_status_latest"."policiesid") LEFT OUTER JOIN "sysdba"."view_best_purchaser_offer_accepted" "VIEW_BEST_PURCHASER_OFFER_ACCEPTED" ON "policies"."policiesid" = "view_best_purchaser_offer_accepted"."policiesid") LEFT OUTER JOIN "sysdba"."gmbh" "GMBH" ON "policies"."policiesid" = "gmbh"."policiesid") LEFT OUTER JOIN "sysdba"."category_2" "CATEGORY_2" ON "policies"."policiesid" = "category_2"."policiesid") LEFT OUTER JOIN "sysdba"."view_latest_rate_change_notification" "View_Latest_Rate_Change_Notification" ON "policies"."policiesid" = "view_latest_rate_change_notification"."policiesid") LEFT OUTER JOIN "sysdba"."service_ext" "SERVICE_EXT" ON "policies"."policiesid" = "service_ext"."policiesid") LEFT OUTER JOIN "sysdba"."view_illustration_latest_select_scenarios" "VIEW_ILLUSTRATION_LATEST_SELECT_SCENARIOS" ON "policies"."policiesid" = "view_illustration_latest_select_scenarios"."policiesid") LEFT OUTER JOIN "sysdba"."view_illustration_latest_select_scenarios_2" "VIEW_ILLUSTRATION_LATEST_SELECT_SCENARIOS_2" ON "policies"."policiesid" = "view_illustration_latest_select_scenarios_2"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_mpicns" "View_Policy_MPICNS" ON "policies"."policiesid" = "view_policy_mpicns"."policiesid") LEFT OUTER JOIN "sysdba"."view_policy_product_maxdate" "View_Policy_Product_MaxDate" ON "policies"."policiesid" = "view_policy_product_maxdate"."policiesid") LEFT OUTER JOIN "sysdba"."policies_ext" "POLICIES_EXT" ON "policies"."policiesid" = "policies_ext"."policiesid") LEFT OUTER JOIN "sysdba"."view_illustration_latest_other" "VIEW_ILLUSTRATION_LATEST_Other" ON "policies"."policiesid" = "view_illustration_latest_other"."policiesid") LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW_CAT_2" ON "category_2"."prem_reqs_newid" = "PREM_REQS_NEW_CAT_2"."prem_reqs_newid") LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" ON "category_1"."prem_reqs_newid" = "prem_reqs_new"."prem_reqs_newid" WHERE (
  ( 
    "view_policy_consolidated"."program" = '108' 
    OR 
    "view_policy_consolidated"."program" = '110' 
    OR 
    "view_policy_consolidated"."program" = '112' 
    OR 
    "view_policy_consolidated"."program" = '120' 
    OR 
    "view_policy_consolidated"."program" = '201' 
    OR 
    "view_policy_consolidated"."program" = '212' 
    OR 
    "view_policy_consolidated"."program" = '221' 
    OR 
    "view_policy_consolidated"."program" = '223' 
    OR 
    "view_policy_consolidated"."program" = '224' 
    OR 
    "view_policy_consolidated"."program" = '225' 
    OR 
    "view_policy_consolidated"."program" = '250' 
    OR 
    "view_policy_consolidated"."program" = '260' 
    OR 
    "view_policy_consolidated"."program" = '270' 
    OR 
    "view_policy_consolidated"."program" = '280' 
    OR 
    "view_policy_consolidated"."program" = '63' 
    OR 
    "view_policy_consolidated"."program" = '65' 
    OR 
    "view_policy_consolidated"."program" = '66' 
    OR 
    "view_policy_consolidated"."program" = '69' 
    OR 
    "view_policy_consolidated"."program" = '74' 
    OR 
    "view_policy_consolidated"."program" = '75' 
    OR 
    "view_policy_consolidated"."program" = '76' 
    OR 
    "view_policy_consolidated"."program" = '78' 
    OR 
    "view_policy_consolidated"."program" = '0' 
    OR 
    "view_policy_consolidated"."program" = '0-H' 
    OR 
    "view_policy_consolidated"."program" = '1' 
    OR 
    "view_policy_consolidated"."program" = '10' 
    OR 
    "view_policy_consolidated"."program" = '100' 
    OR 
    "view_policy_consolidated"."program" = '101' 
    OR 
    "view_policy_consolidated"."program" = '102' 
    OR 
    "view_policy_consolidated"."program" = '106' 
    OR 
    "view_policy_consolidated"."program" = '107' 
    OR 
    "view_policy_consolidated"."program" = '11' 
    OR 
    "view_policy_consolidated"."program" = '13' 
    OR 
    "view_policy_consolidated"."program" = '14' 
    OR 
    "view_policy_consolidated"."program" = '15' 
    OR 
    "view_policy_consolidated"."program" = '16' 
    OR 
    "view_policy_consolidated"."program" = '17' 
    OR 
    "view_policy_consolidated"."program" = '19' 
    OR 
    "view_policy_consolidated"."program" = '2' 
    OR 
    "view_policy_consolidated"."program" = '20' 
    OR 
    "view_policy_consolidated"."program" = '21' 
    OR 
    "view_policy_consolidated"."program" = '24' 
    OR 
    "view_policy_consolidated"."program" = '25' 
    OR 
    "view_policy_consolidated"."program" = '3' 
    OR 
    "view_policy_consolidated"."program" = '4' 
    OR 
    "view_policy_consolidated"."program" = '50' 
    OR 
    "view_policy_consolidated"."program" = '51' 
    OR 
    "view_policy_consolidated"."program" = '53' 
    OR 
    "view_policy_consolidated"."program" = '57' 
    OR 
    "view_policy_consolidated"."program" = '58' 
    OR 
    "view_policy_consolidated"."program" = '59' 
    OR 
    "view_policy_consolidated"."program" = '6' 
    OR 
    "view_policy_consolidated"."program" = '7' 
    OR 
    "view_policy_consolidated"."program" = '8' 
    OR 
    "view_policy_consolidated"."program" = '9' 
  ) 
  OR 
  "policies"."owner" = 'EFG' 
  AND 
  "policies"."status" = 'Sold' 
  OR 
  "view_policy_consolidated"."client" = 'NLSS (Back-Up Service)' 
)