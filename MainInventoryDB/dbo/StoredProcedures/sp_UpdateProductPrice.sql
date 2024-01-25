CREATE PROCEDURE [dbo].[sp_UpdateProductPrice]
    @Product_Id INT,
    @New_Product_Price DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON; -- This can improve performance by not counting the number of rows affected.

    -- Update the Product_Price for the specified Product_Id
    UPDATE dbo.MainStore
    SET Product_Price = @New_Product_Price,
        Price_Update_date = GETDATE() -- Optionally update the price update timestamp
    WHERE Product_Id = @Product_Id;
END;
GO