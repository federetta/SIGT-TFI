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
    public class DALTransporte : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        /// <summary>
        /// Create Cliente - Return ID
        /// </summary>
        /// <param name="Transporte"></param>
        /// <returns></returns>
        public Transporte CreateTransporte(Transporte transporte)
        {
            const string sqlStatement = "INSERT INTO dbo.Transporte ([IdProveedor_Transporte]," +
                " [Marca_Transporte], [Modelo_Transporte],[tara_Transporte], " +
                "[Patente_Transporte], [Descripcion_Transporte],[Titular_Transporte]) " +
                "VALUES(@IdProveedor_Transporte, @Marca_Transporte, @Modelo_Transporte, @tara_Transporte" +
                ", @Patente_Transporte, @Descripcion_Transporte,@Titular_Transporte); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@IdProveedor_Transporte", DbType.Int32, transporte.IdProveedor);
                db.AddInParameter(cmd, "@Marca_Transporte", DbType.String, transporte.Marca);
                db.AddInParameter(cmd, "@Modelo_Transporte", DbType.String, transporte.Modelo);
                db.AddInParameter(cmd, "@tara_Transporte", DbType.Int32, transporte.Tara);
                db.AddInParameter(cmd, "@Patente_Transporte", DbType.String, transporte.Patente);
                db.AddInParameter(cmd, "@Descripcion_Transporte", DbType.String, transporte.Descripcion);
                db.AddInParameter(cmd, "@Titular_Transporte", DbType.String, transporte.Titular);


                // Obtener el valor de la primary key.
                transporte.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return transporte;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(Transporte transporte)


        {
            const string sqlStatement = "UPDATE [dbo].[Transporte] SET[IdProveedor_Transporte] = @IdProveedor_Transporte" +
                ",[Marca_Transporte] = @Marca_Transporte,[Modelo_Transporte] = @Modelo_Transporte," +
                "[tara_Transporte] = @tara_Transporte,[Patente_Transporte] = @Patente_Transporte," +
                "[Descripcion_Transporte] = @Descripcion_Transporte,[Titular_Transporte] = @Titular_Transporte " +
                "WHERE [Id_Transporte] = @Id_Transporte";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@IdProveedor_Transporte", DbType.Int32, transporte.IdProveedor);
                db.AddInParameter(cmd, "@Marca_Transporte", DbType.String, transporte.Marca);
                db.AddInParameter(cmd, "@Modelo_Transporte", DbType.String, transporte.Modelo);
                db.AddInParameter(cmd, "@tara_Transporte", DbType.Int32, transporte.Tara);
                db.AddInParameter(cmd, "@Patente_Transporte", DbType.String, transporte.Patente);
                db.AddInParameter(cmd, "@Descripcion_Transporte", DbType.String, transporte.Descripcion);
                db.AddInParameter(cmd, "@Titular_Transporte", DbType.String, transporte.Titular);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Transporte WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Transporte> SelectTransporte(int id)
        {
            // WARNING! Performance
            const string sqlStatement ="SELECT [Id_Transporte]," +
                "                       [IdProveedor_Transporte]," +
                "                       [Marca_Transporte]," +
                "                       [Modelo_Transporte]," +
                "                       [tara_Transporte]," +
                "                       [Patente_Transporte]," +
                "                       [Descripcion_Transporte]," +
                "                       [Titular_Transporte] FROM[dbo].[Transporte]" +
                "                       WHERE [IdProveedor_Transporte] = @IdProveedor_Transporte";

            var result = new List<Transporte>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@IdProveedor_Transporte", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var transporte = LoadTransporte(dr); // Mapper
                        result.Add(transporte);
                    }
                }
            }

            return result;
        }

        public List<Transporte> SelectAllTransporte()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_Transporte]," +
                "                       [IdProveedor_Transporte]," +
                "                       [Marca_Transporte]," +
                "                       [Modelo_Transporte]," +
                "                       [tara_Transporte]," +
                "                       [Patente_Transporte]," +
                "                       [Descripcion_Transporte]," +
                "                       [Titular_Transporte] FROM[dbo].[Transporte]";

            var result = new List<Transporte>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var transporte = LoadTransporte(dr); // Mapper
                        result.Add(transporte);
                    }
                }
            }

            return result;
        }

        public Transporte SelectbyID(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_empresa], [razonSocial_empresa], [NombreFantasia_empresa], [TipoContribuyente_empresa], [Tipo_empresa]  FROM dbo.Transporte WHERE [Id_empresa]=@Id_empresa ";

            Transporte empresa = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id_empresa", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) empresa = LoadTransporte(dr);
                }

            }
            return empresa;
        }


      

        private static Transporte LoadTransporte(IDataReader dr)
        {
            var transporte = new Transporte
            {

                id = GetDataValue<int>(dr, "Id_Transporte"),
                IdProveedor = GetDataValue<int>(dr, "IdProveedor_Transporte"),
                Marca = GetDataValue<string>(dr, "Marca_Transporte"),
                Modelo = GetDataValue<string>(dr, "Modelo_Transporte"),
                Tara = GetDataValue<int>(dr, "tara_Transporte"),
                Patente = GetDataValue<string>(dr, "Patente_Transporte"),
                Descripcion = GetDataValue<string>(dr, "Descripcion_Transporte"),
                Titular = GetDataValue<string>(dr, "Titular_Transporte"),



            };


            return transporte;
        }
    }
}
