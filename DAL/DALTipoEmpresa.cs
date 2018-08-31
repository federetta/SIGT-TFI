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
    public class DALTipoEmpresa : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<TipoEmpresa> Select()
        {
            const string sqlStatement = "SELECT [id_tipoempresa], [valor_tipoempresa] FROM dbo.Tipo_Empresa ";

            var result = new List<TipoEmpresa>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var tipoempresas = LoadTipoEmpresa(dr); // Mapper
                        result.Add(tipoempresas);
                    }
                }
            }
            
            return result;
        }

        private static TipoEmpresa LoadTipoEmpresa(IDataReader dr)
        {
            var tipoempresa = new TipoEmpresa
            {
                Id = GetDataValue<int>(dr, "id_tipoempresa"),
                Nombre = GetDataValue<string>(dr, "valor_tipoempresa"),
            };


            return tipoempresa;
        }

    }
}
