using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Service
{
    public class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:ServerConnection",
                x => x.MigrationsAssembly("Infrastructure")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICategoriaCursoRepository, CategoriaCursoRepository>();
            services.AddScoped<ICursoSalvoRepository, CursoSalvoRepository>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>();
            using (var dbContext = new ApplicationContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
