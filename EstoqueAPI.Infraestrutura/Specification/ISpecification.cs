using Dados;
using System;
using System.Linq.Expressions;

namespace EstoqueAPI.Infraestrutura
{
  public interface ISpecification<T> where T : ModeloBase
  {
    bool IsSatisfiedBy(T entity);
    Expression<Func<T, bool>> toExpression();
  }
}
