use master
go
create database BDPosto
go
use BDPosto
go
create table Posto
(
	id int identity(1,1) primary key,
	Nome varchar(100) not null
)
go
create table Motorista
(
	id int identity(1,1) primary key,
	Nome varchar(100) not null,
	idade int not null,
	
)
go
Create table TipoCombustivel
(
	id int identity(1,1) primary key,
	Descricao varchar(100) not null
)
go
create table Veiculo
(
	id int identity(1,1) primary key,
	Marca varchar(100) not null,
	TipoCombustivel int,
	Motorista int,

	Constraint FK_CombustivelVeiculo foreign key (TipoCombustivel) references TipoCombustivel(id),
	Constraint FK_MotoristaVeiculo foreign key (Motorista) references Motorista(id)
)
go
create table OrdemServico
(
	id int identity(1,1) primary key,
	ValorLitro float,
	DataOrdem datetime,
	QtdCombustivel float,
	IdMotorista int,
	idPosto int,

	Constraint FK_PostoServico foreign key (idPosto) references Posto(id),
	Constraint FK_MostoristaServico foreign key (IdMotorista) references Motorista(id)
)