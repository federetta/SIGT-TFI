using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Provincia
    {

        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Browsable(false)]
        public String Nombre { get; set; }
    }
}
