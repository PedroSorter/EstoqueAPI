using Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
  public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
  {
    internal Contexto Contexto;
    internal DbSet<TEntity> DbSet;

    public RepositorioBase(Contexto Contexto)
    {
      this.Contexto = Contexto;
      this.DbSet = Contexto.Set<TEntity>();
    }

    public void Save()
    {
      this.Contexto.SaveChanges();
    }

    public void Add(TEntity entity, bool isSave = false)
    {
      DbSet.Add(entity);
      if (isSave)
        this.Save();
    }

    public void Edit(TEntity entity, bool isSave = false)
    {
      var entry = Contexto.Entry(entity);
      var pkey = GetPrimaryKeyInfo<TEntity>().GetValue(entity);

      if (entry.State == EntityState.Detached)
      {
        var set = Contexto.Set<TEntity>();
        TEntity attachedEntity = set.Find(pkey);
        if (attachedEntity != null)
        {
          var attachedEntry = Contexto.Entry(attachedEntity);
          attachedEntry.CurrentValues.SetValues(entity);
        }
        else
        {
          entry.State = EntityState.Modified;
        }
      }

      if (isSave)
        this.Save();
    }

    public void Delete(TEntity entity)
    {
      if (Contexto.Entry(entity).State == EntityState.Detached)
        DbSet.Attach(entity);

      DbSet.Remove(entity);
      Save();
    }

    public void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
    {
      IQueryable<TEntity> query = DbSet;
      List<TEntity> listDelete = query.Where(filter).ToList();

      foreach (var item in listDelete)
      {
        DbSet.Remove(item);
      }

    }

    public void AddAll(List<TEntity> entity, bool isSave = false)
    {
      foreach (var item in entity)
      {
        DbSet.Add(item);
      }

      if (isSave)
        this.Save();
    }

    public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
      IQueryable<TEntity> query = DbSet;

      if (filter != null)
        query = query.Where(filter);

      if (orderBy != null)
        return orderBy(query).ToList();
      else
        return query.ToList();
    }

    public void Dispose()
    {
      DbSet = null;
      Contexto.Dispose();
      GC.SuppressFinalize(this);
    }

    private PropertyInfo GetPrimaryKeyInfo<T>()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();
      foreach (PropertyInfo pI in properties)
      {
        Object[] attributes = pI.GetCustomAttributes(true);
        foreach (object attribute in attributes)
        {
          if (attribute is KeyAttribute)
            return pI;
        }
      }
      return null;
    }
  }
}
