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
    public async Task GetByIdAsync_should_return_existing_task()
    {
        var options = GetInMemoryOptions();

        using (var context = new AppDbContext(options))
        {
            context.Tasks.Add(new TaskEntity
            {
                Title = "Seed",
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
            Assert.Equal("Seed", dto!.Title);
        }
    }
}
