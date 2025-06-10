using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;

namespace CatalogoDeDoces.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task<ProdutoModel> AdicionarProdutoAsync(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApagarProduto(int codigoProduto)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> AtualizarProdutoAsync(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProdutoModel> BuscarTodosAsync(int codigoProduto)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> ObterPeloIdAsync(int codigoProduto)
        {
            throw new NotImplementedException();
        }
    }
}
