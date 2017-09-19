SELECT "view_policy_consolidated"."name", 
       "opportunity_ext"."age", 
       "policies_ext"."mer", 
       "policies_ext"."mer_type", 
       "policies_ext"."mer_age", 
       "view_policy_consolidated"."insurancecompany", 
       "policies"."policynumber", 
       "policies"."deathbenefit", 
       "medicalunderwriting"."productname", 
       "view_policy_consolidated"."client", 
       "gmbh"."gmbh_num", 
       "viewlatest_coo_by_number"."change_owner_sent_date", 
       "policies"."aniversarydate", 
       "policies"."premiumadvancedate", 
       "view_policy_product_maxdate"."max_anni_review_date", 
       "prem_reqs_new"."last_coi_date", 
       "prem_reqs_new"."date_addl_prem_due", 
       "prem_reqs_new"."calc_method", 
       "policies_ext"."product_carrier_take_coi_age", 
       "prem_reqs_new_cat_2"."date_addl_prem_paid", 
       "prem_reqs_new_cat_2"."date_carrier_confirmed_premium", 
       "view_policy_performance_latest"."annualstatementdate", 
       "view_policy_value_stmt_req_latest_annual_stmt"."request_sent_by" as "view_policy_value_stmt_req_latest_annual_stmt.request_sent_by", 
       "view_policy_value_stmt_req_latest_annual_stmt"."date_received" as "view_policy_value_stmt_req_latest_annual_stmt.date_received", 
       "view_policy_value_stmt_req_latest_policy_values"."request_sent_by" as "view_policy_value_stmt_req_latest_policy_values.request_sent_by", 
       "view_policy_value_stmt_req_latest_policy_values"."date_received" as "view_policy_value_stmt_req_latest_policy_values.date_received", 
       "view_illustration_latest_scenario1_service"."rerequest", 
       "view_illustration_latest_scenario1_service"."request_made_by", 
       "view_illustration_latest_scenario1_service"."request_sent_via", 
       "view_illustration_latest_scenario1_service"."fpdate", 
       "view_illustration_latest_scenario1_service"."reason", 
       "view_illustration_latest_scenario1_service"."illustration_rec", 
       "view_illustration_latest_scenario1_service"."illustration_issue" as "view_illustration_latest_scenario1_service.illustration_issue", 
       "view_illustration_latest_scenario1_service"."filetime" as "view_illustration_latest_scenario1_service.filetime", 
       "policies_ext"."product_carrier_will_run_minpa", 
       "view_illustration_latest_select_scenarios_2"."illustration run date" as "view_illustration_latest_select_scenarios_2_illustration_run_date", 
       "view_illustration_latest_select_scenarios_2"."illustration_issue" as "view_illustration_latest_select_scenarios_2.illustration_issue", 
       "view_illustration_latest_select_scenarios_2"."min pay illustration age", 
       "view_illustration_latest_other"."illustration run date" as "view_illustration_latest_other_illustration_run_date", 
       "view_illustration_latest_other"."illustration_issue" as "view_illustration_latest_other.illustration_issue", 
       "view_illustration_latest_other"."other illustration age", 
       "opportunity_ext"."date_of_death", 
       "view_premium_latest_by_source_date"."kbc_decision", 
       "view_policy_value_stmt_req_latest_voc"."date_request_made", 
       "view_policy_value_stmt_req_latest_voc"."request_sent_to", 
       "view_policy_value_stmt_req_latest_voc"."date_submitted_carrier", 
       "view_policy_value_stmt_req_latest_voc"."request_sent_by" as "view_policy_value_stmt_req_latest_voc.request_sent_by", 
       "view_policy_value_stmt_req_latest_voc"."most_recent_received" as "view_policy_value_stmt_req_latest_voc_most_recent_received", 
       "view_policy_value_stmt_req_latest_voc"."complete_flag" as "view_policy_value_stmt_req_latest_voc.complete_flag", 
       "gmbh"."coll_rel_agrmnt_date", 
       "viewlatest_rate_increase_notification"."correspondence_type" as "viewlatest_rate_increase_notification.correspondence_type", 
       "view_latest_rate_change_notification"."date_recvd", 
       "view_latest_rate_change_notification"."effective_date", 
       "opportunity_ext"."gender", 
       "opportunity_ext"."dob", 
       "policies"."issueage", 
       "service_ext"."sub_tracking_ssn_d", 
       "service_ext"."ssn_issue", 
       "view_policy_mpicns"."mpic_provider", 
       "view_policy_mpicns"."mpic_effectivedate", 
       "policies"."stateofissue", 
       "policies_ext"."policy_type", 
       "policies_ext"."product_type", 
       "policies_ext"."death_benefit_type",
       
       "loans"."note_purchaser", 
       "policies"."endorsee", 
       "policies"."policiesid", 
       "view_policy_consolidated"."program", 
       "view_policy_trustinfo"."ilittrustee", 
       "view_policy_consolidated"."loanagreementdate", 
       "view_policy_value_stmt_req_latest_policy_values"."complete_flag" as "view_policy_value_stmt_req_latest_policy_values.complete_flag", 
       "view_illustration_latest_scenario1_service"."request_made", 
       "view_policy_value_stmt_req_latest_policy_values"."most_recent_received" as "view_policy_value_stmt_req_latest_policy_values_most_recent_received", 
       "option_exercise_notice"."strike_price_paid", 
       "option_exercise_notice"."adj_strike_price_check", 
       "option_exercise_notice"."original_strike_price_check", 
       "view_illustration_latest_scenario1_service"."rerequest_check", 
       "view_illustration_latest_scenario1"."age_of_illustration", 
       "loans"."ltr_22_month_response", 
       "prem_reqs_new"."confirmed_lapse_date", 
       "viewlatest_rate_increase_notification"."rate_increase", 
       "view_coo_latest_confirmed"."new_owner_name", 
       "view_policy_value_stmt_req_latest_voc"."request_type", 
       "view_policy_lonsdale_status_latest"."status" as "view_policy_lonsdale_status_latest.status", 
       "loans"."payoff_date_service", 
       "view_best_purchaser_offer_accepted"."purchaser", 
       "view_best_purchaser_offer_accepted"."provider" as "VBPOAProvider", 
       "policies"."owner", 
       "policies"."status" as "policies.status", 
       "prem_reqs_new"."cv", 
       "prem_reqs_new"."csv", 
       "prem_reqs_new"."monthly_ga", 
       "prem_reqs_new"."annual_ga", 
       "prem_reqs_new"."shaow_acct", 
       "prem_reqs_new"."coi_estimated", 
	   "view_policy_value_stmt_req_latest_annual_stmt"."most_recent_submitted_carrier" as "view_policy_value_stmt_req_latest_annual_stmt.most_recent_submitted_carrier", 
	   "view_policy_value_stmt_req_latest_policy_values"."most_recent_submitted_carrier" as "view_policy_value_stmt_req_latest_policy_values.most_recent_submitted_carrier", 
	   "view_policy_performance_latest"."filetime" as "view_policy_performance_latest.filetime", 
	   "view_latest_rate_change_notification"."correspondence_type" as "view_latest_rate_change_notification.correspondence_type", 
	   "view_illustration_latest_select_scenarios"."date request sent to carrier" as "date_request_sent_to_carrier", 
	   "view_illustration_latest_select_scenarios"."illustration run date" as "view_illustration_latest_select_scenarios_illustration_run_date", 
	   "opportunity_ext"."ssn", 
	   "policies_ext"."mer_need_sep_req", 
	   "prem_reqs_new"."rop", 
	   "prem_reqs_new"."total_death_benefit", 
	   "policies_ext"."db_change", 
	   "policies_ext"."partial_surrender_amount", 
	   "policies"."nullnumberforcrystal", 
	   "view_illustration_latest_other"."illustration open",
	   "view_policy_consolidated"."provider" as "VPCProvider"

	   
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