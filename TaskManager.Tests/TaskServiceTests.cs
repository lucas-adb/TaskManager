using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Repositories;
using TaskManager.Models;
using TaskManager.Models.Dto;
using TaskManager.Services;

namespace TaskManager.Tests;

public class TaskServiceTests
{
    private static DbContextOptions<AppDbContext> GetInMemoryOptions() =>
        new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;


    [Fact]
    public async Task CreateAsync_should_persist_and_return_created_task()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);

            var createDto = new TaskCreateDto
            {
                Title = "Teste",
                Description = "Descrição",
                Responsible = "Fulano"
            };

            var created = await service.CreateAsync(createDto);

            Assert.NotNull(created);
            Assert.True(created.Id > 0);
            Assert.Equal("Teste", created.Title);
        }

        using (var context = new AppDbContext(options))
        {
            var count = await context.Tasks.CountAsync();
            Assert.Equal(1, count);
        }
    }

    [Fact]
    public async Task GetAllAsync_should_return_all_existing_tasks()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            context.Tasks.Add(new TaskEntity
            {
                Title = "Task 1",
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
            });

            context.Tasks.Add(new TaskEntity
            {
                Title = "Task 2",
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
            });
            await context.SaveChangesAsync();
        }

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);
            var dtoList = await service.GetAllAsync(1, 10);

            Assert.Equal(2, dtoList.Count);
            Assert.Collection(dtoList, item => Assert.Equal("Task 1", item.Title), item => Assert.Equal("Task 2", item.Title));
        }
    }

    [Fact]
    public async Task GetByIdAsync_should_return_existing_task()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            context.Tasks.Add(new TaskEntity
            {
                Title = "Task",
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
            });
            await context.SaveChangesAsync();
        }

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);
            var dto = await service.GetByIdAsync(1);

            Assert.NotNull(dto);
            Assert.Equal("Task", dto!.Title);
        }
    }

    [Fact]
    public async Task RemoveByIdAsync_should_remove_existing_task()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            context.Tasks.Add(new TaskEntity
            {
                Title = "Task",
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
            });
            await context.SaveChangesAsync();
        }

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);
            var dto = await service.RemoveByIdAsync(1);

            var count = await context.Tasks.CountAsync();
            Assert.Equal(0, count);
        }
    }

    [Fact]
    public async Task UpdateAsync_should_update_task()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);

            var createDto = new TaskCreateDto
            {
                Title = "Teste",
                Description = "Descrição",
                Responsible = "Fulano"
            };

            await service.CreateAsync(createDto);
        }

        using (var context = new AppDbContext(options))
        {
            var repo = new TaskRepository(context);
            var service = new TaskService(repo);


            var updateDto = new TaskUpdateDto
            {
                Title = "Atualizado",
                Description = "Atualizado",
                CompletionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Status = TaskStatusEnum.Concluida,
                Responsible = "Atualizado"
            };

            var updated = await service.UpdateAsync(1, updateDto);

            Assert.NotNull(updated);
            Assert.Equal("Atualizado", updated.Title);
            Assert.Equal("Atualizado", updated.Responsible);
        }
    }
}
