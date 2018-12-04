using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;


namespace BLL
{
    public class BLLFactura
    {
        BLLBitacoraSQL logSQL = new BLLBitacoraSQL();

        public List<Traslado> LISTAR_COMPROBANTE_DETALLE(Cliente objeto)
        {
            var DAC = new DALFactura();
            try
            {

                var datatable = DAC.LISTAR_COMPROBANTE_DETALLE(objeto);
                return datatable.AsEnumerable().Select(row => new Traslado()
                {
                    id = row.Field<int>("id_traslado"),
                    NumeroTraslado = row.Field<int>("numero_traslado"),
                    Fecha = row.Field<DateTime>("fecha_traslado"),
                    Patente = row.Field<string>("Patente_Transporte"),
                    Obra = row.Field<string>("Nombre_Obra"),
                    Carga = row.Field<Decimal>("carga_traslado"),
                    Precio = row.Field<decimal>("precio_listaprecio"),
                    Comision = row.Field<decimal>("comision_listaprecio"),
                    Total = row.Field<decimal>("Precio_Total"),
                    Estado1 = row.Field<string>("nombre_estado"),



                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Cliente> VW_FACTURA_CABECERA(Cliente objeto)
        {
            var DAC = new DALFactura();
            try
            {

                var datatable = DAC.VW_FACTURA_CABECERA(objeto);
                return datatable.AsEnumerable().Select(row => new Cliente()
                {
                    id = row.Field<int>("Id_ComprobanteCabecera"),
                    Tipo = row.Field<string>("Descripcion_TipoComprobante"),
                    Letra = row.Field<string>("nombre_letra"),
                    FechaFactura= row.Field<DateTime>("Fecha_ComprobanteCabecera"),
                    NumeroFactura = row.Field<int>("Numero_ComprobanteCabecera"),
                    Subtotal = row.Field<Decimal>("Subtotal_ComprobanteCabecera"),
                    Iva = row.Field<decimal>("TotalIva_ComprobanteCabecera"),
                    Total = row.Field<decimal>("Total_ComprobanteCabecera"),



                }).ToList();


            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public List<Cliente> VW_FACTURA_SALDO(Cliente objeto)
        {
            var DAC = new DALFactura();
            try
            {

                var datatable = DAC.VW_FACTURA_SALDO(objeto);
                return datatable.AsEnumerable().Select(row => new Cliente()
                {
                    Tipo = row.Field<string>("Descripcion"),
                    Letra = row.Field<string>("letra"),
                    FechaFactura = row.Field<DateTime>("Fecha"),
                    NumeroFactura = row.Field<int>("Numero"),
                    Subtotal = row.Field<Decimal>("Subtotal"),
                    Iva = row.Field<decimal>("TotalIva"),
                    Total = row.Field<decimal>("Total"),



                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convierto la vista de VW_FACTURA en objeto factura para emitir el PDF del comprobante. 
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<Cliente> VW_FACTURA_HISTORICO2(int objeto)
        {
            var factura = new Cliente();
            factura.id = Convert.ToInt32(objeto);
            var DAC = new DALFactura();
            try
            {
                var datatable = DAC.VW_FACTURA_HISTORICO2(factura);
                return datatable.AsEnumerable().Select(row => new Cliente()
                {
                    id = row.Field<int>("Id_ComprobanteCabecera"),
                    Tipo = row.Field<string>("Descripcion_TipoComprobante"),
                    Letra = row.Field<string>("nombre_letra"),
                    FechaFactura = row.Field<DateTime>("Fecha_ComprobanteCabecera"),
                    NumeroFactura = row.Field<int>("Numero_ComprobanteCabecera"),
                    NumeroTraslado = row.Field<int>("numero_traslado"),
                    carga = row.Field<decimal>("carga_traslado"),
                    Precio = row.Field<decimal>("precioFacturado_Traslado"),
                    Comision = row.Field<decimal>("preciocomision_Traslado"),
                    Subtotal = row.Field<decimal>("Subtotal_ComprobanteCabecera"),
                    Iva = row.Field<decimal>("TotalIva_ComprobanteCabecera"),
                    Total = row.Field<decimal>("Total_ComprobanteCabecera"),
                    RazonSocial = row.Field<string>("RazonSocial_Empresa"),
                    Cuit = row.Field<string>("Cuit_Empresa"),
                    Calle = row.Field<string>("Calle_Domicilio"),
                    numero = row.Field<int>("Numero_Domicilio"),
                    Localidad = row.Field<string>("Nombre_Localidad"),
                    TipoContribuyente = row.Field<string>("Nombre_TipoContribuyente"),


                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Cliente UltimoComprobante(Cliente objeto)
        {
            var DAC = new DALFactura();
            return DAC.UltimoComprobante(objeto);
        }



        /// <summary>

        ///     '''     Crea la cabecera de la facutra.
        ///     ''' </summary>
        ///     ''' <param name="objeto"></param>
        ///     ''' <returns></returns>
        public Cliente CrearFactura(Cliente objeto, string user)
        {
            try
            {
                var DAC = new DALFactura();
                var ultimonumero = DAC.UltimoComprobante(objeto);
                objeto.NumeroFactura = ultimonumero.NumeroFactura;

                DAC.CrearFactura(objeto);
                //// Guardo una Bitacora en la DB
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = "Nueva Factura" + Convert.ToString(objeto.NumeroFactura), tipo = "negocio", Usuario = user });
                return objeto;
            }
            catch (Exception ex)
            {
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = user, CustomError = ex.StackTrace });
                throw ex;
            }
        }

        /// <summary>
        ///     '''     Creo el detalle de la Factura emitida.
        ///     ''' </summary>
        ///     ''' <param name="factura"></param>
        public void CrearFacturaDetalle(Cliente factura, string user)
        {
            var DAC = new DALFactura();
            try
            {
              
                    factura.IdTraslado = factura.IdTraslado;
                    factura.id = factura.id;
                    DAC.CrearFacturaDetalle(factura);
                try
                {
                    DAC.CrearTotales(factura);
                    logSQL.CrearBitacora(new BitacoraSQL() { mensaje = "Nuevo Detalle" + Convert.ToString(factura.NumeroFactura), tipo = "negocio", Usuario = user });

                }
                catch (Exception ex)
                {
                    logSQL.CrearBitacora(new BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = user, CustomError = ex.StackTrace });

                    throw ex;

                }


                //    // Guardo una bitacora Local
                //    //logLocal.CrearLog("Nuevo detalle Factura");
                //    //// Guardo una Bitacora en la DB
                //    //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = "Nueva detalle Factura" + Convert.ToString(factura.IDComprobanteCabecera), tipo = "negocio", Usuario = Sesion.sesion.Nombreusuario });
                //}
            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }

        }


        public void CrearTotales(Cliente factura, string user)
        {
            var DAC = new DALFactura();
        
                try
                {
                    DAC.CrearTotales(factura);
                }
                catch (Exception ex)
                {
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = user, CustomError = ex.StackTrace });

                throw ex;

                }
            

        }
    }
}
