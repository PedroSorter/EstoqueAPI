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
        new Produto("RTX 2060") { Id = Guid.NewGuid(), Quantidade = 50, Valor = 2000.00M },
        new Produto("RTX 2060 SUPER") { Id = Guid.NewGuid(), Quantidade = 60, Valor = 2500.00M },
        new Produto("RTX 2070") { Id = Guid.NewGuid(), Quantidade = 10, Valor = 3000.00M },
        new Produto("RTX 2070 SUPER") { Id = Guid.NewGuid(), Quantidade = 8, Valor = 3500.00M },
        new Produto("RTX 2080 SUPER") { Id = Guid.NewGuid(), Quantidade = 5, Valor = 4000.00M },
        new Produto("RTX 2080") { Id = Guid.NewGuid(), Quantidade = 1, Valor = 6000.00M });
    }
  }
}
