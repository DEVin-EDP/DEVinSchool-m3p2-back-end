using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services) 
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }

}
