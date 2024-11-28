-- Exercise 4: Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date,
-- and returns a table of all the SalesOrderDetail rows for that Sales Order including Quantity,
-- ProductID, UnitPrice, and the unit price converted to the target currency based on the end of 
-- day rate for the date provided. Exchange rates can be found in the Sales.CurrencyRate table.

USE AdventureWorks2022;
GO

ALTER FUNCTION dbo.getSalesDetailsCustom (
    @SalesOrderID INT,
    @CurrencyCode NVARCHAR(50),
    @date DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        so.OrderQty,
        so.ProductID,
        so.UnitPrice,
        so.UnitPrice * cr.EndOfDayRate AS ConvertedUnitPrice
    FROM Sales.SalesOrderDetail AS so
    CROSS APPLY (
        SELECT TOP 1
            sc.EndOfDayRate
        FROM Sales.CurrencyRate AS sc
        WHERE sc.ToCurrencyCode = @CurrencyCode
          AND sc.FromCurrencyCode = 'USD'
          AND sc.CurrencyRateDate <= @Date
        ORDER BY sc.CurrencyRateDate DESC
    ) AS cr
    WHERE so.SalesOrderID = @SalesOrderID
);
GO


SELECT * 
FROM dbo.getSalesDetailsCustom(43659, 'ARS', '2011-05-31');
