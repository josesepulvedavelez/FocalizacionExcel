using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsiviFocalizacion.Core.Interfaces;
using PapsiviFocalizacion.Core.Models;

namespace PapsiviFocalizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocUsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public FocUsuarioController(IUsuarioRepository usuarioRepository) 
        { 
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("Loguear")]
        public async Task<ActionResult> Loguear([FromBody]FocUsuario focUsuario) 
        {
            var usuario = await _usuarioRepository.Loguear(focUsuario);
            return Ok(usuario);
        }

    }
}
