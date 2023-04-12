using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CursosTelaInicialRequest
    {
        public string Nome { get; set; }
        public string Link { get; set; }
        public int CategoriaCursoId { get; set; }
    }
}
