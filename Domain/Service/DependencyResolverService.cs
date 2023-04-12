using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

        }
    }

}
