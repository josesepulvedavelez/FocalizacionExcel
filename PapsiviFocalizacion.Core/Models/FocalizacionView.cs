using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Core.Models
{
    public class FocalizacionView
    {
        public int? DepartamentoId { get; set; }
        public string? Departamento { get; set; }

        public int? MunicipioId { get; set; }
        public string? Municipio { get; set; }

        public int? EseId { get; set; }
        public string? Ese { get; set; }

        public int? UsuarioId { get; set; }
        public string? Usuario { get; set; }
        public string? Nivel { get; set; }

        public int? ResolucionId { get; set; }
        public string? Resolucion { get; set; }

        public int FocalizacionId { get; set; }
        public DateTime? FechaContacto { get; set; }
        public string? TipoDoc { get; set; }
        public string? NumeroId { get; set; }
        public string? Nombre1 { get; set; }
        public string? Nombre2 { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? TelefonosContacto { get; set; }
        public string? TelefonoEfectivo { get; set; }
        public string? Aceptacion_o_no_atencion { get; set; }
        public string? Atencion__la_que_accede { get; set; }
        public string? Razon_no_aceptacion { get; set; }
        public string? Incluido_ruv_o_sentencias { get; set; }
        public string? Verificacion_estado_aseguramiento { get; set; }
        public string? Eps { get; set; }
        public string? Condicion_discapacidad { get; set; }
        public string? Pertenencia_etnica { get; set; }
        public string? Sexo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
    }
}
