using AutoMapper;
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
        protected readonly ApplicationContext _context;

        public CursoSalvoRepository(ApplicationContext context) 
        {  
            _context = context; 
        }

        public async Task<ActionResult<dynamic>> GetCursoSalvo(int id, CursoSalvoPutRequest? request);
        {
          
            if (Enum.TryParse(request, out StatusCursoEnum.CONCLUIDO)){
                    request == StatusCursoEnum.CONCLUIDO
            } else if(Enum.TryParse(request, out StatusCursoEnum.REALIZAR_NO_FUTURO)){
                    request == StatusCursoEnum.REALIZAR_NO_FUTURO
            } else if(Enum.TryParse(request, out StatusCursoEnum.EM_ANDAMENTO)){
                    request == StatusCursoEnum.EM_ANDAMENTO
            } else {
                return new { Message = "O valor informado não condiz com o esperado" };
            }            

            try
            {

                if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
                var CursoSalvo = _context.CursoSalvo.FindAsync(id);

                if(request != null)
                {
                    var CursoSalvo = CursoSalvo.Where(a => a.StatusCurso == enum.StatusCursoEnum);
                }


                if (CursoSalvo == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return CursoSalvo;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados dos cursos salvos." };
            }
        }

        public async Task<ActionResult<dynamic>> PutCursoSalvo(int id, Int CursoSalvoPutRequest cursoSalvo);
        {
            if (id != request.Id)
            {
                return new { Message = "O Id do usuário informado é diferente do Id da URL." };
            }

            try
            {
                CursoSalvo CursoSalvo = await _context.CursoSalvo.FindAsync(id);

                if(CursoSalvo == null)
                {
                    return new { Message = "O Id do usuário informado é diferente do Id da URL." };
                }

                CursoSalvo.StatusCurso = request.StatusCurso;

                _context.Entry(CursoSalvo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch 
            {
                return new { Message = "Ocorreu erro durante a atualização do usuário." };
            }
        }

        public async Task<ActionResult<dynamic>> PostCursoSalvo(CursoSalvoRequest request);
        {
            if (_context.CursoSalvo == null)
            {
                return new { Message = "Não foi possível retornar a informação." };
            }
            if (_context.CursoSalvo.Any(a => a.CursoId == request.CursoId))
            {
                return new { Message = "Curso ja está salvo em nosso sistema." };
            }
            
            if (Enum.TryParse(request, out StatusCursoEnum.CONCLUIDO)){
                    request == StatusCursoEnum.CONCLUIDO
            } else if(Enum.TryParse(request, out StatusCursoEnum.REALIZAR_NO_FUTURO)){
                    request == StatusCursoEnum.REALIZAR_NO_FUTURO
            } else if(Enum.TryParse(request, out StatusCursoEnum.EM_ANDAMENTO)){
                    request == StatusCursoEnum.EM_ANDAMENTO
            } else {
                return new { Message = "O valor informado não condiz com o esperado" };
            }        
    
            try
            {
            
                IMapper mapper = ConfigurePostMapper();
                CursoSalvo CursoSalvo = mapper.Map<CursoSalvo>(request);

                _context.CursoSalvo.Add(CursoSalvo);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão de usuário." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteCursoSalvo(int id);
        {
            try
            {
                
                if (!ExisteCursoSalvo(id)) 
                {
                return new { Message = "O Id do curso informado não existe." };
                }
                
                if(_context.CursoSalvo == null)
                {
                return new { Message = "Não foi possível retornar a informação." };
                }

                var CursoSalvo = await _context.CursoSalvo.FindAsync(id);

                if(CursoSalvo == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.CursoSalvo.Remove(CursoSalvo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão do curso." };
            }
        }

        private bool ExisteCursoSalvo(int id)
        {
            return _context.CursoSalvo.Any(a => a.Id == id);
        }

        private static IMapper ConfigurePostMapper()
        {
            var configuracao = new MapperConfiguration(cfg => cfg.CreateMap<CursoSalvoRequest, CursoSalvo>());
            var mapper = configuracao.CreateMapper();

            return mapper;
        }
    }
}
