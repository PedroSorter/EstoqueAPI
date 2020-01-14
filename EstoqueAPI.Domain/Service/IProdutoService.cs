using Dados;
using EstoqueAPI.Domain.Modelo;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;

namespace EstoqueAPI.Domain.Service
{
  public interface IProdutoService : IService<Produto>
  {
    ProdutoModel Produto(Guid Id);
    IEnumerable<ProdutoModel> ListaProdutos();
    IEnumerable<ProdutoModel> ListaProdutosEmEstoque();
    void EditarProduto(ProdutoModel viewModel);
    void DeletarProduto(Guid Id);
    ProdutoModel CriarProduto(ProdutoModel viewModel);
  }
}
