using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByDto(UsuarioRequest dto);
        Task<ActionResult<dynamic>> GetUsuario();
        Task<ActionResult<dynamic>> GetUsuario(int id);
        Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest usuario);
        Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request);
        Task<ActionResult<dynamic>> DeleteUsuario(int id);
    }
}
