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
   public class DALTipoContacto : DataAccessComponent
    {
         Services.ConexionSQL conexion = new Services.ConexionSQL();

        public List<TipoContacto> Select()
        {
            const string sqlStatement = "SELECT [id_tipocontacto], [Valor_TipoContacto] FROM dbo.Tipo_Contacto ";

            var result = new List<TipoContacto>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var tipocontacto = LoadTipoContribuyente(dr); // Mapper
                        result.Add(tipocontacto);
                    }
                }
            }

            return result;
        }

        private static TipoContacto LoadTipoContribuyente(IDataReader dr)
        {
            var tipocontacto = new TipoContacto
            {
                Id = GetDataValue<int>(dr, "id_tipocontacto"),
                Nombre = GetDataValue<string>(dr, "Valor_TipoContacto"),
            };


            return tipocontacto;
        }

    }

    }

