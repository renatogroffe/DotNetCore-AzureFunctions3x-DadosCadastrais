USE BaseDadosCadastrais
GO

CREATE TABLE dbo.DadosCadastrais(
    Id INT IDENTITY(1,1) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Nome VARCHAR(70) NOT NULL,
    DataNascimento DATETIME NOT NULL,
    DtInclusao DATETIME NOT NULL,
    DtAlteracao DATETIME NULL,
    CodEstado CHAR(2) NOT NULL,
    Formacao VARCHAR(50) NOT NULL,
    AreaAtuacao VARCHAR(50) NOT NULL,
    FlCertificacao BIT NOT NULL,
    Salario NUMERIC(10,4) NOT NULL,
    CONSTRAINT PK_DadosCadastrais PRIMARY KEY (Id),
    CONSTRAINT UK_DadosCadastrais_Email UNIQUE (Email)
)
GO

ALTER TABLE dbo.DadosCadastrais ALTER COLUMN Email
ADD MASKED WITH (FUNCTION = 'email()')

ALTER TABLE dbo.DadosCadastrais ALTER COLUMN Nome
ADD MASKED WITH (FUNCTION = 'default()')

ALTER TABLE dbo.DadosCadastrais ALTER COLUMN Salario
ADD MASKED WITH (FUNCTION = 'default()')

USE master
GO

CREATE LOGIN testedatamasks
    WITH PASSWORD = 'SENHA';


USE BaseDadosCadastrais
GO

CREATE USER testedatamasks FOR LOGIN testedatamasks;
GO

EXEC sp_addrolemember 'db_datareader', 'testedatamasks'