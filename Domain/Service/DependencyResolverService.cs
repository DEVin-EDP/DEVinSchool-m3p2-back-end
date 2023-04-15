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
            services.AddScoped<ICategoriaCursoService, CategoriaCursoService>();
            services.AddScoped<ICursoSalvoService, CursoSalvoService>();
            services.AddScoped<ICursoService, CursoService>();
        }
    }
}
