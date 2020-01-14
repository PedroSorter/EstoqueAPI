using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueAPI.Domain.Modelo
{
  public class ProdutoModel
  {
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("nome")]
    public string Nome { get; set; }
    [JsonProperty("quantidade")]

    public string Quantidade { get; set; }
    [JsonProperty("valor")]

    public string Valor { get; set; }
  }
}
