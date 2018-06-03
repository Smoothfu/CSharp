using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProductWCFServices.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ProductWCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
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

        public List<SProduct> GetSProductByPID(int pID)
        {
            List<SProduct> SProductList = new List<SProduct>();
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SProduct sProd = new SProduct();
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if(conn.State==ConnectionState.Open)
            {
                MessageBox.Show("Connected to the database successfully!");
                using (SqlCommand selectCmd = new SqlCommand())
                {
                    selectCmd.CommandType = CommandType.StoredProcedure;
                    selectCmd.CommandText = "spGetProductByPID";
                    selectCmd.Connection = conn;
                    selectCmd.Parameters.Add(new SqlParameter("@PID", pID));
                    sqlDataAdapter.SelectCommand = selectCmd;
                    sqlDataAdapter.Fill(ds);

                    if(ds.Tables!=null && ds.Tables[0].Rows.Count>0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            sProd = new SProduct()
                            {
                                SPID = (int)ds.Tables[0].Rows[i][0],
                                SName = ds.Tables[0].Rows[i][1].ToString(),
                                SPNO = ds.Tables[0].Rows[i][2].ToString(),
                                SMF = ds.Tables[0].Rows[i][3].ToString(),
                                SFGF = ds.Tables[0].Rows[i][4].ToString(),
                                SColor = ds.Tables[0].Rows[i][5].ToString(),
                                SSSL = ds.Tables[0].Rows[i][6].ToString(),
                                SROP = ds.Tables[0].Rows[i][7].ToString(),
                                SSC = ds.Tables[0].Rows[i][8].ToString(),
                                SLP = ds.Tables[0].Rows[i][9].ToString()
                            };
                            SProductList.Add(sProd);
                        }
                    }
                }
            }
            return SProductList;
        }
    }
}
