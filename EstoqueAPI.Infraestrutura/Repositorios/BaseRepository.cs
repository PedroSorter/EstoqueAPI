using Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstoqueAPI.Infraestrutura
{
  public class BaseRepository<T> : IRepository<T> where T : ModeloBase
  {
    private readonly IUnitOfWork unitOfWork;

    public BaseRepository(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public async Task Add(T entity)
    {
      await this.unitOfWork.Contexto.Set<T>().AddAsync(entity);
      await this.unitOfWork.Commit();
    }

    public async Task Delete(T entity)
    {
      T existing = await this.unitOfWork.Contexto.Set<T>().FindAsync(entity.Id);
      if (existing != null) this.unitOfWork.Contexto.Set<T>().Remove(existing);
      await this.unitOfWork.Commit();
    }

    public async Task<IEnumerable<T>> List()
    {
      return await this.unitOfWork.Contexto.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
    {
      return await this.unitOfWork.Contexto.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetById(Guid? id)
    {
      return await this.unitOfWork.Contexto.Set<T>().AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task<T> GetBySpecification(ISpecification<T> specification)
    {
      return await this.unitOfWork.Contexto.Set<T>().Where(specification.toExpression()).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ListBySpecfication(ISpecification<T> specification)
    {
      return await this.unitOfWork.Contexto.Set<T>().Where(specification.toExpression()).ToListAsync();
    }

    public async Task Update(T entity)
    {
      this.unitOfWork.Contexto.Entry(entity).State = EntityState.Modified;
      await this.unitOfWork.Commit();
    }
  }
}
