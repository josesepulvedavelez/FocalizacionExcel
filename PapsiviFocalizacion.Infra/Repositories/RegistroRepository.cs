using Microsoft.Extensions.Configuration;
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
    public class RegistroRepository : IRegistroRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public RegistroRepository(IConfiguration configuration) 
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<List<Registro>> ConsultarRegistros()
        {
            List<Registro> lstRegistros = new List<Registro>();

            using (conexion = new SqlConnection(_Cadena))
            {
                conexion.Open();

                using (comando = new SqlCommand("SELECT * FROM Registro", conexion))
                {
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        Registro registro = new()
                        {
                            Usuario = Convert.ToString(lector["Usuario"]),
                            Ip = Convert.ToString(lector["Ip"]),
                            RegistroId = Convert.ToInt32(lector["RegistroId"])
                        };

                        lstRegistros.Add(registro);
                    }
                }
            }

            return lstRegistros;
        }

    }
}
