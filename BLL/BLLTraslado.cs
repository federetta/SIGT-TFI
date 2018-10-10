using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTraslado
    {
        DALTraslado daltraslado = new DALTraslado();
       
        public Entities.Traslado CreateTraslado(Traslado objeto)
        {
            try
            {
                objeto.Estado = 2;
                daltraslado.CreateTraslado(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }


        public List<Traslado> All()
        {
            var dal = new DALTraslado();
            var result = dal.Select();
            return result;
        }
    }
}
