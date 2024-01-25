CREATE PROCEDURE [dbo].[sp_UpdateProductName]
    @Product_Id INT,
    @New_Product_Name NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON; -- Improves performance by not counting the number of rows affected.

    -- Update the Product_Name for the specified Product_Id
    UPDATE dbo.MainStore
    SET Product_Name = @New_Product_Name
    WHERE Product_Id = @Product_Id;
END;
GO
