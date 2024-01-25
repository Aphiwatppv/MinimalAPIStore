CREATE PROCEDURE [dbo].[sp_GetProductsByName]
    @NamePattern NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON; -- Improves performance by not counting the number of rows affected.

    -- Select and return products where the Product_Name contains the specified pattern
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
    WHERE Product_Name LIKE '%' + @NamePattern + '%';
END;
GO
