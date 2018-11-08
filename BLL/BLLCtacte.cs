using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLCtacte
    {
        /// <summary>
        ///     '''     Busco el Saldo de las Facturas en la Copia Fiel
        ///     ''' </summary>
        ///     ''' <param name="objeto"></param>

        ///     ''' <returns></returns>
        public DataTable BUSCAR_FACTURA_SALDO(CuentaCorriente objeto)
        {
            var DAC = new DALCuentaCorriente();
            try
            {
                return DAC.BUSCAR_FACTURA_SALDO(objeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>

        ///     ''' Traigo la vista de las cobranzas de un cliente.
        ///     ''' </summary>
        ///     ''' <param name="objeto"></param>
        ///     ''' <returns></returns>
        public DataTable BuscarCobranza_View(Entities.CuentaCorriente objeto)
        {
            var DAC = new DALCuentaCorriente();
            try
            {
                return DAC.BuscarCobranza_View(objeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
