using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICursoService
    {
        Task<ActionResult<dynamic>> GetCurso();
        Task<ActionResult<dynamic>> GetCurso(int id);
        Task<ActionResult<dynamic>> GetCursoCategoria(int id);
        Task<ActionResult<dynamic>> PutCurso(int id, CursoResponse request);
        Task<ActionResult<dynamic>> PostCurso(CursoResponse request);
        Task<ActionResult<dynamic>> DeleteCurso(int id);
    }
}
