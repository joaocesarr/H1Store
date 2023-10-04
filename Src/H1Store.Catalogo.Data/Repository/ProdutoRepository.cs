using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly IMongoRepository<ProdutoCollection> _produtoRepository;


		#region - Construtores
		public ProdutoRepository(IMongoRepository<ProdutoCollection> produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		#endregion

		#region - Funções
		public async Task Adicionar(Produto produto)
		{
			ProdutoCollection produtoCollection= new ProdutoCollection();
			produtoCollection.Descricao = produto.Descricao;
			produtoCollection.Ativo = produto.Ativo;
			produtoCollection.DataCadastro = produto.DataCadastro;
			produtoCollection.Codigo = produto.Codigo;
			produtoCollection.Nome = produto.Nome;
			produtoCollection.QuantidadeEstoque	= produto.QuantidadeEstoque;
			produtoCollection.Valor = produto.Valor;
			produtoCollection.Imagem = produto.Imagem;

			await	_produtoRepository.InsertOneAsync(produtoCollection);
		}

		public void Atualizar(Produto produto)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
		{
			throw new NotImplementedException();
		}

		public Task<Produto> ObterPorId(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Produto> ObterTodos()
		{
			var produtoList = _produtoRepository.FilterBy(filter => true);

			List<Produto> lista = new List<Produto>();
			foreach (var item in produtoList)
			{
				lista.Add(new Produto(item.Codigo, item.Nome, item.Descricao, item.Ativo, item.Valor, item.DataCadastro, item.Imagem, item.QuantidadeEstoque));
			}

			return lista;
		}
		#endregion

	}
}
