using Dados;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;

namespace EstoqueAPI.Domain.Service
{
  public interface IProdutoService : IService<Produto>
  {
    Produto Produto(Guid Id);
    IEnumerable<Produto> ListaProdutos();
    IEnumerable<Produto> ListaProdutosEmEstoque();

    void EditarProduto(Produto model);

    void DeletarProduto(Guid Id);
  }
}
