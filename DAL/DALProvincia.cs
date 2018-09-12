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
    public class DALProvincia : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<Provincia> Select()
        {
            const string sqlStatement = "SELECT [id_provincia], [nombre_provincia] FROM dbo.provincia ";

            var result = new List<Provincia>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var provincia = LoadProvincia(dr); // Mapper
                        result.Add(provincia);
                    }
                }
            }
            
            return result;
        }

        private static Provincia LoadProvincia(IDataReader dr)
        {
            var provincia = new Provincia
            {
                Id = GetDataValue<int>(dr, "id_provincia"),
                Nombre = GetDataValue<string>(dr, "nombre_provincia"),
            };


            return provincia;
        }

    }
}
