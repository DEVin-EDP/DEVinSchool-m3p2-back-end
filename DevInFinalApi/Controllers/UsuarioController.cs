using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        //[Authorize(Roles = ("Usuario"))]
        public async Task<ActionResult<dynamic>> GetUsuario()
        {
            return await _usuarioService.GetUsuario();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = ("Usuario"))]
        public async Task<ActionResult<dynamic>> GetUsuario(int id)
        {
            return await _usuarioService.GetUsuario(id);
        }

        [HttpPut("update/{id}")]
        //[Authorize(Roles = ("Usuario"))]
        public async Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest request)
        {
            return await _usuarioService.PutUsuario(id, request);
        }

        [HttpPost("registro")]
        public async Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request)
        {
            return await _usuarioService.PostUsuario(request);
        }

        [HttpDelete("deletar-usuario/{id}")]
        //[Authorize(Roles = (""))]
        public async Task<ActionResult<dynamic>> DeleteUsuario(int id)
        {
            return await _usuarioService.DeleteUsuario(id);
        }
    }
}
