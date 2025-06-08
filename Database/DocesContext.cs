using System.Collections.Generic;
using CatalogoDeDoces.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
