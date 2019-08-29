using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DBDll
{
    public class DBDataTable
    {
        public DataTable GetDataTable()
        {
            Configuration myDllConfig =
            ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
            // Get the appSettings section
            AppSettingsSection myDllConfigAppSettings =
            (AppSettingsSection)myDllConfig.GetSection("appSettings");

            string connString = myDllConfigAppSettings.Settings["SQLConnString"].Value;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectSQL = "select * from dbo.sod2";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, conn))
                {
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
            }
            return dt;
        }

    }
}
