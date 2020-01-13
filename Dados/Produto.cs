using System;
using System.Collections.Generic;
using System.Text;

namespace Dados
{
  public class Produto
  {
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public int Quantidade { get; set; }

    public decimal Valor { get; set; }

    public Produto(string nome)
    {
      if (string.IsNullOrEmpty(nome))
      {
        throw new FormatException("Nome inválido para criação de produto");
      }
      else
      {
        this.Nome = nome;
      }
    }
  }
}
