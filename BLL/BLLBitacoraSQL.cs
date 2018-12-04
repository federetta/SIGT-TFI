using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLBitacoraSQL
    {
        private DALBitacoraSQL datos = new DALBitacoraSQL();
        public void CrearBitacora(BitacoraSQL objeto)
        {
            try
            {
                datos.CrearBitacoraSQL(objeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BitacoraSQL> LISTAR_Bitacora()
        {
            var DAC = new DALBitacoraSQL();
            try
            {

                var dal = new DALBitacoraSQL();
                var result = dal.SelectBitacora();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
