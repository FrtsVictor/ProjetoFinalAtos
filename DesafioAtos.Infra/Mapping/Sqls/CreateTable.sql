CREATE TABLE Usuario (
    id INT PRIMARY KEY IDENTITY (1, 1),
    nome VARCHAR(80) NOT NULL,
    role INT NOT NULL,
    data_criacao SMALLDATETIME DEFAULT GETDATE(),
    login VARCHAR (25) NOT NULL UNIQUE,
    senha VARCHAR (200) NOT NULL,
    
    CONSTRAINT Usuario_Constraint_UNIQUE_Login UNIQUE(login)   
);


CREATE TABLE Empresa_Coletora (
    id INT PRIMARY KEY IDENTITY (1, 1),
    senha VARCHAR(200) NOT NULL,
    data_criacao SMALLDATETIME DEFAULT GETDATE(),
    nome VARCHAR(80) NOT NULL,
    role INT NOT NULL,
    cnpj CHAR(14) NOT NULL,
    telefone CHAR(11) NOT NULL,
    email VARCHAR(80) NOT NULL,
    
    CONSTRAINT Empresa_Coletora_Constraint_UNIQUE_Cnpj UNIQUE(cnpj),
    CONSTRAINT Empresa_Coletora_Constraint_UNIQUE_Telefone UNIQUE(telefone),
    CONSTRAINT Empresa_Coletora_Constraint_UNIQUE_Nome UNIQUE(nome),
    CONSTRAINT Empresa_Coletora_Constraint_UNIQUE_Email UNIQUE(email)
);


CREATE TABLE Endereco (
    id INT PRIMARY KEY IDENTITY (1, 1),
    status BIT,
    data_criacao SMALLDATETIME DEFAULT GETDATE() NOT NULL,
    numero VARCHAR (8) NOT NULL,
    complemento VARCHAR(20),
    rua VARCHAR(100) NOT NULL,
    cep VARCHAR(8) NOT NULL,
    cidade VARCHAR(50) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    bairro VARCHAR(20) NOT NULL,
    id_empresa_coletora int REFERENCES Empresa_Coleta (id),    
)

CREATE TABLE Categoria (
    id INT PRIMARY KEY IDENTITY (1, 1),
    data_criacao SMALLDATETIME DEFAULT GETDATE(),
    nome VARCHAR(80) NOT NULL,

    CONSTRAINT Categoria_Constraint_Unique_Nome UNIQUE(nome)
);


CREATE TABLE Categoria_Usuario (
    id INT PRIMARY KEY IDENTITY (1, 1) ,
    id_categoria int REFERENCES Categoria (id) ON DELETE SET NULL,
    id_usuario int REFERENCES Usuario (id) ON DELETE SET NULL
);

CREATE TABLE Categoria_Empresa (
    id INT PRIMARY KEY IDENTITY (1, 1) ,
    id_categoria int REFERENCES Categoria (id) ON DELETE SET NULL,
    id_empresa_coletora int REFERENCES EmpresaColetora (id) ON DELETE SET NULL
);
