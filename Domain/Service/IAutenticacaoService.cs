using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface IAutenticacaoService
    {
        Task<ActionResult<dynamic>> AutenticarUsuario(LoginDTO dto);
    }
}
