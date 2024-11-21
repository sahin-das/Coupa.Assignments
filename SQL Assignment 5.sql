-- Exercise 5: Write a Procedure supplying name information from the Person.Person table and 
-- accepting a filter for the first name. Alter the above Store Procedure to supply Default 
-- Values if user does not enter any value.


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