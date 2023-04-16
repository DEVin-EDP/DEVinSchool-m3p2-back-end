namespace Domain.DTOs
{
    public class CursoSalvoResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public string StatusCurso { get; set; }
        public DateTime DataCursoSalvo { get; set; }
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public string Resumo { get; set; }
        public int CargaHoraria { get; set; }
        public string Link { get; set; }
        public string CategoriaCurso { get; set; }
    }
}
