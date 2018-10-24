using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Factura
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public int NumeroFactura { get; set; }

        [DisplayName("Tipo")]
        [Browsable(false)]
        public int IdTipo { get; set; }

        [DisplayName("Tipo")]
        [Browsable(false)]
        public string Tipo { get; set; }

        [DisplayName("Letra")]
        [Browsable(false)]
        public int IdLetra { get; set; }

        [DisplayName("Letra")]
        [Browsable(false)]
        public string Letra { get; set; }

        [DisplayName("Fecha")]
        [Browsable(false)]
        public DateTime FechaFactura { get; set; }

        [DisplayName("FechaInicialTraslado")]
        [Browsable(false)]
        public DateTime FechaInicialTraslado { get; set; }

        [DisplayName("FechaFinalTraslado")]
        [Browsable(false)]
        public DateTime FechaFinalTraslado { get; set; }

        [DisplayName("IdCliente")]
        [Browsable(false)]
        public int IdCliente { get; set; }

        [DisplayName("IdTraslado")]
        [Browsable(false)]
        public int IdTraslado { get; set; }

        [DisplayName("NumeroTraslado")]
        [Browsable(false)]
        public int NumeroTraslado { get; set; }

        [DisplayName("IdComprobanteDetalle")]
        [Browsable(false)]
        public int IdComprobanteDetalle { get; set; }

        [DisplayName("EstadoNombre")]
        [Browsable(false)]
        public string Estado1 { get; set; }

        [DisplayName("Patente")]
        [Browsable(false)]
        public string Patente { get; set; }

        [DisplayName("Obra")]
        [Browsable(false)]
        public string Obra { get; set; }

        [DisplayName("Precio")]
        [Browsable(false)]
        public decimal Precio { get; set; }

        [DisplayName("Comision")]
        [Browsable(false)]
        public decimal Comision { get; set; }

        [DisplayName("carga")]
        [Browsable(false)]
        public decimal carga { get; set; }

        [DisplayName("Subtotal")]
        [Browsable(false)]
        public decimal Subtotal { get; set; }

        [DisplayName("Iva")]
        [Browsable(false)]
        public decimal Iva { get; set; }

        [DisplayName("Total")]
        [Browsable(false)]
        public decimal Total { get; set; }

        [DisplayName("RazonSocial")]
        [Browsable(false)]
        public String RazonSocial { get; set; }

        [DisplayName("Cuit")]
        [Browsable(false)]
        public String Cuit { get; set; }

        [DisplayName("Calle")]
        [Browsable(false)]
        public String Calle { get; set; }

        [DisplayName("numero")]
        [Browsable(false)]
        public int numero { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public String Localidad { get; set; }

        [DisplayName("TipoContribuyente")]
        [Browsable(false)]
        public String TipoContribuyente { get; set; }
    }
}
