# Projeto Final Atos EColeta #

* [Escopo](#escopo)
* [Requisitos](#requisitos)
* [Dicas](#dicas)
* [Entregas Mínimas](#entregas)
* [Criterios de Avaliacao](#criterios)
* [Informacoes Projeto](#informacoes)
* [Setup](#setup)

## Escopo

A empresa fictícia NetBull precisa desenvolver alguns microsserviços em DotNET
para compor funções que atendam o negócio da empresa, você poderá escolher entre
alguns domínios como Pedido, Pagamento, Cliente ou Orçamento.
Esses microsserviços devem expor API’s atendendo o padrão Restful e com uma documentação no modelo
Swagger.
Construir uma outra aplicação com a única finalidade de consumir eventos e
expor consulta desses eventos deve ser construída para consumir os eventos gerados
pela API principal escolhida e que irá registrar esses eventos em banco de dados.



***Versionamento** = Git*

**Persistenticia =** EnitityFramework **;** UnitOfWork;

**Segurança =** JwtBearerToken com filtro para Roles. ; Criptografia;

**Mapemanto Enditades** = AutoMapper





## Requisitos

* [ ] Criação de um microsserviço de Domínio e uma API consumidora dos eventos.
* [ ] Estrutura de dados a serem criados deve ser coerente assim como os tipos de dados.
* [ ] Deve conter uma entidade forte do Domínio, e que deve ter pelo menos um relacionamento um-para-muitos
* [ ] Microsserviço deve ter no mínimo 90% de cobertura nos testes.
* [ ] Regra de negócio inserida no microsserviço fica a critério, porém quanto mais regras, melhor.
* [ ] Os testes de integração devem conter um fluxo com sucesso e um com validação para cada API criada (GET/POST/PUT/PATCH/DELETE).
* [ ] Disponibilizar uma documentação do microsserviço com Swagger

## Dicas

* Crie um desenho dos componentes a serem criados para abstrair os cenários.
* Esse desafio está repleto de dicas realizadas em aula.

## Entregas

* Microsserviço com as API’s respeitando o modelo Restful;
* Acesso ao banco de dados com framework de persistência;
* Cobertura de teste;

## Criterios

* Boa práticas de Orientação a Objeto
* Validação de testes cobrindo o que realmente deve ser coberto
* Ao executar todas as funcionalidades devem ser executadas ou pelo Swagger ou pelo Postman, simulando uma  entre os sistemas, sem erros sistêmicos, apenas com erros de validação de negócio será aceita

## Informacoes

Final Project Atos...

### Tecnologias

* Net Framework 5.0.403
* Entity Framework

## Setup

Para rodar o programa execute os seguintes comandos.

```
$ cd ../ProjetoFinalAtos
$ dotnet restore
$ dotnet run 
```
