using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DocesContext _docesContext;
        private readonly IProdutoService _produtoService;

        public ProdutoController(DocesContext docesContext, IProdutoService produtoService)
        {
            _docesContext = docesContext;
            _produtoService = produtoService;
        }

        [Authorize(Policy = "EhAdministrador")]
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

        [Authorize(Policy = "EhAdministrador")]
        public async Task<IActionResult> FiltrarPorCategoria(int id)
        {
            var produtos = await _docesContext.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == id)
                .ToListAsync();

            return View("Index", produtos);
        }

        [Authorize(Policy = "EhAdministrador")]
        public IActionResult Criar()
        {
            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");

            return View();
        }

        [Authorize(Policy = "EhAdministrador")]
        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (produto.ArquivoImagem != null && produto.ArquivoImagem.Length > 0)
                    {
                        var extensao = Path.GetExtension(produto.ArquivoImagem.FileName);
                        var nomeImagem = $"{Guid.NewGuid()}{extensao}";
                        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");

                        if (!Directory.Exists(caminhoPasta))
                            Directory.CreateDirectory(caminhoPasta);

                        var caminhoCompleto = Path.Combine(caminhoPasta, nomeImagem);

                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            await produto.ArquivoImagem.CopyToAsync(stream);
                        }

                        produto.ImagemUrl = $"/imagens/{nomeImagem}";
                    }

                    await _produtoService.CriarAsync(produto);

                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamente. Detalhes: {erro.Message}";
            }

            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [Authorize(Policy = "EhAdministrador")]
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

        [Authorize(Policy = "EhAdministrador")]
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
                    await _produtoService.AtualizarAsync(produto);
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

        [Authorize(Policy = "EhAdministrador")]
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

        [Authorize(Policy = "EhAdministrador")]
        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var produto = await _docesContext.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            else
                await _produtoService.DeletarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _docesContext.Produtos.Any(e => e.Id == id);
        }
    }
}

