using CatalogoDeDoces.Models;
using System.Linq.Expressions;

namespace CatalogoDeDoces.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaModel>> ObterTodosAsync();
        Task<CategoriaModel> ObterPorIdAsync(Expression<Func<CategoriaModel, bool>> predicate);
        Task<CategoriaModel> CriarAsync(CategoriaModel categoria);
        Task<CategoriaModel> AtualizarAsync(CategoriaModel categoria);
        Task<CategoriaModel> DeletarAsync(int Id);
    }
}
