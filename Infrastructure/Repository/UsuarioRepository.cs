using System.Net;
using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context) 
        {  
            _context = context; 
        }

        public async Task<Usuario> GetUsuarioByDto(LoginDTO dto)
        {
            return await _context.Usuario
                        .Include(i => i.Perfil)
                        .FirstOrDefaultAsync(f => f.Email == dto.Email && f.Senha == dto.Senha);
        }

        public async Task<ActionResult<dynamic>> GetUsuario()
        {
            if (_context.Usuario == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                List<Usuario> usuario = await _context.Usuario.Include(i => i.Perfil).ToListAsync();

                return usuario;
            }
            catch
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
        }

        public async Task<ActionResult<dynamic>> GetUsuario(int id)
        {
            if (_context.Usuario == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                var usuario = await _context.Usuario.FindAsync(id);
                IMapper mapper = ConfigureResponseMapper();
                UsuarioResponse usuarioResponse = mapper.Map<UsuarioResponse>(usuario);

                if (usuario == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return usuarioResponse;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados dos usuários." };
            }
        }

        public async Task<ActionResult<dynamic>> PutUsuario(int id, UsuarioPutRequest request)
        {
            try
            {
                Usuario usuario = await _context.Usuario.FindAsync(id);

                if(usuario == null)
                {
                    return new { Message = "O Id do usuário informado é diferente do Id da URL." };
                }

                usuario.Nome = request.Nome;
                usuario.Idade = request.Idade;
                usuario.Senha = request.Senha;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch 
            {
                return new { Message = "Ocorreu erro durante a atualização do usuário." };
            }
        }

        public async Task<ActionResult<dynamic>> PostUsuario(UsuarioRequest request)
        {
            if (_context.Usuario == null || _context.Perfil == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (_context.Usuario.Any(a => a.Email == request.Email))
            {
                return new { Message = "Email ja cadastrado em nosso sistema." };
            }
            if (_context.Usuario.Any(a => a.CPF == request.Cpf))
            {
                return new { Message = "CPF ja cadastrado em nosso sistema." };
            }
            if (!ValidaFoto(request.Foto))
            {
                return new { Message = "Tamanho da imagem maior do que 10MB." };
            }

            try
            {
                IMapper mapper = ConfigurePostMapper();
                Usuario usuario = mapper.Map<Usuario>(request);

                usuario.PerfilId = 1;
                usuario.Perfil = await _context.Perfil.FindAsync(usuario.PerfilId);

                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão de usuário." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteUsuario(int id)
        {
            if (!ExisteUsuario(id))
            {
                return new { Message = "O Id do usuário informado não existe." };
            }
            if(_context.Usuario == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if(usuario == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão do usuário." };
            }
        }

        public async Task<ActionResult<dynamic>> RecuperaUsuario(string email)
        {
            if (_context.Usuario == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                // Find the user containing the provided email
                var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email.Contains(email));

                if (usuario == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                EnviaEmailService.EnviaEmail(usuario.Email, "Recuperação de senha", usuario.Senha);

                return new { Message = "Senha enviada para o email cadastrado!" };
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados dos usuários." };
            }
        }
        private bool ExisteUsuario(int id)
        {
            return _context.Usuario.Any(a => a.Id == id);
        }

        private bool ValidaFoto(string foto)
        {
            if (foto == null)
            {
                return true;
            }
            var TamanhoEmMb = DownloadFoto(foto);

            if (TamanhoEmMb > 10)
            {
                return false;
            }
            return true;
        }

        private double DownloadFoto(string foto)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] FotoData = webClient.DownloadData(foto);

                int Tamanho = FotoData.Length;
                double TamanhoEmMb = Tamanho / (1024.0 * 1024.0);
                return TamanhoEmMb;
            }
        }

        private static IMapper ConfigurePostMapper()
        {
            var configuracao = new MapperConfiguration(cfg => cfg.CreateMap<UsuarioRequest, Usuario>());
            var mapper = configuracao.CreateMapper();

            return mapper;
        }

        private static IMapper ConfigureResponseMapper()
        {
            var configuracao = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioResponse>());
            var mapper = configuracao.CreateMapper();

            return mapper;
        }

        
    }
}
