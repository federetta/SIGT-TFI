using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLObra
    {
        DALObra DAL = new DALObra();
        public List<Obra> ListByCompanyID(int id)
        {
            var result = DAL.SelectObra(id);
            return result;
        }

        public Obra CreateObra(Obra objeto)
        {
            try
            {
                DAL.CreateObra(objeto);
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
