using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Repository
{
    public class UsuarioRepository : RepositoryGeneric<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(DocesContext context) : base(context)
        {       
        }

        public async Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email)
        {
           await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            return new UsuarioModel
            {
                Email = email,
            };
        }
    }
}
