using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CursoModel : _BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("informacao")]
        public string Informacao { get; set; }
        [Column("resumo")]
        public string Resumo { get; set; }
        [Column("carga_horaria")]
        public int CargaHoraria { get; set; }
        [Column("imagem_curso")]
        public string Link { get; set; }
        [Column("categoria_curso")]
        public CategoriaEnum CategoriaCurso { get; set; }
        [Column("curso_ativo")]
        public bool CursoAtivo { get; set; }
    }
}
