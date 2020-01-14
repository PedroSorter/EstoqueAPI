using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueAPI.Domain.Modelo
{
  public class ProdutoModel
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public string Quantidade { get; set; }

    public string Valor { get; set; }
  }
}
