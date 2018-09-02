using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTipoContribuyente : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<TipoContribuyente> Select()
        {
            const string sqlStatement = "SELECT [id_tipocontribuyente], [nombre_tipocontribuyente] FROM dbo.TipoContribuyente ";

            var result = new List<TipoContribuyente>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var tipoempresas = LoadTipoContribuyente(dr); // Mapper
                        result.Add(tipoempresas);
                    }
                }
            }

            return result;
        }

        private static TipoContribuyente LoadTipoContribuyente(IDataReader dr)
        {
            var tipoempresa = new TipoContribuyente
            {
                id = GetDataValue<int>(dr, "id_tipocontribuyente"),
                nombre = GetDataValue<string>(dr, "nombre_tipocontribuyente"),
            };


            return tipoempresa;
        }

    }
}

