-- =============================================
-- Author:		Si
-- Create date: 30/07/19
-- Description:	AFTER Update set zoho Send
-- =============================================
CREATE TRIGGER updateCustomers_sendZoho
   ON  dbo.CUSTOMERS
   AFTER update
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE CUSTOMERS SET ZOHO_SENT = '' WHERE CUST IN (
		SELECT CUST FROM inserted 
	)
    -- Insert statements for trigger here

END
GO
