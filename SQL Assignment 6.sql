-- Exercise 6: Write a trigger for the Product table to ensure the list price can
-- never be raised more than 15 Percent in a single change. Modify the above trigger
-- to execute its check code only if the ListPrice column is updated


CREATE TRIGGER enforce_price_rule
ON Production.Product
for update
as
begin
	DECLARE @oldPrice int, @newPrice int
	select @oldPrice=a.ListPrice, @newPrice=b.ListPrice
	from inserted a, deleted b
	IF @newPrice > (@oldPrice * 1.15)
	BEGIN
		PRINT 'Cannnot raised more than 15 Percent in a single change'
		ROLLBACK TRAN
	END
END;