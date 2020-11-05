CREATE PROCEDURE spCreateAddress
    @Id UNIQUEIDENTIFIER,
    @CustomerId UNIQUEIDENTIFIER,
    @Number VARCHAR(10),
    @Complement VARCHAR(10),
    @District VARCHAR(60),
    @City VARCHAR(60),
    @State VARCHAR(2),
    @Country VARCHAR(2),
    @ZipCode VARCHAR(8),
    @Type INT
AS
    INSERT INTO [Address] (
        [Id],
        [CustomerId],
        [Number],
        [Complement],
        [District],
        [City],
        [State],
        [Country],
        [ZipCode],
        [Type]
    ) VALUES (
        @Id, 
        @CustomerId, 
        @Number, 
        @Complement, 
        @District, 
        @City, 
        @State, 
        @Country, 
        @ZipCode, 
        @Type
    )
