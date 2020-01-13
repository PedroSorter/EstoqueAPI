using Dados;

namespace EstoqueAPI.Infraestrutura
{
  public interface IUnitOfWork
  {
    Contexto Contexto { get; }

    void Commit();
  }
}
