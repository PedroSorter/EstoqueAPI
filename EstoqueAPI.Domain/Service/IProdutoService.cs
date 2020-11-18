using Dados;
using EstoqueAPI.Domain.Modelo;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstoqueAPI.Domain.Service
{
    public interface IProdutoService
    {
        Task<ProdutoModel> Produto(Guid Id);
        Task<IEnumerable<ProdutoModel>> ListaProdutos();
        Task<IEnumerable<ProdutoModel>> ListaProdutosEmEstoque();
        Task EditarProduto(ProdutoModel viewModel);
        Task DeletarProduto(Guid Id);
        Task CriarProduto(ProdutoNovoModel viewModel);
    }
}
