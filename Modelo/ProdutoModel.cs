using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
  class ProdutoModel
  {
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Quantidade { get; set; }

    public string Valor { get; set; }
  }
}
