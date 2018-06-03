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
                                SPID = (int)ds.Tables[0].Rows[i]["pid"],
                                SName = ds.Tables[0].Rows[i]["name"].ToString(),
                                SPNO = ds.Tables[0].Rows[i]["pno"].ToString(),
                                SMF = (bool)ds.Tables[0].Rows[i]["mf"],
                                SFGF = (bool)ds.Tables[0].Rows[i]["FGF"],
                                SColor = ds.Tables[0].Rows[i]["color"].ToString(),
                                SSSL = (Int16)ds.Tables[0].Rows[i]["SSL"],
                                SROP = (Int16)ds.Tables[0].Rows[i]["rop"],
                                SSC = (decimal)ds.Tables[0].Rows[i]["SC"],
                                SLP = (decimal)ds.Tables[0].Rows[i]["lp"],
                                SSize = ds.Tables[0].Rows[i]["size"].ToString(),
                                SSUMC = ds.Tables[0].Rows[i]["sumc"].ToString(),
                                SWUMC = ds.Tables[0].Rows[i]["wumc"].ToString(),
                                SWeight = (decimal)ds.Tables[0].Rows[i]["weight"],
                                SDTM = (int)ds.Tables[0].Rows[i]["DTM"],
                                SPL = ds.Tables[0].Rows[i]["pl"].ToString(),
                                SClass = ds.Tables[0].Rows[i]["class"].ToString(),
                                SStyle = ds.Tables[0].Rows[i]["style"].ToString(),
                                SPSID=(int)ds.Tables[0].Rows[i]["psid"],
                                SPMID=(int)ds.Tables[0].Rows[i]["pmid"],
                                SSSD=(DateTime)ds.Tables[0].Rows[i]["SSD"],
                                SSED=(DateTime)ds.Tables[0].Rows[i]["SED"],
                                SDD=(DateTime)ds.Tables[0].Rows[i]["dd"],
                                SRG=(Guid)ds.Tables[0].Rows[i]["rg"],
                                SMD=(DateTime)ds.Tables[0].Rows[i]["md"]
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
