-- SQLite
--Transferir dados para nova tabela
INSERT INTO Cliente(Id, Nome, DataNascimento, Endereco, Renda)
SELECT Id, Nome, DataNascimento, Endereco, Renda FROM Cliente_Old;

--Apagar tabela Cliente 
DROP TABLE Cliente;

--Apagar tabela Cliente Old
DROP TABLE Cliente_Old;

--Criar nova tabela Cliente
CREATE TABLE Cliente(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Nome TEXT,
DataNascimento TEXT NOT NULL,
Endereco TEXT,
Renda TEXT NOT NULL,
Cargo TEXT
);

--Criar tabela Imovel

CREATE TABLE Imovel(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Tipo TEXT,
Descricao TEXT
);

--Apagar Tabela Imovel
DROP TABLE Imovel;

-- Renomear a tabela Clientes
ALTER TABLE Cliente RENAME TO Cliente_Old;


