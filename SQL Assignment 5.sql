ALTER PROCEDURE dbo.searchPerson
	@FirstName NVARCHAR(50)
AS
BEGIN
	if exists(
		select FirstName + ' ' + LastName as Name
		from Person.Person as p
		where p.FirstName = @FirstName
	) 	select FirstName + ' ' + LastName as Name
		from Person.Person as p
		where p.FirstName = @FirstName
	else
		select 'John Doe' as Name
END;