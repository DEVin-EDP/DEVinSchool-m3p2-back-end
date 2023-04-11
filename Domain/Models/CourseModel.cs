using Domain.Abstract;

namespace Domain.Models
{
    public class CourseModel : _BaseEntity
    {
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public string Resumo { get; set; }
        public int CargaHoraria { get; set; }
        public string Link { get; set; }
        public CategoriaEnum CategoriaCurso { get; set; }
        public bool CursoAtivo { get; set; }
    }
}
