namespace Domain.DTOs
{
    internal class CursosInfoRequest
    {
        public string Nome { get; set; }
        public string Link { get; set; }
        public int CategoriaCursoId { get; set; }
        public string Informacao { get; set; }
        public string Resumo { get; set; }
        public int CargaHoraria { get; set; }
    }
}
