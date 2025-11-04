# TaskManager - Documentação

# Fluxo da aplicação 🔄

Cliente -> Controller -> Service -> Repository -> DbContext -> Banco de Dados

# Estrutura de pastas 💼

- Controllers/

  - Contém controllers. Lida com rotas, status codes e coordena chamadas aos services.

- Services/

  - Contém a lógica de negócio, faz o mapeamento entre DTOs e entidades.

- Data/

  - AppDbContext.cs — configura o modelo EF.
  - Repositories/ — interfaces e implementações que usam AppDbContext para CRUD.

- Models/

  - Entities — classes que representam tabelas no banco.
  - Dto/ — DTOs de entrada/saída (TaskCreateDto, TaskReadDto) para controlar o contrato da API.

- Migrations/

  - Migrações geradas pelo EF Core.

- Program.cs
  - Registra serviços no DI (AddDbContext, Repositories, Services), configura JSON/Swagger e roteamento.

# Comandos Úteis

## Depois de clonar use

```
dotnet restore
```

## Instalando EF e libs para PostgreSql

```
dotnet tool install --global dotnet-ef
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Como criar e rodar migrations

```
dotnet ef migrations add <nomeDaMigration>
dotnet ef database update
```
