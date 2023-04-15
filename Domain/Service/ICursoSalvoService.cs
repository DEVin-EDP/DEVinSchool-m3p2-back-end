using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICursoSalvoService
    {
        Task<ActionResult<dynamic>> GetCursoSalvo();
        Task<ActionResult<dynamic>> GetCursoSalvo(int id);
        Task<ActionResult<dynamic>> GetCursoSalvoHistorico(int id);
        Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest request);
        Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request);
        Task<ActionResult<dynamic>> DeleteCursoSalvo(int id);
    }
}
