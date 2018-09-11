using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTipoContacto
    {
        public List<TipoContacto> All()
        {
            var Dal = new DALTipoContacto();
            var result = Dal.Select();
            return result;
        }
    }
}
