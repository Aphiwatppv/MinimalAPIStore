CREATE TABLE [dbo].[MainStore]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Product_Id INT,
    Product_Name NVARCHAR(255),
    Remaining_Stock INT,
    Product_unit NVARCHAR(50),
    Alert_limit INT,
    Add_by NVARCHAR(100),
    Add_date DATETIME,
    Product_Price DECIMAL(10, 2),
    Price_Unit NVARCHAR(50),
    Price_Update_date DATETIME,
    Update_By NVARCHAR(100)
)
