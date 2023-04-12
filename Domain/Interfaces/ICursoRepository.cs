using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<ActionResult<dynamic>> GetCurso();
        Task<ActionResult<dynamic>> GetCurso(int id);
        Task<ActionResult<dynamic>> GetCursoCategoria(int id);
        Task<ActionResult<dynamic>> PutCurso(int id);
        Task<ActionResult<dynamic>> PostCurso();
        Task<ActionResult<dynamic>> DeleteCurso(int id);
    }
}
