using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BllMedioPago
    {
        public List<MedioPago> All()
        {
            var MedioPagoDAC = new DALMedioPago();
            var result = MedioPagoDAC.Select();
            return result;
        }

    }

}

