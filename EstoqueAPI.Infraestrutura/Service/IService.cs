using Dados;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueAPI.Infraestrutura
{
  public interface IService<T> where T : ModeloBase
  {
    IList<T> GetAll();
    T GetByID(Guid id);
    T Create(T modelBase);
    T Update(T modelBase);
    void Delete(Guid id);
  }
}
