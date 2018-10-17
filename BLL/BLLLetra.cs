using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLLetra
    {
        public List<Letra> All()
        {
            var LetraDac = new DALLetra();
            var result = LetraDac.Select();
            return result;
        }

    }

}

