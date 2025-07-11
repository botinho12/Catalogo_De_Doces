using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class ListaProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarLista()
        {
            return View();
        }
    }
}
