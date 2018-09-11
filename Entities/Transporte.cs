using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Transporte
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }

        [DisplayName("idProveedor")]
        [Browsable(false)]
        public int IdProveedor { get; set; }

        [DisplayName("Marca")]
        [Browsable(false)]
        public String Marca { get; set; }

        [DisplayName("Modelo")]
        [Browsable(false)]
        public string Modelo { get; set; }

        [DisplayName("Tara")]
        [Browsable(false)]
        public int Tara { get; set; }

        [DisplayName("Patente")]
        [Browsable(false)]
        public string Patente { get; set; }

        [DisplayName("Descripcion")]
        [Browsable(false)]
        public string Descripcion { get; set; }

        [DisplayName("Titular")]
        [Browsable(false)]
        public string Titular { get; set; }


    }
}
