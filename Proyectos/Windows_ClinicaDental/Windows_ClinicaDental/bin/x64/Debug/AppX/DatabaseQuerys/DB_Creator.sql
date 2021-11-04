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
  Sex VARCHAR(9) NOT NULL
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
  ID_Sex INT NOT NULL FOREIGN KEY REFERENCES [Sex](id) ON DELETE CASCADE,
  DateBirth DATE NOT NULL,
  ID_JobPosition INT NOT NULL FOREIGN KEY REFERENCES [JobPosition](id) ON DELETE CASCADE,
  Address VARCHAR(MAX) NOT NULL,
  CellPhone VARCHAR(16) NOT NULL,
  LandLinePhone VARCHAR(16) NOT NULL,
  Role INT NOT NULL FOREIGN KEY REFERENCES [Roles](id) ON DELETE CASCADE
)

CREATE TABLE Patients
(
  id INT PRIMARY KEY IDENTITY(1,1),
  username VARCHAR(10) NOT NULL UNIQUE,
  password VARCHAR(64) NOT NULL,
  Name VARCHAR(60) NOT NULL,
  LastName VARCHAR(70) NOT NULL,
  ID_Sex INT NOT NULL FOREIGN KEY REFERENCES [Sex](id) ON DELETE CASCADE,
  DateBirth DATE NOT NULL,
  Address VARCHAR(MAX) NOT NULL,
  CellPhone VARCHAR(16) NOT NULL,
  LandLinePhone VARCHAR(16) NOT NULL,
  ID_Treatments INT NOT NULL FOREIGN KEY REFERENCES [Treatments](id) ON DELETE CASCADE,
  ID_Allergies INT NOT NULL FOREIGN KEY REFERENCES [Allergies](id) ON DELETE CASCADE,
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

--CREAR DATOS PARA EL ADMINISTRADOR INICIAL
INSERT INTO [Sex] (Sex) VALUES
('Masculino'), ('Femenino')
GO

INSERT INTO [JobPosition] ([Position]) VALUES
('Soporte Tecnico')
GO

INSERT INTO [Roles] (Name, [Description]) VALUES
('Admin del Sistema', 'Administra toda la aplicacion y la BD')
GO

--CREDENCIALES: Username: admin Password: admin (encriptado en SHA256)
INSERT INTO [SystemUsers] (username, password, Name, LastName, ID_Sex, DateBirth, ID_JobPosition, Address, CellPhone, LandLinePhone, Role) VALUES
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

--CREA OTRAS ENTRADAS PARA PRUEBA
INSERT INTO [Roles] VALUES
('Basic User', 'User with the lowest privileges of all program. Just for test.'),
('Tester User', 'User with the middle of privileges of all program. Just for test.'),
('Advanced User', 'User with the almost high privileges of all program. Just for test.')
GO

INSERT INTO [JobPosition] VALUES
('Secretaria'), ('Dentista'), ('Ortodoncista'), ('Tester')
GO

INSERT INTO [SystemUsers] (username, password, Name, LastName, ID_Sex, DateBirth, ID_JobPosition, Address, CellPhone, LandLinePhone, Role) VALUES
--PWD = pass
('josueAyala', 'd74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1', 'Josue Alfonso', 'Ayala', 1, GETDATE(), 5, 'UNA DIRECCION', '70707070','21212121', 4)
GO

INSERT INTO [Allergies] VALUES 
('Resinas'), ('Metales'), ('Primers o adhesivos dentales'), ('Materiales de impresión'), ('Anestesia local')
GO