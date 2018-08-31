using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Empresa
    {
        [DisplayName("id")]
        [Browsable(false)]
        public int id { get; set; }
        [DisplayName("RazonSocial")]
        [Browsable(false)]
        public String RazonSocial { get; set; }
        [DisplayName("NombreFantasia")]
        [Browsable(false)]
        public String NombreFantasia { get; set; }
        [DisplayName("Cuit")]
        [Browsable(false)]
        public int Cuit { get; set; }
        public TipoContribuyente TipoContribuyente { get; set; }
        public TipoEmpresa Tipo_Empresa { get; set; }
        

    }
}
