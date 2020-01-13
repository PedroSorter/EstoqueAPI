using System;

namespace Dados
{
  public class Produto : ModeloBase
  {
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
