using H1Store.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IProdutoService
	{
		Task<IEnumerable<ProdutoViewModel>> ObterTodos();
		Task<ProdutoViewModel> ObterPorId(Guid id);
		Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

		void Adicionar(NovoProdutoViewModel produto);
		void Atualizar(ProdutoViewModel produto);
	}
}
