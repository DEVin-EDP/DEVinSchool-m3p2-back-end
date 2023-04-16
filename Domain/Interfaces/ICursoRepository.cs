using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<ActionResult<dynamic>> GetCurso();
        Task<ActionResult<dynamic>> GetCurso(int id);
        Task<ActionResult<dynamic>> GetCursoCategoria(int id);
        Task<ActionResult<dynamic>> GetCursoPesquisa(string valor);
        Task<ActionResult<dynamic>> PutCurso(int id, CursoPostRequest request);
        Task<ActionResult<dynamic>> PostCurso(CursoPostRequest request);
        Task<ActionResult<dynamic>> DeleteCurso(int id);
    }
}
