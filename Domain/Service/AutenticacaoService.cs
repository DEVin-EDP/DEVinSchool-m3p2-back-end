using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AutenticacaoService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<dynamic>> AutenticarUsuario(LoginDTO dto)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByDto(dto);

                if (usuario == null)
                {
                    return new { Message = "Usuário e/ou senha inválidos." };
                }

                var token = _tokenService.GenerateToken(usuario);
                var result = new
                {
                    token,
                    Usuario = new
                    {
                        usuario.Id,
                        usuario.Nome,
                        usuario.Email,
                        usuario.Idade,
                        usuario.CPF,
                        usuario.DataCadastro,
                        usuario.Foto,
                        usuario.UsuarioAtivo,
                        usuario.PerfilId

                    }
                };
                usuario.Senha = "";
                return new { result };
            }
            catch
            {
                return new { Message = "Ocorreu um erro durante o processo de geração do token." };
            }
        }
    }
}
