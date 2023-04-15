using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CursoSalvoController : ControllerBase
    {
        private readonly ICursoSalvoService _cursoSalvoService;

        public CursoSalvoController(ICursoSalvoService cursoSalvoService)
        {
            _cursoSalvoService = cursoSalvoService;
        }

        [HttpGet]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCursoSalvo()
        {
            return await _cursoSalvoService.GetCursoSalvo();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id)
        {
            return await _cursoSalvoService.GetCursoSalvo(id);
        }

        [HttpGet("historico/{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCursoSalvoHistorico(int id)
        {
            return await _cursoSalvoService.GetCursoSalvoHistorico(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ("usuario,admin"))]
        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id,[FromForm]CursoSalvoPutRequest request)
        {
            return await _cursoSalvoService.PutCursoSalvo(id, request);
        }

        [HttpPost]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request)
        {
            return await _cursoSalvoService.PostCursoSalvo(request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id)
        {
            return await _cursoSalvoService.DeleteCursoSalvo(id);
        }
    }
}
