using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConexionSQL
    {
        private SqlConnection conexion;
        //private string connectionString;

        public SqlConnection ConectarBaseDatos()
        {
            try
            {
                conexion = new SqlConnection("Data Source = frdell\\sqlexpress; Initial Catalog = SIGT_Web; Integrated Security = True");
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible conectarse con la base de datos, consulte con su administrador.");
            }
            return conexion;
        }
        public SqlConnection DesconectarBaseDatos()
        {
            try
            {
                conexion = new SqlConnection("Data Source = frdell\\sqlexpress; Initial Catalog = SIGT_Web; Integrated Security = True");
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible desconectarse con la base de datos, consulte con su administrador.");
            }
            return conexion;
        }
    }
}
