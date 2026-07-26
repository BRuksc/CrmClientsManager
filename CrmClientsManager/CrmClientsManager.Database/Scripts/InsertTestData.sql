USE CrmClientsManager;
GO

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
('Energo Polska Sp. z o.o.', '1000000006', 'Warszawa, ul. Marszałkowska 10', 'kontakt@energopolska.pl', '500100100', 'Company'),
('Green Power S.A.', '1000000012', 'Kraków, ul. Długa 15', 'biuro@greenpower.pl', '500100101', 'Company'),
('Eco Energy Sp. z o.o.', '1000000029', 'Wrocław, ul. Legnicka 45', 'office@ecoenergy.pl', '500100102', 'Company'),
('Gaz-System Partner Sp. z o.o.', '1000000035', 'Poznań, ul. Święty Marcin 12', 'kontakt@gspartner.pl', '500100103', 'Company'),
('Power Solutions Sp. z o.o.', '1000000041', 'Gdańsk, ul. Grunwaldzka 80', 'biuro@powersolutions.pl', '500100104', 'Company'),

('Jan Kowalski', '1000000058', 'Warszawa, ul. Jana Pawła II 25', 'jan.kowalski@gmail.com', '500100105', 'Individual'),
('Anna Nowak', '1000000064', 'Łódź, ul. Piotrkowska 77', 'anna.nowak@gmail.com', '500100106', 'Individual'),
('Piotr Zieliński', '1000000070', 'Szczecin, ul. Wojska Polskiego 8', 'zielinski.piotr@gmail.com', '500100107', 'Individual'),
('Magdalena Wiśniewska', '1000000087', 'Katowice, ul. Chorzowska 11', 'm.wisniewska@gmail.com', '500100108', 'Individual'),
('Tomasz Kamiński', '1000000093', 'Lublin, ul. Lipowa 9', 't.kaminski@gmail.com', '500100109', 'Individual'),

('Solar Future Sp. z o.o.', '1000000101', 'Bydgoszcz, ul. Dworcowa 19', 'kontakt@solarfuture.pl', '500100110', 'Company'),
('Blue Energy S.A.', '1000000118', 'Białystok, ul. Mickiewicza 31', 'office@blueenergy.pl', '500100111', 'Company'),
('Energy Trade Sp. z o.o.', '1000000124', 'Rzeszów, ul. Rejtana 50', 'biuro@energytrade.pl', '500100112', 'Company'),

('Karolina Maj', '1000000130', 'Opole, ul. Ozimska 23', 'karolina.maj@gmail.com', '500100113', 'Individual'),
('Michał Wójcik', '1000000147', 'Olsztyn, ul. Kościuszki 18', 'm.wojcik@gmail.com', '500100114', 'Individual'),

('Volt Polska Sp. z o.o.', '1000000153', 'Kielce, ul. Seminaryjska 5', 'kontakt@voltpolska.pl', '500100115', 'Company'),
('Smart Energy Group Sp. z o.o.', '1000000176', 'Toruń, ul. Szosa Chełmińska 14', 'biuro@smartenergy.pl', '500100116', 'Company'),

('Natalia Lewandowska', '1000000182', 'Gdynia, ul. Świętojańska 101', 'n.lewandowska@gmail.com', '500100117', 'Individual'),
('Kamil Dąbrowski', '1000000199', 'Radom, ul. Żeromskiego 27', 'k.dabrowski@gmail.com', '500100118', 'Individual'),

('Energia dla Biznesu Sp. z o.o.', '1000000207', 'Częstochowa, ul. Wolności 30', 'kontakt@edb.pl', '500100119', 'Company');
GO

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
SELECT TOP 10
    CustomerId,
    CONCAT('CON-', CustomerId),
    DATEADD(MONTH, -6, GETDATE()),
    DATEADD(YEAR, 1, GETDATE()),
    CASE 
        WHEN CustomerId % 2 = 0 THEN 'Gas'
        ELSE 'Electricity'
    END,
    5000 + CustomerId * 500,
    'Active'
FROM Customers;
GO