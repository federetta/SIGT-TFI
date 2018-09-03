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
        public Empresa CreateCliente(Empresa empresa)
        {
            const string sqlStatement = "INSERT INTO dbo.Product ([razonSocial_empresa], [NombreFantasia_empresa], [Cuit_empresa], [TipoContribuyente_empresa], [Tipo_empresa]) " +
                "VALUES(@razonSocial_empresa, @NombreFantasia_empresa, @Cuit_empresa, @TipoContribuyente_empresa, @Tipo_empresa); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@razonSocial_empresa", DbType.String, empresa.RazonSocial);
                db.AddInParameter(cmd, "@NombreFantasia_empresa", DbType.String, empresa.NombreFantasia);
                db.AddInParameter(cmd, "@Cuit_empresa", DbType.Int32, empresa.Cuit);
                db.AddInParameter(cmd, "@TipoContribuyente_empresa", DbType.Int32, empresa.Tipo_Contribuyente);
                db.AddInParameter(cmd, "@Tipo_empresa", DbType.Int32, empresa.Tipo_Empresa);
                // Obtener el valor de la primary key.
                empresa.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return empresa;
        }
        
        //public Entities.Empresa InsertarEmpresa(Entities.Empresa empresa)
        //{
        //    var db = DatabaseFactory.CreateDatabase("Data Source = frdell\\sqlexpress; Initial Catalog = SIGT_Web; Integrated Security = True");
        //    try
        //    {
        //        conexion.ConectarBaseDatos();
        //        SqlCommand cmd = new SqlCommand("INSERTAR_empresa", conexion.ConectarBaseDatos());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@razonSocial_empresa", SqlDbType.NVarChar).Value = empresa.RazonSocial;
        //        cmd.Parameters.Add("@NombreFantasia_empresa", SqlDbType.NVarChar).Value = empresa.NombreFantasia;
        //        cmd.Parameters.Add("@Cuit_empresa", SqlDbType.NVarChar).Value = empresa.Cuit;
        //        cmd.Parameters.Add("@TipoContribuyente_empresa", SqlDbType.Int).Value = empresa.Tipo_Contribuyente;
        //        cmd.Parameters.Add("@Tipo_empresa", SqlDbType.Int).Value = empresa.Tipo_Empresa;

        //        // Declaro el ID para retornarlo en el textbox
        //        //cmd.Parameters.Add("@id_empresa", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        empresa.id = Convert.ToInt32(db.ExecuteScalar(cmd));

        //        cmd.ExecuteNonQuery();
        //        // Retorno el ID_empresa
        //        //empresa.id = Convert.ToInt32(cmd.Parameters("@id_empresa").Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    conexion.DesconectarBaseDatos();
        //    return empresa;
    

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
                "SET [RazonSocial]=@razonSocial_empresa, " +
                    "[NombreFantasia_empresa]=@NombreFantasia_empresa, " +
                    "[DealerId]=@Cuit_Empresa, " +
                    "[TipoContribuyente_empresa]=@TipoContribuyente_empresa, " +
                    "[Tipo_empresa]=@Tipo_empresa, " +
                    "[QuantitySold]=@QuantitySold, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id_empresa ";

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
        public List<Empresa> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id_empresa], [razonSocial_empresa], [NombreFantasia_empresa], [TipoContribuyente_empresa], [Tipo_empresa]  FROM dbo.Empresa ";

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

        private static Empresa LoadEmpresa(IDataReader dr)
        {
            var empresa = new Empresa
            {
                                
                id = GetDataValue<int>(dr, "Id_empresa"),
                RazonSocial = GetDataValue<string>(dr, "razonSocial_empresa"),
                NombreFantasia = GetDataValue<string>(dr, "NombreFantasia_empresa"),              
                Tipo_Contribuyente = GetDataValue<int>(dr, "TipoContribuyente_empresa"),
                //Cuit = GetDataValue<int>(dr, "Cuit_Empresa"),
                Tipo_Empresa = GetDataValue<int>(dr, "Tipo_empresa"),
                
            };

        
            return empresa;
        }
    }
}
