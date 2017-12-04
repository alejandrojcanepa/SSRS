SELECT 
       "view_3rd_party_authorization"."insured name" AS [Insured Name], 
       "view_3rd_party_authorization"."carrier" AS [Carrier], 
       "view_3rd_party_authorization"."policy number" AS [Policy Number], 
       "view_3rd_party_authorization"."death benefit" AS [Death Benefit], 
       "view_3rd_party_authorization"."program #" AS [Program #], 
       "view_3rd_party_authorization"."category" AS [Category], 
       "view_policy_consolidated"."client" AS [Current Client], 
       "view_3rd_party_authorization"."policy owning trust" AS [Policy Owning Trust], 
       "view_3rd_party_authorization"."admin trustee" AS [Admin Trustee], 
       "view_3rd_party_authorization"."ilit trustee" AS [ILIT Trustee], 
       "view_3rd_party_authorization"."date_submitted" AS [Carrier 3rd Party Auth Submitted], 
       "view_3rd_party_authorization"."carrier 3rd party auth effective date" AS [Carrier 3rd Party Auth Effective Date], 
       "view_3rd_party_authorization"."carrier 3rd party auth person 1" AS [Carrier 3rd Party Auth Person 1], 
       "view_3rd_party_authorization"."carrier 3rd party auth person 2" AS [Carrier 3rd Party Auth Person 2], 
       "view_3rd_party_authorization"."carrier 3rd party auth company" AS [Carrier 3rd Party Auth Company], 
       "view_3rd_party_authorization"."id code" AS [ID Code], 
       "view_3rd_party_authorization"."carrier 3rd party expiration date" AS [Carrier 3rd Party Expiration Date], 
       "view_3rd_party_authorization"."insured name" AS [@Indefinite Authorization], --function IndefiniteAuthorization
       "view_3rd_party_authorization"."notes" AS [NOTES], 
       "view_3rd_party_authorization"."coo sent to carrier" AS [COO Sent to Carrier], 
       "view_3rd_party_authorization"."received carrier confirm of coo" AS [Received Carrier Confirm of COO], 
       "view_3rd_party_authorization"."mcc purchaser/provider" AS [MCC Purchaser/Provider], 
       "view_3rd_party_authorization"."owner" AS [Owner], 
       "view_3rd_party_authorization"."trustee 1" AS [Trustee 1], 
       "view_3rd_party_authorization"."trustee 2" AS [Trustee 2], 
       "view_3rd_party_authorization"."coo_auth_date_submitted" AS [COO Carrier 3rd Party Auth Submitted], 
       "view_3rd_party_authorization"."coo carrier 3rd party auth effective date" AS [COO Carrier 3rd Party Auth Effective Date], 
       "view_3rd_party_authorization"."coo carrier 3rd party auth person 1" AS [COO Carrier 3rd Party Auth Person 1], 
       "view_3rd_party_authorization"."coo carrier 3rd party auth person 2" AS [COO Carrier 3rd Party Auth Person 2], 
       "view_3rd_party_authorization"."coo carrier 3rd party auth company" AS [COO Carrier 3rd Party Auth Company], 
       "view_3rd_party_authorization"."coo id code" AS [COO ID Code], 
       "view_3rd_party_authorization"."coo carrier 3rd party expiration date" AS [COO Carrier 3rd Party Expiration Date], 
       "view_3rd_party_authorization"."insured name" AS [@COO Indefinte Authorization], --function COOIndefinteAuthorization
       "view_3rd_party_authorization"."coo notes" AS [COO Notes],

       "loans"."note_purchaser", 
       "policies"."endorsee", 
       "policies"."policiesid", 
       "view_policy_consolidated"."program", 
       "view_policy_consolidated"."provider" AS [VPCProvider], 
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
       "view_best_purchaser_offer_accepted"."provider" AS [VBPOAProvider], 
       "policies"."owner", 
       "view_3rd_party_authorization"."indefinite", 
       "view_3rd_party_authorization"."coo indefinite" AS [COO_Indefinite]

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