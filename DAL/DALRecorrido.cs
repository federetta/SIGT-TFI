using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALRecorrido : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        /// <summary>
        /// Create Cliente - Return ID
        /// </summary>
        /// <param name="Recorrido"></param>
        /// <returns></returns>
        public Recorrido CreateRecorrido(Recorrido Recorrido)
        {
            const string sqlStatement = "INSERT INTO dbo.Recorrido ([idObra_Recorrido]," +
                " [DomicilioInicial_Recorrido], [DomicilioFinal_Recorrido], [Nombre_Recorrido]) " +
                "VALUES(@idObra_Recorrido, @DomicilioInicial_Recorrido, @DomicilioFinal_Recorrido); SELECT SCOPE_IDENTITY();";


            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@idObra_Recorrido", DbType.Int32, Recorrido.IdObra);
                db.AddInParameter(cmd, "@DomicilioInicial_Recorrido", DbType.String, Recorrido.Inicio);
                db.AddInParameter(cmd, "@DomicilioFinal_Recorrido", DbType.String, Recorrido.Fin);
                db.AddInParameter(cmd, "@Nombre_Recorrido", DbType.String, Recorrido.Nombre);

                // Obtener el valor de la primary key.
                Recorrido.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return Recorrido;
        }


        private void agregarParametro(SqlCommand cmd, string nombre, object valor, ParameterDirection direccion, SqlDbType tipo)
        {
            SqlParameter parametro = cmd.CreateParameter();
            parametro.ParameterName = nombre;
            parametro.Direction = direccion;
            parametro.SqlDbType = tipo;
            parametro.Value = valor;
            cmd.Parameters.Add(parametro);
        }


        public List<Recorrido> SelectRecorrido(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [id_Recorrido]," +
                "                       [idObra_Recorrido]," +
                "                       [DomicilioInicial_Recorrido]," +
                "                       [DomicilioFinal_Recorrido] " +
                "                       [Nombre_Recorrido] " + 
                "                       FROM[dbo].[Recorrido]" +
                "                       WHERE [idObra_Recorrido] = @idObra_Recorrido";

            var result = new List<Recorrido>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@idObra_Recorrido", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Recorrido = LoadRecorrido(dr); // Mapper
                        result.Add(Recorrido);
                    }
                }
            }

            return result;
        }

        public List<Recorrido> SelectAll()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [id_Recorrido]," +
                "                       [idObra_Recorrido]," +
                "                       [DomicilioInicial_Recorrido]," +
                "                       [DomicilioFinal_Recorrido], " +
                "                       [Nombre_Recorrido] " +
                "                       FROM[dbo].[Recorrido]";

            var result = new List<Recorrido>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
              
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Recorrido = LoadRecorrido(dr); // Mapper
                        result.Add(Recorrido);
                    }
                }
            }

            return result;
        }

        private static Recorrido LoadRecorrido(IDataReader dr)
        {
            var Recorrido = new Recorrido
            {

                id = GetDataValue<int>(dr, "id_Recorrido"),
                IdObra = GetDataValue<int>(dr, "idObra_Recorrido"),
                Inicio = GetDataValue<string>(dr, "DomicilioInicial_Recorrido"),
                Fin = GetDataValue<string>(dr, "DomicilioFinal_Recorrido"),
                Nombre = GetDataValue<string>(dr, "Nombre_Recorrido"),
            };
            return Recorrido;
        }
    }
}
