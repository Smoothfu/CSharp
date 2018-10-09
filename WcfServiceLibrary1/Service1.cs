using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DbService : IDBService
    {
        public List<DbClass> GetDbClassList()
        {
            List<DbClass> dbList = new List<DbClass>();
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = "select TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.tables";

                SqlDataAdapter dataAdaper = new SqlDataAdapter(selectSQL, conn);

                DataSet ds = new DataSet();
                dataAdaper.Fill(ds);

                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dbList.Add(new DbClass()
                        {
                            STableCatalog = ds.Tables[0].Rows[i]["TABLE_CATALOG"].ToString(),
                            STableScheme = ds.Tables[0].Rows[i]["TABLE_SCHEMA"].ToString(),
                            STableName = ds.Tables[0].Rows[i]["TABLE_NAME"].ToString(),
                            STableType = ds.Tables[0].Rows[i]["TABLE_TYPE"].ToString()
                        });
                    }
                }
            }

            if (dbList.Any())
            {
                return dbList;
            }
            return null;
        }
    }
}
