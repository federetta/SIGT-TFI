using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;


namespace BLL
{
    public class BLLFactura
    {
        public List<Traslado> LISTAR_COMPROBANTE_DETALLE(Factura objeto)
        {
           
                try
                {
                var DAC = new DALFactura();
                var datatable = DAC.LISTAR_COMPROBANTE_DETALLE(objeto);
                return datatable.AsEnumerable().Select(row => new Traslado() {
                    id = row.Field<int>("id_traslado"),
                    NumeroTraslado = row.Field<int>("numero_traslado"),
                    Fecha = row.Field<DateTime>("fecha_traslado"),
                    Patente = row.Field<string>("Patente_Transporte"),
                    Obra = row.Field<string>("Nombre_Obra"),
                    Carga = row.Field<Decimal>("carga_traslado"),
                    Precio = row.Field<decimal>("precio_listaprecio"),
                    Comision = row.Field<decimal>("comision_listaprecio"),
                    Total = row.Field<decimal>("Precio_Total"),
                    Estado1 = row.Field<string>("nombre_estado"),



                }).ToList();
            }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

    }
}
