
using CatalogoDeDoces.Database;
using CatalogoDeDoces.Repository;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDoces.Infra
{
    // Classe para injeção e dependencia
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var teste = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DocesContext>(options =>
            {
                options.UseSqlServer(teste);
            });

            #region [ Repositories ]
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region [ Services ]
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<EmailService>();
            services.AddScoped<IJwtService, JwtService>();
            #endregion

            return services;
        }
    }
}