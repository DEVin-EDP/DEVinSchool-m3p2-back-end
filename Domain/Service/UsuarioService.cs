using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ActionResult<dynamic>> GetUsuario()
        {
            return await _usuarioRepository.GetUsuario();
        }
        
        public async Task<ActionResult<dynamic>> GetUsuario(int id)
        {
            return await _usuarioRepository.GetUsuario(id);
        }
        
        public async Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest request)
        {
            return await _usuarioRepository.PutUsuario(id, request);
        }

        public async Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request)
        {
            return await _usuarioRepository.PostUsuario(request);
        }

        public async Task<ActionResult<dynamic>> DeleteUsuario(int id)
        {
            return await _usuarioRepository.DeleteUsuario(id);
        }

        public async Task<ActionResult<dynamic>> RecuperaUsuario(string email)
        {
            return await _usuarioRepository.RecuperaUsuario(email);
        }
    }
}
