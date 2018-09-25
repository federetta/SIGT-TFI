using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class Traslado
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public int NumeroTraslado { get; set; }

        [DisplayName("Fecha")]
        [Browsable(false)]
        public DateTime Fecha { get; set; }

        [DisplayName("Transporte")]
        [Browsable(false)]
        public int IdTransporte { get; set; }

        [DisplayName("Recorrido")]
        [Browsable(false)]
        public int IdRecorrido { get; set; }

        [DisplayName("Carga")]
        [Browsable(false)]
        public string Carga { get; set; }

        [DisplayName("Estado")]
        [Browsable(false)]
        public int Estado { get; set; }

    }
}
