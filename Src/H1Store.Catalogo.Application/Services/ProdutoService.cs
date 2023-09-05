using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Services
{
	public class ProdutoService : IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;
		private IMapper _mapper;

		public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}

		public void Adicionar(NovoProdutoViewModel novoProdutoViewModel)
		{
			var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);
			_produtoRepository.Adicionar(novoProduto);

		}

		public void Atualizar(ProdutoViewModel produto)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
		{
			throw new NotImplementedException();
		}

		public Task<ProdutoViewModel> ObterPorId(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProdutoViewModel>> ObterTodos()
		{
			throw new NotImplementedException();
		}
	}
}
