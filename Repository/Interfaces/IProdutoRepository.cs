using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        IQueryable<ProdutoModel> BuscarTodosAsync(int codigoProduto);
        Task<ProdutoModel> ObterPeloIdAsync(int codigoProduto);
        Task<ProdutoModel> AdicionarProdutoAsync(ProdutoModel produto);
        Task<ProdutoModel> AtualizarProdutoAsync(ProdutoModel produto);
        Task<bool> ApagarProduto(int codigoProduto);

    }
}