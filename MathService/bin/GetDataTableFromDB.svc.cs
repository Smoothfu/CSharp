using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace MathService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetDataTableFromDB" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetDataTableFromDB.svc or GetDataTableFromDB.svc.cs at the Solution Explorer and start debugging.
    public class GetDataTableFromDB : IGetDataTableFromDB
    {
        public string GetDataTableFromDBResult()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectSQL = "select *from AdventureWorks2017.Sales.SalesOrderDetail";
                using (SqlCommand selectCmd = new SqlCommand(selectSQL, conn))
                {
                    selectCmd.CommandType = CommandType.Text;
                    selectCmd.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = selectCmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            return $"Rows count:{dt.Rows.Count},Columns count:{dt.Columns.Count}";
        }
    }
}
