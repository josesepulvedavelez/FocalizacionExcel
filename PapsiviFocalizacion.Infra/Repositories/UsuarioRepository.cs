using Microsoft.Extensions.Configuration;
using PapsiviFocalizacion.Core.Dtos;
using PapsiviFocalizacion.Core.Interfaces;
using PapsiviFocalizacion.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapsiviFocalizacion.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public UsuarioRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<FocUsuarioDto> Loguear(FocUsuario focUsuario)
        {
            FocUsuarioDto usuarioDto = new FocUsuarioDto();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("select * from FocUsuario where Usuario=@Usuario and Contrasena=@contrasena", conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", focUsuario.Usuario);
                    comando.Parameters.AddWithValue("@Contrasena", focUsuario.Contrasena);

                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        usuarioDto.UsuarioId = Convert.ToInt16(lector["UsuarioId"]);
                        usuarioDto.Usuario = Convert.ToString(lector["Usuario"]);
                        usuarioDto.Nivel = Convert.ToString(lector["Nivel"]);                       
                    };
                }
            }

            if (focUsuario.Usuario != null && focUsuario.Contrasena != null)
            {
                return usuarioDto;
            }
            else
            {
                return null;
            }
            
        }

    }
}
