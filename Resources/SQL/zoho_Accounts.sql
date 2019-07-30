SELECT dbo.CUSTOMERS.CUST, 
       dbo.CUSTOMERS.ZOHO_ID                                          AS id, 
       dbo.CUSTOMERS.CUSTNAME                                         AS Account_Name, 
       dbo.CUSTOMERS.CUSTDES                                          AS Description, 
       dbo.CUSTOMERS.ADDRESS2                                         AS Address_2, 
       dbo.CUSTOMERS.ADDRESS3                                         AS Address_3, 
       dbo.COUNTRIES.COUNTRYCODE                                      as Country_Code1, 
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYCUSTOMERS.CUSTNAME 
         ELSE dbo.CUSTOMERS.CUSTNAME 
       END                                                            AS Billing_Customer_Number,
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYCUSTOMERS.ADDRESS 
         ELSE dbo.CUSTOMERS.ADDRESS 
       END                                                            AS Billing_Street, 
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYCUSTOMERS.STATEA 
         ELSE dbo.CUSTOMERS.STATEA 
       END                                                            AS Billing_City, 
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYSTATES.STATENAME 
         ELSE dbo.STATES.STATENAME 
       END                                                            AS Billing_State, 
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYCUSTOMERS.ZIP 
         ELSE dbo.CUSTOMERS.ZIP 
       END                                                            AS Billing_Code, 
       CASE 
         WHEN PAYCUSTOMERS.CUST > 0 THEN PAYCOUNTRIES.COUNTRYNAME 
         ELSE dbo.COUNTRIES.COUNTRYNAME 
       END                                                            AS Billing_Country, 
       dbo.CUSTOMERSA.EMAIL                                           AS Company_Email, 
       dbo.CUSTOMERS.WTAXNUM                                          AS Company_Number, 
       dbo.CURRENCIES.CODE                                            AS Credit_Currency_1, 
       dbo.OBLIGO.MAX_CREDIT                                          AS Credit_Limit, 
       Round(dbo.OBLIGO.MAX_CREDIT - dbo.OBLIGO.CREDIT, 2)            AS Credit_Balance, 
       case 
         when CUSTOMERS.ZTRX_RESTRICTFLAG = 'Y' 
               or CUSTOMERS.RESTRICTED = 'Y' 
               or CUSTSTATS.ZTRX_ONHOLDFLAG = 'Y' then 1 
         else 0 
       end                                                            as On_Credit_Hold, 
       case 
         when CUSTOMERS.ZTRX_RESTRICTFLAG = 'Y' 
               or CUSTOMERS.RESTRICTED = 'Y' 
               or CUSTSTATS.ZTRX_ONHOLDFLAG = 'Y' then CONVERT(varchar, dbo.MINTODATE(CUSTOMERS.RESTRICTDATE), 23)
         else '' 
       end                                                            as Credit_Hold_Date, 
       dbo.CTYPE.CTYPECODE                                            AS Customer_Group_Code_1, 
       dbo.CUSTOMERS.CUSTNAME                                         AS Customer_Number, 
       dbo.CTYPE.CTYPENAME                                            AS Customer_Group_Name1, 
       dbo.CUSTSTATS.STATDES                                          AS Customer_Status_1, 
       CONVERT(varchar, dbo.MINTODATE(dbo.CUSTOMERS.CREATEDDATE), 23) AS Date_Account_Opened, 
       dbo.CUSTOMERS.FAX, 
       dbo.PAY.PAYCODE                                                AS Payment_Terms_Code_1, 
       dbo.PAY.PAYDES                                                 AS Payment_Terms_Description_1,
       dbo.CUSTOMERS.PHONE, 
       dbo.SHIPTYPES.STCODE                                           AS Shipment_Mode_Code_1, 
       dbo.SHIPTYPES.STDES                                            AS Shipment_Mode_Name_1, 
       dbo.CUSTOMERS.VATNUM                                           AS VAT_Number, 
       dbo.CUSTOMERSA.HOSTNAME                                        AS Website, 
       PAYCUSTOMERS.ZOHO_ID                                           AS [Billing_Customer_Name.id],
       dbo.AGENTS.ZOHO_ID                                             AS [Owner.id] 
FROM   dbo.CUSTOMERSA 
       RIGHT OUTER JOIN dbo.COUNTRIES 
                        RIGHT OUTER JOIN dbo.AGENTS 
                                         RIGHT OUTER JOIN dbo.STATES AS PAYSTATES 
                                                          INNER JOIN dbo.CUSTOMERS AS PAYCUSTOMERS
                                                                     INNER JOIN dbo.STATES 
                                                                                INNER JOIN dbo.PAY
                                                                                           INNER JOIN dbo.CUSTOMERS
                                                                                                   ON dbo.PAY.PAY =
                                                                                                      dbo.CUSTOMERS.PAY
                                                                                           INNER JOIN dbo.OBLIGO
                                                                                                   ON dbo.CUSTOMERS.CUST
                                                                                                      =
                                                                                                      dbo.OBLIGO.CUST
                                                                                           INNER JOIN dbo.CTYPE
                                                                                                   ON
                                                                                           dbo.CUSTOMERS.CTYPE =
                                                                                           dbo.CTYPE.CTYPE
                                                                                           INNER JOIN dbo.CUSTSTATS
                                                                                                   ON
                                                                                           dbo.CUSTOMERS.CUSTSTAT =
                                                                                           dbo.CUSTSTATS.CUSTSTAT
                                                                                        ON dbo.STATES.STATEID =
                                                                                           dbo.CUSTOMERS.STATEID
                                                                                INNER JOIN dbo.CURRENCIES
                                                                                        ON dbo.CUSTOMERS.CURRENCY =
                                                                                           dbo.CURRENCIES.CURRENCY
                                                                             ON PAYCUSTOMERS.CUST =
                                                                                dbo.CUSTOMERS.PAYCUST
                                                                     INNER JOIN dbo.SHIPTYPES 
                                                                             ON dbo.CUSTOMERS.SHIPTYPE =
                                                                                dbo.SHIPTYPES.SHIPTYPE
                                                                     INNER JOIN dbo.COUNTRIES AS PAYCOUNTRIES
                                                                             ON PAYCUSTOMERS.COUNTRY =
                                                                                PAYCOUNTRIES.COUNTRY
                                                                  ON PAYSTATES.STATEID = PAYCUSTOMERS.STATEID
                                                       ON dbo.AGENTS.AGENT = dbo.CUSTOMERS.AGENT
                                      ON dbo.COUNTRIES.COUNTRY = dbo.CUSTOMERS.COUNTRY 
                     ON dbo.CUSTOMERSA.CUST = dbo.CUSTOMERS.CUST 
WHERE  ( dbo.CUSTOMERS.CUST > 0 ) 
       AND ( dbo.CUSTOMERS.ZOHO_SENT <> 'Y' ) 
       AND ( dbo.CUSTOMERS.ZOHO_FAIL <> 'Y' ) 
       AND ( dbo.CTYPE.CTYPECODE NOT IN ( 'TD' ) 
              OR ( ( dbo.CUSTSTATS.INACTIVE <> 'Y' ) 
                   AND ( dbo.CTYPE.CTYPECODE IN ( 'TD' ) ) ) ) 
       And ( ( PAYCUSTOMERS.CUST = 0 ) 
              or ( ( PAYCUSTOMERS.CUST > 0 ) 
                   and ( Len(isnull(PAYCUSTOMERS.ZOHO_ID, '')) > 0 ) ) ) 