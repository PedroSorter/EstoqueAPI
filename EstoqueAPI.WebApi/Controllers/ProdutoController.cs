using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAPI.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstoqueAPI.Domain;
using EstoqueAPI.Domain.Modelo;

namespace EstoqueAPI.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProdutoController : ControllerBase
  {
    private readonly IProdutoService produtoService; 

    public ProdutoController(IProdutoService produtoService)
    {
      this.produtoService = produtoService;
    }

    [HttpGet]
    public IEnumerable<ProdutoModel> GetProdutos()
    {
      return produtoService.ListaProdutos().ToList();
    }
  }
}