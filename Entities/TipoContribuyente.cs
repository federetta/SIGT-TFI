using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoContribuyente
    {
        [DisplayName("Id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("Nombre")]
        [Browsable(false)]
        public String nombre { get; set; }
    }
}
