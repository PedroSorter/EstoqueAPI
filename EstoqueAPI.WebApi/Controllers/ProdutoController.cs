using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using EstoqueAPI.Domain.Modelo;
using System.Threading.Tasks;

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

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<ProdutoModel>> Produtos()
    {
      if (!produtoService.ListaProdutos().ToList().Any())
      {
        return NotFound("Nenhum produto encontrado");
      }
      return Ok(produtoService.ListaProdutos().ToList());
    }

    [HttpGet("Produto/{id}")]
    public ActionResult<ProdutoModel> Produto(Guid Id)
    {
      if (produtoService.Produto(Id) == null)
      {
        return NotFound("Produto não encontrado");
      }

      return Ok(produtoService.Produto(Id));
    }

    [HttpPost("Produto")]
    public IActionResult PostProduto([FromBody]ProdutoNovoModel viewModel)
    {
      this.produtoService.CriarProduto(viewModel);
      return StatusCode(200);
    }

    [HttpDelete("Produto/{id}")]
    public IActionResult Deletar(Guid Id)
    {
      this.produtoService.DeletarProduto(Id);
      return StatusCode(200);
    }

    [HttpPut("Produto")]
    public IActionResult Editar([FromBody]ProdutoModel viewModel)
    {
      this.produtoService.EditarProduto(viewModel);
      return StatusCode(200);
    }
  }
}