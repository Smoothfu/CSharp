using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerDataTableService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IGetDBDatabTable" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IGetDBDatabTable.svc or IGetDBDatabTable.svc.cs at the Solution Explorer and start debugging.
    public class GetDBDatabTable : IGetDBDatabTable
    {
        public DataTable GetDBDataTable()
        {
            DataTable dt = new DataTable("Server Database DataTable");
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectSQL = "select * from sales.SalesOrderDetail";
                using (SqlCommand selectCmd = new SqlCommand())
                {
                    selectCmd.Connection = conn;
                    selectCmd.CommandText = selectSQL;
                    selectCmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = selectCmd;
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        dt = ds.Tables[0];
                    }
                }
            }
            return dt;
        }
    }
}
