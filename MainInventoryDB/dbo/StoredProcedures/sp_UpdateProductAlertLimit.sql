CREATE PROCEDURE [dbo].[sp_UpdateProductAlertLimit]
    @Product_Id INT,
    @New_Alert_Limit INT
AS
BEGIN
    SET NOCOUNT ON; -- This can improve performance by not counting the number of rows affected.

    -- Update the Alert_limit for the specified Product_Id
    UPDATE dbo.MainStore
    SET Alert_limit = @New_Alert_Limit
    WHERE Product_Id = @Product_Id;
END;
GO