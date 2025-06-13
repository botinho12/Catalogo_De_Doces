using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            if (categoriaId.HasValue)
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
                if (ModelState.IsValid)
                {
                    produto = await _produtoRepository.CreateAsync(produto);

                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _docesContext.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);

        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoModel produto, int id)
        {
            if (produto.Id != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoRepository.UpdateAsync(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _docesContext.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _docesContext.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var produto = await _docesContext.Produtos.FindAsync(id);
            if (produto != null)
            {
               await _produtoRepository.DeleteAsync(produto);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _docesContext.Produtos.Any(e => e.Id == id);
        }
    }
}

