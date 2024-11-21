-- Exercise 2: Write separate queries using a join, a subquery, a CTE, and then an EXISTS
-- to list all AdventureWorks customers who have not placed an order.

use AdventureWorks2022;


-- join
select CustomerID from Sales.Customer
left join Sales.SalesOrderDetail
on SalesOrderDetail.rowguid = Customer.rowguid
where SalesOrderDetail.rowguid is Null;


-- subquery
select CustomerID from Sales.Customer
where rowguid not in (select rowguid from Sales.SalesOrderDetail);


-- CTE
with OrderedCustomers as (
	select distinct rowguid
	from Sales.SalesOrderDetail
)
select CustomerId from Sales.Customer
left join OrderedCustomers on Customer.rowguid = OrderedCustomers.rowguid
where OrderedCustomers.rowguid is Null;


-- exists
select CustomerID from Sales.Customer
where not exists (
	select 1 from Sales.SalesOrderDetail
	where Customer.rowguid = SalesOrderDetail.rowguid
);