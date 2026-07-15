USE CrmClientsManager;
GO


CREATE TABLE Customers
(
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,

    Name NVARCHAR(200) NOT NULL,

    Nip CHAR(10) NOT NULL UNIQUE,

    Address NVARCHAR(300) NULL,

    Email NVARCHAR(150) NULL,

    Phone NVARCHAR(50) NULL,

    CustomerType VARCHAR(20) NOT NULL
        CHECK(CustomerType IN ('Company', 'Individual')),

    CreatedDate DATETIME2 NOT NULL
        DEFAULT GETDATE()
);
GO


CREATE TABLE Contracts
(
    ContractId INT IDENTITY(1,1) PRIMARY KEY,

    CustomerId INT NOT NULL,

    ContractNumber NVARCHAR(50) NOT NULL UNIQUE,

    DateFrom DATE NOT NULL,

    DateTo DATE NOT NULL,

    EnergyType VARCHAR(20) NOT NULL
        CHECK(EnergyType IN ('Electricity', 'Gas')),

    AnnualValue DECIMAL(12,2) NOT NULL,

    Status VARCHAR(20) NOT NULL
        CHECK(Status IN ('Active', 'Expired', 'Terminated')),


    CONSTRAINT FK_Contracts_Customers
        FOREIGN KEY(CustomerId)
        REFERENCES Customers(CustomerId)
        ON DELETE CASCADE
);
GO


CREATE TABLE Tickets
(
    TicketId INT IDENTITY(1,1) PRIMARY KEY,

    CustomerId INT NOT NULL,

    ContractId INT NULL,

    Subject NVARCHAR(200) NOT NULL,

    Description NVARCHAR(MAX) NULL,

    Priority VARCHAR(20) NOT NULL
        CHECK(Priority IN ('Low','Medium','High')),

    Status VARCHAR(20) NOT NULL
        CHECK(Status IN ('New','InProgress','Closed')),

    CreatedDate DATETIME2 NOT NULL
        DEFAULT GETDATE(),

    ClosedDate DATETIME2 NULL,

    ResolutionComment NVARCHAR(MAX) NULL,


    CONSTRAINT FK_Tickets_Customers
        FOREIGN KEY(CustomerId)
        REFERENCES Customers(CustomerId)
        ON DELETE CASCADE,


    CONSTRAINT FK_Tickets_Contracts
        FOREIGN KEY(ContractId)
        REFERENCES Contracts(ContractId)
);
GO