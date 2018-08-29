using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLEmpresa
    {
        DALEmpresa dalempresa = new DALEmpresa();
        public Entities.Empresa Insertarempresa(Entities.Empresa objeto)
        {
            try
            {
                dalempresa.InsertarEmpresa(objeto);
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
