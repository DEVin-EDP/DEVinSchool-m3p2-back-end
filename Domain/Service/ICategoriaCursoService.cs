using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICategoriaCursoService
    {
        Task<ActionResult<dynamic>> GetCategoriaCurso();
        Task<ActionResult<dynamic>> GetCategoriaCurso(int id);
        Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto categoriaCurso);
        Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request);
        Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id);
    }
}
