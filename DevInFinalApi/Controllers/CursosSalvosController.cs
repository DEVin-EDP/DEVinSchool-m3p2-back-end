using Azure.Core;
using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CursosSalvosController : ControllerBase
    {
        private readonly ICursoSalvoService _cursoSalvoService;
        

        public CursosSalvosController(ICursoSalvoService cursoSalvoService)
        {
            _cursoSalvoService = cursoSalvoService;
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvo()
        {
            return await _cursoSalvoService.GetCursoSalvo();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id)
        {
            return await _cursoSalvoService.GetCursoSalvo(id);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest request)
        {
            return await _cursoSalvoService.PutCursoSalvo(id, request);
        }

        [HttpPost("registro")]
        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request)
        {
            return await _cursoSalvoService.PostCursoSalvo(request);
        }

        [HttpDelete("deletar-cursoSalvo/{id}")]
        //[Authorize(Roles = (""))]
        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id)
        {
            return await _cursoSalvoService.DeleteCursoSalvo(id);
        }
    }
}
