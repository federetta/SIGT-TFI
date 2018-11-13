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
    public class DALTraslado : DataAccessComponent
    {
         Services.ConexionSQL conexion = new Services.ConexionSQL();
        /// <summary>
        /// Create Cliente - Return ID
        /// </summary>
        /// <param name="Traslado"></param>
        /// <returns></returns>
        public Traslado CreateTraslado(Traslado traslado)
        {
            try
            {
                const string sqlStatement = "INSERT INTO dbo.Traslado ([Numero_Traslado], [Fecha_Traslado],[IdTransporte_Traslado], " +
               "[IdRecorrido_Traslado], [Carga_Traslado],[Estado_Traslado]) " +
               "VALUES(@Numero_Traslado, @Fecha_Traslado, @IdTransporte_Traslado, @IdRecorrido_Traslado" +
               ", @Carga_Traslado,@Estado_Traslado); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(ConnectionName);
                using (var cmd = db.GetSqlStringCommand(sqlStatement))
                {
                    db.AddInParameter(cmd, "@Numero_Traslado", DbType.Int32, traslado.NumeroTraslado);
                    db.AddInParameter(cmd, "@Fecha_Traslado", DbType.Date, traslado.Fecha);
                    db.AddInParameter(cmd, "@IdTransporte_Traslado", DbType.Int32, traslado.IdTransporte);
                    db.AddInParameter(cmd, "@IdRecorrido_Traslado", DbType.Int32, traslado.IdRecorrido);
                    db.AddInParameter(cmd, "@Carga_Traslado", DbType.Int32, traslado.Carga);
                    db.AddInParameter(cmd, "@Estado_Traslado", DbType.String, traslado.Estado);


                    // Obtener el valor de la primary key.
                    traslado.id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
           

            return traslado;
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


        public List<Traslado> Select()
        {
            const string sqlStatement = "SELECT [Numero_Traslado], [Fecha_Traslado], [IdTransporte_Traslado], [IdRecorrido_Traslado], [Carga_Traslado], [Estado_Traslado]  FROM dbo.Traslado ";

            var result = new List<Traslado>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Traslado = LoadTraslado(dr); // Mapper
                        result.Add(Traslado);
                    }
                }
            }

            return result;
        }

        private static Traslado LoadTraslado(IDataReader dr)
        {
            var traslado = new Traslado
            {
                NumeroTraslado = GetDataValue<int>(dr, "Numero_Traslado"),
                Fecha = GetDataValue<DateTime>(dr, "Fecha_Traslado"),
                IdTransporte = GetDataValue<int>(dr, "IdTransporte_Traslado"),
                IdRecorrido = GetDataValue<int>(dr, "IdRecorrido_Traslado"),
                Carga = GetDataValue<decimal>(dr, "Carga_Traslado"),
                Estado = GetDataValue<int>(dr, "Estado_Traslado"),
                
            };


            return traslado;
        }
    }
}
