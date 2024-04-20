using PapsiviFocalizacion.Core.Dtos;
using PapsiviFocalizacion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<FocUsuarioDto> Loguear(FocUsuario focUsuario);
    }
}
