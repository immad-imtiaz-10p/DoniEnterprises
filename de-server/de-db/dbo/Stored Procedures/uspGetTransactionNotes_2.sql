CREATE PROCEDURE [dbo].[uspGetTransactionNotes]
(
	@tr_transactionId bigint
)
AS 
BEGIN
	
	SELECT 
	tr_tranNoteID,
	tr_createdOn,
	tr_editedOn,
	tr_transactionNotes,
	ap.initials + '. ' +  ap.firstName + ' ' + ap.lastName AS fullName,
	ap.UserID 
	FROM dbo.TransactionsNotes tn 
	INNER JOIN 
	dbo.AppUsers ap
	ON ap.UserID = tn.tr_createdBy
	where tn.tr_transactionID = @tr_transactionId


END