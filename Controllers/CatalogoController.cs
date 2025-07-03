using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
