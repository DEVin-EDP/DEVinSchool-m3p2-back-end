using System.ComponentModel.DataAnnotations;
namespace Domain.Abstract
{
    public enum StatusCursoEnum
    {
        [Display(Name = "REALIZAR_NO_FUTURO")]
        REALIZAR_NO_FUTURO,
        [Display(Name = "EM_ANDAMENTO")]
        EM_ANDAMENTO,
        [Display(Name = "CONCLUIDO")]
        CONCLUIDO
    }
}
