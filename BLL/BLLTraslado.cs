using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Services;

namespace BLL
{
    public class BLLTraslado
    {
        DALTraslado daltraslado = new DALTraslado();
        BLLBitacoraSQL logSQL = new BLLBitacoraSQL();
        public Entities.Traslado CreateTraslado(Traslado objeto, string user)
        {
            try
            {
                objeto.Estado = 2;
                daltraslado.CreateTraslado(objeto);
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = "Nuevo Traslado " + Convert.ToString(objeto.NumeroTraslado), tipo = "negocio", Usuario = user });

            }
            catch (Exception ex)
            {
                logSQL.CrearBitacora(new BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = user, CustomError = ex.StackTrace });
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
