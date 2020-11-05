CREATE PROCEDURE spGetCustomerOrdersCount
    @Document VARCHAR(11)
AS    
SELECT
        c.[Id],
        CONCAT(c.[FirstName], ' ', c.[LastName]) [Name],
        c.[Document],
		COUNT(o.Id) [Orders]
    FROM [Customer] c
        INNER JOIN [Order] o ON o.[CustomerId] = c.[Id]
	WHERE c.[Document] = @Document
		GROUP BY c.[Id], c.[FirstName], c.[LastName], c.[Document]