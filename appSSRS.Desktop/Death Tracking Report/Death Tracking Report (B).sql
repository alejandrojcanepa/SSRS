SELECT request_date           AS [Death Cert. Req Submitted], 
       death_cert_state       AS [Death Cert. State], 
       death_cert_country     AS [Death Cert. Country], 
       state_status           AS [State Status], 
       jurisdiction           AS [Jurisdiction], 
       jurisdiction_name      AS [Jurisdiction Name], 
       death_cert_status      AS [Death Cert. Status], 
       death_cert_status_date AS [Death Cert Status Date] 
FROM   sysdba.death_certificate 
WHERE  policiesid = 'Q6UJ9A003O2T'  --this is just an example, you need to set the policiesid by parameter