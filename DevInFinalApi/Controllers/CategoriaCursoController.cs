using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaCursoController : ControllerBase
    {
        private readonly ICategoriaCursoService _categoriaCursoService;
        public CategoriaCursoController(ICategoriaCursoService categoriaCursoService)
        {
            _categoriaCursoService = categoriaCursoService;
        }

        [HttpGet]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCategoriaCurso()
        {
            return await _categoriaCursoService.GetCategoriaCurso();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetCategoriaCurso(int id)
        {
            return await _categoriaCursoService.GetCategoriaCurso(id);
        }
        
        [HttpPost]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoService.PostCategoriaCurso(request);
        }
        
        [HttpPut("update/{id}")]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoService.PutCategoriaCurso(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id)
        {
            return await _categoriaCursoService.DeleteCategoriaCurso(id);
        }
    }
}
