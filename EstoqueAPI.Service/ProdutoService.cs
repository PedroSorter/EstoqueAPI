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
using System.Threading.Tasks;

namespace EstoqueAPI.Service
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private IMapper mapper;
        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
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

                cfg.CreateMap<ProdutoNovoModel, Produto>()
              .ForMember(dto => dto.Id, map => Guid.NewGuid())
              .ForMember(dto => dto.Nome, map => map.MapFrom(source => source.Nome))
              .ForMember(dto => dto.Quantidade, map => map.MapFrom(source => int.Parse(source.Quantidade)))
              .ForMember(dto => dto.Valor, map => map.MapFrom(source => decimal.Parse(source.Valor)));

            });

            mapper = config.CreateMapper();

            this.produtoRepository = produtoRepository;
        }

        public async Task CriarProduto(ProdutoNovoModel viewModel)
        {
            if (viewModel != null)
            {
                var model = mapper.Map<ProdutoNovoModel, Produto>(viewModel);
                await this.produtoRepository.Add(model);
            }
        }

        public async Task DeletarProduto(Guid Id)
        {
            var produto = await this.produtoRepository.GetById(Id);
            if (produto != null)
            {
                await this.produtoRepository.Delete(produto);
            }
        }

        public async Task EditarProduto(ProdutoModel viewModel)
        {
            var produto = await this.produtoRepository.GetById(viewModel.Id);
            if (produto != null)
            {
                var model = mapper.Map<ProdutoModel, Produto>(viewModel);
                await this.produtoRepository.Update(model);
            }
        }

        public async Task<IEnumerable<ProdutoModel>> ListaProdutos()
        {
            var listaProdutos = await this.produtoRepository.List();
            return mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(listaProdutos);
        }

        public async Task<IEnumerable<ProdutoModel>> ListaProdutosEmEstoque()
        {
            var listaProdutosEmEstoque = await this.produtoRepository.ListBySpecfication(ProdutoSpecification.EmEstoque);
            return mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(listaProdutosEmEstoque);
        }

        public async Task<ProdutoModel> Produto(Guid Id)
        {
            var produto = await this.produtoRepository.GetById(Id);
            return mapper.Map<Produto, ProdutoModel>(produto);
        }
    }
}
