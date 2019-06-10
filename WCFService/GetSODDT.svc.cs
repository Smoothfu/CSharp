using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration; 
using System.Data.SqlClient;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetSODDT" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetSODDT.svc or GetSODDT.svc.cs at the Solution Explorer and start debugging.
    public class GetSODDT : IGetSODDT
    {
        public DataTable GetSalesOrderDetailDT()
        {
            DataTable dt = new DataTable("DB Table");
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = "select * from sales.SalesOrderDetail";
                using (SqlCommand selectCmd = new SqlCommand(selectSQL, conn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
                    {
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dt = ds.Tables[0];
                    }
                }
            }
            return dt;
        }
    }
}
