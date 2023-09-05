﻿using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Interfaces
{
	public interface IProdutoRepository
	{
		Task<IEnumerable<Produto>> ObterTodos();
		Task<Produto> ObterPorId(Guid id);
		Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

		void Adicionar(Produto produto);
		void Atualizar(Produto produto);
	}
}
