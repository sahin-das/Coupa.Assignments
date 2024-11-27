-- Exercise 5: Write a Procedure supplying name information from the Person.Person table and 
-- accepting a filter for the first name. Alter the above Store Procedure to supply Default 
-- Values if user does not enter any value.


ALTER PROCEDURE dbo.GetPersonDetails
    @FirstName NVARCHAR(50) = NULL
AS
BEGIN
    -- If the user does not supply a value for @FirstName, select all records
    SELECT BusinessEntityID, FirstName, LastName, EmailPromotion
    FROM Person.Person
    WHERE (@FirstName IS NULL OR FirstName = @FirstName);
END;


EXEC dbo.GetPersonDetails;