using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface IUsuarioService
    {
        Task<ActionResult<dynamic>> GetUsuario();
        Task<ActionResult<dynamic>> GetUsuario(int id);
        Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest usuario);
        Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request);
        Task<ActionResult<dynamic>> DeleteUsuario(int id);
        Task<ActionResult<dynamic>> RecuperaUsuario(string email);
    }
}
