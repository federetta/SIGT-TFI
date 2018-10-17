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

        public List<Traslado> LISTAR_COMPROBANTE_DETALLE(Factura objeto)
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
        public Factura UltimoComprobante(Factura objeto)
        {
            var DAC = new DALFactura();
            return DAC.UltimoComprobante(objeto);
        }



        /// <summary>

        ///     '''     Crea la cabecera de la facutra.

        ///     ''' </summary>

        ///     ''' <param name="objeto"></param>

        ///     ''' <returns></returns>
        public Factura CrearFactura(Factura objeto)
        {
            try
            {
                var DAC = new DALFactura();
                var ultimonumero = DAC.UltimoComprobante(objeto);
                objeto.NumeroFactura = ultimonumero.NumeroFactura;

                DAC.CrearFactura(objeto);
                // Guardo una bitacora Local
                //logLocal.CrearLog("NuevaFactura");
                //// Guardo una Bitacora en la DB
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = "Nueva Cabecera Factura  " + Convert.ToString(objeto.Cliente.RazonSocial) + "ID:" + Convert.ToString(objeto.IDComprobanteCabecera) + "Numero: " + Convert.ToString(objeto.numero), tipo = "negocio", Usuario = Sesion.sesion.Nombreusuario });
                return objeto;
            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
        }

        /// <summary>
        ///     '''     Creo el detalle de la Factura emitida.
        ///     ''' </summary>
        ///     ''' <param name="factura"></param>
        public void CrearFacturaDetalle(Factura factura)
        {
            var DAC = new DALFactura();
            try
            {
              
                    factura.IdTraslado = factura.IdTraslado;
                    factura.id = factura.id;
                    DAC.CrearFacturaDetalle(factura);
                

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

    }
}
