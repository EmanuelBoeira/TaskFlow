# Autor: Emanuel Boeira Martins


# Descrição

Este projeto foi desenvolvido para aprendizado e fixação de desenvolviemnto de API REST usando C# em ambiente .NET.


## Sobre o projeto

A aplicação TaskFlow busca funcionar como uma API Web para 
armazenamento persistente de tarefas (tasks), algo 
semelhando a um TODO (lista de tarefas a fazer). 
A aplicação implementa todas as funcionalidades de um CRUD,
Create, Read, Update e Delete; isso é feito seguindo o 
conceito de uma inferface consistente.

Os dados são armazenados no SGDB PostgreSQL por meio das bibliotecas `EntityFramworkCore` para ORM (Object Relational 
Mapping) e `Npgsql` como driver para conexão com PostgreSQL.

## Descrição dos diretórios do projeto

  |  diretório  |  descrição  |
  |  :---:  |  ---  |
  |  TaskFlow.Api  |  Diretório da API, apresenta arquivos do Controller e Program.cs  |
  |  TaskFlow.Aplication  |  Apresenta arquivos de definição do funcionamento do projeto, como Services, Interfaces e DTOs  |
  |  TaskFlow.Domain  |  Apresenta arquivos que descrevem o domínio da aplicação, neste caso, apenas a Entitie TaskItem  |
  |  TaskFlow.Infrastructure  |  Neste diretório estão arquivos relacionados à persistencia e manipulação dos dados no Banco de Dados  |

## Endpoints

  |  endpoint  |  descrição  |
  |  :---:  |  ---  |
  |  POST /api/tasks  |  Criação de uma task  |
  |  GET /api/tasks  |  Leitura de todas as tasks  |
  |  GET /api/tasks/{id}  |  Leitura de apenas uma task identificada pelo id passado  |
  |  PUT /api/tasks/{id}  |  Atualização do Título e descrição da task identificada pelo id passado  |
  |  DELETE /api/tasks/{id}  |  Remove a task informada pelo id passado  (retorno 204 = ok, retorno 404 = Not Found)|



# Dependências

- .NET-sdk 10 ou superior
- ASPNET Targeting pack
- PostgreSQL
- EntityFrameWorkCore
- Npgsql


# Forma de execução

No diretório raíz do projeto execute os seguintes comandos:

`dotnet build`

`dotnet run --project src/TaskFlow.Api`