Use master
IF NOT EXISTS (SELECT name FROM sys.Databases WHERE name = N'ClinicaDental') 
BEGIN
CREATE DATABASE [ClinicaDental]
END
GO

IF EXISTS (SELECT name FROM sys.Databases WHERE name = N'ClinicaDental') 
BEGIN
Use [ClinicaDental]

CREATE TABLE Sex
(
  id INT PRIMARY KEY IDENTITY(1,1),
  Sex CHAR(1) NOT NULL
)

CREATE TABLE JobPosition
(
  id INT PRIMARY KEY IDENTITY(1,1),
  Position VARCHAR(25) NOT NULL UNIQUE
)

CREATE TABLE Roles
(
  id INT PRIMARY KEY IDENTITY(1,1),
  Name VARCHAR(25) NOT NULL UNIQUE,
  Description VARCHAR(MAX)
)

CREATE TABLE Allergies
(
  id INT PRIMARY KEY IDENTITY(1,1),
  Name VARCHAR(35) NOT NULL UNIQUE,
)

CREATE TABLE Treatments
(
  id INT PRIMARY KEY IDENTITY(1,1),
  Name VARCHAR(50) NOT NULL UNIQUE,
  Description VARCHAR(MAX),
  Price FLOAT NOT NULL
)

CREATE TABLE SystemUsers
(
  id INT PRIMARY KEY IDENTITY(1,1),
  username VARCHAR(10) NOT NULL UNIQUE,
  password VARCHAR(64) NOT NULL,
  Name VARCHAR(60) NOT NULL,
  LastName VARCHAR(70) NOT NULL,
  ID_Sex INT NOT NULL FOREIGN KEY REFERENCES [Sex](id),
  DateBirth DATE NOT NULL,
  ID_JobPosition INT NOT NULL FOREIGN KEY REFERENCES [JobPosition](id),
  Adress VARCHAR(MAX) NOT NULL,
  CellPhone VARCHAR(16) NOT NULL,
  LandLinePhone VARCHAR(16) NOT NULL,
  Role INT NOT NULL FOREIGN KEY REFERENCES [Roles](id)
)

CREATE TABLE Patients
(
  id INT PRIMARY KEY IDENTITY(1,1),
  username VARCHAR(10) NOT NULL UNIQUE,
  password VARCHAR(64) NOT NULL,
  Name VARCHAR(60) NOT NULL,
  LastName VARCHAR(70) NOT NULL,
  ID_Sex INT NOT NULL FOREIGN KEY REFERENCES [Sex](id),
  DateBirth DATE NOT NULL,
  Adress VARCHAR(MAX) NOT NULL,
  CellPhone VARCHAR(16) NOT NULL,
  LandLinePhone VARCHAR(16) NOT NULL,
  ID_Treatments INT NOT NULL FOREIGN KEY REFERENCES [Treatments](id),
  ID_Allergies INT NOT NULL FOREIGN KEY REFERENCES [Allergies](id),
)

CREATE TABLE Appointments
(
  id INT PRIMARY KEY IDENTITY(1,1),
  ID_Patient INT NOT NULL FOREIGN KEY REFERENCES [Patients](id),
  ID_SystemUser INT NOT NULL FOREIGN KEY REFERENCES [SystemUsers](id),
  ID_Treatment INT NOT NULL FOREIGN KEY REFERENCES [Treatments](id),
  Observations VARCHAR(MAX),
  Date DATETIME NOT NULL,
)
END
GO

INSERT INTO [Sex] (Sex) VALUES
('M'), ('F')
GO

INSERT INTO [JobPosition] ([Position]) VALUES
('TechnicalSupport')
GO

INSERT INTO [Roles] (Name, [Description]) VALUES
('System Admin', 'Administrates all the application and database')
GO

INSERT INTO [SystemUsers] (username, password, Name, LastName, ID_Sex, DateBirth, ID_JobPosition, Adress, CellPhone, LandLinePhone, Role) VALUES
('admin', 
'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',
'Administrator',
'System',
'1',
GETDATE(),
'1',
'AN IMAGINE ADRESS',
'50371010101',
'50322010101',
'1')
GO