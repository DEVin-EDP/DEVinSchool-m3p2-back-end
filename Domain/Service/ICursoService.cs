using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface ICursoService
    {
        Task<ActionResult<dynamic>> GetCurso();
        Task<ActionResult<dynamic>> GetCurso(int id);
        Task<ActionResult<dynamic>> GetCursoCategoria(int id);
        Task<ActionResult<dynamic>> PutCurso(int id);
        Task<ActionResult<dynamic>> PostCurso();
        Task<ActionResult<dynamic>> DeleteCurso(int id);
    }
}
