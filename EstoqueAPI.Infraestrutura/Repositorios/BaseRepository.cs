using Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EstoqueAPI.Infraestrutura
{
  public class BaseRepository<T> : IRepository<T> where T : ModeloBase
  {
    private readonly IUnitOfWork unitOfWork;

    public BaseRepository(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public void Add(T entity)
    {
      this.unitOfWork.Contexto.Set<T>().Add(entity);
      this.unitOfWork.Commit();
    }

    public void Delete(T entity)
    {
      T existing = this.unitOfWork.Contexto.Set<T>().Find(entity.Id);
      if (existing != null) this.unitOfWork.Contexto.Set<T>().Remove(existing);
      this.unitOfWork.Commit();
    }

    public IEnumerable<T> List()
    {
      return this.unitOfWork.Contexto.Set<T>().AsEnumerable();
    }

    public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
    {
      return this.unitOfWork.Contexto.Set<T>().Where(predicate).AsEnumerable();
    }

    public T GetById(Guid? id)
    {
      return this.unitOfWork.Contexto.Set<T>().AsNoTracking().Where(x => x.Id == id).SingleOrDefault();
    }

    public T GetBySpecification(ISpecification<T> specification)
    {
      return this.unitOfWork.Contexto.Set<T>().Where(specification.toExpression()).SingleOrDefault();
    }

    public IEnumerable<T> ListBySpecfication(ISpecification<T> specification)
    {
      return this.unitOfWork.Contexto.Set<T>().Where(specification.toExpression()).ToList();
    }

    public void Update(T entity)
    {
      this.unitOfWork.Contexto.Entry(entity).State = EntityState.Modified;
      this.unitOfWork.Commit();
    }
  }
}
