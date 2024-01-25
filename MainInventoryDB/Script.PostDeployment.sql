IF NOT EXISTS (SELECT 1 FROM dbo.MainStore)
BEGIN
    INSERT INTO dbo.MainStore (
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
    VALUES (101,N'เหล้าข้าว',100,N'ลัง',10,'Aphiwat',GETDATE(),980,N'บาท',GETDATE(),'Aphiwat'),
           (102,N'ลีโอ',100,N'ลัง',10,'Aphiwat',GETDATE(),980,N'บาท',GETDATE(),'Aphiwat'),
           (103,N'ช้าง',100,N'ลัง',10,'Aphiwat',GETDATE(),980,N'บาท',GETDATE(),'Aphiwat')
    ;
END
