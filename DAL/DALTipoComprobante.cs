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
    public class DALTipoComprobante : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<TipoComprobante> Select()
        {
            const string sqlStatement = "SELECT [id_tipocomprobante], [Descripcion_tipocomprobante] FROM dbo.TipoComprobante ";

            var result = new List<TipoComprobante>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var tipocomprobante = LoadTipoComprobante(dr); // Mapper
                        result.Add(tipocomprobante);
                    }
                }
            }

            return result;
        }

        private static TipoComprobante LoadTipoComprobante(IDataReader dr)
        {
            var tipocomprobante = new TipoComprobante
            {
                id = GetDataValue<int>(dr, "id_tipocomprobante"),
                Nombre = GetDataValue<string>(dr, "descripcion_tipocomprobante"),
            };


            return tipocomprobante;
        }

    }
}

