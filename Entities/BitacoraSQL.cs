using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities
{
    [Serializable]
    public class BitacoraSQL
    {
        [Browsable(false)]
        public DateTime fecha { get; set; }

        [Browsable(false)]
        public string mensaje { get; set; }
        [Browsable(false)]
        public string ComputerName { get; set; }
        [Browsable(false)]
        public string IP { get; set; }

        [Browsable(false)]
        public string WindowsUser { get; set; }

        [Browsable(false)]
        public string CustomError { get; set; }

        [Browsable(false)]
        public string Usuario { get; set; }
        [Browsable(false)]
        public string tipo { get; set; }

      
    }
}
