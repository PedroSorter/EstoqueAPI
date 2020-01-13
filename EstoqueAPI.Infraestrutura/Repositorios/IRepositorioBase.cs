using Dados;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EstoqueAPI.Infraestrutura
{
  public interface IRepository<T> where T : ModeloBase
  {
    T GetById(Guid? id);

    IEnumerable<T> List();

    IEnumerable<T> List(Expression<Func<T, bool>> predicate);

    IEnumerable<T> ListBySpecfication(ISpecification<T> specification);

    T GetBySpecification(ISpecification<T> specification);

    void Add(T entity);

    void Delete(T entity);

    void Update(T entity);
  }
}
