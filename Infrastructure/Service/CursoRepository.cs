using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service
{
    public class CursoRepository : ICursoRepository
    {
        protected readonly ApplicationContext _context;

        public CursoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<dynamic>> GetCurso()
        {
            if (_context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                List<Curso> curso = await _context.Curso.ToListAsync();

                return curso;
            }
            catch
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
        }

        public async Task<ActionResult<dynamic>> GetCurso(int id)
        {
            if (_context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                var curso = _context.Curso.FindAsync(id);

                if (curso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return curso;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados dos cursos." };
            }
        }

        public async Task<ActionResult<dynamic>> GetCursoCategoria(int id)
        {
            if (_context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            try
            {
                var curso = await _context.Curso.Where(x => x.CategoriaCursoId == id).Select(x => new CursosTelaInicialRequest()
                {
                    Nome = x.Nome,
                    Link = x.Link,
                    CategoriaCursoId = x.CategoriaCursoId
                }).FirstAsync();

                if (curso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                return curso;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados dos cursos." };
            }
        }
        public async Task<ActionResult<dynamic>> PutCurso(int id, Curso request)
        {
            if (id != request.Id)
            {
                return new { Message = "O Id do curso informado é diferente do Id da URL." };
            }

            try
            {
                Curso curso = await _context.Curso.FindAsync(id);

                if (curso == null)
                {
                    return new { Message = "O Id do curso informado é diferente do Id da URL." };
                }

                curso.Nome = request.Nome;
                curso.Informacao = request.Informacao;
                curso.Resumo = request.Resumo;
                curso.CargaHoraria = request.CargaHoraria;
                curso.Link = request.Link;
                curso.CursoAtivo = request.CursoAtivo;
                curso.CategoriaCursoId = request.CategoriaCursoId;

                _context.Entry(curso).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante a atualização do curso." };
            }
        }

        public async Task<ActionResult<dynamic>> PostCurso(Curso request)
        {
            if (_context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                _context.Curso.Add(request);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão do curso." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteCurso(int id)
        {
            if (!ExisteCurso(id))
            {
                return new { Message = "O Id do curso informado não existe." };
            }
            if (_context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }

            try
            {
                var curso = await _context.Curso.FindAsync(id);

                if (curso == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão do curso." };
            }
        }

        private bool ExisteCurso(int id)
        {
            return _context.Curso.Any(a => a.Id == id);
        }
    }
}
