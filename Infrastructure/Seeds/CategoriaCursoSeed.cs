using Domain.Models;

namespace Infrastructure.Seeds
{
    internal class CategoriaCursoSeed
    {
        public static List<CategoriaCurso> Seed { get; set; } = new List<CategoriaCurso>()
        {
            new CategoriaCurso
            {
                Id = 1,
                Titulo = "Tecnologia"
            },
            new CategoriaCurso
            {
                Id = 2, 
                Titulo = "Administração"
            },
            new CategoriaCurso
            {
                Id = 3,
                Titulo= "Marketing",
            },
            new CategoriaCurso
            {
                Id = 4,
                Titulo= "Design",
            },
        };
    }
}
