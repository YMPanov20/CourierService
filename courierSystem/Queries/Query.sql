
CREATE DATABASE CourierServiceSystem
USE CourierServiceSystem

CREATE TABLE AdminAccounts(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL,
	Pass VARCHAR(50) NOT NULL,
);
INSERT INTO AdminAccounts (UserName, Pass) VALUES ('Admin','Admin123')

CREATE TABLE Cities (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    CityName VARCHAR(255)
);
INSERT INTO Cities (CityName) VALUES
    ('Burgas'),
    ('Varna'),
    ('Veliko Tarnovo'),
    ('Plovdiv'),
    ('Sofia');

CREATE TABLE Offices (
    OfficeID INT PRIMARY KEY IDENTITY(1,1),
    OfficeName VARCHAR(255),
    CityID INT,
    FOREIGN KEY (CityID) REFERENCES Cities(CityID)
);
INSERT INTO Offices (OfficeName, CityID) VALUES
	('Burgas Center 1', (SELECT CityID FROM Cities WHERE CityName = 'Burgas')),
    ('Burgas Center 2', (SELECT CityID FROM Cities WHERE CityName = 'Burgas')),
    ('Burgas Zornica', (SELECT CityID FROM Cities WHERE CityName = 'Burgas')),
    ('Varna Center 1', (SELECT CityID FROM Cities WHERE CityName = 'Varna')),
    ('Varna Center 2', (SELECT CityID FROM Cities WHERE CityName = 'Varna')),
    ('Varna Levski', (SELECT CityID FROM Cities WHERE CityName = 'Varna')),
    ('Sofia Center 1', (SELECT CityID FROM Cities WHERE CityName = 'Sofia')),
    ('Sofia Center 2', (SELECT CityID FROM Cities WHERE CityName = 'Sofia')),
    ('Sofia Lulin', (SELECT CityID FROM Cities WHERE CityName = 'Sofia')),
    ('Plovdiv Center 1', (SELECT CityID FROM Cities WHERE CityName = 'Plovdiv')),
    ('Plovdiv Center 2', (SELECT CityID FROM Cities WHERE CityName = 'Plovdiv')),
    ('Plovdiv Trakiq', (SELECT CityID FROM Cities WHERE CityName = 'Plovdiv')),
    ('Veliko Tarnovo Center 1', (SELECT CityID FROM Cities WHERE CityName = 'Veliko Tarnovo')),
    ('Veliko Tarnovo Center 2', (SELECT CityID FROM Cities WHERE CityName = 'Veliko Tarnovo')),
    ('Veliko Tarnovo Kartala', (SELECT CityID FROM Cities WHERE CityName = 'Veliko Tarnovo'));


CREATE TABLE Shipments (
    ShipmentID INT PRIMARY KEY IDENTITY(1,1),
    ReceiverName VARCHAR(255) NOT NULL,
    SenderName VARCHAR(255) NOT NULL,
    ReceiverPhoneNumber VARCHAR(20) NOT NULL,
    SenderPhoneNumber VARCHAR(20) NOT NULL,
    ShipmentDetails VARCHAR(50) NOT NULL,
    ShipmentWeight INT NOT NULL,
    ShipmentTrackingId INT DEFAULT (NEXT VALUE FOR ShipmentTrackingIdSequence) UNIQUE,
    OfficeID INT,
    DestinationOfficeID INT,
    FOREIGN KEY (OfficeID) REFERENCES Offices(OfficeID),
    FOREIGN KEY (DestinationOfficeID) REFERENCES Offices(OfficeID),
);
DROP TABLE Shipments
CREATE SEQUENCE ShipmentTrackingIdSequence
    START WITH 100000
    INCREMENT BY 1;

INSERT INTO Shipments (ReceiverName, SenderName, ReceiverPhoneNumber, SenderPhoneNumber, ShipmentDetails, ShipmentWeight, OfficeID, DestinationOfficeID) VALUES ('Receiver1', 'Sender1', '111-222-3333', '444-555-6666', 'Sample details', 10, (SELECT OfficeID FROM Offices WHERE OfficeName = 'Burgas Center 1'), (SELECT OfficeID FROM Offices WHERE OfficeName = 'Burgas Zornica'));
SELECT S.ShipmentID, S.ReceiverName, S.SenderName, S.ReceiverPhoneNumber, S.SenderPhoneNumber, S.ShipmentDetails, S.ShipmentWeight, S.ShipmentTrackingId, O1.OfficeName AS SourceOfficeName, O2.OfficeName AS DestinationOfficeName FROM Shipments S JOIN Offices O1 ON S.OfficeID = O1.OfficeID JOIN Offices O2 ON S.DestinationOfficeID = O2.OfficeID;
DROP TABLE Shipments
SELECT * FROM Shipments