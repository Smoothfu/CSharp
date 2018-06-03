using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ProductWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public static List<Product> selectProductListByPId = new List<Product>();
        public static SqlConnection SqlConn = new SqlConnection();
        public static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        public static DataSet ds = new DataSet();

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

        public SqlConnection GetSQLConnectionByConnString(string conString)
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                if(conn.State==ConnectionState.Open)
                {
                    return conn;
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }

            return new SqlConnection();
        }
        public List<Product> GetProductByPId(int pID)
        {
            try
            {
                SqlConn = GetSQLConnectionByConnString(connString);
                if (SqlConn.State == ConnectionState.Open)
                {
                    using (SqlCommand selectCmd = new SqlCommand())
                    {
                        selectCmd.CommandType = CommandType.StoredProcedure;
                        selectCmd.CommandText = "spGetProductByPID";
                        selectCmd.Connection = SqlConn;
                        sqlDataAdapter.SelectCommand = selectCmd;
                        sqlDataAdapter.Fill(ds);

                        if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                selectProductListByPId.Add(new Product()
                                {
                                    PID = (int)ds.Tables[0].Rows[i][0],
                                    Name = ds.Tables[0].Rows[i][1].ToString(),
                                    PNO = ds.Tables[0].Rows[i][2].ToString(),
                                    MF = ds.Tables[0].Rows[i][3].ToString(),
                                    FGF = ds.Tables[0].Rows[i][4].ToString(),
                                    Color = ds.Tables[0].Rows[i][5].ToString(),
                                    SSL = ds.Tables[0].Rows[i][6].ToString(),
                                    ROP = ds.Tables[0].Rows[i][7].ToString(),
                                    SC = ds.Tables[0].Rows[i][8].ToString(),
                                    LP = ds.Tables[0].Rows[i][9].ToString()
                                });
                            }
                        }
                    }
                }
                return selectProductListByPId;            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return selectProductListByPId = new List<Product>();
            }
        }       
    }
}
