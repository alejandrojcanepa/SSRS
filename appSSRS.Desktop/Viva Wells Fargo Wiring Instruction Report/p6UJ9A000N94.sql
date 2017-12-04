SELECT
       [@Pay Date], --function PayDate
       "view_policy_consolidated"."policiesid" AS [@Amount], --function Amount
       [@Client ID], --function ClientID
       "view_policy_consolidated"."insurancecompany" AS [Carrier], 
       "view_policy_consolidated"."policynumber" AS [AssetID], 
       "view_policy_consolidated"."policiesid" AS [@SEI Account], --function SEIAccount
       "view_policy_consolidated"."name" AS [Insured Name], 
       "view_policy_consolidated"."policiesid" AS [Disbursment Type], --This field seems to be always populated with ""Wire"" value for all listed records
       "view_carrier_address_2ndset"."bank" AS [Bank Check Payable Name], 
       "view_carrier_address_2ndset"."full_carrier_name" AS [Account Name], 
       "view_carrier_address_2ndset"."bank_account_num" AS [Account Number], 
       "view_carrier_address_2ndset"."bank_aba" AS [ABA Number], 
       [@Check Address], --function CheckAddress
       [@Check City, State, ZipCode], --function CheckCity_State_ZipCode
       "view_policy_consolidated"."policiesid" AS [@Payment Type], --This field seems to be always populated with ""Premium"" value for all listed records
       "prem_reqs_new"."date_addl_prem_due" AS [Date Addl Premium Due],

       "view_policy_consolidated"."policiesid",
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
        INNER JOIN "sysdba"."view_coo_latest_confirmed" 
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
       AND "view_coo_latest_confirmed"."new_owner_name" LIKE '%Wells Fargo%' 
       AND "view_policy_consolidated"."client" = 'Viva (Blackstone)' 