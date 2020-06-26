using Newtonsoft.Json;
using System;

namespace EstoqueAPI.Domain.Modelo
{
  public class ProdutoNovoModel
  {
    [JsonProperty("nome")]
    public string Nome { get; set; }
    [JsonProperty("quantidade")]

    public string Quantidade { get; set; }
    [JsonProperty("valor")]

    public string Valor { get; set; }
  }
}

