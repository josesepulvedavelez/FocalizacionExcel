using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;
        
        public RegistrosController(IRegistroRepository registroRepository) 
        { 
            _registroRepository = registroRepository;
        }

        [HttpGet("ConsultarRegistros")]
        public async Task<ActionResult> ConsultarRegistros()
        {
            var registro = await _registroRepository.ConsultarRegistros();

            return Ok(registro);
        }
    }
}
