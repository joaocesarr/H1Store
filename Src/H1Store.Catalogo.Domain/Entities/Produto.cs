using H1Store.Catalogo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
	public class Produto
	{

		#region 1 - Contrutores
		public Produto( string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, int quantidadeEstoque)
		{			
			Nome = nome;
			Descricao = descricao;
			Ativo = ativo;
			Valor = valor;
			DataCadastro = dataCadastro;
			Imagem = imagem;
			QuantidadeEstoque = quantidadeEstoque;
		}


		public Produto(int codigo, string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, int quantidadeEstoque)
		{
			Codigo = codigo;
			Nome = nome;
			Descricao = descricao;
			Ativo = ativo;
			Valor = valor;
			DataCadastro = dataCadastro;
			Imagem = imagem;
			QuantidadeEstoque = quantidadeEstoque;
		}
		#endregion

		#region 2 - Propriedades
		public int Codigo { get; private set; }
			public string Nome { get; private set; }
			public string Descricao { get; private set; }
			public bool Ativo { get; private set; }
			public decimal Valor { get; private set; }
			public DateTime DataCadastro { get; private set; }
			public string Imagem { get; private set; }
			public int QuantidadeEstoque { get; private set; }

		#endregion

		#region 3 - Comportamentos

		public void Ativar() => Ativo = true;

		public void Desativar() => Ativo = false;

		public void AlterarDescricao(string descricao)
		{
			Descricao = descricao;
		}

		public void DebitarEstoque(int quantidade)
		{
			if (quantidade < 0) quantidade *= -1;
			if (!PossuiEstoque(quantidade)) throw new Exception("Estoque insuficiente");
			QuantidadeEstoque -= quantidade;
		}

		public void ReporEstoque(int quantidade)
		{
			QuantidadeEstoque += quantidade;
		}

		public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;


		#endregion
	}
}
