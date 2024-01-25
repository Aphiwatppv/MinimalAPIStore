CREATE PROCEDURE [dbo].[sp_RemoveProductId]
	@Product_Id INT
AS
BEGIN
    SET NOCOUNT ON; -- This can improve performance by not counting the number of rows affected.

    -- Delete the product with the specified Id
    DELETE FROM dbo.MainStore
    WHERE Product_Id = @Product_Id;
END;
GO