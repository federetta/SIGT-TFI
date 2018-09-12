using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;


namespace BLL
{
    public class BLLDomicilio
    {
        DALDomicilio daldomicilio = new DALDomicilio();

        public Entities.Domicilio CreateDomicilio(Entities.Domicilio objeto)
        {
            try
            {
                daldomicilio.CreateDomicilio(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }

        public List<Domicilio> ListByProviderID(int id)
        {
            var domicilioDac = new DALDomicilio();
            var result = domicilioDac.SelectDomicilio(id);
            return result;

        }
    }
}
