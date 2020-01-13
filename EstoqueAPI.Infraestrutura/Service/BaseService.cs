using Dados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAPI.Infraestrutura
{
  public class BaseService<T> : IService<T> where T : ModeloBase
  {
    private readonly IRepository<T> repository;

    public BaseService(IRepository<T> repository)
    {
      this.repository = repository;
    }

    public T Create(T modelBase)
    {
      this.repository.Add(modelBase);
      return modelBase;
    }

    public void Delete(Guid id)
    {
      var item = this.repository.GetById(id);
      if (item != null)
        this.repository.Delete(item);
    }

    public IList<T> GetAll()
    {
      return this.repository.List().ToList();
    }

    public T GetByID(Guid id)
    {
      return this.repository.GetById(id);
    }

    public T Update(T modelBase)
    {
      this.repository.Update(modelBase);
      return modelBase;
    }
  }
}

