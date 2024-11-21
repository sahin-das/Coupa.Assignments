-- Show the most recent five orders that were purchased from 
-- account numbers that have spent more than $70,000 with AdventureWorks

use AdventureWorks2022;

with AccountNumbers as (
	SELECT AccountNumber, SUM(LineTotal) as TotalSpend
	FROM Sales.SalesOrderDetail so
	JOIN Sales.SalesOrderHeader sh
	ON so.SalesOrderID = sh.SalesOrderID
	GROUP BY AccountNumber
	HAVING SUM(LineTotal) > 70000
)

select top (5) so.AccountNumber, TotalSpend, SalesOrderID, OrderDate from Sales.SalesOrderHeader as so
right JOIN AccountNumbers an ON so.AccountNumber = an.AccountNumber
order by OrderDate desc;