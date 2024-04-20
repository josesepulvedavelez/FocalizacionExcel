using System.ComponentModel.DataAnnotations;

namespace PapsiviFocalizacion.Web.Models
{
    public class FocUsuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Usuario es obligatorio.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Contraseña es obligatorio.")]
        public string Contrasena { get; set; }
        public string? Nivel { get; set; }
    }
}
