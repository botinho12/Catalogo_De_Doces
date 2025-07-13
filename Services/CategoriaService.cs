using System.Linq.Expressions;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services.Interfaces;

namespace CatalogoDeDoces.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaModel>> ObterTodosAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<CategoriaModel> ObterPorIdAsync(Expression<Func<CategoriaModel, bool>> predicate)
        {
            return await _categoriaRepository.GetAsync(predicate);
        }

        public async Task<CategoriaModel> CriarAsync(CategoriaModel categoria)
        {
            if (categoria.Nome == null)
                throw new ArgumentNullException("O nome da categoria não pode ser nulo");

            return await _categoriaRepository.CreateAsync(categoria);
        }

        public async Task<CategoriaModel> AtualizarAsync(CategoriaModel categoria)
        {
            return await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task<CategoriaModel> DeletarAsync(int Id)
        {
            var categoria = await _categoriaRepository.GetAsync(c => c.Id == Id);
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");
            else
                await _categoriaRepository.DeleteAsync(categoria);

            return categoria;
        }
    }
}
