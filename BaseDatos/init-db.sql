CREATE DATABASE RealEstate;
GO
use RealEstate;
GO
CREATE TABLE Owner(
  IdOwner int PRIMARY KEY identity(1,1),
  Name varchar(60) Not Null,
  Address varchar(80) Not Null,
  City varchar(100) Not Null,
  Country varchar(40) Not Null,
  Phone varchar(25) Not Null,
  Birthday date
);

CREATE TABLE PropertyType
(
  IdPropertyType int PRIMARY KEY identity(1,1),
  Name varchar(100) Not null,
  Enabled bit default 1,
  CreateDate datetime,
  LastModified DateTime,
)

CREATE TABLE  Property
(
  IdProperty int primary key identity(1,1),
  Name varchar(60) not null,
  Details varchar(500) not null,
  price decimal(18,2) not null,
  CodeInternal varchar(10),
  City varchar(60),
  Country varchar(40),
  Address varchar(100) not null,
  Bedrooms int,
  Bathrooms int,
  Year int,
  IdOwner int,
  IdPropertyType int,
  CreateDate datetime,
  LastModified DateTime,
  Status varchar(20),
  FOREIGN KEY (IdOwner) REFERENCES Owner (IdOwner),
  FOREIGN KEY (IdPropertyType) REFERENCES PropertyType (IdPropertyType)
)

CREATE TABLE PropertyImage(
  IdPropertyImage int primary key identity(1,1),
  IdProperty int,
  FilePath varchar(200) not null,
  Enabled bit default 1
  FOREIGN KEY (IdProperty) REFERENCES Property (IdProperty),
)

CREATE TABLE PropertyTrace(
  IdPropertyTrace int primary key identity(1,1),
  DateSale datetime,
  Name varchar(100),
  Value decimal(18,2),
  Tax decimal(18,2),
  CreateDate datetime,
  LastModified DateTime,
  IdProperty int,
  FOREIGN KEY (IdProperty) REFERENCES Property (IdProperty),
)
--Infomacion semilla para base de datos.
GO
INSERT INTO Owner (Name,Address,City,Country,Phone) VALUES('Juan Lopez','Calle 35 via a la playa', 'Bogota','Colombia','+5734567890',GETDATE())
GO
INSERT INTO Owner (Name,Address,City,Country,Phone) VALUES('Jose Restrepo','Via Beach Miami', 'Miami','Estados Unidos','+5134567890',GETDATE())
GO
INSERT INTO PropertyType (Name,Enabled,CreateDate) VALUES ('Residencial',1,GETDATE())
GO
INSERT INTO PropertyType (Name,Enabled,CreateDate) VALUES ('Montañas',1,GETDATE())
