using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Recorrido
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("idObra")]
        [Browsable(false)]
        public int IdObra { get; set; }

        [DisplayName("Inicio")]
        [Browsable(false)]
        public String Inicio { get; set; }

        [DisplayName("Fin")]
        [Browsable(false)]
        public String Fin { get; set; }
    }
}
