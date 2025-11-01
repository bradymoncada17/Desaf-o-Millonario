using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millonario_Challenge
{
    internal class RepositorioPartidasSql
    {
        public int GuardarPartida(int? usuarioId, int dineroGanado, int respuestasCorrectas)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("INSERT INTO Partidas (UsuarioId, FechaInicio, FechaFin, DineroGanado, RespuestasCorrectas) OUTPUT INSERTED.PartidaId VALUES(@uid, GETDATE(), NULL, @dinero, @correctas)", conexion))
            {
                cmd.Parameters.AddWithValue("@uid", usuarioId.HasValue ? (object)usuarioId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@dinero", dineroGanado);
                cmd.Parameters.AddWithValue("@correctas", respuestasCorrectas);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void GuardarRespuestaPartida(int partidaId, int preguntaId, int? opcionSeleccionadaId, bool esCorrecta)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("INSERT INTO RespuestasPartida (PartidaId, PreguntaId, OpcionSeleccionadaId, EsCorrecta) VALUES(@pid,@qid,@oid,@esCorrecta)", conexion))
            {
                cmd.Parameters.AddWithValue("@pid", partidaId);
                cmd.Parameters.AddWithValue("@qid", preguntaId);
                cmd.Parameters.AddWithValue("@oid", opcionSeleccionadaId.HasValue ? (object)opcionSeleccionadaId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@esCorrecta", esCorrecta ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }
            public List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales)> ObtenerRanking()
        {
            var resultado = new List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales)>();

            // consulta 
            string sql = @"
                SELECT ISNULL(u.NombreUsuario,'Invitado') as NombreUsuario,
                       COUNT(p.PartidaId) AS Partidas,
                       ISNULL(SUM(p.DineroGanado),0) AS DineroTotal,
                       ISNULL(SUM(p.RespuestasCorrectas),0) AS RespuestasCorrectasTotales
                FROM Partidas p
                LEFT JOIN Usuarios u ON p.UsuarioId = u.UsuarioId
                GROUP BY ISNULL(u.NombreUsuario,'Invitado')
                ORDER BY DineroTotal DESC, RespuestasCorrectasTotales DESC;
            ";

            // Obtener la conexión desde el singleton
            var conexion = ConexionBD.Instancia.ObtenerConexion();

            try
            {
                using (var comando = new SqlCommand(sql, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            // Leer columnas — todos son no nulos por la consulta (ISNULL), pero ponemos control por seguridad
                            string nombreUsuario = lector.IsDBNull(0) ? "Invitado" : lector.GetString(0);
                            int partidas = lector.IsDBNull(1) ? 0 : lector.GetInt32(1);
                            int dineroTotal = lector.IsDBNull(2) ? 0 : lector.GetInt32(2);
                            int respuestasCorrectas = lector.IsDBNull(3) ? 0 : lector.GetInt32(3);

                            resultado.Add((nombreUsuario, partidas, dineroTotal, respuestasCorrectas));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo simple de errores: lanza excepción para que la UI la pueda mostrar/loggear
                throw new Exception("Error al obtener el ranking: " + ex.Message, ex);
            }

            return resultado;
        }
    }
    }

