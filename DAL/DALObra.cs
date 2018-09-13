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
    public class DALObra : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        /// <summary>
        /// Create Cliente - Return ID
        /// </summary>
        /// <param name="Obra"></param>
        /// <returns></returns>
        public Obra CreateObra(Obra obra)
        {
            const string sqlStatement = "INSERT INTO dbo.Obra ([idCliente_Obra]," +
                " [Nombre_Obra]) VALUES(@idCliente_Obra, @Nombre_Obra); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@idCliente_Obra", DbType.Int32, obra.IdCliente);
                db.AddInParameter(cmd, "@Nombre_Obra", DbType.String, obra.Nombre);
                // Obtener el valor de la primary key.
                obra.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return obra;
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


        public List<Obra> SelectObra(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_Obra]," +
                "                       [idCliente_Obra]," +
                "                       [Nombre_Obra]" +
                "                       FROM[dbo].[Obra]" +
                "                       WHERE [idCliente_Obra] = @idCliente_Obra";

            var result = new List<Obra>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@idCliente_Obra", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var obra = LoadObra(dr); // Mapper
                        result.Add(obra);
                    }
                }
            }

            return result;
        }

         private static Obra LoadObra(IDataReader dr)
        {
            var obra = new Obra
            {

                id = GetDataValue<int>(dr, "Id_Obra"),
                IdCliente = GetDataValue<int>(dr, "idCliente_Obra"),
                Nombre = GetDataValue<string>(dr, "Nombre_Obra"),
                
            };


            return obra;
        }
    }
}
