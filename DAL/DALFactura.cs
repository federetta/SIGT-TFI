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
        {Services.ConexionSQL conexion = new Services.ConexionSQL();
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

        


        public Factura CrearFactura(Factura factura)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("INSERTAR_FACTURA", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Numero_ComprobanteCabecera", SqlDbType.Int).Value = factura.NumeroFactura;
                cmd.Parameters.Add("@TipoComprobante_ComprobanteCabecera", SqlDbType.Int).Value = factura.IdTipo;
                cmd.Parameters.Add("@idLetra_ComprobanteCabecera", SqlDbType.Int).Value = factura.IdLetra;
                cmd.Parameters.Add("@IdCliente_ComprobanteCabecera", SqlDbType.Int).Value = factura.IdCliente;
                cmd.Parameters.Add("@Fecha_ComprobanteCabecera", SqlDbType.Date).Value = factura.FechaFactura;
                cmd.Parameters.Add("@id_ComprobanteCabecera", SqlDbType.Int).Value = factura.id;
                // Declaro el ID para retornarlo
                var returnParameter = cmd.Parameters.Add("@id_ComprobanteCabecera", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add("@id_ComprobanteCabecera", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                // Retorno el ID_ComprobanteCabecera
                var result = returnParameter.Value;
                factura.id = Convert.ToInt32(result);
                //factura.IDComprobanteCabecera = Convert.ToInt32(cmd.Parameters("@id_ComprobanteCabecera").Value);
            }
            catch (Exception ex)
            {
                EliminarComprobante(factura);
                throw ex;
              
            }
            return factura;
        }
        /// <summary>

        ///     ''' Se llama a un store Procedure para elimina el detalle y la cabecera a partir del id de la cabecera
        ///     ''' Cuando se produce una falla en algun insert, es un rollback del proceso.
        ///     ''' </summary>
        ///     ''' <param name="Comprobante"></param>
        public void EliminarComprobante(Factura comprobante)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();
            SqlCommand cmd = new SqlCommand("ELIMINAR_COMPROBANTE", link);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id_ComprobanteCabecera", SqlDbType.Int).Value = comprobante.id;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     ''' El Store precedure genera el detalle de la factura, va ingresando el o los ID_Traslado mas el ID_ComprobanteCabecera
        ///     ''' </summary>
        ///     ''' <param name="factura"></param>
        ///     ''' <param name="traslado"></param>
        public void CrearFacturaDetalle(Factura factura)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("INSERTAR_FACTURADETALLE", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdTraslado_ComprobanteDetalle", SqlDbType.Int).Value = factura.IdTraslado;
                cmd.Parameters.Add("@IdComprobanteCabecera_ComprobanteDetalle", SqlDbType.Int).Value = factura.id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EliminarComprobante(factura);
                throw ex;
            }
        }

        /// <summary>

        ///     ''' El Store Procedure se fija el ultimo numero del comprobante seleccionado, con la letra seleccionada y le suma 1 para otorgar
        ///     ''' al nuevo comprobante.
        ///     ''' </summary>
        ///     ''' <param name="Factura"></param>
        ///     ''' <returns></returns>
        public Factura UltimoComprobante(Factura comprobante)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("BUSCAR_ULTIMOCOMPROBANTE",link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_tipocomproabte", SqlDbType.Int).Value = comprobante.IdTipo;
                cmd.Parameters.Add("@id_letra", SqlDbType.Int).Value = comprobante.IdLetra;
                cmd.Parameters.Add("@numero_ComprobanteCabecera", SqlDbType.Int).Value = comprobante.NumeroFactura;
                // Declaro el ID para retornarlo
                var returnParameter = cmd.Parameters.Add("@numero_ComprobanteCabecera", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                // Retorno el ID_ComprobanteCabecera
                var result = returnParameter.Value;
                comprobante.NumeroFactura = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobante;
        }

        /// <summary>
        ///     ''' Utilizo este StoreProcedure para impactar fijo los totales de la factura en la cabecera. 
        ///     ''' </summary>
        ///     ''' <param name="factura"></param>
        public void CrearTotales(Factura factura)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("OBTENER_PRECIO_COMPROBANTE",link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id_ComprobanteCabecera", SqlDbType.Int).Value = factura.id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable VW_FACTURA_CABECERA(Factura factura)
        {
            Services.ConexionSQL conexion = new Services.ConexionSQL();
            var link = conexion.ConectarBaseDatos();


            DataSet dataset = new DataSet("LISTAR_FACTURAS");
            DataTable table = new DataTable();
            try
            {
                string procedure = "LISTAR_FACTURAS";

                SqlCommand comando = new SqlCommand(procedure, link);
                comando.CommandType = CommandType.StoredProcedure;
                listarParametros2(comando, factura);
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
        private void listarParametros2(SqlCommand comando, Entities.Factura factura)
        {
            //agregarParametro(comando, "@id_cliente", factura.IdCliente, ParameterDirection.Input, SqlDbType.Int);
            agregarParametro(comando, "@id_letra", factura.IdLetra, ParameterDirection.Input, SqlDbType.Int);
            agregarParametro(comando, "@id_tipocomprobante", factura.IdTipo, ParameterDirection.Input, SqlDbType.Int);
        }

    }


}
