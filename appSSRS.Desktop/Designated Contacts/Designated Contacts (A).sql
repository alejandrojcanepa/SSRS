SELECT DISTINCT contactid, 
                NAME, 
                oe.dob                             AS DOB, 
                oe.ssn                             AS [SSN|leading0], 
                dbo.Formatphonenumber(c.homephone) AS [Insured Home Phone], 
                dbo.Formatphonenumber(c.mobile)    AS [Insured Cell Phone], 
                dbo.Formatphonenumber(c.workphone) AS [Insured Work Phone], 
                a.address1                         AS [Insured Address], 
                a.address2                         AS [Additional Address Detail], 
                a.city, 
                a.state, 
                a.postalcode                       AS [Zip Code|leading0], 
                sa.address1                        AS [Insured Shipping Address], 
                sa.address2                        AS [Additional Shipping Address Detail], 
                sa.city                            AS [Shipping City], 
                sa.state                           AS [Shipping State], 
                sa.postalcode                      AS [Shipping Zip Code|leading0] 
FROM   sysdba.view_policy_consolidated p 
       INNER JOIN sysdba.opportunity_ext oe 
               ON oe.opportunityid = p.opportunityid 
       INNER JOIN sysdba.contact c 
               ON c.contactid = oe.clientcontactid 
       LEFT OUTER JOIN sysdba.address a 
                    ON a.entityid = c.contactid 
                       AND a.isprimary = 'T' 
       LEFT OUTER JOIN sysdba.address sa 
                    ON sa.entityid = c.contactid 
                       AND sa.ismailing = 'T' 
                       AND Isnull(sa.isprimary, 'F') = 'F' 
WHERE  client = 'Viva (Blackstone)' 
ORDER  BY p.NAME 