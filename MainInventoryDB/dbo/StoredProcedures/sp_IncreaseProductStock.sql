CREATE PROCEDURE [dbo].[sp_IncreaseProductStock]
    @Product_Id INT,
    @IncrementAmount INT
AS
BEGIN
    SET NOCOUNT ON; -- Improves performance by not counting the number of rows affected.

    -- Update the Remaining_Stock by increasing it with the IncrementAmount
    UPDATE dbo.MainStore
    SET Remaining_Stock = Remaining_Stock + @IncrementAmount
    WHERE Product_Id = @Product_Id;
END;
GO