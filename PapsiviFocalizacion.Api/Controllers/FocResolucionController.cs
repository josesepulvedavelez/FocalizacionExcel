using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocResolucionController : ControllerBase
    {
        private readonly IFocResolucionRepository _focResolucionRepository;
        
        public FocResolucionController(IFocResolucionRepository focResolucionRepository) 
        { 
            _focResolucionRepository = focResolucionRepository;
        }

        [HttpGet("ConsultarResolucion")]
        public async Task<ActionResult> ConsultarResolucion()
        {
            var resoluciones = await _focResolucionRepository.ConsultarResolucion();

            return Ok(resoluciones);
        }

    }
}
