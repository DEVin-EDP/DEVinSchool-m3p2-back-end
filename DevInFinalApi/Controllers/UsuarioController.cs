using Domain.DTOs;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevInFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> GetUsuario()
        {
            return await _usuarioService.GetUsuario();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> GetUsuario(int id)
        {
            return await _usuarioService.GetUsuario(id);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = ("usuario, admin"))]
        public async Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest request)
        {
            return await _usuarioService.PutUsuario(id, request);
        }

        [HttpPost("registro")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request)
        {
            return await _usuarioService.PostUsuario(request);
        }

        [HttpDelete("deletar-usuario/{id}")]
        [Authorize(Roles = ("admin"))]
        public async Task<ActionResult<dynamic>> DeleteUsuario(int id)
        {
            return await _usuarioService.DeleteUsuario(id);
        }

        [HttpPost("recuperaUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> RecuperaUsuario(string email)
        {
            return await _usuarioService.RecuperaUsuario(email);
        }
    }
}
