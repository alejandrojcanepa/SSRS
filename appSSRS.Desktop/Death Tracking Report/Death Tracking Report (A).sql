SELECT p.policiesid, 
       p.NAME                                            AS [Client Name], 
       CASE 
         WHEN pp.sul_policyid IS NOT NULL THEN 'Yes' 
         ELSE '' 
       END                                               AS [Survivorship Policy], 
       dbo.Formatsloxboolean(dc.first_insured_death, '') AS [Survivorship - 1st Insured Death], 
       sysdba.opportunity_ext.ssn, 
       p.insurancecompany                                AS Carrier, 
       p.policynumber                                    AS [Policy No.], 
       p.deathbenefit                                    AS [Death Benefit$], 
       CASE 
         WHEN pmain.client IS NOT NULL THEN pmain.aniversarydate 
         ELSE p.aniversarydate 
       END                                               AS [Anniversary Date], 
       CASE 
         WHEN pmain.client IS NOT NULL THEN pmain.provider 
         ELSE p.provider 
       END                                               AS [Program Provider], 
       CASE 
         WHEN pmain.program IS NOT NULL THEN pmain.program 
         ELSE p.program 
       END                                               AS [Program No.], 
       CASE 
         WHEN pmain.client IS NOT NULL THEN pmain.client 
         ELSE p.client 
       END                                               AS [Current Client], 
       prev.client                                       AS [Previous Client], 
       pp.stateofissue                                   AS [State of Issue], 
       sysdba.opportunity_ext.dob, 
       sysdba.opportunity_ext.date_of_death              AS DOD, 
       Round(Datediff(d, sysdba.opportunity_ext.dob, 
             sysdba.opportunity_ext.date_of_death) / 
             365.25, 2)                                  AS [Age at DOD], 
       pos.status, 
       pos.owner, 
       CASE 
         WHEN Isnull(dc.ns_not_respon_death_claim, 'F') = '1' THEN 
         'Not Responsible' 
         ELSE 'Responsible' 
       END                                               AS 
       [NorthStar Not Responsible for Filing Death Claim], 
       dc.death_claim_start                              AS 
       [Death Claim Process Start Date], 
       dc.obituary_verified_d                            AS [Obituary Verified], 
       dc.obituary_published_by                          AS [Published by], 
       dc.alt_search_death_veri_d                        AS 
       [Alt. Search/Death Verificaton], 
       CASE 
         WHEN dc.source_state = 'T' THEN 'YES' 
         ELSE '' 
       END                                               AS [Source: State], 
       CASE 
         WHEN dc.source_ssa = 'T' THEN 'YES' 
         ELSE '' 
       END                                               AS [Source: SSA], 
       CASE 
         WHEN dc.source_obituary = 'T' THEN 'YES' 
         ELSE '' 
       END                                               AS [Source: Obituary], 
       CASE 
         WHEN dc.source_other = 'T' THEN 'YES' 
         ELSE '' 
       END                                               AS [Source: Other], 
       dc.source_other_value                             AS [Other Source Type], 
       dc.req_original_from_owner                        AS [Req'd Orig Policy from Owner], 
       dc.addl_doc_from_owner_recvd                      AS [Rec'd Orig Policy from Owner], 
       dc.claim_form_sent_bene                           AS [Claim Forms Sent to Bene], 
       dc.claim_form_executed_by_bene                    AS [Claim Forms Executed by Bene], 
       dc.death_claim_pckg_tocarrier_sub                 AS [Death Claim Pckg Submitted to Carrier], 
       dc.death_claim_pckg_to_sentvia                    AS [Sent Via], 
       dc.death_claim_pckg_tocarrier_rev                 AS [Carrier Rec'd Pckg], 
       dc.first_death_recorded                           AS [1st Death Recorded (Per Carrier)], 
       dc.death_claim_processed                          AS [Death Claim Processed], 
        Isnull(dc.death_benefit, 0) 
        + Isnull(dc.interest, 0) 
       + Isnull(dc.rop_payment, 0)                       AS [Total DB Payout Amount$], 
       Floor(Round(Datediff(hh, sysdba.opportunity_ext.date_of_death, 
                         dc.death_claim_processed) / 
                         24.0, 0))                       AS [No. of Days from DOD to Claim Processed], 
       Floor(Round(Datediff(hh, dc.death_claim_start, dc.death_claim_processed) 
                   / 24.0, 
             0))                                         AS [No. of Days from Claim Start Date to Claim Processed] 
FROM   sysdba.view_policy_consolidated AS p 
       INNER JOIN sysdba.policies AS pp 
               ON pp.policiesid = p.policiesid 
       LEFT OUTER JOIN sysdba.view_policy_owner_status AS pos 
                    ON pos.policiesid = p.policiesid 
       INNER JOIN sysdba.opportunity_ext 
               ON sysdba.opportunity_ext.opportunityid = p.opportunityid 
       LEFT OUTER JOIN sysdba.death_claim AS dc 
                    ON p.policiesid = dc.policiesid 
       LEFT OUTER JOIN sysdba.view_policy_client_previous AS prev 
                    ON prev.policiesid = p.policiesid 
       LEFT OUTER JOIN sysdba.view_policy_consolidated AS pmain 
                    ON pmain.policiesid = pp.sul_policyid 
                       AND Isnull(pp.sul_primary, 'F') = 'F' 
WHERE  ( sysdba.opportunity_ext.date_of_death IS NOT NULL ) 
       AND ( p.isactive = 1 ) 
        OR ( sysdba.opportunity_ext.date_of_death IS NOT NULL ) 
           AND ( p.program IN ( '69', '74', '75', '76', 
                                '78', '102', '104', '112', 
                                '201', '212', '221', '223', 
                                '224', '270', '280', '290', '295' ) ) 
        OR ( sysdba.opportunity_ext.date_of_death IS NOT NULL ) 
           AND ( pmain.isactive = 1 ) 
        OR ( sysdba.opportunity_ext.date_of_death IS NOT NULL ) 
           AND ( pmain.program IN ( '69', '74', '75', '76', 
                                    '78', '102', '104', '112', 
                                    '201', '212', '221', '223', 
                                    '224', '270', '280', '290', '295' ) ) 