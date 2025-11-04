# Instalando EF e libs para PostgreSql

```
dotnet tool install --global dotnet-ef
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
```

# Como criar e rodar migrations

```
dotnet ef migrations add <nomeDaMigration>
dotnet ef database update
```
