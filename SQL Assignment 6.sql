-- Exercise 6: Write a trigger for the Product table to ensure the list price can
-- never be raised more than 15 Percent in a single change. Modify the above trigger
-- to execute its check code only if the ListPrice column is updated


CREATE TRIGGER enforcePriceRule
ON Production.Product
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF (UPDATE(ListPrice))
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM Inserted i
            JOIN Deleted d ON i.ProductID = d.ProductID
            WHERE i.ListPrice > d.ListPrice * 1.15
        )
        BEGIN
            RAISERROR ('Cannot raise ListPrice by more than 15 percent in a single change.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;


UPDATE Production.Product
SET ListPrice = 100.00
WHERE ProductID = 1;

UPDATE Production.Product
SET ListPrice = 120.00
WHERE ProductID = 1;
