using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CursoSalvoModel : _BaseEntity
    {
        [Column("status_curso")]
        public StatusCursoEnum StatusCurso { get; set; }
        [Column("data_curso_salvo")]
        public DateOnly DataCursoSalvo { get; set; }
        [ForeignKey("IdUsuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("IdCurso")]
        public int CursoId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public CursoModel Curso { get; set; }
    }
}
