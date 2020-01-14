using AutoMapper;
using Dados;
using EstoqueAPI.Domain.Modelo;
using EstoqueAPI.Domain.Repository;
using EstoqueAPI.Domain.Service;
using EstoqueAPI.Domain.Specification;
using EstoqueAPI.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstoqueAPI.Service
{
  public class ProdutoService : BaseService<Produto>, IProdutoService
  {
    private readonly IProdutoRepository produtoRepository;
    private IMapper mapper; 
    public ProdutoService(IProdutoRepository produtoRepository) : base (produtoRepository)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<ProdutoModel, Produto>()
            .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
            .ForMember(dto => dto.Nome, map => map.MapFrom(source => source.Nome))
            .ForMember(dto => dto.Quantidade, map => map.MapFrom(source => int.Parse(source.Quantidade)))
            .ForMember(dto => dto.Valor, map => map.MapFrom(source => decimal.Parse(source.Valor)));

        cfg.CreateMap<Produto, ProdutoModel>()
           .ForMember(dto => dto.Nome, map => map.MapFrom(source => source.Nome))
           .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
           .ForMember(dto => dto.Quantidade, map => map.MapFrom(source => source.Quantidade.ToString()))
           .ForMember(dto => dto.Valor, map => map.MapFrom(source => source.Valor.ToString()));
      });

      mapper = config.CreateMapper();
    
      this.produtoRepository = produtoRepository;
    }

    public void DeletarProduto(Guid Id)
    {
      var produto = this.produtoRepository.GetById(Id);
      if (produto != null)
      {
        this.produtoRepository.Delete(produto);
      }
    }

    public void EditarProduto(ProdutoModel viewModel)
    {
      var produto = this.produtoRepository.GetById(viewModel.Id);
      if(produto != null)
      {
        var model = mapper.Map<ProdutoModel, Produto>(viewModel);
        this.produtoRepository.Update(produto);
      }
    }

    public IEnumerable<ProdutoModel> ListaProdutos()
    {
      return mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(this.produtoRepository.List());
    }

    public IEnumerable<ProdutoModel> ListaProdutosEmEstoque()
    {
      return mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(this.produtoRepository.ListBySpecfication(ProdutoSpecification.EmEstoque));
    }

    public ProdutoModel Produto(Guid Id)
    {
      return mapper.Map<Produto, ProdutoModel>(this.produtoRepository.GetById(Id));
    }
  }
}
