
using Domain.Models;

namespace Domain.Service
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioModel usuario);
    }
}
