using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class CursoSalvoService : ICursoSalvoService
    {
        public readonly ICursoSalvoRepository _cursoSalvoRepository;

        public CursoSalvoService(ICursoSalvoRepository cursoSalvoRepository)
        {
            _cursoSalvoRepository = cursoSalvoRepository;
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvo()
        {
            return await _cursoSalvoRepository.GetCursoSalvo();
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id)
        {
            return await _cursoSalvoRepository.GetCursoSalvo(id);
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvoHistorico(int id)
        {
            return await _cursoSalvoRepository.GetCursoSalvoHistorico(id);
        }

        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest request)
        {
            return await _cursoSalvoRepository.PutCursoSalvo(id, request);
        }

        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request)
        {
            return await _cursoSalvoRepository.PostCursoSalvo(request);
        }

        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id)
        {
            return await _cursoSalvoRepository.DeleteCursoSalvo(id);
        }
    }
}
