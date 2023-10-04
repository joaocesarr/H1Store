using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoService _produtoService;
		public ProdutoController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}

		[HttpPost(Name = "Adicionar")]
		public IActionResult Post(NovoProdutoViewModel novoProdutoViewModel)
		{
			_produtoService.Adicionar(novoProdutoViewModel);

			return Ok();
		}


		[HttpGet(Name = "ObterTodos")]
		public IActionResult Get()
		{
			return Ok(_produtoService.ObterTodos());
		}
	}
}
