CREATE PROCEDURE spCreateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document VARCHAR(11),
    @Email VARCHAR(60),
    @Phone VARCHAR(13)
AS
    INSERT INTO [Customer] (
        [Id],
        [FirstName],
        [LastName],
        [Document],
        [Email],
        [Phone]
    ) VALUES (
        @Id, 
        @FirstName, 
        @LastName, 
        @Document, 
        @Email, 
        @Phone
    )
