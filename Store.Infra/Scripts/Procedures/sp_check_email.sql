CREATE PROCEDURE spCheckEmail
    @Email VARCHAR(11)
AS
    SELECT CASE WHEN EXISTS (
        SELECT [Id]
            FROM [Customer]
        WHERE [Email] = @Email 
    )
    THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT) END