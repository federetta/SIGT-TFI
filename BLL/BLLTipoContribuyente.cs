using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTipoContribuyente
    {
        public List<TipoContribuyente> All()
        {
            var TipoContribuyenteDAC = new DALTipoContribuyente();
            var result = TipoContribuyenteDAC.Select();
            return result;
        }

    }

}

