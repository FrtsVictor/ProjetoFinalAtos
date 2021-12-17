# Projeto Final Atos EColeta #






## Escopo

O projeto Garbage Collector consiste em uma API.NET para cadastro de empresas que coletam resíduos. Possui autenticação por tipo de acesso e criptografia para guardar a senha no banco.


## Colaboradores ##
@Anderson-MS
@breno2012
@joaopgreg
@ThiagoCunhaDev
@WALERIAMF

## Tecnologia

**Net Framework 6.0.0

***Versionamento** = Git*

**Persistência =** EnitityFramework **;** UnitOfWork;
**Database = Sql Server**

**Segurança =** JwtBearerToken com filtro para Roles. ; Criptografia;

**Mapemanto Entidades** = AutoMapper

**Arquitetura = DDD, RepositoryPatern, UnitOfWork**

## Arquitetura do Banco ##

![Alt text](/diagrama.png?raw=true "Optional Title")



## Setup

Para rodar o programa execute os seguintes comandos.

```
$ cd ../ProjetoFinalAtos
$ dotnet restore
$ dotnet run 
```
