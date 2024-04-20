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
    public class FocalizacionRepository : IFocalizacionRepository
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        int result;
        private readonly string _Cadena;

        public FocalizacionRepository(IConfiguration configuration)
        {
            var cadena = configuration.GetConnectionString("cadena");
            _Cadena = cadena;
        }

        public async Task<int> GuardarMasivo(List<Focalizacion> _lstFocalizacion)
        {
            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                foreach (var item in _lstFocalizacion)
                {
                    using (var command = new SqlCommand("INSERT INTO Focalizacion (FechaContacto, TipoDoc, NumeroId, Nombre1, Nombre2, Apellido1, Apellido2, FechaNacimiento, Direccion, TelefonosContacto, TelefonoEfectivo, Aceptacion_o_no_atencion, Atencion__la_que_accede, Razon_no_aceptacion, Incluido_ruv_o_sentencias, verificacion_estado_aseguramiento, Eps, Condicion_discapacidad, Pertenencia_etnica, Sexo, Observaciones, EseId, UsuarioId, ResolucionId) VALUES (@FechaContacto, @TipoDoc, @NumeroId, @Nombre1, @Nombre2, @Apellido1, @Apellido2, @FechaNacimiento, @Direccion, @TelefonosContacto, @TelefonoEfectivo, @Aceptacion_o_no_atencion, @Atencion__la_que_accede, @Razon_no_aceptacion, @Incluido_ruv_o_sentencias, @verificacion_estado_aseguramiento, @Eps, @Condicion_discapacidad, @Pertenencia_etnica, @Sexo, @Observaciones, @EseId, @UsuarioId, @ResolucionId)", conexion))
                    {                        
                        command.Parameters.AddWithValue("@FechaContacto", item.FechaContacto);
                        command.Parameters.AddWithValue("@TipoDoc", item.TipoDoc);
                        command.Parameters.AddWithValue("@NumeroId", item.NumeroId);
                        command.Parameters.AddWithValue("@Nombre1", item.Nombre1);
                        command.Parameters.AddWithValue("@Nombre2", item.Nombre2);
                        command.Parameters.AddWithValue("@Apellido1", item.Apellido1);
                        command.Parameters.AddWithValue("@Apellido2", item.Apellido2);
                        command.Parameters.AddWithValue("@FechaNacimiento", item.FechaNacimiento);
                        command.Parameters.AddWithValue("@Direccion", item.Direccion);
                        command.Parameters.AddWithValue("@TelefonosContacto", item.TelefonosContacto);
                        command.Parameters.AddWithValue("@TelefonoEfectivo", item.TelefonoEfectivo);
                        command.Parameters.AddWithValue("@Aceptacion_o_no_atencion", item.Aceptacion_o_no_atencion);
                        command.Parameters.AddWithValue("@Atencion__la_que_accede", item.Atencion__la_que_accede);
                        command.Parameters.AddWithValue("@Razon_no_aceptacion", item.Razon_no_aceptacion);
                        command.Parameters.AddWithValue("@Incluido_ruv_o_sentencias", item.Incluido_ruv_o_sentencias);
                        command.Parameters.AddWithValue("@verificacion_estado_aseguramiento", item.Verificacion_estado_aseguramiento);
                        command.Parameters.AddWithValue("@Eps", item.Eps);
                        command.Parameters.AddWithValue("@Condicion_discapacidad", item.Condicion_discapacidad);
                        command.Parameters.AddWithValue("@Pertenencia_etnica", item.Pertenencia_etnica);
                        command.Parameters.AddWithValue("@Sexo", item.Sexo);
                        command.Parameters.AddWithValue("@Observaciones", item.Observaciones);
                        command.Parameters.AddWithValue("@EseId", item.EseId);
                        command.Parameters.AddWithValue("@UsuarioId", item.UsuarioId);
                        command.Parameters.AddWithValue("@ResolucionId", item.ResolucionId);

                        result += await command.ExecuteNonQueryAsync();
                    }
                }
            }

            return _lstFocalizacion.Count;
        }

        public async Task<List<Focalizacion>> ConsultarMasivo(int usuarioId)
        {
            List<Focalizacion> _lstFocalizacion = new List<Focalizacion>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("SELECT * FROM Focalizacion WHERE UsuarioId=@UsuarioId", conexion))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        Focalizacion focalizacion = new Focalizacion()
                        {
                            FocalizacionId = Convert.ToInt32(lector["FocalizacionId"]),
                            FechaContacto = lector["FechaContacto"] != DBNull.Value ? Convert.ToDateTime(lector["FechaContacto"]) : (DateTime?)null,
                            TipoDoc = lector["TipoDoc"] != DBNull.Value ? lector["TipoDoc"].ToString() : null,
                            NumeroId = lector["NumeroId"] != DBNull.Value ? lector["NumeroId"].ToString() : null,
                            Nombre1 = lector["Nombre1"] != DBNull.Value ? lector["Nombre1"].ToString() : null,
                            Nombre2 = lector["Nombre2"] != DBNull.Value ? lector["Nombre2"].ToString() : null,
                            Apellido1 = lector["Apellido1"] != DBNull.Value ? lector["Apellido1"].ToString() : null,
                            Apellido2 = lector["Apellido2"] != DBNull.Value ? lector["Apellido2"].ToString() : null,
                            FechaNacimiento = lector["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(lector["FechaNacimiento"]) : (DateTime?)null,
                            Direccion = lector["Direccion"] != DBNull.Value ? lector["Direccion"].ToString() : null,
                            TelefonosContacto = lector["TelefonosContacto"] != DBNull.Value ? lector["TelefonosContacto"].ToString() : null,
                            TelefonoEfectivo = lector["TelefonoEfectivo"] != DBNull.Value ? lector["TelefonoEfectivo"].ToString() : null,
                            Aceptacion_o_no_atencion = lector["Aceptacion_o_no_atencion"] != DBNull.Value ? lector["Aceptacion_o_no_atencion"].ToString() : null,
                            Atencion__la_que_accede = lector["Atencion__la_que_accede"] != DBNull.Value ? lector["Atencion__la_que_accede"].ToString() : null,
                            Razon_no_aceptacion = lector["Razon_no_aceptacion"] != DBNull.Value ? lector["Razon_no_aceptacion"].ToString() : null,
                            Incluido_ruv_o_sentencias = lector["Incluido_ruv_o_sentencias"] != DBNull.Value ? lector["Incluido_ruv_o_sentencias"].ToString() : null,
                            Verificacion_estado_aseguramiento = lector["Verificacion_estado_aseguramiento"] != DBNull.Value ? lector["Verificacion_estado_aseguramiento"].ToString() : null,
                            Eps = lector["Eps"] != DBNull.Value ? lector["Eps"].ToString() : null,
                            Condicion_discapacidad = lector["Condicion_discapacidad"] != DBNull.Value ? lector["Condicion_discapacidad"].ToString() : null,
                            Pertenencia_etnica = lector["Pertenencia_etnica"] != DBNull.Value ? lector["Pertenencia_etnica"].ToString() : null,
                            Sexo = lector["Sexo"] != DBNull.Value ? lector["Sexo"].ToString() : null,
                            Observaciones = lector["Observaciones"] != DBNull.Value ? lector["Observaciones"].ToString() : null,
                            EseId = lector["EseId"] != DBNull.Value ? Convert.ToInt32(lector["EseId"]) : (int?)null,
                            UsuarioId = lector["UsuarioId"] != DBNull.Value ? Convert.ToInt32(lector["UsuarioId"]) : (int?)null,
                            FechaLog = lector["FechaLog"] != DBNull.Value ? Convert.ToDateTime(lector["FechaLog"]) : (DateTime?)null
                        };

                        _lstFocalizacion.Add(focalizacion);
                    }

                }
            }

            return _lstFocalizacion;
        }

        public async Task<List<FocalizacionView>> ConsultarMasivo(FocalizacionFiltro focalizacionFiltro)
        {
            List<FocalizacionView> _lstFocalizacionView = new List<FocalizacionView>();

            using (conexion = new SqlConnection(_Cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand("SELECT * FROM FocalizacionView WHERE DepartamentoId=@DepartamentoId AND MunicipioId=@MunicipioId AND EseId=@EseId", conexion))
                {
                    comando.Parameters.AddWithValue("@DepartamentoId", focalizacionFiltro.DepartamentoId ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@MunicipioId", focalizacionFiltro.MunicipioId ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@EseId", focalizacionFiltro.EseId ?? (object)DBNull.Value);
                    lector = await comando.ExecuteReaderAsync();


                    while (await lector.ReadAsync())
                    {
                        FocalizacionView focalizacionView = new FocalizacionView()
                        {
                            DepartamentoId = Convert.ToInt32(lector["DepartamentoId"]),
                            Departamento = Convert.ToString(lector["Departamento"]),
                            
                            MunicipioId = Convert.ToInt32(lector["MunicipioId"]),
                            Municipio = Convert.ToString(lector["Municipio"]),
                            
                            EseId = Convert.ToInt32(lector["EseId"]),
                            Ese = Convert.ToString(lector["Ese"]),
                            
                            UsuarioId = Convert.ToInt32(lector["UsuarioId"]),
                            Usuario = Convert.ToString(lector["Usuario"]),
                            Nivel = Convert.ToString(lector["Nivel"]),

                            ResolucionId = Convert.ToInt32(lector["ResolucionId"]),
                            Resolucion = Convert.ToString(lector["Resolucion"]),

                            FocalizacionId = Convert.ToInt32(lector["FocalizacionId"]),
                            FechaContacto = lector["FechaContacto"] != DBNull.Value ? Convert.ToDateTime(lector["FechaContacto"]) : (DateTime?)null,
                            TipoDoc = lector["TipoDoc"] != DBNull.Value ? lector["TipoDoc"].ToString() : null,
                            NumeroId = lector["NumeroId"] != DBNull.Value ? lector["NumeroId"].ToString() : null,
                            Nombre1 = lector["Nombre1"] != DBNull.Value ? lector["Nombre1"].ToString() : null,
                            Nombre2 = lector["Nombre2"] != DBNull.Value ? lector["Nombre2"].ToString() : null,
                            Apellido1 = lector["Apellido1"] != DBNull.Value ? lector["Apellido1"].ToString() : null,
                            Apellido2 = lector["Apellido2"] != DBNull.Value ? lector["Apellido2"].ToString() : null,
                            FechaNacimiento = lector["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(lector["FechaNacimiento"]) : (DateTime?)null,
                            Direccion = lector["Direccion"] != DBNull.Value ? lector["Direccion"].ToString() : null,
                            TelefonosContacto = lector["TelefonosContacto"] != DBNull.Value ? lector["TelefonosContacto"].ToString() : null,
                            TelefonoEfectivo = lector["TelefonoEfectivo"] != DBNull.Value ? lector["TelefonoEfectivo"].ToString() : null,
                            Aceptacion_o_no_atencion = lector["Aceptacion_o_no_atencion"] != DBNull.Value ? lector["Aceptacion_o_no_atencion"].ToString() : null,
                            Atencion__la_que_accede = lector["Atencion__la_que_accede"] != DBNull.Value ? lector["Atencion__la_que_accede"].ToString() : null,
                            Razon_no_aceptacion = lector["Razon_no_aceptacion"] != DBNull.Value ? lector["Razon_no_aceptacion"].ToString() : null,
                            Incluido_ruv_o_sentencias = lector["Incluido_ruv_o_sentencias"] != DBNull.Value ? lector["Incluido_ruv_o_sentencias"].ToString() : null,
                            Verificacion_estado_aseguramiento = lector["Verificacion_estado_aseguramiento"] != DBNull.Value ? lector["Verificacion_estado_aseguramiento"].ToString() : null,
                            Eps = lector["Eps"] != DBNull.Value ? lector["Eps"].ToString() : null,
                            Condicion_discapacidad = lector["Condicion_discapacidad"] != DBNull.Value ? lector["Condicion_discapacidad"].ToString() : null,
                            Pertenencia_etnica = lector["Pertenencia_etnica"] != DBNull.Value ? lector["Pertenencia_etnica"].ToString() : null,
                            Sexo = lector["Sexo"] != DBNull.Value ? lector["Sexo"].ToString() : null,
                            Observaciones = lector["Observaciones"] != DBNull.Value ? lector["Observaciones"].ToString() : null,
                            FechaLog = lector["FechaLog"] != DBNull.Value ? Convert.ToDateTime(lector["FechaLog"]) : (DateTime?)null
                        };

                        _lstFocalizacionView.Add(focalizacionView);
                    }
                }
            }

            return _lstFocalizacionView;
        }

    }
}
