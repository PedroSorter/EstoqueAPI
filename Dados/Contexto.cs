using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados
{
  public class Contexto : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
      .UseSqlite(@"Estoque.db;");
    }

    public DbSet<Produto> Produto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Produto>().HasData(
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2060", Quantidade = 50, Valor = 2000.00M },
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2060 SUPER", Quantidade = 60, Valor = 2500.00M },
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2070", Quantidade = 10, Valor = 3000.00M },
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2070 SUPER", Quantidade = 8, Valor = 3500.00M },
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2070 SUPER", Quantidade = 5, Valor = 4000.00M },
        new Produto() { Id = Guid.NewGuid(), Nome = "RTX 2080", Quantidade = 1, Valor = 6000.00M });
    }
  }
}
