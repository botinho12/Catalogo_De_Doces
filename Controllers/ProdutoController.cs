using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DocesContext _docesContext;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(DocesContext docesContext, IProdutoRepository produto)
        {
            _docesContext = docesContext;
            _produtoRepository = produto;
        }

        public IActionResult Index(int? categoriaId)
        {
            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "id", "Nome");

            var produtos = _docesContext.Produtos.Include(p => p.Categoria).AsQueryable();

            if(categoriaId.HasValue)
            {
                produtos = produtos.Where(p => p.CategoriaId == categoriaId);
            }

            return View(produtos.ToList());
        }

        public async Task<IActionResult> FiltrarPorCategoria(int id)
        {
            var produtos = await _docesContext.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == id)
                .ToListAsync();

            return View("Index", produtos); 
        }

        public IActionResult Criar()
        {
            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    produto = await _produtoRepository.CreateAsync(produto);

                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
