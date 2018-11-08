﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;


namespace BLL
{
    public class BLLCobranza
    {

        public void CrearCobranzaDetalle(List<Recibo> recibos)
        {
            var DAC = new DALCobranza();
            var id = recibos.FirstOrDefault().idcobranza;
            try
            {
                foreach (var item in recibos)
                {
                    
                    DAC.CrearCobranzaDetalle(item);

                }
                DAC.CrearTotales(id);
            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }

        }
        public void CrearTotales(int recibo)
        {
            var DAC = new DALCobranza();
            try
            {
               DAC.CrearTotales(recibo);

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }

        }

        public Cobranza CrearCobranzaCabecera(Cobranza cobranza)
        {
            var DAC = new DALCobranza();
            try
            {
                return DAC.CrearCobranza(cobranza);

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }

        }

        public List<Cliente> BuscarCobranza_View(Cliente objeto)
        {
            var DAC = new DALCobranza();
            try
            {

                var datatable = DAC.BuscarCobranza_View(objeto);
                return datatable.AsEnumerable().Select(row => new Cliente()
                {
                    NumeroCobranza = row.Field<int>("Numero"),
                    FechaCobranza = row.Field<DateTime>("Fecha"),
                    TotalCobranza = row.Field<decimal>("Total"),



                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> SaldoCuentaCorriente(Cliente objeto)
        {
            var DAC = new DALCobranza();
            try
            {

                var datatable = DAC.SaldoCuentaCOrriente(objeto);
                return datatable.AsEnumerable().Select(row => new Cliente()
                {
                    Saldo = row.Field<decimal>("Saldo"),



                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}
