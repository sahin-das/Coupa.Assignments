use AdventureWorks2022;

select Count(*) as NumberOfRecords from Sales.SalesPerson;

select FirstName, LastName from Person.Person
where FirstName Like 'B%';

select FirstName, LastName, JobTitle from HumanResources.Employee
full outer join Person.Person
on Person.BusinessEntityID = Employee.BusinessEntityID
where JobTitle in ('Design Engineer', 'Tool Designer', 'Marketing Assistant')

select Name, Color, Weight from Production.Product
where Weight = (select max(Weight) from Production.Product);

select Description, isnull(MaxQty, 0) from Sales.SpecialOffer;

select avg(AverageRate) as 'Average exchange rate for the day'
from Sales.CurrencyRate
where FromCurrencyCode = 'USD' and ToCurrencyCode = 'GBP' and year(CurrencyRateDate) = 2005;

select ROW_NUMBER() OVER (ORDER BY FirstName) AS Sn, FirstName, LastName from Person.Person
where FirstName like '%ss%';

select BusinessEntityID as SalePersonId, CommissionPct as 'Commission %',
	case
		when CommissionPct = 0 then 'Band 0'
		when CommissionPct > 0 and CommissionPct <= 1 then 'Band 1'
		when CommissionPct > 1 and CommissionPct <= 1.5 then 'Band 2'
		when CommissionPct > 1.5 then 'Band 3'
	end as 'Commission Band'
from Sales.SalesPerson;

DECLARE @EmployeeID INT;

SELECT @EmployeeID=BusinessEntityID
FROM Person.Person
where FirstName='Ruth' and LastName='Ellerbrock' and PersonType='EM'

EXEC uspGetEmployeeManagers @EmployeeID;

select ProductID from Production.Product
where dbo.ufnGetStock(Product.ProductID) = (select max(dbo.ufnGetStock(Product.ProductID)) from Production.Product);
