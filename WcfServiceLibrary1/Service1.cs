using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary1.Model;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
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

        public List<ProductInventory> GetPIList()
        {
            List<ProductInventory> pIList = new List<ProductInventory>();
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductInventory";
                    cmd.Connection = conn;

                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(ds);

                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            pIList.Add(new ProductInventory()
                            {
                                PID = (int)ds.Tables[0].Rows[i][0],
                                LID = (short)ds.Tables[0].Rows[i][1],
                                Shelf=(string)ds.Tables[0].Rows[i][2],
                                Bin=(byte)ds.Tables[0].Rows[i][3],
                                Quantity=(short)ds.Tables[0].Rows[i][4],
                                RowGuid=(Guid)ds.Tables[0].Rows[i][5],
                                MD=(DateTime)ds.Tables[0].Rows[i][6]
                            });
                        }
                        
                    }
                }
            }
            return pIList;
        }
    }
}
