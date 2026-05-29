# API de Tarefas

API simples para gerenciamento de tarefas (CRUD), construída com .NET 8, Dapper e arquitetura em camadas.

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Dapper
- SQL Server
- FluentValidation
- JWT (autenticação)

## Funcionalidades

- Autenticação via JWT
- Criar tarefa
- Atualizar tarefa
- Remover tarefa
- Buscar tarefa por id
- Listar tarefas com paginação
- Importação em massa via Excel (.xlsx)

## Regras de negócio

- Título é obrigatório
- Título máximo de 100 caracteres
- Data de vencimento deve ser futura
- Status e prioridade devem ser valores válidos## Endpoints

### Criar tarefa
POST /api/tarefas

### Atualizar tarefa
PUT /api/tarefas/{id}

### Remover tarefa
DELETE /api/tarefas/{id}

### Buscar por id
GET /api/tarefas/{id}

### Listar tarefas (com paginação)
GET /api/tarefas?page=1&pageSize=10

## Autenticação

A API utiliza autenticação via JWT.

### Login

POST /api/auth/login

Exemplo de request:

```json
{
  "usuario": "admin",
  "senha": "123"
}
```
## Banco de dados

### Tabela: Tarefas

```sql
CREATE TABLE Tarefas (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Titulo NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(MAX) NULL,
    DataVencimento DATETIME2 NOT NULL,
    Status INT NOT NULL,
    Prioridade INT NOT NULL,
    DataCriacao DATETIME2 NOT NULL
);
```
