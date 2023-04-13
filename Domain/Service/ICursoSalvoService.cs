urousing Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICursoSalvo
    {
        Task<ActionResult<dynamic>> GetCursoSalvo();
        Task<ActionResult<dynamic>> GetCursoSalvo(int id);
        Task<ActionResult<dynamic>> PutCursoSalvo(int idCursoSalvoursoRequestDto cursoSalvo);
        Task<ActionResult<dynamic>> PostCaCursoSalvo(CursoSalvoRequestDto request);
        Task<ActionResult<dynamic>> DeleteCursoSalvo(int id);
    }
}
