using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DocesContext _docesContext;

        public ProdutoController(DocesContext docesContext)
        {
            _docesContext = docesContext;
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

            return View("Index", produtos); // Ou uma view específica, se preferir
        }
    }
}
