using Dados;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstoqueAPI.Infraestrutura
{
  public interface IService<T> where T : ModeloBase
  {
    Task<IList<T>> GetAll();
    Task<T> GetByID(Guid id);
    Task<T> Create(T modelBase);
    Task<T> Update(T modelBase);
    Task Delete(Guid id);
  }
}
