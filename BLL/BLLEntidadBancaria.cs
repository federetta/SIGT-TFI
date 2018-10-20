using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLEntidadBancaria
    {
        public List<EntidadBancaria> All()
        {
            var EntidadBancariaDAC = new DALEntidadBancaria();
            var result = EntidadBancariaDAC.Select();
            return result;
        }

    }

}

