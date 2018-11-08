using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cobranza
    {
        [DisplayName("idcobranzacabecera")]
        [Browsable(false)]
        public int IdCobranzaCabecera { get; set; }

        [DisplayName("idcobranzadetalle")]
        [Browsable(false)]
        public int IdCobranzaDetalle { get; set; }

        [DisplayName("idrecibo")]
        [Browsable(false)]
        public int IdRecibo { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public int NumeroCobranza { get; set; }

        [DisplayName("FechaCobranza")]
        [Browsable(false)]
        public DateTime FechaCobranza { get; set; }

        [DisplayName("Cliente")]
        [Browsable(false)]
        public int IdCliente { get; set; }

        [DisplayName("Recibos")]
        [Browsable(false)]
        public List<Recibo> Recibos { get; set; }
    }
}
