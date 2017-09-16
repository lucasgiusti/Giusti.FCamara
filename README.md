# Aplicativo teste para a consultoria FCamara

Tecnologias utilizadas:
 - ASP.Net Web API
 - AngularJs
 - Bootstrap
 - SQL Server Express

Projetos
 - Giusti.FCamara.Model
 - Giusti.FCamara.Data
 - Giusti.FCamara.Business
 - Giusti.FCamara.Api (Projeto Api)
 - Giusti.FCamara.Web (Projeto Web)

Obs.: Os dois projetos Api e Web estão na mesma solution.

#CONFIGURAÇÃO

# Giusti.FCamara.Api

Geração da Base de Dados
 - Criar Base de Dados SQL Server Express com o nome GiustiFCamara;
 - Executar o arquivo \BaseDeDados\create.sql;
 - Abrir o arquivo \Giusti.FCamara.Api\Web.config e alterar o valor da key ConexaoBanco na sessão appSettings.

# Giusti.FCamara

Caso seja alterada a url da API (publicado)
 - Abrir o arquivo \Giusti.FCamara.Web\app\app.js e alterar na primeira linha o valor da variável urlApi.
 
#EXECUÇÃO

Alterar a Solution para executar dois projetos
 - Clicar com o botão direito na solution e depois em Set StartUp Projects...;
 - Marcar a opção Multiple startup projects;
 - Alterar a coluna Action dos projetos Giusti.FCamara.Api e Giusti.FCamara.Web para Start;
 - Os outros projetos devem permanecer com a Action None.
 
Executar os projetos e logar no sistema com
 - Login: giusti
 - Senha: giusti
 
 Obs.: Para sair do sistema, clicar no nome do usuário logado no canto superior direito da tela e depois clicar em Sair.
 
 A lista de produtos é retornada pela API na uri abaixo
  - http://localhost:51493/api/livro
  
 Obs.: Quando não logado, a API deve retornar um erro de autenticação.
