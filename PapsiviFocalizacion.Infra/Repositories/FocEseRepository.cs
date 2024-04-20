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
    public class FocEseRepository : IFocEseRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public FocEseRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<List<FocEse>> ConsultarEses(int MunicipioId)
        {
            List<FocEse> lstFocEse = new List<FocEse>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("select * from FocEse where MunicipioId=@MunicipioId", conexion))
                {
                    comando.Parameters.AddWithValue("@MunicipioId", MunicipioId);
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        FocEse focEse = new FocEse()
                        {
                            EseId = Convert.ToInt32(lector["EseId"]),
                            Ese = Convert.ToString(lector["Ese"]),
                            MunicipioId = Convert.ToInt32(lector["MunicipioId"])
                        };

                        lstFocEse.Add(focEse);
                    }
                }
            }

            return lstFocEse;
        }

    }
}
