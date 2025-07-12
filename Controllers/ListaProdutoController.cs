using System;
using System.Linq.Expressions;
using CatalogoDeDoces.Dtos;
using CatalogoDeDoces.Helper;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class ListaProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ListaProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos") ?? new List<ProdutoListaDto>();
            return View(lista);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarLista(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(p => p.Id == id);
            if (produto == null)
                return NotFound();

            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos") ?? new List<ProdutoListaDto>();

            if (!lista.Any(p => p.ProdutoId == produto.Id))
            {
                lista.Add(new ProdutoListaDto
                {
                    ProdutoId = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    ImagemUrl = produto.ImagemUrl
                });

                HttpContext.Session.SetObjectAsJson("ListaProdutos", lista);
            }
            TempData["Mensagem"] = "Produto adicionado com sucesso!";
            return RedirectToAction("Index", "ListaProduto");
        }

        [HttpPost]
        public IActionResult RemoverLista(int id)
        {
            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos") ?? new List<ProdutoListaDto>();
            var itemRemover = lista.FirstOrDefault(p => p.ProdutoId == id);
            if (itemRemover != null)
            {
                lista.Remove(itemRemover);
                HttpContext.Session.SetObjectAsJson("ListaProdutos", lista);
            }
            return RedirectToAction("Index");
        }
    }
}
