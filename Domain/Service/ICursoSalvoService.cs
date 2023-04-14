using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICursoSalvoService
    {
        Task<ActionResult<dynamic>> GetCursoSalvo();
        Task<ActionResult<dynamic>> GetCursoSalvo(int id);
        Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest cursoSalvo);
        Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request);
        Task<ActionResult<dynamic>> DeleteCursoSalvo(int id);
    }
}
