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

    [HttpGet("Produtos")]
    public IEnumerable<ProdutoModel> Produtos()
    {
      return produtoService.ListaProdutos().ToList();
    }

    [HttpGet("Produto/{id}")]
    public ProdutoModel Produto(Guid Id)
    {
      return produtoService.Produto(Id);
    }

    [HttpPost("Criar")]
    public IActionResult PostProduto([FromBody]ProdutoModel viewModel)
    {
      this.produtoService.CriarProduto(viewModel);
      return Ok(this.produtoService.CriarProduto(viewModel));
    }

    [HttpDelete("Deletar/{id}")]
    public IActionResult Deletar(Guid Id)
    {
      return Ok(this.produtoService.DeletarProduto(Id));
    }

    [HttpPut("Editar")]
    public void Editar([FromBody]ProdutoModel viewModel)
    {
      this.produtoService.EditarProduto(viewModel);
    }
  }
}