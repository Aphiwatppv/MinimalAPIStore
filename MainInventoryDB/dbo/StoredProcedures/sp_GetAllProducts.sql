CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
    SET NOCOUNT ON; -- Recommended to improve performance by not counting rows affected.

    SELECT 
        Id,
        Product_Id,
        Product_Name,
        Remaining_Stock,
        Product_unit,
        Alert_limit,
        Add_by,
        Add_date,
        Product_Price,
        Price_Unit,
        Price_Update_date,
        Update_By
    FROM 
        dbo.MainStore;
END;
GO
