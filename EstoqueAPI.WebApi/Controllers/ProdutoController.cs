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
    public IEnumerable<ProdutoModel> GetProduto()
    {
      return produtoService.ListaProdutos().ToList();
    }

    [HttpPost("CreateProduto")]
    public IActionResult CreateProduto(ProdutoModel viewModel)
    {
      this.produtoService.CriarProduto(viewModel);
      return Ok(this.produtoService.CriarProduto(viewModel));
    }

    [HttpDelete("DeletarProduto")]
    public void DeletarProduto(Guid Id)
    {
      this.produtoService.DeletarProduto(Id);
    }

    [HttpPut("EditarProduto")]
    public void EditarProduto(ProdutoModel viewModel)
    {
      this.produtoService.EditarProduto(viewModel);
    }
  }
}