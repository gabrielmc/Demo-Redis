CREATE DATABASE BaseCotacoes
GO


USE BaseCotacoes
GO


CREATE TABLE dbo.Cotacoes(
	Sigla char(3) NOT NULL,
	NomeMoeda varchar(30) NOT NULL,
	UltimaCotacao datetime NOT NULL,
	ValorComercial NUMERIC (18,4) NOT NULL,
	ValorTurismo NUMERIC (18,4) NULL,
	CONSTRAINT PK_Cotacoes PRIMARY KEY (Sigla)
)
GO


INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,ValorComercial
	     ,ValorTurismo)
     VALUES
           ('USD'
           ,'Dólar norte-americano'
           ,'17.05.2019 16:59'
           ,4.1020
	     ,4.3200)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,ValorComercial)
     VALUES
           ('EUR'
           ,'Euro'
           ,'05/17/2019 16:59'
           ,4.5750)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,ValorComercial)
     VALUES
           ('LIB'
           ,'Libra esterlina'
           ,'05/17/2019 16:59'
           ,5.2155)
