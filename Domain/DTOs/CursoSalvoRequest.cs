using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstract;
using Domain.Models;

namespace Domain.DTOs
{
    public class CursoSalvoRequest
    {
        public string StatusCurso { get; set; }
        public DateTime DataCursoSalvo { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        
    }
}
