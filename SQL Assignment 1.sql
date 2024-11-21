use AdventureWorks2022;

-- Display the number of records in the [SalesPerson] table
select Count(*) as NumberOfRecords from Sales.SalesPerson;

-- Select both the FirstName and LastName of records from the Person table where the FirstName begins with the letter ‘B’
select FirstName, LastName from Person.Person
where FirstName Like 'B%';

-- Select a list of FirstName and LastName for employees where Title is one of Design Engineer, Tool Designer or Marketing Assistant
select FirstName, LastName, JobTitle from HumanResources.Employee
full outer join Person.Person
on Person.BusinessEntityID = Employee.BusinessEntityID
where JobTitle in ('Design Engineer', 'Tool Designer', 'Marketing Assistant')

-- Display the Name and Color of the Product with the maximum weight
select Name, Color, Weight from Production.Product
where Weight = (select max(Weight) from Production.Product);

-- Display Description and MaxQty fields from the SpecialOffer table. Some of the MaxQty values are NULL, in this case display the value 0.00 instead
select Description, isnull(MaxQty, 0) from Sales.SpecialOffer;

-- Display the overall Average of the [CurrencyRate].[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’ for the year 2005 i.e. FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’
select avg(AverageRate) as 'Average exchange rate for the day'
from Sales.CurrencyRate
where FromCurrencyCode = 'USD' and ToCurrencyCode = 'GBP' and year(CurrencyRateDate) = 2005;

-- Display the FirstName and LastName of records from the Person table where FirstName contains the letters ‘ss’. Display an additional column with sequential numbers for each row returned beginning at integer 1
select ROW_NUMBER() OVER (ORDER BY FirstName) AS SN, FirstName, LastName from Person.Person
where FirstName like '%ss%';

-- Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate band
select BusinessEntityID as SalePersonId, CommissionPct as 'Commission %',
	case
		when CommissionPct = 0 then 'Band 0'
		when CommissionPct > 0 and CommissionPct <= 1 then 'Band 1'
		when CommissionPct > 1 and CommissionPct <= 1.5 then 'Band 2'
		when CommissionPct > 1.5 then 'Band 3'
	end as 'Commission Band'
from Sales.SalesPerson;

-- Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez
DECLARE @EmployeeID INT;

SELECT @EmployeeID=BusinessEntityID
FROM Person.Person
where FirstName='Ruth' and LastName='Ellerbrock' and PersonType='EM'

EXEC uspGetEmployeeManagers @EmployeeID;

-- Display the ProductId of the product with the largest stock level
select ProductID from Production.Product
where dbo.ufnGetStock(Product.ProductID) = (select max(dbo.ufnGetStock(Product.ProductID)) from Production.Product);
