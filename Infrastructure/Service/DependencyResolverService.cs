using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<ICategoriaCursoRepository, CategoriaCursoRepository>();
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
