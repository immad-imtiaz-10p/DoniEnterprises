CREATE PROC [dbo].[uspProductPriceByDateCRUD]
(
	@crudOperation varchar(50), 
	@productId int,
	@priceDate datetime,
	@price int,
    @tr_createdBy int,
    @tr_editedBy int
    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN		
		INSERT INTO [dbo].[dailyProductPrices]
			([Prod_ID]
			,[PriceDate]
			,[Price]
			,[tr_createdBy]
			,[tr_editedBy]
			,[tr_createdOn]
			,[tr_editedOn])
		VALUES
			(@productId
			,@priceDate
			,@price
			,@tr_createdBy
			,null
			,GETDATE()
			,null)
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[dailyProductPrices] SET
			 [Price] = @price
			,[tr_editedBy] = @tr_editedBy
			,[tr_editedOn] = GETDATE()
		WHERE PriceDate = @priceDate and Prod_ID = @productId
	END
END