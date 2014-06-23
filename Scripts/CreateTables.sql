USE Test

if exists (select * from sys.objects where object_id = OBJECT_ID('Person')) drop table Person

create table Person
(
	Id UNIQUEIDENTIFIER Default newid() primary key,
	fName varchar(50),
	sName varchar(50),
	Borough varchar(50)
)

if exists(select * from sys.objects where object_id = OBJECT_ID('Address')) drop table Address

create table Address
(
	Id UNIQUEIDENTIFIER Default newid() primary key,
	HouseNumber varchar(50),
	StreetName varchar(50),
	PostCode varchar(50),
	City varchar(50)
)

if exists(select * from sys.objects where object_id = OBJECT_ID('Borough')) drop table Borough

create table Borough
(
	Id UNIQUEIDENTIFIER Default newid() primary key,
	Name varchar(50)
)