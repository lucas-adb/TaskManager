# Desafio: API de Gerenciamento de Tarefas (Task Manager API)

## Objetivo

Construir uma API em .NET 8 para gerenciar tarefas de um sistema de produtividade (como um To-Do List corporativo), aplicando boas práticas de arquitetura, persistência e organização de código.

## Requisitos Funcionais

A API deve permitir:

1.  **Criar uma tarefa** ✅

    - Uma tarefa contém:
      - Id (gerado automaticamente)
      - Título (obrigatório)
      - Descrição (opcional)
      - Data de criação (automática)
      - Data limite (opcional)
      - Status (Pendente, Em Andamento, Concluída)
      - Responsável (nome de quem deve realizar a tarefa)

2.  **Listar todas as tarefas** ✅

    - Permitir filtro por:
      - Status
      - Responsável
      - Data limite

3.  **Buscar uma tarefa por Id** ✅

4.  **Atualizar uma tarefa** ✅

    - Atualizar título, descrição, status, data limite e responsável.

5.  **Excluir uma tarefa por Id** ✅

## Requisitos Técnicos

1.  .NET 8 Web API
2.  Entity Framework Core 8 com persistência em PostgreSql
3.  Padrão Repository e Service
4.  DTOs
5.  Swagger configurado
6.  Tratamento de exceções
7.  Retorno de status HTTP adequados (200, 201, 400, 404, 500)

## Endpoints esperados

| Método | Rota             | Descrição                                      |
| :----- | :--------------- | :--------------------------------------------- |
| GET    | `api/tasks`      | Lista todas as tarefas (com filtros opcionais) |
| GET    | `api/tasks/{id}` | Retorna uma tarefa específica                  |
| POST   | `api/tasks`      | Cria uma nova tarefa                           |
| PUT    | `api/tasks/{id}` | Atualiza uma tarefa existente                  |
| DELETE | `api/tasks/{id}` | Remove uma tarefa                              |

## Desafio Extra (opcional)

Implemente uma das seguintes features:

- Paginação com `skip` e `take` ✅
- Filtros combinados (status + responsável) ✅
- Persistência em memória com `InMemoryDatabase` para testes ✅ (Apenas Services)
- Testes unitários com xUnit ✅
