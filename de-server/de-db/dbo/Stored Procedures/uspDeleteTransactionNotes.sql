CREATE Procedure dbo.uspDeleteTransactionNotes
(
  @tr_NotesID bigint,
  @tr_ID bigint
)
AS 
BEGIN
	DELETE FROM dbo.TransactionNotes WHERE tr_NotesID = @tr_NotesID AND tr_ID = @tr_ID  
END