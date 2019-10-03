using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure
{
    public static  class DBHelper
    {
        static string ConnString { get; set; }

        static DBHelper()
        {
            ConnString = GetSQLConString();
        }

        static string GetSQLConString()
        {
            Configuration myDllConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            // Get the appSettings section
            AppSettingsSection myDllConfigAppSettings =(AppSettingsSection)myDllConfig.GetSection("appSettings");
            string connString = myDllConfigAppSettings.Settings["SQLConnString"].Value;
            return connString;
        }        
         
        public static DataTable ExecuteSelectSQL(string selectSQL)
        {
            
            DataTable dt = new DataTable();
            using(SqlConnection conn=new SqlConnection(ConnString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                using(SqlDataAdapter dataAdapter=new SqlDataAdapter(selectSQL,conn))
                {
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dt = ds.Tables[0]; 
                }
            }
            return dt;
        }

        public static bool ExecuteDMLSQL(string dmlSQL)
        {
            int executedResult = 0;
            using(SqlConnection conn=new SqlConnection(ConnString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                using(SqlCommand cmd=new SqlCommand(dmlSQL,conn))
                {
                   executedResult= cmd.ExecuteNonQuery();
                }
            }
            return executedResult>0;
        }
    }
}
