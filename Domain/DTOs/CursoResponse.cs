namespace Domain.DTOs
{
    public class CursoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public string Resumo { get; set; }
        public int CargaHoraria { get; set; }
        public string Link { get; set; }
        public bool CursoAtivo { get; set; }
        public int CategoriaCursoId { get; set; }
    }
}
