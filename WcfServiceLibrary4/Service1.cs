using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int AddMethod(int x, int y)
        {
            return x + y;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<DataDesc> GetDBDescs()
        {
            List<DataDesc> dbList = new List<DataDesc>();
            string conString = ConfigurationManager.AppSettings["dbConnectString"].ToString();
            string selectSQL = "select TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.TABLES";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                if(ds.Tables!=null && ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        dbList.Add(new DataDesc
                        {
                            TableCatalog = ds.Tables[0].Rows[i]["TABLE_CATALOG"].ToString(),
                            TableSchema = ds.Tables[0].Rows[i]["TABLE_SCHEMA"].ToString(),
                            TableName = ds.Tables[0].Rows[i]["TABLE_NAME"].ToString(),
                            TableType = ds.Tables[0].Rows[i]["TABLE_TYPE"].ToString()
                        });
                    }
                }
            }

            if(dbList.Any())
            {
                return dbList;
            }
            return null;
        }
    }
}
