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
    public class DALCobranza : DataAccessComponent
    {


        /// <summary>
        ///     ''' Creo la cabecera de la cobranza.
        ///     ''' </summary>
        ///     ''' <param name="cobranza"></param>
        ///     ''' <returns></returns>
        public Cobranza CrearCobranza(Cobranza cobranza)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("INSERTAR_COBRANZA", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numero_cobranza", SqlDbType.Int).Value = cobranza.NumeroCobranza;
                cmd.Parameters.Add("@idCliente_cobranza", SqlDbType.Int).Value = cobranza.IdCliente;
                cmd.Parameters.Add("@Fecha_cobranza", SqlDbType.Date).Value = cobranza.FechaCobranza;
                cmd.Parameters.Add("@id_cobranza", SqlDbType.Int).Value = cobranza.IdCobranzaCabecera;
                // Declaro el ID para retornarlo
                var returnParameter = cmd.Parameters.Add("@id_cobranza", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                // Retorno el ID_ComprobanteCabecera
                var result = returnParameter.Value;
                cobranza.IdCobranzaCabecera = Convert.ToInt32(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return cobranza;
        }

        /// <summary>
        ///     ''' Se llama a un store Procedure para eliminar los recibos y la cabecera a partir del id de la cabecera
        ///     ''' Cuando se produce una falla en algun insert, es un rollback del proceso.
        ///     ''' </summary>
        ///     ''' <param name="cobranza"></param>
        public void EliminarCobranza(Recibo recibo)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();
            SqlCommand cmd = new SqlCommand("ELIMINAR_COBRANZA", link);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_Cobranza", SqlDbType.Int).Value = recibo.idcobranza;
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        ///     ''' Se van agregando los distintos pagos de una cobranza, si algun insert falla llama a la funcion para eliminar
        ///     ''' los recibos ya agregados y la cabecera de la cobranza.
        ///     ''' </summary>
        ///     ''' <param name="recibo"></param>
        public Recibo CrearCobranzaDetalle(Recibo recibo)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();

            try
            {
                SqlCommand cmd = new SqlCommand("INSERTAR_RECIBO", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_Cobranza", SqlDbType.Int).Value = recibo.idcobranza;
                cmd.Parameters.Add("@IdMedioPago_recibo", SqlDbType.Int).Value = recibo.IdMedioPago;
                cmd.Parameters.Add("@IdEntidadBancaria_recibo", SqlDbType.Int).Value = recibo.IdEntidadBancaria;
                cmd.Parameters.Add("@Numero_recibo", SqlDbType.Int).Value = recibo.NumeroRecibo;
                cmd.Parameters.Add("@Fecha_recibo", SqlDbType.Date).Value = recibo.FechaRecibo;
                cmd.Parameters.Add("@Plazo_recibo", SqlDbType.Int).Value = recibo.PlazoRecibo;
                cmd.Parameters.Add("@Endosable_recibo", SqlDbType.Bit).Value = recibo.Endosable;
                cmd.Parameters.Add("@Directo_recibo", SqlDbType.Bit).Value = recibo.Directo;
                cmd.Parameters.Add("@DocLibrador_recibo", SqlDbType.Int).Value = recibo.DocLibrador;
                cmd.Parameters.Add("@Observaciones_recibo", SqlDbType.NVarChar).Value = recibo.Observaciones;
                cmd.Parameters.Add("@Importe_recibo", SqlDbType.Decimal).Value = recibo.Monto;
                cmd.ExecuteNonQuery();
                return recibo;
            }
            catch (Exception ex)
            {
                EliminarCobranza(recibo);
                throw ex;
            }
        }

        public void CrearTotales(int recibo)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();

            try
            {
                SqlCommand cmd = new SqlCommand("OBTENER_TOTAL_COBRANZA", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_Cobranza", SqlDbType.Int).Value = recibo;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarCobranza_View(Cliente cliente)
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
                listarParametros(comando, cliente);
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

        public DataTable SaldoCuentaCOrriente(Cliente cliente)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();


            DataSet dataset = new DataSet("SALDO_CUENTACORRIENTE");
            DataTable table = new DataTable();
            try
            {
                string procedure = "SALDO_CUENTACORRIENTE";

                SqlCommand comando = new SqlCommand(procedure, link);
                comando.CommandType = CommandType.StoredProcedure;
                listarParametros(comando, cliente);
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

        private void listarParametros(SqlCommand comando, Cliente cliente)
        {
            agregarParametro(comando, "@id_cliente", cliente.IdCliente, ParameterDirection.Input, SqlDbType.Int);
        }

    }
}

                





