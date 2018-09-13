using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLRecorrido
    {
        DALRecorrido DAL = new DALRecorrido();
        public List<Recorrido> ListByObra(int id)
        {
            var result = DAL.SelectRecorrido(id);
            return result;
        }

        public Recorrido CreateRecorrido(Recorrido objeto)
        {
            try
            {
                DAL.CreateRecorrido(objeto);
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
