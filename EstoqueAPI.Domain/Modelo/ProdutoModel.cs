﻿using Newtonsoft.Json;
using System;

namespace EstoqueAPI.Domain.Modelo
{
  public class ProdutoModel
  {
    public ProdutoModel()
    {
      Id = Guid.NewGuid();
    }

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
