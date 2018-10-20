using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MedioPago
    {
        [DisplayName("ID")]
        [Browsable(false)]
        public int IdMedioPago { get; set; }

        [DisplayName("Nombre")]
        [Browsable(false)]
        public String Nombre { get; set; }
    }
}
