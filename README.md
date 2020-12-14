Este arquivo README tem por objetivo auxiliar na utilização do projeto.

[[_TOC_]]

## Configurações da Solution

### A Solution
  A solution foi desenvolvida utilizando Visual Studio 2019 Community, consiste em 7 Projetos, sendo 2  de Startup
  - BenFattoLog.API
  - BenFattoLog.UI
  
  Os dois devem rodar ao mesmo tempo a partir do Visual Studio

### Script Banco de Dados
  
  O script do banco de dados postgreSQL encontra-se na pasta BenFattoLog/Database/BenFattoLog.sql

#### String de Conexão
  A string de conexão se encontra no arquivo da classe BenFattoLogContext no projeto BenFattoLog.DAL na pasta Infra

  A partir do diretório:
    
    * BenFattoLog/BenFattoLog.DAL/Infra/BenFattoLogContext.cs

  A partir do Solution Explorer:
    
    * Solution BenFattoLog/Infra/BenFattoLog.DAL/Infra/BenFattoLogContext.cs


#### Rodando Postegre no Docker

 - docker run -d -e POSTGRES_USER=user -e POSTGRES_PASSWORD=admin --name db-my -p 5432:5432  --restart=always postgres
 - Configure o pgAdmin4 para acessar 127.0.0.1:5432
  

#### Porta do projeto WebApi 
   
   Caso de seja necessário mudar a porta do projeto WebApi BenFattoLog.API, o projeto BenFattoLog.UI sera afetado pos os arquivos javascript utilizam a porta e o endereço local para acessar o serviço.
   Para resolver esse problema basta trocar as variaveis serviceAddress e servicePort para os respectivos novos valores nos seguintes arquivos:
   * consulta.log.js - localizado em BenFattoLog\BenFattoLog.UI\wwwroot\js\views\home
   * importacao.log.js - localizado em BenFattoLog\BenFattoLog.UI\wwwroot\js\views\home
   * manual.log.js - localizado em BenFattoLog\BenFattoLog.UI\wwwroot\js\views\home   


## Padrões Utilizados

- O Front-End foi desenvolvido em .NET Core MVC
- Foram utilizados Bootstrap, JavaScript, AJAX(Fetch Api), JQuery, HTML5, CSS3
- Foi utilizada um simplificação do padrão DDD