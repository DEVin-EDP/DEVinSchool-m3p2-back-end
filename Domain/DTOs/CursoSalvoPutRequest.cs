using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstract;

namespace Domain.DTOs
{
    public class CursoSalvoPutRequest
    {
        public StatusCursoEnum StatusCurso { get; set; }

    }
}
