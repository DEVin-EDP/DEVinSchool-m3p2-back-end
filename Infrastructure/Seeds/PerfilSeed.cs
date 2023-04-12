using Domain.Models;

namespace Infrastructure.Seeds
{
    internal class PerfilSeed
    {
        public static List<Perfil> Seed { get; set; } = new List<Perfil>()
        {
            new Perfil
            {
                Id = 1,
                Nome = "usuario"
            },
            new Perfil
            {
                Id = 2,
                Nome = "admin"
            },
        };
    }
}
