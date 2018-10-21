using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
   public class DALListaPrecio : DataAccessComponent
    {
        /// <summary>
        ///     ''' Creo Lista de Precio, en el Store Procedure en cada insert la fecha de inicio pisa la fecha final del anterior registro
        ///     ''' por lo que solo existe un precio vigente. 
        ///     ''' </summary>
        ///     ''' <param name="ListaPrecio"></param>
        ///     ''' <returns></returns>
        public ListaPrecio CrearListaPrecio(ListaPrecio ListaPrecio)
        {
            try
            {
                Services.ConexionSQL conexion = new Services.ConexionSQL();
                var link = conexion.ConectarBaseDatos();
                conexion.ConectarBaseDatos();
                SqlCommand cmd = new SqlCommand("INSERTAR_LISTAPRECIO", link);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idrecorrido_listaPrecio", SqlDbType.Int).Value = ListaPrecio.idrecorrido;
                cmd.Parameters.Add("@FechaInicial_listaPrecio", SqlDbType.Date).Value = ListaPrecio.fechainicial;
                // cmd.Parameters.Add("@fechaFinal_listaPrecio", SqlDbType.Date).Value = ListaPrecio.fechaFinal
                cmd.Parameters.Add("@precio_listaPrecio", SqlDbType.Decimal).Value = ListaPrecio.precio;
                cmd.Parameters.Add("@comision_listaPrecio", SqlDbType.Decimal).Value = ListaPrecio.comision;

                // Declaro el ID para retornarlo en el textbox
                var returnParameter = cmd.Parameters.Add("@id_listaprecio", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                // Retorno el ID_OBRA
                var result = returnParameter.Value;
                ListaPrecio.id = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaPrecio;
        }

       
        /// <summary>
        /// Trae la lista de precios segun el ID del recorrido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ListaPrecio> SelectListaPrecio(int id)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [id_listaPrecio]," +
                "                       [IdRecorrido_listaPrecio]," +
                "                       [FechaInicial_listaPrecio]," +
                "                       [FechaFinal_listaPrecio], " +
                "                       [precio_listaPrecio], " +
                "                       [comision_listaPrecio]" +
                "                       FROM[dbo].[ListaPrecio]" +
                "                       WHERE [IdRecorrido_listaPrecio] = @Idrecorrido_listaPrecio";

            var result = new List<ListaPrecio>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Idrecorrido_listaPrecio", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Recorrido = LoadListaPrecio(dr); // Mapper
                        result.Add(Recorrido);
                    }
                }
            }

            return result;
        }
        private static ListaPrecio LoadListaPrecio(IDataReader dr)
        {
            var Listaprecio = new ListaPrecio
            {

                id = GetDataValue<int>(dr, "id_listaPrecio"),
                idrecorrido = GetDataValue<int>(dr, "IdRecorrido_listaPrecio"),
                fechainicial = GetDataValue<DateTime>(dr, "FechaInicial_listaPrecio"),
                fechafinal = GetDataValue<DateTime>(dr, "FechaFinal_listaPrecio"),
                precio = GetDataValue<decimal>(dr, "precio_listaPrecio"),
                comision = GetDataValue<decimal>(dr, "comision_listaPrecio"),

            };
            return Listaprecio;
        }



    }
}
