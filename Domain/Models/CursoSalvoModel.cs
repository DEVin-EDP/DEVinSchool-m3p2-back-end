using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CursoSalvoModel : _BaseEntity
    {
        public StatusCursoEnum StatusCurso { get; set; }
        public DateOnly DataCursoSalvo { get; set; }
        [ForeignKey("IdUsuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("IdCourse")]
        public int CursoId { get; set; }
        public UserModel Usuario { get; set; }
        public CourseModel Course { get; set; }
    }
}
