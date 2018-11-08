using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class CuentaCorriente
    {
        
        [DisplayName("idcliente")]
        [Browsable(false)]
        public int idcliente { get; set; }

        [Browsable(false)]
        public List<Cliente> Facturas { get; set; }
        [Browsable(false)]
        public List<Cobranza> Cobranzas { get; set; }
    }
}
