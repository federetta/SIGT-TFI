using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessComponent
    {
        protected const string ConnectionName = "Data Source=frdell\\sqlexpress;Initial Catalog=SIGT_Web;Integrated Security=True";

        static DataAccessComponent()
        {
            // Enterprise Library DAAB 6.0 - Database Factories.
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }

        //protected int PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        //protected int PageSize
        //{
        //    get
        //    {
        //        return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        //    }
        //}

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            var i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}

