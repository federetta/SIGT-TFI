using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public String RazonSocial { get; set; }
        public String NombreFantasia { get; set; }
        public int Cuit { get; set; }
        public TipoContribuyente TipoContribuyente { get; set; }
        public TipoEmpresa Tipo_Empresa { get; set; }
        

    }
}
