using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class BLLContacto
    {
        DALContacto DAL = new DALContacto();
        public List<Contacto> ListByCompanyID(int id)
        {
            var result = DAL.SelectContacto(id);
            return result;
        }

        public Contacto CreateContacto(Contacto objeto)
        {
            try
            {
                DAL.CreateContacto(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }
    }
}
