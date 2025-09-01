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
                    Quantidade = produto.Quantidade,
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
        public IActionResult AtualizarQuantidade([FromBody] ProdutoListaDto produtoAtualizado)
        {
            var lista = HttpContext.Session.GetObjectFromJson<List<ProdutoListaDto>>("ListaProdutos");
            var produto = lista.FirstOrDefault(p => p.ProdutoId == produtoAtualizado.ProdutoId);

            if (produto != null)
            {
                produto.Quantidade = produtoAtualizado.Quantidade;
                HttpContext.Session.SetObjectAsJson("ListaProdutos", lista);
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnviarOrcamento(List<ProdutoListaDto> produtos)
        {
            if (produtos == null || !produtos.Any())
            {
                TempData["Mensagem"] = "Sua lista está vazia!";
                return RedirectToAction("Index");
            }

            var mensagemBuilder = new StringBuilder();
            mensagemBuilder.AppendLine("Olá! Gostaria de solicitar um orçamento com os seguintes itens:");

            foreach (var produto in produtos)
            {
                mensagemBuilder.AppendLine($"- {produto.Nome} ({produto.Quantidade})");
            }

            // se ainda quiser limpar da sessão:
            HttpContext.Session.Remove("ListaProdutos");

            TempData["Mensagem"] = "Orçamento enviado com sucesso!";
            TempData["AbrirWhatsApp"] = mensagemBuilder.ToString();

            return RedirectToAction("Index");
        }


    }
}
