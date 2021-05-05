create database vetClinic
go

use vetClinic
go


create table Owners
(
	IdOwner UNIQUEIDENTIFIER not null PRIMARY KEY,
	FirstName varchar(250) not null,
	LastName varchar(250) not null,
	Phone varchar(50) null,
	Email varchar(250) null,
	Address varchar(250) not null
)

create table Pets
(
	IdPet UNIQUEIDENTIFIER not null PRIMARY KEY,
	Name varchar(250) not null,
	Species varchar(250) not null,
	Race varchar(250) not null,	
	IdOwner UNIQUEIDENTIFIER not null,

	CONSTRAINT [FK_Pets_Owners] FOREIGN KEY (IdOwner) REFERENCES [Owners](IdOwner)
)

create table Vets
(
	IdVet  UNIQUEIDENTIFIER not null PRIMARY KEY,
	FirstName varchar(250) not null,
	LastName varchar(250) not null,
	Specialization varchar(250) not null,
	Phone varchar(50) null,
	Email varchar(250) null	
)

create table Consultations
(
	IdConsultation UNIQUEIDENTIFIER not null PRIMARY KEY,
	IdVet UNIQUEIDENTIFIER not null,
	IdPet UNIQUEIDENTIFIER not null,
	IdOwner UNIQUEIDENTIFIER not null,
	Description varchar(250) not null,
	Recomandation varchar(max) not null,
	EventDate datetime not null,

	CONSTRAINT [FK_Consultations_Vets] FOREIGN KEY (IdVet) REFERENCES [Vets](IdVet),
	CONSTRAINT [FK_Consultations_Pets] FOREIGN KEY (IdPet) REFERENCES [Pets](IdPet),
	CONSTRAINT [FK_Consultations_Owners] FOREIGN KEY (IdOwner) REFERENCES [Owners](IdOwner)
)

create table Invoices
(
	IdInvoice UNIQUEIDENTIFIER not null PRIMARY KEY,
	IdConsultation UNIQUEIDENTIFIER not null,
	IdOwner UNIQUEIDENTIFIER not null,
	Price decimal not null,
	EventDate datetime not null

	CONSTRAINT [FK_Invoices_Consultations] FOREIGN KEY (IdConsultation) REFERENCES [Consultations](IdConsultation),
	CONSTRAINT [FK_Invoices_Owners] FOREIGN KEY (IdOwner) REFERENCES [Owners](IdOwner)
)


