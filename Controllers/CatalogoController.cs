using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly DocesContext _context;

        public CatalogoController(DocesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos); 
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }
    }
}
