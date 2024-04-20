using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Dtos;
using PapsiviFocalizacion.Core.Interfaces;
using PapsiviFocalizacion.Core.Models;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocalizacionController : ControllerBase
    {
        private readonly IFocalizacionRepository _focalizacionRepository;

        public FocalizacionController(IFocalizacionRepository focalizacionRepository) 
        { 
            _focalizacionRepository = focalizacionRepository;
        }

        [HttpPost("GuardarMasivo")]
        public async Task<ActionResult> GuardarMasivo([FromBody] List<Focalizacion> _lstFocalizacion)
        {
            try
            {
                var focalizaciones = await _focalizacionRepository.GuardarMasivo(_lstFocalizacion);

                return Ok(focalizaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar las focalizaciones: {ex.Message}");
            }
        }

        [HttpGet("ConsultarMasivo/{usuarioId}")]
        public async Task<ActionResult> ConsultarMasivo(int usuarioId)
        {
            try
            {
                var focalizaciones = await _focalizacionRepository.ConsultarMasivo(usuarioId);
                return Ok(focalizaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al consultar las focalizaciones: {ex.Message}");
            }            
        }

        [HttpPost("ConsultarMasivo")]
        public async Task<ActionResult> ConsultarMasivo(FocalizacionFiltro focalizacionFiltro)
        {
            try
            {
                var focalizaciones = await _focalizacionRepository.ConsultarMasivo(focalizacionFiltro);
                return Ok(focalizaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al consultar las focalizaciones: {ex.Message}");
            }
        }

    }
}
