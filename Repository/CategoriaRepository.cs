using System.Linq.Expressions;
using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;

namespace CatalogoDeDoces.Repository
{
    public class CategoriaRepository : RepositoryGeneric<CategoriaModel>, ICategoriaRepository
    {
        public CategoriaRepository(DocesContext context) : base(context)
        {
        }
    }
}
