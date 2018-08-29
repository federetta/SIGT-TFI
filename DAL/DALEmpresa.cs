using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALEmpresa
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();
        public Entities.Empresa InsertarEmpresa(Entities.Empresa empresa)
        {
            try
            {
                conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("INSERTAR_empresa", conexion.ConectarBaseDatos());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@razonSocial_empresa", SqlDbType.NVarChar).Value = empresa.RazonSocial;
                cmd.Parameters.Add("@NombreFantasia_empresa", SqlDbType.NVarChar).Value = empresa.NombreFantasia;
                cmd.Parameters.Add("@Cuit_empresa", SqlDbType.NVarChar).Value = empresa.Cuit;
                cmd.Parameters.Add("@TipoContribuyente_empresa", SqlDbType.Int).Value = empresa.TipoContribuyente.id;
                cmd.Parameters.Add("@TipoEmpresa_empresa", SqlDbType.Int).Value = empresa.Tipo_Empresa.id;
                
                // Declaro el ID para retornarlo en el textbox
                cmd.Parameters.Add("@id_empresa", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                // Retorno el ID_empresa
                //empresa.id = Convert.ToInt32(cmd.Parameters("@id_empresa").Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conexion.DesconectarBaseDatos();
            return empresa;
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


    }
}
