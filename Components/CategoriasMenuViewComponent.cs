using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Components
{
    public class CategoriasMenuViewComponent : ViewComponent
    {
        private readonly DocesContext _context;

        public CategoriasMenuViewComponent(DocesContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return View(categorias);
        }
    }
}
