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
    public class FocMunicipioRepository : IFocMunicipioRepositoty
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public FocMunicipioRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<List<FocMunicipio>> ConsultarMunicipios(int DepartamentoId)
        {
            List<FocMunicipio> lstFocMunicipio = new List<FocMunicipio>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("select * from FocMunicipio where DepartamentoId = @DepartamentoId", conexion))
                {
                    comando.Parameters.AddWithValue("@DepartamentoId", DepartamentoId);
                    
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        FocMunicipio focMunicipio = new FocMunicipio()
                        {
                            MunicipioId = Convert.ToInt32(lector["MunicipioId"]),
                            Municipio = Convert.ToString(lector["Municipio"]),
                            DepartamentoId = Convert.ToInt32(lector["DepartamentoId"])
                        };

                        lstFocMunicipio.Add(focMunicipio);
                    }
                }
            }

            return lstFocMunicipio;
        }

    }
}
