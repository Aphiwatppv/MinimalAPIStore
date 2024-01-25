CREATE PROCEDURE [dbo].[sp_ReduceProductStock]
@Product_Id INT,
    @DecrementAmount INT
AS
BEGIN
    SET NOCOUNT ON; -- This can improve performance by not counting the number of rows affected.

    -- Check if the current stock is sufficient to reduce
    IF EXISTS (SELECT 1 FROM dbo.MainStore WHERE Product_Id = @Product_Id AND Remaining_Stock >= @DecrementAmount)
    BEGIN
        -- Update the Remaining_Stock by reducing it with the DecrementAmount
        UPDATE dbo.MainStore
        SET Remaining_Stock = Remaining_Stock - @DecrementAmount
        WHERE Product_Id = @Product_Id;
    END
    ELSE
    BEGIN
        -- Handle the case where stock is insufficient, you can raise an error or just return
        RAISERROR('Insufficient stock for the product', 16, 1);
    END
END;
GO