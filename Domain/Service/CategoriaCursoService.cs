using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class CategoriaCursoService : ICategoriaCursoService
    {
        private readonly ICategoriaCursoRepository _categoriaCursoRepository;

        public CategoriaCursoService(ICategoriaCursoRepository categoriaCursoRepository)
        {
            _categoriaCursoRepository = categoriaCursoRepository;
        }

        public async Task<ActionResult<dynamic>> GetCategoriaCurso()
        {
            return await _categoriaCursoRepository.GetCategoriaCurso();
        }

        public async Task<ActionResult<dynamic>> GetCategoriaCurso(int id)
        {
            return await _categoriaCursoRepository.GetCategoriaCurso(id);
        }

        public async Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoRepository.PutCategoriaCurso(id, request);
        }

        public async Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoRepository.PostCategoriaCurso(request);
        }

        public async Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id)
        {
            return await _categoriaCursoRepository.DeleteCategoriaCurso(id);
        }
    }
}
