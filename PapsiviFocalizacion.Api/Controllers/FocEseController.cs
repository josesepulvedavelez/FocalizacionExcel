using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocEseController : ControllerBase
    {
        private readonly IFocEseRepository _focEse;

        public FocEseController(IFocEseRepository focEse) 
        {
            _focEse = focEse;
        }

        [HttpGet("ConsultarEses/{MunicipioId}")]
        public async Task<ActionResult> ConsultarEses(int MunicipioId) 
        {
            var eses = await _focEse.ConsultarEses(MunicipioId);
            
            return Ok(eses);
        }

    }
}
