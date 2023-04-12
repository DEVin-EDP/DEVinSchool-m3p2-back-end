using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<ActionResult<dynamic>> GetCurso()
        {
            return await _cursoRepository.GetCurso();
        }

        public async Task<ActionResult<dynamic>> GetCurso(int id)
        {
            return await _cursoRepository.GetCurso(id);
        }
        public async Task<ActionResult<dynamic>> GetCursoCategoria(int id)
        {
            return await _cursoRepository.GetCurso(id);
        }

        public async Task<ActionResult<dynamic>> PutCurso(int id, CursoResponse request)
        {
            return await _cursoRepository.PutCurso(id, request);
        }

        public async Task<ActionResult<dynamic>> PostCurso(CursoResponse request)
        {
            return await _cursoRepository.PostCurso(request);
        }

        public async Task<ActionResult<dynamic>> DeleteCurso(int id)
        {
            return await _cursoRepository.DeleteCurso(id);
        }
    }
}
