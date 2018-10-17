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
        public Decimal Carga { get; set; }

        [DisplayName("Estado")]
        [Browsable(false)]
        public int Estado { get; set; }

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

        [DisplayName("Total")]
        [Browsable(false)]
        public decimal Total { get; set; }

        public bool Selected { get; set; }

    }
}
