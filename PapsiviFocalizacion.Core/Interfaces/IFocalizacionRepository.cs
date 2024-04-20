using PapsiviFocalizacion.Core.Dtos;
using PapsiviFocalizacion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Core.Interfaces
{
    public interface IFocalizacionRepository
    {
        Task<int> GuardarMasivo(List<Focalizacion> _lstFocalizacion);
        Task<List<Focalizacion>> ConsultarMasivo(int usuarioId);
        Task<List<FocalizacionView>> ConsultarMasivo(FocalizacionFiltro focalizacionFiltro);
    }
}
