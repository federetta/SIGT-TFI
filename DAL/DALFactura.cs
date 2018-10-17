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
   public class DALFactura : DataAccessComponent
    {
        public DataTable LISTAR_COMPROBANTE_DETALLE(Factura factura)
        {

            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();
            DataSet dataset = new DataSet("LISTAR_COMPROBANTE_DETALLE");
            DataTable table = new DataTable();
            try
            {
                string procedure = "LISTAR_COMPROBANTE_DETALLE";

                SqlCommand comando = new SqlCommand(procedure, link);
                comando.CommandType = CommandType.StoredProcedure;
                listarParametros(comando, factura);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dataset, "factura");
                table = dataset.Tables["factura"];
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

        private void listarParametros(SqlCommand comando, Entities.Factura factura)
        {
            agregarParametro(comando, "@id_cliente", factura.IdCliente, ParameterDirection.Input, SqlDbType.Int);
            agregarParametro(comando, "@fechaInicial", factura.FechaInicialTraslado, ParameterDirection.Input, SqlDbType.Date);
            agregarParametro(comando, "@fechaFinal", factura.FechaFinalTraslado, ParameterDirection.Input, SqlDbType.Date);
        }



   
    }
}
