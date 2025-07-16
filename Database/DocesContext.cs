using System.Collections.Generic;
using CatalogoDeDoces.Helper;
using CatalogoDeDoces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CatalogoDeDoces.Database
{
    public class DocesContext : DbContext
    {
        public DocesContext(DbContextOptions<DocesContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        
        
// Inserindo um Usuario Admin para que o usuario possa acessar a tela de administrador
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().HasData(new UsuarioModel
            {
                UsuarioId = 1,
                NomeUsuario = "Admin",
                Email = "admin@admin.com",
                Senha = CriptografiaSenha.GerarHash("123456"), 
                Telefone = "11999999999",
                EhAdministrador = true
            });
        }

    }
}
