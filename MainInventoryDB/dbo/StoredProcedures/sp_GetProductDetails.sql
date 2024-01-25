CREATE PROCEDURE [dbo].[sp_GetProductDetails]
    @Product_Id INT
AS
BEGIN
    SET NOCOUNT ON; -- Improves performance by not counting the number of rows affected.

    -- Select and return the product details for the specified Product_Id
    SELECT 
        Product_Id,
        Product_Name,
        Product_Price,
        Product_unit,
        Price_Unit,
        Add_by,
        Add_date,
        Remaining_Stock,
        Update_By,
        Alert_limit,
        Price_Update_date
    FROM dbo.MainStore
    WHERE Product_Id = @Product_Id;
END;
GO
