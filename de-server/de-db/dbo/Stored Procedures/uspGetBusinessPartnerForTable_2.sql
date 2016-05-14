
CREATE Procedure [dbo].[uspGetBusinessPartnerForTable]

AS 
BEGIN
	SELECT 
	 bp.bp_ID, 
	 bp.bp_Name, 
	 bpc.bp_cont_ID,
	 bpc.bp_Cont_fullName,
	 bp.bp_isBroker,
	 bp.bp_isBuyer, 
	 bp.bp_isSeller,
	 bp.bp_isShipper,
	 bp.bp_credibilityIndex,
	 bp.bp_country,
	 max(T.tr_transactionID) AS tr_transactionID,
	 max(T.tr_date) AS tr_date
	FROM dbo.BusinessPartner bp 
	LEFT OUTER JOIN 
	dbo.BusinessPartner_Contacts bpc 
	ON bp.bp_ID = bpc.bp_ID AND bpc.bp_Cont_IsPrimary = 1
	LEFT OUTER JOIN  
	dbo.Transactions T ON (bp.bp_ID = T.tr_bpBuyerID OR bp.bp_ID = T.tr_bpSellerID)
	GROUP BY bp.bp_ID, 
	 bp.bp_Name, 
	 bpc.bp_cont_ID,
	 bpc.bp_Cont_fullName,
	 bp.bp_isBroker,
	 bp.bp_isBuyer, 
	 bp.bp_isSeller,
	 bp.bp_isShipper,
	 bp.bp_credibilityIndex,
	 bp.bp_country
	ORDER BY bp.bp_Name
END