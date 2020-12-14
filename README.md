Este é o arquivo README para auxiliar na utilização do projeto.

[[_TOC_]]

## Configurações da Solution

### A Solution
  A solution foi desenvolvida utilizando Visual Studio 2019 Community
  A solution consiste de 7 Projetos, sendo que 2 são de Startup
  - BenFattoLog.API
  - BenFattoLog.UI
  Os dois devem rodar ao mesmo tempo a partir do Visual Studio

### Script Banco de Dados

#### String de Conexão
  A string de conexão caso seja necessário mudar se encontra no arquivo da classe BenFattoLogContext no projeto BenFattoLog.DAL na pasta Infra

  A partir do diretório:
    * BenFattoLog/BenFattoLog.DAL/Infra/BenFattoLogContext.cs

  A partir do Solution Explorer:
    * Solution BenFattoLog/Infra/BenFattoLog.DAL/Infra/BenFattoLogContext.cs


#### Rodando Postegre no Docker

 - docker run -d -e POSTGRES_USER=user -e POSTGRES_PASSWORD=admin --name db-my -p 5432:5432  --restart=always postgres
 - Configure o pgAdmin4 para acessar 127.0.0.1:5432
  

#### Porta do projeto WebApi 
   

## Sobre o Desenvolvimento

Second section content.

## Padrões Utilizados

O Front-End foi desenvolvido em .NET Core MVC
Foi utilizada um simplificação do padrão DDD