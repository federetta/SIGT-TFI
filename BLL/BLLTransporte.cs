using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTransporte
    {
        DALTransporte daltransporte = new DALTransporte();

        public Entities.Transporte CreateProveedor(Entities.Transporte objeto)
        {
            try
            {
                daltransporte.CreateTransporte(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }

        public List<Transporte> ListByProviderID(int id)
        {
            var transporteDac = new DALTransporte();
            var result = transporteDac.SelectTransporte(id);
            return result;

        }

        public List<Transporte> List()
        {
            var transporteDac = new DALTransporte();
            var result = transporteDac.SelectAllTransporte();
            return result;

        }
    }
}
