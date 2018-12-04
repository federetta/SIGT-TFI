using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{


    public class DALBitacoraSQL : DataAccessComponent
    {
        private Services.ConexionSQL conexion = new Services.ConexionSQL();

        public void CrearBitacoraSQL(BitacoraSQL objeto)
        {
            BitacoraSQL Bitacora = new BitacoraSQL();
            Bitacora.ComputerName = System.Net.Dns.GetHostName();
            Bitacora.IP = System.Net.Dns.GetHostEntry(Bitacora.ComputerName).AddressList[0].ToString();
            Bitacora.WindowsUser = Environment.UserName;
            Bitacora.fecha = DateTime.Now;
            Bitacora.CustomError = objeto.CustomError;
            Bitacora.Usuario = objeto.Usuario;
            Bitacora.mensaje = objeto.mensaje;
            Bitacora.tipo = objeto.tipo;
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("InsertarBitacora", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Fecha_Bitacora", SqlDbType.DateTime).Value = Bitacora.fecha;
                cmd.Parameters.Add("@Mensaje_Bitacora", SqlDbType.NVarChar).Value = Bitacora.mensaje;
                cmd.Parameters.Add("@ComputerName_Bitacora", SqlDbType.NVarChar).Value = Bitacora.ComputerName;
                cmd.Parameters.Add("@Ip_Bitacora", System.Data.SqlDbType.NVarChar).Value = Bitacora.IP;
                cmd.Parameters.Add("@WindowsUser_Bitacora", SqlDbType.NVarChar).Value = Bitacora.WindowsUser;
                cmd.Parameters.Add("@usuario_bitacora", SqlDbType.NVarChar).Value = Bitacora.Usuario;
                cmd.Parameters.Add("@tipo_bitacora", SqlDbType.NVarChar).Value = Bitacora.tipo;
                cmd.Parameters.Add("@customError_Bitacora", SqlDbType.NVarChar).Value = Bitacora.CustomError;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<BitacoraSQL> SelectBitacora()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Fecha_Bitacora], [Mensaje_Bitacora], [ComputarName_Bitacora], [Ip_Bitacora], [WindowsUser_Bitacora], [tipo_Bitacora] ,[usuario_Bitacora], [customError_Bitacora]  FROM dbo.Bitacora";

            var result = new List<BitacoraSQL>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var bitacora = LoadBitacora(dr); // Mapper
                        result.Add(bitacora);
                    }
                }
            }

            return result;
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


        private static BitacoraSQL LoadBitacora(IDataReader dr)
        {
            var bitacora = new BitacoraSQL
            {

                fecha = GetDataValue<DateTime>(dr, "Fecha_Bitacora"),
                mensaje = GetDataValue<string>(dr, "Mensaje_Bitacora"),
                ComputerName = GetDataValue<string>(dr, "ComputarName_Bitacora"),
                IP = GetDataValue<string>(dr, "Ip_Bitacora"),
                WindowsUser = GetDataValue<string>(dr, "WindowsUser_Bitacora"),
                tipo = GetDataValue<string>(dr, "tipo_Bitacora"),
                Usuario = GetDataValue<string>(dr, "usuario_Bitacora"),
                CustomError = GetDataValue<string>(dr, "customError_Bitacora"),

            };


            return bitacora;
        }
    }



}

