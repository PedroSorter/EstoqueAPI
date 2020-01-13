using Dados;
using EstoqueAPI.Domain.Repository;
using EstoqueAPI.Infraestrutura;

namespace EstoqueAPI.Repository
{
  public class ProdutoRepositorio : BaseRepository<Produto>, IProdutoRepository
  {
    public ProdutoRepositorio(IUnitOfWork unitOfWork) : base (unitOfWork)
    {

    }
  } 
}
