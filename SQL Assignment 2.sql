use AdventureWorks2022;

select CustomerID from Sales.Customer
left join Sales.SalesOrderDetail
on SalesOrderDetail.rowguid = Customer.rowguid
where SalesOrderDetail.rowguid is Null;

select CustomerID from Sales.Customer
where rowguid not in (select rowguid from Sales.SalesOrderDetail);

with OrderedCustomers as (
	select distinct rowguid
	from Sales.SalesOrderDetail
)
select CustomerId from Sales.Customer
left join OrderedCustomers on Customer.rowguid = OrderedCustomers.rowguid
where OrderedCustomers.rowguid is Null;

select CustomerID from Sales.Customer
where not exists (
	select 1 from Sales.SalesOrderDetail
	where Customer.rowguid = SalesOrderDetail.rowguid
);