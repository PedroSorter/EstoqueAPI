using Dados;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstoqueAPI.Infraestrutura
{
  public interface IRepository<T> where T : ModeloBase
  {
    Task<T> GetById(Guid? id);

    Task<IEnumerable<T>> List();

    Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> ListBySpecfication(ISpecification<T> specification);

    Task<T> GetBySpecification(ISpecification<T> specification);

    Task Add(T entity);

    Task Delete(T entity);

    Task Update(T entity);
  }
}
