using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service
{
    public class CategoriaCursoRepository : ICategoriaCursoRepository
    {
        protected readonly ApplicationContext _context;

        public CategoriaCursoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<dynamic>> GetCategoriaCurso()
        {
            try
            {
                if (_context.CategoriaCurso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                List<CategoriaCurso> categoriaCurso = await _context.CategoriaCurso.ToListAsync();

                return categoriaCurso;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados." };
            }
        }

        public async Task<ActionResult<dynamic>> GetCategoriaCurso(int id)
        {
            try
            {
                if (_context.CategoriaCurso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var categoriaCurso = await _context.CategoriaCurso.FindAsync(id);

                if (categoriaCurso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return categoriaCurso;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados da categoria do curso." };
            }
        }

        public async Task<ActionResult<dynamic>> PutCategoriaCurso(int id, CategoriaCursoRequestDto request)
        {
            try
            {
                CategoriaCurso categoriacurso = await _context.CategoriaCurso.FindAsync(id);

                if (categoriacurso == null)
                {
                    return new { Message = "O Id do usuário informado é diferente do Id da URL." };
                }

                categoriacurso.Titulo = request.Titulo;

                _context.Entry(categoriacurso).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante a atualização da categoria do curso." };
            }
        }

        public async Task<ActionResult<dynamic>> PostCategoriaCurso(CategoriaCursoRequestDto request)
        {
            try
            {
                if (ExisteCategoriaRegistrada(request))
                {
                    return new { Mensage = "Categoria ja registrado." };
                }

                IMapper mapper = ConfigurePostMapper();
                CategoriaCurso categoriacurso = mapper.Map<CategoriaCurso>(request);

                _context.CategoriaCurso.Add(categoriacurso);
                await _context.SaveChangesAsync();

                return  categoriacurso;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão da categoria do curso." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteCategoriaCurso(int id)
        {
            if (!ExisteCategoriaCurso(id))
            {
                return new { Message = "O Id da categoria curso informado não existe." };
            }
            if (_context.CategoriaCurso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                CategoriaCurso categoriacurso = await _context.CategoriaCurso.FindAsync(id);

                if (categoriacurso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.CategoriaCurso.Remove(categoriacurso);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão da categoria curso." };
            }
        }

        private bool ExisteCategoriaCurso(int id)
        {
            return _context.CategoriaCurso.Any(a => a.Id == id);
        }

        private bool ExisteCategoriaRegistrada(CategoriaCursoRequestDto request)
        {
            return _context.CategoriaCurso.Any(a => a.Titulo == request.Titulo);
        }

        private static IMapper ConfigurePostMapper()
        {
            var configuracao = new MapperConfiguration(cfg => cfg.CreateMap<CategoriaCursoRequestDto, CategoriaCurso>());
            var mapper = configuracao.CreateMapper();

            return mapper;
        }
    }
}
