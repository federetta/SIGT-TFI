using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Domicilio
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("idempresa")]
        [Browsable(false)]
        public int Idempresa { get; set; }

        [DisplayName("Calle")]
        [Browsable(false)]
        public String Calle { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public int Numero { get; set; }

        [DisplayName("Localidad")]
        [Browsable(false)]
        public int IdLocalidad { get; set; }

        [DisplayName("Piso")]
        [Browsable(false)]
        public string Piso { get; set; }

        [DisplayName("Depto")]
        [Browsable(false)]
        public string Depto { get; set; }

        [DisplayName("CP")]
        [Browsable(false)]
        public string CodigoPostal { get; set; }

        [DisplayName("Provincia")]
        [Browsable(false)]
        public int IdProvincia { get; set; }


    }
}
