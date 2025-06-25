using System.Linq.Expressions;
using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> ObterTodosAsync();
        Task<ProdutoModel> ObterPorIdAsync(Expression<Func<ProdutoModel, bool>> predicate);
        Task<ProdutoModel> CriarAsync(ProdutoModel produto);
        Task<ProdutoModel> AtualizarAsync(ProdutoModel produto);
        Task<ProdutoModel> DeletarAsync(int Id);
    }
}
