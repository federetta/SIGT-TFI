using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLProvincia
    {
        public List<Provincia> All()
        {
            var dal = new DALProvincia();
            var result = dal.Select();
            return result;
        }

    }
}
