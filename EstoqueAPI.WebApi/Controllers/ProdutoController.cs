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
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> Produtos()
        {
          var listaProdutos = await produtoService.ListaProdutos();
          if (!listaProdutos.Any())
            {
                return NotFound("Nenhum produto encontrado");
            }
            return Ok(listaProdutos);
        }

        [HttpGet("Produto/{id}")]
        public async Task<ActionResult<ProdutoModel>> Produto(Guid Id)
        {
            var produto = await produtoService.Produto(Id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            return Ok(produto);
        }

        [HttpPost("Produto")]
        public async Task<IActionResult> PostProduto([FromBody]ProdutoNovoModel viewModel)
        {
            await this.produtoService.CriarProduto(viewModel);
            return StatusCode(200);
        }

        [HttpDelete("Produto/{id}")]
        public async Task<IActionResult> Deletar(Guid Id)
        {
            await this.produtoService.DeletarProduto(Id);
            return StatusCode(200);
        }

        [HttpPut("Produto")]
        public async Task<IActionResult> Editar([FromBody]ProdutoModel viewModel)
        {
            await this.produtoService.EditarProduto(viewModel);
            return StatusCode(200);
        }
    }
}