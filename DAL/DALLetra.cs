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
    public class DALLetra : DataAccessComponent
    {
        Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<Letra> Select()
        {
            const string sqlStatement = "SELECT [id_letra], [nombre_letra] FROM dbo.Letra ";

            var result = new List<Letra>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var letra = LoadLetra(dr); // Mapper
                        result.Add(letra);
                    }
                }
            }

            return result;
        }

        private static Letra LoadLetra(IDataReader dr)
        {
            var letra = new Letra
            {
                id = GetDataValue<int>(dr, "id_letra"),
                Nombre = GetDataValue<string>(dr, "nombre_letra"),
            };


            return letra;
        }

    }
}

