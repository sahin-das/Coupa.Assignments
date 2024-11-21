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
