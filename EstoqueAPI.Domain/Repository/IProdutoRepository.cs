using Dados;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;

namespace EstoqueAPI.Domain.Repository
{
  public interface IProdutoRepository : IRepository<Produto>
  {
  }
}
