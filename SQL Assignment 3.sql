-- Show the most recent five orders that were purchased from 
-- account numbers that have spent more than $70,000 with AdventureWorks

use AdventureWorks2022;

select top (5) SOH.AccountNumber, SOH.SalesOrderID, SOH.OrderDate
FROM Sales.SalesOrderHeader SOH
JOIN Sales.SalesOrderDetail SOD
    ON SOH.SalesOrderID = SOD.SalesOrderID
WHERE SOH.AccountNumber IN (
    SELECT AccountNumber
    FROM Sales.SalesOrderHeader
    GROUP BY AccountNumber
    HAVING SUM(TotalDue) > 70000
)
ORDER BY SOH.OrderDate DESC;
