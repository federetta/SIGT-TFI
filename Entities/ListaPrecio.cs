using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ListaPrecio
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("idrecorrido")]
        [Browsable(false)]
        public int idrecorrido { get; set; }

        [DisplayName("fechainicial")]
        [Browsable(false)]
        public DateTime fechainicial { get; set; }

        [DisplayName("fechafinal")]
        [Browsable(false)]
        public DateTime fechafinal { get; set; }

        [DisplayName("precio")]
        [Browsable(false)]
        public decimal precio { get; set; }

        [DisplayName("comision")]
        [Browsable(false)]
        public decimal comision { get; set; }

        [DisplayName("fechavalidacion")]
        [Browsable(false)]
        public DateTime fechavalidacion { get; set; }


    }
}
