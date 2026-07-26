USE CrmClientsManager;
GO

CREATE OR ALTER PROCEDURE Customer_Update
(
    @CustomerId INT,
    @Name NVARCHAR(200),
    @Nip CHAR(10),
    @Address NVARCHAR(300),
    @Email NVARCHAR(150),
    @Phone NVARCHAR(50),
    @CustomerType VARCHAR(20)
)
AS
BEGIN
    UPDATE Customers
    SET
        Name = @Name,
        Nip = @Nip,
        Address = @Address,
        Email = @Email,
        Phone = @Phone,
        CustomerType = @CustomerType
    WHERE CustomerId = @CustomerId;


    SELECT @CustomerId AS CustomerId;
END
GO

CREATE OR ALTER PROCEDURE Customer_GetAll
AS
BEGIN
    SELECT
        CustomerId,
        Name,
        Nip,
        Address,
        Email,
        Phone,
        CustomerType
    FROM Customers
    ORDER BY Name;
END
GO

CREATE PROCEDURE Contract_GetAll
AS
BEGIN
    SELECT *
    FROM Contracts
END
GO


CREATE OR ALTER PROCEDURE Customer_GetById
(
    @CustomerId INT
)
AS
BEGIN
    SELECT *
    FROM Customers
    WHERE CustomerId = @CustomerId;
END
GO


CREATE OR ALTER PROCEDURE Customer_Insert
(
    @Name NVARCHAR(200),
    @Nip CHAR(10),
    @Address NVARCHAR(300),
    @Email NVARCHAR(150),
    @Phone NVARCHAR(50),
    @CustomerType VARCHAR(20)
)
AS
BEGIN

    INSERT INTO Customers
    (
        Name,
        Nip,
        Address,
        Email,
        Phone,
        CustomerType
    )
    VALUES
    (
        @Name,
        @Nip,
        @Address,
        @Email,
        @Phone,
        @CustomerType
    );


    SELECT SCOPE_IDENTITY() AS CustomerId;

END
GO



CREATE OR ALTER PROCEDURE Customer_Delete
(
    @CustomerId INT
)
AS
BEGIN

    DELETE FROM Customers
    WHERE CustomerId = @CustomerId;

END
GO

CREATE OR ALTER PROCEDURE Contract_Insert
(
    @CustomerId INT,
    @ContractNumber NVARCHAR(50),
    @DateFrom DATE,
    @DateTo DATE,
    @EnergyType VARCHAR(20),
    @AnnualValue DECIMAL(12,2)
)
AS
BEGIN
    IF EXISTS
    (
        SELECT 1
        FROM Contracts
        WHERE CustomerId = @CustomerId
          AND EnergyType = @EnergyType
          AND Status = 'Active'
          AND @DateFrom <= DateTo
          AND @DateTo >= DateFrom
    )
    BEGIN
        THROW 50001,
        'Customer already has active contract for this energy type.',
        1;
    END


    INSERT INTO Contracts
    (
        CustomerId,
        ContractNumber,
        DateFrom,
        DateTo,
        EnergyType,
        AnnualValue,
        Status
    )
    VALUES
    (
        @CustomerId,
        @ContractNumber,
        @DateFrom,
        @DateTo,
        @EnergyType,
        @AnnualValue,
        'Active'
    );


    SELECT SCOPE_IDENTITY() AS ContractId;

END
GO



CREATE OR ALTER PROCEDURE Contract_GetByCustomer
(
    @CustomerId INT
)
AS
BEGIN

    SELECT *
    FROM Contracts
    WHERE CustomerId = @CustomerId
    ORDER BY DateFrom DESC;

END
GO

CREATE OR ALTER PROCEDURE Ticket_GetOpen
AS
BEGIN

    SELECT
        t.*,
        c.Name AS CustomerName
    FROM Tickets t
    JOIN Customers c
        ON c.CustomerId = t.CustomerId
    WHERE t.Status <> 'Closed'
    ORDER BY t.CreatedDate;

END
GO



CREATE OR ALTER PROCEDURE Ticket_Close
(
    @TicketId INT,
    @ResolutionComment NVARCHAR(MAX),
    @ClosedDate DATETIME2
)
AS
BEGIN


    IF @ResolutionComment IS NULL
       OR LTRIM(RTRIM(@ResolutionComment)) = ''
    BEGIN

        THROW 50002,
        'Resolution comment is required.',
        1;

    END


    UPDATE Tickets
    SET
        Status = 'Closed',
        ClosedDate = @ClosedDate,
        ResolutionComment = @ResolutionComment
    WHERE TicketId = @TicketId;


END
GO

CREATE OR ALTER PROCEDURE Dashboard_GetActiveCustomers
AS
BEGIN

    SELECT COUNT(*)
    FROM Customers c
    WHERE EXISTS
    (
        SELECT 1
        FROM Contracts ct
        WHERE ct.CustomerId = c.CustomerId
          AND ct.Status = 'Active'
    );

END
GO



CREATE OR ALTER PROCEDURE Dashboard_GetExpiringContracts
AS
BEGIN

    SELECT COUNT(*)
    FROM Contracts
    WHERE Status = 'Active'
      AND DateTo BETWEEN GETDATE()
                     AND DATEADD(DAY,30,GETDATE());

END
GO



CREATE OR ALTER PROCEDURE Dashboard_GetTicketsByPriority
AS
BEGIN

    SELECT
        Priority,
        COUNT(*) AS Amount
    FROM Tickets
    WHERE Status <> 'Closed'
    GROUP BY Priority;

END
GO

CREATE OR ALTER PROCEDURE Ticket_Create
(
    @CustomerId INT,
    @ContractId INT = NULL,
    @Subject NVARCHAR(200),
    @Description NVARCHAR(MAX),
    @Priority NVARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Tickets
    (
        CustomerId,
        ContractId,
        Subject,
        Description,
        Priority,
        Status,
        CreatedDate
    )
    VALUES
    (
        @CustomerId,
        @ContractId,
        @Subject,
        @Description,
        @Priority,
        'New',
        GETDATE()
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
GO