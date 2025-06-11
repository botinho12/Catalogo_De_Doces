using System.Linq.Expressions;
using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;

namespace CatalogoDeDoces.Repository
{
    public class ProdutoRepository : RepositoryGeneric<ProdutoModel>, IProdutoRepository
    {
        public ProdutoRepository(DocesContext context) : base(context)
        {
        }
    }
}
