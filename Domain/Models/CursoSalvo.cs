using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CursoSalvo : _BaseEntity
    {
        [Column("status_curso")]
        public StatusCursoEnum StatusCurso { get; set; }
        [Column("data_curso_salvo")]
        public DateTime DataCursoSalvo { get; set; } = DateTime.Now;
        [ForeignKey("IdUsuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("IdCurso")]
        public int CursoId { get; set; }
        public Usuario Usuario { get; set; }
        public Curso Curso { get; set; }
    }
}
