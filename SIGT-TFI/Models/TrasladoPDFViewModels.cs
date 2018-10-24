using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SIGT_TFI.Models
{
    public class TrasladoPDFViewModels
    {
       
        [DisplayName("NumeroTraslado")]
        [Browsable(false)]
        public int NumeroTraslado { get; set; }


        [DisplayName("Precio")]
        [Browsable(false)]
        public decimal Precio { get; set; }

        [DisplayName("Comision")]
        [Browsable(false)]
        public decimal Comision { get; set; }

        [DisplayName("carga")]
        [Browsable(false)]
        public decimal carga { get; set; }

        [DisplayName("PrecioTotal")]
        [Browsable(false)]
        public decimal PrecioTotal { get; set; }

        [DisplayName("PrecioTotal")]
        [Browsable(false)]
        public decimal PrecioxCant { get; set; }



    }
}