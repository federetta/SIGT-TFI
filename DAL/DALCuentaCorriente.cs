using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
  public class DALCuentaCorriente : DataAccessComponent
    {
        public DataTable BuscarCobranza_View(CuentaCorriente cuentacorriente)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();


            DataSet dataset = new DataSet("BUSCAR_COBRANZA_VIEW");
            DataTable table = new DataTable();
            try
            {
                string procedure = "BUSCAR_COBRANZA_VIEW";

                SqlCommand comando = new SqlCommand(procedure, link);
                comando.CommandType = CommandType.StoredProcedure;
                listarParametros(comando, cuentacorriente);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dataset, "cuentacorriente");
                table = dataset.Tables["cuentacorriente"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return table;
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

        private void listarParametros(SqlCommand comando, CuentaCorriente cuentacorriente)
        {
            agregarParametro(comando, "@id_cliente", cuentacorriente.idcliente, ParameterDirection.Input, SqlDbType.Int);
        }


        public DataTable BUSCAR_FACTURA_SALDO(CuentaCorriente cuentacorriente)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();


            DataSet dataset = new DataSet("BUSCAR_FACTURA_SALDO");
            DataTable table = new DataTable();
            try
            {
                string procedure = "BUSCAR_FACTURA_SALDO";

                SqlCommand comando = new SqlCommand(procedure, link);
                comando.CommandType = CommandType.StoredProcedure;
                listarParametros(comando, cuentacorriente);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dataset, "cuentacorriente");
                table = dataset.Tables["cuentacorriente"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return table;
        }
    }
}
