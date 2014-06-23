USE Test

if exists (select * from sys.objects where object_id = OBJECT_ID('Person')) drop table Person

create table Person
(
	Id int not null primary key,
	fName varchar(50),
	sName varchar(50)
)

if exists(select * from sys.objects where object_id = OBJECT_ID('Address')) drop table Address

create table Address
(
	Id int not null primary key,
	HouseNumber varchar(50),
	StreetName varchar(50),
	PostCode varchar(50),
	City varchar(50)
)