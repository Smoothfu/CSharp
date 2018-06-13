using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfService7
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string AddMethod(int x, int y)
        {
            return string.Format("AddMethod2 in WCF service Application:{0}+{1}={2}\n", x, y, x + y);
        }

        public List<Store> GetAllStoresFromvStoreWithContacts()
        {
            List<Store> storeList = new List<Store>();
            string sqlSource = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(sqlSource);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetStoreWithContacts";
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            storeList.Add(new Store()
                            {
                                BID=(int)ds.Tables[0].Rows[i][0],
                                Name=ds.Tables[0].Rows[i][1].ToString(),
                                CT=ds.Tables[0].Rows[i][2].ToString(),
                                Title=ds.Tables[0].Rows[i][3].ToString(),
                                FN=ds.Tables[0].Rows[i][4].ToString(),
                                MN=ds.Tables[0].Rows[i][5].ToString(),
                                LN=ds.Tables[0].Rows[i][6].ToString()
                            });
                        }                       
                    }
                }
            }

            return storeList;
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

        public string MultiplyMethod(int x, int y)
        {
            return string.Format("MultiplyMethod2 in WCF Service Application.{0}*{1}={2}\n", x, y, x * y);
        }
    }
}
