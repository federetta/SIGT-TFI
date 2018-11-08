using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Recibo
    {

        [DisplayName("ID")]
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("NumeroCobranza")]
        [Browsable(false)]
        public int NumeroCobranza { get; set; }

        [DisplayName("FechaCobranza")]
        [Browsable(false)]
        public int FechaCobranza { get; set; }

        [DisplayName("Cliente")]
        [Browsable(false)]
        public int IdCliente { get; set; }

        [DisplayName("IdMedioPago")]
        [Browsable(false)]
        public int IdMedioPago { get; set; }

        [DisplayName("IdEntidadBancaria")]
        [Browsable(false)]
        public int IdEntidadBancaria { get; set; }

        [DisplayName("Numero")]
        [Browsable(false)]
        public int NumeroRecibo { get; set; }

        [DisplayName("FechaRecibo")]
        [Browsable(false)]
        public DateTime FechaRecibo { get; set; }

        [DisplayName("PlazoRecibo")]
        [Browsable(false)]
        public int PlazoRecibo { get; set; }

        [DisplayName("Endosable")]
        [Browsable(false)]
        public bool Endosable { get; set; }

        [DisplayName("Directo")]
        [Browsable(false)]
        public bool Directo { get; set; }

        [DisplayName("DocLibrador")]
        [Browsable(false)]
        public int DocLibrador { get; set; }

        [DisplayName("Observaciones")]
        [Browsable(false)]
        public string Observaciones { get; set; }

        [DisplayName("Monto")]
        [Browsable(false)]
        public double Monto { get; set; }

        [DisplayName("IdCobranza")]
        [Browsable(false)]
        public int idcobranza { get; set; }

    }
}
