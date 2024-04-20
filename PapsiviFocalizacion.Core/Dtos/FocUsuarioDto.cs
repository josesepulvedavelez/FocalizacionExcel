using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Core.Dtos
{
    public class FocUsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string? Nivel { get; set; }
    }
}
