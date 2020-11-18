using Dados;
using System.Threading.Tasks;

namespace EstoqueAPI.Infraestrutura
{
  public interface IUnitOfWork
  {
    Contexto Contexto { get; }

    Task Commit();
  }
}
