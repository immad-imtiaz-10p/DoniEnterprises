CREATE PROC [dbo].[uspUpdateProduct]
(
	@ProductID  int,
	@ProductName nvarchar(250),
	@moisture int,
	@weaveled int,
	@origin varchar(50),
	@purity int,
	@splits int,
	@quality nvarchar(max),
	@UpdatedBy int,
	@damaged int,
	@foreignMatter int,
	@greenDamaged int,
	@otherColor int,
	@wrinkled int
)
AS
BEGIN	
   UPDATE [dbo].[Products]
   SET [ProductName] = @ProductName
      ,[LastUpdatedOn] = GETDATE()
      ,[LastUpdatedBy] = @UpdatedBy
      ,[moisture] = @moisture
      ,[purity] = @purity
      ,[weaveled] = @weaveled
      ,[origin] = @origin
      ,[splits] = @splits
      ,[quality] = @quality
	  ,[damaged] = @damaged
      ,[foreignMatter] = @foreignMatter
      ,[greenDamaged] = @greenDamaged
      ,[otherColor] = @otherColor
      ,[wrinkled] = @wrinkled
	WHERE 
	ProductId = @ProductID
					
END