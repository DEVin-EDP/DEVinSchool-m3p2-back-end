using Domain.DTOs;
using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriaCursoController : ControllerBase
    {
        private readonly ICategoriaCursoService _categoriaCursoService;
        public CategoriaCursoController(ICategoriaCursoService categoriaCursoService)
        {
            _categoriaCursoService = categoriaCursoService;
        }
        // GET: api/<CategoriaCursoController>
        [HttpGet]
        public async Task<ActionResult<dynamic>> GetCategoriaCurso()
        {
            return await _categoriaCursoService.GetCategoriaCurso();
        }

        // GET api/<CategoriaCursoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetCategoriaCurso(int id)
        {
            return await _categoriaCursoService.GetCategoriaCurso(id);
        }

        // POST api/<CategoriaCursoController>
        [HttpPost]
        public async Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoService.PostCategoriaCurso(request);
        }

        // PUT api/<CategoriaCursoController>/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto request)
        {
            return await _categoriaCursoService.PutCategoriaCurso(id, request);
        }

        // DELETE api/<CategoriaCursoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id)
        {
            return await _categoriaCursoService.DeleteCategoriaCurso(id);
        }
    }
}
