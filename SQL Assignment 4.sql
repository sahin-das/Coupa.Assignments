-- Exercise 4: Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date,
-- and returns a table of all the SalesOrderDetail rows for that Sales Order including Quantity,
-- ProductID, UnitPrice, and the unit price converted to the target currency based on the end of 
-- day rate for the date provided. Exchange rates can be found in the Sales.CurrencyRate table.

use AdventureWorks2022;
Go


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
		OrderQty
		ProductID,
		UnitPrice,
		UnitPrice * EndOfDayRate as ConvertedUnitPrice
    FROM Sales.SalesOrderDetail AS so
	CROSS APPLY (
		select TOP 1
			sc.EndOfDayRate
		from Sales.CurrencyRate sc
        WHERE sc.ToCurrencyCode = @CurrencyCode
          AND sc.FromCurrencyCode = 'USD'
          AND sc.CurrencyRateDate <= @Date
	) as cr
	WHERE so.SalesOrderID = @SalesOrderID
);
GO


SELECT * 
FROM getSalesDetailsCustom(43659, 'ARS', '2011-05-31');
