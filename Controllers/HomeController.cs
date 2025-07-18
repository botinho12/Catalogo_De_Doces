using System.Diagnostics;
using CatalogoDeDoces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult QuemSomos()
        {
            return View();
        }

        public IActionResult Lojas()
        {
            return View();
        }
    }
}
