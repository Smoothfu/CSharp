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
        static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        static SqlConnection conn = new SqlConnection(connString);
        static List<SProduct> SProductList = new List<SProduct>();
        static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        static DataSet ds = new DataSet();

        public Service1()
        {
                        
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

        public List<SProduct> GetSProductByPID(int pID)
        {    
            SProduct sProd = new SProduct();
            if(conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }            

            Nullable<DateTime> dt = null;
           
            if(conn.State==ConnectionState.Open)
            {               
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
                                SName = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["name"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["name"].ToString(),
                                SPNO = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["pno"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["pno"].ToString(),
                                SMF = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["mf"].ToString()) ? default(bool) : (bool)ds.Tables[0].Rows[i]["mf"],
                                SFGF = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["FGF"].ToString()) ? default(bool) : (bool)ds.Tables[0].Rows[i]["FGF"],
                                SColor = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["color"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["color"].ToString(),
                                SSSL = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["SSL"].ToString()) ? default(Int16): (Int16)ds.Tables[0].Rows[i]["SSL"],
                                SROP = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["rop"].ToString()) ? default(Int16) : (Int16)ds.Tables[0].Rows[i]["rop"],
                                SSC = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["SC"].ToString()) ? default(decimal) : (decimal)ds.Tables[0].Rows[i]["SC"],
                                SLP = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["lp"].ToString()) ? default(decimal) : (decimal)ds.Tables[0].Rows[i]["lp"],
                                SSize = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["size"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["size"].ToString(),
                                SSUMC = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["sumc"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["sumc"].ToString(),
                                SWUMC = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["wumc"].ToString()) ? default(string) : ds.Tables[0].Rows[i]["wumc"].ToString(),                                
                                SWeight = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["weight"].ToString())?default(decimal) : (decimal)ds.Tables[0].Rows[i]["weight"],
                                SDTM = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["DTM"].ToString()) ?default(int): (int)ds.Tables[0].Rows[i]["DTM"],
                                SPL =string.IsNullOrEmpty(ds.Tables[0].Rows[i]["pl"].ToString())?default(string): ds.Tables[0].Rows[i]["pl"].ToString(),
                                SClass = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["class"].ToString())? default(string) : ds.Tables[0].Rows[i]["class"].ToString(),                                
                                SStyle =string.IsNullOrEmpty(ds.Tables[0].Rows[i]["style"].ToString())? default(string) : ds.Tables[0].Rows[i]["style"].ToString(),
                                SPSID=string.IsNullOrEmpty(ds.Tables[0].Rows[i]["psid"].ToString()) ? default(int) : (int)ds.Tables[0].Rows[i]["psid"],
                                SPMID=string.IsNullOrEmpty(ds.Tables[0].Rows[i]["pmid"].ToString())?default(int):(int) ds.Tables[0].Rows[i]["pmid"], 
                                SSSD=(DateTime)ds.Tables[0].Rows[i]["SSD"],
                                SSED =ds.Tables[0].Rows[i]["SED"]== DBNull.Value ? dt : (DateTime?)ds.Tables[0].Rows[i]["SED"],
                                SDD=ds.Tables[0].Rows[i]["dd"]==DBNull.Value? dt : (DateTime?)ds.Tables[0].Rows[i]["dd"],
                                SRG =string.IsNullOrEmpty(ds.Tables[0].Rows[i]["rg"].ToString())?default(Guid) : (Guid)ds.Tables[0].Rows[i]["rg"],
                                SMD = (DateTime)ds.Tables[0].Rows[i]["md"]
                            };
                            SProductList.Add(sProd);
                        }
                    }
                }
            }
            return SProductList;
        }

        public List<SProduct> SaveProducts(List<SProduct> sProdList)
        {   
            if(sProdList==null ||!sProdList.Any())
            {
                MessageBox.Show("No items");
                return null;
            }
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);
            
            if(sProdList!=null && sProdList.Any())
            {
                for(int i=0;i<sProdList.Count;i++)
                {
                    ds.Tables[0].Rows[i]["PID"] = sProdList[i].SPID;
                    ds.Tables[0].Rows[i]["Name"] = sProdList[i].SName;
                    ds.Tables[0].Rows[i]["PNO"] = sProdList[i].SPNO;
                    ds.Tables[0].Rows[i]["MF"] = sProdList[i].SMF;
                    ds.Tables[0].Rows[i]["FGF"] = sProdList[i].SFGF;
                    ds.Tables[0].Rows[i]["Color"] = sProdList[i].SColor;
                    ds.Tables[0].Rows[i]["SSL"] = sProdList[i].SSSL;
                    ds.Tables[0].Rows[i]["ROP"] = sProdList[i].SROP;
                    ds.Tables[0].Rows[i]["SC"] = sProdList[i].SSC;
                    ds.Tables[0].Rows[i]["LP"] = sProdList[i].SLP;
                    ds.Tables[0].Rows[i]["Size"] = sProdList[i].SSize;
                    ds.Tables[0].Rows[i]["SUMC"] = sProdList[i].SSUMC;
                    ds.Tables[0].Rows[i]["WUMC"] = sProdList[i].SWUMC;
                    ds.Tables[0].Rows[i]["Weight"] = sProdList[i].SWeight;
                    ds.Tables[0].Rows[i]["DTM"] = sProdList[i].SDTM;
                    ds.Tables[0].Rows[i]["PL"] = sProdList[i].SPL;
                    ds.Tables[0].Rows[i]["class"] = sProdList[i].SClass;
                    ds.Tables[0].Rows[i]["style"] = sProdList[i].SStyle;
                    ds.Tables[0].Rows[i]["PSID"] = sProdList[i].SPSID;
                    ds.Tables[0].Rows[i]["PMID"] = sProdList[i].SPMID;
                    ds.Tables[0].Rows[i]["SSD"] = sProdList[i].SSSD;
                    ds.Tables[0].Rows[i]["SED"] = sProdList[i].SSED== null ? (object)DBNull.Value: sProdList[i].SSED;
                    ds.Tables[0].Rows[i]["DD"] = sProdList[i].SDD==null?(object)DBNull.Value:sProdList[i].SDD;
                    ds.Tables[0].Rows[i]["RG"] = sProdList[i].SRG;
                    ds.Tables[0].Rows[i]["MD"] = sProdList[i].SMD;

                }
            }
            sqlDataAdapter.UpdateCommand = builder.GetUpdateCommand();

            sqlDataAdapter.Update(ds);

            var returnedNewServerList = GetSProductByPID(0);
            return returnedNewServerList;
        }
    }
}
