/****** Object:  StoredProcedure [dbo].[uspTransactionSecondaryCRUD]    Script Date: 1/6/2016 12:46:15 PM ******/
CREATE PROC [dbo].[uspTransactionNotesCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
    @tr_tranNoteID bigint,
	@tr_transactionNotes varchar(max),
    @tr_createdBy int
	    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsNotes]
           ([tr_transactionID]
           ,[tr_transactionNotes]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedOn])
     VALUES
           (@tr_transactionID,@tr_transactionNotes,@tr_createdBy,GETDATE(),null)
		SELECT TOP 1 * FROM [dbo].[TransactionsNotes] tn order by tn.tr_tranNoteID desc
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
         UPDATE [dbo].[TransactionsNotes]
		   SET [tr_transactionNotes] = @tr_transactionNotes,
			   [tr_editedOn] = GETDATE()
		 WHERE tr_tranNoteID = @tr_tranNoteID
		 SELECT TOP 1 * FROM [dbo].[TransactionsNotes] WHERE tr_tranNoteID = @tr_transactionNotes
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM [dbo].[TransactionsNotes] 
		WHERE tr_transactionNotes = @tr_transactionNotes
		SELECT TOP 1 * FROM [dbo].[TransactionsNotes] WHERE tr_tranNoteID = @tr_transactionNotes
    END	
END