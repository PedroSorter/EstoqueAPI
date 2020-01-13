using Dados;
using EstoqueAPI.Infraestrutura;

namespace EstoqueAPI.Domain.Specification
{
  public static class ProdutoSpecification
  {
    public static readonly BaseSpecification<Produto> EmEstoque =
      new BaseSpecification<Produto>(p => p.Quantidade > 0);
  }
}
