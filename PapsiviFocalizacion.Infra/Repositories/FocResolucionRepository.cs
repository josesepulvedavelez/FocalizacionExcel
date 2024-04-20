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
    public class FocResolucionRepository : IFocResolucionRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public FocResolucionRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<List<Core.Models.FocResolucion>> ConsultarResolucion()
        {
            List<FocResolucion> _lstFocResolucion = new List<FocResolucion>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("SELECT * FROM FocResolucion", conexion))
                {
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        FocResolucion focResolucion = new FocResolucion()
                        {
                            ResolucionId = Convert.ToInt32(lector["ResolucionId"]),
                            Resolucion = Convert.ToString(lector["Resolucion"])
                        };

                        _lstFocResolucion.Add(focResolucion);
                    }
                }
            }

            return _lstFocResolucion;
        }

    }
}
