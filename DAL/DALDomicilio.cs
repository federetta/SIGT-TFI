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
    public class DALDomicilio : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        public Domicilio CreateDomicilio(Domicilio domicilio)
        {
            const string sqlStatement = "INSERT INTO dbo.Domicilio ([Idrelacion_Domicilio]," +
                " [Calle_Domicilio], [Numero_Domicilio],[Localidad_Domicilio], " +
                "[Piso_Domicilio], [Depto_Domicilio],[CodigoPostal_Domicilio], [Provincia_Domicilio]) " +
                "VALUES(@Idrelacion_Domicilio, @Calle_Domicilio, @Numero_Domicilio, @Localidad_Domicilio" +
                ", @Piso_Domicilio, @Depto_Domicilio,@CodigoPostal_Domicilio,@Provincia_Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Idrelacion_Domicilio", DbType.Int32, domicilio.Idempresa);
                db.AddInParameter(cmd, "@Calle_Domicilio", DbType.String, domicilio.Calle);
                db.AddInParameter(cmd, "@Numero_Domicilio", DbType.Int32, domicilio.Numero);
                db.AddInParameter(cmd, "@Localidad_Domicilio", DbType.Int32, domicilio.IdLocalidad);
                db.AddInParameter(cmd, "@Piso_Domicilio", DbType.String, domicilio.Piso);
                db.AddInParameter(cmd, "@Depto_Domicilio", DbType.String, domicilio.Depto);
                db.AddInParameter(cmd, "@CodigoPostal_Domicilio", DbType.String, domicilio.CodigoPostal);
                db.AddInParameter(cmd, "@Provincia_Domicilio", DbType.Int32, domicilio.IdProvincia);
                // Obtener el valor de la primary key.
                domicilio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return domicilio;
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


        public List<Domicilio> SelectDomicilio(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_Domicilio], [Idrelacion_Domicilio]," +
                "                       [Calle_Domicilio]," +
                "                       [Numero_Domicilio]," +
                "                       [Localidad_Domicilio]," +
                "                       [Piso_Domicilio]," +
                "                       [Depto_Domicilio]," +
                "                       [CodigoPostal_Domicilio]," +
                "                       [Provincia_Domicilio] FROM[dbo].[Domicilio]" +
                "                       WHERE [Idrelacion_Domicilio] = @Idrelacion_Domicilio";

            var result = new List<Domicilio>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Idrelacion_Domicilio", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var domicilio = LoadDomicilio(dr); // Mapper
                        result.Add(domicilio);
                    }
                }
            }

            return result;
        }

        private static Domicilio LoadDomicilio(IDataReader dr)
        {
            var domicilio = new Domicilio
            {

                Id = GetDataValue<int>(dr, "Id_Domicilio"),
                Idempresa = GetDataValue<int>(dr, "Idrelacion_Domicilio"),
                Calle = GetDataValue<string>(dr, "Calle_Domicilio"),
                Numero = GetDataValue<int>(dr, "Numero_Domicilio"),
                IdLocalidad = GetDataValue<int>(dr, "Localidad_Domicilio"),
                Piso = GetDataValue<string>(dr, "Piso_Domicilio"),
                Depto = GetDataValue<string>(dr, "Depto_Domicilio"),
                CodigoPostal = GetDataValue<string>(dr, "CodigoPostal_Domicilio"),
                IdProvincia = GetDataValue<int>(dr, "Provincia_Domicilio"),
                
            };


            return domicilio;
        }
    }
}
