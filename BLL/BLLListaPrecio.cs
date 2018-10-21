using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class BLLListaPrecio
    {
        public ListaPrecio CrearListaPrecio(ListaPrecio objeto)
        {
            try
            {
                var DAC = new DALListaPrecio();
                DAC.CrearListaPrecio(objeto);

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

        DALListaPrecio DAL = new DALListaPrecio();
        public List<ListaPrecio> ListByRecorrido(int id)
        {
            var result = DAL.SelectListaPrecio(id);
            return result;
        }
    }
}
