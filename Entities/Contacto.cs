using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Contacto
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("idempresa")]
        [Browsable(false)]
        public int idempresa { get; set; }

        [DisplayName("idtipocontacto")]
        [Browsable(false)]
        public int idtipocontacto { get; set; }
          
        [DisplayName("Valor")]
        [Browsable(false)]
        public string Valor { get; set; }

    }
}
