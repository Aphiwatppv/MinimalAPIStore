CREATE PROCEDURE [dbo].[sp_AddNewProduct]
    @Product_Id INT,
    @Product_Name NVARCHAR(255),
    @Remaining_Stock INT,
    @Product_unit NVARCHAR(50),
    @Alert_limit INT,
    @Add_by NVARCHAR(100),
    @Product_Price DECIMAL(10, 2),
    @Price_Unit NVARCHAR(50),
    @Update_By NVARCHAR(100)
AS
BEGIN
    -- Check if a product with the given Product_Id already exists
    IF NOT EXISTS (SELECT 1 FROM [dbo].[MainStore] WHERE Product_Id = @Product_Id)
    BEGIN
        -- Insert the new product because a product with this Product_Id does not exist
        INSERT INTO [dbo].[MainStore]
        (
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
        )
        VALUES
        (
            @Product_Id,
            @Product_Name,
            @Remaining_Stock,
            @Product_unit,
            @Alert_limit,
            @Add_by,
            GETDATE(), -- Automatically sets the current date and time
            @Product_Price,
            @Price_Unit,
            GETDATE(), -- Automatically sets the current date and time
            @Update_By
        );
    END
    ELSE
    BEGIN
        -- Optionally handle the case where the Product_Id already exists
        -- For example, you could raise an error
        RAISERROR('A product with the given Product_Id already exists.', 16, 1);
        -- Or you could return an error code or a status indicating the operation was not successful
    END
END;
