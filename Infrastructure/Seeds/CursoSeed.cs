using Domain.Abstract;
using Domain.Models;

namespace Infrastructure.Seeds
{
    internal static class CursoSeed
    {
        public static List<CourseModel> Seed { get; set; } = new List<CourseModel>()
        {
            new CourseModel
            {
                Id = 1,
                Nome= "Curso de Java",
                Informacao = "Curso de Java para iniciantes",
                Resumo = "Introdução ao Java",
                Link = "java.com",
                CargaHoraria = 60,
                CategoriaCurso = CategoriaEnum.TECNOLOGIA,
                CursoAtivo = true
            },
            new CourseModel
            {
                Id = 2,
                Nome= "Adm de Empresas",
                Informacao = "Administração de Empresas para iniciantes",
                Resumo = "Introdução a Administração de Empresas",
                Link = "admdeempresas.com",
                CargaHoraria = 12546,
                CategoriaCurso = CategoriaEnum.ADMINISTRACAO,
                CursoAtivo = true
            },
            new CourseModel
            {
                Id = 3,
                Nome= "Marketing de Redes Sociais",
                Informacao = "Introdução a marketing utilizando redes sociais",
                Resumo = "aprenda utilizar redes sociais para alavancar o seu negócio",
                Link = "marketingrs.com",
                CargaHoraria = 120,
                CategoriaCurso = CategoriaEnum.MARKETING,
                CursoAtivo = true
            },
            new CourseModel
            {
                Id = 4,
                Nome= "Introdução ao Design Gráfico",
                Informacao = "Técnicas de Designer gráfico.",
                Resumo = "Aprenda técnicas essenciais para ser um Designer gráfico.",
                Link = "designergrafico.com",
                CargaHoraria = 60,
                CategoriaCurso = CategoriaEnum.DESING,
                CursoAtivo = true
            },

        };
    }
}
