SELECT
       "view_policy_consolidated"."name" AS [Account], --This field seems to be always populated with ""108302-001"" value for all listed records
       "view_policy_consolidated"."name" AS [@Amount], --Function Amount
       "view_policy_consolidated"."name" AS [Disb Code], --This field seems to be always populated with ""817"" value for all listed records
       "view_carrier_address_2ndset"."full_carrier_name" As [Paid To], 
       "view_carrier_address_2ndset"."bank_aba" AS [Receiver ABA], 
       "view_policy_consolidated"."name" AS [Beneficiary ID Code], --This field seems to be always populated with ""D"" value for all listed records
       "view_carrier_address_2ndset"."bank_account_num" AS [Beneficiary ID], 
       "view_carrier_address_2ndset"."full_carrier_name" As [Beneficiary Name], 
       "view_carrier_address_2ndset"."bank" AS [Beneficiary Address 1], 
       "view_carrier_address_2ndset"."bank_city" AS [Beneficiary Address 2], 
       "view_carrier_address_2ndset"."bank_state" AS [Beneficiary Address 3], 
       "view_policy_consolidated"."insurancecompany" AS [OBI 1], 
       "view_policy_consolidated"."name" AS [OBI 2], 
       "view_policy_consolidated"."policynumber" AS [OBI 3], 
       "view_policy_consolidated"."name" AS [OBI 4], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."insurancecompany" AS [Explanation 1], 
       "view_policy_consolidated"."name" AS [Explanation 2], 
       "view_policy_consolidated"."policynumber" AS [Explanation 3], 
       "view_policy_consolidated"."name" AS [Explanation 4], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK ID Code], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK ID], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK Name], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK Address 1], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK Address 2], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [BBK Address 3], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [IBK ID Code], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [IBK ID], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [IBK Address 1], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [IBK Address 2], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [IBK Address 3], --This field seems to be always populated with """" value for all listed records
       "view_policy_consolidated"."name" AS [Paid For], --This field seems to be always populated with """" value for all listed records

       "prem_reqs_new"."date_addl_prem_due", 
       "view_policy_consolidated"."client", 
       "prem_reqs_new"."override_premium", 
       "prem_reqs_new"."adj_est_prem", 
       "view_coo_latest_confirmed"."new_owner_name" 
       
FROM   ((("sysdba"."view_policy_consolidated" "View_Policy_Consolidated" 
          LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" 
                       ON "view_policy_consolidated"."policiesid" = 
                          "category_1"."policiesid") 
         LEFT OUTER JOIN "sysdba"."view_carrier_address_2ndset" 
                         "View_Carrier_Address_2ndSet" 
                      ON "view_policy_consolidated"."policiesid" = 
                         "view_carrier_address_2ndset"."policiesid") 
        LEFT OUTER JOIN "sysdba"."view_coo_latest_confirmed" 
                        "View_COO_Latest_Confirmed" 
                     ON "view_policy_consolidated"."policiesid" = 
                        "view_coo_latest_confirmed"."policiesid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                    ON "category_1"."prem_reqs_newid" = 
                       "prem_reqs_new"."prem_reqs_newid" 
WHERE  ( "prem_reqs_new"."date_addl_prem_due" >= 
                CONVERT(DATETIME, '2017-11-02 00:00:00', 
                  120) 
         AND "prem_reqs_new"."date_addl_prem_due" < 
             CONVERT(DATETIME, '2017-11-30 00:00:00', 
             120) ) 
       AND "view_policy_consolidated"."client" = 'Viva (Blackstone)' 
       AND "view_coo_latest_confirmed"."new_owner_name" LIKE 
           '%Wilmington Trust%' 