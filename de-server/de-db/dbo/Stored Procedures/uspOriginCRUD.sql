CREATE PROCEDURE [dbo].[uspOriginCRUD]
(
	@crudOperation varchar(50),
	@origin_id bigint,
	@origin_name nvarchar(100)
)
AS 
BEGIN
IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[Origin]
           ([origin_name])
     VALUES
           (@origin_name)
    SELECT top 1 o.origin_id From dbo.Origin o order by o.origin_id desc
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[Origin]
		SET 
			[origin_name] = @origin_name
		WHERE origin_id = @origin_id 
		SELECT @origin_id
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM [dbo].[Origin]
		WHERE origin_id = @origin_id
		SELECT @origin_id
    END
END
