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
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UsuarioModel?> BuscarUsuarioPorTokenAsync(string token)
        {
            return await _context.Usuarios
               .FirstOrDefaultAsync(u =>
                   u.TokenRedefinicaoSenha == token &&
                   u.ExpiracaoToken.HasValue &&
                   u.ExpiracaoToken > DateTime.Now);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
