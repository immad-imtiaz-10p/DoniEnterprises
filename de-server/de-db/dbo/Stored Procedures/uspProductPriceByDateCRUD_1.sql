CREATE PROC [dbo].[uspProductPriceByDateCRUD]
(
	@crudOperation nvarchar(10),
	@productId int,
	@priceDate datetime,
	@price DECIMAL(24,2),
	@localPrice DECIMAL(24,2),
    @tr_createdBy int,
    @tr_editedBy int
    	
)
AS 
BEGIN
	IF @price = 0
	BEGIN
		SET @price = null
	END
	IF @localPrice = 0
	BEGIN
		SET @localPrice = null
	END

	IF @crudOperation = 'CREATE'
	BEGIN		
		INSERT INTO [dbo].[dailyProductPrices]
			([Prod_ID]
			,[PriceDate]
			,[Price]
			,[tr_createdBy]
			,[tr_editedBy]
			,[tr_createdOn]
			,[tr_editedOn]
			,[localPrice])
		VALUES
			(@productId
			,@priceDate
			,@price
			,@tr_createdBy
			,null
			,GETDATE()
			,null
			,@localPrice)
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[dailyProductPrices] 
		SET			 
			 [Price] = @price
			,[tr_editedBy] = @tr_editedBy
			,[tr_editedOn] = GETDATE()
			,[localPrice] = @localPrice
		WHERE PriceDate = @priceDate and Prod_ID = @productId
	END
END