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
		private readonly string _produtoCaminhoArquivo;

		#region - Construtores
		public ProdutoRepository()
		{
			_produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "produto.json");
		}

		#endregion

		#region - Funções
		public void Adicionar(Produto produto)
		{
			var produtos = LerProdutosDoArquivo();
			int proximoCodigo = ObterProximoCodigoDisponivel();
			produto.SetaCodigoProduto(proximoCodigo);
			produtos.Add(produto);
			EscreverProdutosNoArquivo(produtos);
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
			return LerProdutosDoArquivo();
		}
		#endregion

		#region - Métodos arquivo
		private List<Produto> LerProdutosDoArquivo()
		{
			if (!System.IO.File.Exists(_produtoCaminhoArquivo))
				return new List<Produto>();
			string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);
			return JsonConvert.DeserializeObject<List<Produto>>(json);
		}

		private int ObterProximoCodigoDisponivel()
		{
			List<Produto> produtos = LerProdutosDoArquivo();
			if (produtos.Any())
				return produtos.Max(p => p.Codigo) + 1;
			else
				return 1;
		}

		private void EscreverProdutosNoArquivo(List<Produto> produtos)
		{
			string json = JsonConvert.SerializeObject(produtos);
			System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
		}
		#endregion


	}
}
