using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLTipoEmpresa
    {
        //DAL.DALTipoEmpresa DAC = new DALTipoEmpresa();
        public List<TipoEmpresa> All()
        {
            var TipoEmpresaDac = new DALTipoEmpresa();
            var result = TipoEmpresaDac.Select();
            return result;
        }

    }
}
