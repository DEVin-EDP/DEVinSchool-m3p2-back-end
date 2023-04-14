using Domain.Abstract;

namespace Domain.DTOs
{
    public class CursoSalvoResponse
    {
        public StatusCursoEnum StatusCurso { get; set; }
        public DateTime DataCursoSalvo { get; set; }
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public string Resumo { get; set; }
        public int CargaHoraria { get; set; }
        public string Link { get; set; }
        public string CategoriaCurso { get; set; }
    }
}
