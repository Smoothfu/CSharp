using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ServerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetDataTable" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetDataTable.svc or GetDataTable.svc.cs at the Solution Explorer and start debugging.
    public class GetDataTable : IGetDataTable
    {
        DataTable IGetDataTable.GetDataTable()
        {
            string connString= ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            string selectSQL = "select * from INFORMATION_SCHEMA.ROUTINES  where ROUTINE_TYPE='function'";
            DataTable dt = new DataTable();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, connString))
            {
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }            
            return dt;
        }         
    }
}
