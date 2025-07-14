using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Controllers
{
    public class CatalogoController(DocesContext context) : Controller
    {
        public IActionResult Index()
        {
            var produtos = context.Produtos.ToList();
            return View(produtos); 
        }

        public IActionResult Detalhes(int id)
        {
            var produto = context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
            
        }
    }
}
