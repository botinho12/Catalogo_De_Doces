using System.Text;
using CatalogoDeDoces.Dtos;
using CatalogoDeDoces.Helper;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    [Authorize]
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

            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos") ?? new List<ProdutoListaDto>();

            if (lista.All(p => p.ProdutoId != produto.Id))
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnviarOrcamento()
        {
            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos") ?? new List<ProdutoListaDto>();

            if (lista.Count == 0)
            {
                TempData["Mensagem"] = "Sua lista está vazia!";
                return RedirectToAction("Index");
            }

            var mensagemBuilder = new StringBuilder();
            mensagemBuilder.AppendLine("Olá! Gostaria de solicitar um orçamento com os seguintes itens:");
            foreach (var produto in lista)
            {
                mensagemBuilder.AppendLine($"- {produto.Nome} (x{produto.Quantidade})");
            }

            HttpContext.Session.Remove("ListaProdutos");
            TempData["Mensagem"] = "Orçamento enviado com sucesso!";
            TempData["AbrirWhatsApp"] = mensagemBuilder.ToString();

            return RedirectToAction("Index");
        }

    }
}
