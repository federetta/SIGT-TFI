using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Entities;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DALEmpresa : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        /// <summary>
        /// Create Cliente - Return ID
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public Empresa CreateProveedor(Empresa proveedor)
        {
            const string sqlStatement = "INSERT INTO dbo.Empresa ([razonSocial_empresa], [NombreFantasia_empresa], [Cuit_empresa], [TipoContribuyente_empresa], [Tipo_empresa]) " +
                "VALUES(@razonSocial_empresa, @NombreFantasia_empresa, @Cuit_empresa, @TipoContribuyente_empresa, @Tipo_empresa); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@razonSocial_empresa", DbType.String, proveedor.RazonSocial);
                db.AddInParameter(cmd, "@NombreFantasia_empresa", DbType.String, proveedor.NombreFantasia);
                db.AddInParameter(cmd, "@Cuit_empresa", DbType.Int32, proveedor.Cuit);
                db.AddInParameter(cmd, "@TipoContribuyente_empresa", DbType.Int32, proveedor.Tipo_Contribuyente);
                db.AddInParameter(cmd, "@Tipo_empresa", DbType.Int32, proveedor.Tipo_Empresa);
                // Obtener el valor de la primary key.
                proveedor.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return proveedor;
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
        public void UpdateById(Empresa empresa)


        {
            const string sqlStatement = "UPDATE dbo.Empresa " +
                "SET [RazonSocial_Empresa]=@razonSocial_empresa, " +
                    "[NombreFantasia_empresa]=@NombreFantasia_empresa, " +
                    "[Cuit_Empresa]=@Cuit_Empresa, " +
                    "[TipoContribuyente_empresa]=@TipoContribuyente_empresa, " +
                    "[Tipo_empresa]=@Tipo_empresa WHERE [Id_empresa]=@Id_empresa ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@razonSocial_empresa", DbType.String, empresa.RazonSocial);
                db.AddInParameter(cmd, "@NombreFantasia_empresa", DbType.String, empresa.NombreFantasia);
                db.AddInParameter(cmd, "@Cuit_Empresa", DbType.Int32, empresa.Cuit);
                db.AddInParameter(cmd, "@TipoContribuyente_empresa", DbType.String, empresa.Tipo_Contribuyente);
                db.AddInParameter(cmd, "@Tipo_empresa", DbType.Int32, empresa.Tipo_Empresa);
                db.AddInParameter(cmd, "@Id_empresa", DbType.Int32, empresa.id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Empresa WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id_empresa", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Empresa> SelectProveedor()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_empresa], [razonSocial_empresa], [NombreFantasia_empresa], [TipoContribuyente_empresa], [Tipo_empresa]  FROM dbo.Empresa Where [Tipo_empresa] = 2";

            var result = new List<Empresa>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var empresa = LoadEmpresa(dr); // Mapper
                        result.Add(empresa);
                    }
                }
            }

            return result;
        }

        public Empresa SelectbyID(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_empresa], [razonSocial_empresa], [NombreFantasia_empresa], [TipoContribuyente_empresa], [Tipo_empresa]  FROM dbo.Empresa WHERE [Id_empresa]=@Id_empresa ";

            Empresa empresa = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id_empresa", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) empresa = LoadEmpresa(dr);
                }

            }
            return empresa;
        }
           
    
        public List<Empresa> Search(string text)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_empresa], [razonSocial_empresa], [NombreFantasia_empresa],[TipoContribuyente_empresa], [Tipo_empresa]  FROM dbo.Empresa Where [razonSocial_empresa]  LIKE '%@text%' ";

            var result = new List<Empresa>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@text", DbType.String, text);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var empresa = LoadEmpresa(dr); // Mapper
                        result.Add(empresa);
                    }
                }
            }

            return result;
        }

        private static Empresa LoadEmpresa(IDataReader dr)
        {
            var empresa = new Empresa
            {
                                
                id = GetDataValue<int>(dr, "Id_empresa"),
                RazonSocial = GetDataValue<string>(dr, "razonSocial_empresa"),
                NombreFantasia = GetDataValue<string>(dr, "NombreFantasia_empresa"),              
                Tipo_Contribuyente = GetDataValue<int>(dr, "TipoContribuyente_empresa"),
                //Cuit = GetDataValue<string>(dr, "Cuit_Empresa"),
                Tipo_Empresa = GetDataValue<int>(dr, "Tipo_empresa"),
                
            };

        
            return empresa;
        }
    }
}
