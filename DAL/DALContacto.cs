using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALContacto : DataAccessComponent
    {
        public Contacto CreateContacto(Contacto contacto)
        {
            const string sqlStatement = "INSERT INTO dbo.Contacto ([Id_Empresa]," +
                " [Id_TipoContacto], [Valor_Contacto]) " +
                "VALUES(@Id_Empresa, @Id_TipoContacto, @Valor_Contacto); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id_Empresa", DbType.Int32, contacto.idempresa);
                db.AddInParameter(cmd, "@Id_TipoContacto", DbType.Int32, contacto.idtipocontacto);
                db.AddInParameter(cmd, "@Valor_Contacto", DbType.String, contacto.Valor);
                // Obtener el valor de la primary key.
                contacto.id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return contacto;
        }


        private void agregarParametro(SqlCommand cmd, string nombre, object valor, ParameterDirection direccion, SqlDbType tipo)
        {
            SqlParameter parametro = cmd.CreateParameter();
            parametro.ParameterName = nombre;
            parametro.Direction = direccion;
            parametro.SqlDbType = tipo;
            parametro.Value = valor;
            cmd.Parameters.Add(parametro);
        }

        /// <summary>
        /// Seleccionar contacto segun empresa.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contacto> SelectContacto(int id)
        {
            const string sqlStatement = "SELECT [Id_Contacto]," +
                "                       [Id_Empresa]," +
                "                       [Id_TipoContacto]," +
                "                       [Valor_Contacto] " +
                "                       FROM[dbo].[Contacto]" +
                "                       WHERE [Id_Empresa] = @Id_Empresa";

            var result = new List<Contacto>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id_Empresa", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var contacto = LoadContacto(dr); // Mapper
                        result.Add(contacto);
                    }
                }
            }

            return result;
        }


        private static Contacto LoadContacto(IDataReader dr)
        {
            var contacto = new Contacto
            {

                id = GetDataValue<int>(dr, "Id_Contacto"),
                idempresa = GetDataValue<int>(dr, "Id_Empresa"),
                idtipocontacto = GetDataValue<int>(dr, "Id_TipoContacto"),
                Valor = GetDataValue<string>(dr, "Valor_Contacto"),
            };


            return contacto;
        }
    }
}
