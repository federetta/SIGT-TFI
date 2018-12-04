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
        BLLBitacoraSQL logSQL = new BLLBitacoraSQL();

        public ListaPrecio CrearListaPrecio(ListaPrecio objeto, string user)
        {
            try
            {
                var DAC = new DALListaPrecio();
                DAC.CrearListaPrecio(objeto);
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = "Nueva Lista Precio  " + Convert.ToString(objeto.id), tipo = "negocio", Usuario = user });

                // Guardo una bitacora Local
                //logLocal.CrearLog("NuevaFactura");
                //// Guardo una Bitacora en la DB
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = "Nueva Cabecera Factura  " + Convert.ToString(objeto.Cliente.RazonSocial) + "ID:" + Convert.ToString(objeto.IDComprobanteCabecera) + "Numero: " + Convert.ToString(objeto.numero), tipo = "negocio", Usuario = Sesion.sesion.Nombreusuario });
                return objeto;
            }
            catch (Exception ex)
            {
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = user, CustomError = ex.StackTrace });
                throw ex;
            }
        }

        DALListaPrecio DAL = new DALListaPrecio();
        public List<ListaPrecio> ListByRecorrido(int id)
        {
            var result = DAL.SelectListaPrecio(id);
            return result;
        }

        
        public DateTime GetUltimaFecha(int id)
        {
            var result = DAL.GetUltimaFecha(id);
            return result;
        }
    }
}
