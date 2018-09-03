using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities
{   [Serializable]

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
        public Int32 Cuit { get; set; }
        public int Tipo_Contribuyente { get; set; }
        //public TipoEmpresa Tipo_Empresa { get; set; }
        
        [DisplayName("Tipo_Empresa")]
        public int Tipo_Empresa { get; set; }


    }
}
