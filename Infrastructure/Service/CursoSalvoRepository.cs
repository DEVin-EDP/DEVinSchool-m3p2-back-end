﻿using AutoMapper;
using Azure.Core;
using Domain.Abstract;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service
{
    public class CursoSalvoRepository : ICursoSalvoRepository
    {
        private readonly ApplicationContext _context;

        public List<CursoSalvoResponse> CursoSalvos { get; set; }
        public CursoSalvoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<dynamic>> GetCursoSalvo()
        {
            if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            CursoSalvos = await _context.CursoSalvo.Include(i => i.Curso)
                .Join(_context.CategoriaCurso,
                      s => s.Curso.CategoriaCursoId,
                      c => c.Id,
                      (s, c) => new CursoSalvoResponse()
                      {
                          Link = s.Curso.Link,
                          Nome = s.Curso.Nome,
                          Informacao = s.Curso.Informacao,
                          CargaHoraria = s.Curso.CargaHoraria,
                          CategoriaCurso = c.Titulo,
                          Resumo = s.Curso.Resumo,
                      }).ToListAsync();

            return CursoSalvos;
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id)
        {
            if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (!ExisteCursoSalvo(id))
            {
                return new { Message = "O Id do curso salvo informado é diferente do Id da URL." };
            }

            var cursoSalvo = await _context.CursoSalvo
                .Include(i => i.Curso).Where(w => w.Id == id)
                .Join(_context.CategoriaCurso,
                      s => s.Curso.CategoriaCursoId,
                      c => c.Id,
                      (s, c) => new CursoSalvoResponse()
                      {
                          Link = s.Curso.Link,
                          Nome = s.Curso.Nome,
                          Informacao = s.Curso.Informacao,
                          CargaHoraria = s.Curso.CargaHoraria,
                          CategoriaCurso = c.Titulo,
                          Resumo = s.Curso.Resumo,
                      }).FirstAsync();

            return cursoSalvo;
        }
        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id, CursoSalvoPutRequest request)
        {
            if (request == null)
            {
                return new { Message = "Necessário preencher todas as informações de forma correta." };
            }
            if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (!ExisteCursoSalvo(id))
            {
                return new { Message = "O Id do curso salvo é diferente do Id da URL." };
            }

            try
            {
                var cursoSalvo = await _context.CursoSalvo.FindAsync(id);

                cursoSalvo.StatusCurso = request.StatusCurso;
                _context.Entry(cursoSalvo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return cursoSalvo;

            }
            catch
            {
                return new { Message = "Ocorreu erro durante a atualização do curso salvo." };
            }
            }
        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request)
        {
            if (_context.CursoSalvo == null || _context.Usuario == null || _context.Curso == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (!ExisteUsuario(request.UsuarioId) || !ExisteCurso(request.CursoId))
            {
                return new { Message = "O Id do curso ou usuário salvo é diferente do Id da URL." };
            }

            try
            {
                var usuario = await _context.Usuario.FindAsync(request.UsuarioId);
                var curso = await _context.Curso.FindAsync(request.CursoId);

                if (usuario == null ||  curso == null)
                {
                    return new { Message = "Ocorreu erro durante o processo de inclusão do curso na lista de cursos salvos." };
                }

                var cursoSalvo = new CursoSalvo()
                {
                    UsuarioId = request.UsuarioId,
                    Usuario = usuario,
                    CursoId = request.CursoId,
                    Curso = curso
                };

                _context.CursoSalvo.Add(cursoSalvo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão do curso na lista de cursos salvos." };
            }
        }
        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id)
        {
            if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (!ExisteCursoSalvo(id))
            {
                return new { Message = "O Id do curso salvo é diferente do Id da URL." };
            }

            try
            {
                var cursoSalvo = await _context.CursoSalvo.FindAsync(id);

                if (cursoSalvo == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.CursoSalvo.Remove(cursoSalvo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão do curso salvo." };
            }
        }
        private bool ExisteCursoSalvo(int id)
        {
            return _context.CursoSalvo.Any(a => a.Id == id);
        }
        private bool ExisteUsuario(int id)
        {
            return _context.Usuario.Any(a => a.Id == id);
        }
        private bool ExisteCurso(int id)
        {
            return _context.Curso.Any(a => a.Id == id);
        }
    }
}