using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
public class CategoriaCurso : _BaseEntity
{
    [Column("titulo")]
    public string Titulo { get; set; }
}
