using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface ICategoriaCursoRepository
    {
    //    Task<CategoriaCurso> GetUsuarioByDto(CategoriaCurso dto);
        Task<ActionResult<dynamic>> GetCategoriaCurso();
        Task<ActionResult<dynamic>> GetCategoriaCurso(int id);
        Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto categoriaCurso);
        Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request);
        Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id);
    }
}
