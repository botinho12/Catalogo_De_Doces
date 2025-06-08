using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
