using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoSalvoController : ControllerBase
    {
        private readonly ICursoSalvoService _cursoSalvoService;

        public CursoSalvoController(ICursoSalvoService cursoSalvoService)
        {
            _cursoSalvoService = cursoSalvoService;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetCursoSalvo()
        {
            return await _cursoSalvoService.GetCursoSalvo();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id)
        {
            return await _cursoSalvoService.GetCursoSalvo(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest request)
        {
            return await _cursoSalvoService.PutCursoSalvo(id, request);
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request)
        {
            return await _cursoSalvoService.PostCursoSalvo(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id)
        {
            return await _cursoSalvoService.DeleteCursoSalvo(id);
        }
    }
}
