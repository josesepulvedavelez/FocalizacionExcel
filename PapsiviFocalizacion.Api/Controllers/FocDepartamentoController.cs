using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocDepartamentoController : ControllerBase
    {
        private readonly IFocDepartamentoRepository _focDepartamentoRepository;

        public FocDepartamentoController(IFocDepartamentoRepository focDepartamentoRepository) 
        { 
            _focDepartamentoRepository = focDepartamentoRepository;
        }

        [HttpGet("ConsultarDepartamentos")]
        public async Task<ActionResult> ConsultarDepartamentos()
        { 
            var departamentos = await _focDepartamentoRepository.ConsultarDepartamentos();

            return Ok(departamentos);
        }

    }
}
