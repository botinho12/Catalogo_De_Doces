using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CatalogoDeDoces.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DocesContext _docesContext;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(DocesContext docesContext, ICategoriaRepository categoriaRepository)
        {
            _docesContext = docesContext;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            var categorias = _docesContext.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "id", "Nome");


            return View(categorias.ToList());
        }

        public IActionResult Criar()
        {
          return View();    
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoriaRepository.CreateAsync(categoria);                   

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

            var categoria = await _docesContext.Categorias.FindAsync(id);
            if(categoria is null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoriaRepository.UpdateAsync(categoria);

                    TempData["MensagemSucesso"] = "Categoria alterada!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops não foi possivel alterar sua categoria! {erro.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar (int? id)
        {
            if(id is null)
            {
                return NotFound();
            }

            var categoria = await _docesContext.Categorias.FindAsync(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar (CategoriaModel categoria)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _categoriaRepository.DeleteAsync(categoria);

                    TempData["MensagemSucesso"] = "Categoria deletada com sucesso";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops não conseguimos excluir sua categoria {erro.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
