using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;

namespace CatalogoDeDoces.Repository
{
    public class UsuarioRepository : RepositoryGeneric<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(DocesContext context) : base(context)
        {
        }
    }
}
