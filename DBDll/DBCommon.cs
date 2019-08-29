using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DBDll
{
    public class DBCommon
    {
        public static SqlConnection GetSqlConnection()
        {
            Configuration myDllConfig =
            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            // Get the appSettings section
            AppSettingsSection myDllConfigAppSettings =(AppSettingsSection)myDllConfig.GetSection("appSettings");
            string connString = myDllConfigAppSettings.Settings["SQLConnString"].Value;
            SqlConnection connection = new SqlConnection(connString);
            return connection;
        }
    }
}
