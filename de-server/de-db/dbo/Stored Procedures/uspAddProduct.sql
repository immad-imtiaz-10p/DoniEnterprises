CREATE PROC [dbo].[uspAddProduct]
(
	
	@ProductName nvarchar(250),
	@CreatedBy int,
	@moisture int,
	@weaveled int,
	@origin varchar(50),
	@purity int,
	@splits int,
	@quality nvarchar(max),
	@damaged int,
	@foreignMatter int,
	@greenDamaged int,
	@otherColor int,
	@wrinkled int

)
AS
BEGIN	
	INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[LastUpdatedOn]
           ,[LastUpdatedBy]
           ,[moisture]
           ,[purity]
           ,[weaveled]
           ,[origin]
           ,[splits]
           ,[quality]
           ,[damaged]
           ,[foreignMatter]
           ,[greenDamaged]
           ,[otherColor]
           ,[wrinkled])
     VALUES
	 (
		@ProductName,
		GETDATE(),
		@CreatedBy,
		null,
		null,
		@moisture,
		@purity,
		@weaveled,
		@origin,
		@splits,
		@quality,
	    @damaged,
		@foreignMatter,
		@greenDamaged,
		@otherColor,
		@wrinkled
	)	
END



