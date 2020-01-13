using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
  public interface IRepositorioBase<TEntity> where TEntity : class
  {
    void Add(TEntity entity, bool isSave);
    void AddAll(List<TEntity> entity, bool isSave);
    void Edit(TEntity entity, bool isSave);
    void Delete(TEntity entity);
    void DeleteAll(Expression<Func<TEntity, bool>> filter = null);
    List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    void Save();
  }
}
