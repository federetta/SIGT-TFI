using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Obra
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("idCliente")]
        [Browsable(false)]
        public int IdCliente { get; set; }

        [DisplayName("Nombre")]
        [Browsable(false)]
        public String Nombre { get; set; }
    }
}
