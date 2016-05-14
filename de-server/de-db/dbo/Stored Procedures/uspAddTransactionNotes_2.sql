CREATE Procedure [dbo].[uspAddTransactionNotes]
(
	@tr_ID bigint,
	@tr_notes NVARCHAR(max),
	@tr_createdBy int 
)
AS 
BEGIN
	INSERT INTO [dbo].[TransactionNotes]
           ([tr_ID]
           ,[notes]
           ,[tr_createdOn]
           ,[tr_lastEditedOn]
           ,[tr_createdBy])
     VALUES
           (@tr_ID, @tr_notes, GETDATE(), null, @tr_createdBy)
END