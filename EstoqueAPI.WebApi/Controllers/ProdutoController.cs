using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("GetProdutos")]
    public IEnumerable<ProdutoModel> GetProdutos()
    {
      return produtoService.ListaProdutos().ToList();
    }

    [HttpGet("GetProduto/{id}")]
    public ProdutoModel GetProduto(Guid Id)
    {
      return produtoService.Produto(Id);
    }

    [HttpPost("PostProduto")]
    public IActionResult PostProduto([FromBody]ProdutoModel viewModel)
    {
      this.produtoService.CriarProduto(viewModel);
      return Ok(this.produtoService.CriarProduto(viewModel));
    }

    [HttpDelete("DeletarProduto/{id}")]
    public IActionResult DeletarProduto(Guid Id)
    {
      return Ok(this.produtoService.DeletarProduto(Id));
    }

    [HttpPut("EditarProduto")]
    public void EditarProduto([FromBody]ProdutoModel viewModel)
    {
      this.produtoService.EditarProduto(viewModel);
    }
  }
}