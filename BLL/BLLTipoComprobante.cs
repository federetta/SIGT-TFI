using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTipoComprobante
    {
        public List<TipoComprobante> All()
        {
            var TipocomprobanteDac = new DALTipoComprobante();
            var result = TipocomprobanteDac.Select();
            return result;
        }

    }

}

