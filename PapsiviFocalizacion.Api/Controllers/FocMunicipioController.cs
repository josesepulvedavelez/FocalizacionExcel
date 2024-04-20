using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocMunicipioController : ControllerBase
    {
        private readonly IFocMunicipioRepositoty _municipioRepositoty;

        public FocMunicipioController(IFocMunicipioRepositoty municipioRepositoty)
        {
            _municipioRepositoty = municipioRepositoty;
        }

        [HttpGet("ConsultarMunicipios/{DepartamentoId}")]
        public async Task<ActionResult> ConsultarMunicipios(int DepartamentoId)
        {
            var municipios = await _municipioRepositoty.ConsultarMunicipios(DepartamentoId);
            return Ok(municipios);
        }

    }
}
