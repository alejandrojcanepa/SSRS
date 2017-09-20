SELECT 
"loans"."note_purchaser", 
"policies"."endorsee", 
"policies"."policiesid", 
"view_policy_consolidated"."program", 
"view_policy_consolidated"."provider" as "VPCProvider", 
"opportunity_ext"."date_of_death", 
"view_premium_latest_by_source_date"."kbc_decision", 
"option_exercise_notice"."strike_price_paid", 
"option_exercise_notice"."adj_strike_price_check", 
"option_exercise_notice"."original_strike_price_check", 
"loans"."ltr_22_month_response", 
"prem_reqs_new"."confirmed_lapse_date", 
"view_policy_lonsdale_status_latest"."status", 
"loans"."payoff_date_service", 
"view_best_purchaser_offer_accepted"."purchaser", 
"view_best_purchaser_offer_accepted"."provider" as "VBPOAProvider", 
"view_3rd_party_authorization"."insured name", 
"view_3rd_party_authorization"."carrier", 
"view_3rd_party_authorization"."policy number", 
"view_3rd_party_authorization"."death benefit", 
"view_3rd_party_authorization"."program #" as "program_numeral", 
"view_3rd_party_authorization"."category", 
"view_3rd_party_authorization"."policy owning trust", 
"view_3rd_party_authorization"."admin trustee", 
"view_3rd_party_authorization"."ilit trustee", 
"view_3rd_party_authorization"."carrier 3rd party auth effective date", 
"view_3rd_party_authorization"."carrier 3rd party auth person 1", 
"view_3rd_party_authorization"."carrier 3rd party auth person 2", 
"view_3rd_party_authorization"."carrier 3rd party auth company", 
"view_3rd_party_authorization"."id code", 
"view_3rd_party_authorization"."carrier 3rd party expiration date", 
"view_3rd_party_authorization"."coo sent to carrier", 
"view_3rd_party_authorization"."received carrier confirm of coo", 
"view_3rd_party_authorization"."mcc purchaser/provider", 
"view_3rd_party_authorization"."owner" as "view_3rd_party_authorization_owner", 
"view_3rd_party_authorization"."trustee 1", 
"view_3rd_party_authorization"."trustee 2", 
"view_3rd_party_authorization"."coo carrier 3rd party auth effective date", 
"view_3rd_party_authorization"."coo carrier 3rd party auth person 1", 
"view_3rd_party_authorization"."coo carrier 3rd party auth person 2", 
"view_3rd_party_authorization"."coo carrier 3rd party auth company", 
"view_3rd_party_authorization"."coo id code", 
"view_3rd_party_authorization"."coo carrier 3rd party expiration date", 
"policies"."owner" as "policy_owner", 
"view_3rd_party_authorization"."coo_auth_date_submitted", 
"view_3rd_party_authorization"."date_submitted", 
"view_3rd_party_authorization"."indefinite", 
"view_3rd_party_authorization"."coo indefinite" as "COO_Indefinite", 
"view_policy_consolidated"."client", 
"view_3rd_party_authorization"."notes", 
"view_3rd_party_authorization"."coo notes" 
FROM   (((((((((("sysdba"."policies" "POLICIES" 
                 LEFT OUTER JOIN "sysdba"."loans" "LOANS" 
                              ON "policies"."policiesid" = "loans"."policiesid") 
                LEFT OUTER JOIN "sysdba"."view_policy_consolidated" 
                                "View_Policy_Consolidated" 
                             ON "policies"."policiesid" = 
                                "view_policy_consolidated"."policiesid") 
               LEFT OUTER JOIN "sysdba"."category_1" "CATEGORY_1" 
                            ON "policies"."policiesid" = 
                               "category_1"."policiesid") 
              LEFT OUTER JOIN "sysdba"."view_premium_latest_by_source_date" 
                              "View_Premium_Latest_By_Source_Date" 
                           ON "policies"."policiesid" = 
                              "view_premium_latest_by_source_date"."policiesid") 
             LEFT OUTER JOIN "sysdba"."option_exercise_notice" 
                             "OPTION_EXERCISE_NOTICE" 
                          ON "policies"."policiesid" = 
                             "option_exercise_notice"."policiesid") 
            LEFT OUTER JOIN "sysdba"."view_policy_lonsdale_status_latest" 
                            "View_Policy_Lonsdale_Status_Latest" 
                         ON "policies"."policiesid" = 
                            "view_policy_lonsdale_status_latest"."policiesid") 
           LEFT OUTER JOIN "sysdba"."view_best_purchaser_offer_accepted" 
                           "VIEW_BEST_PURCHASER_OFFER_ACCEPTED" 
                        ON "policies"."policiesid" = 
                           "view_best_purchaser_offer_accepted"."policiesid") 
          INNER JOIN "sysdba"."view_3rd_party_authorization" 
                     "view_3rd_Party_Authorization" 
                  ON "policies"."policiesid" = 
                     "view_3rd_party_authorization"."policiesid") 
         INNER JOIN "sysdba"."medicalunderwriting" "MEDICALUNDERWRITING" 
                 ON "policies"."medicalunderwritingid" = 
                    "medicalunderwriting"."medicalunderwritingid") 
        LEFT OUTER JOIN "sysdba"."opportunity_ext" "OPPORTUNITY_EXT" 
                     ON "medicalunderwriting"."opportunityid" = 
                        "opportunity_ext"."opportunityid") 
       LEFT OUTER JOIN "sysdba"."prem_reqs_new" "PREM_REQS_NEW" 
                    ON "category_1"."prem_reqs_newid" = 
                       "prem_reqs_new"."prem_reqs_newid"