using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<TaskEntity> Tasks { get; set; } = null!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TaskEntity>().ToTable("tasks");

    // converte enum para string no banco
    modelBuilder.Entity<TaskEntity>()
      .Property(e => e.Status)
      .HasConversion<string>()
      .HasDefaultValue(TaskStatusEnum.Pendente)
      .IsRequired();
  }
}
