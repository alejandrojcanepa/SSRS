SELECT "prem_reqs_new"."date_addl_prem_due", 
       "gmbh"."borrower", 
       "view_policy_consolidated"."policynumber", 
       "view_policy_consolidated"."client", 
       "prem_reqs_new"."override_premium", 
       "prem_reqs_new"."adj_est_prem", 
       "view_policy_consolidated"."insurancecompany", 
       "view_policy_consolidated"."name", 
       "view_carrier_address_2ndset"."bank", 
       "view_carrier_address_2ndset"."full_carrier_name", 
       "view_carrier_address_2ndset"."bank_account_num", 
       "view_carrier_address_2ndset"."bank_aba", 
       "view_policy_sei_account"."sei account", 
       "gmbh"."gmbh_num", 
       "gmbh"."sub", 
       "gmbh"."borrower2", 
       "gmbh"."borrower3", 
       "view_carrier_address_2ndset"."bank_city", 
       "view_carrier_address_2ndset"."bank_state", 
       "view_ncb_premium_report_scope"."enddate", 
       "view_policy_consolidated"."date_of_death" 
FROM   (((( 
        (("sysdba"."policies" "POLICIES" 
             LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" 
                          ON 
         "policies"."policiesid" = "category_1"."policiesid") 
            INNER JOIN "sysdba"."view_policy_consolidated" 
                       "View_Policy_Consolidated" 
                    ON "policies"."policiesid" = 
                       "view_policy_consolidated"."policiesid") 
           LEFT OUTER JOIN "sysdba"."gmbh" "GMBH" 
                        ON "policies"."policiesid" = "gmbh"."policiesid") 
          LEFT OUTER JOIN "sysdba"."view_carrier_address_2ndset" 
                          "View_Carrier_Address_2ndSet" 
                       ON "policies"."policiesid" = 
                          "view_carrier_address_2ndset"."policiesid") 
         LEFT OUTER JOIN "sysdba"."view_policy_sei_account" 
                         "View_Policy_SEI_Account" 
                      ON "policies"."policiesid" = 
                         "view_policy_sei_account"."policiesid") 
        INNER JOIN "sysdba"."view_ncb_premium_report_scope" 
                   "View_NCB_Premium_Report_scope" 
                ON "policies"."policiesid" = 
                   "view_ncb_premium_report_scope"."policiesid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                    ON "category_1"."prem_reqs_newid" = 
                       "prem_reqs_new"."prem_reqs_newid" 
WHERE  ( "prem_reqs_new"."date_addl_prem_due" >= 
                CONVERT(DATETIME, '2017-11-02 00:00:00', 
                  120) 
         AND "prem_reqs_new"."date_addl_prem_due" < 
             CONVERT(DATETIME, '2017-11-30 00:00:00', 
             120) ) 
       AND "view_policy_consolidated"."client" <> 'Centurion' 
       AND "view_ncb_premium_report_scope"."enddate" IS NULL 
       AND "view_policy_consolidated"."date_of_death" IS NULL 