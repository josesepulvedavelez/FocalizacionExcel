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
    public class DepartamentoRepository : IFocDepartamentoRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        private readonly string _Cadena;

        public DepartamentoRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<List<FocDepartamento>> ConsultarDepartamentos()
        {
            List<FocDepartamento> lstFocDepartamento = new List<FocDepartamento>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("select * from FocDepartamento", conexion))
                {
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        FocDepartamento focDepartamento = new FocDepartamento()
                        {
                            DepartamentoId = Convert.ToInt32(lector["DepartamentoId"]),
                            Departamento = Convert.ToString(lector["Departamento"])
                        };

                        lstFocDepartamento.Add(focDepartamento);
                    }
                }
            }

            return lstFocDepartamento;
        }

    }
}
