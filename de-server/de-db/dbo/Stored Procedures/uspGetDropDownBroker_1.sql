CREATE PROCEDURE dbo.[uspGetDropDownBroker]	
AS 
BEGIN 
    SELECT  bp.bp_ID,
			bp.bp_Name,
			bp.bp_address,
			bpc.bp_Cont_fullName,
			bp.bp_country 
	FROM 
		dbo.BusinessPartner bp
	LEFT OUTER JOIN
		dbo.BusinessPartner_Contacts bpc
	ON bp.bp_ID = bpc.bp_ID AND bpc.bp_Cont_IsPrimary = 1
	WHERE bp.bp_isBroker = 1
END