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
    public class DALMedioPago : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<MedioPago> Select()
        {
            const string sqlStatement = "SELECT [id_MedioPago], [Descripcion_MedioPago] FROM dbo.MedioPago ";

            var result = new List<MedioPago>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var MedioPago = LoadMedioPago(dr); // Mapper
                        result.Add(MedioPago);
                    }
                }
            }

            return result;
        }

        private static MedioPago LoadMedioPago(IDataReader dr)
        {
            var MedioPago = new MedioPago
            {
                IdMedioPago = GetDataValue<int>(dr, "id_MedioPago"),
                Nombre = GetDataValue<string>(dr, "Descripcion_MedioPago"),
            };


            return MedioPago;
        }

    }
}

