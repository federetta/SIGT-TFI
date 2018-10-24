using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SIGT_TFI.Models
{
    public class FacturaPDFViewModels
    {
        
        [DisplayName("Numero")]
        [Browsable(false)]
        public int NumeroFactura { get; set; }


        [DisplayName("Tipo")]
        [Browsable(false)]
        public string Tipo { get; set; }

        [DisplayName("Letra")]
        [Browsable(false)]
        public string Letra { get; set; }

        [DisplayName("Fecha")]
        [Browsable(false)]
        public DateTime FechaFactura { get; set; }

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
        public string Cuit { get; set; }

        [DisplayName("Calle")]
        [Browsable(false)]
        public String Calle { get; set; }

        [DisplayName("numero")]
        [Browsable(false)]
        public int numero { get; set; }

        public String TipoContribuyente { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public String Localidad { get; set; }
        public List<TrasladoPDFViewModels> ListaTraslados { get; set; }
    }
}