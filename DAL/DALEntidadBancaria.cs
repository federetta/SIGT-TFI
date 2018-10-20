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
    public class DALEntidadBancaria : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<EntidadBancaria> Select()
        {
            const string sqlStatement = "SELECT [id_EntidadBancaria], [nombre_EntidadBancaria] FROM dbo.EntidadBancaria ";

            var result = new List<EntidadBancaria>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var EntidadBancaria = LoadEntidadBancaria(dr); // Mapper
                        result.Add(EntidadBancaria);
                    }
                }
            }

            return result;
        }

        private static EntidadBancaria LoadEntidadBancaria(IDataReader dr)
        {
            var EntidadBancaria = new EntidadBancaria
            {
                Id = GetDataValue<int>(dr, "id_EntidadBancaria"),
                Nombre = GetDataValue<string>(dr, "nombre_EntidadBancaria"),
            };


            return EntidadBancaria;
        }

    }
}

