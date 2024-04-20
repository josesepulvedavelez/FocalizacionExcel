using PapsiviFocalizacion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Core.Interfaces
{
    public interface IFocDepartamentoRepository
    {
        Task<List<FocDepartamento>> ConsultarDepartamentos();        
    }
}
