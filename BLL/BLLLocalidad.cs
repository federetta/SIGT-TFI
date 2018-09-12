using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLLocalidad
    { 
    public List<Localidad> All()
    {
        var dal = new DALLocalidad();
        var result = dal.Select();
        return result;
    }
    }

}
