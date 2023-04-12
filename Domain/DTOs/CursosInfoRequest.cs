using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    internal class CursosInfoRequest
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public int categoria { get; set; }
        public string descricao { get; set; }
        public int CargaHoraria { get; set; }
    }
}
