using Dados;
using EstoqueAPI.Domain.Repository;
using EstoqueAPI.Domain.Service;
using EstoqueAPI.Domain.Specification;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstoqueAPI.Service
{
  public class ProdutoService : BaseService<Produto>, IProdutoService
  {
    private readonly IProdutoRepository produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository) : base (produtoRepository)
    {
      this.produtoRepository = produtoRepository;
    }

    public void DeletarProduto(Guid Id)
    {
      var produto = this.produtoRepository.GetById(Id);
      if (produto != null)
      {
        this.produtoRepository.Delete(produto);
      }
    }

    public void EditarProduto(Produto model)
    {
      var produto = this.produtoRepository.GetById(model.Id);
      if(produto != null)
      {
        produto.Nome = model.Nome;
        produto.Quantidade = model.Quantidade;
        produto.Valor = model.Valor;
        this.produtoRepository.Update(produto);
      }
    }

    public IEnumerable<Produto> ListaProdutos()
    {
      return this.produtoRepository.List();
    }

    public IEnumerable<Produto> ListaProdutosEmEstoque()
    {
      return this.produtoRepository.ListBySpecfication(ProdutoSpecification.EmEstoque).ToList();
    }

    public Produto Produto(Guid Id)
    {
      return this.produtoRepository.GetById(Id);
    }
  }
}
