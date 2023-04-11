using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CursoFavoritadoModel : _BaseEntity
    {
        [ForeignKey("IdUsuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("IdCourse")]
        public int CursoId { get; set; }
        public UserModel Usuario { get; set; }
        public CourseModel Course { get; set; }
    }
}
