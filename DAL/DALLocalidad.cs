using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Entities;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace DAL
{
    public class DALLocalidad : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<Localidad> Select()
        {
            const string sqlStatement = "SELECT [id_localidad], [nombre_localidad] FROM dbo.localidad ";

            var result = new List<Localidad>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var localidad = LoadLocalidad(dr); // Mapper
                        result.Add(localidad);
                    }
                }
            }
            
            return result;
        }

        private static Localidad LoadLocalidad(IDataReader dr)
        {
            var localidad = new Localidad
            {
                Id = GetDataValue<int>(dr, "id_localidad"),
                Nombre = GetDataValue<string>(dr, "nombre_localidad"),
            };


            return localidad;
        }

    }
}
